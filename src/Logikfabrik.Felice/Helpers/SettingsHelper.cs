//----------------------------------------------------------------------------------
// <copyright file="SettingsHelper.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Helpers
{
    using System;
    using DataTypes;
    using Models;
    using Umbraco.Jet.Maps;

    public class SettingsHelper
    {
        private readonly Lazy<Settings> settings;

        public SettingsHelper(IPageHelper pageHelper)
        {
            if (pageHelper == null)
            {
                throw new ArgumentNullException("pageHelper");
            }

            this.settings = new Lazy<Settings>(pageHelper.GetPageOfType<Settings>);
        }

        /// <summary>
        /// Gets the street address.
        /// </summary>
        /// <returns>The street address.</returns>
        public string GetStreetAddress()
        {
            return this.settings.Value == null ? null : this.settings.Value.StreetAddress;
        }

        /// <summary>
        /// Gets the zip code.
        /// </summary>
        /// <returns>The zip code.</returns>
        public int GetZipCode()
        {
            return this.settings.Value == null ? default(int) : this.settings.Value.ZipCode;
        }

        /// <summary>
        /// Gets the city.
        /// </summary>
        /// <returns>The city.</returns>
        public string GetCity()
        {
            return this.settings.Value == null ? null : this.settings.Value.City;
        }

        /// <summary>
        /// Gets the phone number.
        /// </summary>
        /// <returns>The phone number.</returns>
        public string GetPhoneNumber()
        {
            return this.settings.Value == null ? null : this.settings.Value.PhoneNumber;
        }

        /// <summary>
        /// Gets the opening hours.
        /// </summary>
        /// <returns>The opening hours.</returns>
        public OpeningHours GetOpeningHours()
        {
            if (this.settings.Value == null)
            {
                return new OpeningHours();
            }

            var openingHours = this.settings.Value.OpeningHours;

            return openingHours ?? new OpeningHours();
        }

        /// <summary>
        /// Gets the map coordinates.
        /// </summary>
        public GeoCoordinates GetMapCoordinates()
        {
            if (this.settings.Value == null)
            {
                return null;
            }

            var mapCoordinates = this.settings.Value.MapCoordinates;

            return mapCoordinates;
        }
    }
}