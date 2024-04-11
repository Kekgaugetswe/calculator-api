using Calculator.Domain.Entities;
using Calculator.Domain.Interfaces.Repositories;
using Calculator.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Infrastructure.Repositories
{
    public class CalculationHistoryRepository : ICalculationHistoryRepository
    {
        CalculationDbContext _context;

        public CalculationHistoryRepository(CalculationDbContext context)
        {
            _context = context;
        }

        public void Add(CalculationHistory history)
        {
            _context.CalculationHistory.Add(history);
            _context.SaveChanges();
        }

        public List<string> GetCalculationHistory()
        {
            return _context.CalculationHistory.OrderByDescending(c=> c.TImestamp).Select(c=> c.Calculation).ToList();
        }

        public void ClearAll()
        {
            _context.CalculationHistory.RemoveRange(_context.CalculationHistory);
            _context.SaveChanges();
        }
    }
}
