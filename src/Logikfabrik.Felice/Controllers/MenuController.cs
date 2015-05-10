using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Logikfabrik.Felice.Extensions;
using Logikfabrik.Felice.Models;
using Logikfabrik.Felice.ViewModels;
using umbraco;
using umbraco.interfaces;
using umbraco.NodeFactory;
using Umbraco.Web.Mvc;

namespace Logikfabrik.Felice.Controllers
{
    public class MenuController : SurfaceController
    {
        private static readonly Type[] Types = { typeof(EatWithUsPage), typeof(FindUsPage), typeof(StandardPage) };

        private static bool ShowInMenu(INode node)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            if (!Types.Any(node.IsOfType))
                return false;

            var naviHide = node.GetProperty("umbracoNaviHide");

            return naviHide == null || naviHide.Value != "1";
        }

        [ChildActionOnly]
        public PartialViewResult MainMenu()
        {
            var root = new Node(-1);
            var home = root.GetChildNodes().FirstOrDefault();

            return
                PartialView(home == null
                    ? new MenuItemViewModel[] {}
                    : Mapper.Map<IEnumerable<MenuItemViewModel>>(
                        home.GetChildNodes().Where(ShowInMenu)));
        }
    }
}