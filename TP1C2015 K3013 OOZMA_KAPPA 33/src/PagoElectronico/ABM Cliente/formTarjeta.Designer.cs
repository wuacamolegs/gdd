namespace PagoElectronico.ABM_Cliente
{
    partial class formTarjeta
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
            this.lblEmisor = new System.Windows.Forms.Label();
            this.chkActivar = new System.Windows.Forms.CheckBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.cmbEmisor = new System.Windows.Forms.ComboBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEmisor
            // 
            this.lblEmisor.AutoSize = true;
            this.lblEmisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEmisor.Location = new System.Drawing.Point(11, 67);
            this.lblEmisor.Name = "lblEmisor";
            this.lblEmisor.Size = new System.Drawing.Size(60, 16);
            this.lblEmisor.TabIndex = 3;
            this.lblEmisor.Text = "EMISOR";
            // 
            // chkActivar
            // 
            this.chkActivar.AutoSize = true;
            this.chkActivar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkActivar.Location = new System.Drawing.Point(220, 24);
            this.chkActivar.Name = "chkActivar";
            this.chkActivar.Size = new System.Drawing.Size(85, 20);
            this.chkActivar.TabIndex = 10;
            this.chkActivar.Text = "ACTIVAR";
            this.chkActivar.UseVisualStyleBackColor = true;
            // 
            // btnCrear
            // 
            this.btnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnCrear.Location = new System.Drawing.Point(192, 101);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(110, 33);
            this.btnCrear.TabIndex = 11;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // cmbEmisor
            // 
            this.cmbEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmisor.FormattingEnabled = true;
            this.cmbEmisor.Location = new System.Drawing.Point(97, 62);
            this.cmbEmisor.Name = "cmbEmisor";
            this.cmbEmisor.Size = new System.Drawing.Size(206, 21);
            this.cmbEmisor.TabIndex = 12;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(192, 101);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(110, 33);
            this.btnModificar.TabIndex = 13;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // formTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 148);
            this.Controls.Add(this.cmbEmisor);
            this.Controls.Add(this.chkActivar);
            this.Controls.Add(this.lblEmisor);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnCrear);
            this.Name = "formTarjeta";
            this.Text = "Pago Electrónico - Tarjetas";
            this.Load += new System.EventHandler(this.formTarjeta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmisor;
        private System.Windows.Forms.CheckBox chkActivar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.ComboBox cmbEmisor;
        private System.Windows.Forms.Button btnModificar;
    }
}