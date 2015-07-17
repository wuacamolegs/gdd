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
        public Cuenta unaCuenta = new Cuenta();
        Decimal subtotalSuscripciones = 0;
        Int64 cantidadSuscAPagar = 0;
        Int64 cantidadTransferencias = 0;
        Int64 cantidadModificaciones = 0;

        
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
            unaCuenta.Cliente = unCliente;
            unaFactura.Cliente = unCliente;
            this.Show();
        }

        private void Facturacion_De_Costos_Load(object sender, EventArgs e)
        {
            //Traigo solo los clientes que tengan cosas a facturar (los que aparecen en transacciones pendientes)
            DataSet dsClientes = ObtenerClientes();
            if (dsClientes.Tables[0].Rows.Count > 0)
            {
                DropDownListManager.CargarCombo(cmbCliente, dsClientes.Tables[0], "cliente_id", "cliente_nombre", false, "");
            }
            else 
            {
                MessageBox.Show("No se encuentran Transacciones A Facturar", "");
            }
        }

        #endregion

        #region botones, vista
            
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
                DataSet dsCuentas = ObtenerCuentasAFacturarPorClienteId();

                //Si no tiene cuentas con suscripciones a pagar escondo grupo suscripciones
                if (dsCuentas.Tables[0].Rows.Count == 0)
                {
                    gbSuscripciones.Visible = false;
                }
                else
                {
                    gbSuscripciones.Visible = true;
                    DropDownListManager.CargarCombo(cmbCuenta, dsCuentas.Tables[0], "cuenta_id", "cuenta_id", false, "");
                }

                //Traer transacciones realizadas por el cliente

                //1. TRANSFERENCIAS

                DataSet dsTransferencias = unCliente.TraerTransferenciasAFacturarPorClienteID();
                if (dsTransferencias.Tables[0].Rows.Count > 0)
                {
                    cargarDataGrids(dsTransferencias, gridTransferencia);
                    cargarSubtotales(txtSubTotalTransferencia, gridTransferencia);
                    gbTransferencias.Visible = true;
                }
                else
                {
                    gbTransferencias.Visible = false;
                }


                //2. COSTOS POR MODIFICACION TIPO CUENTA

                DataSet dsModificacionTC = unCliente.TraerModificacionesTipoCuentaAFacturarPorClienteID();
                if (dsModificacionTC.Tables[0].Rows.Count > 0)
                {
                    cargarDataGrids(dsModificacionTC, gridModificacionTC);
                    cargarSubtotales(txtSubTotalModificacionTC, gridModificacionTC);
                    gbTransferencias.Visible = true;
                }
                else
                {
                    gbModificacion.Visible = false;
                }
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
           if (gridTransferencia.Rows.Count > 0 || gridModificacionTC.Rows.Count > 0 || cantidadSuscAPagar > 0)
           {
               DataSet ds = unaFactura.Cliente.TraerClientePorID(unCliente.cliente_id);
               unaFactura.Cliente.DataRowToObject(ds.Tables[0].Rows[0]);
               unaFactura.Fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);

               if (gridTransferencia.Rows.Count == 0) { cantidadTransferencias = 0; }
               else { cantidadTransferencias = gridTransferencia.Rows.Count - 1; } //me cuenta la ultima fila que esta vacia. por eso le resto uno}
               if (gridModificacionTC.Rows.Count == 0) { cantidadModificaciones = 0; }
               else { cantidadModificaciones = gridModificacionTC.Rows.Count - 1; }


               unCliente.cliente_id = Convert.ToInt64(cmbCliente.SelectedValue);
               Facturas frmFacturas = new Facturas();
               frmFacturas.AbrirCon(unaFactura, txtSubTotalTransferencia.Text, txtSubTotalModificacionTC.Text, subtotalSuscripciones, cantidadTransferencias, cantidadModificaciones, cantidadSuscAPagar);
               this.Close();
           }
           else
           {
               MessageBox.Show("No Existen Transacciones a Facturar.", "No se puede generar Factura");
           }
       }

       private void cmbCuenta_SelectedIndexChanged(object sender, EventArgs e)
       {
           //CANTIDAD SUSCRIPCIONES A PAGAR Y COSTO UNITARIO (PARA ESTA CUENTA)
           if (cmbCuenta.Items.Count > 0)
           {
               Int64 cuentaid = Convert.ToInt64(cmbCuenta.SelectedValue);
               DataSet dsSuscripciones = unCliente.TraerSuscripcionesPendientesAFacturarPorClienteIDYCuentaID(cuentaid);
               txtSuscripcionesPendientes.Text = unCliente.TraerCantidadSuscripcionesPendientesAFacturarPorClienteIDYCuentaID(cuentaid).ToString();
               if (dsSuscripciones.Tables[0].Rows.Count == 0)
               {
                   txtCostoUnitario.Text = "0";
               }else{
                   txtCostoUnitario.Text = (dsSuscripciones.Tables[0].Rows[0]["transaccion_pendiente_importe"]).ToString();
               };
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
                   cantidadSuscAPagar = cantidadSuscAPagar + Convert.ToInt64(txtSuscripcionesAPagar.Text);
                   subtotalSuscripciones = subtotalSuscripciones + Convert.ToDecimal(txtSubTotalSuscr.Text);

                   //una vez generada la factura se borran todas las transferencias y costos por modificacion asociados al cliente de la tabla Transacciones Pendientes
                   //Como se pueden pagar solo algunas suscripciones de la cuenta que querramos, tengo que decirle a la bd que suscripciones borrar
                   //Por lo tanto le voy a mandar a la base una tabla con las suscripciones a borrar.
                   //Detemerminamos que cuando se seleccionan X suscripciones de una cuenta se pagaran las mas antiguas. le mando a la base el cliente, la cuenta y la cantidad de suscripciones.
                   //ACA VOY CARGANDO LAS SUSCRIPCIONES A UNA VARIABLE TIPO TABLA. luego cuando en la pantalla Factura ponga aceptar le mando esta tabla.

                   unaFactura.tablaSuscripciones.Rows.Add(unaFactura.Cliente.cliente_id, Convert.ToInt64(cmbCuenta.SelectedValue), Convert.ToInt64(txtSuscripcionesAPagar.Text), Convert.ToDouble(txtCostoUnitario.Text));

               }
               txtSuscripcionesPendientes.Text = (Convert.ToInt64(txtSuscripcionesPendientes.Text) - Convert.ToInt64(txtSuscripcionesAPagar.Text)).ToString();
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
                DataSet dsClientes = unCliente.ObtenerTodosLosClientesConCosasAFacturar();
                ds = dsClientes;
            }
            else
            {
                DataSet dsClienteUsuario = unCliente.ObtenerClientesPorUsuarioIDSiFacturaAlgo(unUsuario.usuario_id);
                ds = dsClienteUsuario;
            }

            return ds;

        }

        public DataSet ObtenerCuentasAFacturarPorClienteId()
        {
            //cargar cmb Cuentas
            unaCuenta.Cliente.cliente_id = Convert.ToInt64(cmbCliente.SelectedValue);
            DataSet dsCuenta = unaCuenta.TraerCuentasACobrarPorClienteID();

            return dsCuenta;

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
                    strErrores = Validator.ValidarSuscripcionesCantidadMenor(txtSuscripcionesAPagar.Text, Convert.ToInt64(txtSuscripcionesPendientes.Text), "Suscripciones A Pagar");
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
            Int64 subtotal = 0;

            // Se recorre fila a fila para recalcular el total despues del cambio
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Se aumula el total de cada una de las filas columna 2 = Subtotal
                subtotal += Convert.ToInt64(row.Cells[2].Value);
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
