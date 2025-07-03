using WinFormsApp100;

public class Inventario : IInventario
{
    private List<Producto> productos;

    public Inventario()
    {
        productos = new List<Producto>();
    }

    public void AgregarProducto(Producto producto)
    {
        var existente = productos.FirstOrDefault(p => p.Nombre == producto.Nombre);
        if (existente != null)
        {
            // Si ya existe, sumamos la cantidad y reactivamos el producto
            existente.Cantidad += producto.Cantidad;
            existente.Estado = EstadoProducto.Activo;

            Logger.Log($"Producto actualizado (cantidad sumada): {existente.Nombre}, nueva cantidad: {existente.Cantidad}");
        }
        else
        {
            productos.Add(producto);
            Logger.Log($"Producto agregado: {producto.Nombre}, cantidad: {producto.Cantidad}");
        }
    }

    public void ActualizarProducto(string nombre, int cantidad)
    {
        var producto = productos.FirstOrDefault(p => p.Nombre == nombre);
        if (producto != null)
        {
            producto.ActualizarCantidad(cantidad);
            Logger.Log($"Producto actualizado (cantidad modificada): {producto.Nombre}, nueva cantidad: {producto.Cantidad}");
        }
    }

    // Eliminación lógica: cambiar estado a Inactivo
    public void EliminarProducto(string nombre)
    {
        var producto = productos.FirstOrDefault(p => p.Nombre == nombre);
        if (producto != null)
        {
            producto.Estado = EstadoProducto.Inactivo;
            Logger.Log($"Producto eliminado (estado Inactivo): {producto.Nombre}");
        }
    }

    // Obtener todos los productos (incluye inactivos)
    public List<Producto> ObtenerInventario()
    {
        return productos;
    }

    // Obtener productos filtrados por estado
    public List<Producto> ObtenerPorEstado(EstadoProducto estado)
    {
        return productos.Where(p => p.Estado == estado).ToList();
    }

    // Buscar productos por texto en el nombre (ignora mayúsculas)
    public List<Producto> BuscarProductos(string textoBusqueda)
    {
        return productos
            .Where(p => p.Nombre.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)
            .ToList();
    }

    /// <summary>
    /// Cargar una lista de productos (usado por persistencia)
    /// </summary>
    /// <param name="lista">Lista de productos deserializados</param>
    public void CargarInventario(List<Producto> lista)
    {
        productos = lista ?? new List<Producto>();
    }
}
