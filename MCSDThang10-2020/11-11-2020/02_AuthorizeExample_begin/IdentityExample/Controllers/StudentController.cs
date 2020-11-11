using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityExample.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExample.Controllers
{
    public class StudentController : Controller
    {
        private StudentContext _studentContext;

        public StudentController(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
        //[AllowAnonymous] //anyone can see
        [Authorize]
        public IActionResult CourseDetails()
        {
            return View(_studentContext.Courses.ToList());
        }
        [Authorize]
        public IActionResult Index()
        {            
            return View();
        }
    }
}