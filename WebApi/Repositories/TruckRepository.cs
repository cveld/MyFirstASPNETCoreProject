using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class TruckRepository : ITrucksRepository
    {
        public List<Truck> GetTrucks()
        {
            return new List<Truck>
            {
                new Truck { Name = "Nissan" },
                new Truck { Name = "BMW" },
                new Truck { Name = "DAF" },
                new Truck { Name = "Mercedes" }
            };
        }
    }
}
