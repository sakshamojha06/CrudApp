using Microsoft.AspNetCore.Mvc;
using BusinessLogic;

namespace RPSApi.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>();

        [HttpPost]
        public IActionResult NewAdmission([FromBody] Student student)
        {
            if (student == null) return BadRequest();
            if (string.IsNullOrEmpty(student.Name)) return BadRequest("Name cannot be empty"); 
            if (student.Age < 18 || student.Age > 100) return BadRequest("Age must be between 18 and 100");
            if (string.IsNullOrEmpty(student.Grade)) return BadRequest("Grade cannot be empty");

            var maxId = students.Count > 0 ? students.Max(s => s.id) : 0;
            student.id = maxId + 1;

            students.Add(student);
            return Ok("Admission Successful");
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = students.FirstOrDefault(s => s.id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.id == id);
            if (student == null)
            {
                return NotFound();
            }
            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.Grade = updatedStudent.Grade;
            return Ok("Student updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.id == id);
            if (student == null)
            {
                return NotFound();
            }
            students.Remove(student);
            return Ok("Student deleted successfully");
        }
    }
}
