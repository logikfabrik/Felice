using Logikfabrik.Umbraco.Jet;
using Logikfabrik.Umbraco.Jet.Web.Mvc;

namespace Logikfabrik.Felice.Models
{
    [DocumentType(
        "Find us page",
        Description = "Document type for a find us page")]
    [PreviewTemplate]
    public class FindUsPage : BasePage
    {
    }
}