﻿using Logikfabrik.Felice.Helpers;
using Logikfabrik.Felice.Models;
using Logikfabrik.Felice.ViewModels;
using Logikfabrik.Umbraco.Jet.Web.Mvc;
using System;
using System.Web.Mvc;

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
            var jm = AutoMapper.Mapper.Map<EatWithUsPageViewModel>(model);
            var menu = lunchMenuHelper.GetMenuOfTheWeek(DateTime.Now);

            jm.HasMenu = menu != null;

            if (menu != null)
                AutoMapper.Mapper.Map(menu, jm);

            return View(jm);
        }
    }
}