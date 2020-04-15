using _01_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeConsole
{
    class ProgramUI
    {
        private MenuRepository _menuRepository = new MenuRepository();
        public void Run()
        {
            SeedMeals();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("Komodo Restaurant Menu Builder v1.0\n" +
                    "Sacco Systems Inc.\n");
                Console.WriteLine("Please make a selection from the following options:\n" +
                    "1 - Get list of all Meals\n" +
                    "2 - Add a new Meal to the Menu\n" +
                    "3 - Remove an existing Meal from the Menu\n" +
                    "4 - Exit Program");
                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        ShowAllMeals();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "2":
                        AddNewMeal();
                        break;

                    case "3":
                        RemoveMealFromMenu();
                        break;

                    case "4":
                        continueRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Please try again...");
                        break;
                }
            }
        }

        private void AddNewMeal()
        {
            Menu newMeal = new Menu();

            Console.WriteLine("What is the Meal Number ?");
            string mealNumber = Console.ReadLine();

            Console.WriteLine("What is the Meal Name ?");
            string mealName = Console.ReadLine();

            Console.WriteLine("What is the Meal Description ?");
            string mealDescription = Console.ReadLine();

            Console.WriteLine("What ingredients are included in this meal ?\n" +
                "Please enter your first ingredient:");
            bool continueAdding = true;
            List<string> listOfIngredients = new List<string>();
            while (continueAdding)
            {
                listOfIngredients.Add(Console.ReadLine());
                int numberOfIngredients = listOfIngredients.Count;
                Console.WriteLine("Add another ingredient ?\n" +
                    "1 = yes, 2 = no");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                    case "yes":
                        Console.WriteLine($"Ingredient {numberOfIngredients + 1}:");
                        break;

                    case "2":
                    case "no":
                        continueAdding = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again...");
                        break;
                }
            }
            Console.WriteLine("What is the Price of this meal ? Enter a decimal amount (ex: 10.50):");
            decimal mealPrice = decimal.Parse(Console.ReadLine());

            newMeal.MealNumber = mealNumber;
            newMeal.MealName = mealName;
            newMeal.Description = mealDescription;
            newMeal.Ingredients = listOfIngredients;
            newMeal.Price = mealPrice;
            _menuRepository.AddNewMealToMenu(newMeal);
            Console.WriteLine($"{newMeal.MealName} has been added to the Menu.\n" +
                $"Press any key to continue.");
            Console.ReadKey();
        }

        private void ShowAllMeals()
        {
            List<Menu> listOfMeals = _menuRepository.GetAllMealsFromMenu();
            foreach (Menu meal in listOfMeals)
            {
                Console.WriteLine($"Meal Number: {meal.MealNumber} | Meal Name: {meal.MealName} | Meal Price: ${meal.Price}\n");
            }
        }

        private void RemoveMealFromMenu()
        {
            Console.WriteLine("What Meal would you like to remove?\n" +
                "Please enter a Meal Number:");
            string userInput = Console.ReadLine();
            Menu existingMeal = _menuRepository.GetMealbyMealNumber(userInput);
            Console.WriteLine($"{existingMeal.MealName} will be removed from the Menu. Press any key to continue...");
            _menuRepository.RemoveExistingMealFromMenu(existingMeal);
            Console.ReadKey();
        }

        private void SeedMeals()
        {
            Menu mealOne = new Menu("1", "Cowboy Burger and French Fries", "A juicy 1/2 pound burger topped with American Cheese, crispy onion rings, and tangy BBQ sauce layered on buttered Texas Toast.", new List<string> { "beef patty", "cheese", "onion rings", "bbq sauce", "texas toast", "french fries" }, 11.99m);
            Menu mealTwo = new Menu("2", "Chicken Fajita Nachos", "Nachos piled high and smothered in queso, chicken and fire-grilled fajita veggies.", new List<string> { "nachos", "chicken", "queso", "onions", "peppers", "tomatoes" }, 9.99m);
            Menu mealThree = new Menu("3", "Chicken Tenders and French Fries", "Five strips of juicy, golden-brown, breast-meat tenders served with fries and sauce for dipping.", new List<string> { "chicken tenders", "french fries", "dipping sauce" }, 10.99m);

            _menuRepository.AddNewMealToMenu(mealOne);
            _menuRepository.AddNewMealToMenu(mealTwo);
            _menuRepository.AddNewMealToMenu(mealThree);
        }
    }
}
