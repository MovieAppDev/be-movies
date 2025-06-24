using be_movies.Data;
using be_movies.Models;
using Microsoft.EntityFrameworkCore;

namespace be_movies.Repositories
{

    public class FavoriteMoviesRepository : IFavoriteMoviesRepository
    {
        private readonly AppDbContext _context;

        public FavoriteMoviesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddFavoriteAsync(FavoriteMovie movie)
        {
            var exists = await _context.FavoriteMovies
                .AnyAsync(f => f.user_id == movie.user_id && f.imdb_id == movie.imdb_id);

            if (!exists)
            {
                _context.FavoriteMovies.Add(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveFavoriteAsync(int userId, string imdbId)
        {
            var favorite = await _context.FavoriteMovies
                .FirstOrDefaultAsync(f => f.user_id == userId && f.imdb_id == imdbId);

            if (favorite != null)
            {
                _context.FavoriteMovies.Remove(favorite);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<FavoriteMovie>> GetFavoritesAsync(int userId)
        {
            return await _context.FavoriteMovies
                .Where(f => f.user_id == userId)
                .ToListAsync();
        }
    }
}
