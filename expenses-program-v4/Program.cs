using System;
using System.Collections.Generic;
using Newtonsoft.Json;



class Program

{  
    static bool isLoggedIn = false;
    static int currentUserId = 0;
    static List<User> Users = new List<User>();
    static string loginChoice = "";
    static bool validInput = false;
    static public string[] loginChoices = { "Login with existing account", "Create new User" };


    // Methods

    static void LoginMenu()
    {
        Console.Write("---------------------EXPENSE CLAIM PROGRAM---------------------\n\n");

        // Loop through until user is logged in

        while (!isLoggedIn)
        {
            Console.Write("\nPlease make a selection:\n\n");

            // Ask the user to select from the login choices menu

            for (int i = 0; i < loginChoices.Length; i++)
            {
                Console.WriteLine(i + 1 + ") " + loginChoices[i]);

            }

           
            // Check if user selection is valid or not

            while (validInput == false)
            {

                try
                {
                    // Parse user selected index to local variable
                    int loginChoiceIndex = int.Parse(Console.ReadLine()) - 1;

                    // Assign user selected claim type to expense claim object field
                    loginChoice = loginChoices[loginChoiceIndex];

                    validInput = true;

                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid selection. Please try again");

                }


            }




            if (loginChoice == "Create new User")
            {
                CreateNewUser();

            }

            // Prompt the user to enter their username and password
            Console.Clear();
            Console.WriteLine("-------------Login---------------\n");
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            // Loop through existing users to check for a match
            foreach (User user in Users)
            {
                if (user.GetUsername() == username && user.GetPassword() == password)
                {
                    isLoggedIn = true;

                    // Assign current user id to variable
                    currentUserId = user.GetUserId();

                    if (user.IsAdmin())
                    {
                        Console.WriteLine("Login successful (admin)");
                    }
                    else
                    {
                        Console.WriteLine("Login successful (employee)");
                    }

                    break;
                }
            }

            if (!isLoggedIn)
            {
                Console.WriteLine("Login failed\n");
            }

        }
    }

    static void CreateNewUser()
    {
        Console.Clear();
        Console.WriteLine("-------------Create New User---------------\n");
        // Prompt the user to enter details for the new user
        Console.Write("Enter a username: ");
        string newUsername = Console.ReadLine();

        Console.Write("Enter a password: ");
        string newPassword = Console.ReadLine();

        Console.Write("Is this user an admin (y/n)? ");
        bool isAdmin = Console.ReadLine().ToLower() == "y";

        // Create a new User object and add it to the list
        User newUser = new User(newUsername, newPassword, isAdmin);
        Users.Add(newUser);

        Console.WriteLine("Hi " + newUser.GetUsername() + ". New user created successfully.");

        // Assign current user id to variable
        currentUserId = newUser.GetUserId();
    }





    static void Main(string[] args)

    {

        // Create list for user objects

        List<User> users = new List<User>();


        // Add some sample users to the list
        users.Add(new User("employee1", "password1", false));
        users.Add(new User("admin1", "password2", true));


        

        LoginMenu();





        if (users[currentUserId - 1].IsAdmin())
        {
            Console.Clear();
            Console.WriteLine("---------------Admin Menu------------------");
        }

     


        // Create a list of the ExpenseClaim objects
        List<ExpenseClaim> Expenseclaims = new List<ExpenseClaim>();

        // Create a new instance of the ExpenseClaim class
        ExpenseClaim expenseClaim = new ExpenseClaim();

        // Print Title of program to console
        
        Console.Write("\n---------------------NEW EXPENSE CLAIM---------------------\n\n");


        // Ask user to set number of journeys in expense claim object
        expenseClaim.SetNumberOfJourneys();

        // Loop through for the amount of journeys selected by the user for the expense claim instance
        for (int i = 0; i < expenseClaim.GetNumberOfJourneys(); i++)
        {
            // Create a new instance of the Journey class
            Journey journey = new Journey();


            // Get the user to set the claim type of the journey
            journey.SetClaimType();

            // Get the user to set the travel cost of the current journey
            journey.SetTravelCost();

            // Add current journey instance expenses to current claim instance running total
            expenseClaim.AddToTotalTravelCost(journey.GetTravelCost());

            // If claim is for expenses as well as travel then set expense cost 

            if (journey.GetClaimType() == "Travel and Expenses")
            {
                // Ask the user to enter the expense cost ,parse to double and save to local variable
                Console.WriteLine("\nPlease enter the expense cost: ");
                double expenseCost = double.Parse(Console.ReadLine());

                // Set current journey expense cost from user input
                journey.SetExpenseCost(expenseCost);

                // Set the non refundable amount in the current journey object
                journey.SetNonRefundable(expenseCost);

                // Add current journey instance non refundable amount to current claim instance running total
                expenseClaim.AddToTotalNonRefundable(journey.GetNonRefundable());

                // Add current journey instance expenses to current claim instance running total
                expenseClaim.AddToTotalExpenses(expenseCost);

                //Add current journey instance expense and travel cost totals to current expense claim instance running total
                expenseClaim.AddToTotalExpenseClaim();


                expenseClaim.SetTotalEmployeePayment();


            }





            // Add current journey instance to the list of journeys
            expenseClaim.GetJourneysList().Add(journey);


            

        }

        // Print current expense claim receipt details

        Console.Clear();
        // Print dividing lines x 2
        for (int j = 0; j < 2; j++)
        {
            Console.WriteLine("\n----------------------------------------------------------");
        }

        Console.WriteLine("\nExpense Claim #" + expenseClaim.GetClaimId() + " Receipt Details");

        Console.WriteLine("\n----------------------------------------------------------");



        // Print out journey details for each journey in expense claim
        foreach (var journey in (expenseClaim.GetJourneysList()))
        {
            foreach (var detail in (journey.GetReceiptDetails()))
            {
                Console.WriteLine(detail);
                ;
            }
            Console.WriteLine("\n---------------------------------------------------------");
        }

        // Print out expense claim recipt details for whole claim

        Console.WriteLine("\n----------------------------------------------------------");

        foreach (var detail in (expenseClaim.GetReceiptDetails()))
        {
            Console.WriteLine(detail);
        }

        // Print dividing lines x 2
        for (int j = 0; j < 2; j++)
        {
            Console.WriteLine("\n----------------------------------------------------------");
        }





        // serialize JSON to a string and then write string to a file
        //File.WriteAllText(@"/expenseClaims.json", JsonConvert.SerializeObject(expenseClaim));

        // serialize JSON directly to a file
        /*using (StreamWriter file = File.CreateText(@"\expenseClaims.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, expenseClaim);
        }*/









    }

}
