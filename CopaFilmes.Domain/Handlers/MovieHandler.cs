using CopaFilmes.Domain.Commands;
using CopaFilmes.Domain.Services;
using CopaFilmes.Infra.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CopaFilmes.Domain.Handlers
{
	public class MovieHandler : ICommandHandler<MoviesWinsCommand>
	{
		private readonly IMoviesChampionshipService moviesChampionshipService;

		public MovieHandler(IMoviesChampionshipService moviesChampionshipService)
		{
			this.moviesChampionshipService = moviesChampionshipService;
		}

		public ICommandResult Handle(MoviesWinsCommand command)
		{
			if (!command.Valid())
				return new CommandResult(false, "Quantidade de filmes incorreta.", null);

			var result = moviesChampionshipService.GetResultChampionship(command.Movies.ToArray());

			return new CommandResult(true, "Campeonato completo.", result);
		}
	}
}
