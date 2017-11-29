using System;
using System.Collections.Generic;

namespace BlockchainAnalysisTool.Models
{
    public partial class WalletId
    {
        public int Wid { get; set; }
        public int NumberOfAddresses { get; set; }
        public int NumberOfTransactions { get; set; }
        public int? Priority { get; set; }
        public double? Balance { get; set; }
    }
}
