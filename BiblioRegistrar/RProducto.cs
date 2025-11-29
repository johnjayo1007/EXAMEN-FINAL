using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioRegistrar
{
    public class RProducto
    {
        public class Producto
        {
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public string Categoria { get; set; }
            public int Stock { get; set; }
            public decimal Precio { get; set; }
        }

        public static List<Producto> listaProductos = new List<Producto>();

        public static void RegistrarProducto()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRO DE PRODUCTOS ===\n");

            string codigo;
            string nombre;

            while (true)
            {
                Console.Write("Código: ");
                codigo = Console.ReadLine().Trim();

                if (codigo == "")
                {
                    Console.WriteLine("ERROR: El código no puede estar vacío.\n");
                    continue;
                }

                bool existe = listaProductos.Any(p => p.Codigo == codigo);
                if (existe)
                    Console.WriteLine("ERROR: El código ya existe.\n");
                else
                    break;
            }

            while (true)
            {
                Console.Write("Nombre: ");
                nombre = Console.ReadLine().Trim();

                if (nombre == "")
                {
                    Console.WriteLine("ERROR: El nombre no puede estar vacío.\n");
                    continue;
                }

                bool existe = listaProductos.Any(p => p.Nombre == nombre);
                if (existe)
                    Console.WriteLine("ERROR: El nombre ya existe.\n");
                else
                    break;
            }

            Console.Write("Categoría: ");
            string categoria = Console.ReadLine().Trim();

            int stock;
            while (true)
            {
                Console.Write("Stock: ");
                if (int.TryParse(Console.ReadLine(), out stock) && stock >= 0)
                    break;

                Console.WriteLine("ERROR: Ingresa un número válido.\n");
            }

            decimal precioU;
            while (true)
            {
                Console.Write("Precio Unitario: ");
                if (decimal.TryParse(Console.ReadLine(), out precioU) && precioU >= 0)
                    break;

                Console.WriteLine("ERROR: Ingresa un precio válido.\n");
            }

            listaProductos.Add(new Producto
            {
                Codigo = codigo,
                Nombre = nombre,
                Categoria = categoria,
                Stock = stock,
                Precio = precioU
            });

            Console.WriteLine("\nProducto registrado exitosamente.");
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
