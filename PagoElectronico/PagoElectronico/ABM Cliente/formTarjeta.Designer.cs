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
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.txtEmisor = new System.Windows.Forms.TextBox();
            this.lblEmisor = new System.Windows.Forms.Label();
            this.lblEmision = new System.Windows.Forms.Label();
            this.dtEmision = new System.Windows.Forms.DateTimePicker();
            this.lblVencimiento = new System.Windows.Forms.Label();
            this.dtVencimiento = new System.Windows.Forms.DateTimePicker();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.chkActivar = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTarjeta.Location = new System.Drawing.Point(12, 79);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(155, 16);
            this.lblTarjeta.TabIndex = 0;
            this.lblTarjeta.Text = "NUMERO DE TARJETA";
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Location = new System.Drawing.Point(185, 75);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(206, 20);
            this.txtTarjeta.TabIndex = 1;
            this.txtTarjeta.TextChanged += new System.EventHandler(this.txtTarjeta_TextChanged);
            // 
            // txtEmisor
            // 
            this.txtEmisor.Location = new System.Drawing.Point(187, 123);
            this.txtEmisor.Name = "txtEmisor";
            this.txtEmisor.Size = new System.Drawing.Size(206, 20);
            this.txtEmisor.TabIndex = 2;
            // 
            // lblEmisor
            // 
            this.lblEmisor.AutoSize = true;
            this.lblEmisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEmisor.Location = new System.Drawing.Point(15, 127);
            this.lblEmisor.Name = "lblEmisor";
            this.lblEmisor.Size = new System.Drawing.Size(60, 16);
            this.lblEmisor.TabIndex = 3;
            this.lblEmisor.Text = "EMISOR";
            // 
            // lblEmision
            // 
            this.lblEmision.AutoSize = true;
            this.lblEmision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEmision.Location = new System.Drawing.Point(15, 183);
            this.lblEmision.Name = "lblEmision";
            this.lblEmision.Size = new System.Drawing.Size(133, 16);
            this.lblEmision.TabIndex = 4;
            this.lblEmision.Text = "FECHA DE EMISION";
            // 
            // dtEmision
            // 
            this.dtEmision.Location = new System.Drawing.Point(185, 179);
            this.dtEmision.Name = "dtEmision";
            this.dtEmision.Size = new System.Drawing.Size(206, 20);
            this.dtEmision.TabIndex = 5;
            // 
            // lblVencimiento
            // 
            this.lblVencimiento.AutoSize = true;
            this.lblVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.275F);
            this.lblVencimiento.Location = new System.Drawing.Point(12, 238);
            this.lblVencimiento.Name = "lblVencimiento";
            this.lblVencimiento.Size = new System.Drawing.Size(170, 16);
            this.lblVencimiento.TabIndex = 6;
            this.lblVencimiento.Text = "FECHA DE VENCIMIENTO";
            // 
            // dtVencimiento
            // 
            this.dtVencimiento.Location = new System.Drawing.Point(185, 234);
            this.dtVencimiento.Name = "dtVencimiento";
            this.dtVencimiento.Size = new System.Drawing.Size(206, 20);
            this.dtVencimiento.TabIndex = 7;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblCodigo.Location = new System.Drawing.Point(12, 288);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(165, 16);
            this.lblCodigo.TabIndex = 8;
            this.lblCodigo.Text = "CODIGO DE SEGURIDAD";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(187, 284);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(204, 20);
            this.txtCodigo.TabIndex = 9;
            // 
            // chkActivar
            // 
            this.chkActivar.AutoSize = true;
            this.chkActivar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkActivar.Location = new System.Drawing.Point(306, 25);
            this.chkActivar.Name = "chkActivar";
            this.chkActivar.Size = new System.Drawing.Size(85, 20);
            this.chkActivar.TabIndex = 10;
            this.chkActivar.Text = "ACTIVAR";
            this.chkActivar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnAceptar.Location = new System.Drawing.Point(281, 328);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(110, 33);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // formTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 419);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.chkActivar);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.dtVencimiento);
            this.Controls.Add(this.lblVencimiento);
            this.Controls.Add(this.dtEmision);
            this.Controls.Add(this.lblEmision);
            this.Controls.Add(this.lblEmisor);
            this.Controls.Add(this.txtEmisor);
            this.Controls.Add(this.txtTarjeta);
            this.Controls.Add(this.lblTarjeta);
            this.Name = "formTarjeta";
            this.Text = "formTarjeta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.TextBox txtEmisor;
        private System.Windows.Forms.Label lblEmisor;
        private System.Windows.Forms.Label lblEmision;
        private System.Windows.Forms.DateTimePicker dtEmision;
        private System.Windows.Forms.Label lblVencimiento;
        private System.Windows.Forms.DateTimePicker dtVencimiento;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.CheckBox chkActivar;
        private System.Windows.Forms.Button btnAceptar;
    }
}