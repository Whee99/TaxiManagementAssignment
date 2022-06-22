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
        public const string IN_RANK = "in rank";
        public const string ON_ROAD = "on the road";
        public string Location = ON_ROAD;
        public double TotalMoneyPaid = 0;
        private Rank rank;
        public Rank Rank
        {
            get { return rank; }
            set
            {
                if (value is null) {
                    throw new Exception("Rank cannot be null");
                }
                else if (Destination.Length > 0) {
                    throw new Exception("Cannot join rank if fare has not been dropped");
                }
                else {
                    rank = value;
                    Location = IN_RANK;
                }

            }
        }

        public Taxi(int num)
        { // start of Taxi
            Number = num;
        } // end of Taxi

        public void AddFare(string destination, double agreedPrice)
        { // start of AddFare
            rank = null;
            Location = ON_ROAD;
            CurrentFare = agreedPrice;
            Destination = destination;
        } // end of AddFare

        public void DropFare(bool priceWasPaid)
        { // start of DropFare
            if (priceWasPaid == false) {
                TotalMoneyPaid = 0;
            }
            else {
                TotalMoneyPaid += CurrentFare;
                Destination = "";
                CurrentFare = 0;
            }
        } // end of DropFare

        public double GetCurrentFare()
        { // start of GetCurrentFare
            return CurrentFare;
        } // end of GetCurrentFare

        public string GetDestination()
        { // start of GetDestination
            return Destination;
        } // end of GetDestination

        public string GetLocation()
        { // start of GetLocation
            return Location;
        } // end of GetLocation

        public int GetNumber()
        { // start of GetNumber
            return Number;
        } // end of GetNumber

        public Rank GetRank()
        { // start of GetRank
            return Rank;
        } // end of GetRank

        public double GetTotalMoneyPaid()
        { // start of GetTotalMoneyPaid
            return TotalMoneyPaid;
        } // end of GetTotalMoneyPaid

    } // end of class Taxi

} // end of namespace
