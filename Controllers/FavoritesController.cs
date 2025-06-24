using System.Security.Claims;
using be_movies.Data;
using be_movies.Models;
using be_movies.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace be_movies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteMoviesController : ControllerBase
    {
        private readonly IFavoriteMovieService _favoriteService;
        private readonly AppDbContext _context;

        public FavoriteMoviesController(IFavoriteMovieService favoriteService, AppDbContext context)
        {
            _favoriteService = favoriteService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetFavorites()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdString, out int userId))
            {
                return Unauthorized(new { message = "No se pudo identificar al usuario." });
            }

            var movies = await _favoriteService.GetFavoritesAsync(userId);
            return Ok(movies);
        }



        [HttpPost]
        public async Task<IActionResult> AddFavorite(FavoriteMovie movie)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdString, out int userId))
            {
                return Unauthorized(new { message = "No se pudo identificar al usuario." });
            }

            movie.user_id = userId;
            await _favoriteService.AddFavoriteAsync(movie);
            return Ok(new { message = "Película agregada a favoritos" });
        }


        [HttpGet("{userId}")]
        public IActionResult GetFavoritesByUser(int userId)
        {
            var favorites = _context.FavoriteMovies
                .Where(f => f.user_id == userId)
                .ToList();

            return Ok(favorites);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteMovie(int id)
        {
            var favorite = await _context.FavoriteMovies.FindAsync(id);

            if (favorite == null)
            {
                return NotFound();
            }

            _context.FavoriteMovies.Remove(favorite);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
