﻿//----------------------------------------------------------------------------------
// <copyright file="NodeExtensions.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using umbraco;
    using umbraco.interfaces;
    using global::Umbraco.Core.Models;
    using Umbraco.Jet.Extensions;
    using global::Umbraco.Web;

    public static class NodeExtensions
    {
        public static IPublishedContent GetContent(this INode node)
        {
            return new UmbracoHelper(UmbracoContext.Current).TypedContent(node.Id);
        }

        public static IEnumerable<INode> GetDescendants(this INode node)
        {
            foreach (var child in node.GetChildNodes())
            {
                yield return child;

                foreach (var grandChild in child.GetDescendants())
                {
                    yield return grandChild;
                }
            }
        }

        public static IEnumerable<INode> GetDescendants<T>(this INode node)
        {
            return GetDescendants(node).Where(n => n.IsOfType(typeof(T)));
        }

        public static IEnumerable<INode> GetChildren<T>(this INode node)
        {
            return node.GetChildNodesByType(typeof(T).Name.Alias());
        }

        public static bool IsOfType(this INode node, Type type)
        {
            return node.NodeTypeAlias == type.Name.Alias();
        }
    }
}