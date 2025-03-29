using Microsoft.AspNetCore.Mvc;
using SmartDepo.Models;
using System.Text;

namespace SmartDepo.Services
{
    public class TramService : ITramService
    {
        private readonly HttpClient httpClient;

        public TramService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> FreeTramAsync(Tram tram)
        {
            return await httpClient.PutAsJsonAsync($"api/Tram/{tram.Id}", tram);
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
