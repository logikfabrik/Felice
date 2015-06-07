//----------------------------------------------------------------------------------
// <copyright file="EatWithUsPageController.cs" company="Logikfabrik">
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

    public class EatWithUsPageController : JetController
    {
        private readonly LunchMenuHelper lunchMenuHelper;
        private readonly MenuHelper menuHelper;
        private readonly PageHelper pageHelper;

        public EatWithUsPageController()
            : this(new PageHelper())
        {
        }

        public EatWithUsPageController(PageHelper pageHelper)
            : this(new LunchMenuHelper(pageHelper, new DateHelper()), new MenuHelper(pageHelper))
        {
            if (pageHelper == null)
            {
                throw new ArgumentNullException("pageHelper");
            }

            this.pageHelper = pageHelper;
        }

        public EatWithUsPageController(LunchMenuHelper lunchMenuHelper, MenuHelper menuHelper)
        {
            if (lunchMenuHelper == null)
            {
                throw new ArgumentNullException("lunchMenuHelper");
            }

            if (menuHelper == null)
            {
                throw new ArgumentNullException("menuHelper");
            }

            this.lunchMenuHelper = lunchMenuHelper;
            this.menuHelper = menuHelper;
        }

        public ActionResult Index(EatWithUsPage model)
        {
            var lunchMenu = this.lunchMenuHelper.GetLunchMenuOfTheWeek(DateTime.Now);

            return this.Index(model, lunchMenu);
        }

        [ActionName("ViewLunchMenu")]
        public ActionResult Index(int year, int week)
        {
            var model = this.pageHelper.GetPageOfType<EatWithUsPage>();

            if (model == null)
            {
                return this.HttpNotFound();
            }
                
            var lunchMenu = this.lunchMenuHelper.GetLunchMenuOfTheWeek(year, week);

            return lunchMenu == null ? this.HttpNotFound() : this.Index(model, lunchMenu);
        }

        private ActionResult Index(EatWithUsPage model, LunchMenu lunchMenu)
        {
            if (model == null)
            {
                throw new ArgumentNullException("lunchMenu");
            }
            
            var jm = Mapper.Map<EatWithUsPageViewModel>(model);

            if (lunchMenu != null)
            {
                jm.LunchMenu = Mapper.Map<LunchMenuViewModel>(lunchMenu);
            }

            jm.Menu = Mapper.Map<IEnumerable<MenuDishViewModel>>(this.menuHelper.GetDishes());

            return this.View("Index", jm);
        }
    }
}
