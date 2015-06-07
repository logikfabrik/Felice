//----------------------------------------------------------------------------------
// <copyright file="OpeningHoursPropertyValueConverter.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.DataTypes
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Umbraco.Jet.Web.Data.Converters;
    
    public class OpeningHoursPropertyValueConverter : IPropertyValueConverter
    {
        public bool CanConvertValue(string uiHint, Type from, Type to)
        {
            return uiHint == OpeningHours.Editor || to == typeof(OpeningHours);
        }

        public object Convert(object value, Type to)
        {
            if (value == null)
            {
                return new OpeningHours[] { };
            }

            var json = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(value.ToString());

            var openingHours = new OpeningHours();

            foreach (var item in json)
            {
                var type = item.type.Value as string;
                var name = item.name.Value as string;
                var hoursFrom = GetHours(item.from);
                var hoursTo = GetHours(item.to);

                switch (type)
                {
                    case "date":
                        openingHours.Add(new OpeningHour(name, (DateTime)item.date, hoursFrom, hoursTo));
                        break;

                    case "dayOfWeek":
                        openingHours.Add(new OpeningHour(name, (DayOfWeek)item.dayOfWeek, hoursFrom, hoursTo));
                        break;

                    default:
                        throw new NotSupportedException(string.Format("Type {0} is not supported.", type));
                }
            }

            return openingHours;
        }

        private static TimeSpan? GetHours(dynamic json)
        {
            if (json == null)
            {
                return null;
            }

            var h = int.Parse((string)json.hours.Value);
            var m = int.Parse((string)json.minutes.Value);

            return new TimeSpan(h, m, 0);
        }
    }
}