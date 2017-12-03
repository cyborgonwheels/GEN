using System;
using System.Collections.Generic;

namespace BlockchainAnalysisTool.Models
{
    public partial class Wallet
    {
        public int Wid { get; set; }
        public int? NumberOfAddresses { get; set; }
        public int? NumberOfTransactions { get; set; }
        public double? Priority { get; set; }
        public double? Balance { get; set; }
    }
}
