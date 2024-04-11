using Calculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain.Interfaces.Repositories
{
    public interface ICalculationHistoryRepository
    {
        void Add(CalculationHistory history);
        void ClearAll();
        List<string> GetCalculationHistory();
    }
}
