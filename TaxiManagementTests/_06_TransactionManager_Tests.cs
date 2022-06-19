using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiManagementAssignment;

// Line 6 and 7 are added: Confirmation Pending...
// Line 15 is altered: Originally "class _06_TransactionManager_Tests" and no[TestClass] present

namespace TaxiManagementTests
{
    [TestClass]
    public class _06_TransactionManager_Tests
    {
        /*
         * Uncomment from line 13
         */

        [TestMethod]
        public void _01_RecordJoinCreatesJoinTransaction()
        {
            TransactionManager tm = new TransactionManager();
            tm.RecordJoin(1, 1);
            Assert.AreEqual("JoinTransaction", tm.GetAllTransactions()[0].GetType().Name);
        }

        [TestMethod]
        public void _02_RecordLeaveCreatesLeaveTransaction()
        {
            TransactionManager tm = new TransactionManager();
            tm.RecordLeave(1, new Taxi(1));
            Assert.AreEqual("LeaveTransaction", tm.GetAllTransactions()[0].GetType().Name);
        }

        [TestMethod]
        public void _03_RecordDropCreatesDropTransaction()
        {
            TransactionManager tm = new TransactionManager();
            tm.RecordDrop(1, true);
            Assert.AreEqual("DropTransaction", tm.GetAllTransactions()[0].GetType().Name);
        }
    }
}
