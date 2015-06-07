using System;

namespace Logikfabrik.Felice.DataTypes
{
    public class OpeningHour
    {
        private readonly string name;
        private readonly DayOfWeek? dayOfWeek;
        private readonly DateTime? date;
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        public OpeningHour(string name, DayOfWeek dayOfWeek, TimeSpan from, TimeSpan to)
            : this(name, from, to)
        {
            this.dayOfWeek = dayOfWeek;
        }

        public OpeningHour(string name, DateTime date, TimeSpan from, TimeSpan to)
            : this(name, from, to)
        {
            this.date = date;
        }

        private OpeningHour(string name, TimeSpan from, TimeSpan to)
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
        public string Name { get { return this.name; } }

        /// <summary>
        /// Gets day of week.
        /// </summary>
        public DayOfWeek? DayOfWeek { get { return this.dayOfWeek; } }

        /// <summary>
        /// Gets date.
        /// </summary>
        public DateTime? Date { get { return this.date; } }

        /// <summary>
        /// Gets time from.
        /// </summary>
        public TimeSpan From { get { return this.from; } }

        /// <summary>
        /// Gets time to.
        /// </summary>
        public TimeSpan To { get { return this.to; } }
    }
}