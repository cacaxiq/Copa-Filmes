using CopaFilmes.Domain.Entities;
using CopaFilmes.Infra.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.Domain.Commands
{
	public class MoviesWinsCommand : ICommand
	{
		public IList<Movie> Movies { get; set; }

		public bool Valid()
		{
			return Movies.Count == 8;
		}
	}
}
