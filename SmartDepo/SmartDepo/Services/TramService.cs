using SmartDepo.Models;

namespace SmartDepo.Services
{
    public class TramService : ITramService
    {
        /// <summary>
        /// HttpClient
        /// </summary>
        private readonly HttpClient httpClient;

        /// <summary>
        /// TramService constructor
        /// </summary>
        /// <param name="httpClient"></param>
        public TramService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// FreeTramAsync - PUT call to API to update tram.
        /// </summary>
        /// <param name="tram"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> FreeTramAsync(Tram tram)
        {
            return await httpClient.PutAsJsonAsync($"api/Tram/{tram.Id}", tram);
        }

        /// <summary>
        /// GetNextAsync - GET call to API to get next tram, or create new.
        /// </summary>
        /// <returns></returns>
        public async Task<Tram> GetNextAsync()
        {
            return await httpClient.GetFromJsonAsync<Tram>("api/Tram/Next");
        }

        /// <summary>
        /// GetTramsAsync - GET call to API to get all trams.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Tram>> GetTramsAsync()
        {
            return await httpClient.GetFromJsonAsync<Tram[]>("api/Tram");
        }
    }
}
