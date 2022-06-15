using System;
namespace TaxiManagementAssignment
{ // start of namespace
    public class JoinTransaction : Transaction
    { // start of class JoinTransaction
        public int taxiNum { get; set; }
        public int rankId { get; set; }

        public JoinTransaction(DateTime transactionDatetype, int taxinum, int rankid) : base("Join", transactionDatetype)
        { // start of JoinTransaction
            taxiNum = taxinum;
            rankId = rankid;
        } // end of JoinTransaction

        public override string ToString()
        {
            string dateStr = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return ($"{dateStr} Join      - Taxi {taxiNum} in rank {rankId}");
        }
    } // end of class JoinTransaction
} // end of namespace