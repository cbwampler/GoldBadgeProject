using KomodoBadges_Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Console
{
    class ProgramUI
    {
        private BadgesRepo _repo = new BadgesRepo();
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //list of menu items for Security Admin
                Console.WriteLine("Hello, Security Admin, what would you like to do?\n\n" +
                    "Select a menu option:\n\n" +
                    "1. Add a badge\n" +
                    "2. Delete a badge\n" +
                    "3. Update a badge\n" +
                    "4. View all badges\n" +
                    "5. Exit menu");

                //get the Admin's menu pick
                string menuItem = Console.ReadLine();

                //go to the menu item the admin selected

                switch (menuItem)
                {
                    case "1":
                        AddNewBadgeToDict();
                        Console.Clear();
                        break;

                    case "2":
                        RemoveBadgeFromDict();
                        //Console.Clear();
                        break;

                    case "3":
                        UpdateDoorsForBadge();
                        Console.Clear();
                        break;

                    case "4":
                        ViewAllBadges();
                        // Console.Clear();
                        break;

                    case "5":
                        keepRunning = false;
                        Console.WriteLine("Exiting Menu, Good-Bye!\n" +
                            "(Press any key to clear the screen)");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Please enter a valid menu item");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                }
            }
        }

        //Add badge

        public void AddNewBadgeToDict()
        {
            List<string> doorAccess = new List<string>();

            Console.WriteLine("Enter the Badge Id:");
            string badgeIdAsString = Console.ReadLine();
            int badgeId = int.Parse(badgeIdAsString);

            Console.WriteLine("Enter the name for this badge:");
            string badgeName = Console.ReadLine();


            Console.WriteLine("Enter the door that it needs access to:");
            string doorName = Console.ReadLine();
            doorAccess.Add(doorName);

            bool moreDoors = true;
            while (moreDoors)

            {
                Console.WriteLine("Any other Doors to be Added? Enter y or n");
                string input = Console.ReadLine();

                if (input == "y")
                {
                    Console.WriteLine("Enter the next door to access:");
                    string nextdoorName = Console.ReadLine();
                    doorAccess.Add(nextdoorName);
                }
                else
                {
                    moreDoors = false;
                    Console.WriteLine("Returning you to main menu\n" +
                        "(Press any key to continue)");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            _repo.AddBadgeToDict(badgeId, new BadgeInfo(badgeId, doorAccess, badgeName));
        }

        //View All Badges
        public void ViewAllBadges()
        {
            Dictionary<int, BadgeInfo> listOfBadges = _repo.ViewAllBadges();

            if (listOfBadges.Count != 0)
            {
                foreach (KeyValuePair<int, BadgeInfo> badgeDetails in listOfBadges)
                {
                    {
                        Console.Clear();
                        Console.WriteLine($"Badge ID: {badgeDetails.Key}\n" +
                            $"Badge Name: {badgeDetails.Value.BadgeName}\n");

                        foreach (var i in
                            badgeDetails.Value.DoorNames)
                        {
                            Console.WriteLine($"Door Assigned: {i}");

                        }
                        Console.WriteLine("\nPress enter to continue...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            else
            {
                Console.WriteLine("No badges exist.  To add a badge, select option 1...");
                Console.ReadKey();
                Console.Clear();
            }

        }

        //Delete badge

        private void RemoveBadgeFromDict()
        {
            ViewAllBadges();

            Dictionary<int, BadgeInfo> listOfBadges = _repo.ViewAllBadges();

            if (listOfBadges.Count != 0)
            {
                //Get the badge to remove
                Console.WriteLine("Enter the Badge ID you would like to delete");

                int badgeId = int.Parse(Console.ReadLine());

                //Call the delete method
                bool wasDeleted = _repo.DeleteBadgeFromDict(badgeId);

                if (wasDeleted)
                {
                    Console.WriteLine("The badge was successfully deleted");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        //Update Badge Acces to Doors

        private void UpdateDoorsForBadge()
        {
            //Display all content
            ViewAllBadges();

            // Ask for the id of the badge to updateo
            Console.WriteLine("Enter the Badge ID you would like to update");

            // Get the id of the badge to update
            int oldBadgeID =  int.Parse(Console.ReadLine());

            // Build a new object
            List<string> doorAccess = new List<string>();


            Console.WriteLine("Enter the Badge Id:");
            string badgeIdAsString = Console.ReadLine();
            int badgeId = int.Parse(badgeIdAsString);

            Console.WriteLine("Enter the name for this badge:");
            string badgeName = Console.ReadLine();


            Console.WriteLine("Enter the door that it needs access to:");
            string doorName = Console.ReadLine();
            doorAccess.Add(doorName);

            bool moreDoors = true;
            while (moreDoors)

            {
                Console.WriteLine("Any other Doors to be Added? Enter y or n");
                string input = Console.ReadLine();

                if (input == "y")
                {
                    Console.WriteLine("Enter the next door to access:");
                    string nextdoorName = Console.ReadLine();
                    doorAccess.Add(nextdoorName);
                }
                else
                {
                    moreDoors = false;
                    Console.WriteLine("Returning you to main menu\n" +
                        "(Press any key to continue)");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            // Verify the update worked
           bool wasUpdated = _repo.UpdateDoorsForBadge(oldBadgeID, new BadgeInfo(badgeId, doorAccess, badgeName));
        
            if (wasUpdated)
            {
                Console.WriteLine("Badge Successfully Updted");
            }
            else
            {
                Console.Write("Badge could not be updated.  Fix the issues and try again.");
            }  
        }
    }
}
    
