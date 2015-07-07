//----------------------------------------------------------------------------------
// <copyright file="OpeningHoursController.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;
    using Helpers;
    using global::Umbraco.Web.WebApi;

    public class OpeningHoursController : UmbracoApiController
    {
        private readonly OpeningHoursHelper openingHoursHelper;

        public OpeningHoursController()
            : this(new OpeningHoursHelper(new PageHelper(), new DateHelper()))
        {
        }

        public OpeningHoursController(OpeningHoursHelper openingHoursHelper)
        {
            if (openingHoursHelper == null)
            {
                throw new ArgumentNullException("openingHoursHelper");
            }

            this.openingHoursHelper = openingHoursHelper;
        }

        public JsonResult GetOpeningHoursOfTheDay()
        {
            var date = DateTime.Now;
            var hours = this.openingHoursHelper.GetOpeningHoursOfTheDay(date);

            if (hours == null)
            {
                return new JsonResult { Data = new { } };
            }

            return new JsonResult
            {
                Data = new
                {
                    hours.Name,
                    From = hours.From.ToString("hh\\:mm"),
                    To = hours.To.ToString("hh\\:mm")
                }
            };
        }

        public JsonResult GetDayNames()
        {
            var dayNames = CultureInfo.CurrentCulture.DateTimeFormat.DayNames.ToArray();

            return new JsonResult
            {
                Data =
                    dayNames.Select(
                        dayName =>
                            new
                            {
                                name =
                                    dayName.First().ToString(CultureInfo.InvariantCulture).ToUpper() +
                                    dayName.Substring(1),
                                value = Array.IndexOf(dayNames, dayName)
                            })
            };
        }
    }
}
