//----------------------------------------------------------------------------------
// <copyright file="FindUsPage.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Models
{
    using Umbraco.Jet;
    using Umbraco.Jet.Web.Mvc;

    [DocumentType(
        "Find us page",
        Description = "Document type for a find us page",
        Icon = "icon-pin-location")]
    [PreviewTemplate]
    public class FindUsPage : BasePage
    {
    }
}