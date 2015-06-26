﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Clases;
using Utilities;


namespace PagoElectronico.Facturacion
{
    public partial class Facturas : Form
    {
        #region variables

        Factura unaFactura;

        #endregion  

        #region initialize

        public Facturas()
        {
            InitializeComponent();
        }


        internal void AbrirCon(Factura factura, string p, string p_3)
        {
            unaFactura = factura;
            txtCliente.Text = factura.Cliente.Apellido + " " + factura.Cliente.Nombre;
            txtFecha.Text = Convert.ToString(factura.Fecha);
            txtTransferencia.Text = p;
            txtApertura.Text = p_3;
            unaFactura.Importe = Convert.ToDecimal(txtTransferencia.Text) + Convert.ToDecimal(txtApertura.Text));
            txtTotal.Text = Convert.ToString(unaFactura.Importe);
            this.Show();
        }
        #endregion


        #region botones

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            unaFactura.GenerarFactura();
        }

        #endregion





    }
}
