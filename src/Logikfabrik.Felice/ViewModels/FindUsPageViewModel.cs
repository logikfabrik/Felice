//----------------------------------------------------------------------------------
// <copyright file="FindUsPageViewModel.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Find us page view model.
    /// </summary>
    public class FindUsPageViewModel : BasePageViewModel
    {
        /// <summary>
        /// Gets or sets the opening hours week.
        /// </summary>
        public int OpeningHoursWeek { get; set; }

        /// <summary>
        /// Gets or sets the opening hours.
        /// </summary>
        public IEnumerable<HoursViewModel> OpeningHours { get; set; }
    }
}