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
            if (ValidarImporteNoVacio())
            {
                if (Convert.ToInt32(cmbCuentaOrigen.SelectedValue) == unaCuentaOrigen.cuenta_id &&
                    Convert.ToInt32(cmbCuentaDestino.SelectedValue) == unaCuentaDestino.cuenta_id)
                {
                    MessageBox.Show("Se ha validado correctamente las cuentas", "Validacion Exitosa");

                    realizarAccionesTransferencia();
                }
                else
                {
                    MessageBox.Show("Vuelva a seleccionar las cuentas", "Datos Incorrectos");
                }
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
            DataSet dsCuentas = unaCuenta.TraerCuentasActivasPorClienteID();
            return dsCuentas;
        }
        
        private bool ValidarImporteNoVacio()
        {
            string strErrores = "";
            strErrores = Validator.ValidarNulo(txtImporte.Text, "Importe");
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


            double cuentaOrigenID = Convert.ToDouble(cmbCuentaOrigen.SelectedValue);
            DataSet dsCuentaOrigen = unaCuentaOrigen.TraerCuentaPorCuentaID(cuentaOrigenID);
            unaCuentaOrigen.DataRowToObject(dsCuentaOrigen.Tables[0].Rows[0]);

            int clienteDestinoID = Convert.ToInt32(cmbClienteDestino.SelectedValue);
            DataSet dsClienteDestino = unClienteDestino.TraerClientePorID(clienteDestinoID);
            unClienteDestino.DataRowToObject(dsClienteDestino.Tables[0].Rows[0]);


            double cuentaDestinoID = Convert.ToDouble(cmbCuentaDestino.SelectedValue);
            DataSet dsCuentaDestino = unaCuentaDestino.TraerCuentaPorCuentaID(cuentaDestinoID);
            unaCuentaDestino.DataRowToObject(dsCuentaDestino.Tables[0].Rows[0]);

            int importe = Convert.ToInt32(txtImporte.Text);
            if (importe <= unaCuentaOrigen.saldo)
            {
                generarTransferenciaExitosa();
            }
            else
            {
                MessageBox.Show("No tiene suficiente saldo para realizar la Transferencia. Por favor, vuelva a ingresar el importe", "Saldo Insuficiente");
                txtImporte.Clear();
            }  
        }

        private void generarTransferenciaExitosa()
        {

            unaTransferencia.CuentaOrigen = Convert.ToDouble(cmbCuentaOrigen.SelectedValue);
            unaTransferencia.CuentaDestino = Convert.ToInt32(cmbCuentaDestino.SelectedValue);
            unaTransferencia.Importe = Convert.ToInt32(txtImporte.Text);
        
        }
     
     #endregion


    }
}
