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
using Conexion;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class ABM_de_Cuenta : Form
    {
        #region variables

        Cliente unCliente = new Cliente();
        Usuario unUsuario = new Usuario();
        Cuenta unaCuenta = new Cuenta();
        Moneda unaMoneda = new Moneda();

        #endregion

        #region initialize

        public ABM_de_Cuenta(Usuario user)
        {
            InitializeComponent();
            unUsuario = user;
        }

        internal void AbrirParaCrear() //TODO tengo que entrar con el user
        {
            btnModificar.Visible = false;
            btnCrear.Visible = true;
            txtCliente.Visible = false;

            DataSet dsClientes = ObtenerClientes();
            DropDownListManager.CargarCombo(cmbCliente, dsClientes.Tables[0], "cliente_id", "cliente_nombre", false, "");
            cargarDatos();
        }

        internal void AbrirParaModificar(Cuenta cuenta)
        {
            cmbCliente.Visible = false;
            btnCrear.Visible = false;
            btnModificar.Visible = true;
            txtCliente.Visible = true;

            //MOSTRAR CLIENTE CUENTA A MODIFICAR
            unaCuenta = cuenta;
            unCliente.cliente_id = unaCuenta.Cliente.cliente_id;
            txtCliente.Text = unaCuenta.Cliente.Nombre;

            //MOSTRAR CUENTA A MODIFICAR
            DataSet ds = unaCuenta.TraerCuentaPorCuentaID(unaCuenta.cuenta_id);
            DropDownListManager.CargarCombo(cmbCuenta,ds.Tables[0], "cuenta_id", "cuenta_id", false, "");

            cargarDatos();

            //que los combos muestren los datos de la cuenta
            cmbTipoCuenta.SelectedIndex = Convert.ToInt32(unaCuenta.tipoCuenta) - 1;
            cmbPais.SelectedIndex = Convert.ToInt32(unaCuenta.Pais) - 1;
            cmbMoneda.SelectedIndex = Convert.ToInt32(unaCuenta.Moneda) - 1;

        }

        private void cargarDatos()
        {
            //Cargar Combo Moneda
            DataSet dsMoneda = unaMoneda.TraerTodasLasMonedas();
            DropDownListManager.CargarCombo(cmbMoneda, dsMoneda.Tables[0], "id_Moneda", "Moneda", false, "");

            //Cargar Combo Paises
            DataSet dsPaises = SQLHelper.ExecuteDataSet("traerListadoPaisesCompleto");
            DropDownListManager.CargarCombo(cmbPais, dsPaises.Tables[0], "pais_id", "pais_nombre", false, "");

            //Cargar Compo tipo Cuenta
            DataSet dsTipoCuenta = SQLHelper.ExecuteDataSet("traerListadoTipoCuentaCompleto");
            DropDownListManager.CargarCombo(cmbTipoCuenta, dsTipoCuenta.Tables[0], "tipo_cuenta_id", "tipo_cuenta_nombre", false, "");
        }

        #endregion

        #region botones, vista



        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargar cmb Cuentas
            DataSet dsCuentas = ObtenerCuentasPorClienteID();
            DropDownListManager.CargarCombo(cmbCuenta, dsCuentas.Tables[0], "cuenta_numero", "cuenta_numero", false, "");
        }

        #endregion
        
        #region llamados base

        #endregion

        #region metodos privados

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

        public DataSet ObtenerCuentasPorClienteID()
        {
            Int64 clienteID = Convert.ToInt64(cmbCliente.SelectedValue);
            DataSet dsCuentas = unaCuenta.TraerCuentasPorClienteID();
            return dsCuentas;
        }

        #endregion  

        private void btnModificar_Click(object sender, EventArgs e)
        {
            unaCuenta.Cliente.cliente_id = unCliente.cliente_id;
            unaCuenta.cuenta_id = Convert.ToInt64(cmbCuenta.SelectedValue);
            bindToUnaCuenta();
            unaCuenta.UpdateCuenta();

        }

        private void bindToUnaCuenta()
        {
            unaCuenta.Moneda = Convert.ToInt64(cmbMoneda.SelectedValue);
            unaCuenta.Pais = Convert.ToInt64(cmbPais.SelectedValue);
            unaCuenta.tipoCuenta = Convert.ToInt64(cmbTipoCuenta.SelectedValue);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            unaCuenta.Cliente.cliente_id = Convert.ToInt64(cmbCliente.SelectedValue);
            bindToUnaCuenta();
            unaCuenta.InsertCuenta();
        }

    }
}
