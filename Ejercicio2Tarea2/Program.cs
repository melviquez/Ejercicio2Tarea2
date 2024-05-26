using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2Tarea2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Listas para almacenar la información de las entradas
            List<int> Numero_factura = new List<int>();
            List<int> Cedula = new List<int>();
            List<string> Nombre = new List<string>();
            List<string> Localidad = new List<string>();
            List<int> Cantidad_entradas = new List<int>();
            List<int> Subtotal = new List<int>();
            List<int> Cargosxservicio = new List<int>();
            List<int> Totalpagar = new List<int>();
            string continuar;
            string tipo = "";

            // Bucle para añadir información
            do
            {
                // Solicitar y almacenar la Numero_factura
                Console.Write("Digite el número de factura: ");
                Numero_factura.Add(int.Parse(Console.ReadLine()));

                // Solicitar y almacenar la Cedula
                Console.Write("Digite el número la Cedula: ");
                Cedula.Add(int.Parse(Console.ReadLine()));

                // Solicitar y almacenar el nombre
                Console.Write("Digite el nombre: ");
                Nombre.Add(Console.ReadLine());

                // Solicitar y almacenar el tipo de localidad
                Console.Write("Digite la localidad (1 para Sol Norte/Sur, 2 para Sombra Este/Oeste y 3 para Preferencial): ");
                int tipoNumero = int.Parse(Console.ReadLine());

                if (tipoNumero == 1)
                {
                    tipo = "Sol Norte/Sur";
                }
                else if (tipoNumero == 2)
                {
                    tipo = "Sombra Este/Oeste";
                }
                else if (tipoNumero == 3)
                {
                    tipo = "Preferencial";
                }

                Localidad.Add(tipo);

                // Solicitar y almacenar la Cantidad_entradas
                int cantidadEntradas;
                while (true)
                {
                    Console.Write("Digite la cantidad de entradas (máximo 4): ");
                    cantidadEntradas = int.Parse(Console.ReadLine());

                    if (cantidadEntradas <= 4)
                    {
                        Cantidad_entradas.Add(cantidadEntradas);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Solo puede comprar como máximo 4 entradas. Por favor, intente nuevamente.");
                    }
                }

                // Calcular el precioxlocalidad
                double precioxlocalidad = 0;
                if (tipoNumero == 1)
                {
                    precioxlocalidad = 10500; // Para Sol Norte/Sur
                }
                else if (tipoNumero == 2)
                {
                    precioxlocalidad = 20500; // Para Sombra Este/Oeste
                }
                else if (tipoNumero == 3)
                {
                    precioxlocalidad = 25500; // Para Preferencial
                }

                // Calcular el subtotal
                int Calculosubtotal = (int)(precioxlocalidad * cantidadEntradas);
                Subtotal.Add(Calculosubtotal);

                // Calcular los cargos x servicios
                int cargos = cantidadEntradas * 1000;
                Cargosxservicio.Add(cargos);

                // Calcular el total a pagar
                int total = Calculosubtotal + cargos;
                Totalpagar.Add(total);

                // Mostrar la información de la entrada registrada
                Console.WriteLine("\nInformación de las entradas:");
                Console.WriteLine($"Numero de factura: {Numero_factura[Numero_factura.Count - 1]}");
                Console.WriteLine($"Cedula: {Cedula[Cedula.Count - 1]}");
                Console.WriteLine($"Nombre: {Nombre[Nombre.Count - 1]}");
                Console.WriteLine($"Localidad: {Localidad[Localidad.Count - 1]}");
                Console.WriteLine($"Cantidad de entradas: {Cantidad_entradas[Cantidad_entradas.Count - 1]}");
                Console.WriteLine($"Subtotal: {Subtotal[Subtotal.Count - 1]}");
                Console.WriteLine($"Cargos por servicio: {Cargosxservicio[Cargosxservicio.Count - 1]}");
                Console.WriteLine($"Total a Pagar: {Totalpagar[Totalpagar.Count - 1]}");

                // Preguntar si se quiere añadir más entradas
                Console.Write("¿Quieres registrar otra entrada? (s/n): ");
                continuar = Console.ReadLine().ToLower();

            } while (continuar == "s");

            // Mostrar la información de las entradas compradas
            Console.WriteLine("\nInformación de las entradas compradas:");

            // Calcular la Cantidad Entradas Localidad Sol Norte/Sur

            int cantidadsolns = 0;
            for (int i = 0; i < Localidad.Count; i++)
            {
                if (Localidad[i] == "Sol Norte/Sur")
                {
                    cantidadsolns++;
                }
            }
            Console.WriteLine($"Cantidad Entradas Localidad Sol Norte/Sur: {cantidadsolns}");

            // Calcular el Acumulado de Dinero Localidad Sol Norte/Sur:
            int acumuladosolns = Totalpagar.Where((total, index) => Localidad[index] == "Sol Norte/Sur").Sum();
            Console.WriteLine($"Acumulado de Dinero Localidad Sol Norte/Sur: {acumuladosolns}");

            // Calcular la Cantidad Entradas Localidad Sombra Este/Oeste

            int cantidadsomesoes = 0;
            for (int i = 0; i < Localidad.Count; i++)
            {
                if (Localidad[i] == "Sombra Este/Oeste")
                {
                    cantidadsomesoes++;
                }
            }
            Console.WriteLine($"Cantidad Entradas Localidad Sombra Este/Oeste: {cantidadsomesoes}");

            // Calcular el Acumulado de Dinero Localidad Sol Norte/Sur:
            int acumuladosomesoes = Totalpagar.Where((total, index) => Localidad[index] == "Sombra Este/Oeste").Sum();
            Console.WriteLine($"Acumulado de Dinero Localidad Sombra Este/Oeste: {acumuladosomesoes}");

            // Calcular la Cantidad Entradas Preferencial

            int cantidadPreferencial = 0;
            for (int i = 0; i < Localidad.Count; i++)
            {
                if (Localidad[i] == "Preferencial")
                {
                    cantidadPreferencial++;
                }
            }
            Console.WriteLine($"Cantidad Entradas Localidad Preferencial: {cantidadPreferencial}");

            // Calcular el Acumulado de Dinero Localidad Preferencial
            int acumuladosPreferencial = Totalpagar.Where((total, index) => Localidad[index] == "Preferencial").Sum();
            Console.WriteLine($"Acumulado de Dinero Localidad Preferencial: {acumuladosPreferencial}");
            Console.ReadLine();
        }
    }
}
