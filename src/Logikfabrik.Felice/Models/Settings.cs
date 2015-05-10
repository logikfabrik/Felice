using System.ComponentModel.DataAnnotations;
using Logikfabrik.Felice.DataTypes;
using Logikfabrik.Umbraco.Jet;
using Logikfabrik.Umbraco.Jet.Maps;

namespace Logikfabrik.Felice.Models
{
    [DocumentType(
        "Settings",
        Description = "Site settings",
        Icon = "icon-settings")]
    public class Settings
    {
        /// <summary>
        /// Gets or sets the street address.
        /// </summary>
        [Display(Name = "Street address", GroupName = "Contact")]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        [Display(Name = "Zip code", GroupName = "Contact")]
        public int ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [Display(Name = "City", GroupName = "Contact")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [Display(Name = "Phone number", GroupName = "Contact")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the opening hours.
        /// </summary>
        [Display(Name = "Opening hours", GroupName = "Opening hours")]
        public OpeningHours OpeningHours { get; set; }

        /// <summary>
        /// Gets or sets the map coordinates.
        /// </summary>
        [Display(Name = "Map", GroupName = "Map coordinates")]
        public GeoCoordinates MapCoordinates { get; set; }
    }
}