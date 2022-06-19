using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{ // start of namespace
    public class TaxiManager
    { // start of class TaxiManager
        public SortedDictionary<int, Taxi> taxis = new SortedDictionary<int, Taxi>();

        public Taxi CreateTaxi(int taxiNum)
        {
            Taxi x = new Taxi(taxiNum);
            //int Number = taxiNum;
            if (taxis.GetValueOrDefault(taxiNum) == default) {
                taxis.Add(taxiNum, x);
            }
            else {
                return taxis.GetValueOrDefault(taxiNum);
            }
            return x;
        }

        public Taxi FindTaxi(int taxiNum)
        {
            if(taxis.GetValueOrDefault(taxiNum) == default) {
                return null;
            }
            else {
                return taxis.GetValueOrDefault(taxiNum);
            }
        }

        public SortedDictionary<int, Taxi> GetAllTaxis()
        {
            return taxis;
        }

    } // end of class TaxiManager
} // end of namespace
