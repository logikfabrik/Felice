﻿using Logikfabrik.Felice.Models;
using System;
using System.Collections.Generic;

namespace Logikfabrik.Felice.Helpers
{
    public class SettingsHelper
    {
        private readonly Lazy<Settings> settings;

        public SettingsHelper(IPageHelper pageHelper)
        {
            if (pageHelper == null)
                throw new ArgumentNullException("pageHelper");

            settings = new Lazy<Settings>(pageHelper.GetSettings);
        }

        /// <summary>
        /// Gets the street address.
        /// </summary>
        /// <returns>The street address.</returns>
        public string GetStreetAddress()
        {
            return settings.Value == null ? null : settings.Value.StreetAddress;
        }

        /// <summary>
        /// Gets the zip code.
        /// </summary>
        /// <returns>The zip code.</returns>
        public int GetZipCode()
        {
            return settings.Value == null ? default(int) : settings.Value.ZipCode;
        }

        /// <summary>
        /// Gets the city.
        /// </summary>
        /// <returns>The city.</returns>
        public string GetCity()
        {
            return settings.Value == null ? null : settings.Value.City;
        }

        /// <summary>
        /// Gets the phone number.
        /// </summary>
        /// <returns>The phone number.</returns>
        public string GetPhoneNumber()
        {
            return settings.Value == null ? null : settings.Value.PhoneNumber;
        }

        /// <summary>
        /// Gets the opening hours.
        /// </summary>
        /// <returns>The opening hours.</returns>
        public IEnumerable<OpeningHours> GetOpeningHours()
        {
            if (settings.Value == null)
                return new OpeningHours[] { };

            var openingHours = settings.Value.OpeningHours;

            return openingHours ?? new OpeningHours[] { };
        }
    }
}