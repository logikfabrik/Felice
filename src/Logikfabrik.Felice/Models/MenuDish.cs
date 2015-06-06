using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Logikfabrik.Umbraco.Jet;

namespace Logikfabrik.Felice.Models
{
    [DocumentType(
        "Menu dish",
        Description = "A menu dish",
        Icon = "icon-food")]
    public class MenuDish
    {
        [Display(Name = "Navigable")]
        [DefaultValue(true)]
        // ReSharper disable once InconsistentNaming
        public bool umbracoNaviHide { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Display(
            Description = "A short description",
            GroupName = "Dish",
            Order = 100)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        [Display(
            Description = "The price in SEK",
            GroupName = "Dish",
            Order = 200)]
        public decimal Price { get; set; }
    }
}