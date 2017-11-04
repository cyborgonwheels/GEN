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

        private static BlockExplorer blockExplorer { get; } = new BlockExplorer();
        protected List<Address> walletAddresses { get; }
        protected List<WalletID> relatedWallets { get; }
        

        /* WalletID
         * 
         * Constructor that takes a list of strings. Each string must be a valid bitcoin address,
         *      and each is searched with the block explorer and added to the walletAddresses list
         *      for this wallet object.
         */
        public WalletID(List<string> addressStrings)
        {
            //Currently client not used, may not be needed:
            BlockchainHttpClient client = new BlockchainHttpClient(apiCode: "48461d4b-9e26-43c0-bbe7-875075a6f751");

            walletAddresses = new List<Address>();

            foreach (string add in addressStrings)
            {
                walletAddresses.Add(blockExplorer.GetBase58AddressAsync(add, filter: FilterType.All).Result);
            }

            //TODO: Add all related addresses using below function

        }


        /* WalletID
         * 
         * Overload for construtor that takes a list of Address objects directly
         */
        public WalletID(List<Address> initAddresses)
        {
            walletAddresses = initAddresses;
        }


        /* addAddresses()
         * 
         * addressStrings: list of string representations of addresses to add
         * 
         * add given addresses to this WalletID if they are not redunant
         */
        public void addAddresses(List<Address> addAddresses)
        {

            foreach (Address singleAddress in addAddresses)
            {
                //var singleAddress = blockExplorer.GetBase58AddressAsync(add).Result;

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


        /* getAddressStrings()
         * 
         * Get a list of string representations of all addresses for this WalletID to
         *      print to the web page.
         */
        public List<string> getAddressStrings()
        {
            var retList = new List<string>();

            foreach (Address address in walletAddresses)
            {
                retList.Add(address.Base58Check);
            }

            return retList;
        }



        //TODO: Handle duplicates in related addresses (same address from multiple transactions)
        //TODO: Handle outputs as well as inputs

        /* getRelatedWallets
         * 
         * Search the transactions of a given address to find related addresses and
         *  group these by WallerID.
         * 
         */
        public List<WalletID> findRelatedWallets() //May not need to return anything?
        {
            
            var retList = new List<WalletID>();

            foreach (Address address in walletAddresses)
            {
                foreach (Transaction trans in address.Transactions)
                {
                    //TODO: decide whether the transaction is incoming or outgoing
                    //TODO: address is new, create new wallet, else add to existing

                    var listOfAddresses = new List<Address>();

                    foreach (Input input in trans.Inputs)
                    {
                        listOfAddresses.Add(blockExplorer.GetBase58AddressAsync(input.PreviousOutput.Address).Result);
                    }

                    retList.Add(new WalletID(listOfAddresses));
                }
            }
            
            
            return retList;
        }




        /*************************************************************************
                             Public Static Helpers
        *************************************************************************/
        


        /* isInList()
         * 
         * Find out whether the given address has been seen before in the 
         *      MASTER_LIST and return an appropriate boolean
         */
        public static bool isInList(Address address)
        {
            return false;
        }



        
        
       
    }
}
