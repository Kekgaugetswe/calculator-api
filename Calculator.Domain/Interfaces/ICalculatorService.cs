using Calculator.Domain.Dtos.Requests;
using Calculator.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain.Interfaces
{
    public interface ICalculatorService
    {
        CalculationResults Calculations(CalculationRequest request);
        void ClearHistory();
        List<string> GetCalculationHistory();
    }
}
