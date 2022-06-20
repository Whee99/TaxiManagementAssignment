using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{ // start of namespace
    public class TransactionManager
    { // start of class TransactionManager
        public List<Transaction> transactions = new List<Transaction>();

        public List<Transaction> GetAllTransactions()
        { // start of GetAllTransactions
            return transactions;
        } // end of GetAllTransactions

        public void RecordJoin(int taxiNum, int rankId)
        { // start of RecordJoin
            Transaction j = new JoinTransaction(DateTime.Now, taxiNum, rankId);
            transactions.Add(j);
        } // end of RecordJoin

        public void RecordLeave(int rankId, Taxi t)
        { // start of RecordLeave
            Transaction l = new LeaveTransaction(DateTime.Now, rankId, t);
            transactions.Add(l);
        } // end of RecordLeave

        public void RecordDrop(int taxiNum, bool pricePaid)
        { // start of RecordDrop
            Transaction d = new DropTransaction(DateTime.Now, taxiNum, pricePaid);
            transactions.Add(d);
        } // end of RecordDrop

    } // end of class TransactionManager
} // end of namespace
