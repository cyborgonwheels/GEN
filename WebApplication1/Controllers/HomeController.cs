using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Info.Blockchain.API.BlockExplorer;
using Info.Blockchain.API.Client;

using BlockchainAnalysisTool;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(String adrs)
        {
            if (adrs != null)
            {
                String address = adrs;
                ViewData["stringAddress"] = address; //address parameter
                //   19TBERtSZYw4V6mXbHpczBgQCYH5MzfM7o
                //var addressList = new List<String>();
                //addressList.Add(adrs);
                //WalletID testwallet = new WalletID(addressList);
                // WalletID.MASTER_LIST.Add(testwallet);
                //BlockExplorer blockExplorer = new BlockExplorer();
                //var address = blockExplorer.GetBase58AddressAsync(adrs).Result;

                //var dataList = new List<List<string>>();
                //var walletList = WalletID.getRelatedWallets(addressString);
                //foreach (WalletID wallet in walletList)
                //{
                //    dataList.Add(wallet.getAddressStrings());
                //}

                //ViewData["ListOfWallets"] = dataList;


                ////TODO: write a loop that creates a list of ints from the transaction list and pass to the ViewData
                //ViewData["Final Balance"] = address.FinalBalance;
                //ViewData["Total Recieved"] = address.TotalReceived;
                //ViewData["Total Sent"] = address.TotalSent;
            }


            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        
    }
}
