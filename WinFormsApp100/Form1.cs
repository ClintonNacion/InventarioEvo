using System;
using System.Windows.Forms;

namespace WinFormsApp100
{
    public partial class Form1 : Form
    {
        private IInventario inventario;
        private ReporteInventario reporteInventario;
        private PersistenciaInventario persistencia;

        public Form1()
        {
            InitializeComponent();
            inventario = new Inventario();
            reporteInventario = new ReporteInventario();
            persistencia = new PersistenciaInventario();

            // Cargar productos al  iniciar
            var productosCargados = persistencia.CargarInventario();
            inventario.CargarInventario(productosCargados);
            ActualizarLista();

            // Botón para ver logs
            Button btnVerLogs2 = new Button();
            btnVerLogs2.Text = "Ver Logs";
            btnVerLogs2.Size = new Size(100, 30);
            btnVerLogs2.Location = new Point(10, 50);
            btnVerLogs2.Click += btnVerLogs_Click;
            this.Controls.Add(btnVerLogs2);
        }

        private void Logger_OnLogAdded(string logEntry)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() => AgregarLog(logEntry)));
            }
            else
            {
                AgregarLog(logEntry);
            }
        }

        private void AgregarLog(string mensaje)
        {
            //txtLog.AppendText(mensaje + Environment.NewLine);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var listaCargada = persistencia.CargarInventario();
            inventario.CargarInventario(listaCargada);
            ActualizarLista();
            this.FormClosing += Form1_FormClosing;

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            persistencia.GuardarInventario(inventario.ObtenerInventario());
        }

        private void btnVerLogs_Click(object sender, EventArgs e)
        {
            var formLogs = new FormLogs();

            string logs = System.IO.File.Exists("log.txt") ? System.IO.File.ReadAllText("log.txt") : "No hay logs disponibles.";

            formLogs.CargarLogs(logs);

            formLogs.ShowDialog(); // Mostrar ventana modal  // Muestra la ventana sin bloquear Form1
        }



        /* private void btnAgregar_Click(object sender, EventArgs e)
         {
             string nombre = txtNombre.Text;
             if (!int.TryParse(txtCantidad.Text, out int cantidad))
             {
                 MessageBox.Show("Cantidad inválida");
                 return;
             }

             Producto producto = new Producto(nombre, cantidad);
             inventario.AgregarProducto(producto);

             Logger.Log($"Producto agregado: {nombre}, Cantidad: {cantidad}");

             MessageBox.Show("Producto agregado al inventario.");
             ActualizarLista();

             txtNombre.Clear();
             txtCantidad.Clear();
             txtNombre.Focus();
         }

         private void btnActualizar_Click(object sender, EventArgs e)
         {
             int selectedIndex = lstInventario.SelectedIndex;

             if (selectedIndex == -1)
             {
                 MessageBox.Show("Selecciona un producto para actualizar.");
                 return;
             }

             string nuevoNombre = txtNombre.Text;
             if (!int.TryParse(txtCantidad.Text, out int nuevaCantidad))
             {
                 MessageBox.Show("Cantidad inválida");
                 return;
             }

             var producto = inventario.ObtenerInventario()[selectedIndex];
             producto.Nombre = nuevoNombre;
             producto.Cantidad = nuevaCantidad;

             Logger.Log($"Producto actualizado: {nuevoNombre}, Cantidad: {nuevaCantidad}");

             ActualizarLista();

             MessageBox.Show("Producto actualizado.");

             txtNombre.Clear();
             txtCantidad.Clear();
             lstInventario.ClearSelected();
         }*/


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();

            // Validaciones
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre del producto no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (nombre.Length > 50)
            {
                MessageBox.Show("El nombre del producto es demasiado largo (máx. 50 caracteres).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (!int.TryParse(txtCantidad.Text.Trim(), out int cantidad) || cantidad < 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return;
            }

            Producto producto = new Producto(nombre, cantidad);
            inventario.AgregarProducto(producto);
            Logger.Log($"Producto agregado: {nombre}, Cantidad: {cantidad}");

            MessageBox.Show("Producto agregado al inventario.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ActualizarLista();
            persistencia.GuardarInventario(inventario.ObtenerInventario());


            txtNombre.Clear();
            txtCantidad.Clear();
            txtNombre.Focus();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstInventario.SelectedIndex;

            if (selectedIndex == -1)
            {
                MessageBox.Show("Selecciona un producto de la lista para actualizar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nuevoNombre = txtNombre.Text.Trim();

            // Validaciones
            if (string.IsNullOrWhiteSpace(nuevoNombre))
            {
                MessageBox.Show("El nombre del producto no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (nuevoNombre.Length > 50)
            {
                MessageBox.Show("El nombre del producto es demasiado largo (máx. 50 caracteres).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (!int.TryParse(txtCantidad.Text.Trim(), out int nuevaCantidad) || nuevaCantidad < 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return;
            }

            var producto = inventario.ObtenerInventario()[selectedIndex];
            producto.Nombre = nuevoNombre;
            producto.Cantidad = nuevaCantidad;

            Logger.Log($"Producto actualizado: {nuevoNombre}, Cantidad: {nuevaCantidad}");

            ActualizarLista();
            persistencia.GuardarInventario(inventario.ObtenerInventario());


            MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNombre.Clear();
            txtCantidad.Clear();
            lstInventario.ClearSelected();
        }


        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            var reporte = reporteInventario.GenerarReporte(inventario.ObtenerInventario());
            MessageBox.Show(reporte);
        }

        private void ActualizarLista()
        {
            lstInventario.Items.Clear();
            foreach (var producto in inventario.ObtenerInventario())
            {
                lstInventario.Items.Add($"{producto.Nombre} - {producto.Cantidad}");
            }
        }
       
        private void groupBoxFormulario_Enter(object sender, EventArgs e)
        {
            // Aquí puedes poner código para ejecutar cuando el groupBox recibe foco,
            // o dejarlo vacío si no necesitas hacer nada.
        }

        private void lstInventario_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar que algo esté seleccionado
            if (lstInventario.SelectedIndex != -1)
            {
                // Obtener el producto seleccionado
                var productoSeleccionado = inventario.ObtenerInventario()[lstInventario.SelectedIndex];

                // Cargar datos en los TextBox para editar
                txtNombre.Text = productoSeleccionado.Nombre;
                txtCantidad.Text = productoSeleccionado.Cantidad.ToString();
            }
        }

    }
}
