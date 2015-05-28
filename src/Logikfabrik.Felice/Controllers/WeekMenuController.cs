using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Logikfabrik.Felice.Helpers;
using Logikfabrik.Felice.ViewModels;
using Umbraco.Web.Mvc;

namespace Logikfabrik.Felice.Controllers
{
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
                throw new ArgumentNullException("lunchMenuHelper");

            this.lunchMenuHelper = lunchMenuHelper;
        }

        [ChildActionOnly]
        public PartialViewResult WeekMenu()
        {
            var menus = this.lunchMenuHelper.GetTheNext5LunchMenus(DateTime.Now);

            return PartialView(Mapper.Map<IEnumerable<MenuItemViewModel>>(menus));
        }
    }
}