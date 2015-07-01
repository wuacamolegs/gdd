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

namespace PagoElectronico.Transferencias
{
    public partial class Transferencias_Entre_Cuentas : Form
    {
        public Usuario unUsuario = new Usuario();

        public Cliente unClienteOrigen = new Cliente();

        public Cliente unClienteDestino = new Cliente();
         
        public Cuenta unaCuentaOrigen = new Cuenta();

        public Cuenta unaCuentaDestino = new Cuenta();

        public Transferencia unaTransferencia = new Transferencia();



        public Transferencias_Entre_Cuentas()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }


     

        #region botones

        private void Transferencias_Entre_Cuentas_Load(object sender, EventArgs e)
        {
            //cargar cmbClienteOrigen
            DataSet dsClienteOrigen = this.ObtenerClientes();
            DropDownListManager.CargarCombo(cmbClienteOrigen, dsClienteOrigen.Tables[0], "cliente_id", "cliente_nombre", false, "");

            //cargar cmbClienteDestino
            DataSet dsClienteDestino = unClienteOrigen.ObtenerTodosLosClientes(unUsuario.usuario_id);
            DropDownListManager.CargarCombo(cmbClienteOrigen, dsClienteDestino.Tables[0], "cliente_id", "cliente_nombre", false, ""); 

            
        }
 
        private void cmbClienteOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargar CuentasClienteOrigen
            DataSet ds = traerCuentasPorCliente(unClienteOrigen);

        }

        private void cmbClienteDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargar CuentasClienteDestino
            DataSet ds = traerCuentasPorCliente(unClienteDestino);
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DataSet ds = unaCuentaOrigen.TraerCuentaPorCuentaID(Convert.ToDouble(cmbCuentaOrigen.SelectedValue));
            unaCuentaOrigen.DataRowToObject(ds.Tables[0].Rows[0]);

            if (ValidarCampos())
            
                
                {
                    MessageBox.Show("Transaccion Exitosa", "Validacion Exitosa");

                    realizarAccionesTransferencia();
                }
                       
        }

        #endregion

     #region funciones

        public DataSet ObtenerClientes()
        {

            DataSet ds = new DataSet();
            if (unUsuario.Rol.rol_id == 1)
            {
                DataSet dsClientes = unClienteOrigen.ObtenerTodosLosClientes(unUsuario.usuario_id);
                ds = dsClientes;
            }
            else
            {
                DataSet dsClienteUsuario = unClienteOrigen.ObtenerClientesPorUsuarioID(unUsuario.usuario_id);
                ds = dsClienteUsuario;
            }

            return ds;

        }
        
        public DataSet traerCuentasPorCliente(Cliente unCliente)
        {
            Cuenta unaCuenta = new Cuenta(unCliente, unUsuario);
            DataSet dsCuentas = unaCuenta.TraerCuentasAbiertasPorClienteID();
            return dsCuentas;
        }
        
        private bool ValidarCampos()
        {
            string strErrores = "";
            strErrores = Validator.ValidarNulo(txtImporte.Text, "Importe");
            strErrores = strErrores + Validator.MayorACero(txtImporte.Text, "Importe");
            strErrores = strErrores + Validator.ValidarSaldoCantidadMenor(txtImporte.Text, unaCuentaOrigen.saldo, "Importe");
            if (strErrores.Length > 0)
            {
                MessageBox.Show(strErrores);
                txtImporte.Clear();
                return false;
            }
            else
            {
                return true;
            }

        }

        private void realizarAccionesTransferencia()
        {
            int clienteOrigenID = Convert.ToInt32(cmbClienteOrigen.SelectedValue);
            DataSet dsClienteOrigen = unClienteOrigen.TraerClientePorID(clienteOrigenID);
            unClienteOrigen.DataRowToObject(dsClienteOrigen.Tables[0].Rows[0]);

            int clienteDestinoID = Convert.ToInt32(cmbClienteDestino.SelectedValue);
            DataSet dsClienteDestino = unClienteDestino.TraerClientePorID(clienteDestinoID);
            unClienteDestino.DataRowToObject(dsClienteDestino.Tables[0].Rows[0]);

            double cuentaDestinoID = Convert.ToDouble(cmbCuentaDestino.SelectedValue);
            DataSet dsCuentaDestino = unaCuentaDestino.TraerCuentaPorCuentaID(cuentaDestinoID);
            unaCuentaDestino.DataRowToObject(dsCuentaDestino.Tables[0].Rows[0]);

            generarTransferenciaExitosa();
        }

        private void generarTransferenciaExitosa()
        {
            unaTransferencia.CuentaOrigen.cuenta_id = Convert.ToDouble(cmbCuentaOrigen.SelectedValue);
            unaTransferencia.CuentaDestino.cuenta_id = Convert.ToInt32(cmbCuentaDestino.SelectedValue);
            unaTransferencia.Importe = Convert.ToInt32(txtImporte.Text);
            unaTransferencia.Fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);

            unaTransferencia.GenerarTransferencia();
        }
     
     #endregion



    }
}
