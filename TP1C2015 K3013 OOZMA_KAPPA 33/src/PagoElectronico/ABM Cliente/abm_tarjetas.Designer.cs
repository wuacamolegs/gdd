namespace PagoElectronico.ABM_Cliente
{
    partial class abm_tarjetas
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
            this.lblSeleccione = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dtgTarjetas = new System.Windows.Forms.DataGridView();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTarjetas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSeleccione
            // 
            this.lblSeleccione.AutoSize = true;
            this.lblSeleccione.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblSeleccione.Location = new System.Drawing.Point(24, 41);
            this.lblSeleccione.Name = "lblSeleccione";
            this.lblSeleccione.Size = new System.Drawing.Size(153, 18);
            this.lblSeleccione.TabIndex = 0;
            this.lblSeleccione.Text = "Seleccione una tarjeta";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnAgregar.Location = new System.Drawing.Point(333, 28);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(115, 31);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Nueva tarjeta";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // dtgTarjetas
            // 
            this.dtgTarjetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTarjetas.Location = new System.Drawing.Point(12, 81);
            this.dtgTarjetas.Name = "dtgTarjetas";
            this.dtgTarjetas.Size = new System.Drawing.Size(436, 192);
            this.dtgTarjetas.TabIndex = 2;
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnModificar.Location = new System.Drawing.Point(199, 294);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(113, 30);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnDesactivar.Location = new System.Drawing.Point(334, 294);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(114, 30);
            this.btnDesactivar.TabIndex = 4;
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.UseVisualStyleBackColor = true;
            // 
            // abm_tarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 354);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dtgTarjetas);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblSeleccione);
            this.Name = "abm_tarjetas";
            this.Text = "abm_tarjetas";
            ((System.ComponentModel.ISupportInitialize)(this.dtgTarjetas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSeleccione;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dtgTarjetas;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnDesactivar;
    }
}