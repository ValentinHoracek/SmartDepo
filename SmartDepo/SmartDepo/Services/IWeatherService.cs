using SmartDepoAPI;

namespace SmartDepo.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync();
    }
}
