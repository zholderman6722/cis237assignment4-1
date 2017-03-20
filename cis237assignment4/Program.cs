﻿//Zachery Holderman
//CIS237
//Instructor: David Barnes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new droid collection and set the size of it to 100.
            DroidCollection droidCollection = new DroidCollection(100);

            //Create a user interface and pass the droidCollection into it as a dependency
            UserInterface userInterface = new UserInterface(droidCollection);

            //Display the main greeting for the program
            userInterface.DisplayGreeting();

            //Display the main menu for the program
            userInterface.DisplayMainMenu();

            droidCollection.hardcodedDroids();

            //Get the choice that the user makes
            int choice = userInterface.GetMenuChoice();
            
            
            //While the choice is not equal to 5, continue to do work with the program
            while (choice != 5)
            {
                //Test which choice was made
                switch (choice)
                {
                    //Choose to create a droid
                    case 1:
                        userInterface.CreateDroid();
                        break;

                    //Choose to Print the droid
                    case 2:
                        userInterface.PrintDroidList();
                        break;
                    case 3:
                        droidCollection.sortDroidTypes();
                        Console.WriteLine("***********************************");
                        Console.WriteLine("Droids have been sorted by type.");
                        Console.WriteLine("***********************************");
                        break;
                    case 4:
                        droidCollection.sortDroidCost();
                        Console.WriteLine("***********************************");
                        Console.WriteLine("Droids have been sorted by cost.");
                        Console.WriteLine("***********************************");
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                        
                }
                //Re-display the menu, and re-prompt for the choice
                userInterface.DisplayMainMenu();
                choice = userInterface.GetMenuChoice();
            }


        }
    }
}
