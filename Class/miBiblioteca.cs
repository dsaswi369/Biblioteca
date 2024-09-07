using System;
using System.Collections.Generic;

namespace Biblioteca.Clases
{
    public class MiBiblioteca
    {
        private List<Libro> Libros;

        public MiBiblioteca()
        {
            Libros = new List<Libro>();
        }

        public void AgregarLibro(Libro libro)
        {
            Libros.Add(libro);
            Console.WriteLine($"Libro '{libro.Titulo}' agregado a la biblioteca.");
        }

        public void AgregarLibro(string titulo, string autor, int? anioPublicacion = null, string? isbn = null)
        {
            Libro nuevoLibro;
            if (anioPublicacion.HasValue && !string.IsNullOrEmpty(isbn))
            {
                nuevoLibro = new Libro(titulo, autor, anioPublicacion.Value, isbn);
            }
            else if (anioPublicacion.HasValue)
            {
                nuevoLibro = new Libro(titulo, autor, anioPublicacion.Value);
            }
            else if (!string.IsNullOrEmpty(isbn))
            {
                nuevoLibro = new Libro(titulo, autor, isbn: isbn);
            }
            else
            {
                nuevoLibro = new Libro(titulo, autor);
            }
            Libros.Add(nuevoLibro);
            Console.WriteLine($"Libro '{nuevoLibro.Titulo}' agregado a la biblioteca.");
        }

        public void ListarLibros()
        {
            if (Libros.Count == 0)
            {
                Console.WriteLine("No hay libros en la biblioteca.");
                return;
            }

            Console.WriteLine("Libros disponibles en la biblioteca:");
            foreach (Libro libro in Libros)
            {
                Console.WriteLine(libro.ObtenerInformacion());
            }
        }

        public bool EliminarLibro(string titulo)
        {
            var libroAEliminar = Libros.Find(libro => libro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            if (libroAEliminar != null)
            {
                Libros.Remove(libroAEliminar);
                Console.WriteLine($"Libro '{titulo}' eliminado de la biblioteca.");
                return true;
            }
            else
            {
                Console.WriteLine($"No se encontró el libro con el título '{titulo}' en la biblioteca.");
                return false;
            }
        }

        public Libro[] BuscarLibro(string autor)
        {
            var librosEncontrados = Libros.FindAll(libro => libro.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase)).ToArray();
            if (librosEncontrados.Length > 0)
            {
                return librosEncontrados;
            }
            else
            {
                Console.WriteLine($"No se encontraron libros del autor '{autor}' en la biblioteca.");
                return Array.Empty<Libro>();
            }
        }
    }
}

