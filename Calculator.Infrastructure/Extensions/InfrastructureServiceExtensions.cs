using Calculator.Domain.Interfaces.Repositories;
using Calculator.Infrastructure.DataContext;
using Calculator.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Infrastructure.Extensions
{
    public static class InfrastructureServiceExtensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRespository();
            services.AddDbContext(configuration);
            return services;
        }

        static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration) 
        {

            services.AddDbContext<CalculationDbContext>(options => options.UseSqlite(configuration.GetConnectionString("SQLiteConnection"), b => b.MigrationsAssembly("Calculator.API")));
            return services; 
        }
        static IServiceCollection AddRespository(this IServiceCollection services)
        {
            services.AddTransient<ICalculationHistoryRepository, CalculationHistoryRepository>();
            return services;
        }

        
    }
}
