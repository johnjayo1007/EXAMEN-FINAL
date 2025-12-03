using System;
using BiblioRegistrar;
using BiblioVentas;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioReportes
{
    public class Reporte
    {
        public static void MostrarReporte(int tipo)
        {
            for (int y = 5; y < 29; y++)
            {
                Console.SetCursorPosition(1, y);
                Console.Write(new string(' ', 108));
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(5, 6);

            string titulo = "";

            switch (tipo)
            {
                case 0: titulo = "REPORTE DE CLIENTES"; break;
                case 1: titulo = "REPORTE DE PRODUCTOS"; break;
                case 2: titulo = "REPORTE DE VENDEDORES"; break;
                case 3: titulo = "REPORTE DE PROVEEDORES"; break;
                case 4: titulo = "REPORTE DE BOLETAS"; break;
                default: titulo = ""; break;
            }

            Console.WriteLine("=== " + titulo + " ===");
            Console.ResetColor();

            int fila = 10;

            switch (tipo)
            {
                case 0: 
                    Console.SetCursorPosition(5, 8);
                    Console.WriteLine("DNI       | NOMBRE         | APELLIDO       | TELÉFONO");
                    Console.SetCursorPosition(5, 9);
                    Console.WriteLine("----------------------------------------------------------");

                    foreach (var c in RCliente.listaClientes)
                    {
                        Console.SetCursorPosition(5, fila++);
                        Console.WriteLine($"{c.DNI.PadRight(10)}| {c.Nombre.PadRight(14)}| {c.Apellido.PadRight(14)}| {c.Telefono}");
                    }
                    break;

                case 1: 
                    Console.SetCursorPosition(5, 8);
                    Console.WriteLine("CÓDIGO    | NOMBRE         | PRECIO");
                    Console.SetCursorPosition(5, 9);
                    Console.WriteLine("-------------------------------------");

                    foreach (var p in RProducto.listaProductos)
                    {
                        Console.SetCursorPosition(5, fila++);
                        Console.WriteLine($"{p.Codigo.PadRight(10)}| {p.Nombre.PadRight(14)}| {p.Precio.ToString("0.00")}");
                    }
                    break;

                case 2: 
                    Console.SetCursorPosition(5, 8);
                    Console.WriteLine("CÓDIGO    | NOMBRE         | APELLIDO       | SUELDO");
                    Console.SetCursorPosition(5, 9);
                    Console.WriteLine("----------------------------------------------------------");

                    foreach (var v in RVendedor.listaVendedores)
                    {
                        Console.SetCursorPosition(5, fila++);
                        Console.WriteLine($"{v.Codigo.PadRight(10)}| {v.Nombre.PadRight(14)}| {v.Apellidos.PadRight(14)}| {v.Sueldo}");
                    }
                    break;

                case 3: 
                    Console.SetCursorPosition(5, 8);
                    Console.WriteLine("CODIGO    | EMPRESA        | RUC          | REPRESENTANTE   | TELÉFONO");
                    Console.SetCursorPosition(5, 9);
                    Console.WriteLine("--------------------------------------------------------------------------");

                    foreach (var pr in RProveedores.listaProveedores)
                    {
                        Console.SetCursorPosition(5, fila++);
                        Console.WriteLine(
                            $"{pr.Codigo.PadRight(10)}| " +
                            $"{pr.Empresa.PadRight(14)}| " +
                            $"{pr.RUC.PadRight(12)}| " +
                            $"{pr.Representante.PadRight(16)}| " +
                            $"{pr.Telefono}"
                        );
                    }
                    break;

                case 4:
                    Console.SetCursorPosition(5, 8);
                    Console.WriteLine("N° BOLETA | CLIENTE          | VENDEDOR         | TOTAL");
                    Console.SetCursorPosition(5, 9);
                    Console.WriteLine("--------------------------------------------------------------");

                    foreach (var b in VBoletas.listaBoleta)
                    {
                        // Cabecera de la boleta
                        Console.SetCursorPosition(5, fila++);
                        Console.WriteLine(
                            $"{b.NROBOLETA.PadRight(10)}| " +
                            $"{b.CLIENTE.PadRight(16)}| " +
                            $"{b.VENDEDOR.PadRight(16)}| " +
                            $"{b.TOTAL.ToString("0.00").PadLeft(8)}"
                        );

                        Console.SetCursorPosition(7, fila++);
                        Console.WriteLine($"COD   | PRODUCTO        | CANT | MONTO");
                        Console.SetCursorPosition(7, fila++);
                        Console.WriteLine("----------------------------------------");

                        foreach (var item in b.Items)
                        {
                            Console.SetCursorPosition(7, fila++);
                            Console.WriteLine(
                                $"{item.Codigo.PadRight(5)}| " +
                                $"{item.Producto.PadRight(16)}| " +
                                $"{item.Cantidad.ToString().PadLeft(3)} | " +
                                $"{item.Monto.ToString("0.00").PadLeft(8)}"
                            );
                        }

                        fila++;
                        Console.SetCursorPosition(5, fila++);
                        Console.WriteLine(new string('-', 60));
                        fila++;
                    }
                    break;
            }

            while (true)
            {
                ConsoleKey tecla = Console.ReadKey(true).Key;
                if (tecla == ConsoleKey.Escape)
                    break;
            }

            for (int y = 5; y < 29; y++)
            {
                Console.SetCursorPosition(1, y);
                Console.Write(new string(' ', 108));
            }
        }
    }
}
