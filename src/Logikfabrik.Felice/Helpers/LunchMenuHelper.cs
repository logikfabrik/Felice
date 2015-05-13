using System;
using System.Collections.Generic;
using System.Linq;
using Logikfabrik.Felice.Models;

namespace Logikfabrik.Felice.Helpers
{
    public class LunchMenuHelper
    {
        private readonly IPageHelper pageHelper;
        private readonly DateHelper dateHelper;

        public LunchMenuHelper(IPageHelper pageHelper, DateHelper dateHelper)
        {
            if (pageHelper == null)
                throw new ArgumentNullException("pageHelper");

            if (dateHelper == null)
                throw new ArgumentNullException("dateHelper");

            this.pageHelper = pageHelper;
            this.dateHelper = dateHelper;
        }

        /// <summary>
        /// Gets the menu of the week.
        /// </summary>
        /// <param name="date">The current date.</param>
        /// <returns>The menu of the week.</returns>
        public LunchMenu GetMenuOfTheWeek(DateTime date)
        {
            var year = date.Year;
            var week = this.dateHelper.GetWeekOfYearISO8601(date);

            return GetMenuOfTheWeek(year, week);
        }

        /// <summary>
        /// Gets the menu of the week.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="week">The week.</param>
        /// <returns>The menu of the week.</returns>
        public LunchMenu GetMenuOfTheWeek(int year, int week)
        {
            return this.pageHelper.GetLunchMenus().FirstOrDefault(m => IsMatch(m, year, week));
        }

        public IEnumerable<LunchMenu> GetTheNext5Menus(DateTime date)
        {
            var year = date.Year;
            var week = this.dateHelper.GetWeekOfYearISO8601(date);

            var lunchMenus = this.pageHelper.GetLunchMenus().OrderBy(m => m.Year).ThenBy(m => m.Week);

            return lunchMenus.SkipWhile(m => m.Year != year && m.Week != week).Take(5);
        }
        
        /// <summary>
        /// Gets the dish of the day.
        /// </summary>
        /// <returns>The dish of the day.</returns>
        public string GetDishOfTheDay()
        {
            return GetDishOfTheDay(DateTime.Now);
        }

        /// <summary>
        /// Gets the dish of the day.
        /// </summary>
        /// <param name="date">The current date.</param>
        /// <returns>The dish of the day.</returns>
        public string GetDishOfTheDay(DateTime date)
        {
            var day = this.dateHelper.GetDayOfWeek(date);
            var menu = GetMenuOfTheWeek(date);

            if (menu == null)
                return null;

            switch (day)
            {
                case DayOfWeek.Monday:
                    return menu.Monday;
                case DayOfWeek.Tuesday:
                    return menu.Tuesday;
                case DayOfWeek.Wednesday:
                    return menu.Wednesday;
                case DayOfWeek.Thursday:
                    return menu.Thursday;
                case DayOfWeek.Friday:
                    return menu.Friday;
                case DayOfWeek.Saturday:
                    return menu.Saturday;
                case DayOfWeek.Sunday:
                    return menu.Sunday;
                default:
                    return null;
            }
        }

        private static bool IsMatch(LunchMenu menu, int year, int week)
        {
            return menu.Year == year && menu.Week == week;
        }
    }
}