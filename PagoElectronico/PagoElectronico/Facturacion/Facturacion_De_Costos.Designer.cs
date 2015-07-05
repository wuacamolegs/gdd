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
            this.gbSuscripciones = new System.Windows.Forms.GroupBox();
            this.btnAñadirSuscripcionesCuenta = new System.Windows.Forms.Button();
            this.cmbCuenta = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubTotalSuscr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCostoUnitario = new System.Windows.Forms.TextBox();
            this.txtSuscripcionesAPagar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSuscripcionesPendientes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSubTotalModificacionTC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gridModificacionTC = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSubTotalTransferencia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridTransferencia = new System.Windows.Forms.DataGridView();
            this.btnGenerarFactura = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbSuscripciones.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridModificacionTC)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransferencia)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbSuscripciones);
            this.groupBox1.Controls.Add(this.cmbCliente);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 583);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FACTURA";
            // 
            // gbSuscripciones
            // 
            this.gbSuscripciones.Controls.Add(this.btnAñadirSuscripcionesCuenta);
            this.gbSuscripciones.Controls.Add(this.cmbCuenta);
            this.gbSuscripciones.Controls.Add(this.label8);
            this.gbSuscripciones.Controls.Add(this.label4);
            this.gbSuscripciones.Controls.Add(this.txtSubTotalSuscr);
            this.gbSuscripciones.Controls.Add(this.label1);
            this.gbSuscripciones.Controls.Add(this.txtCostoUnitario);
            this.gbSuscripciones.Controls.Add(this.txtSuscripcionesAPagar);
            this.gbSuscripciones.Controls.Add(this.label7);
            this.gbSuscripciones.Controls.Add(this.txtSuscripcionesPendientes);
            this.gbSuscripciones.Controls.Add(this.label6);
            this.gbSuscripciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.gbSuscripciones.Location = new System.Drawing.Point(28, 440);
            this.gbSuscripciones.Name = "gbSuscripciones";
            this.gbSuscripciones.Size = new System.Drawing.Size(646, 137);
            this.gbSuscripciones.TabIndex = 10;
            this.gbSuscripciones.TabStop = false;
            this.gbSuscripciones.Text = "SUSCRIPCIONES PENDIENTES";
            // 
            // btnAñadirSuscripcionesCuenta
            // 
            this.btnAñadirSuscripcionesCuenta.Location = new System.Drawing.Point(561, 40);
            this.btnAñadirSuscripcionesCuenta.Name = "btnAñadirSuscripcionesCuenta";
            this.btnAñadirSuscripcionesCuenta.Size = new System.Drawing.Size(75, 23);
            this.btnAñadirSuscripcionesCuenta.TabIndex = 12;
            this.btnAñadirSuscripcionesCuenta.Text = "Añadir";
            this.btnAñadirSuscripcionesCuenta.UseVisualStyleBackColor = true;
            this.btnAñadirSuscripcionesCuenta.Click += new System.EventHandler(this.btnAñadirSuscripcionesCuenta_Click);
            // 
            // cmbCuenta
            // 
            this.cmbCuenta.FormattingEnabled = true;
            this.cmbCuenta.Location = new System.Drawing.Point(120, 36);
            this.cmbCuenta.Name = "cmbCuenta";
            this.cmbCuenta.Size = new System.Drawing.Size(273, 24);
            this.cmbCuenta.TabIndex = 11;
            this.cmbCuenta.SelectedIndexChanged += new System.EventHandler(this.cmbCuenta_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(35, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "CUENTA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label4.Location = new System.Drawing.Point(35, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cantidad Suscripciones Pendientes De Pago";
            // 
            // txtSubTotalSuscr
            // 
            this.txtSubTotalSuscr.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSubTotalSuscr.Location = new System.Drawing.Point(561, 113);
            this.txtSubTotalSuscr.Name = "txtSubTotalSuscr";
            this.txtSubTotalSuscr.ReadOnly = true;
            this.txtSubTotalSuscr.Size = new System.Drawing.Size(75, 22);
            this.txtSubTotalSuscr.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(35, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cantidad Suscripciones a Pagar";
            // 
            // txtCostoUnitario
            // 
            this.txtCostoUnitario.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCostoUnitario.Location = new System.Drawing.Point(561, 77);
            this.txtCostoUnitario.Name = "txtCostoUnitario";
            this.txtCostoUnitario.ReadOnly = true;
            this.txtCostoUnitario.Size = new System.Drawing.Size(75, 22);
            this.txtCostoUnitario.TabIndex = 8;
            // 
            // txtSuscripcionesAPagar
            // 
            this.txtSuscripcionesAPagar.Location = new System.Drawing.Point(266, 111);
            this.txtSuscripcionesAPagar.Name = "txtSuscripcionesAPagar";
            this.txtSuscripcionesAPagar.Size = new System.Drawing.Size(56, 22);
            this.txtSuscripcionesAPagar.TabIndex = 2;
            this.txtSuscripcionesAPagar.TextChanged += new System.EventHandler(this.txtSuscripcionesAPagar_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label7.Location = new System.Drawing.Point(342, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 18);
            this.label7.TabIndex = 7;
            this.label7.Text = "Sub Total Por Suscripciones";
            // 
            // txtSuscripcionesPendientes
            // 
            this.txtSuscripcionesPendientes.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSuscripcionesPendientes.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSuscripcionesPendientes.Location = new System.Drawing.Point(266, 79);
            this.txtSuscripcionesPendientes.Name = "txtSuscripcionesPendientes";
            this.txtSuscripcionesPendientes.ReadOnly = true;
            this.txtSuscripcionesPendientes.Size = new System.Drawing.Size(56, 22);
            this.txtSuscripcionesPendientes.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(366, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Costo Unitario Por Suscripcion";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSubTotalModificacionTC);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.gridModificacionTC);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(28, 287);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(645, 145);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MODIFICACION TIPO CUENTA";
            // 
            // txtSubTotalModificacionTC
            // 
            this.txtSubTotalModificacionTC.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSubTotalModificacionTC.Location = new System.Drawing.Point(552, 114);
            this.txtSubTotalModificacionTC.Name = "txtSubTotalModificacionTC";
            this.txtSubTotalModificacionTC.ReadOnly = true;
            this.txtSubTotalModificacionTC.Size = new System.Drawing.Size(75, 22);
            this.txtSubTotalModificacionTC.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(490, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "SubTotal";
            // 
            // gridModificacionTC
            // 
            this.gridModificacionTC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridModificacionTC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridModificacionTC.Location = new System.Drawing.Point(23, 26);
            this.gridModificacionTC.Name = "gridModificacionTC";
            this.gridModificacionTC.Size = new System.Drawing.Size(604, 80);
            this.gridModificacionTC.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSubTotalTransferencia);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.gridTransferencia);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(28, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(646, 198);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TRANSFERENCIAS";
            // 
            // txtSubTotalTransferencia
            // 
            this.txtSubTotalTransferencia.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSubTotalTransferencia.Location = new System.Drawing.Point(552, 165);
            this.txtSubTotalTransferencia.Name = "txtSubTotalTransferencia";
            this.txtSubTotalTransferencia.ReadOnly = true;
            this.txtSubTotalTransferencia.Size = new System.Drawing.Size(75, 22);
            this.txtSubTotalTransferencia.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(490, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "SubTotal";
            // 
            // gridTransferencia
            // 
            this.gridTransferencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridTransferencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTransferencia.Location = new System.Drawing.Point(23, 33);
            this.gridTransferencia.Name = "gridTransferencia";
            this.gridTransferencia.Size = new System.Drawing.Size(604, 126);
            this.gridTransferencia.TabIndex = 0;
            // 
            // btnGenerarFactura
            // 
            this.btnGenerarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarFactura.Location = new System.Drawing.Point(568, 599);
            this.btnGenerarFactura.Name = "btnGenerarFactura";
            this.btnGenerarFactura.Size = new System.Drawing.Size(115, 53);
            this.btnGenerarFactura.TabIndex = 3;
            this.btnGenerarFactura.Text = "Generar Factura";
            this.btnGenerarFactura.UseVisualStyleBackColor = true;
            this.btnGenerarFactura.Click += new System.EventHandler(this.btnGenerarFactura_Click);
            // 
            // Facturacion_De_Costos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 660);
            this.Controls.Add(this.btnGenerarFactura);
            this.Controls.Add(this.groupBox1);
            this.Name = "Facturacion_De_Costos";
            this.Text = "PAGO ELECTRONICO - FACTURACION DE COSTOS";
            this.Load += new System.EventHandler(this.Facturacion_De_Costos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbSuscripciones.ResumeLayout(false);
            this.gbSuscripciones.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridModificacionTC)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransferencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridModificacionTC;
        private System.Windows.Forms.DataGridView gridTransferencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSuscripcionesAPagar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubTotalTransferencia;
        private System.Windows.Forms.TextBox txtSubTotalModificacionTC;
        private System.Windows.Forms.Button btnGenerarFactura;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSuscripcionesPendientes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSubTotalSuscr;
        private System.Windows.Forms.TextBox txtCostoUnitario;
        private System.Windows.Forms.GroupBox gbSuscripciones;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbCuenta;
        private System.Windows.Forms.Button btnAñadirSuscripcionesCuenta;
    }
}