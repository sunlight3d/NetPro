using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BindViewsExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace BindViewsExample.Controllers
{
    public class HomeController : Controller
    {
        //Home/Index
        public IActionResult Index()
        {
            Restaurant restaurant = new Restaurant() { 
                Id = 1, Name = "My Kitchen 1", 
                Address = "New Brunswick, 2657 Webster Street",
                Speciality = "Hamburgers", Open = true, Review = 4 };//Builder Pattern
            return View(restaurant);            
        }

        [Route("Home/Display")]
        public IActionResult AnotherWayToDisplay()
        {
            Restaurant restaurant = new Restaurant() { Id = 2, Name = "My Kitchen 2", Address = "New Brunswick, 4175 Echo Lane Street", Speciality = "Sushi", Open = true, Review = 3 };
            return View(restaurant);            
        }
    }
}