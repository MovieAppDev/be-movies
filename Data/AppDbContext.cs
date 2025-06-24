using be_movies.Models;
using Microsoft.EntityFrameworkCore;

namespace be_movies.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<FavoriteMovie> FavoriteMovies { get; set; }
    }
}