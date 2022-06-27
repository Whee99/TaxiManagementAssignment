using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{ // start of namespace
    public class Program
    { // start of class Program
        //private int taxiNum;
        //private int rankId;
        //private Taxi t;

        //private static RankManager rm = new RankManager();
        //private static TaxiManager txm = new TaxiManager();
        //private static TransactionManager trm = new TransactionManager();

        //public UserUI ui = new UserUI(rm, txm, trm);

        public static void Main(string[] args)
        { // start of main
            /*
            Console.WriteLine("\n\tWrite your Taxi Management application in this project." +
                "\n\n\tFollow the instructions in the assignment specification." +
                "\n\n\tREMEMBER: do not change any of the code in the tests project." +
                "\n\n\tYou can delete the code in the Main() method.\n\n");
            */
            RankManager rm = new RankManager();
            TaxiManager txm = new TaxiManager();
            TransactionManager trm = new TransactionManager();
            UserUI ui = new UserUI(rm, txm, trm);

            while (true)
            { // start of while true
                Console.Write("What do you want to do? Input the corresponding number or 0 to quit:\n" +
                    "1. Add a taxi\n" + "2. Leave rank\n" + "3. Drop fare\n" +
                "4. View Financial Report\n" + "5. View Taxi Locations\n" + "6. View Transaction Log\n");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                { // start of AddTaxi
                    Console.WriteLine("You have selected 'Add a taxi'");
                    Console.WriteLine("Please input a taxi number and a rank ID");
                    int taxiNum = Convert.ToInt32(Console.ReadLine());
                    int rankId = Convert.ToInt32(Console.ReadLine());
                    foreach (string j in ui.TaxiJoinsRank(taxiNum, rankId))
                    {
                        Console.WriteLine(j);
                    }
                } // end of AddTaxi
                else if (option == 2)
                { // start of LeaveRank
                    Console.WriteLine("You have selected 'Leave rank'");
                    Console.WriteLine("Please enter a rank ID, a destination, and the agreed price:");
                    int rankId = Convert.ToInt32(Console.ReadLine());
                    string destination = Console.ReadLine();
                    double agreedPrice = Convert.ToDouble(Console.ReadLine());
                    foreach (string l in ui.TaxiLeavesRank(rankId, destination, agreedPrice))
                    {
                        Console.WriteLine(l);
                    }
                } // end of LeaveRank
                else if (option == 3)
                { // start of DropFare
                    Console.WriteLine("You have selected 'Drop fare'");
                    Console.WriteLine("Please enter a taxi number and whether the price has been paid or not.\n"
                        + "'yes' if price has been paid and 'no' if price has not been paid.");
                    int taxiNum = Convert.ToInt32(Console.ReadLine());
                    string priceWasPaid = Console.ReadLine();
                    if (priceWasPaid == "yes") {
                        bool pricePaid = true;
                        foreach (string d in ui.TaxiDropsFare(taxiNum, pricePaid))
                        {
                            Console.WriteLine(d);
                        }
                    }
                    else if (priceWasPaid == "no"){
                        bool pricePaid = false;
                        foreach (string d in ui.TaxiDropsFare(taxiNum, pricePaid))
                        {
                            Console.WriteLine(d);
                        }
                    }
                } // end of Dropfare
                else if (option == 4)
                { // start of ViewFinancialReport
                    Console.WriteLine("You have selected 'View Financial Report'");
                    foreach (string f in ui.ViewFinancialReport())
                    {
                        Console.WriteLine(f);
                    }
                } // end of ViewFinancialReport
                else if (option == 5)
                { // start of ViewTaxiLocations
                    Console.WriteLine("You have selected 'View Taxi Locations'");
                    foreach (string tL in ui.ViewTaxiLocations())
                    {
                        Console.WriteLine(tL);
                    }
                } // end of ViewTaxiLocations
                else if (option == 6)
                { // start of ViewTransactionLog
                    Console.WriteLine("You have selected 'View Transaction Log'");
                    foreach (string trL in ui.ViewTransactionLog())
                    {
                        Console.WriteLine(trL);
                    }
                } // end of ViewTransactionLog
                else if (option == 0)
                {
                    Console.WriteLine("Program ended");
                    break;
                }
                else
                {
                    Console.WriteLine("Option unavailable. Please choose again.");
                }
            } // end of while true

        } // end of main

        //private void DisplayMenu()
        //{
        //    Console.WriteLine("What function? ");
        //}

    } // end of class Program

} // end of namespace
