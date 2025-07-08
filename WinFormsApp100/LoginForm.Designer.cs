using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp100
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Label lblUsuario;
        private Label lblPassword;
        private Button btnLogin;
        private GroupBox groupBoxLogin;
        private Label lblTitulo;
        private PictureBox picVerClave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            lblUsuario = new Label();
            lblPassword = new Label();
            btnLogin = new Button();
            groupBoxLogin = new GroupBox();
            lblTitulo = new Label();
            picVerClave = new PictureBox();
            groupBoxLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(picVerClave)).BeginInit();
            SuspendLayout();

            // txtUsuario
            txtUsuario.Location = new Point(149, 29);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(239, 27);
            txtUsuario.TabIndex = 1;

            // txtPassword
            txtPassword.Location = new Point(149, 69);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(239, 27);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;

            // picVerClave (botón mostrar/ocultar clave)
            picVerClave.Location = new Point(394, 69);
            picVerClave.Name = "picVerClave";
            picVerClave.Size = new Size(24, 24);
            picVerClave.SizeMode = PictureBoxSizeMode.StretchImage;
            picVerClave.Cursor = Cursors.Hand;
            picVerClave.BorderStyle = BorderStyle.FixedSingle;
            picVerClave.Click += picVerClave_Click;

            // lblUsuario
            lblUsuario.Location = new Point(11, 33);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(92, 20);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";

            // lblPassword
            lblPassword.Location = new Point(11, 73);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(92, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Contraseña:";

            // btnLogin
            btnLogin.Location = new Point(149, 115);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(103, 33);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Iniciar sesión";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;

            // groupBoxLogin
            groupBoxLogin.Controls.Add(lblUsuario);
            groupBoxLogin.Controls.Add(txtUsuario);
            groupBoxLogin.Controls.Add(lblPassword);
            groupBoxLogin.Controls.Add(txtPassword);
            groupBoxLogin.Controls.Add(picVerClave); // 👈 ojo aquí
            groupBoxLogin.Controls.Add(btnLogin);
            groupBoxLogin.Location = new Point(14, 45);
            groupBoxLogin.Name = "groupBoxLogin";
            groupBoxLogin.Size = new Size(429, 170);
            groupBoxLogin.TabIndex = 0;
            groupBoxLogin.TabStop = false;

            // lblTitulo
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 5);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(380, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Iniciar Sesión";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // LoginForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 230);
            Controls.Add(lblTitulo);
            Controls.Add(groupBoxLogin);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - Inventario";
            Load += LoginForm_Load;
            groupBoxLogin.ResumeLayout(false);
            groupBoxLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(picVerClave)).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
