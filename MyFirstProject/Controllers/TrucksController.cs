using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Controllers
{
    public class TrucksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Management()
        {
            return View();
        }
    }
    
}