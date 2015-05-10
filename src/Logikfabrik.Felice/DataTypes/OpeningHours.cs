using System.Collections.Generic;
using Logikfabrik.Umbraco.Jet;

namespace Logikfabrik.Felice.DataTypes
{
    [DataType(typeof(OpeningHours), Editor)]
    public class OpeningHours : List<OpeningHour>
    {
        public const string Editor = "OpeningHours";        
    }
}