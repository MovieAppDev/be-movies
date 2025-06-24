using be_movies.Models;

namespace movies_be.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> SearchMoviesAsync(string title);
    }
}
