using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Repositories;

namespace TodoApi.Extensions
{
    public static class TruckRepositoryExtensions
    {
        public static IServiceCollection AddTruckRepository(this IServiceCollection service)
        {
            service.AddSingleton<ITrucksRepository, TruckRepository>();
            return service;
        }

    }
}
