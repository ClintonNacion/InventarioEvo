using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp100
{
    public interface IInventario
    {
        void AgregarProducto(Producto producto);
        void ActualizarProducto(string nombre, int cantidad);
        List<Producto> ObtenerInventario();
        void CargarInventario(List<Producto> productos);
    }

}
