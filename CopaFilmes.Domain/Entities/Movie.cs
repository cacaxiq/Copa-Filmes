using CopaFilmes.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.Domain.Entities
{
	public class Movie
	{
		public Movie(string id, string titulo, long ano, double nota)
		{
			Id = id;
			Titulo = titulo;
			Ano = ano;
			Nota = nota;
		}

		public string Id { get; private set; }

		public string Titulo { get; private set; }

		public long Ano { get; private set; }

		public double Nota { get; private set; }
	}
}
