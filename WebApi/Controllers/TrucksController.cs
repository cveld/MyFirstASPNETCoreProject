using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrucksController
    {
        private readonly ITrucksRepository trucksRepository;

        public TrucksController(ITrucksRepository trucksRepository)
        {
            this.trucksRepository = trucksRepository;
        }

        [HttpGet]       
        public ActionResult<List<Truck>> Get() {
            return trucksRepository.GetTrucks();
        }
    }
}
