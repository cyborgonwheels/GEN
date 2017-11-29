using System;
using System.Collections.Generic;

namespace BlockchainAnalysisTool.Models
{
    public partial class Trans
    {
        public int Tid { get; set; }
        public int? NumberOfInputs { get; set; }
        public int? NumberOfOutputs { get; set; }
        public double? AmountSent { get; set; }
        public int? FromWallet { get; set; }
        public int? ToWallet { get; set; }
    }
}
