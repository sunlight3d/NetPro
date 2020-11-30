using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyFirstEF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        

        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Dictionary<string, string>> Get()
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            result.Add(
                new Dictionary<string, string>() {
                    {"id", "123"},
                    {"cityName", "Hanoi"},
                    {"airport", "aa123"},
                }                
            );
            result.Add(new Dictionary<string, string>() {
                    {"id", "222"},
                    {"cityName", "mdisjrie"},
                    {"airport", "bb11222"},
            });
            return result;
        }
    }
}
