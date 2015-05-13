using Logikfabrik.Felice.Helpers;
using Logikfabrik.Felice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Logikfabrik.Felice.DataTypes;

namespace Logikfabrik.Felice.Test.Helpers
{
    [TestClass]
    public class SettingsHelperTest
    {
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

            mock.Setup(m => m.GetSettings()).Returns(settings);

            return mock.Object;
        }

        [TestMethod]
        public void CanGetStreetAddress()
        {
            var helper = new SettingsHelper(GetPageHelper());

            Assert.AreEqual("Street address", helper.GetStreetAddress());
        }

        [TestMethod]
        public void CanGetZipCode()
        {
            var helper = new SettingsHelper(GetPageHelper());

            Assert.AreEqual(12345, helper.GetZipCode());
        }

        [TestMethod]
        public void CanGetCity()
        {
            var helper = new SettingsHelper(GetPageHelper());

            Assert.AreEqual("City", helper.GetCity());
        }

        [TestMethod]
        public void CanGetPhoneNumber()
        {
            var helper = new SettingsHelper(GetPageHelper());

            Assert.AreEqual("0123 567 89", helper.GetPhoneNumber());
        }

        [TestMethod]
        public void CanGetOpeningHours()
        {
            var helper = new SettingsHelper(GetPageHelper());

            Assert.AreEqual(0, helper.GetOpeningHours().Count());
        }
    }
}
