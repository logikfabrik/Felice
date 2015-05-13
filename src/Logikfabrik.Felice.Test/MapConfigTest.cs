using Logikfabrik.Felice.Helpers;
using Logikfabrik.Felice.Models;
using Logikfabrik.Felice.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logikfabrik.Felice.Test
{
    [TestClass]
    public class MapConfigTest
    {
        private static SettingsHelper GetSettingsHelper()
        {
            var settings = new Settings
            {
                StreetAddress = "Annavägen 3",
                ZipCode = 35246,
                City = "Växjö",
                PhoneNumber = "0470-77 09 99"
            };
            
            var mock = new Moq.Mock<IPageHelper>();

            mock.Setup(m => m.GetSettings()).Returns(settings);

            return new SettingsHelper(mock.Object);
        }

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            MapConfig.RegisterMaps(GetSettingsHelper());
        }

        [TestMethod]
        public void CanMapHomePage()
        {
            var model = new HomePage();
            var viewModel = AutoMapper.Mapper.Map<HomePageViewModel>(model);

            Assert.AreEqual("Annavägen 3", viewModel.StreetAddress);
            Assert.AreEqual(35246, viewModel.ZipCode);
            Assert.AreEqual("Växjö", viewModel.City);
            Assert.AreEqual("0470-77 09 99", viewModel.PhoneNumber);
            Assert.AreEqual("Annavägen 3, 352 46 Växjö", viewModel.Address);
        }
    }
}
