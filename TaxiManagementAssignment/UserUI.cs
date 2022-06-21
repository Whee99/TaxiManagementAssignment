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

        //public int taxinum; // Need to ask if this is allowed

        public UserUI(RankManager rkMgr, TaxiManager txMgr, TransactionManager trMgr)
        { // start of UserUI
            rankMgr = rkMgr;
            taxiMgr = txMgr;
            transactionMgr = trMgr;
        } // end of UserUI

        public List<string> TaxiJoinsRank (int taxiNum, int rankId)
        { // start of TaxiJoinsRank
            //taxinum = taxiNum;
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
            //Taxi t = rankMgr.ranks[rankId].TaxiSpace[0];
            //Taxi t = taxiMgr.FindTaxi(taxinum);

            Taxi t = rankMgr.FrontTaxiInRankTakesFare(rankId, destination, agreedPrice);

            if (t != null) {
                transactionMgr.RecordLeave(rankId, t);
                leaveLog.Add($"Taxi {t.Number} has left rank {rankId} to take a fare to {destination} for £{agreedPrice}.");
                //taxiMgr.taxis.Remove(t.Number);
            }
            else {
                leaveLog.Add($"Taxi has not left rank {rankId}.");
            }

            return leaveLog;
        } // end of TaxiLeavesRank

        public List<string> TaxiDropsFare (int taxiNum, bool pricePaid)
        { // start of TaxiDropsFare
            //Taxi t = taxiMgr.FindTaxi(taxinum);
            List<string> dropLog = new List<string>();
            Taxi t = taxiMgr.FindTaxi(taxiNum);
            t.DropFare(pricePaid);

            if (t.Location == "in rank") { 
                dropLog.Add($"Taxi {taxiNum} has not dropped its fare.");
            }
            else {
                if (pricePaid == true) {
                    transactionMgr.RecordDrop(taxiNum, pricePaid);
                    dropLog.Add($"Taxi {taxiNum} has dropped its fare and the price was paid.");
                }
                else {
                    dropLog.Add($"Taxi {taxiNum} has dropped its fare and the price was not paid.");
                }
            }

            return dropLog;
        } // end of TaxiDropsFare

        public List<string> ViewTaxiLocations()
        { // start of ViewTaxiLocations
            SortedDictionary<int,Taxi> listoftaxis = taxiMgr.GetAllTaxis();
            List<string> taxiLocations = new List<string>();

            taxiLocations.Add("Taxi locations");
            taxiLocations.Add("==============");
            if (listoftaxis.Count == 0) {
                taxiLocations.Add("No taxis");
            }
            else {
                foreach (Taxi t in listoftaxis.Values) {
                    //taxiLocations.Add($"Taxi {t.Number} is in rank {t.Rank.Id}");
                    if (t.Destination.Length > 0) {
                        taxiLocations.Add($"Taxi {t.Number} is on the road to {t.Destination}");
                    }
                    else if (t.Destination.Length == 0) {
                        //taxiLocations.Add($"Taxi {t.Number} is on the road");
                        if (t.Location == "on the road") {
                            taxiLocations.Add($"Taxi {t.Number} is on the road");
                        }
                        else {
                            taxiLocations.Add($"Taxi {t.Number} is in rank {t.Rank.Id}");
                        }
                    }
                    //else {
                    //    taxiLocations.Add($"Taxi {t.Number} is in rank {t.Rank.Id}");
                    //}
                }
            }

            return taxiLocations;
        } // end of ViewTaxiLocations

    } // end of class UserUI
} // end of namespace
