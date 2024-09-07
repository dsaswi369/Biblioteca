using System;

namespace Biblioteca.Clases
{
    public class Libro
    {
        public string Titulo { get; }
        public string Autor { get; }
        public int? AnioPublicacion { get; }
        public string? ISBN { get; }

        public Libro(string titulo, string autor, int? anioPublicacion = null, string? isbn = null)
        {
            Titulo = titulo;
            Autor = autor;
            AnioPublicacion = anioPublicacion;
            ISBN = isbn;
        }

        public string ObtenerInformacion()
        {
            return $"{Titulo} por {Autor}" +
                   (AnioPublicacion.HasValue ? $", {AnioPublicacion.Value}" : "") +
                   (!string.IsNullOrEmpty(ISBN) ? $", ISBN: {ISBN}" : "");
        }
    }
}
