using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControllerExampleM04.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ProductPrices = new Dictionary<string, int>();
            ViewBag.ProductPrices.Add("Bread", 5);
            ViewBag.ProductPrices.Add("Rice", 3);
            ViewBag.EmployeeNames = new string[] { "Michael", "Sarah", "Logan", "Elena", "Nathan" };

            return View();
        }
    }
}
