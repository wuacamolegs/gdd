using System;
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


        internal void AbrirCon(Factura factura, string subTotalTransferencias, string subTotalModificacionesTC, decimal subtotalSuscrip, int cantTransferencias, int cantModificaciones, int cantSuscr)
        {
            unaFactura = factura;
            txtCliente.Text = factura.Cliente.Apellido + " " + factura.Cliente.Nombre;
            txtFecha.Text = Convert.ToString(factura.Fecha);
            unaFactura.Importe = 0;
            txtCantidadMod.Text = cantModificaciones.ToString();
            txtCantidadTransf.Text = cantTransferencias.ToString();
            txtCantidadSuscr.Text = cantSuscr.ToString();

            if (subTotalTransferencias == "")
            {
                txtTransferencia.Text = "0";
            }
            else
            {
                txtTransferencia.Text = subTotalTransferencias;
                unaFactura.Importe = unaFactura.Importe + Convert.ToDecimal(subTotalTransferencias);
            }
            if (subTotalModificacionesTC == "")
            {
                txtModificacion.Text = "0";
            }
            else
            {
                txtModificacion.Text = subTotalModificacionesTC;
                unaFactura.Importe = unaFactura.Importe + Convert.ToDecimal(subTotalModificacionesTC);
            }

            if (subtotalSuscrip == 0)
            {
                txtSuscripciones.Text = "0";
            }
            else
            {
                txtSuscripciones.Text = subtotalSuscrip.ToString();
                unaFactura.Importe = unaFactura.Importe + Convert.ToDecimal(subtotalSuscrip);
            }
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
            MessageBox.Show("Se genero la factura. Cliente: " + unaFactura.Cliente.cliente_id + " Importe: " + unaFactura.Importe + " Fecha: " + unaFactura.Fecha, "Factura");
            unaFactura = unaFactura.GenerarFactura();
            unaFactura.AñadirItems(Convert.ToInt32(txtCantidadTransf.Text), Convert.ToDecimal(txtTransferencia.Text), Convert.ToInt32(txtCantidadMod.Text), Convert.ToDecimal(txtModificacion.Text), Convert.ToInt32(txtCantidadSuscr.Text), Convert.ToDecimal(txtSuscripciones.Text));
        }

        #endregion






    }
}
