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
            unClienteOrigen.Usuario = unUsuario;
            unaTransferencia.CuentaOrigen = unaCuentaOrigen;
            unaTransferencia.CuentaDestino = unaCuentaDestino;
            this.Show();
        }


     

        #region botones

        private void Transferencias_Entre_Cuentas_Load(object sender, EventArgs e)
        {
            //cargar cmbClienteOrigen
            DataSet dsClienteOrigen = this.ObtenerClientes();
            DropDownListManager.CargarCombo(cmbClienteOrigen, dsClienteOrigen.Tables[0], "cliente_id", "cliente_nombre", false, "");

                       
        }
 
        private void cmbClienteOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargar CuentasClienteOrigen
            unClienteOrigen.cliente_id = Convert.ToInt64(cmbClienteOrigen.SelectedValue);
            DataSet dsCuentaOrigen = traerCuentasPorCliente(unClienteOrigen);
            DropDownListManager.CargarCombo(cmbCuentaOrigen, dsCuentaOrigen.Tables[0], "cuenta_numero", "cuenta_numero", false, "");

        }

        private void cmbCuentaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int64 cuentaID = Convert.ToInt64(cmbCuentaOrigen.SelectedValue);
            DataSet dsCuentaOrigen = unaCuentaOrigen.TraerCuentaPorCuentaID(cuentaID);
            unaCuentaOrigen.DataRowToObject(dsCuentaOrigen.Tables[0].Rows[0]);
            txtSaldo.Clear();
            string saldo = Convert.ToString(unaCuentaOrigen.saldo);
            txtSaldo.Text = saldo;
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
                {
                   
                    realizarAccionesTransferencia();
                    
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
            DataSet dsCuentas = unaCuenta.TraerCuentasAbiertasPorClienteID();
            return dsCuentas;
        }

        private bool ValidarCampos()
        {
            if (txtCuentaDestino.Text == "") { MessageBox.Show("Debe ingresar una Cuenta", "Datos Faltantes"); txtImporte.Text = ""; return false; }
            else
            {
                string strerrorescuentadestino = "";
                strerrorescuentadestino = strerrorescuentadestino + Validator.SoloNumeros(txtCuentaDestino.Text, "Cuenta Destino");
                if (strerrorescuentadestino.Length > 0)
                {
                    MessageBox.Show(strerrorescuentadestino);
                    return false;
                }
                else
                {

                    unaCuentaDestino.cuenta_id = Convert.ToInt64(txtCuentaDestino.Text);
                    if (unaCuentaDestino.validarCuentaDestino())
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
                                    Int64 Importe = Convert.ToInt64(txtImporte.Text);
                                    Int64 Saldo = Convert.ToInt64(txtSaldo.Text);
                                    if (Importe <= Saldo)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se ha realizado la transferencia ya que no cuenta con suficiente saldo", "Saldo insuficiente");
                                        return false;
                                    }


                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cuenta de destino que ingreso es inexistente", "Cuenta inexistente");
                        txtCuentaDestino.Clear();
                        return false;
                    }
                }
            }
        }


        private void realizarAccionesTransferencia()
        {
            if (Convert.ToInt64(txtCuentaDestino.Text) == Convert.ToInt64(cmbCuentaOrigen.SelectedValue))
            {
                MessageBox.Show("No se puede realizar una transferencia entre mismas cuentas. Seleccione otra Cuenta", "Cuenta Incorrecta");
                txtImporte.Clear();

            }
            else
            {
                Int64 clienteOrigenID = Convert.ToInt64(cmbClienteOrigen.SelectedValue);
                DataSet dsClienteOrigen = unClienteOrigen.TraerClientePorID(clienteOrigenID);
                unClienteOrigen.DataRowToObject(dsClienteOrigen.Tables[0].Rows[0]);

               
                Int64 cuentaDestinoID = Convert.ToInt64(txtCuentaDestino.Text);
                DataSet dsCuentaDestino = unaCuentaDestino.TraerCuentaPorCuentaID(cuentaDestinoID);
                unaCuentaDestino.DataRowToObject(dsCuentaDestino.Tables[0].Rows[0]);

                Int64 cuentaOrigenID = Convert.ToInt64(cmbCuentaOrigen.SelectedValue);
                DataSet dsCuentaOrigen = unaCuentaOrigen.TraerCuentaPorCuentaID(cuentaOrigenID);
                unaCuentaOrigen.DataRowToObject(dsCuentaOrigen.Tables[0].Rows[0]);


                unaTransferencia.CuentaOrigen = unaCuentaOrigen;
                unaTransferencia.CuentaDestino = unaCuentaDestino;

                generarTransferenciaExitosa();
            }
        }

        private void generarTransferenciaExitosa()
        {
            unaTransferencia.CuentaOrigen.cuenta_id = Convert.ToInt64(cmbCuentaOrigen.SelectedValue);
            unaTransferencia.CuentaDestino.cuenta_id = Convert.ToInt64(txtCuentaDestino.Text);
            unaTransferencia.Importe = Convert.ToInt64(txtImporte.Text);
            unaTransferencia.Fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);

            unaTransferencia.GenerarTransferencia();
            MessageBox.Show("TRANSFERENCIA EXITOSA!\nCuenta Origen: " + unaTransferencia.CuentaOrigen.cuenta_id + "\nCuenta Destino: " + unaTransferencia.CuentaDestino.cuenta_id + "\nImporte: " + unaTransferencia.Importe + "\nFecha: " + unaTransferencia.Fecha, "Validacion Exitosa");
            txtSaldo.Clear();
            this.Hide();
        
        
        }
     
     #endregion







    }
}
