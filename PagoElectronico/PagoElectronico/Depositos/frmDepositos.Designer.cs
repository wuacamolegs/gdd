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
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.cmbCuenta = new System.Windows.Forms.ComboBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.cmbTarjeta = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(13, 52);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(64, 16);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "CLIENTE";
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(184, 44);
            this.cmbCliente.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(234, 24);
            this.cmbCliente.TabIndex = 5;
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuenta.Location = new System.Drawing.Point(13, 110);
            this.lblCuenta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(64, 16);
            this.lblCuenta.TabIndex = 6;
            this.lblCuenta.Text = "CUENTA";
            // 
            // cmbCuenta
            // 
            this.cmbCuenta.FormattingEnabled = true;
            this.cmbCuenta.Location = new System.Drawing.Point(184, 102);
            this.cmbCuenta.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCuenta.Name = "cmbCuenta";
            this.cmbCuenta.Size = new System.Drawing.Size(234, 24);
            this.cmbCuenta.TabIndex = 7;
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporte.Location = new System.Drawing.Point(13, 230);
            this.lblImporte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(69, 16);
            this.lblImporte.TabIndex = 8;
            this.lblImporte.Text = "IMPORTE";
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(13, 169);
            this.lblMoneda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(67, 16);
            this.lblMoneda.TabIndex = 9;
            this.lblMoneda.Text = "MONEDA";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(184, 224);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(234, 22);
            this.txtImporte.TabIndex = 10;
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Location = new System.Drawing.Point(184, 161);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(234, 24);
            this.cmbMoneda.TabIndex = 11;
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Location = new System.Drawing.Point(13, 286);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(155, 16);
            this.lblTarjeta.TabIndex = 12;
            this.lblTarjeta.Text = "TARJETA DE CRÉDITO";
            // 
            // cmbTarjeta
            // 
            this.cmbTarjeta.FormattingEnabled = true;
            this.cmbTarjeta.Location = new System.Drawing.Point(184, 278);
            this.cmbTarjeta.Name = "cmbTarjeta";
            this.cmbTarjeta.Size = new System.Drawing.Size(234, 24);
            this.cmbTarjeta.TabIndex = 13;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(415, 337);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(113, 54);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // frmDepositos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 418);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cmbTarjeta);
            this.Controls.Add(this.lblTarjeta);
            this.Controls.Add(this.cmbMoneda);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.lblMoneda);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.cmbCuenta);
            this.Controls.Add(this.lblCuenta);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.lblCliente);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDepositos";
            this.Text = "PAGO ELECTRONICO - DEPOSITOS";
            this.Load += new System.EventHandler(this.frmDepositos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.ComboBox cmbCuenta;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.ComboBox cmbTarjeta;
        private System.Windows.Forms.Button btnAceptar;
    }
}