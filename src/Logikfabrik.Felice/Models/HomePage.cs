using Logikfabrik.Umbraco.Jet;
using Logikfabrik.Umbraco.Jet.Web.Mvc;

namespace Logikfabrik.Felice.Models
{
    [DocumentType(
        "Home page",
        Description = "Document type for a home page",
        AllowedAsRoot = true,
        AllowedChildNodeTypes = new[]
        {
            typeof(Settings), 
            typeof(LunchMenus), 
            typeof(Menu),
            typeof(EatWithUsPage),
            typeof(FindUsPage)
        },
        Icon = "icon-home")]
    [PreviewTemplate]
    public class HomePage : BasePage
    {
    }
}