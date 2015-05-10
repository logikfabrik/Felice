using System.Web.Mvc;
using AutoMapper;
using Logikfabrik.Felice.Models;
using Logikfabrik.Felice.ViewModels;
using Logikfabrik.Umbraco.Jet.Web.Mvc;

namespace Logikfabrik.Felice.Controllers
{
    public class FindUsPageController : JetController
    {
        public ActionResult Index(FindUsPage model)
        {
            var jm = Mapper.Map<FindUsPageViewModel>(model);

            return View(jm);
        }
    }
}
