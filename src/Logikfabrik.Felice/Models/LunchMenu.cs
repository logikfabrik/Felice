//----------------------------------------------------------------------------------
// <copyright file="LunchMenu.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Models
{
    using System.ComponentModel.DataAnnotations;
    using Umbraco.Jet;

    [DocumentType(
        "Lunch menu",
        Description = "A lunch menu for a full week",
        Icon = "icon-food")]
    public class LunchMenu
    {
        /// <summary>
        /// Gets or sets the first preamble.
        /// </summary>
        [ScaffoldColumn(false)]
        public string Preamble1 { get; set; }

        /// <summary>
        /// Gets or sets the second preamble.
        /// </summary>
        [ScaffoldColumn(false)]
        public string Preamble2 { get; set; }

        /// <summary>
        /// Gets or sets the year the lunch menu is for.
        /// </summary>
        [Display(
            Description = "The year this menu is for",
            GroupName = "Menu",
            Order = 100)]
        [Required]
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the week the lunch menu is for.
        /// </summary>
        [Display(
            Description = "The week this menu is for",
            GroupName = "Menu",
            Order = 200)]
        [Required]
        public int Week { get; set; }

        /// <summary>
        /// Gets or sets the dish for Monday.
        /// </summary>
        [Display(
            Name = "Monday dish",
            Description = "The dish served on Monday",
            GroupName = "Menu",
            Order = 300)]
        public string Monday { get; set; }

        /// <summary>
        /// Gets or sets the dish for Tuesday.
        /// </summary>
        [Display(
            Name = "Tuesday dish",
            Description = "The dish served on Tuesday",
            GroupName = "Menu",
            Order = 400)]
        public string Tuesday { get; set; }

        /// <summary>
        /// Gets or sets the dish for Wednesday.
        /// </summary>
        [Display(
            Name = "Wednesday dish",
            Description = "The dish served on Wednesday",
            GroupName = "Menu",
            Order = 500)]
        public string Wednesday { get; set; }

        /// <summary>
        /// Gets or sets the dish for Thursday.
        /// </summary>
        [Display(
            Name = "Thursday dish",
            Description = "The dish served on Thursday",
            GroupName = "Menu",
            Order = 600)]
        public string Thursday { get; set; }

        /// <summary>
        /// Gets or sets the dish for Friday.
        /// </summary>
        [Display(
            Name = "Friday dish",
            Description = "The dish served on Friday",
            GroupName = "Menu",
            Order = 700)]
        public string Friday { get; set; }

        /// <summary>
        /// Gets or sets the dish for Saturday.
        /// </summary>
        [Display(
            Name = "Saturday dish",
            Description = "The dish served on Saturday",
            GroupName = "Menu",
            Order = 800)]
        public string Saturday { get; set; }

        /// <summary>
        /// Gets or sets the dish for Sunday.
        /// </summary>
        [Display(
            Name = "Sunday dish",
            Description = "The dish served on Sunday",
            GroupName = "Menu",
            Order = 900)]
        public string Sunday { get; set; }
    }
}