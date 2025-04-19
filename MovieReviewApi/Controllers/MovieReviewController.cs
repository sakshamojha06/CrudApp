using Microsoft.AspNetCore.Mvc;

namespace MovieReviewApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieReviewController : ControllerBase
    {
        private static List<Movie> _movies = new List<Movie>();

        [HttpPost]
        public IActionResult CreateMovie([FromBody] string name)
        {
            if (name == null) return BadRequest("Movie name cannot be empty");

            var maxId = _movies.Count > 0 ? _movies.Max(m => m.id) : 0;

            Movie movie = new Movie(maxId + 1,name);

            _movies.Add(movie);

            return Ok("Movie added");
        }

        [HttpPost("{id}/reviews")]
        public IActionResult CreateReview(int id, [FromBody] string review)
        {
            var movie = _movies.FirstOrDefault(m => m.id == id);
            if (movie == null) return BadRequest("Movie not found");

            movie.Reviews.Add(review);

            return Ok("Review added");
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(_movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.id == id);

            if (movie == null) return BadRequest("Movie not found");

            return Ok(movie);
        }

        [HttpGet("{id}/reviews")]
        public IActionResult GetMovieReviewsById(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.id == id);

            if (movie == null) return NotFound("Movie not found");

            return Ok(movie.Reviews);
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
            this.Reviews = new List<string>();
        }
    }
}
