using Logikfabrik.Umbraco.Jet;

namespace Logikfabrik.Felice.DataTypes
{
    [DataType(typeof(Models.OpeningHours), Editor)]
    public class OpeningHours
    {
        public const string Editor = "OpeningHours";
    }
}