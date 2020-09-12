using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EKebun.Models;

namespace EKebun.Controllers
{
    public class SeekerController : Controller
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
    }
}
