using Calculator.Domain.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain.ValueObjects
{
    public class CalculationResults
    {
        public double Results { get; set; }
        public OperationType Operation { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
