﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using singleaddresssearch;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();
            // We are going to use a List<WalletID>() to handle it for now. The plan is to switch to a database, probably next sprint.
            
            List<String> singleaddresssearch = new Singleaddresssearch()
        
             
            host.Run();
            singleAddressSearch.Run();
        }
    }
}
