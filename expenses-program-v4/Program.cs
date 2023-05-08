using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)

    {

        List<User> users = new List<User>();



        Console.Write("\n---------------------EXPENSE CLAIM PROGRAM---------------------\n\n");

        



        // Loop through the list of users to check if the login details match
        bool isLoggedIn = false;

        while (!isLoggedIn)
        {
            Console.Write("\nPlease make a selection:\n\n");

            // Ask the user to select the claim type from the available choices

            for (int i = 0; i < User.loginChoices.Length; i++)
            {
                Console.WriteLine(i + 1 + ") " + User.loginChoices[i]);

            }

            string loginChoice = "";

            bool validInput = false;


            while (validInput == false)
            {

                try
                {
                    // Parse user selected index to local variable
                    int loginChoiceIndex = int.Parse(Console.ReadLine()) - 1;

                    // Assign user selected claim type to expense claim object field
                    loginChoice = User.loginChoices[loginChoiceIndex];

                    validInput = true;

                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid selection. Please try again");

                }


            }

            // Add some sample users to the list
            users.Add(new User("employee1", "password1", false));
            users.Add(new User("admin1", "password2", true));



            if (loginChoice == "Create new User")
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
                users.Add(newUser);

                Console.WriteLine("Hi " + newUser.GetUsername() + ". New user created successfully.");
            }

            // Prompt the user to enter their username and password
            Console.Clear();
            Console.WriteLine("-------------Login---------------\n");
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            foreach (User user in users)
            {
                if (user.GetUsername() == username && user.GetPassword() == password)
                {
                    isLoggedIn = true;

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






    }

}
