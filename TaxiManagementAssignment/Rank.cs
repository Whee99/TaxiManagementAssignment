using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{ // start of namespace

    public class Rank
    { // start of class Rank

        public int Id;
        public int numberOfTaxiSpaces;
        public List<Taxi> TaxiSpace;

        public Rank(int rankid, int numoftaxispaces)
        { // start of Rank
            Id = rankid;
            numberOfTaxiSpaces = numoftaxispaces;
            TaxiSpace = new List<Taxi>(numberOfTaxiSpaces);
        } // end of Rank

        public bool AddTaxi(Taxi t)
        { // start of AddTaxi
            if (TaxiSpace.Count == numberOfTaxiSpaces) {
                return false;
            }
            else {
                t.Rank = this;
                TaxiSpace.Add(t);
                return true;
            }
        } // end of AddTaxi

        public Taxi FrontTaxiTakesFare(string destination, double agreedPrice)
        { // start of FrontTaxiTakesFare
            if (TaxiSpace.Count == 0) {
                return null;
            }
            else {
                Taxi t = TaxiSpace[0];
                t.AddFare(destination, agreedPrice);
                TaxiSpace.RemoveAt(0);
                return t;
            }
        } // end of FrontTaxiTakesFare

    } // end of class Rank

} // end of namespace
