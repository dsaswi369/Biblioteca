using Biblioteca.Clases;
using System;

namespace Biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a la biblioteca");

            MiBiblioteca miBiblioteca = new MiBiblioteca();

            int opcion;
            do
            {
                // Mostrar el menú
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Agregar Libro");
                Console.WriteLine("2. Buscar Libro por Autor");
                Console.WriteLine("3. Listar Libros");
                Console.WriteLine("4. Eliminar Libro");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción (1-5): ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    continue;
                }

                
                switch (opcion)
                {
                    case 1:
                        // Función Agregar Libro
                        Console.Write("Ingrese el título del libro: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Ingrese el autor del libro: ");
                        string autor = Console.ReadLine();
                        Console.Write("Ingrese el año de publicación (opcional, presione Enter para omitir): ");
                        string anioInput = Console.ReadLine();
                        int? anioPublicacion = string.IsNullOrEmpty(anioInput) ? (int?)null : int.Parse(anioInput);
                        Console.Write("Ingrese el ISBN (opcional, presione Enter para omitir): ");
                        string? isbn = Console.ReadLine();
                        miBiblioteca.AgregarLibro(titulo, autor, anioPublicacion, isbn);
                        Console.WriteLine("Libro agregado exitosamente.");
                        break;

                    case 2:
                        // Función Buscar Libro
                        Console.Write("Ingrese el nombre del autor: ");
                        string autorBuscar = Console.ReadLine();
                        var librosPorAutor = miBiblioteca.BuscarLibro(autorBuscar);
                        if (librosPorAutor.Length > 0)
                        {
                            Console.WriteLine("Libros encontrados:");
                            foreach (var libro in librosPorAutor)
                            {
                                Console.WriteLine(libro.ObtenerInformacion());
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron libros para el autor especificado.");
                        }
                        break;

                    case 3:
                        //Función Listar Libros
                        Console.WriteLine("Lista de libros:");
                        miBiblioteca.ListarLibros();
                        break;

                    case 4:
                        // Función Eliminar Libro
                        Console.Write("Ingrese el título del libro a eliminar: ");
                        string tituloEliminar = Console.ReadLine();
                        if (miBiblioteca.EliminarLibro(tituloEliminar))
                        {
                            Console.WriteLine("Libro eliminado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró un libro con el título especificado.");
                        }
                        break;

                    case 5:
                        // Salir
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Por favor, ingrese un número entre 1 y 5.");
                        break;
                }

            } while (opcion != 5); 
        }
    }
}
