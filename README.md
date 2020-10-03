"# GoldBadgeFinal" 
=======
# GoldBadgeProject
PURPOSE:
This readme contains all the informaton necessary to view and run the Komodo Company Operations
* Komodo Cafe new menu
* Komodo Insurance Claim Handling improvements
* Komodo Security Badge System
This is the first release of these programs and subject to many improvements in future releases. 

FILES INCLUDED:
Komodo Cafe:
This project includes the following files:  
  KomodoCafe_Console: This holds the files necessary to run the program and gather information from the user.
  KomodoCafe_Repo: This holds all the data that the user enters.  It also defines what operations will be performed.
  KomodoCafe_Tests:  This contains all the unit tests that will verify the methods built in the repository work as intended. 

Komodo Insurance:
This project includes the following files
  KomodoIns_Console: This holds the files necessary to run the program and gather information from the user.
  KomodoIns_Repo: This holds all the data that the user enters.  It also defines what operations will be performed.
  KomodoIns_Tests:  This contains all the unit tests that will verify the methods built in the repository work as intended. 
  
Komodo Badges:
  KomodoBadges_Console: This holds the files necessary to run the program and gather information from the user.
  KomodoBadges_Repo: This holds all the data that the user enters.  It also defines what operations will be performed.
  KomodoBadges_Tests:  This contains all the unit tests that will verify the methods built in the repository work as intended. 

OPERATIONS:

Komodo Cafe: 
This is a program that uses list operations to manipulate data for a menu system.
Running the ProgramUI.cs initiates a list that will manipulate menu items for the cafe menu.  The following options are available:
  Add a menu item:
    * this will walk the user through adding a menu item to the menu by asking a series of questions for the informationt o build the menu item.
    * Once completed, it will return the user to the main menu. 
  Delete a menu item
    * This option will show you all the current menu items and allow you to choose one to delete
    * If you enter an invalid item, it will tell you the content cannot be deleted.
    * If you enter a valid item, it will successfully delete the item.
  view the menu
    * This option will show you all the current menu options available for the men  
  Exit the menu
    * This menu option will close the program
    * All additions and deletions made while in the program will be removed from memory and not stored 
 
 Komodo Insurance Claims:
 This program uses queue operations to hold and manipulate the data entered through the menu.
 Running the ProgramUI.cs initiates a menu list that will manipulate claim information.  The following options are available:
  View all Existing Claims
    * This will display all the information for a claim
    * the claim type uses an enum class that will only allow selecting certain types of claims:  Car, Theft, Home
    * date of claim and date of incident are both entered with the claim to determin whether it is a valid claim.  
    * If the timespan is beyond 30 days, it will be marked as not valid
  Review the first claim in the queue
    * this menu pick will use the 'peek' queue operation to view the first item in the queue
    * It will give the user an option to work on this claim
    * If the user replies 'y' it will remove the claim 
    * if the user replied 'n' it will leave the claim and return the user to the main menu
  Enter a new claim into the system
    *This menu pick will create a new claim into memory
    *It will run through a series of prompts asking for the required information to create a new claim
    *Once the claim information is completed, it will be added to memory and the user returned to the main menu
  Exit the system
    *This menu pick closes out the program
    *Any information added or removed will be discarded from memory

Komodo Badge Entry:
This program uses a dictionary to collect and manipulate data entered by the user.  
Running the ProgramUI.cs initiates a menu that will manipulate badge access information.  The following options are available:
  Add a badge
    * this will add a new badge into the system
    * A series of questions will be asked so that the badge can be successfully added to the dictionary
    * There is currently no existing badges in the system. In order to do the other menu operations, a badge must first be entered into the system
  Delete a badge
    * this will remove a badge from the dictionary
    * if there isnt any badges, it will display a 'no badges exist' message 
    * if there are existing badges, they will be displayed and then the user will be asked which badge to delete
    * entering a valid badge number will result in a message that the badge was successfully deleted.
    * currently there are no hooks in place for entering an invalid badge id which will cause the program to crash...SO DON"T DO THAT!  that will be fixed in the next release!
  Update a badge
    * this will show all the available badges in the system then ask the user to enter the badge id to be updated
    * the user will be be prompted with a series of questions to update the badge information which are the same as when adding a badge
    * once completed the new badge information will replace the previous information.
    * once all information is completed, the user is returned to the main menu.
  View all badges
    * this will show all the available badges in the system
    * if no badges exist, a message will indicate that there are no badges in the system
    * if badges exist, they will be displayed one badge at at until all badges have been viewed
    * once all badges have been viewed, the user is returned to the main menu
  Exit menu
    * this will take the user out of the program
    * all information added, changed or deleted will be removed from memory and not stored for subsequent runs
    
CURRENT GOTCHAS:
Most operations take the 'happy path' when entering and manipulating data.  
Entering invalid data could result in crashing the program since asserts have not been added and will be scheduld for future releases.
For the Komodo Badges, the update feature is present; however, adding and removing only the badges is not an option and will be scheduled for future releases.
There is definitely room for many improvements.  Due to time constraints, several enhancements were not able to be implemented.  These will be scheduled for future releases.
All suggestions and creative critism is always welcome!
  