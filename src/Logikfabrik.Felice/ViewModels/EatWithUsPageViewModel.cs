using System.Collections.Generic;

namespace Logikfabrik.Felice.ViewModels
{
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