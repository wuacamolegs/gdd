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
using Excepciones;
using Conexion;

namespace PagoElectronico.ABM_Cliente
{
    public partial class formTarjeta : Form
    {
        public Tarjeta unaTarjeta = new Tarjeta();
        public Cliente unCliente = new Cliente();

        public formTarjeta()
        {
            InitializeComponent();
        }

        public void abrirParaModificarCon(Tarjeta tarjeta)
        {
            unaTarjeta = tarjeta;
            unCliente = unaTarjeta.Cliente;
            cmbEmisor.SelectedValue = unaTarjeta.Emisor;
            chkActivar.Checked = unaTarjeta.Estado;
            btnCrear.Visible = false;
        }

        private void formTarjeta_Load(object sender, EventArgs e)
        {
            //CARGAR COMBO EMISOR
            DataSet dsEmisor = SQLHelper.ExecuteDataSet("traerListadoEmisorTarjeta");
            DropDownListManager.CargarCombo(cmbEmisor, dsEmisor.Tables[0], "emisor_id", "emisor_descripcion", false, "");
            cmbEmisor.SelectedIndex = -1;           
        }
        
        public void abrirParaAsociarNueva(Tarjeta tarjeta)
        {
            unaTarjeta = tarjeta;
            chkActivar.Visible = false;
            btnModificar.Visible = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            unaTarjeta.Emisor = Convert.ToInt64(cmbEmisor.SelectedValue);
            unaTarjeta.Estado = chkActivar.Checked;
            unaTarjeta.UpdateTarjeta();
            MessageBox.Show("Se Modificó correctamente la tarjeta: " + unaTarjeta.tarjeta_id, "Modificar Tarjeta");
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            unaTarjeta.Emisor = Convert.ToInt64(cmbEmisor.SelectedValue);
            unaTarjeta.FechaEmision = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);
            unaTarjeta.CrearNueva();
            MessageBox.Show("Se creó una nueva Tarjeta para el cliente: " + unaTarjeta.Cliente.cliente_id, "Modificar Tarjeta");
            this.Close();
        }
    }
}
