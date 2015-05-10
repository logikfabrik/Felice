using System;
using System.Linq;
using Logikfabrik.Umbraco.Jet.Mappings;
using Umbraco.Core;
using Umbraco.Core.Models;

namespace Logikfabrik.Felice.DataTypes
{
    public class OpeningHoursDataTypeDefinitionMapping : DataTypeDefinitionMapping
    {
        private static IDataTypeDefinition GetDefinition(string editor)
        {
            if (string.IsNullOrWhiteSpace(editor))
                throw new ArgumentException("Editor cannot be null or white space.", "editor");

            return ApplicationContext.Current.Services.DataTypeService.GetDataTypeDefinitionByPropertyEditorAlias(editor).Single();
        }

        public override IDataTypeDefinition GetMappedDefinition(Type fromType)
        {
            return !CanMapToDefinition(fromType)
                ? null
                : GetDefinition(OpeningHours.Editor);
        }

        protected override Type[] SupportedTypes
        {
            get { return new[] { typeof(OpeningHours) }; }
        }
    }
}