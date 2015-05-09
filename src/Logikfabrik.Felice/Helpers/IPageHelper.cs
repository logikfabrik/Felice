using System.Collections.Generic;
using Logikfabrik.Felice.Models;

namespace Logikfabrik.Felice.Helpers
{
    public interface IPageHelper
    {
        /// <summary>
        /// Gets the lunch menus.
        /// </summary>
        /// <returns>The lunch menus.</returns>
        IEnumerable<LunchMenu> GetLunchMenus();

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <returns>The settings.</returns>
        Settings GetSettings();
    }
}