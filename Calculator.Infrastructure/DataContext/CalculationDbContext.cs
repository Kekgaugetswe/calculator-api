using Calculator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Infrastructure.DataContext
{
    public class CalculationDbContext : DbContext
    {
        public CalculationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CalculationHistory> CalculationHistory { get; set; }
    }
}
