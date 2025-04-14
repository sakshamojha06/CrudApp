using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {

        [HttpGet("addition")]
        public IActionResult AddData(int number1, int number2)
        {
            if(number1 == null && number2 == null) return BadRequest("Data cannot be null");

            var addition = number1 + number2;

            return Ok("Added number is = " + addition);
            
        }

        [HttpGet("subtraction")]
        public IActionResult SubtractData(int number1, int number2)
        {
            if (number1 == null && number2 == null) return BadRequest("Data cannot be null");

            var subtraction = number1 - number2;

            return Ok("Subtracted number is = " + subtraction);

        }

        [HttpGet("multiplication")]
        public IActionResult MultiplyData(int number1, int number2)
        {
            if (number1 == null && number2 == null) return BadRequest("Data cannot be null");

            var multiplication = number1 * number2;

            return Ok("Multiplied number is = " + multiplication);
        }

        [HttpGet("division")]
        public IActionResult DivideData(int number1, int number2)
        {
            if (number1 == null && number2 == null) return BadRequest("Data cannot be null");
            if (number2 == 0) return BadRequest("Division by zero is not allowed");

            var division = number1 / number2;

            return Ok("Divided number is = " + division);
        }
    }
}
