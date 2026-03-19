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
        static List<double> listaRi = new List<double>();
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
                        Console.WriteLine("--- Configuración del Algoritmo Congruencial Multiplicativo ---");
                        AlgoritmoCongruencialMultiplicativo();
                        break;

                    case 3:

                        AlgoritmoCongruencialAditivo();
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
            Console.Clear();
            listaRi.Clear();
            verificar = true;
            numerosUnicos.Clear();
            Console.WriteLine("=== Algoritmo Congruencial Lineal ===");
            int cantNum = (int)datos("¿Qué cantidad de números deseas generar?: ");
            Console.WriteLine("Ingresa los siguientes valores (Solo enteros positivos): ");
            long x0 = datos("x0: ");
            long k = datos("k: ");
            long g = datos("g: ");
            long c = datos("c: ");

            var numAleatoriosACL = AlgoritmoLineal(cantNum, x0, k, g, c);

            Console.WriteLine("RESULTADOS:");
            Console.WriteLine("========================");
            Console.WriteLine("| i | X_i |   r_i   |");
            Console.WriteLine("|---|-----|---------|");

            if (verificar == true)
            {
                for (int i = 0; i < cantNum; i++)
                {
                    //Reducimos los decimales a 4 en los números aleatorios r
                    double truncarNum_r = Math.Truncate(numAleatoriosACL.Item2[i] * 10000) / 10000;
                    Console.WriteLine($"| {i + 1,-1} | {numAleatoriosACL.Item1[i],-3} | {truncarNum_r,-7} | ");
                }
            }
            else
            {
                for (int i = 0; i < numAleatoriosACL.Item3; i++)
                {
                    double truncarNum_r = Math.Truncate(numAleatoriosACL.Item2[i] * 10000) / 10000;
                    Console.WriteLine($"| {i + 1,-1} | {numAleatoriosACL.Item1[i],-3} | {truncarNum_r,-7} | ");
                }
            }
            Console.WriteLine("========================");
            Console.WriteLine($"\nTotal: {numAleatoriosACL.Item3} de {cantNum}");

            PruebaCorridasMedia(listaRi);
            Console.WriteLine("\nPresiona cualquier tecla...");
            Console.ReadKey();
            numerosUnicos.Clear();
            return;
        }

        static Tuple<double[], double[], int> AlgoritmoLineal(int cantidadNumAl,
            long x0, long k, long g, long c)
        {

            double[] numAleatorios = new double[cantidadNumAl];
            double[] xGenerados = new double[cantidadNumAl];
            int numCreadosConExito = 0;
            long m = (long)Math.Pow(2, g);
            long a = 1 + 4 * k;
            Console.WriteLine("a = {0}, m = {1}\n", a, m);

            for (int i = 0; i < cantidadNumAl; i++)
            {
                long xn = (a * x0 + c) % m;
                double numeroAleatorio = xn / (double)(m - 1);

                verificar = verificador(numeroAleatorio);
                if (verificar == true)
                {
                    xGenerados[i] = xn;
                    numAleatorios[i] = numeroAleatorio;
                    listaRi.Add(numeroAleatorio);
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

        static void MultiplicadorConstante()
        {
            Console.Clear();
            listaRi.Clear();
            try
            {
                Console.WriteLine("=== MULTIPLICADOR CONSTANTE ===\n");

                long X = 0, a = 0;

                try
                {
                    Console.Write("Semilla X0 (4 dígitos): ");
                    X = long.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                try
                {
                    Console.Write("Constante a (4 dígitos): ");
                    a = long.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                if (X < 1000 || X > 9999 || a < 1000 || a > 9999)
                {
                    Console.WriteLine("Error: Ambos deben ser de 4 dígitos");
                    Console.ReadKey();
                    return;
                }

                int cantidadNumeros = 0;
                try
                {
                    Console.Write("\n¿Cuántos números generar? ");
                    cantidadNumeros = int.Parse(Console.ReadLine());

                    if (cantidadNumeros <= 0)
                    {
                        Console.WriteLine("Error: Número positivo requerido");
                        Console.ReadKey();
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("\nGenerando...\n");

                numerosUnicos.Clear();
                verificar = true;

                Console.WriteLine("RESULTADOS:");
                Console.WriteLine("===========================================");
                Console.WriteLine("| i | Y        | X_i+1 | r_i   |");
                Console.WriteLine("|---|----------|-------|-------|");

                int totalGenerados = 0;

                for (int i = 0; i < cantidadNumeros; i++)
                {
                    try
                    {
                        long Y = a * X;
                        string Ytexto = Y.ToString().PadLeft(8, '0');
                        string centro = Ytexto.Substring(2, 4);
                        long nuevoX = long.Parse(centro);
                        string rTexto = "0." + nuevoX.ToString("D4");
                        double r = double.Parse(rTexto);
                        r = Math.Round(r, 4);
                        listaRi.Add(r);

                        verificar = verificador(r);

                        if (verificar == true)
                        {
                            Console.WriteLine($"| {i,-2} | {Y,-8} | {nuevoX,-5} | {r,-5:F4} |");
                            X = nuevoX;
                            totalGenerados++;
                        }
                        else
                        {
                            Console.WriteLine($"\nSe detuvo en iteración {i} por repetición");
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"\nError en iteración {i}");
                        break;
                    }
                }

                Console.WriteLine("===========================================");
                Console.WriteLine($"\nTotal: {totalGenerados} de {cantidadNumeros}");

                numerosUnicos.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            finally
            {
                PruebaCorridasMedia(listaRi);
                Console.WriteLine("\nPresiona cualquier tecla...");
                Console.ReadKey();
            }
        }

        static void EjecutarCongruencialCuadratico()
        {
            Console.Clear();
            listaRi.Clear();
            try
            {
                Console.WriteLine("=== CONGRUENCIAL CUADRÁTICO ===\n");

                long x0 = 0, a = 0, b = 0, c = 0, g = 0;

                try
                {
                    Console.Write("Semilla X0: ");
                    x0 = long.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                try
                {
                    Console.Write("Constante a (par): ");
                    a = long.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                try
                {
                    Console.Write("Constante b: ");
                    b = long.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                try
                {
                    Console.Write("Constante c (impar): ");
                    c = long.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                try
                {
                    Console.Write("Valor de g: ");
                    g = long.Parse(Console.ReadLine());

                    if (g <= 0)
                    {
                        Console.WriteLine("Error: g debe ser positivo");
                        Console.ReadKey();
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                long m = (long)Math.Pow(2, g);
                Console.WriteLine($"\nm = {m}");

                int cantidadNumeros = 0;
                try
                {
                    Console.Write("¿Cuántos números generar? ");
                    cantidadNumeros = int.Parse(Console.ReadLine());

                    if (cantidadNumeros <= 0)
                    {
                        Console.WriteLine("Error: Número positivo requerido");
                        Console.ReadKey();
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("\nGenerando...\n");

                Program.numerosUnicos.Clear();
                Program.verificar = true;

                Console.WriteLine("RESULTADOS:");
                Console.WriteLine("========================");
                Console.WriteLine("| i | X_i | r_i   |");
                Console.WriteLine("|---|-----|-------|");

                long xi = x0;
                int totalGenerados = 0;

                for (int i = 1; i <= cantidadNumeros; i++)
                {
                    try
                    {
                        long parteA = (a * ((xi * xi) % m)) % m;
                        long parteB = (b * xi) % m;
                        long siguienteX = (parteA + parteB + c) % m;

                        double ri = (double)siguienteX / (m - 1);
                        ri = Math.Round(ri, 4);
                        listaRi.Add(ri);

                        Program.verificar = Program.verificador(ri);

                        if (Program.verificar == true)
                        {
                            Console.WriteLine($"| {i,-2} | {siguienteX,-3} | {ri,-5:F4} |");
                            xi = siguienteX;
                            totalGenerados++;
                        }
                        else
                        {
                            Console.WriteLine($"\nSe detuvo en iteración {i}");
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"\nError en iteración {i}");
                        break;
                    }
                }

                Console.WriteLine("========================");
                Console.WriteLine($"\nTotal: {totalGenerados} de {cantidadNumeros}");

                Program.numerosUnicos.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            finally
            {
                PruebaCorridasMedia(listaRi);
                Console.WriteLine("\nPresiona cualquier tecla...");
                Console.ReadKey();
            }
        }

        static void EjecutarBlumBlumShub()
        {
            Console.Clear();
            listaRi.Clear();
            try
            {
                Console.WriteLine("=== BLUM BLUM SHUB ===\n");

                long x0 = 0, m = 0;

                try
                {
                    Console.Write("Semilla X0: ");
                    x0 = long.Parse(Console.ReadLine());

                    if (x0 <= 0)
                    {
                        Console.WriteLine("Error: X0 debe ser positivo");
                        Console.ReadKey();
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                try
                {
                    Console.Write("Módulo m: ");
                    m = long.Parse(Console.ReadLine());

                    if (m <= 0)
                    {
                        Console.WriteLine("Error: m debe ser positivo");
                        Console.ReadKey();
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                int cantidadNumeros = 0;
                try
                {
                    Console.Write("\n¿Cuántos números generar? ");
                    cantidadNumeros = int.Parse(Console.ReadLine());

                    if (cantidadNumeros <= 0)
                    {
                        Console.WriteLine("Error: Número positivo requerido");
                        Console.ReadKey();
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("\nGenerando...\n");

                Program.numerosUnicos.Clear();
                Program.verificar = true;

                Console.WriteLine("RESULTADOS:");
                Console.WriteLine("========================");
                Console.WriteLine("| i | X_i | r_i   |");
                Console.WriteLine("|---|-----|-------|");

                long xi = x0;
                int totalGenerados = 0;

                for (int i = 1; i <= cantidadNumeros; i++)
                {
                    try
                    {
                        long siguienteX = (xi * xi) % m;
                        double ri = (double)siguienteX / (m - 1);
                        ri = Math.Round(ri, 4);
                        listaRi.Add(ri);

                        Program.verificar = Program.verificador(ri);

                        if (Program.verificar == true)
                        {
                            Console.WriteLine($"| {i,-2} | {siguienteX,-3} | {ri,-5:F4} |");
                            xi = siguienteX;
                            totalGenerados++;
                        }
                        else
                        {
                            Console.WriteLine($"\nSe detuvo en iteración {i}");
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"\nError en iteración {i}");
                        break;
                    }
                }

                Console.WriteLine("========================");
                Console.WriteLine($"\nTotal: {totalGenerados} de {cantidadNumeros}");

                Program.numerosUnicos.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            finally
            {
                PruebaCorridasMedia(listaRi);
                Console.WriteLine("\nPresiona cualquier tecla...");
                Console.ReadKey();
            }
        }

        static void CuadradosMedios()
        {
            Console.Clear();
            listaRi.Clear();
            try
            {
                Console.WriteLine("=== CUADRADOS MEDIOS ===\n");

                int semilla = 0;

                try
                {
                    Console.Write("Semilla X0 (4 dígitos): ");
                    semilla = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                if (semilla < 1000 || semilla > 9999)
                {
                    Console.WriteLine("Error: Debe ser de 4 dígitos");
                    Console.ReadKey();
                    return;
                }

                int cantidadNumeros = 0;
                try
                {
                    Console.Write("\n¿Cuántos números generar? ");
                    cantidadNumeros = int.Parse(Console.ReadLine());

                    if (cantidadNumeros <= 0)
                    {
                        Console.WriteLine("Error: Número positivo requerido");
                        Console.ReadKey();
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("\nGenerando...\n");

                numerosUnicos.Clear();
                verificar = true;

                Console.WriteLine("RESULTADOS:");
                Console.WriteLine("===========================================");
                Console.WriteLine("| i | Cuadrado  | X_i+1 | r_i   |");
                Console.WriteLine("|---|-----------|-------|-------|");

                int x = semilla;
                int totalGenerados = 0;

                for (int i = 0; i < cantidadNumeros; i++)
                {
                    try
                    {
                        long cuadrado = (long)x * x;
                        string cuadradoTexto = cuadrado.ToString().PadLeft(8, '0');
                        string centro = cuadradoTexto.Substring(2, 4);
                        int nuevoX = int.Parse(centro);
                        string rTexto = "0." + nuevoX.ToString("D4");
                        double r = double.Parse(rTexto);
                        r = Math.Round(r, 4);
                        listaRi.Add(r);

                        verificar = verificador(r);

                        if (verificar == true)
                        {
                            Console.WriteLine($"| {i,-2} | {cuadrado,-9} | {nuevoX,-5} | {r,-5:F4} |");
                            x = nuevoX;
                            totalGenerados++;
                        }
                        else
                        {
                            Console.WriteLine($"\nSe detuvo en iteración {i}");
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"\nError en iteración {i}");
                        break;
                    }
                }

                Console.WriteLine("===========================================");
                Console.WriteLine($"\nTotal: {totalGenerados} de {cantidadNumeros}");

                numerosUnicos.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            finally
            {
                PruebaCorridasMedia(listaRi);
                Console.WriteLine("\nPresiona cualquier tecla...");
                Console.ReadKey();
            }
        }

        static void ProductosMedios()
        {
            Console.Clear();
            listaRi.Clear();
            try
            {
                Console.WriteLine("=== PRODUCTOS MEDIOS ===\n");

                int x0 = 0, x1 = 0;

                try
                {
                    Console.Write("Primera semilla X0 (4 dígitos): ");
                    x0 = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                try
                {
                    Console.Write("Segunda semilla X1 (4 dígitos): ");
                    x1 = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                if (x0 < 1000 || x0 > 9999 || x1 < 1000 || x1 > 9999)
                {
                    Console.WriteLine("Error: Ambas deben ser de 4 dígitos");
                    Console.ReadKey();
                    return;
                }

                int cantidadNumeros = 0;
                try
                {
                    Console.Write("\n¿Cuántos números generar? ");
                    cantidadNumeros = int.Parse(Console.ReadLine());

                    if (cantidadNumeros <= 0)
                    {
                        Console.WriteLine("Error: Número positivo requerido");
                        Console.ReadKey();
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("\nGenerando...\n");

                numerosUnicos.Clear();
                verificar = true;

                Console.WriteLine("RESULTADOS:");
                Console.WriteLine("===========================================");
                Console.WriteLine("| i | Producto  | X_i+1 | r_i   |");
                Console.WriteLine("|---|-----------|-------|-------|");

                int totalGenerados = 0;
                int xActual = x0;
                int xSiguiente = x1;

                for (int i = 0; i < cantidadNumeros; i++)
                {
                    try
                    {
                        long producto = (long)xActual * xSiguiente;
                        string productoTexto = producto.ToString().PadLeft(8, '0');
                        string centro = productoTexto.Substring(2, 4);
                        int nuevoX = int.Parse(centro);
                        string rTexto = "0." + nuevoX.ToString("D4");
                        double r = double.Parse(rTexto);
                        r = Math.Round(r, 4);
                        listaRi.Add(r);

                        verificar = verificador(r);

                        if (verificar == true)
                        {
                            Console.WriteLine($"| {i,-2} | {producto,-9} | {nuevoX,-5} | {r,-5:F4} |");
                            xActual = xSiguiente;
                            xSiguiente = nuevoX;
                            totalGenerados++;
                        }
                        else
                        {
                            Console.WriteLine($"\nSe detuvo en iteración {i}");
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"\nError en iteración {i}");
                        break;
                    }
                }

                Console.WriteLine("===========================================");
                Console.WriteLine($"\nTotal: {totalGenerados} de {cantidadNumeros}");

                numerosUnicos.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            finally
            {
                PruebaCorridasMedia(listaRi);
                Console.WriteLine("\nPresiona cualquier tecla...");
                Console.ReadKey();
            }
        }

        public static void AlgoritmoCongruencialAditivo()
        {
            Console.Clear();
            listaRi.Clear();
            try
            {
                Console.WriteLine("=== CONGRUENCIAL ADITIVO ===\n");

                Console.WriteLine("Secuencia inicial (separada por comas):");
                Console.Write("Ejemplo: 65,89,98,03,69 : ");
                string entrada = Console.ReadLine();

                List<int> secuenciaInicial = entrada.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(int.Parse)
                                                   .ToList();

                if (secuenciaInicial.Count < 2)
                {
                    Console.WriteLine("Error: Mínimo 2 números");
                    Console.ReadKey();
                    return;
                }

                int m = 0;
                try
                {
                    Console.Write("\nMódulo m: ");
                    m = int.Parse(Console.ReadLine());

                    if (m <= 0)
                    {
                        Console.WriteLine("Error: m positivo requerido");
                        Console.ReadKey();
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                int cantidadAGenerar = 0;
                try
                {
                    Console.Write("¿Cuántos números generar? ");
                    cantidadAGenerar = int.Parse(Console.ReadLine());

                    if (cantidadAGenerar <= 0)
                    {
                        Console.WriteLine("Error: Número positivo requerido");
                        Console.ReadKey();
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("\nGenerando...\n");

                Program.numerosUnicos.Clear();
                Program.verificar = true;

                Console.WriteLine("Secuencia: " + string.Join(", ", secuenciaInicial));
                Console.WriteLine($"n = {secuenciaInicial.Count}, m = {m}\n");

                Console.WriteLine("RESULTADOS:");
                Console.WriteLine("========================");
                Console.WriteLine("| i | X_i | r_i   |");
                Console.WriteLine("|---|-----|-------|");

                List<int> X = new List<int>(secuenciaInicial);
                int n = X.Count;
                int totalGenerados = 0;

                for (int i = 0; i < cantidadAGenerar; i++)
                {
                    try
                    {
                        int x_anterior = X[X.Count - 1];
                        int x_n_posiciones_atras = X[i];
                        int nuevo_X = (x_anterior + x_n_posiciones_atras) % m;
                        double nuevo_r = (double)nuevo_X / (m - 1);
                        nuevo_r = Math.Round(nuevo_r, 4);
                        listaRi.Add(nuevo_r);

                        Program.verificar = Program.verificador(nuevo_r);

                        if (Program.verificar == true)
                        {
                            int indice_X = n + i + 1;
                            Console.WriteLine($"| {indice_X,-2} | {nuevo_X,-3} | {nuevo_r,-5:F4} |");
                            X.Add(nuevo_X);
                            totalGenerados++;
                        }
                        else
                        {
                            Console.WriteLine($"\nSe detuvo en iteración {i + 1}");
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"\nError en iteración {i + 1}");
                        break;
                    }
                }

                Console.WriteLine("========================");
                Console.WriteLine($"\nTotal: {totalGenerados} de {cantidadAGenerar}");

                Program.numerosUnicos.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            finally
            {
                PruebaCorridasMedia(listaRi);
                Console.WriteLine("\nPresiona cualquier tecla...");
                Console.ReadKey();
            }
        }

        public static void AlgoritmoCongruencialMultiplicativo()
        {
            Console.Clear();
            listaRi.Clear();
            try
            {
                Console.WriteLine("=== CONGRUENCIAL MULTIPLICATIVO ===\n");

                int x0 = 0, a = 0, m = 0;
                int opcionCalculo = 0;

                try
                {
                    Console.Write("Semilla X0 (impar): ");
                    x0 = int.Parse(Console.ReadLine());

                    if (x0 % 2 == 0)
                    {
                        Console.WriteLine("Error: X0 debe ser impar");
                        Console.ReadKey();
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("\nOpciones:");
                Console.WriteLine("1. Calcular a y m con k y g");
                Console.WriteLine("2. Ingresar a y m directamente");
                Console.Write("Elige (1 o 2): ");

                try
                {
                    opcionCalculo = int.Parse(Console.ReadLine());

                    if (opcionCalculo != 1 && opcionCalculo != 2)
                    {
                        Console.WriteLine("Error: Opción no válida");
                        Console.ReadKey();
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                if (opcionCalculo == 1)
                {
                    int k = 0, g = 0;

                    try
                    {
                        Console.Write("\nk: ");
                        k = int.Parse(Console.ReadLine());

                        if (k < 0)
                        {
                            Console.WriteLine("Error: k no negativo");
                            Console.ReadKey();
                            return;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error: Número inválido");
                        Console.ReadKey();
                        return;
                    }

                    try
                    {
                        Console.Write("g: ");
                        g = int.Parse(Console.ReadLine());

                        if (g <= 0)
                        {
                            Console.WriteLine("Error: g positivo");
                            Console.ReadKey();
                            return;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error: Número inválido");
                        Console.ReadKey();
                        return;
                    }

                    m = (int)Math.Pow(2, g);

                    Console.WriteLine("\nFórmula para a:");
                    Console.WriteLine("1. a = 3 + 8k");
                    Console.WriteLine("2. a = 5 + 8k");
                    Console.Write("Elige (1 o 2): ");

                    int opcionA = int.Parse(Console.ReadLine());

                    if (opcionA == 1)
                        a = 3 + (8 * k);
                    else
                        a = 5 + (8 * k);

                    Console.WriteLine($"\nm = {m}, a = {a}");
                }
                else
                {
                    try
                    {
                        Console.Write("\na: ");
                        a = int.Parse(Console.ReadLine());

                        if (a <= 0)
                        {
                            Console.WriteLine("Error: a positivo");
                            Console.ReadKey();
                            return;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error: Número inválido");
                        Console.ReadKey();
                        return;
                    }

                    try
                    {
                        Console.Write("m: ");
                        m = int.Parse(Console.ReadLine());

                        if (m <= 0)
                        {
                            Console.WriteLine("Error: m positivo");
                            Console.ReadKey();
                            return;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error: Número inválido");
                        Console.ReadKey();
                        return;
                    }
                }

                int cantidadNumeros = 0;
                try
                {
                    Console.Write("\n¿Cuántos números generar? ");
                    cantidadNumeros = int.Parse(Console.ReadLine());

                    if (cantidadNumeros <= 0)
                    {
                        Console.WriteLine("Error: Número positivo requerido");
                        Console.ReadKey();
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Error: Número inválido");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("\nGenerando...\n");

                Program.numerosUnicos.Clear();
                Program.verificar = true;

                Console.WriteLine("RESULTADOS:");
                Console.WriteLine("=======================================");
                Console.WriteLine("| i | Operación    | X_i | r_i   |");
                Console.WriteLine("|---|--------------|-----|-------|");

                int x_actual = x0;
                int totalGenerados = 0;

                for (int i = 1; i <= cantidadNumeros; i++)
                {
                    try
                    {
                        int nuevo_X = (a * x_actual) % m;
                        double nuevo_r = (double)nuevo_X / (m - 1);
                        nuevo_r = Math.Round(nuevo_r, 4);
                        listaRi.Add(nuevo_r);

                        Program.verificar = Program.verificador(nuevo_r);

                        if (Program.verificar == true)
                        {
                            string operacion = $"{a}*{x_actual} mod {m}";
                            Console.WriteLine($"| {i,-2} | {operacion,-12} | {nuevo_X,-3} | {nuevo_r,-5:F4} |");
                            x_actual = nuevo_X;
                            totalGenerados++;
                        }
                        else
                        {
                            Console.WriteLine($"\nSe detuvo en iteración {i}");
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"\nError en iteración {i}");
                        break;
                    }
                }

                Console.WriteLine("=======================================");
                Console.WriteLine($"\nTotal: {totalGenerados} de {cantidadNumeros}");

                Program.numerosUnicos.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            finally
            {
                PruebaCorridasMedia(listaRi);
                Console.WriteLine("\nPresiona cualquier tecla...");
                Console.ReadKey();
            }
        }

        static void PruebaCorridasMedia(List<double> datos)
        {
            int n = datos.Count;

            if (n < 2)
            {
                Console.WriteLine("No hay suficientes datos para la prueba");
                return;
            }

            double media = 0.5;
            List<int> unosCeros = new List<int>();

            foreach (var r in datos)
            {
                if (r >= media)
                    unosCeros.Add(1);
                else
                    unosCeros.Add(0);
            }

            // Contar corridas
            int corridas = 1;

            for (int i = 1; i < unosCeros.Count; i++)
            {
                if (unosCeros[i] != unosCeros[i - 1])
                    corridas++;
            }

            // Contar n1 y n2
            int n1 = unosCeros.Count(s => s == 1);
            int n2 = unosCeros.Count(s => s == 0);
            string cerosUnosLista = string.Join(", ", unosCeros);

            // Media esperada
            double mediaCorridas = ((2.0 * n1 * n2) / n) + 1;

            // Varianza
            double varianza = (2.0 * n1 * n2 * (2 * n1 * n2 - n)) /
                              (Math.Pow(n, 2) * (n - 1));

            double desviacion = Math.Sqrt(varianza);

            // Estadístico Z
            double z = (corridas - mediaCorridas) / desviacion;

            double limiteTablaN = 1.96;

            Console.WriteLine("\n===== PRUEBA DE CORRIDAS =====");
            Console.WriteLine("Binarización de la muestra: " + cerosUnosLista);
            Console.WriteLine($"n = {n}");
            Console.WriteLine($"Número de: 1 = {n1}, 0 = {n2}");
            Console.WriteLine($"Corridas = {corridas}");
            Console.WriteLine($"Media esperada = {mediaCorridas:F4}");
            Console.WriteLine($"Varianza = {varianza:F4}");
            Console.WriteLine($"Estadístico Z = {z:F4}");

            if (Math.Abs(z) < limiteTablaN)
                Console.WriteLine("No se rechaza la independencia. El conjunto de números es apto para la simulación");
            else
                Console.WriteLine("Los números NO son independientes.");
        }
    }
}