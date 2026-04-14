using System.Linq;
using System.Text;

namespace LINQ
{
    internal class Program
    {
        record Estudiante(string nombre, int edad, string carrera);

        static void Main(string[] args)
        {
            Console.WriteLine("Practicando con LINQ");

            List<int> notas = new List<int> { 65, 98, 95, 77, 60, 85, 100, 81, 89 };

            //Aqui se hace la consulta para buscar las notas mayores a 90
            IEnumerable<int> consultaNotas = from nota in notas        //requerido
                                             where nota > 80           //opcional
                                             orderby nota descending   //opcional
                                             select nota;              //requerido

            //Se debe usar el foreach para recorrer la coleccion de elementos (IEnumerable)
            foreach (int nota in consultaNotas)
            {
                Console.WriteLine($"La nota es: {nota}");
            }



            //Ahora si se va a usar los resultados varias veces se recomienda utilizar .ToList() --> ejecuta la consulta una sola vez y guarda los resultados en memoria
            List<int> MyScores = consultaNotas.ToList();


            //El foreach solo recorre la lista, no re-ejecuta la consulta.      //Puedes reutilizar MyScores múltiples veces sin costo extra
            recorrerConsultas(MyScores);


            // Aquí recién se ejecuta la consulta y cuenta cuántos resultados hay
            //Console.WriteLine(consultaNotas.Count()); // ej: 5







            //LINQ usando lambda
            Console.WriteLine("LINQ usando funcion lambda");
            var scoreQuery = notas.Where(n => n > 80).OrderByDescending(n => n);







            //EJERCICIO 2
            string sentence = "the quick brown fox jumps over the lazy dog";

            string[] palabras = sentence.Split(' ');

            //Obtener palabras con +3 letras
            //Consulta
            IEnumerable<string> pal = from palabra in palabras
                                      where palabra.Length > 3
                                      select palabra;

            recorrerConsultas(pal);







            //EJERCICIO 3
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable<int> pares = from num in numeros
                                     where num%2 == 0
                                     orderby num ascending
                                     select num;

            recorrerConsultas(pares);







            //EJERCICIO 4
            List<Estudiante> estudiantes = new()
            {
            new("Valeska",  21, "Negocios"),
            new("Luis", 19, "Diseño"),
            new("Eva",  19, "Sistemas"),
            new("Marco",21, "Medicina"),
            new("Damin",22, "Sistemas"),
            new("Lucas",21, "Diseño"),
            new("Alejandro",21, "Diseño"),
            new("Ana",18, "Diseño"),
            new("Jose",19, "Medicina"),
            new("Pedro",22, "Sistemas"),

            };


            //Utilizar IEnumerable cuando quiero devolver el objeto completo
            IEnumerable<Estudiante> query = from e in estudiantes
                                            where e.carrera == "Sistemas"
                                            orderby e.edad
                                            select e;
                                          //select new {e.nombre, e.edad}; --> si solo se quiere devolver propiedades específicas.
            recorrerConsultas(query);
            Console.WriteLine("\n");


            //Utilizar var cuando solo quiero devolver ciertas propiedas del objeto.
            var query2 = estudiantes.Where(e => e.carrera == "Sistemas").OrderBy(e => e.edad).Select(e => new { e.nombre, e.edad });
            recorrerConsultas(query2);
            Console.WriteLine("\n");






            //USO DE GROUPBY PARA AGRUPAR ESTUDIANTES POR CARRERA
            var query3 = estudiantes.
                            GroupBy(e => e.carrera).
                            Select(g => new { 
                                              carrera = g.Key, 
                                              alumnos = g.ToList(),
                                              totalEstudiantes = g.Count(),
                                              menores = g.Where(e => e.edad < 20).ToList()
                            });



            //Para mostrar los estudiantes por carrera se debe usar un foreach anidado
            foreach (var grupos in query3)
            {
                Console.WriteLine(grupos.carrera + $" --> Total estudiantes:{grupos.totalEstudiantes}");

                foreach(var alumno in grupos.alumnos)
                {
                    Console.WriteLine("- " + $"Nombre: {alumno.nombre}, Edad: {alumno.edad}");
                }
            }






            //Funcion para iterar sobre los query
            void recorrerConsultas<T>(IEnumerable<T> query)
            {
                foreach (var q in query)
                {
                    Console.WriteLine(q);
                }
            }

            Console.ReadKey();
        }
    }
}
