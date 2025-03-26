using SmartDepoAPI;

namespace SmartDepo.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient httpClient;

        public WeatherService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
        {
            return await httpClient.GetFromJsonAsync<WeatherForecast[]>("api/WeatherForecast");
        }
    }
}
