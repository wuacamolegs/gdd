namespace FrbaCommerce.Calificar_Vendedor
{
    partial class vendedoresSinCalificar
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
            this.dtgVendedoresSinCalificar = new System.Windows.Forms.DataGridView();
            this.lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVendedoresSinCalificar)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgVendedoresSinCalificar
            // 
            this.dtgVendedoresSinCalificar.BackgroundColor = System.Drawing.Color.Lavender;
            this.dtgVendedoresSinCalificar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgVendedoresSinCalificar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVendedoresSinCalificar.Location = new System.Drawing.Point(14, 49);
            this.dtgVendedoresSinCalificar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgVendedoresSinCalificar.Name = "dtgVendedoresSinCalificar";
            this.dtgVendedoresSinCalificar.Size = new System.Drawing.Size(840, 328);
            this.dtgVendedoresSinCalificar.TabIndex = 44;
            this.dtgVendedoresSinCalificar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgVendedoresSinCalificar_CellContentClick);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lbl.Location = new System.Drawing.Point(14, 10);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(261, 17);
            this.lbl.TabIndex = 45;
            this.lbl.Text = "Vendedores que no ha calificado aún";
            // 
            // vendedoresSinCalificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(868, 390);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dtgVendedoresSinCalificar);
            this.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "vendedoresSinCalificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calificar Vendedores";
            this.Load += new System.EventHandler(this.calificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgVendedoresSinCalificar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgVendedoresSinCalificar;
        private System.Windows.Forms.Label lbl;
    }
}