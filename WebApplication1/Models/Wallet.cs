using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockchainAnalysisTool.Models
{
    public class Wallet
    {
        public int walletIndex { get; set; }
        public int numAddresses { get; set; }
        public int numTransactions { get; set; }
        public float priorityNum { get; set; }
        public double balance { get; set; }
        public List<String> walletAddresses { get; set; }
    }
}
