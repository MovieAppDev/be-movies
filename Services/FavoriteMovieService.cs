using be_movies.Models;
using be_movies.Repositories;

namespace be_movies.Services
{
    public interface IFavoriteMovieService
    {
        Task AddFavoriteAsync(FavoriteMovie movie);
        Task RemoveFavoriteAsync(int userId, string imdbId);
        Task<List<FavoriteMovie>> GetFavoritesAsync(int userId);
    }

    public class FavoriteMovieService : IFavoriteMovieService
    {
        private readonly IFavoriteMoviesRepository _repository;

        public FavoriteMovieService(IFavoriteMoviesRepository repository)
        {
            _repository = repository;
        }

        public async Task AddFavoriteAsync(FavoriteMovie movie)
        {
            await _repository.AddFavoriteAsync(movie);
        }

        public async Task RemoveFavoriteAsync(int userId, string imdbId)
        {
            await _repository.RemoveFavoriteAsync(userId, imdbId);
        }

        public async Task<List<FavoriteMovie>> GetFavoritesAsync(int userId)
        {
            return await _repository.GetFavoritesAsync(userId);
        }
    }
}
