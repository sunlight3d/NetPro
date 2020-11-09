using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeStoreApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CakeStoreApi.Controllers
{
    public class CakeStoreApiController : Controller
    {
        private IData _data;

        public CakeStoreApiController(IData data)
        {
            //Dependency injection, phai co cho addservice
            _data = data;
        }

        [HttpGet("/api/CakeStore")]
        //http:localhost:3000/CakeStore
        public ActionResult<List<CakeStore>> GetAll()
        {
            return _data.CakesInitializeData();
        }

        [HttpGet("/api/CakeStore/{id}", Name = "Get Detail Cake by id")]
        public ActionResult<CakeStore> GetById(int? id)
        {
            var item = _data.GetCakeById(id);
            if (item == null)
            {
                return NotFound();//response to client
            }
            return new ObjectResult(item);
        }
    }
}
