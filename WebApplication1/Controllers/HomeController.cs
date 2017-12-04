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
        private readonly BlockchainContext _context;

        public HomeController(BlockchainContext context)
        {
            _context = context;
        }

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
