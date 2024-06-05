using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Tienda tienda = new Tienda();
        Carrito carrito = new Carrito();
        bool esCliente = true; // por default arrancamos la tienda en modo cliente

        Console.WriteLine("Bienvenido a la tienda del capitan jobo");

        while (true)
        {
            if (esCliente)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Ver productos disponibles");
                Console.WriteLine("2. Agregar producto al carrito");
                Console.WriteLine("3. Eliminar producto del carrito");
                Console.WriteLine("4. Cobrar compra");
                Console.WriteLine("5. Cambiar a modo dueño");
                Console.WriteLine("6. Salir");
            }
            else
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Agregar producto a la tienda");
                Console.WriteLine("2. Eliminar producto de la tienda");
                Console.WriteLine("3. Ver productos de la tienda");
                Console.WriteLine("4. Cambiar a modo cliente");
                Console.WriteLine("5. Salir");
            }

            string opcion = Console.ReadLine();


            //realizamos el menu interactivo usando switch case 
            if (esCliente)
            {
                switch (opcion)
                {
                    case "1":
                        tienda.MostrarProductos();
                        break;
                    case "2":
                        Console.WriteLine("Ingrese el nombre del producto a agregar al carrito:");
                        string nombreCarrito = Console.ReadLine();
                        Producto productoCarrito = tienda.Productos.Find(p => p.Nombre == nombreCarrito);
                        if (productoCarrito != null)
                        {
                            Console.WriteLine("Ingrese la cantidad:");
                            int cantidad = Convert.ToInt32(Console.ReadLine());
                            carrito.AgregarProducto(productoCarrito, cantidad);
                        }
                        else
                        {
                            Console.WriteLine("Producto no encontrado.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Ingrese el nombre del producto a eliminar del carrito:");
                        string nombreEliminarCarrito = Console.ReadLine();
                        Producto productoEliminarCarrito = tienda.Productos.Find(p => p.Nombre == nombreEliminarCarrito);
                        if (productoEliminarCarrito != null)
                        {
                            carrito.EliminarProducto(productoEliminarCarrito);
                        }
                        else
                        {
                            Console.WriteLine("Producto no encontrado.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Ingrese el dinero del cliente:");
                        double dineroCliente = Convert.ToDouble(Console.ReadLine());
                        tienda.CobrarCompra(carrito, dineroCliente);
                        break;
                    case "5":
                        esCliente = false; // cambiamos a modo dueño
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            else
            {
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Ingrese el nombre del producto:");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el costo del producto:");
                        double costo = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Ingrese el stock del producto:");
                        int stock = Convert.ToInt32(Console.ReadLine());

                        Producto nuevoProducto = new Producto(nombre, costo, stock);
                        tienda.AgregarProducto(nuevoProducto);
                        break;
                    case "2":
                        Console.WriteLine("Ingrese el nombre del producto a eliminar:");
                        string nombreEliminar = Console.ReadLine();
                        Producto productoEliminar = tienda.Productos.Find(p => p.Nombre == nombreEliminar);
                        if (productoEliminar != null)
                        {
                            tienda.EliminarProducto(productoEliminar);
                        }
                        else
                        {
                            Console.WriteLine("Producto no encontrado.");
                        }
                        break;
                    case "3":
                        tienda.MostrarProductos();
                        break;
                    case "4":
                        esCliente = true; // cambiamos a modo cliente
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}

