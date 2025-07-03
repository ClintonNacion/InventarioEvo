using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp100
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnVerLogs;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            lstInventario = new ListBox();
            txtNombre = new TextBox();
            txtCantidad = new TextBox();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnGenerarReporte = new Button();
            lblNombre = new Label();
            lblCantidad = new Label();
            groupBoxFormulario = new GroupBox();
            groupBoxFormulario.SuspendLayout();
            SuspendLayout();
            // 
            // lstInventario
            // 
            lstInventario.FormattingEnabled = true;
            lstInventario.Location = new Point(14, 16);
            lstInventario.Margin = new Padding(3, 4, 3, 4);
            lstInventario.Name = "lstInventario";
            lstInventario.Size = new Size(411, 204);
            lstInventario.TabIndex = 0;
            lstInventario.SelectedIndexChanged += lstInventario_SelectedIndexChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(149, 29);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(239, 27);
            txtNombre.TabIndex = 1;
            // 
            // txtLog
            // 
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtLog.Location = new System.Drawing.Point(14, 420);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(411, 100);
            this.txtLog.TabIndex = 7;
            this.Controls.Add(this.txtLog);

            // 
            // 
            // btnVerLogs
            // 
            this.btnVerLogs = new System.Windows.Forms.Button();
            this.btnVerLogs.Location = new System.Drawing.Point(320, 420); // Puedes ajustar la posición
            this.btnVerLogs.Size = new System.Drawing.Size(103, 33);
            this.btnVerLogs.Text = "Ver Logs";
            this.btnVerLogs.UseVisualStyleBackColor = true;
            this.btnVerLogs.Click += new System.EventHandler(this.btnVerLogs_Click);
            this.Controls.Add(this.btnVerLogs);


            // txtCantidad
            // 
            txtCantidad.Location = new Point(149, 69);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(239, 27);
            txtCantidad.TabIndex = 2;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(11, 120);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(103, 33);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(143, 120);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(103, 33);
            btnActualizar.TabIndex = 4;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.Location = new Point(286, 120);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(103, 33);
            btnGenerarReporte.TabIndex = 5;
            btnGenerarReporte.Text = "Reporte";
            btnGenerarReporte.UseVisualStyleBackColor = true;
            btnGenerarReporte.Click += btnGenerarReporte_Click;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(11, 33);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(114, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblCantidad
            // 
            lblCantidad.Location = new Point(11, 73);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(114, 20);
            lblCantidad.TabIndex = 1;
            lblCantidad.Text = "Cantidad: ";
            // 
            // groupBoxFormulario
            // 
            groupBoxFormulario.Controls.Add(lblNombre);
            groupBoxFormulario.Controls.Add(txtNombre);
            groupBoxFormulario.Controls.Add(lblCantidad);
            groupBoxFormulario.Controls.Add(txtCantidad);
            groupBoxFormulario.Controls.Add(btnAgregar);
            groupBoxFormulario.Controls.Add(btnActualizar);
            groupBoxFormulario.Controls.Add(btnGenerarReporte);
            groupBoxFormulario.Location = new Point(14, 240);
            groupBoxFormulario.Name = "groupBoxFormulario";
            groupBoxFormulario.Size = new Size(411, 173);
            groupBoxFormulario.TabIndex = 6;
            groupBoxFormulario.TabStop = false;
            groupBoxFormulario.Text = "Gestión de Producto";
            groupBoxFormulario.Enter += groupBoxFormulario_Enter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 433);
            Controls.Add(groupBoxFormulario);
            Controls.Add(lstInventario);
            Name = "Form1";
            Text = "Gestión de Inventario";
            Load += Form1_Load;
            groupBoxFormulario.ResumeLayout(false);
            groupBoxFormulario.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox lstInventario;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.GroupBox groupBoxFormulario;
    }
}
