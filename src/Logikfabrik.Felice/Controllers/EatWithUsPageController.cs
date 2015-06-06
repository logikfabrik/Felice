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
        private readonly PageHelper pageHelper;

        public EatWithUsPageController()
            : this(new PageHelper())
        {
        }

        public EatWithUsPageController(PageHelper pageHelper)
            : this(new LunchMenuHelper(pageHelper, new DateHelper()))
        {
            if (pageHelper == null)
                throw new ArgumentNullException("pageHelper");

            this.pageHelper = pageHelper;
        }

        public EatWithUsPageController(LunchMenuHelper lunchMenuHelper)
        {
            if (lunchMenuHelper == null)
                throw new ArgumentNullException("lunchMenuHelper");

            this.lunchMenuHelper = lunchMenuHelper;
        }

        public ActionResult Index(EatWithUsPage model)
        {
            var menu = this.lunchMenuHelper.GetLunchMenuOfTheWeek(DateTime.Now);

            return Index(model, menu);
        }

        [ActionName("ViewLunchMenu")]
        public ActionResult Index(int year, int week)
        {
            var model = pageHelper.GetPageOfType<EatWithUsPage>();

            if (model == null)
                return HttpNotFound();

            var menu = this.lunchMenuHelper.GetLunchMenuOfTheWeek(year, week);

            return menu == null ? HttpNotFound() : Index(model, menu);
        }

        private ActionResult Index(EatWithUsPage model, LunchMenu menu)
        {
            if (model == null)
                throw new ArgumentNullException("menu");

            var jm = Mapper.Map<EatWithUsPageViewModel>(model);

            jm.HasLunchMenu = menu != null;

            if (menu != null)
                Mapper.Map(menu, jm);

            return View("Index", jm);
        }
    }
}
