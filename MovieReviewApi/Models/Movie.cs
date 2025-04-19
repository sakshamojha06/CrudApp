namespace MovieReviewApi.Models
{
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
}
