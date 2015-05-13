using System;
using System.Web.Mvc;
using AutoMapper;
using Logikfabrik.Felice.Helpers;
using Logikfabrik.Felice.Models;
using Logikfabrik.Felice.ViewModels;
using Logikfabrik.Umbraco.Jet.Web.Mvc;

namespace Logikfabrik.Felice.Controllers
{
    public class EatWithUsPageController : JetController
    {
        private readonly LunchMenuHelper lunchMenuHelper;

        public EatWithUsPageController()
            : this(new LunchMenuHelper(new PageHelper(), new DateHelper()))
        {
        }

        public EatWithUsPageController(LunchMenuHelper lunchMenuHelper)
        {
            if (lunchMenuHelper == null)
                throw new ArgumentNullException("lunchMenuHelper");

            this.lunchMenuHelper = lunchMenuHelper;
        }

        public ActionResult Index(EatWithUsPage model)
        {
            var jm = Mapper.Map<EatWithUsPageViewModel>(model);
            var menu = this.lunchMenuHelper.GetMenuOfTheWeek(DateTime.Now);

            jm.HasMenu = menu != null;

            if (menu != null)
                Mapper.Map(menu, jm);

            return View(jm);
        }
    }
}
