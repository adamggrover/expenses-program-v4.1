using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Journey
{
    // Fields
    static int journeyCount = 0;

    private int journeyId;
    private double expenseCost;
    private double travelCost;
    private double nonRefundable = 0;
    private string[] claimTypes = { "Travel and Expenses", "Just Travel" };
    private string claimType;
    private double maxRefundable = 50;
    private bool validInput = false;



    // Constructor

    public Journey()
    {
        ++journeyCount;
        this.journeyId = journeyCount;


    }


    //---------Expense Cost-------------------------------------------------------------------------------------------------------------//

    // Setter method for the expense cost field    
    public void SetExpenseCost(double expenseCost)
    {
        this.expenseCost = expenseCost;
    }

    // Getter method for the expense cost field
    public double GetExpenseCost()
    {
        return expenseCost;
    }


    //---------Travel Cost---------------------------------------------------------------------------------------------------------------//

    // Setter method for the travel cost field
    public void SetTravelCost()
    {
        // Ask the user to enter the travel cost
        Console.WriteLine("\nPlease enter the travel cost: ");
        double travelCost = double.Parse(Console.ReadLine());

        // Set the travel cost in the current object
        this.travelCost = travelCost;
    }

    // Getter method for the travel cost field
    public double GetTravelCost()
    {
        return travelCost;
    }


    //---------Non-Refundable---------------------------------------------------------------------------------------------------------//

    // Setter method for the non-refundable amount field

    public void SetNonRefundable(double expenseCost)
    {
        if (expenseCost > 50)
        {
            this.nonRefundable = expenseCost - maxRefundable;

        }

    }

    // Getter method for the non-refundable amount field
    public double GetNonRefundable()
    {
        return nonRefundable;
    }


    //---------Claim Type---------------------------------------------------------------------------------------------------------//

    // Setter method for the claim type field
    public void SetClaimType()
    {
        Console.Clear();


        // Print journey number to the console
        Console.WriteLine("\nJourney " + journeyId + " Details\n");
        // Ask the user to select the claim type from the available choices
        Console.WriteLine("Please select a claim type:\n");
        for (int i = 0; i < claimTypes.Length; i++)
        {
            Console.WriteLine(i + 1 + ") " + claimTypes[i]);

        }


        while (validInput == false)
        {

            try
            {
                // Parse user selected index to local variable
                int claimTypeIndex = int.Parse(Console.ReadLine()) - 1;

                // Assign user selected claim type to expense claim object field
                this.claimType = claimTypes[claimTypeIndex];

                validInput = true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid selection. Please try again");

            }


        }





    }

    // Getter method for the claim type field
    public string GetClaimType()
    {
        return claimType;
    }


    //---------Total Cost---------------------------------------------------------------------------------------------------------//

    // Method to calculate the total cost of the journey
    public double GetTotalCost()
    {
        // Calculate the total cost by adding the expense cost and travel cost and then subtracting the non-refundable amount
        double totalCost = expenseCost + travelCost;

        return totalCost;
    }

    //---------Receipt Details--------------------------------------------------------------------------------------------------------//

    // Method to generate the receipt details as a list of strings
    public List<string> GetReceiptDetails()
    {
        // Create a new list to store the receipt details
        List<string> details = new List<string>();

        // Add the claim type, expense cost, travel cost, non-refundable amount, and total cost to the list of receipt details
        details.Add("\nReceipt Details for journey #" + journeyId + ":");
        details.Add("\nClaim type for journey #" + journeyId + ": " + claimType);
        details.Add("\nTravel costs for journey #" + journeyId + ": £" + travelCost);
        details.Add("Cost of other expenses for journey #" + journeyId + ": £" + expenseCost);
        details.Add("Total costs for journey #" + journeyId + ": £" + GetTotalCost());
        details.Add("Non-refundable amount for journey #" + journeyId + ": £" + nonRefundable);


        // Return the list of receipt details
        return details;
    }
}

















