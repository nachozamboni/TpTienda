using System;

public class Tienda // definimos la clase Tienda
{
    public List<Producto> Productos { get; private set; } // lista de productos en la tienda
    public double DineroEnCaja { get; private set; } // dinero en caja 

    // constructor de la Tienda
    public Tienda()
    {
        Productos = new List<Producto>(); // inicializamos la lista de productos
        DineroEnCaja = 0; // inicializamos el dinero en caja
    }

    // metodo para agregar un producto a la tienda (solo para el dueño)
    public void AgregarProducto(Producto producto)
    {
        Productos.Add(producto);
    }

    // metodo para eliminar un producto 
    public void EliminarProducto(Producto producto)
    {
        Productos.Remove(producto); 
    }

    // metodo para mostrar los productos
    public void MostrarProductos()
    {
        Console.WriteLine("Lista de Productos:"); 

        //bucle sobre la lista de productos para mostrar nombre y stock de c/u
        foreach (Producto producto in Productos)
        {
            Console.WriteLine($"Nombre: {producto.Nombre}\nStock: {producto.Stock}\n");
        }
    }

    // metodo para cobrar
    public void CobrarCompra(Carrito carrito, double dineroCliente)
    {
        double total = carrito.CalcularTotal(); // calcular el total de la compra (carrito del cliente) 
        if (dineroCliente >= total) // chequear si el cliente tiene suficiente dinero 
        {
            double vuelto = dineroCliente - total; 
            DineroEnCaja += total; 
            Console.WriteLine($"Compra realizada :), el vuelto es: {vuelto}"); 
        }
        else
        {
            Console.WriteLine("Dinero insuficiente para la compra :("); 
        }
    }
}
