using POO.Models;

public class Celular : Producto
{
    public string Modelo { get; set; }
    public string Camara { get; set; }
    public string Color { get; set; }

    public Celular(string codigo, string nombre, string modelo, string camara, string color) : base(codigo, nombre)
    {

        Modelo = modelo;
        Camara = camara;
        Color = color;
    }

    public override void Encender()
    {
        Console.WriteLine("El celular esta encendiendo...");
    }

    public override void Apagar()
    {
        Console.WriteLine("El celular se esta apagando...");
    }
}