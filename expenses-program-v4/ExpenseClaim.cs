using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;



internal class ExpenseClaim
{

    // Fields
    static int claimCount = 0;

    private int claimId;
    private int numberOfJourneys;
    private double totalExpenses = 0;
    private double totalTravelCost = 0;
    // Create a list of the Journey objects
    private List<Journey> Journeys = new List<Journey>();
    private double totalExpenseClaim = 0;
    private double totalNonRefundable = 0;
    private double totalEmployeePayment = 0;


    // Constructor
    public ExpenseClaim()
    {
        ++claimCount;
        this.claimId = claimCount;


    }

    //--------Claim Id-----------------------------------//

    // Getter method for Claim Id

    public int GetClaimId()
    {
        return claimId;
    }


    //---------Journeys-----------------------------//

    // Setter method for the number of journeys field    
    public void SetNumberOfJourneys()
    {
        // Ask the user for the number of journeys completed
        Console.Write("Please enter the number of journeys completed: ");

        // Assign number of journeys user selected to local variable
        this.numberOfJourneys = int.Parse(Console.ReadLine());

    }

    // Getter method for the number of journeys field
    public int GetNumberOfJourneys()
    {
        return numberOfJourneys;
    }


    // Getter method for Journeys list

    public List<Journey> GetJourneysList()
    {
        return Journeys;
    }

    // Setter method for adding Journey to Journeys list

    public void AddJourneyToList(Journey journey)
    {
        Journeys.Add(journey);
    }







    //---------Total Expenses-----------------------------//


    // Setter method for the total expenses field

    public void AddToTotalExpenses(double expenseCost)
    {
        this.totalExpenses += expenseCost;
    }


    // Getter method for the total expenses field
    public double GetTotalExpenses()
    {
        return Math.Round(totalExpenses, 2);
    }

    //---------Total Travel Cost-----------------------------//

    // Setter method for the total travel cost field

    public void AddToTotalTravelCost(double travelCost)
    {
        this.totalTravelCost += travelCost;
    }


    // Getter method for the total expenses field
    public double GetTotalTravelCost()
    {
        return Math.Round(totalTravelCost, 2);
    }

    //---------Total Expense Claim-----------------------------//

    // Setter method for the total travel cost field

    public void AddToTotalExpenseClaim()
    {
        this.totalExpenseClaim = totalTravelCost + totalExpenses;
    }


    // Getter method for the total expenses field
    public double GetTotalExpenseClaim()
    {
        return Math.Round(totalExpenseClaim, 2);
    }

    //---------Total Non Refundable-----------------------------//

    // Setter method for the total travel cost field

    public void AddToTotalNonRefundable(double nonRefundable)
    {
        this.totalNonRefundable += nonRefundable;
    }


    // Getter method for the total expenses field
    public double GetTotalNonRefundable()
    {
        return totalNonRefundable;
    }


    //---------Total Non Refundable-----------------------------//

    // Setter method for the total travel cost field

    public void SetTotalEmployeePayment()
    {
        this.totalEmployeePayment = totalExpenseClaim - totalNonRefundable;
    }


    // Getter method for the total expenses field
    public double GetTotalEmployeePayment()
    {
        return totalEmployeePayment;
    }



    //---------Receipt Details--------------------------------------------------------------------------------------------------------//

    // Method to generate the receipt details as a list of strings
    public List<string> GetReceiptDetails()
    {
        // Create a new list to store the receipt details
        List<string> details = new List<string>();

        // Add the claim type, expense cost, travel cost, non-refundable amount, and total cost to the list of receipt details


        details.Add("\nExpense Claim #" + claimId + " Totals\n");
        details.Add("\nTotal travel costs: £" + GetTotalTravelCost());
        details.Add("Total cost of other expenses: £" + GetTotalExpenses());
        details.Add("Total cost of expense claim: £" + GetTotalExpenseClaim());
        details.Add("Total amount that can be reclaimed by company: £" + GetTotalExpenseClaim() * 0.2);
        details.Add("Total non refundable amount: £" + GetTotalNonRefundable());
        details.Add("Total payment due to employee £" + GetTotalEmployeePayment());

        // details.Add("Non-refundable amount: " + nonRefundable);


        // Return the list of receipt details
        return details;
    }

}
