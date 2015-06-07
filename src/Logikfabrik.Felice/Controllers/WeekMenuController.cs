//----------------------------------------------------------------------------------
// <copyright file="WeekMenuController.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using AutoMapper;
    using Helpers;
    using global::Umbraco.Web.Mvc;
    using ViewModels;

    public class WeekMenuController : SurfaceController
    {
        private readonly LunchMenuHelper lunchMenuHelper;

        public WeekMenuController()
            : this(new LunchMenuHelper(new PageHelper(), new DateHelper()))
        {
        }

        public WeekMenuController(LunchMenuHelper lunchMenuHelper)
        {
            if (lunchMenuHelper == null)
            {
                throw new ArgumentNullException("lunchMenuHelper");
            }

            this.lunchMenuHelper = lunchMenuHelper;
        }

        [ChildActionOnly]
        public PartialViewResult WeekMenu()
        {
            var menus = this.lunchMenuHelper.GetTheNext5LunchMenus(DateTime.Now);

            return this.PartialView(Mapper.Map<IEnumerable<MenuItemViewModel>>(menus));
        }
    }
}