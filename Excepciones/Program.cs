using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Excepciones
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //LAS EXCEPCIONES PERMITEN CAPTURAS ERRORES EN TIEMPO DE EJECUCIÓN Y CONTROLARLOS A TIEMPO, SIN QUE SE TERMINE O CIERRE EL PROGRAMA.    


            //TRY --> CONTIENE EL CODIGO QUE PUEDE ARROJAR UNA EXCEPCION
            //CATCH --> CONTROLA DICHA EXCEPCION. SE PUEDE USAR SIN FILTRO DE EXCEPCION PERO PUEDE CAPTURAR CUALQUIER EXCEPCION Y NO TENER
            //          INFORMACIÓN MAS DETALLADA.


            //HAY DIFERENTES FILTROS DE EXCEPCION:
            //GENERAL --> VIENE A SER CATCH(Exception ex){}
            //ESPECIFICO --> CAPTURA SOLO UN TIPO DE EXCEPCION = catch(DivideByZeroException ex){}



            //CREACIÓN Y CONFIGURACIÓN DE EXCEPCIONES PERSONALIZADAS
            //El proceso para iniciar un objeto de excepción implica crear una instancia de una clase derivada de excepciones, 
            //configurar opcionalmente las propiedades de la excepción y, a continuación, iniciar el objeto mediante la palabra clave throw.


            //throw --> se usa cuando uno mismo quiere lanzar una excepcion manualmente sin esperar que C# la genere sola.
            //          se usa cuando C# no puede detectar el error por sí solo porque es una regla de tu negocio o lógica, no un error del lenguaje.



            //Forma larga de crear una instancia de una excepcion. Esto se usa cuando se quiere guardarla en una variable para luego hacer algo con ella
            //como almacenarla en un log.
            //FormatException miExcepcion = new FormatException("Mi error personalizado");
            //throw miExcepcion;


            Console.WriteLine("Ingrese el monto a retirar:");
            string montoRetiro = Console.ReadLine();
            bool exit = false;
            do
            {

                try
                {
                    
                    RetirarDinero(montoRetiro);
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine("Un error ha ocurrido:");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Ingrese una cantidad menor para retirar o escriba \"salir\" para terminar:");
                    montoRetiro = Console.ReadLine().ToLower().Trim();

                    if (montoRetiro.Contains("salir"))
                    {
                        exit = true;
                    }
                    else
                    {
                        exit = false;
                    }
                }



            } while (!exit);

            Console.WriteLine("Buen dia. Gracias por preferirnos.");

            void RetirarDinero(string money)
            {
                int montoD = int.Parse(money);
                int saldo = 100;
                if (montoD > saldo)
                {
                    InvalidOperationException montoInsuficiente = new InvalidOperationException("No tiene saldo suficiente para hacer este retiro");
                    throw montoInsuficiente;
                }
                //throw new InvalidOperationException("No tiene saldo suficiento para hacer este retiro");

                Console.WriteLine("Retiro exitoso");
                Console.WriteLine("Su saldo disponible ahora es de: " + (saldo - montoD));
                exit = true;
            }






            //EJERCICIO
            Console.WriteLine("Ingrese su codigo");
            string code = Console.ReadLine();

            try
            {
                BusinessProcess1(code);
            }
            catch(FormatException ex) //El argumento puede ser especifico o general, pero si solo vamos a manejar un tipo de excepcion se recomienda que sea especifico usando FormatException
            {
                Console.WriteLine(ex.Message);
            }

            //FORMA DE CAPTURAR EXCEPCIONES PERSONALIZADAS.
            void BusinessProcess1(string userEntries)
            {
                
                    try
                    {
                        int valueEntered = int.Parse(userEntries);  // puede fallar con "two"
                    }
                    catch (FormatException)
                    {
                        // Captura el error de formato de C#
                        // Crea una nueva excepción con mensaje personalizado
                        FormatException miExcepcion = new FormatException("Los valores deben ser enteros válidos");

                        // La lanza hacia arriba en la pila de llamadas
                        throw miExcepcion;
                    }
            }


            //Excepciones comunes que puedes lanzar de forma corta

            // Argumento inválido
            //throw new ArgumentException("El nombre no puede estar vacío");

            //Argumento nulo
            //throw new ArgumentNullException("El parámetro no puede ser null");

            //Operación inválida
            //throw new InvalidOperationException("No puedes retirar más de lo que tienes");

            //Índice fuera de rango
            //throw new IndexOutOfRangeException("El índice no existe");

            //Formato incorrecto
            //throw new FormatException("El formato del dato es incorrecto");



            // La excepcion personalizada (con throw) se debe manejar con try-catch. Se debe usar el try-catch obligatoriamente para manejar
            //la excepcion ya que sin el try-catch el programa se crashea y muestra un error feo en pantalla.
            try
            {
                Retirar(100, 500);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);  // "Saldo insuficiente"
            }


            void Retirar(double saldo, double monto)
            {
                // C# no sabe que esto es un error, para él es solo una resta
                // TÚ debes indicarle que es una condición inválida con throw
                if (monto > saldo)
                    throw new Exception("Saldo insuficiente");

                saldo -= monto;
                Console.WriteLine("Retiro exitoso");
            }




            try
            {
                int num1 = int.MaxValue;
                int num2 = int.MaxValue;
                int result = num1 + num2;
                Console.WriteLine("Result: " + result);

                string str = null;
                int length = str.Length;
                Console.WriteLine("String Length: " + length);

                int[] numbers = new int[5];
                numbers[5] = 10;
                Console.WriteLine("Number at index 5: " + numbers[5]);

                int num3 = 10;
                int num4 = 0;
                int result2 = num3 / num4;
                Console.WriteLine("Result: " + result2);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error: The number is too large to be represented as an integer." + ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Error: The reference is null." + ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Error: Index out of range." + ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: Cannot divide by zero." + ex.Message);
            }

            Console.WriteLine("Exiting program.");



            //TIPOS DE EXCEPCIONES ESPECÍFICAS CON FILTRO
            try
            {
                int[] array = { 1, 2, 3 };
                int resultado = array[10];         // IndexOutOfRangeException
                //int division = 10 / 0;            // DivideByZeroException
                int numero = int.Parse("abc");    // FormatException
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Índice fuera de rango: " + ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("No se puede dividir entre cero: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Formato incorrecto: " + ex.Message);
            }
            catch (Exception ex)
            {
                // catch general → captura cualquier excepción no manejada arriba
                Console.WriteLine("Error inesperado: " + ex.Message);
            }






            //EJERCICIO 1
            try
            {
                Process1();
            }
            catch
            {
                Console.WriteLine("An exception has occurred.");
            }

            Console.WriteLine("Exit program");


            //EJERCICIO 2
            double float1 = 3000.0;
            double float2 = 0.0;
            int number1 = 3000;
            int number2 = 0;

            //Aunque la excepcion se produzca dos niveles en la pila de llamadas, igual se controla correctamente.
            try
            {
                Console.WriteLine(number1 / number2);

                //Console.WriteLine(float1 / float2);
                Console.WriteLine(float1 / float2);
               

            }
            catch
            {
                Console.WriteLine("An exception has been caught");
            }

            Console.WriteLine("Exit program");



            //checked{}  --> sirve para detectar desbordamientos aritméticos (overflow) y lanza una excepcion cuando un valor excede
            //               el rango del tipo de dato.


            //Overflow  --> Se da cuando se intenta guardar un valor más grande de lo que el tipo de dato puede almacenar. Por ejemplo
            //              si se quiere almacenar 3000 en una variable de tipo "byte" no se va a poder ya que solo permite hasta 255, entonces
            //              el compilador trunca el valor silenciosamente (esto es incorrecto) y no lanza una excepcion, pero si se usa checked
            //              se lanza una exepcion de tipo "OverFlowException".




            Console.WriteLine("Ingrese su codigo:");
            string codigo = Console.ReadLine();

            try
            {
                int.Parse(codigo);  // si falla, va al catch
            }
            catch (FormatException)
            {
                // capturas el error de C# y lanzas el tuyo personalizado
                throw new FormatException("Mi error personalizado");
            }

            Console.WriteLine("Continuación del programa");



            Console.ReadKey();
        }

        public static void Process1()
        {
            try 
            {
                WriteMessage();
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine($"Exception caught in Process1: {ex.Message}");
            }

        }


        //Este metodo no termina de ejecutarse (la parte del checked) ya que se dtecta una excepcion antes de esto y se debe controlar
        //mediante el catch, pero el resto programa sigue ejecutandose.
        public static void WriteMessage()
        {
            double float1 = 3000.0;
            double float2 = 0.0;
            int number1 = 3000;
            int number2 = 0;
            byte smallNumber;

            Console.WriteLine(float1 / float2);
            Console.WriteLine(number1 / number2);
            checked
            {
                try
                {
                    smallNumber = (byte)number1;

                }
                catch(OverflowException ex) 
                {
                    Console.WriteLine($"Exception caught: {ex.Message}");
                }
            }
        }
    }
}
