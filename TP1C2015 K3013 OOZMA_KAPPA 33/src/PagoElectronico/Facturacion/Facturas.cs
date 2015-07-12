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


        internal void AbrirCon(Factura factura, string subTotalTransferencias, string subTotalModificacionesTC, decimal subtotalSuscrip, Int64 cantTransferencias, Int64 cantModificaciones, Int64 cantSuscr)
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
            //primero inserto items factura en tabla items, y luego la nueva factura en tabla factura.
            //cuando genero factura tambien mando tabla con suscripciones por cuenta
            unaFactura.GenerarFactura();
            unaFactura.AñadirItems(unaFactura.Numero, Convert.ToDecimal(txtCantidadTransf.Text), Convert.ToDecimal(txtTransferencia.Text), Convert.ToDecimal(txtCantidadMod.Text), Convert.ToDecimal(txtModificacion.Text), Convert.ToDecimal(txtCantidadSuscr.Text), Convert.ToDecimal(txtSuscripciones.Text));
            MessageBox.Show("FACTURA GENERADA EXITOSAMENTE: " + unaFactura.Numero + "\nCliente: " + unaFactura.Cliente.cliente_id + "\nImporte: " + unaFactura.Importe + "\nFecha: " + unaFactura.Fecha, "Factura");
            this.Close();
        }

        #endregion






    }
}
