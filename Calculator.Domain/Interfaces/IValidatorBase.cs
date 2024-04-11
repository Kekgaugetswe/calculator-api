using Calculator.Domain.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain.Interfaces
{
    public interface IValidatorBase<T> where T : BaseRequest
    {
        List<string> Validate(T data);
    }
}
