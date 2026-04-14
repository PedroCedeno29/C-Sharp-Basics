using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Models
{
    public abstract class Producto
    {
        public string Codigo;
        public string Marca { get; set; }
        public int Cantidad { get; private set; }
        private double Precio { get; set; }
        public double Peso { get; set; }


        public Producto()
        {
            Codigo = "";
            Marca = "";
            Cantidad = 0;
            Precio = 0;
        }



        public Producto(string codigo, string marca)
        {
            Codigo = codigo;
            Marca = marca;
        }



        public Producto(string codigo, string marca, int cantidad, double precio)
        {
            Codigo = codigo;
            Marca = marca;
            Cantidad = cantidad;
            Precio = precio;
        }


        public abstract void Encender();
        public virtual void Apagar()
        {
            Console.WriteLine("Apagando...");
        }


    }
}
