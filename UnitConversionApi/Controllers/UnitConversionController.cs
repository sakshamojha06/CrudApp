using Microsoft.AspNetCore.Mvc;

namespace UnitConversionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitConversionController : ControllerBase
    {
        [HttpGet("findingfahrenheit")]
        public IActionResult FindingFahrenheit(double celsius)
        {
            var fahrenheit = (celsius * 9 / 5) + 32;
            return Ok(fahrenheit);
        }

        [HttpGet("findingcelsius")]
        public IActionResult FindingCelsius(double fahrenheit)
        {
            var celsius = (fahrenheit - 32) * 5 / 9;
            return Ok(celsius);
        }

        [HttpGet("findingmiles")]
        public IActionResult FindingMiles(double kilometers)
        {
            var miles = kilometers * 0.621371;
            return Ok(miles);
        }

        [HttpGet("findingkilometers")]
        public IActionResult FindingKilometers(double miles)
        {
            var kilometers = miles / 0.621371;
            return Ok(kilometers);
        }

        [HttpGet("findingpounds")]
        public IActionResult FindingPounds(double kilograms)
        {
            var pounds = kilograms * 2.20462;
            return Ok(pounds);
        }

        [HttpGet("findingkilograms")]
        public IActionResult FindingKilograms(double pounds)
        {
            var kilograms = pounds / 2.20462;
            return Ok(kilograms);
        }
    }
}
