using System.ComponentModel.DataAnnotations;
using Logikfabrik.Umbraco.Jet;
using Logikfabrik.Umbraco.Jet.Web.Mvc;

namespace Logikfabrik.Felice.Models
{
    [DocumentType(
        "Standard page",
        Description = "Document type for a standard page",
        AllowedChildNodeTypes = new[] { typeof(StandardPage) })]
    [PreviewTemplate]
    public class StandardPage : BasePage
    {
        [Display(Name = "Navigable")]
        [ScaffoldColumn(true)]
        // ReSharper disable once InconsistentNaming
        public new bool umbracoNaviHide { get; set; }
    }
}