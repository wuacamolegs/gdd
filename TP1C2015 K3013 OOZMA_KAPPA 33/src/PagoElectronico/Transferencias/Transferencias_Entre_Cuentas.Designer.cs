namespace PagoElectronico.Transferencias
{
    partial class Transferencias_Entre_Cuentas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Saldo = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.cmbCuentaOrigen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbClienteOrigen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCuentaDestino = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Saldo);
            this.groupBox1.Controls.Add(this.txtSaldo);
            this.groupBox1.Controls.Add(this.cmbCuentaOrigen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbClienteOrigen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(33, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ORIGEN";
            // 
            // Saldo
            // 
            this.Saldo.AutoSize = true;
            this.Saldo.Location = new System.Drawing.Point(70, 128);
            this.Saldo.Name = "Saldo";
            this.Saldo.Size = new System.Drawing.Size(39, 15);
            this.Saldo.TabIndex = 5;
            this.Saldo.Text = "Saldo";
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSaldo.Location = new System.Drawing.Point(117, 125);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(103, 21);
            this.txtSaldo.TabIndex = 4;
            // 
            // cmbCuentaOrigen
            // 
            this.cmbCuentaOrigen.Location = new System.Drawing.Point(73, 76);
            this.cmbCuentaOrigen.Name = "cmbCuentaOrigen";
            this.cmbCuentaOrigen.Size = new System.Drawing.Size(147, 23);
            this.cmbCuentaOrigen.TabIndex = 6;
            this.cmbCuentaOrigen.SelectedIndexChanged += new System.EventHandler(this.cmbCuentaOrigen_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "CUENTA";
            // 
            // cmbClienteOrigen
            // 
            this.cmbClienteOrigen.FormattingEnabled = true;
            this.cmbClienteOrigen.Location = new System.Drawing.Point(73, 35);
            this.cmbClienteOrigen.Name = "cmbClienteOrigen";
            this.cmbClienteOrigen.Size = new System.Drawing.Size(147, 23);
            this.cmbClienteOrigen.TabIndex = 1;
            this.cmbClienteOrigen.SelectedIndexChanged += new System.EventHandler(this.cmbClienteOrigen_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "CLIENTE";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCuentaDestino);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(298, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 162);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DESTINO";
            // 
            // txtCuentaDestino
            // 
            this.txtCuentaDestino.Location = new System.Drawing.Point(76, 76);
            this.txtCuentaDestino.Name = "txtCuentaDestino";
            this.txtCuentaDestino.Size = new System.Drawing.Size(182, 20);
            this.txtCuentaDestino.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "CUENTA";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtImporte);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(33, 180);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(529, 56);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(265, 23);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(122, 20);
            this.txtImporte.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(168, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "IMPORTE";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(469, 242);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(93, 42);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // Transferencias_Entre_Cuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 296);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Transferencias_Entre_Cuentas";
            this.Text = "PAGO ELECTRONICO - TRANSFERENCIAS ENTRE CUENTAS";
            this.Load += new System.EventHandler(this.Transferencias_Entre_Cuentas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbCuentaOrigen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbClienteOrigen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label Saldo;
        private System.Windows.Forms.TextBox txtCuentaDestino;
    }
}