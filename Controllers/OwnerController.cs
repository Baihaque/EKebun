using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EKebun.Models;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EKebun.Controllers
{
    public class OwnerController : Controller
    {
        public IActionResult Dashboard()
        {
            ViewData["Message"] = "Hello! Welcome to the dashboard.";

            return View();
        }

        public IActionResult UpdateProfile()
        {
            ViewData["Message"] = "Hello! You can update your profile here.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private CloudTable getTableStorageInformation()
        {
            //step 1: link appsettings.jason to get access key
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");
            IConfigurationRoot configure = builder.Build();

            //Step 2: link with storage account to get key access 
            
            CloudStorageAccount storageaccount =
            CloudStorageAccount.Parse(configure["ConnectionStrings:tablestorageconnection"]);
            CloudTableClient tableClient = storageaccount.CreateCloudTableClient();

            //step 3: how to create a new table in the storage. 
            CloudTable table = tableClient.GetTableReference("OwnerTable");
            return table;
        }

        //step 4: create the tavle if not exist in the storage
       
        public ActionResult CreateTable()
        {
            //step 1: link the table info
            CloudTable table = getTableStorageInformation();

            //step 2: create table with the mention name
            ViewBag.Success = table.CreateIfNotExistsAsync().Result;

            //step 3: to store the table name in the viewbag
            ViewBag.TableName = table.Name;
            return View();
        }
    }
}
