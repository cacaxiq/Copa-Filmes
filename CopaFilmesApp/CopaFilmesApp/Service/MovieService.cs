using CopaFilmes.Infra.Commands;
using CopaFilmes.Infra.PoliceHTTPs;
using CopaFilmesApp.Models;
using CopaFilmesApp.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(MovieService))]
namespace CopaFilmesApp.Service
{
    public class MovieService : IMovieService
    {
        public async Task<IEnumerable<Models.Movie>> GetMovies()
        {
            var oauthToken = string.Empty;

            try
            {
                oauthToken = await SecureStorage.GetAsync("oauth_token");
            }
            catch (Exception)
            {
                return null;
            }

            var moviesResult = await GetAsync.ExecuteAsync("https://copafilmes.azurewebsites.net/api/movies", oauthToken);

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
            if (movies == null)
            {
                throw new ArgumentNullException(nameof(movies));
            }

            var oauthToken = string.Empty;

            try
            {
                oauthToken = await SecureStorage.GetAsync("oauth_token");
            }
            catch (Exception)
            {
                return null;
            }

            var data = JsonConvert.SerializeObject(movies);
			var response = "{  \"movies\": " + data + "}";
            var moviesResult = await PostAsync.ExecuteAsync("https://copafilmes.azurewebsites.net/api/movies", response, oauthToken);

            if (moviesResult.Success)
            {
				JToken root = JObject.Parse(moviesResult.Content);
				return JsonConvert.DeserializeObject<Models.ResutMovies>(root["data"].ToString());
			}

            return null;
        }
    }
}
