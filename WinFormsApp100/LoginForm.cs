using System;
using System.Drawing;
using System.IO;
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

            // Cargar usuario recordado
            if (File.Exists("recordar.txt"))
            {
                string usuario = File.ReadAllText("recordar.txt");
                txtUsuario.Text = usuario;
                chkRecordarme.Checked = true;
            }
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
                // Guardar usuario si está marcado "Recordarme"
                if (chkRecordarme.Checked)
                    File.WriteAllText("recordar.txt", usuario);
                else if (File.Exists("recordar.txt"))
                    File.Delete("recordar.txt");

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
            picVerClave.BackColor = claveVisible ? Color.LightGray : Color.Transparent;
        }
    }
}
