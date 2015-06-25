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

namespace PagoElectronico.Depositos
{
    public partial class frmDepositos : Form
    {
        public frmDepositos()
        {
            InitializeComponent();
        }

       
        public Usuario unUsuario = new Usuario();
        public Cliente unCliente;
        public Deposito depositoActual = new Deposito();
        public Tarjeta unaTarjeta = new Tarjeta();
        public Cuenta unaCuenta = new Cuenta();
        

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        private void Depositos_Load(object sender, EventArgs e)
        { 
            DataSet dsClientes = ObtenerClientes();
            DropDownListManager.CargarCombo(cmbCliente, dsClientes.Tables[0], "cliente_id", "cliente_nombre", false, "");
        }

        private void ComboCliente_SelectedIndexChanged(object sender, EventArgs e)
        { 
            //cargar CMB cuenta

            unaCuenta.cliente.cliente_id = Convert.ToInt32 (cmbCliente.SelectedValue) ;
            DataSet dsCuenta = unaCuenta.TraerCuentasActivasPorClienteID();
            DropDownListManager.CargarCombo(cmbCuenta, dsCuenta.Tables[0], "cuenta_id", "cuenta_id", false, "");

            //Cargar CMB Tarjeta
            unaTarjeta.Cliente = Convert.ToInt32

        }

        

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

        public DataSet ObtenerCuentasActivasPorClienteId()
        {
            unCliente.cliente_id = Convert.ToInt32(cmbCliente.SelectedValue);
            DataSet dsClientes = unCliente.TraerClientePorID(unCliente.cliente_id);
            unCliente.DataRowToObject(dsClientes.Tables[0].Rows[0]);

            Cuenta unaCuenta = new Cuenta(unCliente, unUsuario);
            DataSet dsCuentas = unaCuenta.TraerCuentasActivasPorClienteID();

            return dsCuentas;

        }
               


        
        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        { 
            //CMBMONEDA SOLO PERMITE DOLARES
            cmbMoneda.Items.Add("DOLARES");
        }

       //ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }
        
       
            
        //VALIDAR TARJETA NO VENCIDA
        private bool ValidarCampos()
        {
            string strErrores = "";
            strErrores = strErrores + Validator.ValidarNulo(txtImporte.Text, "Importe");
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

        
        //HACER DEPOSITO
        private void realizarAccionesDeposito()
        {
            
        }

        //HACER DEPOSITO
        private void generarDepositoExitoso()
        {
         
            
        }

   

    }
}
