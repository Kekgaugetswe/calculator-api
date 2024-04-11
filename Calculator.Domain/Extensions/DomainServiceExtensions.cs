using Calculator.Domain.Interfaces;
using Calculator.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain.Extensions
{
    public static class DomainServiceExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {

            services.AddServices();
            services.AddValidators();
            return services;

        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICalculatorService, CalculatorService>();
            return services;
        }
         
        private static IServiceCollection AddValidators(this IServiceCollection services)
        {

            return services;
        }
    }
}
