//----------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Models
{
    using System.ComponentModel.DataAnnotations;
    using DataTypes;
    using Umbraco.Jet;
    using Umbraco.Jet.Maps;

    [DocumentType(
        "Settings",
        Description = "Site settings",
        Icon = "icon-settings")]
    public class Settings
    {
        /// <summary>
        /// Gets or sets the street address.
        /// </summary>
        [Display(
            Name = "Street address",
            Description = "The restaurant street address",
            GroupName = "Contact",
            Order = 100)]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        [Display(
            Name = "Zip code", 
            Description = "The restaurant zip code",
            GroupName = "Contact",
            Order = 200)]
        public int ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [Display(
            Name = "City", 
            Description = "The restaurant city",
            GroupName = "Contact",
            Order = 300)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [Display(
            Name = "Phone number", 
            Description = "The restaurant phone number",
            GroupName = "Contact",
            Order = 400)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the map coordinates.
        /// </summary>
        [Display(
            Name = "Map", 
            Description = "The restaurant map coordinates",
            GroupName = "Contact",
            Order = 500)]
        public GeoCoordinates MapCoordinates { get; set; }

        /// <summary>
        /// Gets or sets the opening hours.
        /// </summary>
        [Display(
            Name = "Opening hours", 
            Description = "The restaurant opening hours",
            GroupName = "Opening hours",
            Order = 100)]
        public OpeningHours OpeningHours { get; set; }
    }
}