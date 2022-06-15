using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{ // start of namespace
    public class TaxiManager
    { // start of class TaxiManager
        public SortedDictionary<int, Taxi> taxis = new SortedDictionary<int, Taxi>();

        //public Taxi CreateTaxi(int taxiNum)
        //{

        //}

        public Taxi FindTaxi(int taxiNum)
        {
            return taxis.GetValueOrDefault(taxiNum);
        }

        public SortedDictionary<int, Taxi> GetAllTaxis()
        {
            return taxis;
        }

    } // end of class TaxiManager
} // end of namespace
