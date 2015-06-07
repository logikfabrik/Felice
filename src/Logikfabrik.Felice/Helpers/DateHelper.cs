//----------------------------------------------------------------------------------
// <copyright file="DateHelper.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class DateHelper
    {
        /// <summary>
        /// Gets the week of year for the given date.
        /// </summary>
        /// <param name="date">A date.</param>
        /// <returns>The week of year.</returns>
        // ReSharper disable once InconsistentNaming
        public int GetWeekOfYearISO8601(DateTime date)
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
        /// Gets the day of week for the given date.
        /// </summary>
        /// <param name="date">A date.</param>
        /// <returns>The day of week.</returns>
        public DayOfWeek GetDayOfWeek(DateTime date)
        {
            var format = DateTimeFormatInfo.CurrentInfo;

            // ReSharper disable once PossibleNullReferenceException
            return format.Calendar.GetDayOfWeek(date);
        }

        /// <summary>
        /// Gets the days in week for the given year and week.
        /// </summary>
        /// <param name="year">A year.</param>
        /// <param name="week">A week.</param>
        /// <returns>The days in week.</returns>
        public IEnumerable<DateTime> GetDaysInWeek(int year, int week)
        {
            if (year < 1 || year > 9999)
            {
                throw new ArgumentOutOfRangeException("year");
            }

            if (week < 1)
            {
                throw new ArgumentOutOfRangeException("week");
            }

            var days = new List<DateTime>();
            var date = FirstDateOfWeek(year, week);

            for (var i = 0; i < 7; i++)
            {
                days.Add(date.AddDays(i));
            }

            return days;
        }
        
        /// <summary>
        /// Gets the weeks of year for the given year.
        /// </summary>
        /// <param name="year">A year.</param>
        /// <returns>The weeks of year.</returns>
        // ReSharper disable once InconsistentNaming
        public int GetWeeksOfYearISO8601(int year)
        {
            if (year < 1 || year > 9999)
            {
                throw new ArgumentOutOfRangeException("year");
            }

            // The 28th of December will always fall within the last week, according to ISO 8601.
            var date = new DateTime(year, 12, 28);

            return GetWeekOfYearISO8601(date);
        }

        private static DateTime FirstDateOfWeek(int year, int week)
        {
            if (year < 1 || year > 9999)
            {
                throw new ArgumentOutOfRangeException("year");
            }

            if (week < 1)
            {
                throw new ArgumentOutOfRangeException("week");
            }

            var date = new DateTime(year, 1, 1);
            var format = DateTimeFormatInfo.CurrentInfo;
            // ReSharper disable once PossibleNullReferenceException
            var offset = GetDaysBetweenDaysOfWeek(format.FirstDayOfWeek, date.DayOfWeek);
            
            return date.AddDays((week - 1) * 7).AddDays(-1 * offset);
        }

        private static int GetDaysBetweenDaysOfWeek(DayOfWeek from, DayOfWeek to)
        {
            if (from == to)
            {
                return 0;
            }

            var c = (int)from;
            var d = (int)to;
            var n = (7 - c + d);

            return (n > 7) ? n % 7 : n;
        }
    }
}