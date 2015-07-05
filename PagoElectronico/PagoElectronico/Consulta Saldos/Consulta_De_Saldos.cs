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

namespace PagoElectronico.Consulta_Saldos
{
    public partial class Consulta_De_Saldos : Form
    {
        #region variables

        public Usuario unUsuario = new Usuario();
        public Cliente unCliente = new Cliente();
        public Cuenta unaCuenta = new Cuenta();

        #endregion

        #region initialize

        public Consulta_De_Saldos()
        {
            InitializeComponent();
        }
     
        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            unCliente.Usuario = user;
            unaCuenta.Cliente = unCliente;
            this.Show();
        }

        private void Consulta_De_Saldos_Load(object sender, EventArgs e)
        {
            DataSet dsClientes = ObtenerClientes();
            DropDownListManager.CargarCombo(cmbCliente, dsClientes.Tables[0], "cliente_id", "cliente_nombre", false, "");
           
        }

        
        
        
        #endregion

        #region botones y vistas

        
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargar CMB cuenta
            unaCuenta.Cliente.cliente_id = Convert.ToInt64(cmbCliente.SelectedValue);
            DataSet dsCuenta = unaCuenta.TraerCuentasActivasPorClienteID();
            DropDownListManager.CargarCombo(cmbCuenta, dsCuenta.Tables[0], "cuenta_numero", "cuenta_numero", false, "");

        }


        #endregion

        #region llamados a la base
        #endregion

        #region metodos privados

        private DataSet ObtenerClientes()
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

        private void cmbCuenta_SelectedIndexChanged(object sender, EventArgs e){
 
            Int64 cuentaID = Convert.ToInt64(cmbCuenta.SelectedValue);
            DataSet dsCuenta = unaCuenta.TraerCuentaPorCuentaID(cuentaID);
            unaCuenta.DataRowToObject(dsCuenta.Tables[0].Rows[0]);
            txtSaldo.Clear();
            string saldo = Convert.ToString(unaCuenta.saldo);
            txtSaldo.Text = saldo;

        }



    }
}
