using System;
using BiblioRegistrar;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioVentas
{
    public class VBoletas
    {
        public class Boleta
        {
            public string DNICLIENTE { get; set; }
            public string NROBOLETA { get; set; }
            public string CLIENTE { get; set; }
            public string VENDEDOR { get; set; }
            public decimal TOTAL { get; set; }
        }

        static List<Boleta> listaBoleta = new List<Boleta>();

        public static int MostrarBoleta()
        {
            string dniCliente = "";
            string nroBoleta = "";
            string nombreCliente = "";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("                    BOLETA DE VENTA\n");

                Console.Write(" DNI CLIENTE: ");
                dniCliente = Console.ReadLine();

                if (dniCliente.Length != 8 || !dniCliente.All(char.IsDigit))
                {
                    Console.WriteLine("\nEl DNI ingresado debe tener 8 digitos numericos.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }



                RCliente.Cliente clienteEncontrado = RCliente.listaClientes.Find(c => c.DNI == dniCliente);

                if (clienteEncontrado != null)
                    break;

                Console.WriteLine("\n DNI no registrado como cliente.");
                Console.WriteLine(" Presione una tecla para intentar de nuevo...");
                Console.ReadKey();
            }

            Console.Write("\n NRO BOLETA: ");
            nroBoleta = Console.ReadLine();

            Console.Write("\n CLIENTE (nombre): ");
            nombreCliente = Console.ReadLine();

            List<(string Codigo, string Nombre, int Cant, decimal Precio, decimal Monto)> detalles =
                new List<(string, string, int, decimal, decimal)>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("                    BOLETA DE VENTA\n");
                Console.WriteLine($" DNI CLIENTE: {dniCliente}          NRO BOLETA: {nroBoleta}");
                Console.WriteLine($" CLIENTE: {nombreCliente}\n");

                Console.WriteLine(" --------------------------------------------------------------");
                Console.WriteLine(" CODIGO        PRODUCTO        CANT        PRECIO        MONTO");
                Console.WriteLine(" --------------------------------------------------------------");

                foreach ((string Codigo, string Nombre, int Cant, decimal Precio, decimal Monto) d in detalles)
                {
                    Console.WriteLine($" {d.Codigo,-12} {d.Nombre,-14} {d.Cant,-10} {d.Precio,-12:0.00} {d.Monto:0.00}");
                }

                Console.WriteLine(" ");

                Console.Write(" Codigo: ");
                string codigo = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(codigo))
                    break;

                RProducto.Producto producto = RProducto.listaProductos
                    .Find(p => p.Codigo == codigo);

                if (producto == null)
                {
                    Console.WriteLine("\n Código no encontrado.");
                    Console.WriteLine(" Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine($" Producto: {producto.Nombre}");

                int cant;
                while (true)
                {
                    Console.Write(" Cantidad: ");
                    bool esNumero = int.TryParse(Console.ReadLine(), out cant);

                    if (esNumero)
                    {
                        if (cant <= producto.Stock)
                            break;

                        Console.WriteLine($" Stock insuficiente. Solo quedan {producto.Stock} unidades.");
                    }
                    else
                    {
                        Console.WriteLine(" Ingrese un número válido.");
                    }
                }

                decimal monto = cant * producto.Precio;

                producto.Stock -= cant;

                detalles.Add((producto.Codigo, producto.Nombre, cant, producto.Precio, monto));
            }

            string dniVendedor = "";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("                    BOLETA DE VENTA\n");
                Console.WriteLine($" DNI CLIENTE: {dniCliente}          NRO BOLETA: {nroBoleta}");
                Console.WriteLine($" CLIENTE: {nombreCliente}\n");

                Console.WriteLine(" --------------------------------------------------------------");
                Console.WriteLine(" CODIGO        PRODUCTO        CANT        PRECIO        MONTO");
                Console.WriteLine(" --------------------------------------------------------------");

                foreach ((string Codigo, string Nombre, int Cant, decimal Precio, decimal Monto) d in detalles)
                {
                    Console.WriteLine($" {d.Codigo,-12} {d.Nombre,-14} {d.Cant,-10} {d.Precio,-12:0.00} {d.Monto:0.00}");
                }
                Console.WriteLine(" --------------------------------------------------------------");
                Console.Write("\n DNI VENDEDOR: ");
                dniVendedor = Console.ReadLine();

                if (dniCliente.Length != 8 || !dniCliente.All(char.IsDigit))
                {
                    Console.WriteLine("\nEl DNI ingresado debe tener 8 digitos numericos.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                RVendedor.Vendedores vend = RVendedor.listaVendedores
                    .Find(v => v.Codigo == dniVendedor);

                if (vend != null) break;

                Console.WriteLine("\n DNI de vendedor no válido.");
                Console.ReadKey();
            }

            decimal total = detalles.Sum(d => d.Monto);

            int opcion = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("                    BOLETA DE VENTA\n");
                Console.WriteLine($" DNI CLIENTE: {dniCliente}          NRO BOLETA: {nroBoleta}");
                Console.WriteLine($" CLIENTE: {nombreCliente}\n");

                Console.WriteLine(" --------------------------------------------------------------");
                Console.WriteLine(" CODIGO        PRODUCTO        CANT        PRECIO        MONTO");
                Console.WriteLine(" --------------------------------------------------------------");

                foreach ((string Codigo, string Nombre, int Cant, decimal Precio, decimal Monto) d in detalles)
                {
                    Console.WriteLine($" {d.Codigo,-12} {d.Nombre,-14} {d.Cant,-10} {d.Precio,-12:0.00} {d.Monto:0.00}");
                }

                Console.WriteLine(" --------------------------------------------------------------");

                Console.WriteLine($" DNI VENDEDOR: {dniVendedor}          TOTAL: {total}\n");

                Console.WriteLine($"{(opcion == 0 ? ">" : " ")} [ GUARDAR ]    {(opcion == 1 ? ">" : " ")} [ CANCELAR ]");

                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.LeftArrow) opcion = 0;
                if (key == ConsoleKey.RightArrow) opcion = 1;

                if (key == ConsoleKey.Enter)
                {
                    if (opcion == 0)
                    {
                        Boleta nuevaBoleta = new Boleta
                        {
                            DNICLIENTE = dniCliente,
                            CLIENTE = nombreCliente,
                            NROBOLETA = nroBoleta,
                            VENDEDOR = dniVendedor,
                            TOTAL = total
                        };

                        listaBoleta.Add(nuevaBoleta);

                        Console.WriteLine("\n BOLETA GUARDADA.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("\n OPERACIÓN CANCELADA.");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
