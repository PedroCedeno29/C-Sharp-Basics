using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Models
{
    public class Laptop : Producto
    {
        //Propiedades
        public string Procesador { get; set; }
        public string SistemaOperativo { get; set; }
        public string AlmacenamientoInterno { get; set; }  


        //Constructores
        public Laptop(string codigo, string nombre, int cantidad, double precio, string procesador, string so, string almacenamientoInterno ) : base(codigo, nombre, cantidad, precio)
        {
            Procesador = procesador;
            SistemaOperativo = so;
            AlmacenamientoInterno = almacenamientoInterno;
        }


        //Métodos
        public override void Encender()
        {
            Console.WriteLine("La laptop esta encendiendo...");
        }

        public override void Apagar()
        {
            Console.WriteLine("La laptop se esta apagando...");
        }
    }
}
