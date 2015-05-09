using System;

namespace Logikfabrik.Felice.Models
{
    public class Hours
    {
        private readonly string name;
        private readonly DateTime date;
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        public string Name { get { return name; } }

        public DateTime Date { get { return date; } }

        public TimeSpan From { get { return from; } }

        public TimeSpan To { get { return to; } }

        public Hours(string name, DateTime date, TimeSpan from, TimeSpan to)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or white space.", "name");

            this.name = name;
            this.date = date;
            this.from = from;
            this.to = to;
        }
    }
}