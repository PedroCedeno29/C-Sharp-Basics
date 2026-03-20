using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ARREGLOS
            //1. Declaración e Inicialización
            // Solo declarar (sin valores, todos en 0/null por defecto)
            int[] numeros = new int[5];  // Arreglo de 5 enteros

            // Declarar e inicializar con valores
            int[] edades = new int[] { 18, 25, 30, 22, 17 };

            // Forma corta (el compilador infiere el tamaño)
            int[] precios = { 100, 200, 300, 400 };

            // Declarar primero, asignar después
            string[] nombres;
            nombres = new string[3];





            //2.Acceder y Modificar Elementos
            int[] numeros1 = { 10, 20, 30, 40, 50 };

            // Leer un elemento
            Console.WriteLine(numeros1[0]);  // 10
            Console.WriteLine(numeros1[2]);  // 30

            // Modificar un elemento
            numeros1[1] = 99;
            Console.WriteLine(numeros1[1]);  // 99

            // Último elemento
            Console.WriteLine(numeros1[numeros1.Length - 1]);  // 50



            //3. Recorrer un Arreglo
            int[] notas = { 85, 90, 78, 95, 88 };

            // Con for clásico
            for (int i = 0; i < notas.Length; i++)
            {
                Console.WriteLine($"Nota {i}: {notas[i]}");
            }

            // Con foreach (más limpio, solo lectura)
            foreach (int nota in notas)
            {
                Console.WriteLine(nota);
            }



            //4. Propiedades y Métodos Útiles

            int[] nums = { 5, 2, 8, 1, 9, 3 };

            Console.WriteLine(nums.Length);       // 6 → cantidad de elementos

            Array.Sort(nums);                     // Ordena: { 1, 2, 3, 5, 8, 9 }
            Array.Reverse(nums);                  // Invierte: { 9, 8, 5, 3, 2, 1 }

            int pos = Array.IndexOf(nums, 5);     // Busca el índice del valor 5
            Console.WriteLine(pos);              // 2
            Console.Write("\n");

            int[] ejercicio = { 1, 90, 6, 4, 3, 75 };
            Console.WriteLine("Longitud del arreglo: " + ejercicio.Length);
            Console.WriteLine("1era Forma de invertir un arreglo:");
            Console.Write("|");
            for(int i = ejercicio.Length-1; i >= 0; i--)
            {
                Console.Write(ejercicio[i]);
                Console.Write("|");
            }
            Console.Write("\n");
            Console.WriteLine("2da Forma de invertir un arreglo:");
            Array.Reverse(ejercicio);
            Console.Write("|");
            foreach(int n in ejercicio)
            {
                Console.Write(n + "|");
            }



            Console.Write("\n");

            //MATRICES
            int maxMascotas = 4;
            int columnas = 3;
            string[,] mascotas = new string[maxMascotas, columnas];  //[filas,columnas]
            string nombreM = "";
            int edad = 0;
            string tamaño = "";
            string descripción;

            for (int i = 0; i < maxMascotas; i++)
            {
                switch (i)
                {
                    case 0:
                        nombreM = "max";
                        edad = 2;
                        tamaño = "grande";
                        break;
                    case 1:
                        nombreM = "chopper";
                        edad = 5;
                        tamaño = "pequeño";
                        break;
                    case 2:
                        nombreM = "franky";
                        edad = 8;
                        tamaño = "mediano";
                        break;
                    default:
                        Console.WriteLine("Ingrese el nombre de la mascota: ");
                        nombreM = Console.ReadLine();
                        Console.WriteLine("Ingrese la edad de la mascota: ");
                        edad = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el tamaño de la mascota: ");
                        tamaño = Console.ReadLine();
                        break;
                }

                mascotas[i, 0] = "nombre: " + nombreM;
                mascotas[i, 1] = "edad: " + edad;
                mascotas[i, 2] = "tamaño: " + tamaño;
            }

            //Recorrer los valores de la matriz
            for (int i = 0; i < maxMascotas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Console.Write(mascotas[i, j] + " | ");
                }
                Console.WriteLine("\n");
            }







            //BUSQUEDA DE MASCOTAS POR CARACTERISTICAS
            bool estado = true;

            do
            {
                Console.WriteLine("Bienvenido a Petstore!!!");
                Console.WriteLine("Seleccione una opcion:\n 1) Listar toda la información de nuestras mascotas disponibles.\n " +
                    "2) Display all dogs with specific characteristic.");
                string opcion = Console.ReadLine();


                do
                {
                    if (int.TryParse(opcion, out int num))
                    {
                        if (num == 1 || num == 2) break;
                        else
                            Console.WriteLine("Por favor ingrese 1 0 2.");
                            opcion = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Por favor ingrese 1 0 2.");
                        opcion = Console.ReadLine();
                    }
                } while (true);

                int numero = int.Parse(opcion);
                switch (numero)
                {
                    case 1:
                        ;
                        break;
                    case 2:
                        ;
                        break;

                }


            } while (estado);

            Console.ReadKey();
        }
    }
}
