using SmartDepo.Models;

namespace SmartDepo.Services
{
    public class TramService : ITramService
    {
        private readonly HttpClient httpClient;

        public TramService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Tram>> GetDepoAsync()
        {
            return await httpClient.GetFromJsonAsync<Tram[]>("api/Tram");
        }
    }
}
