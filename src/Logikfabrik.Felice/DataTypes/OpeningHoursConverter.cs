using Logikfabrik.Umbraco.Jet.Web.Data.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Logikfabrik.Felice.DataTypes
{
    public class OpeningHoursConverter : IPropertyValueConverter
    {
        public bool CanConvertValue(string uiHint, Type from, Type to)
        {
            return uiHint == OpeningHours.Editor && from == typeof(JArray) && to == typeof(IEnumerable<Models.OpeningHours>);
        }

        private static TimeSpan? GetHours(dynamic json)
        {
            if (json == null)
                return null;

            var h = int.Parse((string)json.hours.Value);
            var m = int.Parse((string)json.minutes.Value);

            return new TimeSpan(h, m, 0);
        }

        public object Convert(object value, Type to)
        {
            if (value == null)
                return new Models.OpeningHours[] { };

            var json = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(value.ToString());

            var openingHours = new List<Models.OpeningHours>();

            foreach (var item in json)
            {
                var type = item.type.Value as string;
                var name = item.name.Value as string;
                var hoursFrom = GetHours(item.from);
                var hoursTo = GetHours(item.to);

                switch (type)
                {
                    case "date":
                        openingHours.Add(new Models.OpeningHours(name, (DateTime)item.date, hoursFrom, hoursTo));
                        break;
                    case "dayOfWeek":
                        openingHours.Add(new Models.OpeningHours(name, (DayOfWeek)item.dayOfWeek, hoursFrom, hoursTo));
                        break;
                    default:
                        throw new NotSupportedException(string.Format("Type {0} is not supported.", type));
                }
            }

            return openingHours;
        }
    }
}