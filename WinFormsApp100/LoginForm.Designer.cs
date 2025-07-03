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
        // Declaración:
        private Label lblTitulo;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            lblUsuario = new Label();
            lblPassword = new Label();
            btnLogin = new Button();
            groupBoxLogin = new GroupBox();
            groupBoxLogin.SuspendLayout();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(149, 29);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(239, 27);
            txtUsuario.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(149, 69);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(239, 27);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblUsuario
            // 
            lblUsuario.Location = new Point(11, 33);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(114, 20);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(11, 73);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(114, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Contraseña:";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(149, 115);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(103, 33);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Iniciar sesión";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // Dentro de InitializeComponent (antes de groupBoxLogin):
            lblTitulo = new Label();
            lblTitulo.Text = "Iniciar Sesión";
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.AutoSize = false;
            lblTitulo.Size = new Size(380, 30); // Igual al ancho del formulario o groupbox
            lblTitulo.Location = new Point(30, 0); // Ajusta según el formulario
            Controls.Add(lblTitulo);

            // 
            // groupBoxLogin
            // 
            groupBoxLogin.Controls.Add(lblUsuario);
            groupBoxLogin.Controls.Add(txtUsuario);
            groupBoxLogin.Controls.Add(lblPassword);
            groupBoxLogin.Controls.Add(txtPassword);
            groupBoxLogin.Controls.Add(btnLogin);
            groupBoxLogin.Location = new Point(14, 20);
            groupBoxLogin.Name = "groupBoxLogin";
            groupBoxLogin.Size = new Size(411, 170);
            groupBoxLogin.TabIndex = 0;
            groupBoxLogin.TabStop = false;
           // groupBoxLogin.Text = "Iniciar Sesión";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 215);
            Controls.Add(groupBoxLogin);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - Inventario";
            groupBoxLogin.ResumeLayout(false);
            groupBoxLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
