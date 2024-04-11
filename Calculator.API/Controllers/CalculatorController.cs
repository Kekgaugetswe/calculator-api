using Calculator.Domain.Dtos.Requests;
using Calculator.Domain.Interfaces;
using Calculator.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        ICalculatorService service;

        public CalculatorController(ICalculatorService service)
        {
            this.service = service;
        }

        [HttpPost]
        public ActionResult<CalculationResults> Calculete(CalculationRequest request)
        {
            try
            {
                var result = service.Calculations(request);
                return Ok(result);
            }catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("history")]
        public ActionResult<List<string>> GetCalculationHistory()
        {
            try
            {
                var history = service.GetCalculationHistory();
                return Ok(history);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("clear-all")]
        public ActionResult ClearAll()
        {
            try
            {
                service.ClearHistory();
                return Ok("Calculation history cleared successfully");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"an error occured: {ex.Message}");
            }
        }


    }
}
