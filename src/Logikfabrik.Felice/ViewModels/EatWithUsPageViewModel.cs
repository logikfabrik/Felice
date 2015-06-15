//----------------------------------------------------------------------------------
// <copyright file="EatWithUsPageViewModel.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Eat with us page view model.
    /// </summary>
    public class EatWithUsPageViewModel : BasePageViewModel
    {
        /// <summary>
        /// Gets or sets the lunch menu.
        /// </summary>
        public LunchMenuViewModel LunchMenu { get; set; }

        /// <summary>
        /// Gets or sets the menu (dishes).
        /// </summary>
        public IEnumerable<MenuDishViewModel> Menu { get; set; }
    }
}