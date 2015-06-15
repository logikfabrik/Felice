//----------------------------------------------------------------------------------
// <copyright file="MenuHelper.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Helpers
{
    using System;
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Helper class for restaurant menu.
    /// </summary>
    public class MenuHelper
    {
        private readonly IPageHelper pageHelper;

        public MenuHelper(IPageHelper pageHelper)
        {
            if (pageHelper == null)
            {
                throw new ArgumentNullException("pageHelper");
            }

            this.pageHelper = pageHelper;
        }

        public IEnumerable<MenuDish> GetDishes()
        {
            return this.pageHelper.GetChildPagesOfType<Menu, MenuDish>();
        }
    }
}