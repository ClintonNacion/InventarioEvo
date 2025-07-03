using System;
using System.Windows.Forms;

namespace WinFormsApp100
{
    public partial class LoginForm : Form
    {
        private AutenticacionService authService;

        public LoginForm()
        {
            InitializeComponent();
            authService = new AutenticacionService();
            this.AcceptButton = btnLogin;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtPassword.Text;

            if (authService.ValidarCredenciales(usuario, clave))
            {
               // MessageBox.Show("¡Bienvenido!", "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Señala que el login fue exitoso
                this.Close();                        // Cierra solo el LoginForm
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

    }
}
