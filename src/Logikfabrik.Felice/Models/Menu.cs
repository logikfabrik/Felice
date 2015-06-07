//----------------------------------------------------------------------------------
// <copyright file="Menu.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Models
{
    using Umbraco.Jet;

    [DocumentType(
        "Menu",
        Description = "A menu",
        AllowedChildNodeTypes = new[] { typeof(MenuDish) },
        Icon = "icon-food")]
    public class Menu
    {
    }
}