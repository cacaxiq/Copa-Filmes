using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Queries;
using CopaFilmes.Infra.Commands;
using CopaFilmes.Infra.PoliceHTTPs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CopaFilmes.Domain.Services
{
	public class CopaFilmesService : ICopaFilmesService
	{
		public async Task<ICommandResult> GetCopaFilmes()
		{
			var copaFilmesResult = await GetAsync.ExecuteAsync("https://copadosfilmes.azurewebsites.net/api/filmes");

			if (copaFilmesResult.Success)
			{
				var list = JsonConvert.DeserializeObject<IEnumerable<CopaFilmesQueryResult>>(copaFilmesResult.Content);

				var movies = new List<Movie>();
				foreach (var item in list)
				{
					movies.Add(item.ConvertToMovie());
				}

				return new CommandResult(
					true,
					"Lista de Filmes obtida com sucesso",
					movies);
			}

			return new CommandResult(
				false,
				copaFilmesResult.Message,
				null);
		}
	}
}
