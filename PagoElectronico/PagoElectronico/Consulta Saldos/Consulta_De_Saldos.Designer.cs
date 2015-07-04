namespace PagoElectronico.Consulta_Saldos
{
    partial class Consulta_De_Saldos
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
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.cmbCuenta = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.SALDO = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbCliente
            // 
            this.cmbCliente.BackColor = System.Drawing.Color.White;
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(170, 44);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(217, 21);
            this.cmbCliente.TabIndex = 1;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // cmbCuenta
            // 
            this.cmbCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCuenta.FormattingEnabled = true;
            this.cmbCuenta.Location = new System.Drawing.Point(170, 104);
            this.cmbCuenta.Name = "cmbCuenta";
            this.cmbCuenta.Size = new System.Drawing.Size(217, 21);
            this.cmbCuenta.TabIndex = 2;
            this.cmbCuenta.SelectedIndexChanged += new System.EventHandler(this.cmbCuenta_SelectedIndexChanged);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblCliente.Location = new System.Drawing.Point(42, 47);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(70, 18);
            this.lblCliente.TabIndex = 3;
            this.lblCliente.Text = "CLIENTE";
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblCuenta.Location = new System.Drawing.Point(43, 104);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(69, 18);
            this.lblCuenta.TabIndex = 4;
            this.lblCuenta.Text = "CUENTA";
            // 
            // SALDO
            // 
            this.SALDO.AutoSize = true;
            this.SALDO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.SALDO.Location = new System.Drawing.Point(42, 164);
            this.SALDO.Name = "SALDO";
            this.SALDO.Size = new System.Drawing.Size(58, 18);
            this.SALDO.TabIndex = 5;
            this.SALDO.Text = "SALDO";
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSaldo.Location = new System.Drawing.Point(170, 162);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(217, 20);
            this.txtSaldo.TabIndex = 7;
            // 
            // Consulta_De_Saldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 220);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.SALDO);
            this.Controls.Add(this.lblCuenta);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cmbCuenta);
            this.Controls.Add(this.cmbCliente);
            this.Name = "Consulta_De_Saldos";
            this.Text = "PAGO ELECTRONICO - CONSULTA DE SALDOS";
            this.Load += new System.EventHandler(this.Consulta_De_Saldos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.ComboBox cmbCuenta;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.Label SALDO;
        private System.Windows.Forms.TextBox txtSaldo;
    }
}