using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{ // start of namespace
    public class UserUI
    { // start of class UserUI
        public RankManager rankMgr;
        public TaxiManager taxiMgr;
        public TransactionManager transactionMgr;

        public int taxinum; // Need to ask if this is allowed
        public int rankid; // Need to ask if this is allowed

        public UserUI(RankManager rkMgr, TaxiManager txMgr, TransactionManager trMgr)
        { // start of UserUI
            rankMgr = rkMgr;
            taxiMgr = txMgr;
            transactionMgr = trMgr;
        } // end of UserUI

        public List<string> TaxiJoinsRank (int taxiNum, int rankId)
        { // start of TaxiJoinsRank
            taxinum = taxiNum;
            List<string> joinLog = new List<string>();
            Taxi t = taxiMgr.CreateTaxi(taxiNum);
            //rankMgr.AddTaxiToRank(t, rankId);
            if (rankMgr.AddTaxiToRank(t, rankId) == false) {
                joinLog.Add($"Taxi {taxiNum} has not joined rank {rankId}.");
            }
            else {
                joinLog.Add($"Taxi {taxiNum} has joined rank {rankId}.");
                transactionMgr.RecordJoin(taxiNum, rankId);
            }
            return joinLog;
        } // end of TaxiJoinsRank

        public List<string> TaxiLeavesRank (int rankId, string destination, double agreedPrice)
        { // start of TaxiLeavesRank
            List <string> leaveLog = new List<string>();
            Taxi t = taxiMgr.FindTaxi(taxinum);
            if (rankMgr.FrontTaxiInRankTakesFare(rankId, destination, agreedPrice) != null) {
                transactionMgr.RecordLeave(rankId, t);
                leaveLog.Add($"Taxi {taxinum} has left rank {rankId} to take a fare to {destination} for £{agreedPrice}.");
            }
            else {
                leaveLog.Add($"Taxi has not left rank {rankId}.");
            }
            return leaveLog;
        } // end of TaxiLeavesRank

        public List<string> TaxiDropsFare (int taxiNum, bool pricePaid)
        { // start of TaxiDropsFare
            Taxi t = new Taxi(taxiNum);
            List<string> dropLog = new List<string>();
            t.DropFare(pricePaid);
            if (pricePaid == true) {
                transactionMgr.RecordDrop(taxiNum, pricePaid);
                dropLog.Add($"Taxi {taxiNum} has dropped its fare and the price was paid.");
            }
            else if (pricePaid == false) {
                dropLog.Add($"Taxi {taxiNum} has not dropped its fare.");
            }
            else if (t.GetTotalMoneyPaid() == 0) {
                dropLog.Add($"Taxi {taxiNum} has dropped its fare and the price was not paid.");
            }
            return dropLog;
        } // end of TaxiDropsFare

    } // end of class UserUI
} // end of namespace
