using Logikfabrik.Felice.Controllers;
using Logikfabrik.Felice.Helpers;
using Logikfabrik.Felice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Logikfabrik.Felice.Test.Controllers
{
    [TestClass]
    public class EatWithUsPageControllerTest
    {
        private static IPageHelper GetPageHelper()
        {
            var mock = new Moq.Mock<IPageHelper>();

            mock.Setup(m => m.GetSettings()).Returns(new Settings());
            mock.Setup(m => m.GetLunchMenus()).Returns(new[]
            {
                new LunchMenu
                {
                    Preamble1 = "First preamble",
                    Preamble2 = "Second preamble",
                    Year = DateTime.Now.Year,
                    Week = new DateHelper().GetWeekOfYearISO8601(DateTime.Now),
                    Monday = "Dish for Monday",
                    Tuesday =  "Dish for Tuesday",
                    Wednesday = "Dish for Wednesday",
                    Thursday = "Dish for Thursday",
                    Friday = "Dish for Friday",
                    Saturday = "Dish for Saturday",
                    Sunday = "Dish for Sunday"
                }
            });

            return mock.Object;
        }

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            MapConfig.RegisterMaps(new SettingsHelper(GetPageHelper()));
        }

        [TestMethod]
        public void CanGetIndex()
        {
            var controller = new EatWithUsPageController(new LunchMenuHelper(GetPageHelper(), new DateHelper()));
            var view = controller.Index(new EatWithUsPage());

            Assert.IsNotNull(view);
        }
    }
}
