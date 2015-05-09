using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Logikfabrik.Umbraco.Jet;

namespace Logikfabrik.Felice.Models
{
    [DocumentType(
        "Menu dish",
        Description = "A menu dish")]
    public class MenuDish
    {
        [Display(Name = "Navigable")]
        [DefaultValue(true)]
        // ReSharper disable once InconsistentNaming
        public bool umbracoNaviHide { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }
    }
}