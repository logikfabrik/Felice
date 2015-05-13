using Logikfabrik.Umbraco.Jet;
using Logikfabrik.Umbraco.Jet.Web.Mvc;

namespace Logikfabrik.Felice.Models
{
    [DocumentType(
        "Eat with us page",
        Description = "Document type for a eat with us page",
        Icon = "icon-food")]
    [PreviewTemplate]
    public class EatWithUsPage : BasePage
    {
    }
}