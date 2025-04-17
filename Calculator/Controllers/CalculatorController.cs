using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Calculator.Controllers
{
    public class CalculationData
    {
        public int number1 { get; set;}
        public int number2 { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpPost("add")]
        public IActionResult PostAdd([FromBody] CalculationData calculateData)
        {
            var result = calculateData.number1 + calculateData.number2;
            return Ok($"Result is {result}");
        }

        [HttpGet("add")]
        public IActionResult Add(int number1, int number2)
        {
            //if(number1 == null || number2 == null) return BadRequest("Data cannot be null");

            var result = number1 + number2;

            return Ok($"Added number is {result}");
            
        }

        [HttpGet("subtract")]
        public IActionResult Subtract(int number1, int number2)
        {
            //if (number1 == null || number2 == null) return BadRequest("Data cannot be null");

            var result = number1 - number2;

            return Ok($"Subtracted number is {result}");

        }

        [HttpGet("multiply")]
        public IActionResult Multiply(int number1, int number2)
        {
            //if (number1 == null || number2 == null) return BadRequest("Data cannot be null");

            var result = number1 * number2;

            return Ok("Result is = " + result);
        }

        [HttpGet("divide")]
        public IActionResult Divide(int number1, int number2)
        {
            //if (number1 == null || number2 == null) return BadRequest("Data cannot be null");
            if (number2 == 0) return BadRequest("Division by zero is not allowed");

            var result = number1 / number2;

            return Ok("Divided number is = " + result);
        }
    }
}
