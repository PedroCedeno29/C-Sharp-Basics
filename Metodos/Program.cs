using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Metodos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MÉTODOS
            //Parametro -- Es la variable que se pasa entre los corchetes de un metodo
            //Argumento --> Es el valor que se pasa cuando se llama al metodo

            //Se pueden metodos en cualquier momento tantas veces como sea necesario usarlo, dentro de instrucciones if-else, bucles for, switch.

            //Void --> No devuelve nada, solo ejecuta acciones, como imprimir un resultado o modificar un array o lista, validar y ejecutar lógica.


            double total = 0;
            double minimumSpend = 30.00;

            double[] items = { 15.97, 3.50, 12.25, 22.99, 10.98 };
            double[] discounts = { 0.30, 0.00, 0.10, 0.20, 0.50 };

            for (int i = 0; i < items.Length; i++)
            {
                total += GetDiscountedPrice(i);
            }

            total -= TotalMeetsMinimum() ? 5.00 : 0.00;

            Console.WriteLine($"Total: ${FormatDecimal(total)}");

            double GetDiscountedPrice(int itemIndex)
            {
                return items[itemIndex] * (1 - discounts[itemIndex]);
            }

            bool TotalMeetsMinimum()
            {
                return total >= minimumSpend;
            }

            string FormatDecimal(double input)
            {
                return input.ToString().Substring(0, 5);
            }

            //PROYECTO - JUEGOS DE DADOS
            Console.WriteLine("Desea jugar a los dados?\n Ingrese \"s\" para \"Si\" y \"n\" para \"No\"");
            string resp = Console.ReadLine().ToLower().Trim();
            
            while (play(resp))
            {
                int resultadoDados = dados();
                if(resultadoDados > 5)
                {
                    Console.WriteLine("Wow! Obtuvo el número mayor. Gano el juego!!!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Ups! no alcanzo el número mayor (6). Su resultado fue: {resultadoDados}.\nDesea jugar otra vez? Y/N");
                    resp = Console.ReadLine().ToLower().Trim();
              
                
                }
            }

            int dados()
            {
                Random random = new Random();
                return random.Next(1, 7);
            }

            bool play(string input)
            {
                if (input == "s")
                {
                    return true;
                }
                else { return false; }
            }



            //CODIGO PARA INVERTIR UNA PALABRA
            Console.WriteLine("Por favor ingrese una palabra para ser invertida:");
            string pal = Console.ReadLine();
            Console.WriteLine(invertWord(pal));

            string invertWord(string w)
            {
                string invertida = new string(w.Reverse().ToArray());
                return invertida;
            }



            //DEVOLUCIÓN DE MATRICES CON MÉTODOS
            int[] monedas = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };
            Console.WriteLine("Ingrese un valor numérico:");
            int num10 = int.Parse(Console.ReadLine());
            int [] resultadoo = monedasDev(monedas, num10);
            if(resultadoo.Length == 0)
            {
                Console.WriteLine("No se encontraron 2 monedas que devuelvan su valor ingresado");
            }
            else
            {
                Console.WriteLine($"Las monedas son: {resultadoo[0]} y {resultadoo[1]}");
            }

                int[] monedasDev(int[] arrMonedas, int val)
                {
                    int n = arrMonedas[0];
                    int result = 0;

                    for (int i = 0; i < arrMonedas.Length; i++)
                    {
                        for (int j = i + 1; j < arrMonedas.Length; j++)
                        {
                            if (arrMonedas[i] + arrMonedas[j] == val)
                            {
                                return new int[] { arrMonedas[i], arrMonedas[j] };
                            }
                        }
                    }
                    return new int[0];
                }



            //MÉTODO PARA INVERTIR UNA ORACION
            Console.WriteLine("Por favor ingrese una oracion para ser invertida:");
            string oracion1 = Console.ReadLine();
            Console.WriteLine(invertSentence(oracion1));


            string invertSentence(string sentence)
            {
                string[] words = sentence.Split(' ');
                string oracionInvertida = "";

                foreach(string w in words)
                {
                    string inversa = new string(w.Reverse().ToArray());
                    oracionInvertida += inversa + " ";
                }
                return oracionInvertida;
            }



            //CODIGO PARA HACER LA CONVERSION DE USD A VND
            Console.WriteLine("Ingrese la cantidad de USD que desea convertir a VND:");
            int valor1 = int.Parse(Console.ReadLine());
            Console.WriteLine($"${valor1} equivale a: " + vndConversor(valor1));

            int vndConversor(int usd)
            {
                int rate = 23500;
                return usd * rate;
            }



            //Desafío de código: agregar un método para mostrar direcciones de correo electrónico
            string[,] corporate =
            {
                {"Robert", "Bavin"}, {"Simon", "Bright"},
                {"Kim", "Sinclair"}, {"Aashrita", "Kamath"},
                {"Sarah", "Delucchi"}, {"Sinan", "Ali"}
            };

            string[,] external =
            {
                {"Vinnie", "Ashton"}, {"Cody", "Dysart"},
                {"Shay", "Lawrence"}, {"Daren", "Valdes"}
            };

            string internalDomain = "contoso.com";
            string externalDomain = "hayworth.com";

            for(int i=0; i<corporate.GetLength(0); i++)
            {
                displayEmail(corporate[i, 0], corporate[i, 1], internalDomain);
            }

            for (int i = 0; i < external.GetLength(0); i++)
            {
                displayEmail(external[i, 0], external[i, 1], externalDomain);
            }

            void displayEmail(string first, string last, string domain)
            {
                string correo = first.Substring(0, 2) + last;
                correo = correo.ToLower().Trim();
                Console.WriteLine($"{correo}@{domain}");
            }


            //List<string> internos = new List<string>();
            //List<string> externos = new List<string>();
          

            //correos(corporate, internos, internalDomain);
            //showCorreos(internos);
            //correos(external, externos, externalDomain);
            //showCorreos(externos);

            //void correos(string[,] arregloPersonal, List<string> lista, string domain)
            //{
            //    for(int i = 0; i < arregloPersonal.GetLength(0); i++){
            //        for (int j=0; j < arregloPersonal.GetLength(1); j++)
            //        {
            //            string palabra = "";
            //            palabra = arregloPersonal[i, j] + domain;
            //            palabra = palabra.ToLower().Trim();
            //            lista.Add(palabra);
            //        }
            //    }
            //}

            //void showCorreos(List<string>correosPersonal)
            //{
            //    foreach(string personal in correosPersonal)
            //    {
            //        Console.WriteLine(personal);
            //    }
            //}
           

            //PRACTICA - Creación de una aplicación RSVP
            string[] guestList = { "Rebecca", "Nadia", "Noor", "Jonte" };
            string[] rsvps = new string[10]; //Max 10 invitados con reserva
            int count = 0;

            RSVP("Pedro", 2, "none", true);
            RSVP("Jonte", 3, "none", true);
            RSVP("Nadia", 5, "none", true);
            //ARGUMENTOS CON NOMBRE --> SE PUEDEN PASAR EN CUALQUIER ORDEN SIEMPRE Y CUANDO SE ESPECIFIQUE EL NOMBRE DEL PARÁMETRO
            RSVP(partySize: 4, name: "Sebastian", inviteOnly: true, allergies: "none");
            

            showRSVP(rsvps);

            void RSVP(string name, int partySize, string allergies, bool inviteOnly)
            {
                bool esInvitado = false;
                if (inviteOnly)
                {
                    for(int i = 0; i < guestList.Length; i++)
                    {
                        if (guestList[i] == name)
                        {
                                rsvps[count] = $"name: {name}, party size: {partySize}, allergies: {allergies}";
                                count++;
                                esInvitado = true;

                            
                        }
                    }

                    if(!esInvitado) { Console.WriteLine($"{name} no se encuentra en la lista de invitados."); }
                }
            }

            //PARAMETROS OPCIONALES --> CUANDO SE LA ASIGNA UN VALOR PREDETERMINADO EN LA FIRMA DEL METODO. SI SE OMITE UN 
            //PARAMETRO OPCIONAL DE LOS ARGUMENTOS,SE USA EL VALOR PREDETERMINADO CUANDO SE EJECUTA EL MÉTODO.

            //void RSVP(string name, int partySize = 1, string allergies = "none", bool inviteOnly = true)

            void showRSVP(string[] rsvp)
            {
                foreach(string s in rsvp)
                {
                    Console.WriteLine(s);
                }
            }

            //Ejercicio 6 - Métodos:
            //Crea un método que reciba un array de números enteros y devuelva el mayor, el menor y el promedio.
            int[] array = { 1, 4, 20, 3, 5, 7 };
            ejercicioArray(array);



            Console.WriteLine("Ingrese un numero");
            int num = int.Parse(Console.ReadLine());
            Count(num);
            Console.WriteLine("\n");

            //Math.Abs() --> Devuelve el valor absoluto de un número, es decir, siempre devuelve el valor positivo sin importar
            //               si el número es negativo.

            int[] schedule = { 800, 1200, 1600, 2000 };
            DisplayAdjustedTimes(schedule, 5, -5);
            Console.WriteLine("\n");

            int[] numeros = { 1, 2, 3 };

            string[] nombres = { "Pedro", "Jose", "Moi" };
            RecorrerArreglo(nombres);


            // DATOS POR TIPO DE VALOR Y REFERENCIA
            // TIPO DE VALOR --> CHAR, BOOL, INT, FLOAT, DOUBLE
            // TIPO POR REFERENCIA --> STRING, ARRAY Y OBJETOS 

            //LOS QUE SON POR REFERNCIA NO ALMACENAN SU VALOR DIRECTAMENTE SINO QUE ALMACENAN UNA DIRECCION DONDE ALMACENAN SU VALOR.

            string status = "Healthy";

            Console.WriteLine($"Start: {status}");
            SetHealth(status, false);
            Console.WriteLine($"End: {status}\n");


            //EJERCICOS DE LOGICA DE PROGRAMACIÓN

            //Ejercicio 1 - Strings y métodos:
            //Pide al usuario que ingrese una oración.Muestra cuántas palabras tiene, toda la oración en mayúsculas y sin espacios extremos.
            Console.WriteLine("Ingrese una oración:");
            string oracion = Console.ReadLine();
            oracion = oracion.ToUpper().Trim().Replace(" ","");
            int longitudOracion = oracion.Length;
            Console.WriteLine($"Su oración tiene:{longitudOracion} caracteres\nOración en Mayúsculas y sin espacios: {oracion}");


            //Ejercicio 2 - Arrays:
            //Crea un array con 5 nombres, recórrelo con un for y muestra solo los nombres que tengan más de 4 letras.
            string[] nombres1 = { "Pedro", "Jose", "Joseph", "Saul", "Omar", "Sebastián" };
            Console.WriteLine(nombres1.Length);

            for(int i=0; i<nombres1.Length; i++)
            {
                if(nombres1[i].Length > 4)
                {
                    Console.WriteLine(nombres1[i]);
                }
            }

            Console.WriteLine("\n");


            //Ejercicio 3 - Bucles:
            //Haz un programa que pida números al usuario hasta que ingrese el número 0, luego muestre la suma total de todos los números ingresados.
            bool esCero = false;
            int numIngresado = 0;
            string valor = "";
            do
            {
                Console.WriteLine("Ingrese cualquier número: ");
                valor = Console.ReadLine();
                if(int.TryParse(valor, out int numero)){
                    
                    if(numero == 0)
                    {
                        esCero = true;
                    }
                    else
                    {
                        numIngresado += numero;
                    }
                }
                else
                {
                    Console.WriteLine("El valor ingresado no es del tipo correcto. Por favor ingrese un valor numérico.\n");
                }
            } while (esCero == false);
            Console.WriteLine("La suma de sus números ingresados es: " + numIngresado);


            //Ejercicio 4 - Listas:
            //Crea una lista de productos, permite al usuario agregar productos, eliminarlos por nombre y mostrar la lista actualizada, todo dentro de un menú con opciones.
            Console.WriteLine("\n");
            List<string> productos = new List<string> {"arroz", "pollo", "queso"};
            bool finMenu = false;
            int numRespuesta = 0;
            do
            {
                Console.WriteLine("Seleccione una opcón:\n1)Agregar productos\n2)Eliminar producto por nombre\n3)Mostrar lista actualizada de productos\n4)Salir del menú\n");
                string respuesta = Console.ReadLine();
                
                if(int.TryParse(respuesta, out int number))
                {
                    if(number > 0 && number <= 4)
                    {
                        string productoNuevo = "";

                        switch (number)
                        {
                            case 1:
                                Console.WriteLine("Ingrese el nombre del producto:");
                                productoNuevo = Console.ReadLine();
                                productoNuevo = productoNuevo.ToLower().Trim();
                                productos.Add(productoNuevo);
                                break;
                            case 2:
                                Console.WriteLine("Ingrese el nombre del producto que desea eliminar:");
                                productoNuevo = Console.ReadLine();
                                productoNuevo = productoNuevo.ToLower().Trim();
                                for (int i = 0; i < productos.Count; i++)
                                {
                                    if (productos[i] == productoNuevo)
                                    {
                                        productos.RemoveAt(i);
                                    }
                                }
                                break;
                            case 3:
                                foreach (string producto in productos)
                                {
                                    Console.WriteLine("-" + producto + "\n");
                                }
                                break;
                            case 4:
                                finMenu = true;
                                break;
                        }
                    }
                    else { Console.WriteLine("Por favor ingrese un numero entre el 1 y 4."); }
                }
                else { Console.WriteLine("Por favor ingrese 1,2 o 3\n"); }

            } while (finMenu == false);

            Console.WriteLine("\n");



            //Ejercicio 5 - Strings y lógica:
            //Pide una cadena al usuario y determina si es un palíndromo(se lee igual al derecho y al revés).Ejemplo: "ana" → es palíndromo.
            Console.WriteLine("Ingrese una palabra para verificar si es palíndroma:");
            string word = Console.ReadLine().ToLower().Trim();

            string palabraInvertida = new string(word.Reverse().ToArray());
            if(palabraInvertida == word)
            {
                Console.WriteLine($"Tu palabra es palíndroma: {word} == {palabraInvertida}");
            }
            else { Console.WriteLine("Tu palabra no es palíndroma"); }
            Console.WriteLine("\n");



            bool fin = false;
            bool contieneNum = false;
            bool contieneMayus = false;
            bool sinEspacios = false;

            do
            {

                Console.WriteLine("Ingrese una contraseña. Esta debe contener:\n-Minimo 8 caracteres\nAl menos un numero\nAl menos una mayuscula\nSin espacios");
                string clave = Console.ReadLine();
                if (clave.Length < 8)
                {
                    Console.WriteLine("La contraseña debe contener mínimo 8 caracteres");
                }
                else
                {
                    foreach (char c in clave)
                    {
                        if (char.IsDigit(c))
                        {
                            contieneNum = true;
                        }
                        if (char.IsUpper(c))
                        {
                            contieneMayus = true;
                        }
                        if (c != ' ')
                        {
                            sinEspacios = true;
                        }
                    }

                    if (contieneNum && sinEspacios && contieneMayus)
                    {
                        Console.WriteLine("Su contraseña cumple con los requisitos.");
                        fin = true;

                    }
                    else
                    {
                        Console.WriteLine("Su contraseña no cumple con los requisitos. Por favor vuelva a ingresar una nueva.");
                    }
                }
            } while (fin == false);


            //SE DEBE REASIGNAR EL VALOR A UNA VARIABLE CUANDO SE INVOCA A UN METODO QUE CAMBIA SU VALOR ORIGINAL.
            int x = 5;

            x = ChangeValue(x);

            Console.WriteLine(x);

            int ChangeValue(int value)
            {
                return value = 10;
            }



            Console.ReadKey();
        }

        //C# Permite el uso de parámetros con nombre y opcionales. Estos parámetros permiten seleccionar que argumentos desea proporcionar
        //al método, por lo que no está restringido a la estructura definida en la firma el método.
        
  
        public static void SetHealth(string status, bool isHealthy)
        {
            status = (isHealthy ? "Healthy" : "Unhealthy");
            Console.WriteLine($"Middle: {status}");
        }

        public static void Count(int max)
        {
            for (int i = 0; i < max; i++)
            {
                Console.Write(i + " ");
            }
        }

        //Metodo para modificar la zona horaria
        public static void DisplayAdjustedTimes(int[] times, int currentGMT, int newGMT)
        {
            int diff = 0;
            if (Math.Abs(newGMT) > 12 || Math.Abs(currentGMT) > 12)
            {
                Console.WriteLine("Invalid GMT");
            }
            else if (newGMT <= 0 && currentGMT <= 0 || newGMT >= 0 && currentGMT >= 0)
            {
                diff = 100 * (Math.Abs(newGMT) - Math.Abs(currentGMT));
            }
            else
            {
                diff = 100 * (Math.Abs(newGMT) + Math.Abs(currentGMT));
            }

            for (int i = 0; i < times.Length; i++)
            {
                int newTime = (times[i] + diff) % 2400;
                Console.WriteLine($"{times[i]} -> {newTime}");
            }
        }

        public static void RecorrerArreglo(string[] array)
        {
            foreach(string palabra in array)
            {
                Console.WriteLine(palabra);
            }
        }

        public static void ClearArray(int[] array)
        {
            for(int i=0; i<array.Length; i++)
            {
                array[i] = 0;
            }

        }

        public static void ejercicioArray(int[] array)
        {
            int longitud = array.Length;
            int ultimaPos = longitud - 1;
            int numeros = 0;
            for(int i=0; i<array.Length; i++) {
             
                numeros += array[i];
            }
            Console.WriteLine("El promedio es: " + ((double)numeros / longitud)); //Se usa double para hacer la conversión de int a double.
            Array.Sort(array);
            Console.WriteLine("El número menor es: " + array[0] + " El número mayor es: "+ array[ultimaPos]);

        }
    }
}
