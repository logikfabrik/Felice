using System;
using System.Collections.Generic;
using System.Globalization;

namespace Logikfabrik.Felice.Helpers
{
    public class DateHelper
    {
        /// <summary>
        /// Gets the week of year.
        /// </summary>
        /// <param name="date">The current date.</param>
        /// <returns>The week of year.</returns>
        /// <remarks>Respects ISO 8601.</remarks>
        public int GetWeekOfYearIso8601(DateTime date)
        {
            while (true)
            {
                var iso = new[] { 6, 7, 8, 9, 10, 4, 5 };

                var firstDayOfYear = date.AddDays(-date.Day + 1).AddMonths(-date.Month + 1);
                var lastDayOfYear = firstDayOfYear.AddYears(1).AddDays(-1);
                var weekOfYear = (date.Subtract(firstDayOfYear).Days + iso[(int)firstDayOfYear.DayOfWeek]) / 7;

                switch (weekOfYear)
                {
                    case 0:
                        date = firstDayOfYear.AddDays(-1);
                        continue;
                    case 53:
                        return lastDayOfYear.DayOfWeek < DayOfWeek.Thursday ? 1 : weekOfYear;
                    default:
                        return weekOfYear;
                }
            }
        }
        
        /// <summary>
        /// Gets the day of week.
        /// </summary>
        /// <param name="date">The current date.</param>
        /// <returns>The day of week.</returns>
        public DayOfWeek GetDayOfWeek(DateTime date)
        {
            var format = DateTimeFormatInfo.CurrentInfo;

            // ReSharper disable once PossibleNullReferenceException
            return format.Calendar.GetDayOfWeek(date);
        }

        public IEnumerable<DateTime> GetDaysInWeek(int year, int week)
        {
            var days = new List<DateTime>();
            var date = FirstDateOfWeek(year, week);

            for (var i = 0; i < 7; i++)
                days.Add(date.AddDays(i));

            return days;
        }

        private DateTime FirstDateOfWeek(int year, int week)
        {
            var date = new DateTime(year, 1, 1);
            var format = DateTimeFormatInfo.CurrentInfo;
            // ReSharper disable once PossibleNullReferenceException
            var offset = GetDaysBetweenDaysOfWeek(format.FirstDayOfWeek, date.DayOfWeek);

            if (week <= 1)
                week--;

            return date.AddDays(offset).AddDays(week * 7);
        }

        public int GetDaysBetweenDaysOfWeek(DayOfWeek from, DayOfWeek to)
        {
            if (from == to)
                return 0;

            var c = (int)from;
            var d = (int)to;
            var n = (7 - c + d);

            return (n > 7) ? n % 7 : n;
        }
    }
}