using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControllerExampleM04.Models;
using ControllerExampleM04.Filters;

namespace ControllerExampleM04.Controllers
{
    public class HomeController : Controller
    {        
        [Route("Calc/Mult/{num1:int}/{num2:int}")]        
        public IActionResult Mult(int num1, int num2)
        {
            return Content($"result = {num1 * num2}");
        }
        
        [HttpPost("Divide/{param?}")]
        public IActionResult DivideByTen(int param)
        {
            return Content($"Value = {param / 10}");//2.
        }

        public IActionResult Index()
        {
            ExampleModel model = new ExampleModel() {
                Sentence = "Welcome to module 4 demo 1" 
            };

            return View();
        }
        //home/ParamExample/3
        public IActionResult ParamExample(string id)
        {
            return Content($"Your param is: {id}");
        }
        public IActionResult RouteDataExample()
        {
            string controller = (string)RouteData.Values["Controller"];
            string action = (string)RouteData.Values["action"];
            string id = (string)RouteData.Values["id"];
            return Content($"Action information: the action is in {controller} controller, the action name is {action} and the id value is {id}");
        }
        [CustomActionFilter]
        public IActionResult ViewBagExample()

        {
            
            ViewBag.Message = "ViewBag Example";
            ViewBag.x = 10;
            ViewBag.y = 20;
            string a = "xx";
            return View("ViewBagExample", a);

        }
        // /home/Hello/Nguen/Duc Hoang
        [Route("Hello/{firstName}/{lastName}")]
        public IActionResult Greeting(string firstName, string lastName)
        {
            return Content($"Hello {firstName} {lastName} from module 4 demo 2");
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
