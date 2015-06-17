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
    public partial class Facturacion_De_Costos : Form
    {
        public Usuario unUsuario = new Usuario();
        public Cliente unCliente = new Cliente();


        public Facturacion_De_Costos()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            unCliente.Usuario = user;
            this.Show();
        }


        #region botones

        private void Facturacion_De_Costos_Load(object sender, EventArgs e)
        {
            DataSet dsClientes = ObtenerClientes();
            DropDownListManager.CargarCombo(cmbCliente, dsClientes.Tables[0], "cliente_id", "cliente_nombre", false, "");
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Traer transacciones realizadas por el cliente
            unCliente.cliente_id = Convert.ToInt32(cmbCliente.SelectedValue);

            //1. TRANSFERENCIAS

            DataSet dsTransferencias = unCliente.TraerTransferenciasAFacturarPorClienteID();
            cargarDataGrids(dsTransferencias, gridTranseferencia);

            //2. COSTOS POR APERTURA CUENTA

            DataSet dsAperturaCuenta = unCliente.TraerCostosPorAperturaCuentaAFacturarPorClienteID();
            cargarDataGrids(dsAperturaCuenta, gridReaperturaCuenta);

            //3. MODIFICACION TIPO CUENTA

            DataSet dsModificacionesTC = unCliente.TraerModificacionesTipoCuentaAFacturarPorClienteID();
            cargarDataGrids(dsModificacionesTC, gridModificacionTipoCuenta);

        }

       private void cargarDataGrids(DataSet ds, DataGridView dataGrid){
             
            //realizo la configuracion de las grillas, seteando las filas y columnas con sus nombres y valores
            dataGrid.Columns.Clear();
            dataGrid.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmFecha = new DataGridViewTextBoxColumn();
            clmFecha.Width = 50;
            clmFecha.ReadOnly = true;
            clmFecha.DataPropertyName = "item_factura_fecha";
            clmFecha.HeaderText = "FECHA";
            dataGrid.Columns.Add(clmFecha);

            DataGridViewTextBoxColumn clmID = new DataGridViewTextBoxColumn();
            clmID.Width = 50;
            clmID.ReadOnly = true;
            clmID.DataPropertyName = "item_factura_id";  
            clmID.HeaderText = "ID item";
            dataGrid.Columns.Add(clmID);

            DataGridViewTextBoxColumn clmNombre = new DataGridViewTextBoxColumn();
            clmNombre.Width = 50;
            clmNombre.ReadOnly = true;
            clmNombre.DataPropertyName = "item_factura_cant";
            clmNombre.HeaderText = "CANTIDAD";
            dataGrid.Columns.Add(clmNombre);

            DataGridViewCheckBoxColumn clmCosto = new DataGridViewCheckBoxColumn();
            clmCosto.Width = 60;
            clmCosto.ReadOnly = true;
            clmCosto.DataPropertyName = "item_factura_costo";
            clmCosto.HeaderText = "COSTO";
            dataGrid.Columns.Add(clmCosto);

            //le inserto a la grilla el dataset obtenido
            dataGrid.DataSource = ds.Tables[0];
        }
        





        #endregion



        #region llamados a bd

        public DataSet ObtenerClientes()
        {

            DataSet ds = new DataSet();
            if (unUsuario.Rol.rol_id == 1)
            {
                DataSet dsClientes = unCliente.ObtenerTodosLosClientes(unUsuario.usuario_id);
                ds = dsClientes;
            }
            else
            {
                DataSet dsClienteUsuario = unCliente.ObtenerClientesPorUsuarioID(unUsuario.usuario_id);
                ds = dsClienteUsuario;
            }

            return ds;

        }

        #endregion








    }
    
}
