
using Microsoft.AspNetCore.Components;
using SmartDepo.Models;
using SmartDepo.Services;

namespace SmartDepo.Components.Pages
{
    public class TramBase : ComponentBase
    {
        [Inject]
        public ITramService TramService { get; set; }

        public IEnumerable<Models.Tram> Trams { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Trams = (await TramService.GetDepoAsync()).ToList();
        }
        public async Task FetchData()
        {
           Trams = await TramService.GetDepoAsync();
        }
    }
}
