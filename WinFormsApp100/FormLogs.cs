using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp100
{
    public partial class FormLogs : Form
    {
        public FormLogs()
        {
            InitializeComponent();
        }

        public void CargarLogs(string logs)
        {
            txtLogs.Text = logs;  // textBoxLogs es el TextBox que pusiste para mostrar los log
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}
