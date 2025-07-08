using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp100
{
    public partial class LoginForm : Form
    {
        private AutenticacionService authService;
        private bool claveVisible = false;

        public LoginForm()
        {
            InitializeComponent();
            authService = new AutenticacionService();
            this.AcceptButton = btnLogin;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
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
                MessageBox.Show("¡Bienvenido!", "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void picVerClave_Click(object sender, EventArgs e)
        {
            claveVisible = !claveVisible;
            txtPassword.UseSystemPasswordChar = !claveVisible;

            // (Opcional: puedes agregar imágenes en el futuro)
            picVerClave.BackColor = claveVisible ? Color.LightGray : Color.Transparent;
        }
    }
}
