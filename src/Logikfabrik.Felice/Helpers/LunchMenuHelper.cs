﻿using System;
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

        private IEnumerable<LunchMenu> GetLunchMenus()
        {
            var lunchMenusPage = this.pageHelper.GetPageOfType<LunchMenus>();
            var lunchMenuPages = this.pageHelper.GetChildPagesOfType<LunchMenus, LunchMenu>().ToArray();

            foreach (var page in lunchMenuPages)
            {
                page.Preamble1 = lunchMenusPage.Preamble1;
                page.Preamble2 = lunchMenusPage.Preamble2;
            }

            return lunchMenuPages;
        }

        /// <summary>
        /// Gets the lunch menu of the week.
        /// </summary>
        /// <param name="date">The current date.</param>
        /// <returns>The lunch menu of the week.</returns>
        public LunchMenu GetLunchMenuOfTheWeek(DateTime date)
        {
            var year = date.Year;
            var week = this.dateHelper.GetWeekOfYearISO8601(date);

            return GetLunchMenuOfTheWeek(year, week);
        }

        /// <summary>
        /// Gets the lunch menu of the week.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="week">The week.</param>
        /// <returns>The lunch menu of the week.</returns>
        public LunchMenu GetLunchMenuOfTheWeek(int year, int week)
        {
            return GetLunchMenus().FirstOrDefault(m => IsMatch(m, year, week));
        }

        public IEnumerable<LunchMenu> GetTheNext5LunchMenus(DateTime date)
        {
            var year = date.Year;
            var week = this.dateHelper.GetWeekOfYearISO8601(date);

            var lunchMenus = GetLunchMenus().OrderBy(m => m.Year).ThenBy(m => m.Week);

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
            var menu = GetLunchMenuOfTheWeek(date);

            if (menu == null)
                return null;

            string dish = null;

            switch (day)
            {
                case DayOfWeek.Monday:
                    dish = menu.Monday;
                    break;

                case DayOfWeek.Tuesday:
                    dish = menu.Tuesday;
                    break;

                case DayOfWeek.Wednesday:
                    dish = menu.Wednesday;
                    break;

                case DayOfWeek.Thursday:
                    dish = menu.Thursday;
                    break;

                case DayOfWeek.Friday:
                    dish = menu.Friday;
                    break;

                case DayOfWeek.Saturday:
                    dish = menu.Saturday;
                    break;

                case DayOfWeek.Sunday:
                    dish = menu.Sunday;
                    break;
            }

            return string.IsNullOrWhiteSpace(dish) ? null : dish;
        }

        private static bool IsMatch(LunchMenu menu, int year, int week)
        {
            return menu.Year == year && menu.Week == week;
        }
    }
}