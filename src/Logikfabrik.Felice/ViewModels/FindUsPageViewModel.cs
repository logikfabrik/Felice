using System.Collections.Generic;

namespace Logikfabrik.Felice.ViewModels
{
    public class FindUsPageViewModel : BasePageViewModel
    {
        public int OpeningHoursWeek { get; set; }

        public IEnumerable<HoursViewModel> OpeningHours { get; set; }
    }
}