using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.Title = "Mi programa";
            //Creación de una aplicación para el Contoso Petting Zoo que coordina las visitas escolares.
           
            string[] pettingZoo =
            {
                "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
                "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
                "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
            };

            string[,] groups = AssignGroup(pettingZoo);
            Console.WriteLine("School A");
            printGroup(groups);
            Console.WriteLine("\n");

            Console.WriteLine("School B");
            randomizeAnimals(pettingZoo);
            groups = AssignGroup(pettingZoo, 3);
            printGroup(groups);
            Console.WriteLine("\n");

            Console.WriteLine("School C");
            RandomizeAnimals(pettingZoo);
            groups = AssignGroup(pettingZoo, 2);
            printGroup(groups);

            Console.ReadKey();
        }


        public static string[] randomizeAnimals(string[]animals)
        {
            for(int i=0; i<animals.Length; i++)
            {
                string temp = animals[i];
                animals[i] = animals[animals.Length - 1];
                animals[animals.Length - 1] = temp;
            }
            return animals;
        }

        public static string[,] AssignGroup(string[] array, int cantidadGrupos = 6)
        {
            int cantAnimales = array.Length;
            int columnas = cantAnimales / cantidadGrupos;
            string[,] grupos = new string[cantidadGrupos, columnas];

            for(int i=0; i<cantidadGrupos; i++)
            {
                for(int j= 0; j<columnas; j++)
                {
                    grupos[i, j] = array[(i * 3) + j];

                }
            }

            return grupos;
        }

        public static void printGroup(string[,]array)
        {
            int count = 1;
            for(int i=0; i<array.GetLength(0); i++)
            {
                Console.Write($"Grupo {count}: ");
                for(int j=0; j<array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
                count++;
            }
        }
        //OTRA FORMA DE CAMBIAR LA POSICION DE LOS ANIMALES DENTRO DE LA MATRIZ, USANDO RANDOM.
        public static void RandomizeAnimals(string[]pettingZoo)
        {
            Random random = new Random();

            for (int i = 0; i < pettingZoo.Length; i++)
            {
                int r = random.Next(i, pettingZoo.Length);

                string temp = pettingZoo[r];
                pettingZoo[r] = pettingZoo[i];
                pettingZoo[i] = temp;
            }
        }

    }
}
