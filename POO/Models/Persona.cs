using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Models
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public Persona()
        {
            Nombre = "";
            Apellido = "";
            Edad = 0;
        }

        public Persona(string nombre, string apellido, int edad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }

        public void Saludar()
        {
            Console.WriteLine("Hola!");
        }
    }
}
