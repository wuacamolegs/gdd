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

        internal void AbrirParaCrear()
        {
            btnModificar.Visible = false;
            btnCrear.Visible = true;
            txtCliente.Visible = false;

            unaCuenta.Cliente = unCliente;

            DataSet dsClientes = ObtenerClientes();
            DropDownListManager.CargarCombo(cmbCliente, dsClientes.Tables[0], "cliente_id", "cliente_nombre", false, "");

            //Traigo el supuesto cuentaID que se le va a asignar
            DataSet dsProxCuenta = SQLHelper.ExecuteDataSet("TraerProximaCuentaID");
            txtCuenta.Text = dsProxCuenta.Tables[0].Rows[0]["proxID"].ToString();

            cargarDatos();
            cmbTipoCuenta.SelectedIndex = -1;
            cmbPais.SelectedIndex = -1;
            cmbMoneda.SelectedIndex = -1;
        }

        internal void AbrirParaModificar(Cuenta cuenta)
        {
            cmbCliente.Visible = false;
            btnCrear.Visible = false;
            btnModificar.Visible = true;
            txtCliente.Visible = true;

            //MOSTRAR CLIENTE CUENTA A MODIFICAR
            unaCuenta = cuenta;
            unaCuenta.Cliente = unCliente;
            unCliente.cliente_id = unaCuenta.Cliente.cliente_id;
            txtCliente.Text = unaCuenta.Cliente.Nombre;

            //MOSTRAR CUENTA A MODIFICAR
            DataSet ds = unaCuenta.TraerCuentaPorCuentaID(unaCuenta.cuenta_id);
            unaCuenta.DataRowToObjectCompleto(ds.Tables[0].Rows[0]);
            txtCuenta.Text = unaCuenta.cuenta_id.ToString();

            cargarDatos();

            //que los combos muestren los datos de la cuenta
            cmbTipoCuenta.SelectedValue = Convert.ToInt32(unaCuenta.tipoCuenta);
            cmbPais.SelectedValue = Convert.ToInt32(unaCuenta.Pais);
            cmbMoneda.SelectedValue = Convert.ToInt32(unaCuenta.Moneda);

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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            unaCuenta.Cliente.cliente_id = unCliente.cliente_id;
            unaCuenta.cuenta_id = Convert.ToInt64(txtCuenta.Text);

             //VERIFICAR QUE NO TIENE SUSCRIPCIONES PENDIENTES AL TIPO CUENTA ANTERIOR. 
            //COMO SE AUTOFACTURA LA COMISION POR APERTURA CUENTA Y MODIFICACION CUENTA CADA VEZ QUE LE HAGO LA FACTURACION,
            //SI LLEGA A TENER PAGADAS AL MENOS UNA SUSCRIPCION SIGNIFICA QUE TAMBIEN FACTURO LA APERTURA/MODIFICACION CUENTA.
            //POR LO QUE NO HACE FALTA QUE ME FIJE SI PAGO LA COMISION POR APERTURA/MODIFIACION.

            Int64 cantidadSuscripcionesAPagar = unCliente.TraerCantidadSuscripcionesPendientesAFacturarPorClienteIDYCuentaID(unaCuenta.cuenta_id);
            
            //Si llega a cambiar el tipo cuenta me tengo  que fijar que no tengas suscripciones pendientes. Si las tiene no puede modificar el tipo cuenta!!
            if (cantidadSuscripcionesAPagar > 0 && unaCuenta.tipoCuenta != Convert.ToInt64(cmbTipoCuenta.SelectedValue))
            {
                MessageBox.Show("La Cuenta: " + unaCuenta.cuenta_id + "Posee saldos pendientes a pagar. Elija otra cuenta", "No se puede Modificar TipoCuenta");
                this.Close();
            }
            else
            {
                bindToUnaCuenta();
                unaCuenta.UpdateCuenta();
                MessageBox.Show("Se modificó correctamente la cuenta: " + unaCuenta.cuenta_id, "Modificación exitosa!");
                this.Close();
            }

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                unaCuenta.Cliente.cliente_id = Convert.ToInt64(cmbCliente.SelectedValue);
                bindToUnaCuenta();
                unaCuenta.InsertCuenta();
                MessageBox.Show("Se creó correctamente la Cuenta: " + txtCuenta.Text + "\nPais: " + cmbPais.Text + "\nMoneda: " + cmbMoneda.Text + "\nTipo Cuenta: " + cmbTipoCuenta.Text, "Nueva Cuenta");
                this.Close();
            }
        }


        #endregion
        
        #region llamados base

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
            unaCuenta.Cliente.cliente_id = clienteID;
            DataSet dsCuentas = unaCuenta.TraerCuentasPorClienteID();
            return dsCuentas;
        }

        #endregion

        #region metodos privados

        private void bindToUnaCuenta()
        {
            unaCuenta.Moneda = Convert.ToInt64(cmbMoneda.SelectedValue);
            unaCuenta.Pais = Convert.ToInt64(cmbPais.SelectedValue);
            unaCuenta.tipoCuenta = Convert.ToInt64(cmbTipoCuenta.SelectedValue);
        }

        private bool ValidarCampos()
        {
            if (cmbPais.SelectedIndex == -1) 
            {
                MessageBox.Show("Debe seleccionar un pais", "Datos Faltantes");
                return false;
            }

            if (cmbMoneda.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una moneda", "Datos Faltantes");
                return false;
            }

            if (cmbTipoCuenta.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de cuenta", "Datos Faltantes");
                return false;
            }
            return true;
        }

        #endregion  



    }
}
