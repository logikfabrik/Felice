using Logikfabrik.Umbraco.Jet;
using Logikfabrik.Umbraco.Jet.Maps;
using Logikfabrik.Umbraco.Jet.Web.Mvc;

namespace Logikfabrik.Felice.Models
{
    [DocumentType(
        "Eat with us page",
        Description = "Document type for a eat with us page")]
    [PreviewTemplate]
    public class EatWithUsPage : BasePage
    {
        public GeoCoordinates Map { get; set; }
    }
}