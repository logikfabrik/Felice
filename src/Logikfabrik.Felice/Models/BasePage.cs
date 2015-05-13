using System;
using System.ComponentModel.DataAnnotations;

namespace Logikfabrik.Felice.Models
{
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
            Description = "Comma-separated keywords for the page.",
            GroupName = "SEO",
            Order = 200)]
        public string MetaKeywords { get; set; }

        [ScaffoldColumn(false)]
        // ReSharper disable once InconsistentNaming
        public bool umbracoNaviHide { get; set; }
    }
}