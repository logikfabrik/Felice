//----------------------------------------------------------------------------------
// <copyright file="HomePage.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Models
{
    using Umbraco.Jet;
    using Umbraco.Jet.Web.Mvc;

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