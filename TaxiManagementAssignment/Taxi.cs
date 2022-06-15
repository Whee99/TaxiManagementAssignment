using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{ // start of namespace
    public class Taxi
    { // start of class Taxi

        public int Number = 0;
        public double CurrentFare = 0;
        public string Destination = "";
        public static string IN_RANK = "in rank";
        public static string ON_ROAD = "on the road";
        public string Location = ON_ROAD;
        public double TotalMoneyPaid = 0;
        public Rank Rank;

        public Taxi(int num)
        { // start of Taxi

            Number = num;

        } // end of Taxi

        public void AddFare(string destination, double agreedPrice)
        { // start of AddFare

            Location = ON_ROAD;
            CurrentFare = agreedPrice;
            Destination = destination;
            Rank = null;

        } // end of AddFare

        public void DropFare(bool priceWasPaid)
        { // start of DropFare

            if(priceWasPaid == false) {
                TotalMoneyPaid = 0;
            }
            else {
                TotalMoneyPaid = CurrentFare;
                Destination = "";
                CurrentFare = 0;
            }

        } // end of DropFare

    } // end of class Taxi

} // end of namespace
