using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class ReporteInventario
{
    public string GenerarReporte(List<Producto> inventario)
    {
        StringBuilder reporte = new StringBuilder();

        reporte.AppendLine("REPORTE DE INVENTARIO".PadLeft(45));
        reporte.AppendLine("=".PadLeft(70, '='));

        // Encabezado con formato alineado
        reporte.AppendLine(string.Format("{0,-30} {1,-10} {2,-15} {3,-15}",
            "Producto", "Cantidad", "Estado", "Fecha Creación"));
        reporte.AppendLine(new string('-', 70));

        // Contenido
        foreach (var producto in inventario)
        {
            reporte.AppendLine(string.Format("{0,-30} {1,-10} {2,-15} {3,-15}",
                Truncar(producto.Nombre, 30),
                producto.Cantidad,
                Truncar(producto.Estado.ToString(), 15),
                producto.FechaCreacion.ToString("yyyy-MM-dd")));
        }

        return reporte.ToString();
    }

    public void GuardarReporte(List<Producto> inventario, string rutaArchivo)
    {
        var reporte = GenerarReporte(inventario);
        File.WriteAllText(rutaArchivo, reporte, Encoding.UTF8); // UTF-8 para tildes
    }

    // Opcional: Truncar texto para que no desborde
    private string Truncar(string texto, int maxLong)
    {
        if (texto.Length > maxLong)
            return texto.Substring(0, maxLong - 3) + "...";
        return texto;
    }
}


