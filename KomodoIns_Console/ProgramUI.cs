using KomodoIns_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KomodoIns_Console
{
    class ProgramUI
    {
        private KomodoInsRepo _claimsRepo = new KomodoInsRepo();
        public void Run()
        {
            ExistingClaimList();
            Menu();
        }

        //Menu Items for Claims Manager to manage claims
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //list of menu items for claims agent to pick from
                Console.WriteLine("WELCOME TO THE KOMODO INSURANCE CLAIM MENU\n\n" +
                    "------------------------------------\n\n" +
                    "Select a menu option:\n\n" +
                    "1. View All Existing Claims\n" +
                    "2. Review the Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit\n\n" +
                    "-----------------------------------");

                //Get the Agent's menu pick
                string input = Console.ReadLine();

                //Go to the menu item the agent picked
                switch (input)
                {
                    case "1":
                        ViewAllClaims();
                        Console.Clear();
                        Console.WriteLine("No more claims to view.\n" +
                            "Press enter to return to main menu...");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case "2":
                        ViewFirstClaim();
                        break;

                    case "3":
                        EnterNewClaim();
                        Console.Clear();
                        Console.WriteLine("\nClaim successfully handled.\n" +
                            "Press enter to return to the main menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "4":
                        keepRunning = false;
                        Console.WriteLine("Exiting Menu, GOOD-BYE!");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Please enter a valid menu item");
                        break;
                }              
            }
        }

        //View all claims
        private void ViewAllClaims()
        {
            Queue<ClaimInfo> listOfClaims = _claimsRepo.ViewAllClaims();
            foreach(ClaimInfo claim in listOfClaims)
            {
                Console.Clear();
                Console.WriteLine(
                    $"Claim ID: {claim.ClaimId}\n" +
                    $"Claim Type: {claim.TypeOfClaim}\n" +
                    $"Claim Description: {claim.Description}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Date of Incident: {claim.DateOfIncident}\n" +
                    $"Date of Claim: {claim.DateOfClaim}\n" +
                    $"Is Claim Valid: {claim.IsValid}\n");
                Console.WriteLine("Press any key to see next claim...");
                Console.ReadKey();
               
            }
        }

        //Display first claim in list

        public void ViewFirstClaim()
        {
            ClaimInfo claim = _claimsRepo.GetNextClaim();

            Console.Clear();
            Console.WriteLine(
                $"Claim ID: {claim.ClaimId}\n" +
                $"Claim Type: {claim.TypeOfClaim}\n" +
                $"Claim Description: {claim.Description}\n" +
                $"Claim Amount: {claim.ClaimAmount}\n" +
                $"Date of Incident: {claim.DateOfIncident}\n" +
                $"Date of Claim: {claim.DateOfClaim}\n" +
                $"Is Claim Valid: {claim.IsValid}\n");

            Console.WriteLine("Are you available to work on this claim? Please enter y or n");
            
            string input = Console.ReadLine();

            if (input == "y")
            {
                _claimsRepo.DeleteClaimfromQueue();
                Console.WriteLine("Claim Successfully Completed.\n" +
                    "Press enter to return to the main menu...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
               Console.WriteLine("No action at this time.  Returning to Main Menu...");
               Console.ReadKey();
               Console.Clear();
            }     
        }   

        //Enter a new claim
        private void EnterNewClaim()
        {
            ClaimInfo newClaim = new ClaimInfo();

            Console.WriteLine("Enter the Claim ID:");
            string claimIdAsString = Console.ReadLine();
            newClaim.ClaimId = int.Parse(claimIdAsString);

            Console.WriteLine("Enter the Claim Type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");

            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newClaim.TypeOfClaim = (ClaimType)claimTypeAsInt;

            Console.WriteLine("Enter Claim Description:");
            string claimDescription = Console.ReadLine();
            newClaim.Description = claimDescription;
           
            Console.WriteLine("Enter Amount of Damage:");
            string claimAmtAsString = Console.ReadLine();
            newClaim.ClaimAmount = decimal.Parse(claimAmtAsString);

            Console.WriteLine("Enter Date of Accident:");
            string accidentDateAsString = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(accidentDateAsString);

            Console.Write("Enter Report Date of Claim:\n");
            string claimDateAsString = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(claimDateAsString);

            //is claim valid
            DateTime t1 = newClaim.DateOfClaim;
            DateTime t2 = newClaim.DateOfIncident;
            TimeSpan Diff_dates = t1.Subtract(t2);
            if(Diff_dates.Days <= 30)
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }
            Console.WriteLine($"Days since incident: {Diff_dates.Days} so claim is valid: {newClaim.IsValid}");
            
           
            _claimsRepo.AddClaimToList(newClaim);
        }
        //Add existing claims to repo
        private void ExistingClaimList()
        {
            ClaimInfo claim1 = new ClaimInfo(1,ClaimType.Car ,"Car accident on 465", 400m, Convert.ToDateTime("4/25/2018"), Convert.ToDateTime("4/27/2018"), true);
            ClaimInfo claim2 = new ClaimInfo(2,ClaimType.Home,"House fire in kitchen", 4000m, Convert.ToDateTime("4/11/2018"), Convert.ToDateTime("4/12/2018"), true);
            ClaimInfo claim3 = new ClaimInfo(3, ClaimType.Theft, "Stolen pancakes", 4m, Convert.ToDateTime("4/27/2018"), Convert.ToDateTime("6/1/2018"), false);
            _claimsRepo.AddClaimToList(claim1);
            _claimsRepo.AddClaimToList(claim2);
            _claimsRepo.AddClaimToList(claim3); 
        }
    }
}
