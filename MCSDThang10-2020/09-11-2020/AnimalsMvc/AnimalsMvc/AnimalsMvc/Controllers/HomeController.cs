using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnimalsMvc.Models;
using ConfigureMiddlewareExample.Services;

namespace AnimalsMvc.Controllers
{
    public class HomeController : Controller
    {
        private ILogger logger;
        public HomeController(ILogger logger) {
            this.logger = logger;
        }
        public IActionResult Index()
        {
            this.logger.Log("Index cua Home");
            return View();
        }

        public IActionResult About()
        {
            this.logger.Log("About cua Home");
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult TestPage()
        {
            //TestPage.cshtml
            return View();
        }
    }
}
