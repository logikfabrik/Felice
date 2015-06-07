//----------------------------------------------------------------------------------
// <copyright file="HomePageController.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Models;
    using Umbraco.Jet.Web.Mvc;
    using ViewModels;

    public class HomePageController : JetController
    {
        public ActionResult Index(HomePage model)
        {
            var jm = Mapper.Map<HomePageViewModel>(model);

            return this.View(jm);
        }
    }
}
