//----------------------------------------------------------------------------------
// <copyright file="LunchMenus.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Models
{
    using Umbraco.Jet;

    [DocumentType(
        "Lunch menus",
        Description = "Lunch menus",
        AllowedChildNodeTypes = new[] { typeof(LunchMenu) },
        Icon = "icon-food")]
    public class LunchMenus
    {
        /// <summary>
        /// Gets or sets the first preamble.
        /// </summary>
        public string Preamble1 { get; set; }

        /// <summary>
        /// Gets or sets the second preamble.
        /// </summary>
        public string Preamble2 { get; set; }
    }
}