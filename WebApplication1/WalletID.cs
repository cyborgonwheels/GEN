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


        public static List<WalletID> MASTER_LIST;

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
                var singleAddress = blockExplorer.GetBase58AddressAsync(add).Result;

                try
                {
                    //Try to find the address in the list
                    walletAddresses.Find(x => x.Base58Check == singleAddress.Base58Check);
                }
                catch
                {
                    //Add address if we can't find it
                    walletAddresses.Add(singleAddress);
                }


            }
        }


        //TODO: Handle duplicates in related addresses (same address from multiple transactions)
        //TODO: Handle outputs as well as inputs
        public List<Address> getRelatedAddresses(Address address)
        {
            address.TransactionCount.ToString();
            List<Address> retList = new List<Address>();

            foreach (Transaction trans in address.Transactions)
            {
                foreach (Input input in trans.Inputs)
                {
                    retList.Add(blockExplorer.GetBase58AddressAsync(input.PreviousOutput.Address).Result);
                }
            }


            return retList;
        }


        // Overload for getRelatedAddresses that takes a string
        public List<Address> getRelatedAddresses(string addressString)
        {
            var address = blockExplorer.GetBase58AddressAsync(addressString).Result;

            return getRelatedAddresses(address);
        }
        
       
    }
}
