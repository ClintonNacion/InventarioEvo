using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace WinFormsApp100
{
    public class PersistenciaInventario
    {
        private readonly string rutaArchivo = "inventario.json";

        public void GuardarInventario(List<Producto> productos)
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(productos, opciones);
            File.WriteAllText(rutaArchivo, json);
        }

        public List<Producto> CargarInventario()
        {
            if (!File.Exists(rutaArchivo)) return new List<Producto>();

            string json = File.ReadAllText(rutaArchivo);
            return JsonSerializer.Deserialize<List<Producto>>(json) ?? new List<Producto>();
        }
    }
}
