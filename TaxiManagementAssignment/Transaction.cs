using System;

namespace TaxiManagementAssignment
{ // start of namespace
    public abstract class Transaction
    { // start of class Transaction
        public DateTime TransactionDatetime { get; set; }
        public string TransactionType { get; set; }

        public Transaction(string type, DateTime dt)
        { // start of Transaction
            TransactionType = type;
            TransactionDatetime = dt;
        } // end of Transaction

    } // end of class Transaction
} // end of namespace