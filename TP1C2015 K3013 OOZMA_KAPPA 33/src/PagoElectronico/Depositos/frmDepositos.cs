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
        public Cliente unCliente = new Cliente();
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

        private void frmDepositos_Load(object sender, EventArgs e)
        {
            unCliente.Usuario = unUsuario;
            depositoActual.Cliente = unCliente;
            depositoActual.Cuenta = unaCuenta;
            unaTarjeta.Cliente = unCliente;
            unaCuenta.Cliente = unCliente;
            depositoActual.Tarjeta = unaTarjeta;

            DataSet dsClientes = ObtenerClientes();
            DropDownListManager.CargarCombo(cmbCliente, dsClientes.Tables[0], "cliente_id", "cliente_nombre", false, "");

            DataSet dsMoneda = unaMoneda.TraerTodasLasMonedas();
            DropDownListManager.CargarCombo(cmbMoneda, dsMoneda.Tables[0], "id_Moneda", "Moneda", false, "");
            cmbMoneda.SelectedIndex = -1;

        }


        #endregion

        #region Botones
        private void ComboCliente_SelectedIndexChanged(object sender, EventArgs e)
        { 
            //cargar CMB cuenta
            unaCuenta.Cliente.cliente_id = Convert.ToInt64 (cmbCliente.SelectedValue) ;
            DataSet dsCuenta = unaCuenta.TraerCuentasActivasPorClienteID();
            if (dsCuenta.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("El Cliente no posee Cuentas Activas. Por favor ingrese otro Cliente", "No hay Cuentas Activas");
                cmbMoneda.SelectedIndex = -1;
            }
            else
            {
                DropDownListManager.CargarCombo(cmbCuenta, dsCuenta.Tables[0], "cuenta_numero", "cuenta_numero", false, "");

                //Cargar CMB Tarjeta
                unaTarjeta.Cliente.cliente_id = Convert.ToInt64(cmbCliente.SelectedValue);
                DataSet dsTarjetas = unaTarjeta.ObtenerTarjetasPorClienteiD();
                if (dsTarjetas.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("El Cliente no posee Tarjetas Activas. Por favor ingrese otro Cliente", "No hay Tarjetas Activas");
                    cmbCuenta.SelectedIndex = -1;
                    cmbMoneda.SelectedIndex = -1;
                }
                else
                {
                    DropDownListManager.CargarCombo(cmbTarjeta, dsTarjetas.Tables[0], "tarjeta_numero", "tarjeta_numero", false, "");
                    cmbCuenta.SelectedIndex = -1;
                    cmbMoneda.SelectedIndex = -1;
                    cmbTarjeta.SelectedIndex = -1;
                }
            }

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
                depositoActual.Moneda = Convert.ToInt64(cmbMoneda.SelectedValue);
                depositoActual.EfectuarDeposito();
                MessageBox.Show("DEPOSITO EXITOSO DE: " + depositoActual.Importe +"\nCliente: " + depositoActual.Cliente.cliente_id + "\nCuenta: " + depositoActual.Cuenta.cuenta_id + "\nTarjeta: " + depositoActual.Tarjeta.tarjeta_id, "Deposito Exitoso");
                this.Close();
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
                strErrores = strErrores + Validator.SoloNumerosODecimales(txtImporte.Text, "Importe");
                if (strErrores.Length > 0)
                {
                    MessageBox.Show(strErrores);
                    txtImporte.Clear();
                    return false;

                }
                else
                {
                    strErrores = strErrores + Validator.MayorACero(txtImporte.Text, "Importe");
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
            }
        }



        #endregion



    }
}
