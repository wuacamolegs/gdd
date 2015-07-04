using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class Cuenta : Form
    {
        private Button btnAceptar;
        private Label lblCuenta;
        private Label lblPais;
        private Label lblMoneda;
        private Label lblFecha;
        private Label lblTipoDeCuenta;
        private ComboBox cmbPais;
        private ComboBox cmbMoneda;
        private DateTimePicker txtFechaDeApertura;
        private ComboBox cmbTipoDeCuenta;
        private CheckBox chkHabilitada;
        private TextBox txtCuenta;
    
        public Cuenta()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.lblPais = new System.Windows.Forms.Label();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblTipoDeCuenta = new System.Windows.Forms.Label();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.cmbPais = new System.Windows.Forms.ComboBox();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.txtFechaDeApertura = new System.Windows.Forms.DateTimePicker();
            this.cmbTipoDeCuenta = new System.Windows.Forms.ComboBox();
            this.chkHabilitada = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnAceptar.Location = new System.Drawing.Point(443, 224);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(114, 30);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblCuenta.Location = new System.Drawing.Point(12, 42);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(87, 16);
            this.lblCuenta.TabIndex = 1;
            this.lblCuenta.Text = "Nº de Cuenta";
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblPais.Location = new System.Drawing.Point(308, 43);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(95, 16);
            this.lblPais.TabIndex = 2;
            this.lblPais.Text = "País de origen";
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblMoneda.Location = new System.Drawing.Point(12, 99);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(58, 16);
            this.lblMoneda.TabIndex = 3;
            this.lblMoneda.Text = "Moneda";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblFecha.Location = new System.Drawing.Point(12, 164);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(119, 16);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha de Apertura";
            // 
            // lblTipoDeCuenta
            // 
            this.lblTipoDeCuenta.AutoSize = true;
            this.lblTipoDeCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTipoDeCuenta.Location = new System.Drawing.Point(303, 99);
            this.lblTipoDeCuenta.Name = "lblTipoDeCuenta";
            this.lblTipoDeCuenta.Size = new System.Drawing.Size(100, 16);
            this.lblTipoDeCuenta.TabIndex = 5;
            this.lblTipoDeCuenta.Text = "Tipo de Cuenta";
            // 
            // txtCuenta
            // 
            this.txtCuenta.Location = new System.Drawing.Point(128, 41);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(145, 20);
            this.txtCuenta.TabIndex = 6;
            // 
            // cmbPais
            // 
            this.cmbPais.FormattingEnabled = true;
            this.cmbPais.Location = new System.Drawing.Point(417, 40);
            this.cmbPais.Name = "cmbPais";
            this.cmbPais.Size = new System.Drawing.Size(145, 21);
            this.cmbPais.TabIndex = 7;
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Location = new System.Drawing.Point(128, 99);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(145, 21);
            this.cmbMoneda.TabIndex = 8;
            // 
            // txtFechaDeApertura
            // 
            this.txtFechaDeApertura.Location = new System.Drawing.Point(152, 162);
            this.txtFechaDeApertura.Name = "txtFechaDeApertura";
            this.txtFechaDeApertura.Size = new System.Drawing.Size(205, 20);
            this.txtFechaDeApertura.TabIndex = 9;
            // 
            // cmbTipoDeCuenta
            // 
            this.cmbTipoDeCuenta.FormattingEnabled = true;
            this.cmbTipoDeCuenta.Location = new System.Drawing.Point(417, 98);
            this.cmbTipoDeCuenta.Name = "cmbTipoDeCuenta";
            this.cmbTipoDeCuenta.Size = new System.Drawing.Size(145, 21);
            this.cmbTipoDeCuenta.TabIndex = 10;
            // 
            // chkHabilitada
            // 
            this.chkHabilitada.AutoSize = true;
            this.chkHabilitada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkHabilitada.Location = new System.Drawing.Point(473, 160);
            this.chkHabilitada.Name = "chkHabilitada";
            this.chkHabilitada.Size = new System.Drawing.Size(89, 20);
            this.chkHabilitada.TabIndex = 11;
            this.chkHabilitada.Text = "Habilitada";
            this.chkHabilitada.UseVisualStyleBackColor = true;
            // 
            // Cuenta
            // 
            this.ClientSize = new System.Drawing.Size(569, 289);
            this.Controls.Add(this.chkHabilitada);
            this.Controls.Add(this.cmbTipoDeCuenta);
            this.Controls.Add(this.txtFechaDeApertura);
            this.Controls.Add(this.cmbMoneda);
            this.Controls.Add(this.cmbPais);
            this.Controls.Add(this.txtCuenta);
            this.Controls.Add(this.lblTipoDeCuenta);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblMoneda);
            this.Controls.Add(this.lblPais);
            this.Controls.Add(this.lblCuenta);
            this.Controls.Add(this.btnAceptar);
            this.Name = "Cuenta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
