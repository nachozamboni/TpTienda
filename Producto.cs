using System;

public class Producto // definimos la clase Producto
{
    public string Nombre { get; private set; } 
    public double Costo { get; private set; } 
    public double PrecioVenta { get; private set; } 
    public int Stock { get; set; } 

    // constructor de la clase Producto
    public Producto(string nombre, double costo, int stock)
    {
        if (string.IsNullOrEmpty(nombre) || costo <= 0) // chequeamos si el nombre es nulo o vacío, o si el costo es menor o igual a 0
        {
            throw new ArgumentException("No se puede crear un producto sin nombre o costo"); // mostramos error si no se cumple algunos de los dos casos anteriores
        }
        //asignamos nombre, costo, precio y stock
        Nombre = nombre; 
        Costo = costo; 
        PrecioVenta = costo * 1.3; 
        Stock = stock; 
    }
}
