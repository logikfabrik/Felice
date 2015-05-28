using Logikfabrik.Felice.Helpers;
using Logikfabrik.Felice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Logikfabrik.Felice.DataTypes;

namespace Logikfabrik.Felice.Test.Helpers
{
    [TestClass]
    public class OpeningHoursHelperTest
    {
        private static IPageHelper GetPageHelper()
        {
            var settings = new Settings
            {
                OpeningHours = new OpeningHours()
                {
                    new OpeningHour("Monday", DayOfWeek.Monday, new TimeSpan(10, 0, 0), new TimeSpan(17, 0, 0)),
                    new OpeningHour("Saturday", DayOfWeek.Saturday, new TimeSpan(0, 0, 0), new TimeSpan(24, 0, 0)),
                    new OpeningHour("Sunday", DayOfWeek.Sunday, new TimeSpan(0, 0, 0), new TimeSpan(24, 0, 0)),
                    new OpeningHour("New Year's Eve", new DateTime(2014, 12, 31), new TimeSpan(0, 0, 0), new TimeSpan(24, 0, 0))
                }
            };
            var mock = new Moq.Mock<IPageHelper>();

            mock.Setup(m => m.GetPageOfType<Settings>()).Returns(settings);

            return mock.Object;
        }

        [TestMethod]
        public void CanGetOpeningHoursOfTheDay()
        {
            var helper = new OpeningHoursHelper(GetPageHelper(), new DateHelper());
            
            var date1 = new DateTime(2015, 2, 15);
            var openingHours1 = helper.GetOpeningHoursOfTheDay(date1);

            Assert.IsNotNull(openingHours1);
            Assert.AreEqual("Sunday", openingHours1.Name);

            var date2 = new DateTime(2015, 2, 16);
            var openingHours2 = helper.GetOpeningHoursOfTheDay(date2);

            Assert.IsNotNull(openingHours2);
            Assert.AreEqual("Monday", openingHours2.Name);
        }

        [TestMethod]
        public void CanGetOpeningHoursOfTheDayWithSpecialOpeningHours()
        {
            var helper = new OpeningHoursHelper(GetPageHelper(), new DateHelper());

            var date = new DateTime(2014, 12, 31);
            var openingHours = helper.GetOpeningHoursOfTheDay(date);

            Assert.IsNotNull(openingHours);
            Assert.AreEqual("New Year's Eve", openingHours.Name);
        }

        [TestMethod]
        public void CanGetOpeningHoursOfTheWeek()
        {
            var helper = new OpeningHoursHelper(GetPageHelper(), new DateHelper());

            var date = new DateTime(2014, 10, 26);
            var openingHours = helper.GetOpeningHoursOfTheWeek(date);

            Assert.AreEqual(3, openingHours.Count());
        }

        [TestMethod]
        public void CanGetOpeningHoursOfTheWeekWithSpecialOpeningHours()
        {
            var helper = new OpeningHoursHelper(GetPageHelper(), new DateHelper());

            var date = new DateTime(2014, 12, 31);
            var openingHours = helper.GetOpeningHoursOfTheWeek(date);

            Assert.AreEqual(3, openingHours.Count());
        }
    }
}
