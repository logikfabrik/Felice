using AutoMapper;
using Logikfabrik.Felice.Helpers;
using Logikfabrik.Felice.Models;
using Logikfabrik.Felice.ViewModels;
using Logikfabrik.Umbraco.Jet.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Logikfabrik.Felice.Controllers
{
    public class FindUsPageController : JetController
    {
        private readonly OpeningHoursHelper openingHoursHelper;

        public FindUsPageController()
            : this(new PageHelper())
        {
        }

        public FindUsPageController(IPageHelper pageHelper)
            : this(new OpeningHoursHelper(pageHelper, new DateHelper()))
        {
        }

        public FindUsPageController(OpeningHoursHelper openingHoursHelper)
        {
            if (openingHoursHelper == null)
            {
                throw new ArgumentNullException("openingHoursHelper");
            }

            this.openingHoursHelper = openingHoursHelper;
        }

        public ActionResult Index(FindUsPage model)
        {
            var jm = Mapper.Map<FindUsPageViewModel>(model);

            jm.OpeningHours =
                Mapper.Map<IEnumerable<HoursViewModel>>(this.openingHoursHelper.GetOpeningHoursOfTheWeek(DateTime.Now));

            return View(jm);
        }
    }
}
