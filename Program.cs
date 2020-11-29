using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMascotas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PROGRAMA PARA TIENDA DE MASCOTAS");
            Console.WriteLine();
            Console.WriteLine("Los productos que vendemos son:");
            var petshop = new Dictionary<string, double>()
         {
             {"Galletitas",70.00},
             {"Alimentos",600.00},
             {"Juguetes",250.00}
         };

            //IMPRIMIR  los productos de venta
            foreach (var productos in petshop)
                Console.WriteLine("producto: {0}, precio: {1}", productos.Key, productos.Value); 

            menu(petshop);

        }
        static void cobro(Dictionary<string, double> petshop)
        {
            Console.WriteLine("CAJA");
            Console.WriteLine("Desea generar una factura [si/no]");
            string factura = Console.ReadLine();
            //MAX DOS PRODUCTOS
            while (factura == "si")
            {
                Console.WriteLine("Ingrese el nombre del cliente");
                string cliente = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre del producto a comprar");
                string prodVenta = Console.ReadLine();
                Console.WriteLine("Ingrese la cantidad del producto a comprar");
                int cantiVenta = int.Parse(Console.ReadLine());
                Console.WriteLine("Desea cargar otro producto [si/no]");
                string otroProducto = Console.ReadLine();
                while (otroProducto == "si")
                {
                    Console.WriteLine("Ingrese el nombre del producto a comprar");
                    string prodVenta2 = Console.ReadLine();
                    Console.WriteLine("Ingrese la cantidad del producto a comprar");
                    int cantiVenta2 = int.Parse(Console.ReadLine());
                    if (petshop.ContainsKey(prodVenta ) || petshop.ContainsKey(prodVenta2))
                    {
                        Console.WriteLine("FACTURA");
                        Console.WriteLine($"CLIENTE: {cliente}  \n COMPRA: {prodVenta}  IMPORTE {(petshop[prodVenta])*cantiVenta} \n COMPRA: {prodVenta2}  IMPORTE  {(petshop[prodVenta2]) * cantiVenta2}");
                        Console.WriteLine($"TOTAL { ((petshop[prodVenta]) * cantiVenta)+ ((petshop[prodVenta2]) * cantiVenta2)}");
                    }

                    Console.WriteLine("Presione cualquier tecla para continuar");
                     otroProducto = Console.ReadLine();
                }

                Console.WriteLine("Desea generar otra factura");
                factura = Console.ReadLine();
            }
            menu(petshop);
        }

        static void agregar(Dictionary<string, double> petshop)
        {
            //ACTULIZAR y AGREGAR productos 
            Console.WriteLine(" Que producto desa actualizar o agregar");
            string products = Console.ReadLine();
            Console.WriteLine("Agregue el precio");
            double information = double.Parse(Console.ReadLine());
            petshop[products] = information; // actualizar el valor y la clave 
            Console.WriteLine("Operacion exitosa");
            menu(petshop);
        }

        static void consulta(Dictionary<string, double> petshop)
        {
            //CONSULTA DE PRECIO 
            //IMPRIMIR  los productos de venta
            foreach (var productos in petshop)
                Console.WriteLine("producto: {0}", productos.Key); //Las claves deben ser únicas
            Console.WriteLine(" Que precio desea consultar");
            var venta = Console.ReadLine();
            if (petshop.ContainsKey(venta))
            {
                Console.WriteLine($"El precio a cobrar es {petshop[venta]}");
            }
            menu(petshop);
        }

        static void eliminiarAgregar(Dictionary<string, double> petshop)
        {
            //ELIMINAR ELEMENTOS DE LOS PRECIOS
            Console.WriteLine("Desea eliminar algun producto en el listado de precios[si/no]");
            string eliminar = Console.ReadLine();

            if (eliminar == "si")
            {
                Console.WriteLine("Indique que elemento quiere eliminar");
                string eliminarA = Console.ReadLine();
                Console.WriteLine(" Operacion exitosa");
                if (petshop.ContainsKey(eliminarA)) // revise la clave antes de quitarla
                {
                    petshop.Remove(eliminarA);
                    Console.WriteLine("Los precios actuales son:");
                    foreach (var clavex in petshop) //Para imprimir con la actualizacion
                    {
                        Console.WriteLine("producto: {0}, precio: {1}", clavex.Key, clavex.Value);
                    }

                }
                else Console.WriteLine("No existe el producto a eliminar");
            }
            else
            {
                Console.WriteLine("muchas grcias");
            }
            menu(petshop);
        }

        //MENÚ
        static void menu(Dictionary<string, double> petshop)
        {
            Console.WriteLine("");
            Console.WriteLine("Escriba un numero por la opcion seleccionada \n [1] Agregar/modificar productos  \n [2] Consultar productos  \n [3] Eliminar productos  \n [4] Registrar un cobro \n [5] Salir");
            int factura = int.Parse(Console.ReadLine());

            switch (factura)
            {
                case 1:
                    Console.WriteLine("Selecciono Agregar/modificar productos ");
                    agregar(petshop);
                    break;

                case 2:
                    Console.WriteLine("Consultar productos ");
                    consulta(petshop);
                    break;

                case 3:
                    Console.WriteLine("Selecciono Eliminar productos ");
                    eliminiarAgregar(petshop);
                    break;

                case 4:
                    Console.WriteLine("Selecciono Registrar un cobro");
                    cobro(petshop);
                    break;

                case 5:
                    Console.WriteLine("Muchas gracias por usar la app");
                    break;
            }

        }
    }
}
