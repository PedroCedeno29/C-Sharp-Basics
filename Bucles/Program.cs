using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucles
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            bool estado = false;
            //While --> Se ejecuta si se cumple una condición desde el principio.
            while (estado)
            {
                // si condicion es false desde el inicio, nunca entra
            }



            //Do-While --> Siempre se ejecuta al menos una vez
            do
            {
                // Siempre entra al menos una vez, luego evalúa
            } while (estado);




            //Listas --> Son de tamaño dinámico, se puede agregar y eliminar elementos libremente.
            List<string> nombres = new List<string> { "Pepe", "Joseph" };

            //Declaración con valores
            List<string> ejemplo = new List<string>() { "carro", "moto", "avion" };

            //Agregar elementos a una lista
            nombres.Add("Pedro");
            nombres.Add("José");
            nombres.Add("Peter");

            //Foreach se usa cuando solo se quiere leer los elementos sin complicarse.
            foreach (string nombre in nombres)
            {
                Console.WriteLine(nombre);
            }

            //Usando una función para recorrer la lista
            //RecorrerLista(nombres);

            Console.WriteLine("\n");
            //Eliminar elementos de una lista
            nombres.Remove("José");
            nombres.RemoveAt(1); //Eliminar desde una posición específica




            //LISTA DE ENTEROS
            List<int> enteros = new List<int> { 100, 200, 300 };
            enteros.Add(400);
            RecorrerLista(enteros);


            //RECORRER LISTA USANDO FOR --> SE USA COUNT
            for(int i=0; i<enteros.Count; i++)
            {
                Console.WriteLine(enteros[i]);
            }




            int[] array = { 1, 2, 3 };

            //For --> Tiene 3 argumentos, incialización, condición y el paso (cuantas veces va a incrementar o decrementar).
            // A diferencia del Foreach, el bucle for permite el control total del indice, tambien permite modificar elementos facilmente.

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);

            }
            Console.WriteLine("\n");


            for(int i=array.Length - 1; i>= 0; i--)
            {
                Console.WriteLine(array[i]);
            }


            //Funcion de tipo genérico
            void RecorrerLista<T>(List<T> lista)
            {
                foreach(var valor in lista)
                {
                    Console.WriteLine(valor);
                }
            }

            Console.ReadKey();

        }
    }
}
