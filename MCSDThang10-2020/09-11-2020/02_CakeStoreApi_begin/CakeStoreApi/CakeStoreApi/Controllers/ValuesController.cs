using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CakeStoreApi.Controllers
{
    [Route("api/[controller]")] //attribute to configuration.Eg: http://diachiIp:port/api/values
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        //http://diachiIp:port/api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            //return new string[] { "value1", "value2" };
            return "Chao cac ban toi la Hoang";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
