namespace PagoElectronico.Facturacion
{
    partial class Facturas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtTransferencia = new System.Windows.Forms.TextBox();
            this.txtSuscripciones = new System.Windows.Forms.TextBox();
            this.txtModificacion = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCantidadTransf = new System.Windows.Forms.TextBox();
            this.txtCantidadMod = new System.Windows.Forms.TextBox();
            this.txtCantidadSuscr = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "FACTURA NRO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(506, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "CLIENTE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(506, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "FECHA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "TRANSFERENCIAS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(69, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "SUSCRIPCIONES";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(69, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(236, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "MODIFICACION TIPO CUENTA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(506, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "TOTAL";
            // 
            // txtFactura
            // 
            this.txtFactura.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtFactura.Location = new System.Drawing.Point(193, 73);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.ReadOnly = true;
            this.txtFactura.Size = new System.Drawing.Size(248, 20);
            this.txtFactura.TabIndex = 4;
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtCliente.Location = new System.Drawing.Point(595, 19);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(200, 20);
            this.txtCliente.TabIndex = 5;
            // 
            // txtFecha
            // 
            this.txtFecha.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtFecha.Location = new System.Drawing.Point(597, 74);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(100, 20);
            this.txtFecha.TabIndex = 6;
            // 
            // txtTransferencia
            // 
            this.txtTransferencia.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTransferencia.Location = new System.Drawing.Point(341, 120);
            this.txtTransferencia.Name = "txtTransferencia";
            this.txtTransferencia.ReadOnly = true;
            this.txtTransferencia.Size = new System.Drawing.Size(100, 20);
            this.txtTransferencia.TabIndex = 7;
            // 
            // txtSuscripciones
            // 
            this.txtSuscripciones.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSuscripciones.Location = new System.Drawing.Point(341, 198);
            this.txtSuscripciones.Name = "txtSuscripciones";
            this.txtSuscripciones.ReadOnly = true;
            this.txtSuscripciones.Size = new System.Drawing.Size(100, 20);
            this.txtSuscripciones.TabIndex = 8;
            // 
            // txtModificacion
            // 
            this.txtModificacion.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtModificacion.Location = new System.Drawing.Point(341, 159);
            this.txtModificacion.Name = "txtModificacion";
            this.txtModificacion.ReadOnly = true;
            this.txtModificacion.Size = new System.Drawing.Size(100, 20);
            this.txtModificacion.TabIndex = 9;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTotal.Location = new System.Drawing.Point(595, 241);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(200, 20);
            this.txtTotal.TabIndex = 10;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(668, 307);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(108, 36);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(510, 307);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 36);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCantidadTransf
            // 
            this.txtCantidadTransf.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCantidadTransf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCantidadTransf.Location = new System.Drawing.Point(37, 120);
            this.txtCantidadTransf.Name = "txtCantidadTransf";
            this.txtCantidadTransf.ReadOnly = true;
            this.txtCantidadTransf.Size = new System.Drawing.Size(30, 13);
            this.txtCantidadTransf.TabIndex = 13;
            // 
            // txtCantidadMod
            // 
            this.txtCantidadMod.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCantidadMod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCantidadMod.Location = new System.Drawing.Point(37, 159);
            this.txtCantidadMod.Name = "txtCantidadMod";
            this.txtCantidadMod.ReadOnly = true;
            this.txtCantidadMod.Size = new System.Drawing.Size(26, 13);
            this.txtCantidadMod.TabIndex = 14;
            // 
            // txtCantidadSuscr
            // 
            this.txtCantidadSuscr.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCantidadSuscr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCantidadSuscr.Location = new System.Drawing.Point(37, 202);
            this.txtCantidadSuscr.Name = "txtCantidadSuscr";
            this.txtCantidadSuscr.ReadOnly = true;
            this.txtCantidadSuscr.Size = new System.Drawing.Size(26, 13);
            this.txtCantidadSuscr.TabIndex = 15;
            // 
            // Facturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 355);
            this.Controls.Add(this.txtCantidadSuscr);
            this.Controls.Add(this.txtCantidadMod);
            this.Controls.Add(this.txtCantidadTransf);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtModificacion);
            this.Controls.Add(this.txtSuscripciones);
            this.Controls.Add(this.txtTransferencia);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtFactura);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Facturas";
            this.Text = "FACTURA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtTransferencia;
        private System.Windows.Forms.TextBox txtSuscripciones;
        private System.Windows.Forms.TextBox txtModificacion;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtCantidadTransf;
        private System.Windows.Forms.TextBox txtCantidadMod;
        private System.Windows.Forms.TextBox txtCantidadSuscr;
    }
}