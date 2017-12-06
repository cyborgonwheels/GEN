using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Info.Blockchain.API.BlockExplorer;
using Info.Blockchain.API.Client;
using Info.Blockchain.API.Models;
using BlockchainAnalysisTool.Models;


namespace BlockchainAnalysisTool
{
    public static class Sort
    {
        // The blockExplorer used to access information from blockchain.info
        private static BlockExplorer blockExplorer { get; } = new BlockExplorer();



        public static List<Wallet> getRelatedWallets(BlockchainContext context, String adrs)
        {
            //List<int> widList = new List<int>(); // List of wallets to pull from database

            //// Add the one parent wallet (maybe make this one special, use data dict)
            //var address = context.Addr.Single(x => x.Aid == adrs);
            //widList.Add(address.ParentWallet);

            //// Get all wallets sent to
            //var inTrans = context.Trans.Where(t => t.FromWallet == address.ParentWallet).ToList();
            //foreach (var trans in inTrans)
            //{
            //    widList.Add(trans.ToWallet);
            //}

            //// Get all wallets received from
            //var outTrans = context.Trans.Where(t => t.ToWallet == address.ParentWallet).ToList();
            //foreach (var trans in outTrans)
            //{
            //    widList.Add(trans.FromWallet);
            //}


            //var wallets = await context.Wallet.Where(x => widList.Contains(x.Wid)).ToListAsync();

            //wallets = wallets.OrderByDescending(w => w.Priority).ToList();

            //return wallets;
            return null;
        }




        //// All addresses known to belong to this wallet
        //private List<Address> walletAddresses { get; set; }                          // TODO: fix scope, create getters, setters ?

        //// Priority of wallet
        //private float walletPriority { get; set; }



        ///* WalletID
        // * 
        // * Constructor that takes a list of strings. Each string must be a valid bitcoin address,
        // *      and each is searched with the block explorer and added to the walletAddresses list
        // *      for this wallet object.
        // */
        //public Sort(List<string> addressStrings)
        //{
        //    //Currently client not used, may not be needed:
        //    BlockchainHttpClient client = new BlockchainHttpClient(apiCode: "48461d4b-9e26-43c0-bbe7-875075a6f751");

        //    walletAddresses = new List<Address>();

        //    foreach (string add in addressStrings)
        //    {
        //        walletAddresses.Add(blockExplorer.GetBase58AddressAsync(add, filter: FilterType.All).Result);
        //    }


        //    //Variable that determines the sort priority for individual wallet
        //    walletPriority = 0.5f;
        //}



        ////* WalletID
        //// * 
        //// * Overload for construtor that takes a single Address 
        //// */
        //public Sort(string initAddress) : this(new List<string>() { initAddress })
        //{
        //    //Nothing needs to be done here
        //}



        ///* addAddresses()
        // * 
        // * addressStrings: list of string representations of addresses to add
        // * 
        // * add given addresses to this WalletID if they are not redunant
        // */
        //public void addAddresses(List<Address> addAddresses)
        //{

        //    foreach (Address singleAddress in addAddresses)
        //    {
        //        //Try to find the address in the list
        //        var find = walletAddresses.Find(x => x.Base58Check == singleAddress.Base58Check);
        //        if (find == null)
        //        {
        //            //Add address if we can't find it
        //            walletAddresses.Add(singleAddress);
        //        }
        //    }
        //}



        ///* getAddresses():
        // * 
        // * gets the list of addresses for this wallet
        // */
        //public List<Address> getAddresses()
        //{
        //    return walletAddresses;
        //}



        ///* getAddressStrings()
        // * 
        // * Get a list of string representations of all addresses for this WalletID to
        // *      print to the web page.
        // */
        //public List<string> getAddressStrings()
        //{
        //    var retList = new List<string>();

        //    foreach (Address address in walletAddresses)
        //    {
        //        retList.Add(address.Base58Check);
        //    }

        //    return retList;
        //}



        ///* hasAddress()
        // * 
        // * Simple method that check if this wallet contains a given address
        // * 
        // * return: true if it contains it, false otherwise
        // */
        //public bool hasAddress(Address checkAddress)
        //{
        //    var check = walletAddresses.Find(x => x.Base58Check == checkAddress.Base58Check);
        //    if (check == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}




        ///*************************************************************************
        //                     Public Static Helpers
        //*************************************************************************/




        ///* walletsShareAddress():
        // * 
        // * Given two wallets, checks to see if the wallets share any addresses
        // */
        //public static bool walletsShareAddress(Sort checkWallet, Sort wallet)
        //{
        //    foreach (Address address in checkWallet.walletAddresses)
        //    {
        //        if (wallet.hasAddress(address))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}







        ///* Database method dummy
        // * 
        // */
        //public static int findWallet(string findAddress)
        //{
        //    //find address in database

        //    //get wallet ID number from address

        //    //return ID number

        //    return 0;
        //}


        ///* Database Method Dummy
        // * 
        // */
        //public static List<string> getWalletAddresses(int walletIndex)
        //{
        //    //get all addresses with parent wallet of walletIndex and return in a List<string>

        //    return new List<string>() { "" };
        //}


        ///* Database method Dummy
        // * 
        // */
        //public static bool storeAddress(Address putAddress)
        //{
        //    //find wallet index and store address in database

        //    return false;
        //}
    }
}
