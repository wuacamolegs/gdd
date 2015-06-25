namespace PagoElectronico.ABM_Rol
{
    partial class ABM_de_Rol
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
            this.dtgListado = new System.Windows.Forms.DataGridView();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.NotaSelecRol = new System.Windows.Forms.Label();
            this.btnDeshab = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListado)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListado
            // 
            this.dtgListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListado.Location = new System.Drawing.Point(17, 99);
            this.dtgListado.Name = "dtgListado";
            this.dtgListado.Size = new System.Drawing.Size(408, 165);
            this.dtgListado.TabIndex = 2;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(350, 270);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(256, 270);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(17, 66);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(88, 23);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Nuevo Rol";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // NotaSelecRol
            // 
            this.NotaSelecRol.AutoSize = true;
            this.NotaSelecRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.NotaSelecRol.Location = new System.Drawing.Point(15, 12);
            this.NotaSelecRol.Name = "NotaSelecRol";
            this.NotaSelecRol.Size = new System.Drawing.Size(179, 26);
            this.NotaSelecRol.TabIndex = 7;
            this.NotaSelecRol.Text = "Seleccione un rol";
            // 
            // btnDeshab
            // 
            this.btnDeshab.Location = new System.Drawing.Point(153, 271);
            this.btnDeshab.Name = "btnDeshab";
            this.btnDeshab.Size = new System.Drawing.Size(83, 20);
            this.btnDeshab.TabIndex = 8;
            this.btnDeshab.Text = "Deshabilitar";
            this.btnDeshab.UseVisualStyleBackColor = true;
            // 
            // ABM_de_Rol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 400);
            this.Controls.Add(this.btnDeshab);
            this.Controls.Add(this.NotaSelecRol);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dtgListado);
            this.Name = "ABM_de_Rol";
            this.Text = "PAGO ELECTRONICO - ABM ROL";
            ((System.ComponentModel.ISupportInitialize)(this.dtgListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListado;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label NotaSelecRol;
        private System.Windows.Forms.Button btnDeshab;
    }
}