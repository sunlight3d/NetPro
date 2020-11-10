using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerExampleM04.Filters
{
    public class CustomActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context) {
            Console.WriteLine("3.OnActionExecuted");
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //string actionName = filterContext.ActionDescriptor.RouteValues["action"];
            //Debug.WriteLine(">>> " + actionName + " started, event fired: OnActionExecuting");

            Console.WriteLine("1.OnActionExecuting");
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("4.OnResultExecuting");
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("5.OnResultExecuted");//di qua 5 => hoan tat(nhin thay view)
        }
        
    }
}
