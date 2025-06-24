using Microsoft.AspNetCore.Mvc;
using movies_be.Services;

namespace be_movies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string title)
        {
            var result = await _movieService.SearchMoviesAsync(title);
            return Ok(result);
        }
    }
}
