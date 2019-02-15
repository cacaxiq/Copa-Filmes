using CopaFilmes.Infra.Commands;
using CopaFilmes.Infra.PoliceHTTPs;
using CopaFilmesApp.Models;
using CopaFilmesApp.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            var moviesResult = await GetAsync.ExecuteAsync("https://copafilmes.azurewebsites.net/api/movies");

            if (moviesResult.Success)
            {
				try
				{
					JToken root = JObject.Parse(moviesResult.Content);
					var t = JsonConvert.DeserializeObject<IEnumerable<Movie>>(root["data"].ToString());
					return t;
				}
				catch (System.Exception e)
				{
					throw e;
				}
            }

            return null;
        }

        public async Task<Models.ResutMovies> GetResultChampionship(IEnumerable<Movie> movies)
        {
            var data = JsonConvert.SerializeObject(movies);
			var response = "{  \"movies\": " + data + "}";
            var moviesResult = await PostAsync.ExecuteAsync("https://copafilmes.azurewebsites.net/api/movies", response);

            if (moviesResult.Success)
            {
				JToken root = JObject.Parse(moviesResult.Content);
				return JsonConvert.DeserializeObject<Models.ResutMovies>(root["data"].ToString());
			}

            return null;
        }
    }
}
