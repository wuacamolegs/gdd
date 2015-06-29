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
        #region variables

        public Usuario unUsuario = new Usuario();
        public Cliente unCliente = new Cliente();
        public Factura unaFactura = new Factura();
        Decimal subtotalSuscripciones = 0;
        int cantidadSuscAPagar = 0;
        int cantidadTransferencias = 0;
        int cantidadModificaciones = 0;
        Tuplas<int,int> tupla = new Tuplas<int,int>();
        
        #endregion

        #region initialize
        public Facturacion_De_Costos()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            unCliente.Usuario = user;
            unaFactura.Cliente = unCliente;
            this.Show();
        }

        private void Facturacion_De_Costos_Load(object sender, EventArgs e)
        {
            DataSet dsClientes = ObtenerClientes();
            DropDownListManager.CargarCombo(cmbCliente, dsClientes.Tables[0], "cliente_id", "cliente_nombre", false, "");
        }

        #endregion

        #region botones, vista
            
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            unCliente.cliente_id = Convert.ToInt32(cmbCliente.SelectedValue);


            //Traer cuentas asociadas al cliente    
            DataSet dsCuentas = ObtenerCuentasPorClienteId();
            DropDownListManager.CargarCombo(cmbCuenta, dsCuentas.Tables[0], "cuenta_id", "cuenta_id", false, "");

            //Traer transacciones realizadas por el cliente

            //1. TRANSFERENCIAS

            DataSet dsTransferencias = unCliente.TraerTransferenciasAFacturarPorClienteID();
            cargarDataGrids(dsTransferencias, gridTransferencia);
            cargarSubtotales(txtSubTotalTransferencia, gridTransferencia);

            //2. COSTOS POR MODIFICACION TIPO CUENTA
            
            DataSet dsModificacionTC = unCliente.TraerModificacionesTipoCuentaAFacturarPorClienteID();
            cargarDataGrids(dsModificacionTC, gridModificacionTC);
            cargarSubtotales(txtSubTotalModificacionTC, gridModificacionTC);
            
        }


       private void cargarDataGrids(DataSet ds, DataGridView dataGrid){
             
            //realizo la configuracion de las grillas, seteando las filas y columnas con sus nombres y valores
            dataGrid.Columns.Clear();
            dataGrid.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmFecha = new DataGridViewTextBoxColumn();
            clmFecha.Width = 150;
            clmFecha.ReadOnly = true;
            clmFecha.DataPropertyName = "transaccion_pendiente_fecha";
            clmFecha.HeaderText = "FECHA";
            dataGrid.Columns.Add(clmFecha);

            DataGridViewTextBoxColumn clmID = new DataGridViewTextBoxColumn();
            clmID.Width = 150;
            clmID.ReadOnly = true;
            clmID.DataPropertyName = "transaccion_pendiente_id";  
            clmID.HeaderText = "ID item";
            dataGrid.Columns.Add(clmID);

            DataGridViewTextBoxColumn clmCosto = new DataGridViewTextBoxColumn();
            clmCosto.Width = 150;
            clmCosto.ReadOnly = true;
            clmCosto.DataPropertyName = "transaccion_pendiente_importe";
            clmCosto.HeaderText = "COSTO";
            dataGrid.Columns.Add(clmCosto);

            //le inserto a la grilla el dataset obtenido
            dataGrid.DataSource = ds.Tables[0];
           
        }
        
       private void btnGenerarFactura_Click(object sender, EventArgs e)
       {
           //TODO: VALIDAR CAMPOS NO SEAN NULOS, Y QUE SEAN DEL TIPO DATO CORRECTO
               DataSet ds = unaFactura.Cliente.TraerClientePorID(unCliente.cliente_id);
               unaFactura.Cliente.DataRowToObject(ds.Tables[0].Rows[0]);
               unaFactura.Fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);
               cantidadTransferencias = gridTransferencia.Rows.Count - 1; //me cuenta la ultima fila que esta vacia. por eso le resto uno.
               cantidadModificaciones = gridModificacionTC.Rows.Count - 1;
                    
               Facturas frmFacturas = new Facturas();
               frmFacturas.AbrirCon(unaFactura, txtSubTotalTransferencia.Text, txtSubTotalModificacionTC.Text, subtotalSuscripciones, cantidadTransferencias, cantidadModificaciones, cantidadSuscAPagar);
       }

       private void cmbCuenta_SelectedIndexChanged(object sender, EventArgs e)
       {
           //CANTIDAD SUSCRIPCIONES A PAGAR Y COSTO UNITARIO (PARA ESTA CUENTA)
           if (cmbCuenta.Items.Count > 0)
           {
               Double cuentaid = Convert.ToDouble(cmbCuenta.SelectedValue);
               DataSet dsSuscripciones = unCliente.TraerSuscripcionesPendientesAFacturarPorClienteIDYCuentaID(cuentaid);
               txtSuscripcionesPendientes.Text = unCliente.TraerCantidadSuscripcionesPendientesAFacturarPorClienteIDYCuentaID(cuentaid).ToString();
               txtCostoUnitario.Text = (dsSuscripciones.Tables[0].Rows[0]["transaccion_pendiente_importe"]).ToString();
           }
       }

       private void btnAñadirSuscripcionesCuenta_Click(object sender, EventArgs e)
       {
           if (ValidarCampos())
           {
               if (txtSubTotalSuscr.Text == "")
               {
                   subtotalSuscripciones = 0;
               }
               else
               {
                    
                   txtSubTotalSuscr.Text = (Convert.ToDecimal(txtCostoUnitario.Text) * Convert.ToDecimal(txtSuscripcionesAPagar.Text)).ToString();
                   cantidadSuscAPagar = cantidadSuscAPagar + Convert.ToInt32(txtSuscripcionesAPagar.Text);
                   subtotalSuscripciones = subtotalSuscripciones + Convert.ToDecimal(txtSubTotalSuscr.Text);
                   
               }
               txtSuscripcionesPendientes.Text = (Convert.ToInt32(txtSuscripcionesPendientes.Text) - Convert.ToInt32(txtSuscripcionesAPagar.Text)).ToString();
               txtSubTotalSuscr.Clear();
               txtSuscripcionesAPagar.Clear();
           }
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

        public DataSet ObtenerCuentasPorClienteId()
        {
            int clienteID = Convert.ToInt32(cmbCliente.SelectedValue);
            DataSet dsClientes = unCliente.TraerClientePorID(clienteID);
            unCliente.DataRowToObject(dsClientes.Tables[0].Rows[0]);

            Cuenta unaCuenta = new Cuenta(unCliente, unUsuario);
            DataSet dsCuentas = unaCuenta.TraerCuentasACobrarPorClienteID();

            return dsCuentas;

        }

        #endregion

        #region metodos privados

        private bool ValidarCampos()
        {
            string strErrores = "";
            strErrores = Validator.SoloNumerosPeroOpcional(txtSuscripcionesAPagar.Text, "Suscripciones");
            if (strErrores.Length > 0)
            {
                MessageBox.Show(strErrores, "Validar Campos");
                txtSuscripcionesAPagar.Text = "";
                return false;
            }
            else
            {
                if (txtSuscripcionesAPagar.Text == "")
                {
                    return false;
                }
                else
                {
                    strErrores = Validator.ValidarCantidadMenor(txtSuscripcionesAPagar.Text, Convert.ToInt32(txtSuscripcionesPendientes.Text), "Suscripciones A Pagar");
                    if (strErrores.Length > 0)
                    {
                        MessageBox.Show(strErrores, "Validar Campos");
                        return false;
                    }else{
                        return true;
                    }
                }
            }
        }

        private void cargarSubtotales(TextBox txtSubTotal, DataGridView dataGridView)
        {
            double subtotal = 0;

            // Se recorre fila a fila para recalcular el total despues del cambio
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Se aumula el total de cada una de las filas columna 2 = Subtotal
                subtotal += Convert.ToDouble(row.Cells[2].Value);
            }
            txtSubTotal.Text = Convert.ToString(subtotal);

        }


        #endregion

        private void txtSuscripcionesAPagar_TextChanged(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                txtSubTotalSuscr.Text = (Convert.ToDecimal(txtCostoUnitario.Text) * Convert.ToDecimal(txtSuscripcionesAPagar.Text)).ToString();
            }
            
        }

        
    }
    
}
