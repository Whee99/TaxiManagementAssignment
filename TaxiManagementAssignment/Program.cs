using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{ // start of namespace
    public class Program
    { // start of class Program
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
                int option = 0;

                Console.Write("What do you want to do?\n\n" +
                "1. Add a taxi\n" + "2. Leave rank\n" + "3. Drop fare\n" +
                "4. View Financial Report\n" + "5. View Taxi Locations\n" +
                "6. View Transaction Log\n\n" + "0. End Program\n\n");

                // makes sure the user inputs a number
                while (true)
                {
                    Console.Write("Please input the corresponding number: ");
                    string answer = Console.ReadLine();

                    bool isParsable = Int32.TryParse(answer, out option);

                    if (isParsable == false) {
                        Console.WriteLine("\nUser must input a number\n");
                    }
                    else {
                        break;
                    }
                }

                // Option 1: AddTaxi
                if (option == 1)
                { // start of AddTaxi
                    int taxiNum = 0;
                    int rankId = 0;
                    
                    Console.WriteLine("\nYou have selected 'Add a taxi'\n");

                    // makes sure the user inputs a number
                    while (true)
                    {
                        Console.Write("Please input a taxi number: ");
                        string answer = Console.ReadLine();

                        bool isParsable = Int32.TryParse(answer, out taxiNum);

                        if (isParsable == false) {
                            Console.WriteLine("\nUser must input a number\n");
                        }
                        else {
                            break;
                        }
                    }

                    // makes sure the user inputs a number
                    while (true)
                    {
                        Console.Write("Please input a rank ID: ");
                        string answer = Console.ReadLine();

                        bool isParsable = Int32.TryParse(answer, out rankId);

                        if (isParsable == false) {
                            Console.WriteLine("\nUser must input a number\n");
                        }
                        else {
                            break;
                        }
                    }

                    Console.WriteLine("");

                    foreach (string x in ui.TaxiJoinsRank(taxiNum, rankId))
                    {
                        Console.WriteLine(x);
                    }

                    Console.WriteLine("");
                } // end of AddTaxi

                // Option 2: LeaveRank
                else if (option == 2)
                { // start of LeaveRank
                    int rankId = 0;
                    double agreedPrice = 0;
                    
                    Console.WriteLine("\nYou have selected 'Leave rank'\n");

                    // makes sure the user inputs a number
                    while (true)
                    {
                        Console.Write("Please input a rank ID: ");
                        string answer = Console.ReadLine();

                        bool isParsable = Int32.TryParse(answer, out rankId);

                        if (isParsable == false) {
                            Console.WriteLine("\nUser must input a number\n");
                        }
                        else {
                            break;
                        }
                    }

                    Console.Write("Please enter a destination: ");
                    string destination = Console.ReadLine();

                    // makes sure the user inputs a number
                    while (true)
                    {
                        Console.Write("Please enter the agreed price: ");
                        string answer = Console.ReadLine();

                        bool isParsable = Double.TryParse(answer, out agreedPrice);

                        if (isParsable == false) {
                            Console.WriteLine("\nUser must input a number\n");
                        }
                        else {
                            break;
                        }
                    }

                    Console.WriteLine("");

                    foreach (string x in ui.TaxiLeavesRank(rankId, destination, agreedPrice))
                    {
                        Console.WriteLine(x);
                    }

                    Console.WriteLine("");
                } // end of LeaveRank

                // Option 3: DropFare
                else if (option == 3)
                { // start of DropFare
                    int taxiNum = 0;
                    string priceWasPaid = "";
                    
                    Console.WriteLine("\nYou have selected 'Drop fare'\n");

                    // makes sure the user inputs a number
                    while (true)
                    {
                        Console.Write("Please input a taxi number: ");
                        string answer = Console.ReadLine();

                        bool isParsable = Int32.TryParse(answer, out taxiNum);

                        if (isParsable == false) {
                            Console.WriteLine("\nUser must input a number\n");
                        }
                        else {
                            break;
                        }
                    }

                    // makes sure user inputs 'yes' or 'no'
                    while (true)
                    {
                        Console.Write("Please enter 'yes' if price has been paid and 'no' if price has not been paid: ");
                        priceWasPaid = Console.ReadLine();

                        if(priceWasPaid == "yes" || priceWasPaid == "no") {
                            break;
                        }
                        else {
                            Console.WriteLine("\nYou must enter 'yes' or 'no'.\n");
                        }
                    }

                    Console.WriteLine("");

                    if (priceWasPaid == "yes") {
                        bool pricePaid = true;
                        foreach (string x in ui.TaxiDropsFare(taxiNum, pricePaid))
                        {
                            Console.WriteLine(x);
                        }
                    }
                    else if (priceWasPaid == "no"){
                        bool pricePaid = false;
                        foreach (string x in ui.TaxiDropsFare(taxiNum, pricePaid))
                        {
                            Console.WriteLine(x);
                        }
                    }

                    Console.WriteLine("");
                } // end of Dropfare

                // Option 4: ViewFinancialReport
                else if (option == 4)
                { // start of ViewFinancialReport
                    Console.WriteLine("\nYou have selected 'View Financial Report'\n\n");

                    foreach (string x in ui.ViewFinancialReport())
                    {
                        Console.WriteLine(x);
                    }

                    Console.WriteLine("");
                } // end of ViewFinancialReport

                // Option 5: ViewTaxiLocation
                else if (option == 5)
                { // start of ViewTaxiLocations
                    Console.WriteLine("\nYou have selected 'View Taxi Locations'\n\n");

                    foreach (string x in ui.ViewTaxiLocations())
                    {
                        Console.WriteLine(x);
                    }

                    Console.WriteLine("");
                } // end of ViewTaxiLocations

                // Option 6: ViewTransactionLog
                else if (option == 6)
                { // start of ViewTransactionLog
                    Console.WriteLine("\nYou have selected 'View Transaction Log'\n\n");

                    foreach (string x in ui.ViewTransactionLog())
                    {
                        Console.WriteLine(x);
                    }

                    Console.WriteLine("");
                } // end of ViewTransactionLog

                // Option 7: End Program
                else if (option == 0)
                {
                    Console.WriteLine("\nProgram ended");
                    break;
                }

                // Invalid Input
                else
                {
                    Console.WriteLine("\nOption unavailable. Please choose again.\n");
                }
            } // end of while true

        } // end of main

    } // end of class Program

} // end of namespace
