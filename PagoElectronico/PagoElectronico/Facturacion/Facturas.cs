using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.Facturacion
{
    public partial class Facturas : Form
    {
        public Facturas()
        {
            InitializeComponent();
        }


        internal void AbrirCon(Clases.Factura unaFactura, string p, string p_3, string p_4)
        {
            txtCliente.Text = unaFactura.Cliente.Apellido + " " + unaFactura.Cliente.Nombre;
            txtFecha.Text = Convert.ToString(unaFactura.Fecha);
            txtTotal.Text = Convert.ToString(unaFactura.Importe);
            txtTransferencia.Text = p;
            txtApertura.Text = p_3;
            txtModificacion.Text = p_4;
            this.Show();

        }
    }
}
