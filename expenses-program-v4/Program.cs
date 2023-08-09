using System;
using System.Collections.Generic;
using Newtonsoft.Json;



class Program

{
    // Fields
    static int currentUserId = 0;
    static List<User> users = new List<User>();
    static List<ExpenseClaim> Expenseclaims = new List<ExpenseClaim>();
    static bool isLoggedIn = false;
    static string loginChoice = "";
    static bool validInput = false;
    static int loginChoiceIndex = 0;
    static string[] employeeMenuChoices = { "Enter a New Expense Claim", "Logout" };
    static string[] adminMenuChoices = { "Largest Expense Claim Payment", "Average Expense Claim Payment" };
    static int adminMenuChoiceIndex = 0;
    static int employeeMenuChoiceIndex = 0;



    // Methods

    static void LoginOptions()
    {


            Console.Write("\nPlease make a selection:\n\n");

            // Ask the user to select the claim type from the available choices

            for (int i = 0; i < User.loginChoices.Length; i++)
            {
                Console.WriteLine(i + 1 + ") " + User.loginChoices[i]);

            }




            while (validInput == false)
            {

                try
                {
                    // Parse user selected index to local variable
                    loginChoiceIndex = int.Parse(Console.ReadLine()) - 1;

                    // Assign user selected claim type to expense claim object field
                    loginChoice = User.loginChoices[loginChoiceIndex];

                    validInput = true;

                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid selection. Please try again");

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
        users.Add(newUser);

        Console.WriteLine("Hi " + newUser.GetUsername() + ". New user created successfully.");

        // Assign current user id to variable
        currentUserId = newUser.GetUserId();
    }


    static void Login()
    {

        // Create new User objects and add it to the list
        User User1 = new User("john", "password123", false);
        users.Add(User1);
        User User2 = new User("sarah", "puppies", true);
        users.Add(User2);

        // Prompt the user to enter their username and password
        Console.Clear();
        Console.WriteLine("-------------Login---------------\n");
        Console.Write("Username: ");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        // Loop through existing users to check for a match
        foreach (User user in users)
        {
            if (user.GetUsername() == username && user.GetPassword() == password)
            {
                isLoggedIn = true;

                // Assign current user id to variable
                currentUserId = user.GetUserId();

                if (user.IsAdmin())
                {
                    Console.WriteLine("\nLogin successful (admin)");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\nLogin successful (employee)");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }

                if (users[currentUserId - 1].IsAdmin())
                {
                    AdminMenu();
                }
                else
                {
                    EmployeeMenu();
                }


            }
        }

        if (!isLoggedIn)
        {
            Console.WriteLine("\nLogin failed\n");
            Console.WriteLine("Press any key to try again");
            Console.ReadKey();
        }
    }



    static void AdminMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------Admin Menu------------------");

        Console.Write("\nPlease make a selection:\n\n");

        // Ask the user to select the menu from the available choices

        for (int i = 0; i < adminMenuChoices.Length; i++)
        {
            Console.WriteLine(i + 1 + ") " + adminMenuChoices[i]);

        }

        validInput = false;

        while (validInput == false)
        {

            try
            {
                // Parse user selected index to local variable
                adminMenuChoiceIndex = int.Parse(Console.ReadLine()) - 1;



                validInput = true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid selection. Please try again");

            }

            switch (adminMenuChoiceIndex)
            {
                case 0:
                    LargestPayment();
                    break;
                case 1:
                    AveragePayment();
                    break;
                case 2:
                    Console.WriteLine("\nYou have now logged out");
                    Console.WriteLine("\nPress any key to login");
                    Console.ReadKey();
                    Login();
                    break;
                default:
                    Login();
                    break;
            }



        }
    }


    static void EmployeeMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------Employee Menu------------------");

        Console.Write("\nPlease make a selection:\n\n");

        // Ask the user to select the menu from the available choices

        for (int i = 0; i < employeeMenuChoices.Length; i++)
        {
            Console.WriteLine(i + 1 + ") " + employeeMenuChoices[i]);

        }

        validInput = false;

        while (validInput == false)
        {

            try
            {
                // Parse user selected index to local variable
                employeeMenuChoiceIndex = int.Parse(Console.ReadLine()) - 1;



                validInput = true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid selection. Please try again");

            }

            switch (employeeMenuChoiceIndex)
            {
                case 0:
                    NewExpenseClaim();
                    break;
                case 1:
                    Console.WriteLine("\nYou have now logged out");
                    Console.WriteLine("\nPress any key to login");
                    Console.ReadKey();
                    Login();
                    break;
                default:
                    Login();
                    break;
            }



        }
    }

    static void NewExpenseClaim()
    {
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

    static void LargestPayment()
    {
        if (Expenseclaims.Count < 1)
        {
            Console.WriteLine("There are currently no expense claims in the system");
            return;
        }
        
        double largestPayment = 0;
        int largestPaymentExpenseClaimId = 0;


        foreach (var ExpenseClaim in Expenseclaims)
        {
            

            if (ExpenseClaim.GetTotalExpenseClaim() > largestPayment)
            {
                largestPayment = ExpenseClaim.GetTotalExpenseClaim();
                largestPaymentExpenseClaimId = ExpenseClaim.GetClaimId();

            }
        }


        Console.WriteLine("The largest payment made was £" + largestPayment + " in expense claim #" + largestPaymentExpenseClaimId);
        

        
        
    }


    static double AveragePayment()
    {

        double averagePayment = 0;  


        foreach (var ExpenseClaim in Expenseclaims)
        {


            double totalPayments =+ ExpenseClaim.GetTotalExpenseClaim();
            int totalExpenseClaims = Expenseclaims[0].GetClaimId();

            averagePayment = totalPayments / totalExpenseClaims;
        }

        return averagePayment;
        

    }


    static void Main(string[] args)

    {

        Console.Write("---------------------EXPENSE CLAIM PROGRAM---------------------\n\n");


        // Loop through while the user isn't logged in
        while (!isLoggedIn)

        {
            LoginOptions();

            if (loginChoice == "Create new User")
            {
                CreateNewUser();
            }

            Login();

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
