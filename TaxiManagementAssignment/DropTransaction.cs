using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{ // start of namespace
    public class DropTransaction : Transaction
    { // start of class DropTransaction
        public int taxiNum { get; set; }
        public bool priceWasPaid { get; set; }

        public DropTransaction(DateTime transactionDatetime, int taxinum, bool pricewaspaid) : base("Drop fare", transactionDatetime)
        { // start of DropTransaction
            taxiNum = taxinum;
            priceWasPaid = pricewaspaid;
        } // end of DropTransaction

        public override string ToString()
        {
            string dateStr = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            if (priceWasPaid == true)
            {
                return ($"{dateStr} Drop fare - Taxi {taxiNum}, price was paid");
            }
            else
            {
                return ($"{dateStr} Drop fare - Taxi {taxiNum}, price was not paid");
            }
        }

    } // end of class DropTransaction
} // end of namespace