using Microsoft.AspNetCore.Mvc;

namespace MovieReviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieReviewController : ControllerBase
    {
        private static List<Movie> _movies = new List<Movie>();

        [HttpPost]
        public IActionResult newMovie([FromBody] string name)
        {
            if (name == null) return BadRequest("Movie name cannot be empty");

            var maxId = _movies.Count > 0 ? _movies.Max(m => m.id) : 0;

            Movie m = new Movie(maxId + 1,name);

            _movies.Add(m);

            return Ok("Movie added");
        }

        [HttpPost("review/{id}")]
        public IActionResult movieReview(int id, [FromBody] List<string> review)
        {
            var movie = _movies.FirstOrDefault(m => m.id == id);
            if (movie == null) return BadRequest("Movie not found");

            movie.Reviews = review;

            return Ok("Review added");
        }

        [HttpGet]
        public IActionResult getMovies()
        {
            return Ok(_movies);
        }

        [HttpGet("{id}")]
        public IActionResult getMovieById(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.id == id);

            if (movie == null) return BadRequest("Movie not found");

            return Ok(movie);
        }
    }

    public class Movie
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<string> Reviews { get; set; }

        public Movie(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
