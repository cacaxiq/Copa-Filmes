namespace CopaFilmesApp.Models
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

        public string Id { get; set; }

        public string Titulo { get; set; }

        public long Ano { get; set; }

        public double Nota { get; set; }
    }
}
