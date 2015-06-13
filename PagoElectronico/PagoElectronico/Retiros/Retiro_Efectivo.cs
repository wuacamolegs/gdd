using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Utilities;


namespace PagoElectronico.Retiros
{
    public partial class Retiro_Efectivo : Form
    {
        public Usuario unUsuario = new Usuario();
        public Cliente unCliente;


        public Retiro_Efectivo()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            unCliente = new Cliente(unUsuario);
            this.Show();
        }

        #region botones

        private void Retiro_Efectivo_Load(object sender, EventArgs e)
        {
            
            //cargar cmb Clientes
           DataSet dsClientes = ObtenerClientes();
           DropDownListManager.CargarCombo(cmbCliente, dsClientes.Tables[0], "cliente_id", "cliente_nombre", false, "");

        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {   
            //cargar cmb Cuentas
            DataSet dsCuentas = ObtenerCuentasPorClienteId();
            DropDownListManager.CargarCombo(cmbCuenta, dsCuentas.Tables[0], "cuenta_saldo", "cuenta_numero", false, "");

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (Convert.ToInt32(txtDocumento.Text) == unCliente.Documento)
                {
                    MessageBox.Show("Se ha validado correctamente la identidad del Cliente", "Validacion Exitosa");
                    //TODO: CHEQUEAR SALDO > IMPORTE, Y LAS DEMAS VALIDACIONES.
                    realizarAccionesRetiroExitoso();
                }
                else
                {
                    MessageBox.Show("Vuelva a ingresar el numero de documento", "Datos Incorrectos");
                }
            }

        }

        #endregion
        
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
            int clienteID =  Convert.ToInt32(cmbCliente.SelectedValue);
            DataSet dsClientes = ObtenerClientePorID(clienteID);
            unCliente.DataRowToObject(dsClientes.Tables[0].Rows[0]);

            Cuenta unaCuenta = new Cuenta(unCliente, unUsuario);
            DataSet dsCuentas = unaCuenta.TraerCuentasPorClienteID();
                                 
            return dsCuentas;

        }

        public DataSet ObtenerClientePorID(int clienteID)
        {
            DataSet dsCliente = unCliente.TraerClientePorID(clienteID);
            return dsCliente;
            
        }

        private bool ValidarCampos()
        {
            string strErrores = "";
            strErrores = Validator.ValidarNulo(txtDocumento.Text, "Documento");
            strErrores =  strErrores + Validator.ValidarNulo(txtImporte.Text, "Importe");
            if (strErrores.Length > 0)
            {
                MessageBox.Show(strErrores);
                txtDocumento.Clear();
                txtImporte.Clear();
                return true;
            }
            return false;
        }

        private void realizarAccionesRetiroExitoso() { }

        
    }
}
