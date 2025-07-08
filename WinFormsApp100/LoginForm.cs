
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

            if (authService.EstaBloqueado(usuario))
            {
                MessageBox.Show("El usuario ha sido bloqueado por 1 minuto tras 3 intentos fallidos.",
                                "Usuario bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            if (authService.ValidarCredenciales(usuario, clave))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
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
