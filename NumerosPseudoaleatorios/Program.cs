using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumerosPseudoaleatorios
{
    internal class Program
    {
        private static bool verificar = true;
        //El HashSet nos sirve para verificar que ningun numero aleatorio se repita.
        private static HashSet<double> numerosUnicos = new HashSet<double>();
        static void Main(string[] args)
        {
            int opcion;
            string mensaje;

            do
            {
                Console.WriteLine("===== MÉTODOS PARA GENERAR NÚMEROS PSEUDOALEATORIOS =====\n");
                Console.WriteLine("1. Congruenciales");
                Console.WriteLine("2. No congruenciales");
                Console.WriteLine("0. Salir");

                mensaje = "\nSeleccione una opción: ";
                opcion = (int)datos(mensaje);

                switch (opcion)
                {
                    case 1:
                        MenuCongruenciales();
                        break;

                    case 2:
                        MenuNoCongruenciales();
                        break;
                    case 0:
                        Console.WriteLine("Hasta luego.");
                        break;
                    default:
                        Console.WriteLine("Ingrese un valor válido");
                        break;
                }

            } while (opcion != 0);
        }

        static void MenuCongruenciales()
        {
            int opcion;
            string mensaje;

            do
            {
                Console.WriteLine("=== MÉTODOS CONGRUENCIALES ===\n");
                Console.WriteLine("1. Congruenciales lineales");
                Console.WriteLine("2. Congruenciales no lineales");
                Console.WriteLine("0. Volver");

                mensaje = "\nSeleccione una opción: ";
                opcion = (int)datos(mensaje);

                switch (opcion)
                {
                    case 1:
                        MenuLineales();
                        break;

                    case 2:
                        MenuNoLineales();
                        break;
                    case 0:
                        Console.WriteLine("Volviendo al menú anterior.");
                        break;
                    default:
                        Console.WriteLine("Ingrese un valor válido");
                        break;
                }

            } while (opcion != 0);
        }

        static void MenuLineales()
        {
            int opcion;
            string mensaje;

            do
            {
                Console.WriteLine("=== CONGRUENCIALES LINEALES ===\n");
                Console.WriteLine("1. Algoritmo congruencial lineal");
                Console.WriteLine("2. Algoritmo congruencial multiplicativo");
                Console.WriteLine("3. Algoritmo congruencial aditivo");
                Console.WriteLine("0. Volver");

                mensaje = "\nSeleccione una opción: ";
                opcion = (int)datos(mensaje);

                switch (opcion)
                {
                    case 1:
                        AlgoritmoCongruencialLinealObtencionDatos();
                        break;

                    case 2:
                        int x0 = 13;
                        int a = 11;
                        int m = 32;
                        int cantidad1 = 8;

                        AlgoritmoCongruencialMultiplicativo(x0, a, m, cantidad1);
                        break;

                    case 3:
                        List<int> secuencia = new List<int> { 65, 89, 98, 3, 69 };
                        int modulo_m = 100;
                        int cantidad = 7;

                        AlgoritmoCongruencialAditivo(secuencia, modulo_m, cantidad);
                        break;
                    case 0:
                        Console.WriteLine("Volviendo al menú anterior.");
                        break;
                    default:
                        Console.WriteLine("Ingrese un valor válido");
                        break;
                }

            } while (opcion != 0);
        }

        static void MenuNoLineales()
        {
            int opcion;
            string mensaje;

            do
            {
                Console.WriteLine("=== CONGRUENCIALES NO LINEALES ===\n");
                Console.WriteLine("1. Algoritmo congruencial cuadrático");
                Console.WriteLine("2. Algoritmo Blum, Blum y Shub");
                Console.WriteLine("0. Volver");

                mensaje = "\nSeleccione una opción: ";
                opcion = (int)datos(mensaje);

                switch (opcion)
                {
                    case 1:
                        EjecutarCongruencialCuadratico();
                        break;

                    case 2:
                        EjecutarBlumBlumShub();
                        break;
                    case 0:
                        Console.WriteLine("Volviendo al menú anterior.");
                        break;
                    default:
                        Console.WriteLine("Ingrese un valor válido");
                        break;
                }

            } while (opcion != 0);
        }

        static void MenuNoCongruenciales()
        {
            int opcion;
            string mensaje;

            do
            {
                Console.WriteLine("=== NO CONGRUENCIALES ===\n");
                Console.WriteLine("1. Algoritmo de cuadrados medios");
                Console.WriteLine("2. Algoritmo de productos medios");
                Console.WriteLine("3. Algoritmo de multiplicador constante");
                Console.WriteLine("0. Volver");

                mensaje = "\nSeleccione una opción: ";
                opcion = (int)datos(mensaje);

                switch (opcion)
                {
                    case 1:
                        CuadradosMedios();
                        break;

                    case 2:
                        ProductosMedios();
                        break;

                    case 3:
                        MultiplicadorConstante();
                        break;
                    case 0:
                        Console.WriteLine("Volviendo al menú anterior.");
                        break;
                    default:
                        Console.WriteLine("Ingrese un valor válido");
                        break;
                }

            } while (opcion != 0);
        }

        static long datos(string mensaje)
        {
            bool verificarEntrada;
            int dato;
            do
            {
                Console.Write(mensaje);
                verificarEntrada = int.TryParse(Console.ReadLine(), out dato);

                if (!verificarEntrada || dato < 0)
                {
                    Console.WriteLine("Ingrese un valor numérico válido (Entero positivo)");
                }

            } while (!verificarEntrada || dato < 0);

            return dato;
        }

        static bool verificador(double valor)
        {
            if (valor < 0 || valor > 1)
            {
                Console.WriteLine("¡ERROR! Se ha encontrado un valor r fuera del rango entre 0 y 1.");
                return false;
            }
            bool prueba = numerosUnicos.Add(valor);
            if (prueba == true)
            {
                return true;
            }
            else
            {
                Console.WriteLine("¡ERROR! Los valores se han repetido.");
                return false;
            }
        }

        static void AlgoritmoCongruencialLinealObtencionDatos()
        {
            verificar = true;
            numerosUnicos.Clear();
            Console.WriteLine("---Algoritmo Congruencial Lineal---");
            int cantNum = (int)datos("¿Qué cantidad de números deseas generar?: ");
            Console.WriteLine("Ingresa los siguientes valores (Solo enteros positivos): ");
            long x0 = datos("x0: ");
            long k = datos("k: ");
            long g = datos("g: ");
            long c = datos("c: ");

            var numAleatoriosACL = AlgoritmoLineal(cantNum, x0, k, g, c);

            if (verificar == true)
            {
                Console.WriteLine("Números x y r generados:");
                for (int i = 0; i < cantNum; i++)
                {
                    //Reducimos los decimales a 4 en los números aleatorios r
                    double truncarNum_r = Math.Truncate(numAleatoriosACL.Item2[i] * 10000) / 10000;
                    Console.WriteLine("X{0} = {1} -- r{2} = {3}", i + 1, numAleatoriosACL.Item1[i], i + 1, truncarNum_r);
                }
            }
            else
            {
                Console.WriteLine("HA OCURRIDO UN PROBLEMA: No se han podido generar los números pseudoaleatorios requeridos." +
                    "\nA continuación se muestran los números x y r que se pudieron crear sin repetir ninguno valor, y sin salirse del rango establecido para los números r [0 a 1].");
                for (int i = 0; i < numAleatoriosACL.Item3; i++)
                {
                    double truncarNum_r = Math.Truncate(numAleatoriosACL.Item2[i] * 10000) / 10000;
                    Console.WriteLine("X{0} = {1} -- r{2} = {3}", i + 1, numAleatoriosACL.Item1[i], i + 1, truncarNum_r);
                }
                Console.WriteLine("Intente ingresando otros valores.");
            }
            numerosUnicos.Clear();
            return;
        }

        static Tuple<double[], double[], int> AlgoritmoLineal(int cantidadNumAl, long x0, long k, long g, long c)
        {

            double[] numAleatorios = new double[cantidadNumAl];
            double[] xGenerados = new double[cantidadNumAl];
            int numCreadosConExito = 0;
            long m = (long)Math.Pow(2, g);
            long a = 1 + 4 * k;

            for (int i = 0; i < cantidadNumAl; i++)
            {
                long xn = (a * x0 + c) % m;
                double numeroAleatorio = xn / (double)(m - 1);

                verificar = verificador(numeroAleatorio);
                if (verificar == true)
                {
                    xGenerados[i] = xn;
                    numAleatorios[i] = numeroAleatorio;
                    numCreadosConExito = i + 1;
                    x0 = xn;
                }
                else
                {
                    break;
                }
            }

            return Tuple.Create(xGenerados, numAleatorios, numCreadosConExito);
        }

        //Método Multiplicador Constante
        static void MultiplicadorConstante()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("=== MÉTODO MULTIPLICADOR CONSTANTE ===\n");

                // ========== DECLARACIÓN DE VARIABLES ==========
                // X = semilla, a = constante (ambas de 4 dígitos)
                long X = 0, a = 0;

                // Validar semilla
                try
                {
                    Console.Write("Semilla inicial X0 (4 dígitos): ");
                    X = long.Parse(Console.ReadLine());//Convierte texto a número
                }
                catch (FormatException)// Error si el usuario escribe letras o símbolos
                {
                    Console.WriteLine("Error: Debe ingresar un número válido para la semilla");
                    Console.ReadKey();
                    return;// Sale del método y regresa al menú
                }
                catch (OverflowException)// Error si el número es demasiado grande
                {
                    Console.WriteLine("Error: La semilla es demasiado grande");
                    Console.ReadKey();
                    return;
                }

                // Validar constante
                try
                {
                    Console.Write("Constante a (4 dígitos): ");
                    a = long.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Debe ingresar un número válido para la constante");
                    Console.ReadKey();
                    return;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: La constante es demasiado grande");
                    Console.ReadKey();
                    return;
                }
                // ========== VALIDACIÓN DE 4 DÍGITOS ==========
                // Verifica que ambos números tengan exactamente 4 dígitos (1000 a 9999)
                if (X < 1000 || X > 9999 || a < 1000 || a > 9999)
                {
                    Console.WriteLine("Error: Deben ser números de 4 dígitos (1000 - 9999)");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("\nGenerando números...\n");

                // Limpiar HashSet para este método
                numerosUnicos.Clear();
                verificar = true;

                // Encabezados
                Console.WriteLine("RESULTADOS:");
                Console.WriteLine("===========================================");
                Console.WriteLine("| i | Y        | X_i+1 | r_i   |");
                Console.WriteLine("|---|----------|-------|-------|");

                // Variable para contar (FUERA del ciclo)
                // Esta variable lleva la cuenta de cuántos números se generaron realment
                int totalGenerados = 0;

                // Generar 50 números
                for (int i = 0; i < 50; i++)
                {
                    try
                    {
                        // PASO 1: Calcular Y = a * X
                        long Y = a * X;

                        // PASO 2: Obtener los 4 dígitos del centro
                        string Ytexto = Y.ToString().PadLeft(8, '0');

                        if (Ytexto.Length < 8) // Verifica que tenga al menos 8 dígitos

                        {
                            throw new Exception("Error al formatear el número");
                        }

                        //Toma los 4 digitos del centro
                        string centro = Ytexto.Substring(2, 4);
                        long nuevoX = long.Parse(centro);//convierte a número

                        // PASO 3: Calcular r = 0.dígitos (4 decimales)
                        string rTexto = "0." + nuevoX.ToString("D4");
                        double r = double.Parse(rTexto);
                        r = Math.Round(r, 4);

                        // Validar que r esté entre 0 y 1 usando el verificador
                        verificar = verificador(r);

                        if (verificar == true)
                        {
                            // Mostrar resultado
                            Console.WriteLine($"| {i,-2} | {Y,-8} | {nuevoX,-5} | {r,-5:F4} |");

                            // Actualizar X y contador
                            X = nuevoX;
                            totalGenerados++;
                        }
                        else
                        {
                            Console.WriteLine($"\nCiclo terminado en iteración {i} por repetición o valor fuera de rango");
                            break;
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine($"Error: Problema al extraer dígitos en iteración {i}");
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Error: Problema al convertir números en iteración {i}");
                        break;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine($"Error: Desbordamiento en iteración {i}");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error inesperado en iteración {i}: {ex.Message}");
                        break;
                    }
                }

                Console.WriteLine("===========================================");
                Console.WriteLine($"\nTotal: {totalGenerados} números generados");

                if (totalGenerados < 50)
                {
                    Console.WriteLine($"Nota: Solo se generaron {totalGenerados} de 50 números debido a repetición o error");
                }

                // Limpiar HashSet para el siguiente método
                numerosUnicos.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError general: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
        static void EjecutarCongruencialCuadratico()
        {
            Console.Clear();
            Console.WriteLine("--- ALGORITMO CONGRUENCIAL CUADRÁTICO ---");

            try
            {
                long x0 = PedirValor("Ingresa la Semilla (X0): ");
                long a = PedirValor("Ingresa la constante 'a': ");
                long b = PedirValor("Ingresa la constante 'b': ");
                long c = PedirValor("Ingresa la constante 'c': ");
                long m = PedirValor("Ingresa el Módulo 'm': ");

                if (m <= 0)
                {
                    Console.WriteLine("Error: El módulo 'm' debe ser mayor a 0.");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("\n i \t Xi \t\t ri");
                Console.WriteLine("------------------------------------------------");

                long xi = x0;
                // HashSet guardará los Xi generados para detectar el ciclo
                HashSet<long> numerosGenerados = new HashSet<long>();
                numerosGenerados.Add(xi); // Agregamos la semilla inicial por si el ciclo vuelve a ella

                int i = 0;
                while (true)
                {
                    long parteA = (a * ((xi * xi) % m)) % m;
                    long parteB = (b * xi) % m;
                    long siguienteX = (parteA + parteB + c) % m;

                    double ri = (double)siguienteX / (m - 1);

                    // 1. CONDICIÓN DE PARADA: Revisamos si el número ya existe
                    if (numerosGenerados.Contains(siguienteX))
                    {
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine($"[!] FIN DEL CICLO: El número X = {siguienteX} se repitió en la iteración {i + 1}.");
                        Console.WriteLine($"Periodo del generador: {i} números únicos.");
                        break; // Rompe el ciclo while
                    }

                    // 2. FORMATO A 4 DECIMALES: Usamos {ri:F4} y mostramos Xi y ri
                    Console.WriteLine($" {i + 1} \t {siguienteX} \t\t {ri:F4}");

                    // Guardamos el número nuevo y preparamos la siguiente iteración
                    numerosGenerados.Add(siguienteX);
                    xi = siguienteX;
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcurrió un error: {ex.Message}");
            }

            Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        static void EjecutarBlumBlumShub()
        {
            Console.Clear();
            Console.WriteLine("--- ALGORITMO DE BLUM, BLUM Y SHUB (BBS) ---");

            try
            {
                long p = PedirValor("Ingresa el número primo 'p' (congruente a 3 mod 4): ");
                long q = PedirValor("Ingresa el número primo 'q' (congruente a 3 mod 4): ");
                long s = PedirValor("Ingresa la semilla 's' (primo relativo de p*q): ");

                if (p % 4 != 3 || q % 4 != 3)
                {
                    Console.WriteLine("\n[Advertencia] p y q deberían ser congruentes con 3 mod 4 para que BBS sea seguro.\n");
                }

                long n = p * q;
                long xi = (s * s) % n; // Calculamos X0

                HashSet<long> numerosGenerados = new HashSet<long>();
                numerosGenerados.Add(xi);

                Console.WriteLine($"\nValor de n (p*q) = {n}");
                Console.WriteLine(" i \t Xi \t\t ri");
                Console.WriteLine("------------------------------------------------");

                int i = 0;
                while (true)
                {
                    long siguienteX = (xi * xi) % n;
                    double ri = (double)siguienteX / (n - 1);

                    // 1. CONDICIÓN DE PARADA
                    if (numerosGenerados.Contains(siguienteX))
                    {
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine($"[!] FIN DEL CICLO: El número X = {siguienteX} se repitió en la iteración {i + 1}.");
                        Console.WriteLine($"Periodo del generador: {i} números únicos.");
                        break;
                    }

                    // 2. FORMATO A 4 DECIMALES
                    Console.WriteLine($" {i + 1} \t {siguienteX} \t\t {ri:F4}");

                    numerosGenerados.Add(siguienteX);
                    xi = siguienteX;
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcurrió un error: {ex.Message}");
            }

            Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        // Método auxiliar para evitar repetir código al pedir datos
        static long PedirValor(string mensaje)
        {
            Console.Write(mensaje);
            while (true)
            {
                if (long.TryParse(Console.ReadLine(), out long resultado))
                {
                    return resultado;
                }
                Console.Write("Entrada inválida. Ingresa un número entero: ");
            }
        }
        static void CuadradosMedios()
        {
            Console.WriteLine("--- Algoritmo de Cuadrados Medios ---");

            Console.Write("Ingresa la semilla inicial (X0) de 4 dígitos: ");
            string entrada = Console.ReadLine();
            int semilla = Convert.ToInt32(entrada);

            List<int> numerosGenerados = new List<int>();

            int x = semilla;
            int contador = 1;
            bool seRepite = false;

            Console.WriteLine("\n n \t X \t r");
            Console.WriteLine("-------------------------");

            // 2. El ciclo termina cuando se repite un número
            while (seRepite == false)
            {
                // Elevar al cuadrado (usamos long porque el cuadrado de 4 dígitos puede ser grande)
                long cuadrado = (long)x * x;

                // Convertir a texto
                string cuadradoTexto = cuadrado.ToString();

                // Rellenar con ceros a la izquierda si tiene menos de 8 caracteres (estilo muy novato)
                while (cuadradoTexto.Length < 8)
                {
                    cuadradoTexto = "0" + cuadradoTexto;
                }

                // Tomar los 4 dígitos de en medio (cortamos desde la posición 2 y tomamos 4 letras)
                string centro = cuadradoTexto.Substring(2, 4);

                // Ese texto del centro es nuestro nuevo X
                int nuevoX = Convert.ToInt32(centro);

                // Calcular el valor 'r' entre 0 y 1
                double r = nuevoX / 10000.0;

                // 3. Mostrar el X generado y el valor r (con 4 decimales)
                Console.WriteLine(contador + " \t " + nuevoX + " \t " + r.ToString("0.0000"));

                // Revisar si la lista ya contiene este número nuevo
                if (numerosGenerados.Contains(nuevoX))
                {
                    seRepite = true; // Esto rompe el ciclo
                    Console.WriteLine("\nEl ciclo terminó porque el número " + nuevoX + " se repitió.");
                }
                else
                {
                    // Si no se repite, lo agregamos a la lista
                    numerosGenerados.Add(nuevoX);
                    x = nuevoX; // El nuevo X ahora es el X para la siguiente vuelta
                    contador++;
                }
            }

            // 4. Validar que la corrida sea de mínimo 50 números
            int totalGenerados = contador - 1; // Restamos 1 porque el contador sumó antes de repetir

            Console.WriteLine("\n--- Resumen ---");
            if (totalGenerados < 50)
            {
                Console.WriteLine("La corrida fue de " + totalGenerados + " números. NO cumple el mínimo de 50.");
                Console.WriteLine("Nota: El método de cuadrados medios degenera rápido. ¡Intenta con otra semilla (como 2113 o 5634)!");
            }
            else
            {
                Console.WriteLine("¡Excelente! La corrida fue de " + totalGenerados + " números. Cumple el mínimo de 50.");
            }

            Console.ReadLine();
        }
        static void ProductosMedios()
        {
            Console.WriteLine("--- Algoritmo de Productos Medios ---");

            // 1. Solicitar los datos iniciales (necesitamos dos semillas)
            Console.Write("Ingresa la primera semilla (X0) de 4 dígitos: ");
            string entrada1 = Console.ReadLine();
            int x0 = Convert.ToInt32(entrada1);

            Console.Write("Ingresa la segunda semilla (X1) de 4 dígitos: ");
            string entrada2 = Console.ReadLine();
            int x1 = Convert.ToInt32(entrada2);

            // Lista para guardar el historial y checar si se repite
            List<int> numerosGenerados = new List<int>();

            int contador = 1;
            bool seRepite = false;

            // Encabezado de la tabla
            Console.WriteLine("\n n \t X \t r");
            Console.WriteLine("-------------------------");

            // 2. El ciclo termina cuando se repite un número
            while (seRepite == false)
            {
                // Multiplicar x0 por x1 (usamos long por si el número se hace muy grande)
                long producto = (long)x0 * x1;

                // Convertir el resultado a texto
                string productoTexto = producto.ToString();

                // Rellenar con ceros a la izquierda hasta que tenga 8 caracteres
                while (productoTexto.Length < 8)
                {
                    productoTexto = "0" + productoTexto;
                }

                // Tomar los 4 dígitos de en medio (empezamos en la posición 2 y cortamos 4)
                string centro = productoTexto.Substring(2, 4);

                // Ese texto del centro es nuestro nuevo número generado (X)
                int nuevoX = Convert.ToInt32(centro);

                // Calcular el valor 'r' entre 0 y 1
                double r = nuevoX / 10000.0;

                // 3. Mostrar el X generado y el valor r (con 4 decimales)
                Console.WriteLine(contador + " \t " + nuevoX + " \t " + r.ToString("0.0000"));

                // Checar si la lista ya tiene este número nuevo
                if (numerosGenerados.Contains(nuevoX))
                {
                    seRepite = true; // Cambiamos la variable para salir del ciclo while
                    Console.WriteLine("\nEl ciclo terminó porque el número " + nuevoX + " se repitió.");
                }
                else
                {
                    // Si no se repite, lo guardamos en la lista
                    numerosGenerados.Add(nuevoX);

                    // Preparamos los valores para la siguiente vuelta
                    x0 = x1;       // La semilla 2 pasa a ser la semilla 1
                    x1 = nuevoX;   // El número nuevo pasa a ser la semilla 2

                    contador = contador + 1; // Sumamos 1 al contador estilo básico
                }
            }

            // 4. Validar que la corrida sea de mínimo 50 números
            int totalGenerados = contador - 1; // Le quitamos 1 porque el contador sumó en la última vuelta

            Console.WriteLine("\n--- Resumen ---");
            if (totalGenerados < 50)
            {
                Console.WriteLine("La corrida fue de " + totalGenerados + " números. NO cumple el mínimo de 50.");
                Console.WriteLine("Nota: Intenta con otras semillas (por ejemplo: 5015 y 5734).");
            }
            else
            {
                Console.WriteLine("¡Excelente! La corrida fue de " + totalGenerados + " números. Cumple el mínimo de 50.");
            }

            Console.ReadLine();

        }

        public static void AlgoritmoCongruencialAditivo(List<int> secuenciaInicial, int m, int cantidadAGenerar)
        {
            // Creamos una nueva lista basada en la secuencia inicial para trabajar sobre ella
            List<int> X = new List<int>(secuenciaInicial);
            int n = X.Count;
            List<double> r = new List<double>();

            Console.WriteLine("Solución:\n");

            for (int i = 0; i < cantidadAGenerar; i++)
            {
                // X_{i-1} corresponde al último elemento que tenemos guardado
                int x_anterior = X[X.Count - 1];
                // X_{i-n} corresponde al elemento en la posición actual del ciclo 'i'
                int x_n_posiciones_atras = X[i];

                // Ecuación: X_i = (X_{i-1} + X_{i-n}) mod m
                int nuevo_X = (x_anterior + x_n_posiciones_atras) % m;
                X.Add(nuevo_X);

                // Ecuación: r_i = X_i / (m - 1)
                // Es importante castear a (double) para evitar la división entera en C#
                double nuevo_r = (double)nuevo_X / (m - 1);
                r.Add(nuevo_r);

                // Índices para imprimir correctamente el texto
                int indice_X = n + i + 1;
                int indice_r = i + 1;

                // Imprimir en consola con formato (F4 asegura que salgan 4 decimales)
                Console.WriteLine($"X_{indice_X} = (X_{indice_X - 1} + X_{indice_X - n}) mod {m} " +
                                  $"= ({x_anterior} + {x_n_posiciones_atras:D2}) mod {m} = {nuevo_X,-2} \t " +
                                  $"r_{indice_r} = {nuevo_X}/{m - 1} = {nuevo_r:F4}");
            }
        }
        public static void AlgoritmoCongruencialMultiplicativo(int x0, int a, int m, int cantidadAGenerar)
        {
            int x_actual = x0;
            List<int> X = new List<int>();
            List<double> r = new List<double>();

            Console.WriteLine($"Parámetros iniciales: X0 = {x0}, a = {a}, m = {m}\n");
            Console.WriteLine("Solución paso a paso:\n");

            for (int i = 1; i <= cantidadAGenerar; i++)
            {
                // Ecuación: X_{i} = (a * X_{i-1}) mod m
                int nuevo_X = (a * x_actual) % m;
                X.Add(nuevo_X);

                // Ecuación: r_i = X_i / (m - 1)
                double nuevo_r = (double)nuevo_X / (m - 1);
                r.Add(nuevo_r);

                // Imprimir el proceso
                Console.WriteLine($"X_{i} = ({a} * X_{i - 1}) mod {m} " +
                                  $"= ({a} * {x_actual,-2}) mod {m} = {nuevo_X,-2} \t " +
                                  $"r_{i} = {nuevo_X}/{m - 1} = {nuevo_r:F4}");

                // Actualizamos la semilla para la siguiente iteración
                x_actual = nuevo_X;
            }
        }
    }
}
