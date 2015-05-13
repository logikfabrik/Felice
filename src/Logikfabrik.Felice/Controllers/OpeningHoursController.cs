using System;
using System.Web.Mvc;
using Logikfabrik.Felice.Helpers;
using Umbraco.Web.WebApi;

namespace Logikfabrik.Felice.Controllers
{
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
                throw new ArgumentNullException("openingHoursHelper");

            this.openingHoursHelper = openingHoursHelper;
        }

        public JsonResult GetOpeningHoursOfTheDay(DateTime date)
        {
            var hours = this.openingHoursHelper.GetOpeningHoursOfTheDay(date);

            if (hours == null)
                return new JsonResult { Data = new { } };

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
    }
}
