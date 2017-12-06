using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainCapstoneWebApp;
using BlockchainAnalysisTool;
using System.Collections.Generic;
using BlockchainAnalysisTool.Models;

namespace BlockchainAnalysisToolTest
{

    // Each test method that you want Test Explorer to run must have the [TestMethod]attribute
    [TestClass]
    public class SortTest
    {
        // Given a blank database, everything is equivalent
        [TestMethod]
        public void TestMethod1()
        {

            //List<string> addressStrings = null;
            //Sort scumbag1 = new Sort(addressStrings);


            //addressStrings.Add("19TBERtSZYw4V6mXbHpczBgQCYH5MzfM7o");
            //Assert.AreEqual(scumbag1,  scumbag1, "failed to identify a wallet for the scumbag");
            //addressStrings.Remove("19TBERtSZYw4V6mXbHpczBgQCYH5MzfM7o");
            //Assert.AreEqual(scumbag1, null, "the scumbag should have no wallet");

        }


        // CRUD Test for Wallet Model
        [TestMethod]
        public void WalletTest()
        {
            // Create new Wallet

            int initWid = 6541;
            int? initNumAdd = 6846;
            int? initNumTrans = 1838;
            double? initPriority = 861.868;
            double? initBalance = 654.654;

            Wallet wallet = new Wallet
            {
                Wid = initWid,
                NumberOfAddresses = initNumAdd,
                NumberOfTransactions = initNumTrans,
                Priority = initPriority,
                Balance = initBalance
            };


            // Read from Wallet

            Assert.AreEqual(initWid, wallet.Wid);
            Assert.AreEqual(initNumAdd, wallet.NumberOfAddresses);
            Assert.AreEqual(initNumTrans, wallet.NumberOfTransactions);
            Assert.AreEqual(initPriority, wallet.Priority);
            Assert.AreEqual(initBalance, wallet.Balance);


            // Update Wallet

            int newWid = 763;
            int? newNumAdd = 1124;
            int? newNumTrans = 7995;
            double? newPriority = 122.188;
            double? newBalance = 799.511;

            wallet.Wid = newWid;
            wallet.NumberOfAddresses = newNumAdd;
            wallet.NumberOfTransactions = newNumTrans;
            wallet.Priority = newPriority;
            wallet.Balance = newBalance; // haha newBalance :P

            Assert.AreEqual(newWid, wallet.Wid);
            Assert.AreEqual(newNumAdd, wallet.NumberOfAddresses);
            Assert.AreEqual(newNumTrans, wallet.NumberOfTransactions);
            Assert.AreEqual(newPriority, wallet.Priority);
            Assert.AreEqual(newBalance, wallet.Balance);


            // Delete values

            wallet.NumberOfAddresses = null;
            wallet.NumberOfTransactions = null;
            wallet.Priority = null;
            wallet.Balance = null;

            Assert.AreEqual(newWid, wallet.Wid);
            Assert.AreEqual(null, wallet.NumberOfAddresses);
            Assert.AreEqual(null, wallet.NumberOfTransactions);
            Assert.AreEqual(null, wallet.Priority);
            Assert.AreEqual(null, wallet.Balance);

        }



        // CRUD Test for Wallet Model
        [TestMethod]
        public void AddrTest()
        {
            // Create new Wallet

            string initAid = "hfduiaoiudshf";
            int initParentWallet = 14896845;
            double? initAmountSent = 1684.15544;
            double? initAmountReceived = 4489.2244;
            string initLastSentTo = "djfuiuhsdfa";
            string initLastReceivedFrom = "dfaiuvgiog";

            Addr addr = new Addr
            {
                Aid = initAid,
                ParentWallet = initParentWallet,
                AmountSent = initAmountSent,
                AmountReceived = initAmountReceived,
                LastSentTo = initLastSentTo,
                LastReceivedFrom = initLastReceivedFrom
            };


            // Read from Wallet

            Assert.AreEqual(initAid, addr.Aid);
            Assert.AreEqual(initParentWallet, addr.ParentWallet);
            Assert.AreEqual(initAmountSent, addr.AmountSent);
            Assert.AreEqual(initAmountReceived, addr.AmountReceived);
            Assert.AreEqual(initLastSentTo, addr.LastSentTo);
            Assert.AreEqual(initLastReceivedFrom, addr.LastReceivedFrom);


            // Update Wallet

            string newAid = "yubiusiuy3";
            int newParentWallet = 778416;
            double? newAmountSent = 168.188;
            double? newAmountReceived = 9411.244;
            string newLastSentTo = "qoiuybvcxoi";
            string newLastReceivedFrom = "breitiyuyb";

            addr.Aid = newAid;
            addr.ParentWallet = newParentWallet;
            addr.AmountSent = newAmountSent;
            addr.AmountReceived = newAmountReceived;
            addr.LastSentTo = newLastSentTo;
            addr.LastReceivedFrom = newLastReceivedFrom;

            Assert.AreEqual(newAid, addr.Aid);
            Assert.AreEqual(newParentWallet, addr.ParentWallet);
            Assert.AreEqual(newAmountSent, addr.AmountSent);
            Assert.AreEqual(newAmountReceived, addr.AmountReceived);
            Assert.AreEqual(newLastSentTo, addr.LastSentTo);
            Assert.AreEqual(newLastReceivedFrom, addr.LastReceivedFrom);


            // Delete values

            addr.AmountSent = null;
            addr.AmountReceived = null;

            Assert.AreEqual(null, addr.AmountSent);
            Assert.AreEqual(null, addr.AmountReceived);

        }


        // CRUD Test for Wallet Model
        [TestMethod]
        public void TransTest()
        {
            // Create new Wallet

            int initWid = 6541;
            int? initNumAdd = 6846;
            int? initNumTrans = 1838;
            double? initPriority = 861.868;
            double? initBalance = 654.654;

            Wallet wallet = new Wallet
            {
                Wid = initWid,
                NumberOfAddresses = initNumAdd,
                NumberOfTransactions = initNumTrans,
                Priority = initPriority,
                Balance = initBalance
            };


            // Read from Wallet

            Assert.AreEqual(initWid, wallet.Wid);
            Assert.AreEqual(initNumAdd, wallet.NumberOfAddresses);
            Assert.AreEqual(initNumTrans, wallet.NumberOfTransactions);
            Assert.AreEqual(initPriority, wallet.Priority);
            Assert.AreEqual(initBalance, wallet.Balance);


            // Update Wallet

            int newWid = 763;
            int? newNumAdd = 1124;
            int? newNumTrans = 7995;
            double? newPriority = 122.188;
            double? newBalance = 799.511;

            wallet.Wid = newWid;
            wallet.NumberOfAddresses = newNumAdd;
            wallet.NumberOfTransactions = newNumTrans;
            wallet.Priority = newPriority;
            wallet.Balance = newBalance; // haha newBalance :P

            Assert.AreEqual(newWid, wallet.Wid);
            Assert.AreEqual(newNumAdd, wallet.NumberOfAddresses);
            Assert.AreEqual(newNumTrans, wallet.NumberOfTransactions);
            Assert.AreEqual(newPriority, wallet.Priority);
            Assert.AreEqual(newBalance, wallet.Balance);


            // Delete values

            wallet.NumberOfAddresses = null;
            wallet.NumberOfTransactions = null;
            wallet.Priority = null;
            wallet.Balance = null;

            Assert.AreEqual(newWid, wallet.Wid);
            Assert.AreEqual(null, wallet.NumberOfAddresses);
            Assert.AreEqual(null, wallet.NumberOfTransactions);
            Assert.AreEqual(null, wallet.Priority);
            Assert.AreEqual(null, wallet.Balance);

        }


        // CRUD Test for Wallet Model
        [TestMethod]
        public void InputTest()
        {
            // Create new Wallet

            int initWid = 6541;
            int? initNumAdd = 6846;
            int? initNumTrans = 1838;
            double? initPriority = 861.868;
            double? initBalance = 654.654;

            Wallet wallet = new Wallet
            {
                Wid = initWid,
                NumberOfAddresses = initNumAdd,
                NumberOfTransactions = initNumTrans,
                Priority = initPriority,
                Balance = initBalance
            };


            // Read from Wallet

            Assert.AreEqual(initWid, wallet.Wid);
            Assert.AreEqual(initNumAdd, wallet.NumberOfAddresses);
            Assert.AreEqual(initNumTrans, wallet.NumberOfTransactions);
            Assert.AreEqual(initPriority, wallet.Priority);
            Assert.AreEqual(initBalance, wallet.Balance);


            // Update Wallet

            int newWid = 763;
            int? newNumAdd = 1124;
            int? newNumTrans = 7995;
            double? newPriority = 122.188;
            double? newBalance = 799.511;

            wallet.Wid = newWid;
            wallet.NumberOfAddresses = newNumAdd;
            wallet.NumberOfTransactions = newNumTrans;
            wallet.Priority = newPriority;
            wallet.Balance = newBalance; // haha newBalance :P

            Assert.AreEqual(newWid, wallet.Wid);
            Assert.AreEqual(newNumAdd, wallet.NumberOfAddresses);
            Assert.AreEqual(newNumTrans, wallet.NumberOfTransactions);
            Assert.AreEqual(newPriority, wallet.Priority);
            Assert.AreEqual(newBalance, wallet.Balance);


            // Delete values

            wallet.NumberOfAddresses = null;
            wallet.NumberOfTransactions = null;
            wallet.Priority = null;
            wallet.Balance = null;

            Assert.AreEqual(newWid, wallet.Wid);
            Assert.AreEqual(null, wallet.NumberOfAddresses);
            Assert.AreEqual(null, wallet.NumberOfTransactions);
            Assert.AreEqual(null, wallet.Priority);
            Assert.AreEqual(null, wallet.Balance);

        }


        // CRUD Test for Wallet Model
        [TestMethod]
        public void OutputTest()
        {
            // Create new Wallet

            int initWid = 6541;
            int? initNumAdd = 6846;
            int? initNumTrans = 1838;
            double? initPriority = 861.868;
            double? initBalance = 654.654;

            Wallet wallet = new Wallet
            {
                Wid = initWid,
                NumberOfAddresses = initNumAdd,
                NumberOfTransactions = initNumTrans,
                Priority = initPriority,
                Balance = initBalance
            };


            // Read from Wallet

            Assert.AreEqual(initWid, wallet.Wid);
            Assert.AreEqual(initNumAdd, wallet.NumberOfAddresses);
            Assert.AreEqual(initNumTrans, wallet.NumberOfTransactions);
            Assert.AreEqual(initPriority, wallet.Priority);
            Assert.AreEqual(initBalance, wallet.Balance);


            // Update Wallet

            int newWid = 763;
            int? newNumAdd = 1124;
            int? newNumTrans = 7995;
            double? newPriority = 122.188;
            double? newBalance = 799.511;

            wallet.Wid = newWid;
            wallet.NumberOfAddresses = newNumAdd;
            wallet.NumberOfTransactions = newNumTrans;
            wallet.Priority = newPriority;
            wallet.Balance = newBalance; // haha newBalance :P

            Assert.AreEqual(newWid, wallet.Wid);
            Assert.AreEqual(newNumAdd, wallet.NumberOfAddresses);
            Assert.AreEqual(newNumTrans, wallet.NumberOfTransactions);
            Assert.AreEqual(newPriority, wallet.Priority);
            Assert.AreEqual(newBalance, wallet.Balance);


            // Delete values

            wallet.NumberOfAddresses = null;
            wallet.NumberOfTransactions = null;
            wallet.Priority = null;
            wallet.Balance = null;

            Assert.AreEqual(newWid, wallet.Wid);
            Assert.AreEqual(null, wallet.NumberOfAddresses);
            Assert.AreEqual(null, wallet.NumberOfTransactions);
            Assert.AreEqual(null, wallet.Priority);
            Assert.AreEqual(null, wallet.Balance);

        }
    }
}
