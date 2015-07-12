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


namespace PagoElectronico.Retiros
{
    public partial class Retiro_Efectivo : Form
    {
        #region atributos
        public Usuario unUsuario = new Usuario();
        public Cliente unCliente = new Cliente();
        public Retiro retiroActual = new Retiro();
        public Cheque chequeActual = new Cheque();
        public Cuenta unaCuenta = new Cuenta();
        #endregion

        #region inicialize

        public Retiro_Efectivo()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            unCliente.Usuario = user;
            unaCuenta.Cliente = unCliente;
            chequeActual.Cliente = unCliente;
            retiroActual.Cuenta = unaCuenta;
            chequeActual.Cuenta = unaCuenta;
            retiroActual.Cheque = chequeActual;
            this.Show();
        }

        private void Retiro_Efectivo_Load(object sender, EventArgs e)
        {
            //cargar cmb Clientes
            DataSet dsClientes = ObtenerClientes();
            if (dsClientes.Tables[0].Rows.Count > 0)
            {
                DropDownListManager.CargarCombo(cmbCliente, dsClientes.Tables[0], "cliente_id", "cliente_nombre", false, "");
            }

            //cargar cmb banco
            Banco unBanco = new Banco();
            DataSet dsBancos = unBanco.ObtenerTodosLosBancos();
            DropDownListManager.CargarCombo(cmbBanco, dsBancos.Tables[0], "banco_id", "banco_nombre", false, "");
            cmbBanco.SelectedIndex = -1;
        }


        #endregion 

        #region botones

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            unCliente.TraerClientePorID(Convert.ToInt64(cmbCliente.SelectedValue));
            if (ValidarCampos())
            {
                if (Convert.ToInt64(txtDocumento.Text) == unCliente.Documento)
                {                    
                    realizarAccionesRetiro();
                    actualizarSaldo();
                    cmbBanco.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Vuelva a ingresar el numero de documento", "Validacion Incorrecta");
                }
            }
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargar cmb Cuentas
            unaCuenta.Cliente.cliente_id = Convert.ToInt64(cmbCliente.SelectedValue);
            DataSet dsCuenta = unaCuenta.TraerCuentasActivasPorClienteID();
            if (dsCuenta.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("El Cliente no posee Cuentas Activas. Por favor seleccione otro Cliente", "No hay Cuentas Activas");
                cmbBanco.SelectedIndex = -1;
            }
            else
            {
                DropDownListManager.CargarCombo(cmbCuenta, dsCuenta.Tables[0], "cuenta_numero", "cuenta_numero", false, "");
            }
        }

        private void cmbCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarSaldo();
        }

        private void actualizarSaldo() 
        {
            Int64 cuentaID = Convert.ToInt64(cmbCuenta.SelectedValue);
            DataSet dsCuenta = unaCuenta.TraerCuentaPorCuentaID(cuentaID);
            unaCuenta.DataRowToObject(dsCuenta.Tables[0].Rows[0]);
            txtSaldoActual.Clear();
            string saldo = unaCuenta.saldo.ToString();
            txtSaldoActual.Text = saldo;   
        }

        #endregion

        #region llamados a la base

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
        
        #region metodos privados

        private bool ValidarCampos()
        {
            string strErrores = "";
            strErrores = Validator.ValidarNulo(txtDocumento.Text, "Documento");
            strErrores = strErrores + Validator.ValidarNulo(txtImporte.Text, "Importe");

            if (strErrores.Length > 0)
            {
                MessageBox.Show(strErrores);
                txtDocumento.Clear();
                txtImporte.Clear();
                return false;
            }
            else
            {
                strErrores = strErrores + Validator.SoloNumeros(txtDocumento.Text, "Documento");
                strErrores = strErrores + Validator.SoloNumerosODecimales(txtImporte.Text, "Importe");
                if (strErrores.Length > 0)
                {
                    MessageBox.Show(strErrores);
                    txtDocumento.Clear();
                    txtImporte.Clear();
                    return false;

                }
                else
                {
                    strErrores = strErrores + Validator.MayorACero(txtImporte.Text, "Importe");
                    strErrores = strErrores + Validator.MayorACero(txtDocumento.Text, "Documento");
                    if (strErrores.Length > 0)
                    {
                        MessageBox.Show(strErrores);
                        txtDocumento.Clear();
                        txtImporte.Clear();
                        return false;
                    }
                    else
                    {
                        if (cmbBanco.SelectedIndex == -1)
                        {
                            MessageBox.Show("Debe seleccionar un Banco", "Banco Erroneo");
                            return false;
                        }
                        else { return true; }
                    }
                }
            }
        }

        private void realizarAccionesRetiro() 
        {
            Int64 clienteID = Convert.ToInt64(cmbCliente.SelectedValue);
            DataSet dsCliente = unCliente.TraerClientePorID(clienteID);
            unCliente.DataRowToObject(dsCliente.Tables[0].Rows[0]);

             
            Int64 cuentaID = Convert.ToInt64(cmbCuenta.SelectedValue);
            DataSet dsCuenta = unaCuenta.TraerCuentaPorCuentaID(cuentaID);
            unaCuenta.DataRowToObject(dsCuenta.Tables[0].Rows[0]);
            
            Int64 importe = Convert.ToInt64(txtImporte.Text);
            if (importe <= unaCuenta.saldo)
            {
                generarRetiroExitoso();
            }
            else 
            {
                MessageBox.Show("No tiene suficiente saldo para realizar el Retiro. Por favor, vuelva a ingresar el importe", "Saldo Insuficiente");
                txtImporte.Clear();
            }        
        }


        private void generarRetiroExitoso()
        {
            chequeActual.banco.Banco_id = Convert.ToInt64(cmbBanco.SelectedValue);
            chequeActual.Cliente = unCliente;
            chequeActual.Cuenta = unaCuenta;
            chequeActual.Fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);
            chequeActual.Importe = Convert.ToInt64(txtImporte.Text);
            chequeActual.GenerarChequeDevolverSuID();

            retiroActual.Cheque = chequeActual;
            retiroActual.Cuenta = unaCuenta;
            retiroActual.Fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);
            retiroActual.Importe = Convert.ToInt64(txtImporte.Text);
            retiroActual.GenerarRetiroDevolverSuID();
            MessageBox.Show("RETIRO GENERADO EXITOSAMENTE!\nNumero Cheque: " + chequeActual.Cheque_id + "\nCuenta ID: " + unaCuenta.cuenta_id + "\nFecha: " + retiroActual.Fecha + "\nImporte " + retiroActual.Importe, "Retiro Exitoso" );

         
            txtImporte.Clear();
            txtDocumento.Clear();

        }
        #endregion

    }
}
