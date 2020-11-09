using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalsMvc.Models;
using ConfigureMiddlewareExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsMvc.Controllers
{
    public class AnimalsController : Controller
    {
        private IData _tempData;
        private ILogger _logger;
        public AnimalsController(IData tempData, ILogger logger)
        {
            _tempData = tempData;
            _logger = logger;
        }

        public IActionResult Index()
        {
            this._logger.Log("Index cua aniomal 1111");            
            List<Animal> animals = _tempData.AnimalsInitializeData();
            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.Animals = animals;
            
            return View(indexViewModel);//Controllers/Animals/Index.cshtml
        }

        public IActionResult Details(int? id)
            //Controllers/Animals/Details.cshtml
        {
            this._logger.Log("Details cua aniomal");
            var foundAnimal = _tempData.GetAnimalById(id);
            if (foundAnimal == null)
            {
                return NotFound();
            }
            return View(foundAnimal);            
        }
    }
}
