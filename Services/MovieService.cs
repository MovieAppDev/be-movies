using System.Net.Http;
using System.Text.Json;
using be_movies.Models;
using global::movies_be.Services;


namespace be_movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public MovieService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiKey = configuration["Omdb:ApiKey"];
        }

        public async Task<List<Movie>> SearchMoviesAsync(string title)
        {
            var response = await _httpClient.GetStringAsync($"https://www.omdbapi.com/?apikey={_apiKey}&s={title}");
            var json = JsonDocument.Parse(response);
            var results = new List<Movie>();

            if (json.RootElement.TryGetProperty("Search", out var movies))
            {
                foreach (var item in movies.EnumerateArray())
                {
                    results.Add(new Movie
                    {
                        Title = item.GetProperty("Title").GetString(),
                        Year = item.GetProperty("Year").GetString(),
                        ImdbID = item.GetProperty("imdbID").GetString(),
                        Type = item.GetProperty("Type").GetString(),
                        Poster = item.GetProperty("Poster").GetString(),
                    });
                }
            }

            return results;
        }
    }
}

