using Logikfabrik.Felice.Models;
using Logikfabrik.Felice.ViewModels;
using Logikfabrik.Umbraco.Jet.Web.Mvc;
using System.Web.Mvc;

namespace Logikfabrik.Felice.Controllers
{
    public class HomePageController : JetController
    {
        public ActionResult Index(HomePage model)
        {
            var jm = AutoMapper.Mapper.Map<HomePageViewModel>(model);

            return View(jm);
        }
    }
}
