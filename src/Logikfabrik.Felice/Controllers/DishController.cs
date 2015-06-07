//----------------------------------------------------------------------------------
// <copyright file="DishController.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Controllers
{
    using System;
    using System.Web.Mvc;
    using Helpers;
    using global::Umbraco.Web.WebApi;

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
            {
                throw new ArgumentNullException("lunchMenuHelper");
            }

            this.lunchMenuHelper = lunchMenuHelper;
        }

        public JsonResult GetDishOfTheDay()
        {
            var date = DateTime.Now;
            var menu = this.lunchMenuHelper.GetLunchMenuOfTheWeek(date);

            if (menu == null)
            {
                return new JsonResult { Data = new { } };
            }

            var dish = this.lunchMenuHelper.GetDishOfTheDay(date);

            if (dish == null)
            {
                return new JsonResult { Data = new { } };
            }

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
