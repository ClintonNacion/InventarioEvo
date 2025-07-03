using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp100
{
    partial class FormLogs
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtLogs;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtLogs = new TextBox();
            textBoxLogs = new Label();
            SuspendLayout();
            // 
            // txtLogs
            // 
            txtLogs.Dock = DockStyle.Fill;
            txtLogs.Font = new Font("Consolas", 10F);
            txtLogs.Location = new Point(0, 0);
            txtLogs.Multiline = true;
            txtLogs.Name = "txtLogs";
            txtLogs.ReadOnly = true;
            txtLogs.ScrollBars = ScrollBars.Vertical;
            txtLogs.Size = new Size(600, 400);
            txtLogs.TabIndex = 0;
            // 
            // textBoxLogs
            // 
            textBoxLogs.Location = new Point(210, 120);
            textBoxLogs.Name = "textBoxLogs";
            textBoxLogs.Size = new Size(114, 20);
            textBoxLogs.TabIndex = 1;
            textBoxLogs.Text = "Nombre";
            textBoxLogs.Click += lblNombre_Click;
            // 
            // FormLogs
            // 
            ClientSize = new Size(600, 400);
            Controls.Add(textBoxLogs);
            Controls.Add(txtLogs);
            Name = "FormLogs";
            Text = "Registro de Logs";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label textBoxLogs;
    }
}
