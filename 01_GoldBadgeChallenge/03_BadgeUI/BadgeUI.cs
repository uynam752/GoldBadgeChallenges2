using _03_Badge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeUI
{
    public class BadgeUI
    {
        private BadgeRepository _badgeRepository = new BadgeRepository();
        public void Run()
        {
            SeedBadgeRepository();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("------------------------");
                Console.WriteLine("Komodo Insurance Badge System (v1.0)\n" +
                "-- Sacco Systems Inc. --\n\n" +
                "Please make a selction from the menu:\n" +
                "1 - Add a Badge \n" +
                "2 - Edit a Badge\n" +
                "3 - List all Badges\n" +
                "4 - Exit");
                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        AddNewBadge();
                        break;

                    case "2":
                        EditExistingBadge();
                        break;

                    case "3":
                        ShowAllBadges();
                        break;

                    case "4":
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AddNewBadge()
        {
            Badge newBadge = new Badge();
            Console.Write("What is the new badge's numeric ID ? (ex: 0000): ");
            newBadge.BadgeID = int.Parse(Console.ReadLine());
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Write("Please enter a Door ID for which this badge should have access: ");
                newBadge.DoorNames = new List<string>();
                string userInput = Console.ReadLine().ToUpper();
                newBadge.DoorNames.Add(userInput);
                Console.Write("Any other doors to add ? (y/n)");
                string userResponse = Console.ReadLine();
                if (userResponse == "n")
                {
                    continueRunning = false;
                    _badgeRepository.AddNewBadgeToList(newBadge);
                    Console.WriteLine($"\nYour new badge, Badge ID: {newBadge.BadgeID}, has been added.\n\n" +
                        $"Press any key to return to the main menu.");
                    Console.ReadKey();
                }
                else
                {
                    continueRunning = true;
                }
            }
        }

        private void ShowAllBadges()
        {
            Dictionary<int, List<string>> badgeDictionary = _badgeRepository.GetListOfBadges();

            Console.WriteLine("{0, -10}", "BadgeID:");
            foreach (KeyValuePair<int, List<string>> badge in badgeDictionary)
            {
                Console.WriteLine(badge.Key);
                foreach (string door in badge.Value)
                {
                    Console.Write("{0} {1, -5}", "", door);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        private void EditExistingBadge()
        {
            Console.Write("What is the badge number you would like to update ?: ");
            int userBadgeInput = int.Parse(Console.ReadLine());
            Badge badge = _badgeRepository.GetBadgeByBadgeID(userBadgeInput);
            foreach (string door in badge.DoorNames)
            {
                Console.WriteLine("{0, -10} {1, -10}", badge.BadgeID, door);
            }
            Console.WriteLine("What would you like to do ?\n\n" +
                "1 - Remove a door\n" +
                "2 - Add a door\n" +
                "3 - Cancel\n");
            string userResponse = Console.ReadLine();
            switch (userResponse)
            {
                case "1":
                    Console.WriteLine($"Which door would you like to remove?");
                    string removeDoor = Console.ReadLine().ToUpper();
                    badge.DoorNames.Remove(removeDoor);
                    Console.WriteLine($"Door {removeDoor} was removed from Badge {badge.BadgeID}");
                    break;

                case "2":
                    Console.WriteLine($"Which door would you like to add?");
                    string addDoor = Console.ReadLine().ToUpper();
                    badge.DoorNames.Add(addDoor);
                    Console.WriteLine($"Door {addDoor} was added to Badge {badge.BadgeID}");
                    break;

                case "3":
                    break;

                default:
                    Console.WriteLine("Invalid selection. Please try again...");
                    break;
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        private void SeedBadgeRepository()
        {
            Badge badgeOne = new Badge(1000, new List<string> { "A1", "B1", "C1", "B2", "B3", "C2", "C3" });
            Badge badgeTwo = new Badge(1001, new List<string> { "B1", "B2", "B3" });
            Badge badgeThree = new Badge(1002, new List<string> { "C1", "C2", "C3" });

            _badgeRepository.AddNewBadgeToList(badgeOne);
            _badgeRepository.AddNewBadgeToList(badgeTwo);
            _badgeRepository.AddNewBadgeToList(badgeThree);
        }
    }
}
