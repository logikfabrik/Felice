//----------------------------------------------------------------------------------
// <copyright file="OpeningHours.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.DataTypes
{
    using System.Collections.Generic;
    using Umbraco.Jet;

    [DataType(typeof(OpeningHours), Editor)]
    public class OpeningHours : List<OpeningHour>
    {
        public const string Editor = "OpeningHours";        
    }
}