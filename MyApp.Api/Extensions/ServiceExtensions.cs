using Microsoft.Extensions.DependencyInjection;
using MyApp.Facade.Interface;
using MyApp.Facade.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Api.Extensions
{
    public static class ServiceExtensions
    { 
        public static void ConfigureFacade(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>(); 
        }

      
    }
}
