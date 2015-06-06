using System;

namespace Logikfabrik.Felice.ViewModels
{
    public class HoursViewModel
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan From { get; set; }

        public TimeSpan To { get; set; }
    }
}