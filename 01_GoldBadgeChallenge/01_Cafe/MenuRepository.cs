using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuRepository
    {
        private List<Menu> _menu = new List<Menu>();

        public List<Menu> GetAllMealsFromMenu()
        {
            return _menu;
        }

        public Menu GetMealbyMealNumber(string mealNumber)
        {
            foreach (Menu meal in _menu)
            {
                if (meal.MealNumber == mealNumber)
                {
                    return meal;
                }
            }
            return null;
        }

        public void AddNewMealToMenu(Menu newMeal)
        {
            _menu.Add(newMeal);
        }

        public void RemoveExistingMealFromMenu(Menu existingMeal)
        {
            _menu.Remove(existingMeal);
        }
    }
}
