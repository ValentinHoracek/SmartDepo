
using Microsoft.AspNetCore.Components;
using SmartDepo.Services;

namespace SmartDepo.Models
{
    public class TramBase : ComponentBase
    {
        /// <summary>
        /// Injected TramService
        /// </summary>
        [Inject]
        public ITramService TramService { get; set; }

        /// <summary>
        /// List of trams
        /// </summary>
        public IEnumerable<Tram> Trams { get; set; }

        /// <summary>
        /// OnInitializedAsync - set Tram on initialization.
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            // Trams = (await TramService.GetDepoAsync()).ToList();
        }

        /// <summary>
        /// FetchData - fetches data from TramService.
        /// </summary>
        /// <returns></returns>
        public async Task FetchData()
        {
            Trams = await TramService.GetTramsAsync();
        }

        /// <summary>
        /// ScheduleNext - schedules next tram.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// FreeTram - frees tram.
        /// </summary>
        /// <param name="tram">Tram to be freed from schedule.</param>
        /// <returns></returns>
        public async Task FreeTram(Tram tram)
        {
            tram.HasSchedule = false;
            await TramService.FreeTramAsync(tram);

            Trams.Where(w => w.Id == tram.Id).First().HasSchedule = tram.HasSchedule;
        }
    }
}
