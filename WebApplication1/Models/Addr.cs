using System;
using System.Collections.Generic;

namespace BlockchainAnalysisTool.Models
{
    public partial class Addr
    {
        public int Aid { get; set; }
        public int? ParentWallet { get; set; }
        public double? AmountSent { get; set; }
        public double? AmountReceived { get; set; }
        public string LastSentTo { get; set; }
        public string LastSentFrom { get; set; }
    }
}
