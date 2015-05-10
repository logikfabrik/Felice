using System;
using System.Collections.Generic;
using System.Linq;
using Logikfabrik.Felice.Extensions;
using Logikfabrik.Felice.Models;
using Logikfabrik.Umbraco.Jet.Web.Data;
using umbraco;
using umbraco.NodeFactory;

namespace Logikfabrik.Felice.Helpers
{
    public class PageHelper : IPageHelper
    {
        private readonly DocumentService documentService;

        public PageHelper()
            : this(new DocumentService())
        {
        }

        public PageHelper(DocumentService documentService)
        {
            if (documentService == null)
                throw new ArgumentNullException("documentService");

            this.documentService = documentService;
        }

        private static Node GetHomePage()
        {
            var root = new Node(-1);

            return root.GetChildNodes().FirstOrDefault();
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <returns>The settings.</returns>
        public Settings GetSettings()
        {
            var homePage = GetHomePage();

            var settings = homePage == null
                ? null
                : homePage.GetDescendants<Settings>().SingleOrDefault();

            return settings == null ? null : documentService.GetDocument<Settings>(settings.GetContent());
        }

        /// <summary>
        /// Gets the lunch menus.
        /// </summary>
        /// <returns>The lunch menus.</returns>
        public IEnumerable<LunchMenu> GetLunchMenus()
        {
            var homePage = GetHomePage();

            var lunchMenus = homePage == null
                ? null
                : homePage.GetDescendants<LunchMenus>().SingleOrDefault();

            if (lunchMenus == null)
                return new LunchMenu[] { };

            var menus =
                lunchMenus.GetChildren<LunchMenu>()
                    .Select(menu => documentService.GetDocument<LunchMenu>(menu.GetContent()))
                    .ToArray();

            var lunchMenusPage = documentService.GetDocument<LunchMenus>(lunchMenus.GetContent());

            foreach (var menu in menus)
            {
                menu.Preamble1 = lunchMenusPage.Preamble1;
                menu.Preamble2 = lunchMenusPage.Preamble2;
            }

            return menus;
        }
    }
}