using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainCapstoneWebApp;
using BlockchainAnalysisTool;
using System.Collections.Generic;
using BlockchainAnalysisTool.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace BlockchainAnalysisToolTest
{

    // Each test method that you want Test Explorer to run must have the [TestMethod]attribute
    [TestClass]
    public class SortTest
    {
        // Interact with Database
        [TestMethod]
        public void TestMethod1()
        {
            //var x = new DbContextOptions<BlockchainContext>();
            //var context = new BlockchainContext(x);
            //var read = context.Wallet.SingleAsync(v => v.Wid == 1).Result.Balance;
            //Console.WriteLine(read);

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



        // CRUD Test for Address Model
        [TestMethod]
        public void AddrTest()
        {
            // Create new Address

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


            // Read from Address

            Assert.AreEqual(initAid, addr.Aid);
            Assert.AreEqual(initParentWallet, addr.ParentWallet);
            Assert.AreEqual(initAmountSent, addr.AmountSent);
            Assert.AreEqual(initAmountReceived, addr.AmountReceived);
            Assert.AreEqual(initLastSentTo, addr.LastSentTo);
            Assert.AreEqual(initLastReceivedFrom, addr.LastReceivedFrom);


            // Update Address

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


            // Delete values in Address

            addr.AmountSent = null;
            addr.AmountReceived = null;

            Assert.AreEqual(null, addr.AmountSent);
            Assert.AreEqual(null, addr.AmountReceived);

        }


        // CRUD Test for Transaction Model
        [TestMethod]
        public void TransTest()
        {
            // Create new Transaction

            int initTid = 15368748;
            int? initNumberOfInputs = 153584;
            int? initNumberOfOutputs = 49975;
            double? initAmountSent = 21.221;
            int initFromWallet = 489;
            int initToWallet = 77654;

            Trans trans = new Trans
            {
                Tid = initTid,
                NumberOfInputs = initNumberOfInputs,
                NumberOfOutputs = initNumberOfOutputs,
                AmountSent = initAmountSent,
                FromWallet = initFromWallet,
                ToWallet = initToWallet
            };


            // Read from Transaction

            Assert.AreEqual(trans.Tid, initTid);
            Assert.AreEqual(trans.NumberOfInputs, initNumberOfInputs);
            Assert.AreEqual(trans.NumberOfOutputs, initNumberOfOutputs);
            Assert.AreEqual(trans.AmountSent, initAmountSent);
            Assert.AreEqual(trans.FromWallet, initFromWallet);
            Assert.AreEqual(trans.ToWallet, initToWallet);


            // Update Transaction

            int newTid = 116798;
            int? newNumberOfInputs = 134;
            int? newNumberOfOutputs = 99421;
            double? newAmountSent = 9877.211;
            int newFromWallet = 6498;
            int newToWallet = 16477;

            trans.Tid = newTid;
            trans.NumberOfInputs = newNumberOfInputs;
            trans.NumberOfOutputs = newNumberOfOutputs;
            trans.AmountSent = newAmountSent;
            trans.FromWallet = newFromWallet;
            trans.ToWallet = newToWallet;

            Assert.AreEqual(trans.Tid, newTid);
            Assert.AreEqual(trans.NumberOfInputs, newNumberOfInputs);
            Assert.AreEqual(trans.NumberOfOutputs, newNumberOfOutputs);
            Assert.AreEqual(trans.AmountSent, newAmountSent);
            Assert.AreEqual(trans.FromWallet, newFromWallet);
            Assert.AreEqual(trans.ToWallet, newToWallet);


            // Delete values in Transaction

            trans.NumberOfInputs = null;
            trans.NumberOfOutputs = null;
            trans.AmountSent = null;

            Assert.AreEqual(null, trans.NumberOfInputs);
            Assert.AreEqual(null, trans.NumberOfOutputs);
            Assert.AreEqual(null, trans.AmountSent);

        }


        // CRUD Test for Input Model
        [TestMethod]
        public void InputTest()
        {
            // Create new Input

            string initAid = "vcistuy";
            int initTid = 16987;
            int initIndexIn = 41658;

            InputId input = new InputId
            {
                Aid = initAid,
                Tid = initTid,
                IndexIn = initIndexIn
            };


            // Read from Input

            Assert.AreEqual(initAid, input.Aid);
            Assert.AreEqual(initTid, input.Tid);
            Assert.AreEqual(initIndexIn, input.IndexIn);


            // Update Input

            string newAid = "oxiuvycb";
            int newTid = 98744;
            int newIndexIn = 349;

            input.Aid = newAid;
            input.Tid = newTid;
            input.IndexIn = newIndexIn;

            Assert.AreEqual(newAid, input.Aid);
            Assert.AreEqual(newTid, input.Tid);
            Assert.AreEqual(newIndexIn, input.IndexIn);

        }


        // CRUD Test for Output Model
        [TestMethod]
        public void OutputTest()
        {
            // Create new Output

            string initAid = "wbtmnre";
            int initTid = 395487;
            int initIndexOut = 8653;

            OutputId output = new OutputId
            {
                Aid = initAid,
                Tid = initTid,
                IndexOut = initIndexOut
            };


            // Read from Output

            Assert.AreEqual(initAid, output.Aid);
            Assert.AreEqual(initTid, output.Tid);
            Assert.AreEqual(initIndexOut, output.IndexOut);


            // Update Output

            string newAid = "xenvot";
            int newTid = 7835;
            int newIndexOut = 5924;

            output.Aid = newAid;
            output.Tid = newTid;
            output.IndexOut = newIndexOut;

            Assert.AreEqual(newAid, output.Aid);
            Assert.AreEqual(newTid, output.Tid);
            Assert.AreEqual(newIndexOut, output.IndexOut);

        }
    }
}
