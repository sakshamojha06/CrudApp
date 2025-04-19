using Microsoft.AspNetCore.Mvc;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private static List<ToDo> _toDos = new List<ToDo>();

        [HttpPost]
        public IActionResult NewTodo([FromBody] string title)
        {
            if (title == null) return BadRequest();
            if (string.IsNullOrEmpty(title)) return BadRequest("Title is necessary");

            var maxId = _toDos.Count > 0 ? _toDos.Max(t => t.id): 0;

            var todo = new ToDo(maxId+1, title);

            _toDos.Add(todo);
            return Ok("Todo Added");
        }

        [HttpGet]
        public IActionResult AllTodo()
        {
            return Ok(_toDos);
        }

        [HttpGet("{id}")]
        public IActionResult GetTodoById(int id)
        {
            var todo = _toDos.FirstOrDefault(t => t.id == id);

            if(todo == null) return NotFound("Todo not found");
            
            return Ok(todo);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTodo(int id, [FromBody] ToDo UpdatedTodo)
        {
            var todo = _toDos.FirstOrDefault(t => t.id == id);

            if(todo == null) return NotFound("Todo not found");

            todo.Title = UpdatedTodo.Title;
            todo.IsDone = UpdatedTodo.IsDone;
            
            return Ok("Todo updated successfully");
        }

        [HttpPatch("changeTitle/{id}")]
        public IActionResult PartialTodoUpdate(int id, [FromBody] string title)
        {
            var todo = _toDos.FirstOrDefault(t => t.id == id);

            if (todo == null) return NotFound("Todo not found");
            if (string.IsNullOrEmpty(title)) return BadRequest("Please provide the todo title");

            todo.Title = title;
            
            return Ok("Todo is updated successfully");
        }

        [HttpPatch("markComplete/{id}")]
        public IActionResult MarkComplete(int id)
        {
            var todo = _toDos.FirstOrDefault(t => t.id == id);

            if (todo == null) return NotFound("Todo not found");

            todo.IsDone = true;

            return Ok($"{id} marked completed");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTodo(int id)
        {
            var todo = _toDos.FirstOrDefault(t => t.id == id);

            if (todo == null) return NotFound("Todo not found");

            _toDos.Remove(todo);

            return Ok("Todo deleted successfully");
        }
    }

    public class ToDo
    {
        public int id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public ToDo(int id, string title)
        {
            this.id = id;
            Title = title;
            IsDone = false;
        }
    }
}
