using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Info.Blockchain.API.BlockExplorer;
using Info.Blockchain.API.Client;
using Info.Blockchain.API.Models;


namespace BlockchainAnalysisTool
{
    public class WalletID
    {
        private BlockExplorer blockExplorer { get; }
        protected List<Address> walletAddresses;
        

        public WalletID(string[] addressStrings)
        {
            //Currently client not used, may not be needed:
            BlockchainHttpClient client = new BlockchainHttpClient(apiCode: "48461d4b-9e26-43c0-bbe7-875075a6f751");

            blockExplorer = new BlockExplorer();
            walletAddresses = new List<Address>();

            foreach (string add in addressStrings)
            {
                walletAddresses.Add(blockExplorer.GetBase58AddressAsync(add, filter: FilterType.All).Result);
            }

            //TODO: Add all related addresses using below function

        }


        public void addAddresses(string[] addressStrings)
        {
            //TODO: fix

            foreach (string add in addressStrings)
            {
                var singleAddress = blockExplorer.GetBase58AddressAsync(add, filter: FilterType.All).Result;

                try
                {
                    walletAddresses.Find(x => x.Base58Check == singleAddress.Base58Check);
                }
                catch
                {
                    walletAddresses.Add(singleAddress);
                }


            }
        }
        

        //TODO: return list of Addresses instead of strings?
        public List<string> getRelatedAddresses(Address address)
        {
            address.TransactionCount.ToString();
            List<string> retList = new List<string>();

            foreach (Transaction trans in address.Transactions)
            {
                foreach (Input input in trans.Inputs)
                {
                    retList.Add(input.PreviousOutput.Address);
                }
            }


            return retList;
        }

        public List<string> getRelatedAddresses(string addressString)
        {
            var address = blockExplorer.GetBase58AddressAsync(addressString).Result;

            return getRelatedAddresses(address);
        }
        
       
    }
}
