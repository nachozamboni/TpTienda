using System;
using System.Collections.Generic; 

public class Carrito // definimos la clase Carrito
{
    private List<(Producto producto, int cantidad)> productosEnCarrito; // lista para guardar los productos en el carrito y la cantidad

    // constructor de la clase Carrito
    public Carrito()
    {
        productosEnCarrito = new List<(Producto producto, int cantidad)>(); // inicializamos la lista de productos en el carrito como lista vacía
    }

    // metodo para agregar un producto al carrito con la cantidad especificada
    public void AgregarProducto(Producto producto, int cantidad)
    {
        if (producto.Stock >= cantidad) // chequeamos si hay suficiente stock
        {
            productosEnCarrito.Add((producto, cantidad)); // agregamos al carrito junto con su cantidad
            producto.Stock -= cantidad; // restamos la cantidad del stock 
        }
        else
        {
            Console.WriteLine("Stock insuficiente :("); 
        }
    }

    // metodo para eliminar un producto del carrito
    public void EliminarProducto(Producto producto)
    {
        var item = productosEnCarrito.Find(p => p.producto == producto); // buscamos el producto en el carrito
        if (item.producto != null && item.cantidad != 0) // vemos si el producto se encontro y si hay cantidad para eliminar
        {
            productosEnCarrito.Remove(item); 
            producto.Stock += item.cantidad; 
        }
    }

    // metodo para calcular el total a pagar
    public double CalcularTotal()
    {
        double total = 0; // inicializamos el total como 0
        foreach (var item in productosEnCarrito) // iteramos sobre los elementos del carrito
        {
            total += item.producto.PrecioVenta * item.cantidad; 
        }
        return total; 
    }
}

