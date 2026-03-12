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
                        Console.WriteLine("\nSeleccionaste: Algoritmo congruencial multiplicativo");
                        break;

                    case 3:
                        Console.WriteLine("\nSeleccionaste: Algoritmo congruencial aditivo");
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
                        Console.WriteLine("\nSeleccionaste: Algoritmo de cuadrados medios");
                        break;

                    case 2:
                        Console.WriteLine("\nSeleccionaste: Algoritmo de productos medios");
                        break;

                    case 3:
                        Console.WriteLine("\nSeleccionaste: Algoritmo de multiplicador constante");
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
                int N = (int)PedirValor("Ingresa la cantidad de números a generar (N): ");

                if (m <= 0)
                {
                    Console.WriteLine("Error: El módulo 'm' debe ser mayor a 0.");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("\n i \t Xi \t\t ri");
                Console.WriteLine("------------------------------------------------");

                long xi = x0;

                for (int i = 0; i < N; i++)
                {
                    // Desglosamos la operación para evitar el desbordamiento (overflow) de memoria con números grandes
                    long parteA = (a * ((xi * xi) % m)) % m;
                    long parteB = (b * xi) % m;
                    long siguienteX = (parteA + parteB + c) % m;

                    double ri = (double)siguienteX / (m - 1);

                    // Imprimimos el resultado tabulado
                    Console.WriteLine($" {i + 1} \t {siguienteX} \t\t {ri:F5}");

                    xi = siguienteX;
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
                int N = (int)PedirValor("Ingresa la cantidad de números a generar (N): ");

                // Verificación de congruencia (criptográficamente necesario)
                if (p % 4 != 3 || q % 4 != 3)
                {
                    Console.WriteLine("\n[Advertencia] p y q deberían ser congruentes con 3 mod 4 para que BBS sea seguro.");
                    Console.WriteLine("Continuando de todos modos para fines de simulación...\n");
                }

                long n = p * q;
                long xi = (s * s) % n; // X0 inicial

                Console.WriteLine($"\nValor de n (p*q) = {n}");
                Console.WriteLine(" i \t Xi \t\t ri");
                Console.WriteLine("------------------------------------------------");

                for (int i = 0; i < N; i++)
                {
                    xi = (xi * xi) % n;
                    double ri = (double)xi / (n - 1);

                    Console.WriteLine($" {i + 1} \t {xi} \t\t {ri:F5}");
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
    }
}
