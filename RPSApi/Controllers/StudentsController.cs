using Microsoft.AspNetCore.Mvc;
using RPSApi.Models;

namespace RPSApi.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>();

        [HttpPost("admission")]
        public IActionResult NewAdmission([FromBody] Student student)
        {
            students.Add(student);
            return Ok("Admission Successful");
        }

        [HttpGet("allAdmissions")]
        public IActionResult GetStudents()
        {
            return Ok(students);
        }
    }
}
