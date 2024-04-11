using Calculator.Domain.Dtos.Requests;
using Calculator.Domain.Entities;
using Calculator.Domain.enums;
using Calculator.Domain.Interfaces;
using Calculator.Domain.Interfaces.Repositories;
using Calculator.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain.Services
{
    public class CalculatorService : ICalculatorService
    {

        ICalculationHistoryRepository historyRepository;

        public CalculatorService(ICalculationHistoryRepository historyRepository)
        {
            this.historyRepository = historyRepository;
        }

        public CalculationResults Calculations(CalculationRequest request)
        {
            var response = new CalculationResults();

            double result = 0;

            switch (request.Operation)
            {
                case OperationType.Add:
                    result = request.Operand_A + request.Operand_B;
                    break;
                case OperationType.Subtract:
                    result = request.Operand_A - request.Operand_B;
                    break;
                case OperationType.Multiply:
                    result =  request.Operand_A * request.Operand_B;
                    break;
                case OperationType.Divide:
                    if(request.Operand_B != 0)
                    {
                        result = request.Operand_A / request.Operand_B;
                    }
                    else
                    {
                        throw new ArgumentException("Cannot divide by zero.");
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid operation.");

            }

            var operationSign = GetOperationSign(request.Operation);

            string calculation = $"{ request.Operand_A} { operationSign} { request.Operand_B} = {result}";

            var calculationHistory = new CalculationHistory
            {
                Calculation = calculation,
                TImestamp = DateTime.Now,
            };
            historyRepository.Add(calculationHistory);

            response.Results = result;
            response.Operation = request.Operation;
            response.Timestamp = DateTime.Now;

            return response;
        }

        private string GetOperationSign(OperationType operation)
        {
            switch (operation)
            {
                case OperationType.Add:
                    return "+";
                case OperationType.Subtract:
                    return "-";
                case OperationType.Multiply:
                    return "*";
                case OperationType.Divide:
                    return "/";
                default:
                    throw new ArgumentException("Invalid operation.");
            }

        }

        public List<string> GetCalculationHistory()
        {
            return  historyRepository.GetCalculationHistory();
        }

        public void ClearHistory()
        {
            historyRepository.ClearAll();

        }
    }

}
