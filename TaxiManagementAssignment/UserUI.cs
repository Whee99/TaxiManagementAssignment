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

        public int taxinum;
        public int rankid;

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
            transactionMgr.RecordLeave(rankId, t);
            return leaveLog;
        } // end of TaxiLeavesRank

    } // end of class UserUI
} // end of namespace
