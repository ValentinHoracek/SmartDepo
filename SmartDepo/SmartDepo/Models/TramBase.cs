
using Microsoft.AspNetCore.Components;
using SmartDepo.Services;

namespace SmartDepo.Models
{
    public class TramBase : ComponentBase
    {
        [Inject]
        public ITramService TramService { get; set; }

        public IEnumerable<Tram> Trams { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //Trams = (await TramService.GetDepoAsync()).ToList();
        }
        public async Task FetchData()
        {
            Trams = await TramService.GetTramsAsync();
        }

        public async Task ScheduleNext()
        {
            Tram next = await TramService.GetNextAsync();
            if (next is null)
            {
                return;
            }

            if (next.Order > Trams.Count())
            {
                Trams = Trams.Concat([next]);
            }
            else
            {
                Trams.Where(w => w.Id == next.Id).First().HasSchedule = next.HasSchedule;
            }
        }

        public async Task FreeTram(Tram tram)
        {
            tram.HasSchedule = false;
            await TramService.FreeTramAsync(tram);

            Trams.Where(w => w.Id == tram.Id).First().HasSchedule = tram.HasSchedule;
        }

    }
}
