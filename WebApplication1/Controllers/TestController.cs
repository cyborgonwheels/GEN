using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Info.Blockchain.API.BlockExplorer;
using Info.Blockchain.API.Client;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace MvcMovie.Controllers //change namespace name?
{
    public class TestController : Controller
    {
        // 
        // GET: /Test/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /Test/Welcome/ 

        public IActionResult Welcome(string name, string addressString = "1L1BRq7vyf17rsnYCiw9tebY6nmiNTxQgf")
        {
            var customClient = new BlockchainHttpClient(apiCode: "48461d4b-9e26-43c0-bbe7-875075a6f751");

            BlockExplorer blockExplorer = new BlockExplorer();

            var transactions =  blockExplorer.GetBase58AddressAsync(addressString).Result.Transactions;

            //TODO: write a loop that creates a list of ints from the transaction list and pass to the ViewData


            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = addressString;
            ViewData["Transactions"] = transactions;

            return View();
        }
    }
}
