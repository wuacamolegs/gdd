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
            DropDownListManager.CargarCombo(cmbClienteDestino, dsClienteDestino.Tables[0], "cliente_id", "cliente_nombre", false, ""); 

            
        }
 
        private void cmbClienteOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargar CuentasClienteOrigen
            unClienteOrigen.cliente_id = Convert.ToInt32(cmbClienteOrigen.SelectedValue);
            DataSet dsCuentaOrigen = traerCuentasPorCliente(unClienteOrigen);
            DropDownListManager.CargarCombo(cmbCuentaOrigen, dsCuentaOrigen.Tables[0], "cuenta_numero", "cuenta_numero", false, ""); 
        }

        private void cmbClienteDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargar CuentasClienteDestino
            unClienteDestino.cliente_id = Convert.ToInt32(cmbClienteDestino.SelectedValue);
            DataSet dsCuentaDestino = traerCuentasPorCliente(unClienteDestino);
            DropDownListManager.CargarCombo(cmbCuentaDestino, dsCuentaDestino.Tables[0], "cuenta_numero", "cuenta_numero", false, ""); 
        }

        private void cmbCuentaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            unaCuentaOrigen.cuenta_id = Convert.ToInt64(cmbCuentaOrigen.SelectedValue);
            DataSet dsCuentaOrigen = unaCuentaOrigen.TraerCuentaPorCuentaID(unaCuentaOrigen.cuenta_id);
            txtSaldo.Clear();
            string saldo = Convert.ToString(dsCuentaOrigen.Tables[0].Rows[0]["cuenta_saldo"]);
            txtSaldo.Text = saldo;
        }



        private void btnConfirmar_Click(object sender, EventArgs e)
        {


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
            strErrores = strErrores + Validator.ValidarSaldoCantidadMenor(txtImporte.Text, Convert.ToInt32(txtSaldo.Text), "Importe");
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

            Int64 cuentaDestinoID = Convert.ToInt64(cmbCuentaDestino.SelectedValue);
            DataSet dsCuentaDestino = unaCuentaDestino.TraerCuentaPorCuentaID(cuentaDestinoID);
            unaCuentaDestino.DataRowToObject(dsCuentaDestino.Tables[0].Rows[0]);

            unaTransferencia.CuentaOrigen = unaCuentaOrigen;
            unaTransferencia.CuentaDestino = unaCuentaDestino;
            
            generarTransferenciaExitosa();
        }

        private void generarTransferenciaExitosa()
        {
            unaTransferencia.CuentaOrigen.cuenta_id = Convert.ToInt64(cmbCuentaOrigen.SelectedValue);
            unaTransferencia.CuentaDestino.cuenta_id = Convert.ToInt64(cmbCuentaDestino.SelectedValue);
            unaTransferencia.Importe = Convert.ToInt32(txtImporte.Text);
            unaTransferencia.Fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);

            unaTransferencia.GenerarTransferencia();
            txtSaldo.Clear();
            this.Hide();
        }
     
     #endregion






    }
}
