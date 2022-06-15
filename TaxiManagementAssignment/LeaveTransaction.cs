﻿
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{ // start of namespace
    public class LeaveTransaction : Transaction
    { // start of class LeaveTransaction
        public int taxiNum { get; set; }
        public int rankId { get; set; }
        public string Destination { get; set; }
        public double agreedPrice { get; set; }

        public LeaveTransaction(DateTime transactionDatetime, int rankid, Taxi t) : base("Leave", transactionDatetime)
        {
            rankId = rankid;
            taxiNum = t.Number;
        }

        public override string ToString()
        {
            string dateStr = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return ($"{dateStr} Leave     - Taxi 1 from rank 2 to {Destination} for £{agreedPrice}");
        }
    } // end of class LeaveTransaction
} // end of namespace
