namespace PagoElectronico.Facturacion
{
    partial class Facturacion_De_Costos
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
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSubTotalModificacionTC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gridModificacionTipoCuenta = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSubTotalReapertura = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gridReaperturaCuenta = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSubTotalTransferencia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridTranseferencia = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSuscripciones = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridModificacionTipoCuenta)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReaperturaCuenta)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTranseferencia)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCliente);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 561);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FACTURA";
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(261, 37);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(273, 28);
            this.cmbCliente.TabIndex = 3;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "CLIENTE";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSubTotalModificacionTC);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.gridModificacionTipoCuenta);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(28, 411);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(646, 137);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "MODIFICACION TIPO CUENTA";
            // 
            // txtSubTotalModificacionTC
            // 
            this.txtSubTotalModificacionTC.Location = new System.Drawing.Point(552, 111);
            this.txtSubTotalModificacionTC.Name = "txtSubTotalModificacionTC";
            this.txtSubTotalModificacionTC.Size = new System.Drawing.Size(75, 22);
            this.txtSubTotalModificacionTC.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(490, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "SubTotal";
            // 
            // gridModificacionTipoCuenta
            // 
            this.gridModificacionTipoCuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridModificacionTipoCuenta.Location = new System.Drawing.Point(23, 27);
            this.gridModificacionTipoCuenta.Name = "gridModificacionTipoCuenta";
            this.gridModificacionTipoCuenta.Size = new System.Drawing.Size(604, 78);
            this.gridModificacionTipoCuenta.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSubTotalReapertura);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.gridReaperturaCuenta);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(28, 260);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(645, 135);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "REAPERTURA CUENTA";
            // 
            // txtSubTotalReapertura
            // 
            this.txtSubTotalReapertura.Location = new System.Drawing.Point(552, 104);
            this.txtSubTotalReapertura.Name = "txtSubTotalReapertura";
            this.txtSubTotalReapertura.Size = new System.Drawing.Size(75, 22);
            this.txtSubTotalReapertura.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(490, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "SubTotal";
            // 
            // gridReaperturaCuenta
            // 
            this.gridReaperturaCuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReaperturaCuenta.Location = new System.Drawing.Point(23, 26);
            this.gridReaperturaCuenta.Name = "gridReaperturaCuenta";
            this.gridReaperturaCuenta.Size = new System.Drawing.Size(604, 71);
            this.gridReaperturaCuenta.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSubTotalTransferencia);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.gridTranseferencia);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(28, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(646, 171);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TRANSFERENCIAS";
            // 
            // txtSubTotalTransferencia
            // 
            this.txtSubTotalTransferencia.Location = new System.Drawing.Point(552, 140);
            this.txtSubTotalTransferencia.Name = "txtSubTotalTransferencia";
            this.txtSubTotalTransferencia.Size = new System.Drawing.Size(75, 22);
            this.txtSubTotalTransferencia.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(490, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "SubTotal";
            // 
            // gridTranseferencia
            // 
            this.gridTranseferencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTranseferencia.Location = new System.Drawing.Point(23, 33);
            this.gridTranseferencia.Name = "gridTranseferencia";
            this.gridTranseferencia.Size = new System.Drawing.Size(604, 100);
            this.gridTranseferencia.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 602);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cantidad suscripciones a Tipo de Cuenta";
            // 
            // txtSuscripciones
            // 
            this.txtSuscripciones.Location = new System.Drawing.Point(318, 600);
            this.txtSuscripciones.Name = "txtSuscripciones";
            this.txtSuscripciones.Size = new System.Drawing.Size(56, 20);
            this.txtSuscripciones.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(560, 583);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 61);
            this.button1.TabIndex = 3;
            this.button1.Text = "Generar Factura";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Facturacion_De_Costos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 661);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSuscripciones);
            this.Controls.Add(this.label1);
            this.Name = "Facturacion_De_Costos";
            this.Text = "PAGO ELECTRONICO - FACTURACION DE COSTOS";
            this.Load += new System.EventHandler(this.Facturacion_De_Costos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridModificacionTipoCuenta)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReaperturaCuenta)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTranseferencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridModificacionTipoCuenta;
        private System.Windows.Forms.DataGridView gridReaperturaCuenta;
        private System.Windows.Forms.DataGridView gridTranseferencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSuscripciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubTotalTransferencia;
        private System.Windows.Forms.TextBox txtSubTotalModificacionTC;
        private System.Windows.Forms.TextBox txtSubTotalReapertura;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label5;
    }
}