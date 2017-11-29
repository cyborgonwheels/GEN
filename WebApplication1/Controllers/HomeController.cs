using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Info.Blockchain.API.BlockExplorer;
using Info.Blockchain.API.Client;

using BlockchainAnalysisTool.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(String adrs)
        {
            if (adrs != null)
            {

                ViewData["stringAddress"] = adrs; //address parameter
                
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
