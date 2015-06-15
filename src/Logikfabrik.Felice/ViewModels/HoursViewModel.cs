//----------------------------------------------------------------------------------
// <copyright file="HoursViewModel.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.ViewModels
{
    using System;

    public class HoursViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the time from.
        /// </summary>
        public TimeSpan From { get; set; }

        /// <summary>
        /// Gets or sets the time to.
        /// </summary>
        public TimeSpan To { get; set; }
    }
}