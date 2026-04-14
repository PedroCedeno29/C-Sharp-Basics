using POO.Models;
namespace POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Formas de instanciar un objeto:
            //1)
            var persona1 = new Persona();
            persona1.Nombre = "Pedro";
            persona1.Apellido = "Cedeño";
            persona1.Edad = 22;
            persona1.Saludar();
            Console.WriteLine($"{persona1.Nombre}");


            //2)
            var persona2 = new Persona("Jose", "Idrovo", 22);
            Console.WriteLine($"Nombre: {persona2.Nombre}, Apellido: {persona2.Apellido}, Edad: {persona2.Edad}");



            //PRODUCTOS
            var laptop1 = new Laptop("L01", "HP Pavilion", 10, 850.80, "Intel Core I9", "Windows 11", "1TB");
            laptop1.Encender();
            laptop1.Apagar();

            var celular1 = new Celular("C01", "SAMSUNG", "S30", "50mpx", "Negro");
            celular1.Encender();
            celular1.Apagar();


            Console.ReadKey();

        }
    }
}
