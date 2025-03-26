using SmartDepo.Models;
namespace SmartDepo.Services
{
    public interface ITramService
    {
        Task<IEnumerable<Tram>> GetDepoAsync();
    }
}
