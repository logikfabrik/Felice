using Logikfabrik.Felice.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Logikfabrik.Felice.Test.Helpers
{
    [TestClass]
    public class DateHelperTest
    {
        private static CultureInfo cultureInfo;
        
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            cultureInfo = Thread.CurrentThread.CurrentCulture;
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
        }

        // ReSharper disable once InconsistentNaming
        private const string enUS = "en-US";
        // ReSharper disable once InconsistentNaming
        private const string svSE = "sv-SE";

        private static void SetCulture(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or white space.", "name");

            Thread.CurrentThread.CurrentCulture = new CultureInfo(name);
        }

        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void CanGetWeekOfYearIso8601enUS()
        {
            SetCulture(enUS);

            var helper = new DateHelper();

            Assert.AreEqual(52, helper.GetWeekOfYearISO8601(new DateTime(2015, 12, 27)));
            Assert.AreEqual(53, helper.GetWeekOfYearISO8601(new DateTime(2015, 12, 28)));
            Assert.AreEqual(1, helper.GetWeekOfYearISO8601(new DateTime(2014, 12, 29)));
        }

        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void CanGetWeekOfYearIso8601svSE()
        {
            SetCulture(svSE);

            var helper = new DateHelper();

            Assert.AreEqual(52, helper.GetWeekOfYearISO8601(new DateTime(2015, 12, 27)));
            Assert.AreEqual(53, helper.GetWeekOfYearISO8601(new DateTime(2015, 12, 28)));
            Assert.AreEqual(1, helper.GetWeekOfYearISO8601(new DateTime(2014, 12, 29)));
        }

        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void GetWeeksOfYearIso8601enUS()
        {
            SetCulture(enUS);

            var helper = new DateHelper();

            Assert.AreEqual(53, helper.GetWeeksOfYearISO8601(2015));
            Assert.AreEqual(52, helper.GetWeeksOfYearISO8601(2014));
        }

        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void GetWeeksOfYearIso8601svSE()
        {
            SetCulture(svSE);

            var helper = new DateHelper();

            Assert.AreEqual(53, helper.GetWeeksOfYearISO8601(2015));
            Assert.AreEqual(52, helper.GetWeeksOfYearISO8601(2014));
        }

        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void GetDaysInWeekenUS()
        {
            SetCulture(enUS);

            var helper = new DateHelper();
            var days = helper.GetDaysInWeek(2015, 23).ToArray();

            Assert.AreEqual(new DateTime(2015, 5, 31).Date, days.First().Date);
            Assert.AreEqual(new DateTime(2015, 6, 6).Date, days.Last().Date);
        }

        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void GetDaysInWeeksvSE()
        {
            SetCulture(svSE);

            var helper = new DateHelper();
            var days = helper.GetDaysInWeek(2015, 23).ToArray();

            Assert.AreEqual(new DateTime(2015, 6, 1).Date, days.First().Date);
            Assert.AreEqual(new DateTime(2015, 6, 7).Date, days.Last().Date);
        }
    }
}
