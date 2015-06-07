//----------------------------------------------------------------------------------
// <copyright file="FindUsPageController.cs" company="Logikfabrik">
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
    using Models;
    using Umbraco.Jet.Web.Mvc;
    using ViewModels;

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

            return this.View(jm);
        }
    }
}
