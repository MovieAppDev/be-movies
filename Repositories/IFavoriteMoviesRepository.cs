using be_movies.Models;

namespace be_movies.Repositories
{
    public interface IFavoriteMoviesRepository
    {
        Task AddFavoriteAsync(FavoriteMovie movie);
        Task RemoveFavoriteAsync(int userId, string imdbId);
        Task<List<FavoriteMovie>> GetFavoritesAsync(int userId);
    }
}
