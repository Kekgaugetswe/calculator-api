using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain.Entities
{
    public class CalculationHistory
    {
        public int Id { get; set; }
        public string Calculation { get; set; }
        public DateTime TImestamp { get; set; }
    }
}
