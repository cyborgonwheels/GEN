using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Info.Blockchain.API.BlockExplorer;
using Info.Blockchain.API.Client;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string addressString = "1L1BRq7vyf17rsnYCiw9tebY6nmiNTxQgf"; //TODO: add this as a parameter

            var customClient = new BlockchainHttpClient(apiCode: "48461d4b-9e26-43c0-bbe7-875075a6f751");

            BlockExplorer blockExplorer = new BlockExplorer();

            var address = blockExplorer.GetBase58AddressAsync(addressString).Result;
            

            //TODO: write a loop that creates a list of ints from the transaction list and pass to the ViewData
            ViewData["Final Balance"] = address.FinalBalance;
            ViewData["Total Recieved"] = address.TotalReceived;
            ViewData["Total Sent"] = address.TotalSent;


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
