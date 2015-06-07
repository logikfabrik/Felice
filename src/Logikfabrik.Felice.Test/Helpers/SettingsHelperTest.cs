//----------------------------------------------------------------------------------
// <copyright file="SettingsHelperTest.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Test.Helpers
{
    using System.Linq;
    using DataTypes;
    using Felice.Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    
    /// <summary>
    /// Test class for the SettingsHelper class.
    /// </summary>
    [TestClass]
    public class SettingsHelperTest
    {
        /// <summary>
        /// Test function GetStreetAddress.
        /// </summary>
        [TestMethod]
        public void CanGetStreetAddress()
        {
            var helper = new SettingsHelper(GetPageHelper());

            Assert.AreEqual("Street address", helper.GetStreetAddress());
        }

        /// <summary>
        /// Test function GetZipCode.
        /// </summary>
        [TestMethod]
        public void CanGetZipCode()
        {
            var helper = new SettingsHelper(GetPageHelper());

            Assert.AreEqual(12345, helper.GetZipCode());
        }

        /// <summary>
        /// Test function GetCity.
        /// </summary>
        [TestMethod]
        public void CanGetCity()
        {
            var helper = new SettingsHelper(GetPageHelper());

            Assert.AreEqual("City", helper.GetCity());
        }

        /// <summary>
        /// Test function GetPhoneNumber.
        /// </summary>
        [TestMethod]
        public void CanGetPhoneNumber()
        {
            var helper = new SettingsHelper(GetPageHelper());

            Assert.AreEqual("0123 567 89", helper.GetPhoneNumber());
        }

        /// <summary>
        /// Test function GetOpeningHours.
        /// </summary>
        [TestMethod]
        public void CanGetOpeningHours()
        {
            var helper = new SettingsHelper(GetPageHelper());

            Assert.AreEqual(0, helper.GetOpeningHours().Count());
        }

        /// <summary>
        /// Gets a helper.
        /// </summary>
        /// <returns>A helper.</returns>
        private static IPageHelper GetPageHelper()
        {
            var settings = new Settings
            {
                StreetAddress = "Street address",
                ZipCode = 12345,
                City = "City",
                PhoneNumber = "0123 567 89",
                OpeningHours = new OpeningHours()
            };
            var mock = new Moq.Mock<IPageHelper>();

            mock.Setup(m => m.GetPageOfType<Settings>()).Returns(settings);

            return mock.Object;
        }
    }
}
