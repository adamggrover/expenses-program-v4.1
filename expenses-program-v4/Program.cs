using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {

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
