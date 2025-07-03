public enum EstadoProducto
{
    Activo,
    Inactivo,
    EnReparacion
}

public class Producto
{
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public EstadoProducto Estado { get; set; }
    public DateTime FechaCreacion { get; set; }

    public Producto(string nombre, int cantidad)
    {
        Nombre = nombre;
        Cantidad = cantidad;
        Estado = EstadoProducto.Activo;
        FechaCreacion = DateTime.Now;
    }

    public void ActualizarCantidad(int cantidad)
    {
        Cantidad = cantidad;
    }
}
