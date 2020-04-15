using System;
using System.Collections.Generic;
using _01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeTest
{
    [TestClass]
    public class MenuTest
    {
        
        private MenuRepository _menuRepository;
        private Menu _meal;

        [TestInitialize]

        public void Arrange()
        {
            _menuRepository = new MenuRepository();
            _meal = new Menu("1", "Cowboy Burger", "A juicy 1/2 pound burger topped with American Cheese, crispy onion rings, and tangy BBQ sauce layered on buttered Texas Toast.", new List<string> { "beef patty", "cheese", "onion rings", "bbq sauce", "texas toast", "french fries" }, 9.99m);
        }

        [TestMethod]
        public void AddMealToMenuTest()
        {
            _menuRepository.AddNewMealToMenu(_meal);
            int expected = 1;
            int actual = _menuRepository.GetAllMealsFromMenu().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveMealFromMenuTest()
        {
            _menuRepository.RemoveExistingMealFromMenu(_meal);
            int expected = 0;
            int actual = _menuRepository.GetAllMealsFromMenu().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMealByMealNumberTest()
        {
            _menuRepository.AddNewMealToMenu(_meal);
            string mealNumber = "1";
            string expected = "Cowboy Burger";
            Menu actual = _menuRepository.GetMealbyMealNumber(mealNumber);
            Assert.AreEqual(expected, actual.MealName);
        }
    }
}

