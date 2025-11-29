using BiblioRegistrar;
using BiblioVentas;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BiblioVentas.VBoletas;

namespace BilioSubMenus
{
    public class SubMenus
    {
        public static void SubMenuRegistrar()
        {
            int sub;
            do
            {
                sub = Registrar.Registra();

                switch (sub)
                {
                    case 0:
                        RProducto.RegistrarProducto();
                        break;

                    case 1:
                        RCliente.RegistrarCliente();
                        break;

                    case 2:
                        RVendedor.RegistrarVendedor();
                        break;

                    case 3:
                        RProveedores.RegistrarProveedor();
                        break;

                }
            } while (sub != -1);

        }
        public static void SubMenuVenta()
        {
            int sub;
            do
            {
                sub = Ventas.Venta();

                switch (sub)
                {
                    case 0:
                        VBoletas.MostrarBoleta();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Seguimos trabajando...");
                        Console.ReadKey(true);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Seguimos trabajando...");
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Seguimos trabajando...");
                        Console.ReadKey(true);
                        break;
                }
            }
            while (sub != -1);
        }
    }
}
