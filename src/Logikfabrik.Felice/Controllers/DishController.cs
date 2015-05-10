using System;
using System.Web.Mvc;
using Logikfabrik.Felice.Helpers;
using Umbraco.Web.WebApi;

namespace Logikfabrik.Felice.Controllers
{
    public class DishController : UmbracoApiController
    {
        private readonly LunchMenuHelper lunchMenuHelper;

        public DishController()
            : this(new LunchMenuHelper(new PageHelper(), new DateHelper()))
        {
        }

        public DishController(LunchMenuHelper lunchMenuHelper)
        {
            if (lunchMenuHelper == null)
                throw new ArgumentNullException("lunchMenuHelper");

            this.lunchMenuHelper = lunchMenuHelper;
        }

        public object GetDishOfTheDay(DateTime date)
        {
            var menu = lunchMenuHelper.GetMenuOfTheWeek(date);

            if (menu == null)
                return new JsonResult { Data = new { } };

            var dish = lunchMenuHelper.GetDishOfTheDay(date);

            if (dish == null)
                return new JsonResult { Data = new { } };

            return new JsonResult
            {
                Data = new
                {
                    Dish = dish,
                    menu.Week,
                    menu.Preamble1,
                    menu.Preamble2
                }
            };
        }
    }
}
