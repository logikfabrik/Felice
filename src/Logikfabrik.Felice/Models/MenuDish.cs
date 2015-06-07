//----------------------------------------------------------------------------------
// <copyright file="MenuDish.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Models
{
    using System.ComponentModel.DataAnnotations;
    using Umbraco.Jet;

    [DocumentType(
        "Menu dish",
        Description = "A menu dish",
        Icon = "icon-food")]
    public class MenuDish
    {
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