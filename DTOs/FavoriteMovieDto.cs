namespace be_movies.DTOs
{
    public class FavoriteMovieDto
    {
        public string user_id { get; set; } = null!;
        public string title { get; set; } = null!;
        public string imdb_id { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
