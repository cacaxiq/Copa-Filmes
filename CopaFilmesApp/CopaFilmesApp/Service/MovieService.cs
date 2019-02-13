using CopaFilmes.Infra.PoliceHTTPs;
using CopaFilmesApp.Models;
using CopaFilmesApp.Service;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(MovieService))]
namespace CopaFilmesApp.Service
{
    public class MovieService : IMovieService
    {
        public async Task<IEnumerable<Models.Movie>> GetMovies()
        {
            var moviesResult = await GetAsync.ExecuteAsync("http://10.0.2.2/CopaFilmes.Api/api/Movies/Get");

            if (moviesResult.Success)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Models.Movie>>(moviesResult.Content);
            }

            return null;
        }

        public async Task<Models.ResutMovies> GetResultChampionship(IEnumerable<Movie> movies)
        {
            var data = JsonConvert.SerializeObject(movies);
            var moviesResult = await PostAsync.ExecuteAsync("http://10.0.2.2/CopaFilmes.Api/api/Movies/Post", data);

            if (moviesResult.Success)
            {
                return JsonConvert.DeserializeObject<Models.ResutMovies>(moviesResult.Content);
            }

            return null;
        }
    }
}
