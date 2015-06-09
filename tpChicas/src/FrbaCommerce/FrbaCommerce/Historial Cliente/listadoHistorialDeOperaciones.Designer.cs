namespace FrbaCommerce.Historial_Cliente
{
    partial class listadoHistorialDeOperaciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtgHistorial = new System.Windows.Forms.DataGridView();
            this.cmbHistorial = new System.Windows.Forms.ComboBox();
            this.btnVer = new System.Windows.Forms.Button();
            this.lblSeleccionar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgHistorial
            // 
            this.dtgHistorial.BackgroundColor = System.Drawing.Color.Lavender;
            this.dtgHistorial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHistorial.Location = new System.Drawing.Point(41, 105);
            this.dtgHistorial.Name = "dtgHistorial";
            this.dtgHistorial.Size = new System.Drawing.Size(644, 280);
            this.dtgHistorial.TabIndex = 0;
            // 
            // cmbHistorial
            // 
            this.cmbHistorial.FormattingEnabled = true;
            this.cmbHistorial.Items.AddRange(new object[] {
            "Compras",
            "Ofertas",
            "Calificaciones Recibidas",
            "Calificaciones Otorgadas"});
            this.cmbHistorial.Location = new System.Drawing.Point(41, 57);
            this.cmbHistorial.Name = "cmbHistorial";
            this.cmbHistorial.Size = new System.Drawing.Size(173, 23);
            this.cmbHistorial.TabIndex = 2;
            // 
            // btnVer
            // 
            this.btnVer.BackColor = System.Drawing.Color.PowderBlue;
            this.btnVer.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVer.Location = new System.Drawing.Point(245, 57);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(57, 27);
            this.btnVer.TabIndex = 3;
            this.btnVer.Text = "Ver";
            this.btnVer.UseVisualStyleBackColor = false;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // lblSeleccionar
            // 
            this.lblSeleccionar.AutoSize = true;
            this.lblSeleccionar.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionar.Location = new System.Drawing.Point(37, 20);
            this.lblSeleccionar.Name = "lblSeleccionar";
            this.lblSeleccionar.Size = new System.Drawing.Size(183, 19);
            this.lblSeleccionar.TabIndex = 4;
            this.lblSeleccionar.Text = "Seleccione la operación";
            // 
            // listadoHistorialDeOperaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(722, 412);
            this.Controls.Add(this.lblSeleccionar);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.cmbHistorial);
            this.Controls.Add(this.dtgHistorial);
            this.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "listadoHistorialDeOperaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de Usuario";
            this.Load += new System.EventHandler(this.listadoHistorialDeOperaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgHistorial;
        private System.Windows.Forms.ComboBox cmbHistorial;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Label lblSeleccionar;
    }
}