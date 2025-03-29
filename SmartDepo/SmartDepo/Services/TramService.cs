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

        public async Task<Tram> GetNextAsync()
        {
            return await httpClient.GetFromJsonAsync<Tram>("api/Tram/Next");
        }

        public async Task<IEnumerable<Tram>> GetTramsAsync()
        {
            return await httpClient.GetFromJsonAsync<Tram[]>("api/Tram");
        }
    }
}
