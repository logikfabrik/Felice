using System;
using System.Collections.Generic;
using System.Linq;
using Logikfabrik.Felice.Extensions;
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

        private static Node GetRootNode()
        {
            var root = new Node(-1);

            return root.GetChildNodes().FirstOrDefault();
        }
        
        public T GetPageOfType<T>() where T : class, new()
        {
            var rootNode = GetRootNode();

            var pageNode = rootNode == null
                ? null
                : rootNode.GetDescendants<T>().SingleOrDefault();

            return pageNode == null ? null : documentService.GetDocument<T>(pageNode.GetContent());
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
                return new T2[] { };

            var pageNodes =
                parentPageNodes.GetChildren<T2>()
                    .Select(menu => documentService.GetDocument<T2>(menu.GetContent()))
                    .ToArray();

            return pageNodes;
        }
    }
}