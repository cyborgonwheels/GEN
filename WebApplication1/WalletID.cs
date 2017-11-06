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


        public static List<WalletID> MASTER_LIST = new List<WalletID>();

        private static BlockExplorer blockExplorer { get; } = new BlockExplorer();
        public List<Address> walletAddresses { get; }
        public List<WalletID> relatedWallets { get; }
        

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

            relatedWallets = new List<WalletID>();
            //adds each new wallet to the master list, chekcing with the addwallet function
            foreach(Address ad in walletAddresses)
            {
                WalletID walletToAdd = getWallet(ad);
                if(addWallet(walletToAdd) == true)
                {
                    MASTER_LIST.Add(walletToAdd);
                }
            }

            //TODO: Add all related addresses using below function

        }


        /* WalletID
         * 
         * Overload for construtor that takes a list of Address objects directly
         */
        public WalletID(List<Address> initAddresses)
        {
            //Currently client not used, may not be needed:
            BlockchainHttpClient client = new BlockchainHttpClient(apiCode: "48461d4b-9e26-43c0-bbe7-875075a6f751");

            walletAddresses = initAddresses;

            relatedWallets = new List<WalletID>();
            
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


                //This try catch does not do what is intended, this should check for a null return from the Find() call
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

        /* findRelatedWallets
         * 
         * Search the transactions of a given address to find related addresses and
         *  group these by WalletID.
         * 
         */
        public void updateRelatedWallets() //May not need to return anything?
        {
            var retList = new List<WalletID>();
            var commonAddresses = new List<Address>();

            foreach (Address address in walletAddresses)
            {
                foreach (Transaction trans in address.Transactions)
                {
                    //sum output values to get ammount
                    decimal ammount = 0; 
                    foreach (var output in trans.Outputs)
                    {
                        ammount += output.Value.Bits;
                    }

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
            
            
            
        }


        /*************************************************************************
                             Public Static Helpers
        *************************************************************************/
        


        /* getWallet()
         * 
         * Find the wallet that contains the given address, from the master list.
         * Return null if it is not found
         */
        public static WalletID getWallet(string addString)
        {

            foreach (WalletID wallet in MASTER_LIST)
            {
                if (null != wallet.walletAddresses.Find(x => x.Base58Check == addString))
                {
                    return wallet;
                }
            }

            return null;
        }

        /* getWallet()
         * 
         * Overload for getWallet that takes an address instead of a string
         */
        public static WalletID getWallet(Address address)
        {
            string addString = address.Base58Check;

            return getWallet(addString);
        }


        /* addWallet
         * 
         * Attempts to add given wallet to the master list
         * Return true if successful, false otherwise
         */
        public static bool addWallet(WalletID checkWallet)
        {

            foreach (WalletID wallet in MASTER_LIST)
            {
                if (walletsShareAddress(checkWallet, wallet) == true)
                {
                    return false;
                }
            }

            MASTER_LIST.Add(checkWallet);
            return true;    
        }

        /*
         * Given a wallet, checks to see if the wallet is already in the master list
         * returns true if the wallet is not already in the master list
         */
        public static Boolean walletsShareAddress(WalletID checkWallet, WalletID wallet)
        {
            foreach (Address address in checkWallet.walletAddresses)
            {
                if (null != wallet.walletAddresses.Find(x => x.Base58Check == address.Base58Check))
                {
                    return true;
                }
            }
            return false;
        }




    }
}
