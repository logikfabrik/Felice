//----------------------------------------------------------------------------------
// <copyright file="BasePage.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class BasePage
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        [ScaffoldColumn(false)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        [ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the update date.
        /// </summary>
        [ScaffoldColumn(false)]
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [ScaffoldColumn(false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the meta description.
        /// </summary>
        [Display(
            Name = "Description",
            Description = "A short description of the page",
            GroupName = "SEO",
            Order = 100)]
        public string MetaDescription { get; set; }

        /// <summary>
        /// Gets or sets the meta keywords.
        /// </summary>
        [Display(
            Name = "Keywords",
            Description = "Comma-separated keywords for the page",
            GroupName = "SEO",
            Order = 200)]
        public string MetaKeywords { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the page is navigable or not.
        /// </summary>
        [ScaffoldColumn(false)]
        // ReSharper disable once InconsistentNaming
        public bool umbracoNaviHide { get; set; }
    }
}