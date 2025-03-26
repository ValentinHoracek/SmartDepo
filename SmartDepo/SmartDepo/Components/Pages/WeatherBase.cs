using Microsoft.AspNetCore.Components;
using SmartDepo.Services;
using SmartDepoAPI;
using System.Net.Http;

namespace SmartDepo.Components.Pages
{
    public class WeatherBase : ComponentBase
    {
        [Inject]
        public IWeatherService WeatherService { get; set; }

        public IEnumerable<WeatherForecast> WeatherForecasts { get; set; }

        protected override async Task OnInitializedAsync()
        {
            WeatherForecasts = (await WeatherService.GetWeatherForecastsAsync()).ToList();
        }
        public async Task FetchData()
        {
           WeatherForecasts = await WeatherService.GetWeatherForecastsAsync();
        }
    }
}
