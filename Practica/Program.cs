using System;
using System.Globalization;
using System.Linq;

namespace Practica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un numero: ");
            int n50 = int.Parse(Console.ReadLine());
            bool esPrimo2 = true;

            for(int i = 2; i<n50; i++)
            {
                if(n50%i == 0)
                {
                    esPrimo2 = false;
                }
            }

            Console.WriteLine(esPrimo2 == true ? $"{n50} es primo" : $"{n50} no es primo"); 

                //TIPOS DE DATOS                                     
                int a = 5;
            string nombre = "Pedro";
            char c = 'a';
            bool resp = false;
            float num = 10.4f;
            double num1 = 15.1;
            decimal num2 = 25.6m;
            Console.WriteLine("Diferentes tipos de datos en C#\n");
            Console.WriteLine("Enteros: " + a + "\nString: " + nombre + "\nBooleano" + resp + "\n");
            Console.WriteLine("Los numeros decimales por defecto son de tipo double. Entonces si se quiere usar \nun tipo de dato float hay que especificar poniendole f al final y si es decimal ponerle la m");
            Console.WriteLine("float: " + num + "\nDouble: " + num1 + "\nDecimal: " + num2 + "\n");

            Console.WriteLine("Operadores:\nExisten 2 tipos el \"%\" para obtener el residuo de una división y  \"/\" para división\n");
            int n1 = 10;
            int n2 = 3;
            Console.WriteLine(n1 % n2);
            Console.WriteLine((decimal)n1 / n2 + "\n");




            //INTERPOLACIÓN
            //string pal = $"Hello, {nombre}! You have {a} messages in your inbox. The temperatura is {num1} celsius";
            Console.WriteLine("Interpolación");
            Console.WriteLine($"Hello, {nombre}! You have {a} messages in your inbox. The temperatura is {num1} celsius\n");
            string palabrainvertida = "";


            Console.WriteLine("Reversión de palabras\n");
            for (int i = nombre.Length - 1; i >= 0; i--)
            {
                palabrainvertida += nombre[i];
            }
            Console.WriteLine(palabrainvertida + "\n");


            for (int i = nombre.Length - 1; i >= 0; i--)
            {

                Console.WriteLine(nombre[i]);
            }
            Console.WriteLine("");



            //FORMA NUEVA PARA INVERTIR PALABRAS
            Console.WriteLine("Forma moderna:");
            string invertida = new string(nombre.Reverse().ToArray());
            Console.WriteLine(invertida);



            //FORMATO COMPUESTO -->  es un mecanismo que permite construir cadenas de texto combinando texto literal con valores de variables, usando marcadores de posición ({índice}).
            //El número después de la letra indica cuántos decimales quieres mostrar. Se puede usar 3, 4, 5 o los decimales que quieras. "{0:N3}", "{0:C3}", "{0:P3}"
            //El formato compuesto muestra los valores decimales redondeados, asi que para manejar valores monetarios es mejor truncar.
            //Solo muestra un redondeo como presentación visual, el dato va a permanecer en su estado original (no se va a redondear).
            Console.WriteLine("\n");
            Console.WriteLine("FORMATO COMPUESTO\n");
            decimal precio = 2000.45m;
            DateTime fecha = DateTime.Now;
            Console.WriteLine(string.Format("{0:C}", precio));
            Console.WriteLine("{0:C}", precio);
            Console.WriteLine(string.Format("{0:N2}", precio));
            Console.WriteLine("{0:dd/mm/yyyy}", fecha);
            Console.WriteLine("\n");





            //Math.Truncate() --> corta lo que está después del punto decimal. NO REDONDEA NI APROXIMA. Ideal para trabajar con valores monetarios.
            decimal valor = 18.59876431m;
            decimal resultado = Math.Truncate(valor * 1000) / 1000;
            Console.WriteLine(resultado);

            //FUNCION PARA TRUNCAR AUTOMATICAMENTE DECIMALES
            bool valorCorrecto = false;
            int num10 = 0;
            decimal numDec = 0;

            do { 
                Console.WriteLine("Ingrese un numero:");
                string numIngresado = Console.ReadLine().Replace(",",".");
              
                if (decimal.TryParse(numIngresado,NumberStyles.Number, CultureInfo.InvariantCulture, out numDec))
                {
                    valorCorrecto = true;
                }
                else {
                    Console.WriteLine("El valor ingresado no es del tipo correcto. Por favor ingrese un valor decimal.");
                    valorCorrecto = false;
                }
                   //Usa formato numérico estándar internacional, sin depender del país
            } while (valorCorrecto == false);

            Console.WriteLine("Ingrese la cantidad de decimales que desea obtener:");
            int cantDec = int.Parse(Console.ReadLine());
            Console.WriteLine("Resultado: " + TruncamientoAutomatico(numDec, cantDec));





            //Math.Pow() --> sirve para elevar un número a una potencia. Siempre devuelve valores de tipo DOUBLE.
            //Math.Pow(a, b)
            Console.WriteLine(Math.Pow(2, 3));  //8






            //EJERCICIO PRACTICA USANDO FORMATO COMPUESTO, INTERPOLACIÓN Y PAD.
            //PadRight() y PadLeft() sirven para rellenar una cadena hasta alcanzar una longitud determinada, agregando caracteres al lado derecho o izquierdo
            //respectivamente contando los caracteres que ya tiene la palabra. Siempre completa hasta llegar al tamaño indicado.
            string customerName = "Ms. Barros";

            string currentProduct = "Magic Yield";
            int currentShares = 2975000;
            decimal currentReturn = 0.1275m;
            decimal currentProfit = 55000000.0m;

            string newProduct = "Glorious Future";
            decimal newReturn = 0.13125m;
            decimal newProfit = 63000000.0m;


            string Message = $"Dear {customerName},\nAs a costumer of our Magic Yield offering " +
                $"we are excited to tell you about a new Financial product that would dramatically increase your return.\n\n" +
                $"Currently, you own {string.Format("{0:C}", currentShares)} share at a return of {string.Format("{0:P}", currentReturn)}.\n\n" +
                $"Our new product, Glorius Future offers a return of {string.Format("{0:P}", newReturn)} Given your current volume, your potential " +
                $"profit would be {string.Format("{0:C}", newProfit)}.\n\nHere's a quick comparison:\n\n";
            Console.WriteLine(Message);

            string comparisonMessage = "";
            comparisonMessage += currentProduct.PadRight(20);
            comparisonMessage += string.Format("{0:P}", currentReturn).PadRight(12);
            comparisonMessage += string.Format("{0:C}", currentProfit).PadRight(10) + "\n";

            comparisonMessage += newProduct.PadRight(20);
            comparisonMessage += string.Format("{0:P}", newReturn).PadRight(12);
            comparisonMessage += string.Format("{0:C}", newProfit).PadRight(10);
            Console.WriteLine(comparisonMessage);
            Console.WriteLine("\n");




            //INDEXOF() Y LASTINDEXOF() --> Sirve para encontrar la posición inicial y final de un caracter o subcadena.Devuelve un valor númerico (posición).
            string encontrar = "Mi nombre es Pedro";
            int posicion = encontrar.IndexOf("P");
            int ultPosicion = encontrar.LastIndexOf("e");
            Console.WriteLine("La posición de la letra \"P\" es: " + posicion + " y la posición de la ultima letra \"e\" es: " + ultPosicion);


            //Cuando se busca la cadena larga, IndexOf() devuelve la primera posicion de la misma, en este caso la de "<" por eso para apuntar 
            //despues del ">" se debe sumar la cantidad de carateres que contiene "</span>"
            string message = "What is the value <span>between the tags</span>?";

            int p1 = message.IndexOf("<span>");
            int closingPosition = message.IndexOf("</span>");

            p1 += 6;
            int length = closingPosition - p1;
            Console.WriteLine(message.Substring(p1, length));

            //EJERCICIO PRÁCTICO
            string message2 = "Quiero obtener solo el contenido (dentro) del ultimo paréntesis (Chelsea)";

            int ultParentesisInicial = message2.LastIndexOf("(") + 1;
            int ultParentesisFinal = message2.LastIndexOf(")");
            int longitudPalabra = ultParentesisFinal - ultParentesisInicial;
            Console.WriteLine(message2.Substring(ultParentesisInicial, longitudPalabra));
            Console.WriteLine("\n");

            //EJERCICO PRACTICO 2 -- QUITAR TODOS LOS PARENTESIS DE LA CADENA.
            string message20 = "(What if) there are (more than) one (set of parentheses)?";
            //message20 = message20.Replace("(", "").Replace(")", "");
            //Console.WriteLine(message20);

            //SEPARAR LOS DATOS DENTRO DEL PARENTESIS
            bool estado = true;

            while (true)
            {
                int PosInicial = message20.IndexOf("(");
                if (PosInicial == -1) break;

                PosInicial += 1;
                int PosFinal = message20.IndexOf(")");
                int longitud = PosFinal - PosInicial;
                Console.WriteLine(message20.Substring(PosInicial, longitud));

                //Para indicar desde donde se debe cortar la cadena hasta el final.
                message20 = message20.Substring(PosFinal + 1);
            }

            int edad = 18;
            string resultadoEdad = (edad >= 18) ? "Mayor de edad" : "Menor de edad";
            Console.WriteLine(resultadoEdad);




            //Split() ---> Divide una cadena en un array de subcadenas usando un separador que tú defines. Es como cortar una cuerda en varios pedazos.
            //EJERCICIO ELIMINAR ESPACIOS EN BLANCO DE UNA ORACIÓN.
            string pal1 = "Stamford Bridge is Chelsea's Stadium";
            string[] palabras = pal1.Split(' ');
            string palabrasSinEspacios = "";
    
            foreach(string palabra in palabras)
            {
                palabrasSinEspacios += palabra;
            }
            Console.WriteLine(palabrasSinEspacios);
            Console.WriteLine("\n");




            //REPLACE() --> Reemplaza todas las ocurrencias de un carácter o subcadena por otra (o por ninguna). Replace() simplemente no hace nada si no encuentra lo que busca
            Console.WriteLine("Ingrese su direccion de domicilio:");
            string direccion = Console.ReadLine().Trim().ToLower().Replace(" ", "");
            Console.WriteLine(direccion);



            //REMOVE() --> ELIMINA CARACTERES A PARTIR DE UNA POSICIÓN. SOLO SE USA CUANDO SE SABE EXACTAMENTE DESDE QUE POSICIÓN SE DESEA ELIMINAR.
            string sentencia = "Paseando por Hollywood";
            sentencia = sentencia.Remove(0, 13);
            Console.WriteLine(sentencia);



            //EJERCICO PRACTICO ELIMINAR PORCIONES DE LA CADENA USANDO REPLACE()
            string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

            int pos5 = input.LastIndexOf("5");
            int pos0 = input.LastIndexOf("0") + 1;
            int longitudOutput = pos0 - pos5;

            string quantity = input.Substring(pos5, longitudOutput);
            string output = "";

            output = input.Replace("<div>", "").Replace("</div>", "").Replace("trade", "reg");

            Console.WriteLine(quantity);
            Console.WriteLine(output);

            //Cuando la variable ya tiene un valor asignado se debe reasignar el resultado
            string direccion2 = "Mirador del norte";
            direccion2 = direccion2.Replace(" ", "");
            Console.WriteLine(direccion2 + "\n");


            string example = "This--is--ex-amp-le--da-ta";
            example = example.Replace("--", " ").Replace("-", "");
            Console.WriteLine(example);



            //INDEXOFANY() --> Busca cualquiera de varios caracteres que se le pasen y devuelve el indice de la primera coincidencia.
            char[] array = { ' ', ',' };
            string oracion = "Hola, me llamo Pedro";
            Console.WriteLine("La coma se encuentra en la posición:" + oracion.IndexOfAny(array));

            //Ejercico para encontrar pares de caracteres
            string mes = "(What if) I have [different symbols] but every {open symbol} needs a [matching closing symbol]?";
            char[] symbols = { '[', '{', '(' };
            int posInicial = 0;
            int closePosition = 0;

            do
            {
                posInicial = mes.IndexOfAny(symbols);
                if (posInicial == -1) break;
                
                
                string currentSymbol = mes.Substring(posInicial, 1);
                string matchingSymbol = " ";
                switch (currentSymbol)
                {
                    case "(":
                        matchingSymbol = ")";
                        break;

                    case "{":
                        matchingSymbol = "}";
                            break;

                    case "[":
                        matchingSymbol = "]";
                        break;
                    default:
                        break;
                }
                posInicial += 1; 
                //Se usa dos parametros para que la busqueda del "matchingSymbol empiece desde la openingPosition".
                closePosition = mes.IndexOf(matchingSymbol, posInicial);
                int longitudPal = closePosition - posInicial;
                Console.WriteLine(mes.Substring(posInicial, longitudPal));
                closePosition += 1;
                mes = mes.Substring(closePosition); //Para cortar la cadena y comenzar desde donde termino la primera iteracion.

            } while (true);


            string reporte = "Nombre: <Carlos> | Edad: (25) | Saldo: {1500.75} | Ciudad: [Guayaquil] ";
            char[] simbolo = { '(', '<', '{', '[' };
            int FirstPos = 0;
            int FinalPos = 0;

            do
            {
               FirstPos = reporte.IndexOfAny(simbolo); //Para encontrar cualquiera de los caracteres del array.
               if (FirstPos == -1) break;

               string caracter = reporte.Substring(FirstPos,1);
               FirstPos += 1;

                switch (caracter)
                {
                    case "(":
                        FinalPos = reporte.IndexOf(")", FirstPos);
                        break;
                    case "<":
                        FinalPos = reporte.IndexOf(">", FirstPos);
                        break;
                    case "{":
                        FinalPos = reporte.IndexOf("}", FirstPos);
                        break;
                    case "[":
                        FinalPos = reporte.IndexOf("]", FirstPos);
                        break;
                    default:
                        break;
                }
                 
                int longitud = FinalPos - FirstPos;
                string palabra = reporte.Substring(FirstPos, longitud);
                Console.WriteLine(palabra);
                FinalPos += 1;
                reporte = reporte.Substring(FinalPos);
                
            } while (true);



            //SUBSTRING() --> Para extraer una porción de una cadena.
            string pal2 = "Stamford Bridge is Chelsea's Stadium";
            Console.WriteLine(pal2.Substring(19)); //Aqui toma la porción comenzando desde la posición 19. El primer argumento indica desde donde empieza.
            Console.WriteLine(pal2.Substring(0,15)); //El segundo argumento indica la cantidad de caracteres que se van a tomar de una cadena.

            const string input2 = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

            string nuevaPal = input2;
            nuevaPal = nuevaPal.Replace("<div>", "").Replace("</div>","").Replace("trade", "reg");
            Console.WriteLine(nuevaPal);



            //EJERCICIOS DE LOGICA
            //FIZZBUZZ

            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine(i + " == FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine(i + " == Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine(i + " == Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }



            //DETECCIÓN DE UN NÚMERO PRIMO
            int[] dataset = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 14, 15, 16, 19, 23, 25, 29, 30 };
            for (int i = 0; i < dataset.Length; i++)
            {
                bool esPrimo = true;

                for (int j = 2; j < dataset[i]; j++)
                {
                    if (dataset[i] % j == 0)
                    {
                        esPrimo = false;
                        break;
                    }
                }

                if (esPrimo) { Console.WriteLine(dataset[i] + " es número primo"); }
                else { Console.WriteLine(dataset[i] + " no es primo"); }
            }



            Console.ReadKey();
        }


        public static string TruncamientoAutomatico (decimal num, int cantDecimal)
        {
           decimal potencia = (decimal)Math.Pow(10, cantDecimal);
           decimal truncado = Math.Truncate(num * potencia) / 100;
           return $"{truncado:C}";
           //return string.Format("{0:C}", truncado);
           //return result;
        }

        
    }

}
