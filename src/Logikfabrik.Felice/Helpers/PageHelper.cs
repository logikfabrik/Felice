//----------------------------------------------------------------------------------
// <copyright file="PageHelper.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using umbraco;
    using umbraco.NodeFactory;
    using Umbraco.Jet.Web.Data;

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
            {
                throw new ArgumentNullException("documentService");
            }

            this.documentService = documentService;
        }

        public T GetPageOfType<T>() where T : class, new()
        {
            var rootNode = GetRootNode();

            var pageNode = rootNode == null
                ? null
                : rootNode.GetDescendants<T>().SingleOrDefault();

            return pageNode == null ? null : this.documentService.GetDocument<T>(pageNode.GetContent());
        }

        public IEnumerable<T2> GetChildPagesOfType<T1, T2>()
            where T1 : class, new()
            where T2 : class, new()
        {
            var rootNode = GetRootNode();

            var parentPageNodes = rootNode == null
                ? null
                : rootNode.GetDescendants<T1>().SingleOrDefault();

            if (parentPageNodes == null)
            {
                return new T2[] { };
            }

            var pageNodes =
                parentPageNodes.GetChildren<T2>()
                    .Select(menu => this.documentService.GetDocument<T2>(menu.GetContent()))
                    .ToArray();

            return pageNodes;
        }

        private static Node GetRootNode()
        {
            var root = new Node(-1);

            return root.GetChildNodes().FirstOrDefault();
        }
    }
}