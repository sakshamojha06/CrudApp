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

            var movie = new Movie(name);

            _movies.Add(movie);

            return Ok("Movie added");
        }

        [HttpPost("{id}/reviews")]
        public IActionResult CreateReview(Guid id, [FromBody] ReviewDto newReview)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return BadRequest("Movie not found");

            var review = new Review(newReview);

            movie.Reviews.Add(review);

            return Ok("Review added");
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(_movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(Guid id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);

            if (movie == null) return BadRequest("Movie not found");

            return Ok(movie);
        }

        [HttpGet("{id}/reviews")]
        public IActionResult GetMovieReviewsById(Guid id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);

            if (movie == null) return NotFound("Movie not found");


            return Ok(movie.Reviews);
        }
    }

    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Review> Reviews { get; set; }

        public Movie(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Reviews = new List<Review>();
        }
    }

    public class Review: ReviewDto
    {
        public Guid Id { get; set; }

        public Review(string author, int star, string text)
        {
            Id = Guid.NewGuid();
            Author = author;
            Star = star;
            Text = text;
        }

        public Review(ReviewDto reviewDto)
        {
            Id = Guid.NewGuid();
            Author = reviewDto.Author;
            Star = reviewDto.Star;
            Text = reviewDto.Text;
        }
    }

    public class ReviewDto
    {
        public string Author { get; set; }
        public int Star { get; set; }
        public string Text { get; set; }
    }
}
