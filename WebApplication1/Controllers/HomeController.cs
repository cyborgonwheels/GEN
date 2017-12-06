using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Info.Blockchain.API.BlockExplorer;
using Info.Blockchain.API.Client;

using BlockchainAnalysisTool.Models;

namespace BlockchainCapstoneWebApp.Controllers
{
    public class HomeController : Controller
    {
        // Context for interacting with database
        private readonly BlockchainContext _context;

        // block explorer for interacting with Blockchain.info API
        private BlockExplorer blockExplorer;



        ///////////////////////////////////////////////////////////////////////         
        // HomeController: Creates the controller with a context and 
        //                   block explorer
        // 
        //  context: Represents a session with the gen-blockchain-db database
        ///////////////////////////////////////////////////////////////////////
        public HomeController(BlockchainContext context)
        {
            _context = context;

            //Currently client not used, may not be needed:
            BlockchainHttpClient client = new BlockchainHttpClient(apiCode: "48461d4b-9e26-43c0-bbe7-875075a6f751");

            blockExplorer = new BlockExplorer();
        }


        ///////////////////////////////////////////////////////////////////////
        // Index: Finds wallets related to address and returns them
        //          in the View
        //
        //  adrs: Bitcoin address to search
        ///////////////////////////////////////////////////////////////////////
        public IActionResult Index(String adrs)
        {
            BlockExplorer be = new BlockExplorer();

            if (adrs != null)
            {
                var x = _context.Wallet.Single(w => w.Wid == 1).Wid; //address parameter

                ViewData["stringAddress"] = x;
            }


            return View();
        }

        public IActionResult WalletLink(int index)
        {
            int testCount = 77; 
            ViewBag.address = testCount;
            ViewData["param"] = index;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Thank you for your support!";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Please contact with questions and issues!";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        
    }
}
