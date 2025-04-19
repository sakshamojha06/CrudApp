namespace MovieReviewApi.Models
{
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
}
