using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainCapstoneWebApp;
using BlockchainAnalysisTool;
using System.Collections.Generic;

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

            List<string> addressStrings = null;
            Sort scumbag1 = new Sort(addressStrings);

            
            addressStrings.Add("19TBERtSZYw4V6mXbHpczBgQCYH5MzfM7o");
            Assert.AreEqual(scumbag1,  scumbag1, "failed to identify a wallet for the scumbag");
            addressStrings.Remove("19TBERtSZYw4V6mXbHpczBgQCYH5MzfM7o");
            Assert.AreEqual(scumbag1, null, "the scumbag should have no wallet");
            
        }

    }
}
