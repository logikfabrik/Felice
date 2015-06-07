//----------------------------------------------------------------------------------
// <copyright file="OpeningHoursDataTypeDefinitionMapping.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.DataTypes
{
    using System;
    using System.Linq;
    using global::Umbraco.Core;
    using global::Umbraco.Core.Models;
    using Umbraco.Jet.Mappings;

    public class OpeningHoursDataTypeDefinitionMapping : DataTypeDefinitionMapping
    {
        protected override Type[] SupportedTypes
        {
            get
            {
                return new[] { typeof(OpeningHours) };
            }
        }

        public override IDataTypeDefinition GetMappedDefinition(Type fromType)
        {
            return !this.CanMapToDefinition(fromType)
                ? null
                : GetDefinition(OpeningHours.Editor);
        }

        private static IDataTypeDefinition GetDefinition(string editor)
        {
            if (string.IsNullOrWhiteSpace(editor))
            {
                throw new ArgumentException("Editor cannot be null or white space.", "editor");
            }

            return ApplicationContext.Current.Services.DataTypeService.GetDataTypeDefinitionByPropertyEditorAlias(editor).Single();
        }
    }
}