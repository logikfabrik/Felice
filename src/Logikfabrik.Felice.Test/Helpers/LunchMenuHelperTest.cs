//----------------------------------------------------------------------------------
// <copyright file="LunchMenuHelperTest.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Test.Helpers
{
    using System;
    using Felice.Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    
    /// <summary>
    /// Test class for the LunchMenuHelper class.
    /// </summary>
    [TestClass]
    public class LunchMenuHelperTest
    {
        /// <summary>
        /// Test function GetLunchMenuOfTheWeek.
        /// </summary>
        [TestMethod]
        public void CanGetMenuOfTheWeek()
        {
            var helper = new LunchMenuHelper(GetPageHelper(), new DateHelper());

            var date1 = new DateTime(2013, 3, 4);
            var menu1 = helper.GetLunchMenuOfTheWeek(date1);

            Assert.IsNotNull(menu1);
            Assert.AreEqual(10, menu1.Week);
            Assert.AreEqual(2013, menu1.Year);
            Assert.AreEqual("Dish 1", menu1.Monday);

            var date2 = new DateTime(2014, 10, 26);
            var menu2 = helper.GetLunchMenuOfTheWeek(date2);

            Assert.IsNotNull(menu2);
            Assert.AreEqual(43, menu2.Week);
            Assert.AreEqual(2014, menu2.Year);
            Assert.AreEqual("Dish 2", menu2.Sunday);
        }

        /// <summary>
        /// Test function GetDishOfTheDay.
        /// </summary>
        [TestMethod]
        public void CanGetDishOfTheDay()
        {
            var helper = new LunchMenuHelper(GetPageHelper(), new DateHelper());

            var date1 = new DateTime(2013, 3, 4);
            var dish1 = helper.GetDishOfTheDay(date1);

            Assert.IsNotNull(dish1);
            Assert.AreEqual("Dish 1", dish1);

            var date2 = new DateTime(2014, 10, 26);
            var dish2 = helper.GetDishOfTheDay(date2);

            Assert.IsNotNull(dish2);
            Assert.AreEqual("Dish 2", dish2);
        }

        /// <summary>
        /// Gets a helper.
        /// </summary>
        /// <returns>A helper.</returns>
        private static IPageHelper GetPageHelper()
        {
            var menu = new LunchMenus();
            var menus = new[]
            {
                new LunchMenu
                {
                    Year = 2013,
                    Week = 10,
                    Monday = "Dish 1"
                },
                new LunchMenu
                {
                    Year = 2014,
                    Week = 43,
                    Sunday = "Dish 2"
                }
            };

            var mock = new Moq.Mock<IPageHelper>();

            mock.Setup(m => m.GetPageOfType<LunchMenus>()).Returns(menu);
            mock.Setup(m => m.GetChildPagesOfType<LunchMenus, LunchMenu>()).Returns(menus);

            return mock.Object;
        }
    }
}
