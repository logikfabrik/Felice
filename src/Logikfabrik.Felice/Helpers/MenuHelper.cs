using System;
using System.Collections.Generic;
using Logikfabrik.Felice.Models;

namespace Logikfabrik.Felice.Helpers
{
    /// <summary>
    /// Helper class for restaurant menu.
    /// </summary>
    public class MenuHelper
    {
        private readonly IPageHelper pageHelper;

        public MenuHelper(IPageHelper pageHelper)
        {
            if (pageHelper == null)
                throw new ArgumentNullException("pageHelper");

            this.pageHelper = pageHelper;
        }

        public IEnumerable<MenuDish> GetDishes()
        {
            return this.pageHelper.GetChildPagesOfType<Menu, MenuDish>();
        }
    }
}