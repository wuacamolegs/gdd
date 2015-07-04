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
      
        #region Atributos

        public Usuario unUsuario = new Usuario();
        public Cliente unCliente;
        public Deposito depositoActual = new Deposito();
        public Tarjeta unaTarjeta = new Tarjeta();
        public Cuenta unaCuenta = new Cuenta();
        public Moneda unaMoneda = new Moneda();

        #endregion 
        
        #region Initialize
        public frmDepositos()
        {
            InitializeComponent();
        }


        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        private void Depositos_Load(object sender, EventArgs e)
        { 
            DataSet dsClientes = ObtenerClientes();
            DropDownListManager.CargarCombo(cmbCliente, dsClientes.Tables[0], "cliente_id", "cliente_nombre", false, "");
            DataSet dsMoneda = unaMoneda.TraerTodasLasMonedas();
            DropDownListManager.CargarCombo(cmbMoneda, dsMoneda.Tables[0], "moneda_id", "moneda_nombre", false, "");

        }

        #endregion

        #region Botones
        private void ComboCliente_SelectedIndexChanged(object sender, EventArgs e)
        { 
            //cargar CMB cuenta

            unaCuenta.Cliente.cliente_id = Convert.ToInt64 (cmbCliente.SelectedValue) ;
            DataSet dsCuenta = unaCuenta.TraerCuentasActivasPorClienteID();
            DropDownListManager.CargarCombo(cmbCuenta, dsCuenta.Tables[0], "cuenta_id", "cuenta_id", false, "");

            //Cargar CMB Tarjeta
            unaTarjeta.Cliente.cliente_id = Convert.ToInt64(cmbCliente.SelectedValue);
            DataSet dsTarjetas = unaTarjeta.ObtenerTarjetasPorClienteiD();
            DropDownListManager.CargarCombo(cmbTarjeta, dsTarjetas.Tables[0], "tarjeta_id", "tarjeta_id", false, "");

        }


        //ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                depositoActual.Cliente.cliente_id = Convert.ToInt64(cmbCliente.SelectedValue);
                depositoActual.Cuenta.cuenta_id = Convert.ToInt64(cmbCuenta.SelectedValue);
                depositoActual.Tarjeta.tarjeta_id = Convert.ToInt64(cmbTarjeta.SelectedValue);
                depositoActual.Importe = Convert.ToInt64(txtImporte.Text);
                depositoActual.EfectuarDeposito();


            }

        }

        #endregion

        #region Metodos Privados
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
        
            
        //Validar Importe no nulo, mayor a cero y tipo de dato correcto
        private bool ValidarCampos()
        {
            string errores = "";
            errores = Validator.ValidarNulo(txtImporte.Text, "Importe");
            errores = errores + Validator.SoloNumerosODecimales(txtImporte.Text, "Importe");
            errores = errores + Validator.MayorACero(txtImporte.Text, "Importe");
            if (errores.Length > 0)
            {
                MessageBox.Show(errores);
                txtImporte.Clear();
                return false;
            }
            else
            {
                return true;
            }

        }



        #endregion

    }
}
