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

        // Static list of all wallets ever seen; will evolve into a database
        public static List<WalletID> MASTER_LIST = new List<WalletID>();

        // The blockExplorer used to access information from blockchain.info
        private static BlockExplorer blockExplorer { get; } = new BlockExplorer();

        // All addresses known to belong to this wallet
        private List<Address> walletAddresses { get; set; }                          // TODO: fix scope, create getters, setters ?

        // All wallets known to be related to this wallet
        public List<WalletID> relatedWallets { get; }
        
        //Variable that determines the parinee pranking a car individual wallet
        // Floats are slightly less precise then double but rqqory and execution


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

            //update(); //update information on all addresses

            addWallet(this); //Add to master list

        }



        //* WalletID
        // * 
        // * Overload for construtor that takes a single Address 
        // */
        public WalletID(string initAddress) : this(new List<string>() { initAddress })
        {
            
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
                //Try to find the address in the list
                var find = walletAddresses.Find(x => x.Base58Check == singleAddress.Base58Check);
                if (find == null)
                {
                    //Add address if we can't find it
                    walletAddresses.Add(singleAddress);
                }
            }
        }



        /* getAddresses():
         * 
         * gets the list of addresses for this wallet
         */
        public List<Address> getAddresses()
        {
            return walletAddresses;
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



        /* hasAddress()
         * 
         * Simple method that check if this wallet contains a given address
         * 
         * return: true if it contains it, false otherwise
         */
        public bool hasAddress(Address checkAddress)
        {
            var check = walletAddresses.Find(x => x.Base58Check == checkAddress.Base58Check);
            if (check == null)
            {
                return false;
            }
            return true;
        }




        //TODO: Handle duplicates in related addresses (same address from multiple transactions)
        //TODO: Handle outputs as well as inputs

        /* update
         * 
         * Search the transactions of a given address to find related addresses and
         *  group these by WalletID.
         * 
         */
        public void update() 
        {
            var retList = new List<WalletID>();
            var commonAddresses = new List<Address>();

            // update everything with blockchain.info
            List<Address> newList = new List<Address>();
            foreach (Address address in walletAddresses)
            {
                newList.Add(blockExplorer.GetBase58AddressAsync(address.Base58Check).Result);
            }
            walletAddresses = newList;
            

            foreach (Address indexAddresses in walletAddresses)
            {
                foreach (Transaction trans in indexAddresses.Transactions)
                {
                    ////sum output values to get ammount                  // THIS IS NOT USED YET
                    //decimal ammount = 0; 
                    //foreach (var output in trans.Outputs)
                    //{
                    //    ammount += output.Value.Bits;
                    //}

                    // get all output addresses
                    var outAdds = new List<Address>();
                    foreach (var output in trans.Outputs)
                    {
                        outAdds.Add(blockExplorer.GetBase58AddressAsync(output.Address).Result);
                    }

                    // get all input addresses
                    var inAdds = new List<Address>();
                    foreach (var input in trans.Inputs)
                    {
                        inAdds.Add(blockExplorer.GetBase58AddressAsync(input.PreviousOutput.Address).Result);
                    }

                    // Find out which side is this wallet on
                    bool isOutgoing = false;
                    foreach (Address output in outAdds)
                    {
                        if (hasAddress(output))
                        {
                            isOutgoing = true;
                            break;
                        }
                    }


                    //List<Address> otherGuysAddresses = new List<Address>();
                    //if (isOutgoing)
                    //{
                    //    addAddresses(outAdds);
                    //    otherGuysAddresses = inAdds;
                    //}
                    //else
                    //{
                    //    addAddresses(inAdds);
                    //    otherGuysAddresses = outAdds;

                    //}


                    //////////  Now refresh the MASTER LIST
                    //var bbreak = false;
                    //foreach (Address add in otherGuysAddresses)
                    //{
                    //    foreach (WalletID wallet in MASTER_LIST)
                    //    {
                    //        if (wallet.hasAddress(add))
                    //        {
                    //            wallet.addAddresses(otherGuysAddresses);
                    //            bbreak = true;
                    //            break;
                    //        }
                    //    }
                    //    if (bbreak) break;
                    //}


                    /////// Still need to refresh related wallets


                    if (isOutgoing)
                    {
                        var strings = new List<string>();
                        foreach (var x in outAdds)
                        {
                            strings.Add(x.Base58Check);

                        }
                        relatedWallets.Add(new WalletID(strings));

                    }
                    else
                    {
                        var strings = new List<string>();
                        foreach (var x in inAdds)
                        {
                            strings.Add(x.Base58Check);

                        }
                        relatedWallets.Add(new WalletID(strings));
                    }



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
        public static WalletID getWallet(Address address)
        {

                foreach (WalletID wallet in MASTER_LIST)
                {
                    if (wallet.hasAddress(address))
                    {
                        return wallet;
                    }
                }

            return null;
        }



        /* getWallet():
         * 
         * Overload for getWallet that takes a string
         */
        public static WalletID getWallet(string address)
        {
            return getWallet(blockExplorer.GetBase58AddressAsync(address).Result);
        }



        /* addWallet():
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



        /* walletsShareAddress():
         * 
         * Given two wallets, checks to see if the wallets share any addresses
         */
        public static bool walletsShareAddress(WalletID checkWallet, WalletID wallet)
        {
            foreach (Address address in checkWallet.walletAddresses)
            {
                if (wallet.hasAddress(address))
                {
                    return true;
                }
            }
            return false;
        }


        /* isNewAddress():
         * 
         * Given a bitcoin address, checks to see if the address has been seen 
         * by this system before
         * 
         * return: True if the address has never been seen
         *          False if the address is found
         */
        public static bool isNewAddress(Address checkAddress)
        {
            if (MASTER_LIST.Count == 0)
            {
                return true;
            }

            foreach (WalletID wallet in MASTER_LIST)
            {
                if (wallet.hasAddress(checkAddress))
                {
                    return false;
                }
            }

            return true;
        }


        /* isNewAddress():
         * 
         * Overload that takes a string for use in Index.cshtml
         */
         public static bool? isNewAddress(string checkAddress)
        {
            if (checkAddress == null)
            {
                return null;
            }

            return isNewAddress(blockExplorer.GetBase58AddressAsync(checkAddress).Result);
        }


    }
}
