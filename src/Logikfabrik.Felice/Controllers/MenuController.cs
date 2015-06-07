//----------------------------------------------------------------------------------
// <copyright file="MenuController.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Extensions;
    using Models;
    using umbraco;
    using umbraco.interfaces;
    using umbraco.NodeFactory;
    using global::Umbraco.Web.Mvc;
    using ViewModels;

    public class MenuController : SurfaceController
    {
        private static readonly Type[] Types = { typeof(EatWithUsPage), typeof(FindUsPage), typeof(StandardPage) };

        [ChildActionOnly]
        public PartialViewResult MainMenu()
        {
            var root = new Node(-1);
            var home = root.GetChildNodes().FirstOrDefault();

            return
                this.PartialView(home == null
                    ? new MenuItemViewModel[] { }
                    : Mapper.Map<IEnumerable<MenuItemViewModel>>(
                        home.GetChildNodes().Where(ShowInMenu)));
        }

        private static bool ShowInMenu(INode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            if (!Types.Any(node.IsOfType))
            {
                return false;
            }

            var naviHide = node.GetProperty("umbracoNaviHide");

            return naviHide == null || naviHide.Value != "1";
        }
    }
}