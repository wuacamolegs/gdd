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

        public ABM_de_Cuenta()
        {
            InitializeComponent();
            unCliente.Usuario = unUsuario;
            unaCuenta.Cliente = unCliente;
            //cargar combos moneda pais y tipo cuenta

            //Cargar Combo Moneda
            DataSet dsMoneda = unaMoneda.TraerTodasLasMonedas();
            DropDownListManager.CargarCombo(cmbMoneda, dsMoneda.Tables[0], "moneda_id", "moneda_nombre", false, "");

            //CargarCombo Paises
            DataSet dsPaises = unUsuario.TraerListado("PaisesCompleto");
            DropDownListManager.CargarCombo(cmbPais, dsPaises.Tables[0], "pais_id", "pais_descripcion", false, "");
        }

        private void ABM_de_Cuenta_Load(object sender, EventArgs e)
        {
            DataSet dsClientes = ObtenerClientes();
            DropDownListManager.CargarCombo(cmbCliente, dsClientes.Tables[0], "cliente_id", "cliente_nombre", false, "");
        }

        internal void AbrirParaModificar(DataSet dsCuenta, Cuenta cuenta)
        {
            unaCuenta = cuenta;
            unCliente.cliente_id = unaCuenta.Cliente.cliente_id;
            btnCrear.Visible = false;
            btnModificar.Visible = true;
        }

        internal void AbrirParaCrear()
        {
            btnModificar.Visible = false;
            btnCrear.Visible = true;
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

        #endregion  

        public DataSet ObtenerCuentasPorClienteID()
        {
            Int64 clienteID = Convert.ToInt64(cmbCliente.SelectedValue);
            DataSet dsCuentas = unaCuenta.TraerCuentasPorClienteID();
            return dsCuentas;
        }








    }
}
