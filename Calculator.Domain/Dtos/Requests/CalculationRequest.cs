using Calculator.Domain.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain.Dtos.Requests
{
    public class CalculationRequest
    {
        public double Operand_A { get; set; }
        public double Operand_B { get; set; }
        public OperationType Operation { get; set; }
    }
}
