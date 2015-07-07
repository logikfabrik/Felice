//----------------------------------------------------------------------------------
// <copyright file="StandardPage.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Models
{
    using System.ComponentModel.DataAnnotations;
    using Umbraco.Jet;
    using Umbraco.Jet.Web.Mvc;

    [DocumentType(
        "Standard page",
        Description = "Document type for a standard page",
        AllowedChildNodeTypes = new[] { typeof(StandardPage) },
        Icon = "icon-document")]
    [PreviewTemplate]
    public class StandardPage : BasePage
    {
        /// <summary>
        /// Gets or sets a value indicating whether the page is navigable or not.
        /// </summary>
        [Display(Name = "Navigable")]
        [ScaffoldColumn(true)]
        // ReSharper disable once InconsistentNaming
        public new bool umbracoNaviHide { get; set; }
    }
}