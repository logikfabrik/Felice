//----------------------------------------------------------------------------------
// <copyright file="EatWithUsPage.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Models
{
    using Umbraco.Jet;
    using Umbraco.Jet.Web.Mvc;

    [DocumentType(
        "Eat with us page",
        Description = "Document type for a eat with us page",
        Icon = "icon-food")]
    [PreviewTemplate]
    public class EatWithUsPage : BasePage
    {
    }
}