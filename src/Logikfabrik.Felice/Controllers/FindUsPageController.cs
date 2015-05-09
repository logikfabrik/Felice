using Logikfabrik.Felice.Models;
using Logikfabrik.Felice.ViewModels;
using Logikfabrik.Umbraco.Jet.Web.Mvc;
using System.Web.Mvc;

namespace Logikfabrik.Felice.Controllers
{
    public class FindUsPageController : JetController
    {
        public ActionResult Index(FindUsPage model)
        {
            var jm = AutoMapper.Mapper.Map<FindUsPageViewModel>(model);

            return View(jm);
        }
    }
}
