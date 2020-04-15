using _02_Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsUI
{
    public class ClaimUI
    {
        ClaimRepository _claims = new ClaimRepository();
        PromptUser _prompt = new PromptUser();
        public void Run()
        {
            SeedClaims();
            WelcomeUser();
            DisplayMenu();
        }
        private void WelcomeUser()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Welcome to Komodo Claims Tool");
            Console.WriteLine(" Press enter to display menu ");
            Console.WriteLine("*****************************");
            Console.ReadLine();
        }
        private void DisplayMenu()
        {
            bool isUserUsingApp = true;
            while (isUserUsingApp)
            {
                Console.Clear();
                Console.WriteLine("*****************************");
                Console.WriteLine("          Main Menu          ");
                Console.WriteLine("*****************************\n");

                Console.WriteLine("1) See All Claims\n" +
                    "2) Next Claim\n" +
                    "3) Enter A New Claim\n" +
                    "4) Exit Program");

                ConsoleKeyInfo userInput = Console.ReadKey();

                switch (userInput.Key)
                {
                    case ConsoleKey.D1:
                        DisplayAllClaims();
                        break;
                    case ConsoleKey.NumPad1:
                        DisplayAllClaims();
                        break;
                    case ConsoleKey.D2:
                        ViewNextClaim();
                        break;
                    case ConsoleKey.NumPad2:
                        ViewNextClaim();
                        break;
                    case ConsoleKey.D3:
                        AddAClaim();
                        break;
                    case ConsoleKey.NumPad3:
                        AddAClaim();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        isUserUsingApp = false;
                        break;
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        isUserUsingApp = false;
                        break;
                    default:
                        continue;
                }
            }
        }
        private void DisplayAllClaims()
        {
            if (_claims.IsQueueEmpty)
            {
                Console.Clear();
                Console.WriteLine("There are no claims to view at this time...\n" +
                    "Press enter to return to the main menu...");
                Console.ReadLine();
            }
            else
            {

                Console.Clear();
                List<Claim> claims = new List<Claim>();
                claims = _claims.GetAllClaims();

                foreach (Claim claim in claims)
                {
                    Console.WriteLine($"{claim.ID} {claim.TypeOfClaim,-19} {claim.Description,-19} {claim.Amount,-19} {claim.DateOfIncident.ToString("dd/MM/yyyy"),-19} {claim.DateOfClaim.ToString("dd/MM/yyyy"),-19} {claim.IsValid,-19}\n");
                }
                Console.ReadLine();
            }
        }
        private void AddAClaim()
        {
            Claim claim = new Claim();

            claim.TypeOfClaim = _prompt.PromptUserForTypeOfClaim();
            claim.Description = _prompt.PromptUserForDescription();
            claim.Amount = _prompt.PromptUserForAmount();
            claim.DateOfIncident = _prompt.PromptUserForDateOfIncident();
            claim.DateOfClaim = _prompt.PromptUserForDateOfClaim();
            if (claim.IsValid)
            {
                Console.WriteLine("The claim is valid. Adding to cue...\n" +
                    "Press enter to return to menu.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("The claim is not valid.\n" +
                    "Press Enter to Continue.");
            }

            _claims.AddClaimToQueue(claim);
        }
        private void SeedClaims()
        {
            Claim claim1 = new Claim("123456", ClaimType.Car, "Wreck", 1000m, new DateTime(2020, 1, 1), new DateTime(2020, 1, 7));
            _claims.AddClaimToQueue(claim1);

            Claim claim2 = new Claim("123457", ClaimType.Theft, "Stolen stuff", 2000m, new DateTime(2020, 1, 1), new DateTime(2020, 1, 4));
            _claims.AddClaimToQueue(claim2);

            Claim claim3 = new Claim("123458", ClaimType.Home, "Flooded basement", 5000m, new DateTime(2020, 1, 1), new DateTime(2020, 1, 15));
            _claims.AddClaimToQueue(claim3);

            Claim claim4 = new Claim("123459", ClaimType.Car, "Bad wreck", 6000m, new DateTime(2020, 1, 1), new DateTime(2020, 1, 2));
            _claims.AddClaimToQueue(claim4);
        }
        private void ViewNextClaim()
        {
            Claim nextClaim = _claims.GetNextClaim();
            Console.Clear();

            if (_claims.IsQueueEmpty)
            {
                Console.WriteLine("There are no claims to view at this time...\n" +
                    "Press enter to return to the main menu...");
                Console.ReadLine();
            }
            else
            {

                Console.WriteLine("Here are the details for the next claim to be handled:");
                Console.WriteLine($"Claim ID: {nextClaim.ID}\n" +
                    $"Claim Type: {nextClaim.TypeOfClaim}\n" +
                    $"Claim Description: {nextClaim.Description}\n" +
                    $"Claim Amount: {nextClaim.Amount:C}\n" +
                    $"Date of Incident: {nextClaim.DateOfIncident.ToString("MM/dd/yyyy")}\n" +
                    $"Date of Claim: {nextClaim.DateOfClaim.ToString("MM/dd/yyyy")}\n" +
                    $"Is Valid: {nextClaim.IsValid}\n");

                Console.WriteLine("Would you like to deal with this claim now? (Y/N)");
                ConsoleKeyInfo userInput = Console.ReadKey();

                switch (userInput.Key)
                {
                    case ConsoleKey.Y:
                        Console.Clear();
                        _claims.RemoveNextClaim();
                        Console.WriteLine("The claim has been removed from the queue.\n" +
                            "Press enter to return to main menu...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.N:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
