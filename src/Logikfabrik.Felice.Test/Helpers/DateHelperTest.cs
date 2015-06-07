//----------------------------------------------------------------------------------
// <copyright file="DateHelperTest.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Test.Helpers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Felice.Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test class for the DateHelper class.
    /// </summary>
    [TestClass]
    public class DateHelperTest
    {
        /// <summary>
        /// Culture en-US.
        /// </summary>
        private const string EnUs = "en-US";

        /// <summary>
        /// Culture sv-SE.
        /// </summary>
        private const string SvSe = "sv-SE";

        /// <summary>
        /// The culture info used by the test class.
        /// </summary>
        private static CultureInfo cultureInfo;
        
        /// <summary>
        /// Test initialization.
        /// </summary>
        /// <param name="context">A test context.</param>
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            cultureInfo = Thread.CurrentThread.CurrentCulture;
        }

        /// <summary>
        /// Test clean up.
        /// </summary>
        [ClassCleanup]
        public static void Cleanup()
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
        }
        
        /// <summary>
        /// Test function GetWeekOfYearISO8601 for culture en-US.
        /// </summary>
        [TestMethod]
        public void CanGetWeekOfYearIso8601EnUs()
        {
            SetCulture(EnUs);

            var helper = new DateHelper();

            Assert.AreEqual(52, helper.GetWeekOfYearISO8601(new DateTime(2015, 12, 27)));
            Assert.AreEqual(53, helper.GetWeekOfYearISO8601(new DateTime(2015, 12, 28)));
            Assert.AreEqual(1, helper.GetWeekOfYearISO8601(new DateTime(2014, 12, 29)));
        }

        /// <summary>
        /// Test function GetWeekOfYearISO8601 for culture sv-SE.
        /// </summary>
        [TestMethod]
        public void CanGetWeekOfYearIso8601SvSe()
        {
            SetCulture(SvSe);

            var helper = new DateHelper();

            Assert.AreEqual(52, helper.GetWeekOfYearISO8601(new DateTime(2015, 12, 27)));
            Assert.AreEqual(53, helper.GetWeekOfYearISO8601(new DateTime(2015, 12, 28)));
            Assert.AreEqual(1, helper.GetWeekOfYearISO8601(new DateTime(2014, 12, 29)));
        }

        /// <summary>
        /// Test function GetWeeksOfYearISO8601 for culture en-US.
        /// </summary>
        [TestMethod]
        public void GetWeeksOfYearIso8601EnUs()
        {
            SetCulture(EnUs);

            var helper = new DateHelper();

            Assert.AreEqual(53, helper.GetWeeksOfYearISO8601(2015));
            Assert.AreEqual(52, helper.GetWeeksOfYearISO8601(2014));
        }

        /// <summary>
        /// Test function GetWeeksOfYearISO8601 for culture sv-SE.
        /// </summary>
        [TestMethod]
        public void GetWeeksOfYearIso8601SvSe()
        {
            SetCulture(SvSe);

            var helper = new DateHelper();

            Assert.AreEqual(53, helper.GetWeeksOfYearISO8601(2015));
            Assert.AreEqual(52, helper.GetWeeksOfYearISO8601(2014));
        }

        /// <summary>
        /// Test function GetDaysInWeek for culture en-US.
        /// </summary>
        [TestMethod]
        public void GetDaysInWeekenUs()
        {
            SetCulture(EnUs);

            var helper = new DateHelper();
            var days = helper.GetDaysInWeek(2015, 23).ToArray();

            Assert.AreEqual(new DateTime(2015, 5, 31).Date, days.First().Date);
            Assert.AreEqual(new DateTime(2015, 6, 6).Date, days.Last().Date);
        }

        /// <summary>
        /// Test function GetDaysInWeek for culture sv-SE.
        /// </summary>
        [TestMethod]
        public void GetDaysInWeeksvSe()
        {
            SetCulture(SvSe);

            var helper = new DateHelper();
            var days = helper.GetDaysInWeek(2015, 23).ToArray();

            Assert.AreEqual(new DateTime(2015, 6, 1).Date, days.First().Date);
            Assert.AreEqual(new DateTime(2015, 6, 7).Date, days.Last().Date);
        }

        /// <summary>
        /// Sets the current culture.
        /// </summary>
        /// <param name="name">A culture name.</param>
        private static void SetCulture(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or white space.", "name");
            }
                
            Thread.CurrentThread.CurrentCulture = new CultureInfo(name);
        }
    }
}
