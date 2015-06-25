namespace PagoElectronico.Depositos
{
    partial class frmDepositos
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
            this.lblCliente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCuenta = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTarjeta = new System.Windows.Forms.ComboBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblCliente.Location = new System.Drawing.Point(35, 42);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(64, 16);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "CLIENTE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(35, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "IMPORTE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(17, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "TIPO DE MONEDA";
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Location = new System.Drawing.Point(146, 188);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(255, 21);
            this.cmbMoneda.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.Location = new System.Drawing.Point(35, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "TARJETA";
            // 
            // cmbCuenta
            // 
            this.cmbCuenta.FormattingEnabled = true;
            this.cmbCuenta.Location = new System.Drawing.Point(146, 90);
            this.cmbCuenta.Name = "cmbCuenta";
            this.cmbCuenta.Size = new System.Drawing.Size(254, 21);
            this.cmbCuenta.TabIndex = 7;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnAceptar.Location = new System.Drawing.Point(291, 314);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(110, 38);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(146, 39);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(256, 21);
            this.cmbCliente.TabIndex = 1;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.ComboCliente_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label5.Location = new System.Drawing.Point(35, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "CUENTA";
            // 
            // cmbTarjeta
            // 
            this.cmbTarjeta.FormattingEnabled = true;
            this.cmbTarjeta.Location = new System.Drawing.Point(146, 139);
            this.cmbTarjeta.Name = "cmbTarjeta";
            this.cmbTarjeta.Size = new System.Drawing.Size(255, 21);
            this.cmbTarjeta.TabIndex = 10;
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(146, 240);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(254, 20);
            this.txtImporte.TabIndex = 11;
            // 
            // Depositos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 385);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.cmbTarjeta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cmbCuenta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMoneda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.lblCliente);
            this.Name = "Depositos";
            this.Text = "Depositos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCuenta;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTarjeta;
        private System.Windows.Forms.TextBox txtImporte;
    }
}