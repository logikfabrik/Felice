using System;
using Logikfabrik.Umbraco.Jet.Maps;

namespace Logikfabrik.Felice.ViewModels
{
    public abstract class BasePageViewModel
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the update date.
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the meta description.
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// Gets or sets the meta keywords.
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// Gets or sets the street address.
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        public int ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets the address.
        /// </summary>
        public string Address
        {
            get
            {
                if (string.IsNullOrWhiteSpace(StreetAddress))
                    return null;

                if (ZipCode == default(int))
                    return null;

                return string.IsNullOrWhiteSpace(City)
                    ? null
                    : string.Format("{0}, {1:### ##} {2}", StreetAddress, ZipCode, City);
            }
        }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the map coordinates.
        /// </summary>
        public GeoCoordinates MapCoordinates { get; set; }
    }
}