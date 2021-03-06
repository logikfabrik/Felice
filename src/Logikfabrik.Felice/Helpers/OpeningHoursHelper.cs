﻿//----------------------------------------------------------------------------------
// <copyright file="OpeningHoursHelper.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataTypes;
    using Models;

    public class OpeningHoursHelper
    {
        private readonly SettingsHelper settingsHelper;
        private readonly DateHelper dateHelper;

        public OpeningHoursHelper(IPageHelper pageHelper, DateHelper dateHelper)
        {
            if (pageHelper == null)
            {
                throw new ArgumentNullException("pageHelper");
            }

            if (dateHelper == null)
            {
                throw new ArgumentNullException("dateHelper");
            }

            this.settingsHelper = new SettingsHelper(pageHelper);
            this.dateHelper = dateHelper;
        }

        /// <summary>
        /// Gets the opening hours of the day.
        /// </summary>
        /// <param name="date">The current date.</param>
        /// <returns>The opening hours of the day.</returns>
        /// <remarks>All opening hours are hours the restaurant is open. If no hours are returned the restaurant is closed.</remarks>
        public Hours GetOpeningHoursOfTheDay(DateTime date)
        {
            // Opening hours for specific dates takes precedence.
            var openingHours = this.settingsHelper.GetOpeningHours().Where(h => this.IsForDate(h, date)).ToArray();

            var hours = openingHours.Any(h => h.Date.HasValue)
                ? openingHours.First(h => h.Date.HasValue)
                : openingHours.FirstOrDefault();

            return hours == null ? null : new Hours(hours.Name, date, hours.From, hours.To);
        }

        public IEnumerable<Hours> GetOpeningHoursOfTheWeek(DateTime date)
        {
            var daysInWeek = this.dateHelper.GetDaysInWeek(date.Year, this.dateHelper.GetWeekOfYearISO8601(date));

            return daysInWeek.Select(this.GetOpeningHoursOfTheDay).Where(h => h != null);
        }

        /// <summary>
        /// Gets whether or not the opening hours are for the current date.
        /// </summary>
        /// <param name="openingHours">The opening hours.</param>
        /// <param name="date">The current date.</param>
        /// <returns>True it the opening hours are for the current date; otherwise false.</returns>
        private bool IsForDate(OpeningHour openingHours, DateTime date)
        {
            if (openingHours == null)
            {
                throw new ArgumentNullException("openingHours");
            }

            if (openingHours.Date.HasValue)
            {
                return openingHours.Date.Value.Year == date.Year && openingHours.Date.Value.Month == date.Month && openingHours.Date.Value.Day == date.Day;
            }

            return this.IsBetweenDaysOfWeek(openingHours, date);
        }

        private bool IsBetweenDaysOfWeek(OpeningHour openingHours, DateTime date)
        {
            if (openingHours == null)
            {
                throw new ArgumentNullException("openingHours");
            }

            if (!openingHours.DayOfWeek.HasValue)
            {
                return false;
            }

            return openingHours.DayOfWeek.Value == this.dateHelper.GetDayOfWeek(date);
        }
    }
}