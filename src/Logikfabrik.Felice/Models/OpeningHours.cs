using System;

namespace Logikfabrik.Felice.Models
{
    public class OpeningHours
    {
        private readonly string name;
        private readonly DayOfWeek? dayOfWeek;
        private readonly DateTime? date;
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        public OpeningHours(string name, DayOfWeek dayOfWeek, TimeSpan from, TimeSpan to)
            : this(name, from, to)
        {
            this.dayOfWeek = dayOfWeek;
        }

        public OpeningHours(string name, DateTime date, TimeSpan from, TimeSpan to)
            : this(name, from, to)
        {
            this.date = date;
        }

        private OpeningHours(string name, TimeSpan from, TimeSpan to)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or white space.", "name");

            this.name = name;
            this.from = from;
            this.to = to;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Gets day of week.
        /// </summary>
        public DayOfWeek? DayOfWeek { get { return dayOfWeek; } }

        /// <summary>
        /// Gets date.
        /// </summary>
        public DateTime? Date { get { return date; } }

        /// <summary>
        /// Gets time from.
        /// </summary>
        public TimeSpan From { get { return from; } }

        /// <summary>
        /// Gets time to.
        /// </summary>
        public TimeSpan To { get { return to; } }
    }
}