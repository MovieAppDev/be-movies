using System.ComponentModel.DataAnnotations.Schema;

namespace be_movies.Models
{
    [Table("favorite_movies")]
    public class FavoriteMovie
    {
        public int Id { get; set; }
        public int user_id { get; set; } = 0;
        public string title { get; set; } = null!;
        public string imdb_id { get; set; } = null!;
        public DateTime created_at { get; set; } = DateTime.UtcNow;
    }
}
