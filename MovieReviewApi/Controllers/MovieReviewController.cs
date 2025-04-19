using Microsoft.AspNetCore.Mvc;
using MovieReviewApi.Models;

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

            var dtos = GetDtos(movie.Reviews);

            return Ok(dtos);
        }

        private List<ReviewDto> GetDtos(List<Review> reviews)
        {
            var dtos = new List<ReviewDto>();

            foreach (var item in reviews)
            {
                var dto = new ReviewDto();
                dto.Author = item.Author;
                dto.Star = item.Star;
                dto.Text = item.Text;

                dtos.Add(dto);
            }

            return dtos;
        }
    }
}
