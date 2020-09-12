using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EKebun.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EKebun.Controllers
{
    public class AdministratorController : Controller
    {
        public IActionResult Dashboard()
        {
            ViewData["Message"] = "Hello Admin! Welcome to the dashboard.";

            return View();
        }
        public IActionResult UpdateProfile()
        {
            ViewData["Message"] = "Hello Admin! You can update your profile here.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
