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
                Console.Clear();
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
                Console.Clear();
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
                Console.Clear();
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
                Console.Clear();
                Console.WriteLine("=== CONGRUENCIALES NO LINEALES ===\n");
                Console.WriteLine("1. Algoritmo congruencial cuadrático");
                Console.WriteLine("2. Algoritmo Blum, Blum y Shub");
                Console.WriteLine("0. Volver");

                mensaje = "\nSeleccione una opción: ";
                opcion = (int)datos(mensaje);

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\nSeleccionaste: Algoritmo congruencial cuadrático");
                        break;

                    case 2:
                        Console.WriteLine("\nSeleccionaste: Algoritmo Blum, Blum y Shub");
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
                Console.Clear();
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
    }
}
