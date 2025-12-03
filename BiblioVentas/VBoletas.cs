using System;
using BilioSubMenus;
using BiblioRegistrar;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioVentas
{
    public class VBoletas
    {
        //**********SIMULADOR DE TEXTBOX**********
        public static string LeerTextBox(int x, int y, int maxLen)
        {

            Console.SetCursorPosition(x, y);
            Console.Write(new string(' ', maxLen));
            Console.SetCursorPosition(x, y);

            string texto = "";
            ConsoleKeyInfo tecla;

            while (true)
            {
                tecla = Console.ReadKey(true);

                if (tecla.Key == ConsoleKey.Enter)
                    break;

                if (tecla.Key == ConsoleKey.Backspace)
                {
                    if (texto.Length > 0)
                    {
                        texto = texto.Substring(0, texto.Length - 1);

                        Console.SetCursorPosition(x, y);
                        Console.Write(new string(' ', maxLen));
                        Console.SetCursorPosition(x, y);
                        Console.Write(texto);
                    }
                }
                else if (!char.IsControl(tecla.KeyChar) && texto.Length < maxLen)
                {
                    texto += tecla.KeyChar;
                    Console.Write(tecla.KeyChar);
                }
            }
            return texto;
        }

        public class ItemsBoleta
        {
            public string Codigo { get; set; }
            public string Producto { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio { get; set; }
            public decimal Monto { get; set; }
        }
        public class Boleta
        {
            public string DNICLIENTE { get; set; }
            public string NROBOLETA { get; set; }
            public string CLIENTE { get; set; }
            public string VENDEDOR { get; set; }
            public decimal TOTAL { get; set; }

            public List<ItemsBoleta> Items { get; set; } = new List<ItemsBoleta>();
        }

        public static List<Boleta> listaBoleta = new List<Boleta>();

        public static void MostrarBoleta()
        {
            string dniCliente;
            string nroBoleta;
            string nombreCliente;
            int alineaIzquierda = 1;

            //**********IMPRIMO EL MENU ESTATICO**********
            string[] arregloMenu = { "REGISTRA", "VENTAS", "REPORTES", "MODIFICAR", "AYUDA", "SALIR" };

            Console.Clear();

            ClaseInterfaz.Interfaz();

            for (int i = 0; i < arregloMenu.Length; i++)
            {
                Console.SetCursorPosition(alineaIzquierda, 3);

                if (i == 1)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.Write("                 ");
                Console.SetCursorPosition(alineaIzquierda + 4, 3);
                Console.Write(arregloMenu[i]);
                Console.ResetColor();

                alineaIzquierda = alineaIzquierda + 18;
            }

            //**********IMPRIMO LAS ENTRADAS DE TEXTO**********
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(45, 6);
                Console.Write("BOLETA DE VENTA");

                Console.SetCursorPosition(8, 8);
                Console.Write("DNI CLIENTE    :");

                Console.SetCursorPosition(8, 10);
                Console.Write("CLIENTE        :");

                Console.SetCursorPosition(8, 12);
                Console.Write("NRO BOLETA     :");

                Console.SetCursorPosition(8, 24);
                Console.Write("DNI VENDEDOR   :");

                Console.SetCursorPosition(70, 24);
                Console.Write("TOTAL          :");

                //**********IMPRIMO EL ENCABEZADO DE LA TABLA DE LOS PRODUCTOS**********
                string[] productos = { "CODIGO", "PRODUCTOS", "CANTIDAD", "PRECIO UNITARIO", "MONTO" };

                int x = 8;
                int y = 14;

                for (int i = 0; i < productos.Length; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(productos[i]);

                    x += 20;
                }

                //**********PEDIMOS EL DNI DEL CLIENTE**********
                while (true)
                {

                    Console.SetCursorPosition(26, 8); Console.Write(new string(' ', 12));
                    Console.SetCursorPosition(26, 10); Console.Write(new string(' ', 30));

                    dniCliente = LeerTextBox(26, 8, 8);

                    var cli = RCliente.listaClientes.Find(c => c.DNI == dniCliente);

                    if (cli != null)
                    {
                        nombreCliente = cli.Nombre;

                        Console.SetCursorPosition(26, 10);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(nombreCliente);
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(26, 10);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Error: Cliente no registrado.");
                        Console.ResetColor();

                        Console.ReadKey(true);

                        Console.SetCursorPosition(26, 10);
                        Console.Write(new string(' ', 30));
                    }
                }

                //**********PEDIMOS EL NUMERO DE BOLETA**********
                nroBoleta = LeerTextBox(26, 12, 12);

                //**********PEDIMOS EL INGRESO DE PRODUCTOS**********
                Console.SetCursorPosition(40, 12);
                Console.WriteLine("Presione cualquier tecla para ingresar los productos...");
                Console.ReadKey(true);
                Console.SetCursorPosition(40, 12);
                Console.Write(new string(' ', 60));

                Console.SetCursorPosition(10, 13);
                Console.Write(new string(' ', 55));

                string[,] tabla = new string[5, 5];

                bool salir = false;

                for (int fila = 0; fila < 5; fila++)
                {
                    while (true)
                    {
                        Console.SetCursorPosition(10, 16 + fila);
                        Console.Write(new string(' ', 10));
                        Console.SetCursorPosition(8, 16 + fila);

                        string codigo = LeerTextBox(8, 16 + fila, 10);

                        if (codigo.ToUpper() == "FIN")
                        {
                            Console.SetCursorPosition(8, 16 + fila);
                            Console.Write(new string(' ', 10));
                            salir = true;
                            break;
                        }
                        var prod = RProducto.listaProductos.Find(p => p.Codigo == codigo);

                        if (prod != null)
                        {
                            tabla[fila, 0] = prod.Codigo;
                            tabla[fila, 1] = prod.Nombre;
                            tabla[fila, 3] = prod.Precio.ToString("0.00");

                            Console.SetCursorPosition(28, 16 + fila);
                            Console.Write(new string(' ', 20));
                            Console.SetCursorPosition(28, 16 + fila);
                            Console.Write(prod.Nombre);

                            Console.SetCursorPosition(68, 16 + fila);
                            Console.Write(new string(' ', 10));
                            Console.SetCursorPosition(68, 16 + fila);
                            Console.Write(prod.Precio.ToString("0.00"));
                        }
                        else
                        {
                            Console.SetCursorPosition(20, 16 + fila);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Error: Código no registrado");
                            Console.ResetColor();
                            Console.ReadKey(true);

                            Console.SetCursorPosition(20, 16 + fila);
                            Console.Write(new string(' ', 40));

                            continue;
                        }

                        while (true)
                        {
                            Console.SetCursorPosition(48, 16 + fila);
                            Console.Write(new string(' ', 5));
                            Console.SetCursorPosition(48, 16 + fila);

                            string cantStr = LeerTextBox(48, 16 + fila, 5);

                            if (!int.TryParse(cantStr, out int cantidad) || cantidad <= 0)
                            {
                                Console.SetCursorPosition(20, 18);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Cantidad no válida.");
                                Console.ResetColor();
                                Console.ReadKey(true);
                                Console.SetCursorPosition(20, 18);
                                Console.Write(new string(' ', 40));
                                continue;
                            }

                            string codProdTemp = tabla[fila, 0];
                            var producto = RProducto.listaProductos.FirstOrDefault(p => p.Codigo == codProdTemp);

                            if (cantidad > producto.Stock)
                            {
                                Console.SetCursorPosition(20, 18);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($"Error: Stock insuficiente (Disponible: {producto.Stock}).");
                                Console.ResetColor();
                                Console.ReadKey(true);
                                Console.SetCursorPosition(20, 18);
                                Console.Write(new string(' ', 50));
                                continue;
                            }

                            tabla[fila, 2] = cantidad.ToString();

                            decimal precio = decimal.Parse(tabla[fila, 3]);
                            decimal monto = precio * cantidad;
                            tabla[fila, 4] = monto.ToString("0.00");

                            Console.SetCursorPosition(88, 16 + fila);
                            Console.Write(new string(' ', 10));
                            Console.SetCursorPosition(88, 16 + fila);
                            Console.Write(monto.ToString("0.00"));
                            break;
                        }
                        break;
                    }
                    if (salir)
                        break;
                }

                string dniVendedor;
                string nombreVendedor;

                while (true)
                {
                    Console.SetCursorPosition(26, 24);
                    Console.Write(new string(' ', 12));

                    dniVendedor = LeerTextBox(26, 24, 8);

                    var vend = RVendedor.listaVendedores.Find(v => v.Codigo == dniVendedor);

                    if (vend == null)
                    {
                        Console.SetCursorPosition(36, 24);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Error: Vendedor no registrado.");
                        Console.ResetColor();
                        Console.ReadKey(true);

                        Console.SetCursorPosition(26, 24);
                        Console.Write(new string(' ', 40));
                    }
                    else
                    {
                        nombreVendedor = vend.Nombre + " " + vend.Apellidos;

                        Console.SetCursorPosition(36, 24);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("- " + nombreVendedor);
                        Console.ResetColor();
                        break;
                    }
                }

                decimal total = 0;

                for (int i = 0; i < 5; i++)
                {
                    if (!string.IsNullOrEmpty(tabla[i, 4]))
                        total += decimal.Parse(tabla[i, 4]);
                }

                Console.SetCursorPosition(82, 24);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(total.ToString("0.00"));
                Console.ResetColor();

                string[] GC = { "GUARDAR", "CANCELAR" };
                int opcionGC = 0;

                while (true)
                {
                    Console.SetCursorPosition(30, 26);
                    Console.Write(new string(' ', 40));

                    for (int i = 0; i < GC.Length; i++)
                    {
                        if (i == opcionGC)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        Console.SetCursorPosition(30 + (i * 12), 26);
                        Console.Write($" {GC[i]} ");

                        Console.ResetColor();
                    }

                    ConsoleKey key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.RightArrow)
                    {
                        opcionGC++;
                        if (opcionGC >= GC.Length) opcionGC = 0;
                    }

                    if (key == ConsoleKey.LeftArrow)
                    {
                        opcionGC--;
                        if (opcionGC < 0) opcionGC = GC.Length - 1;
                    }

                    if (key == ConsoleKey.Enter)
                        break;
                }

                Console.ResetColor();
                Console.Clear();

                if (opcionGC == 0)
                {
                    Boleta nuevaBoleta = new Boleta();
                    nuevaBoleta.DNICLIENTE = dniCliente;
                    nuevaBoleta.CLIENTE = nombreCliente;
                    nuevaBoleta.NROBOLETA = nroBoleta;
                    nuevaBoleta.VENDEDOR = nombreVendedor;
                    nuevaBoleta.TOTAL = total;

                    for (int i = 0; i < 5; i++)
                    {
                        if (tabla[i, 0] != null)
                        {
                            nuevaBoleta.Items.Add(new ItemsBoleta
                            {
                                Codigo = tabla[i, 0],
                                Producto = tabla[i, 1],
                                Cantidad = int.Parse(tabla[i, 2]),
                                Precio = decimal.Parse(tabla[i, 3]),
                                Monto = decimal.Parse(tabla[i, 4])
                            });
                        }
                    }
                    listaBoleta.Add(nuevaBoleta);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Su boleta ha sido guardada, presione cualquier boton para salir.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Su boleta no ha sido guardada, presione cualquier boton para salir.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                return;
            }
        }
    }
}
