﻿using System;
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
        public Usuario unUsuario = new Usuario();
        public Cliente unCliente;
        public Retiro retiroActual = new Retiro();
        public Cheque chequeActual = new Cheque();
        public Cuenta unaCuenta = new Cuenta();


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

            //cargar cmb banco
           Banco unBanco = new Banco();
           DataSet dsBancos = unBanco.ObtenerTodosLosBancos();
           DropDownListManager.CargarCombo(cmbBanco, dsBancos.Tables[0], "banco_id", "banco_nombre", false, "");
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {   
            //cargar cmb Cuentas
            DataSet dsCuentas = ObtenerCuentasActivasPorClienteId();
            DropDownListManager.CargarCombo(cmbCuenta, dsCuentas.Tables[0], "cuenta_numero", "cuenta_numero", false, "");

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (Convert.ToInt32(txtDocumento.Text) == unCliente.Documento)
                {
                    MessageBox.Show("Se ha validado correctamente la identidad del Cliente", "Validacion Exitosa");
                    
                    realizarAccionesRetiro();
                }
                else
                {
                    MessageBox.Show("Vuelva a ingresar el numero de documento", "Datos Incorrectos");
                }
            }
            MessageBox.Show("comprobando campos", "Datos Incorrectos");

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

        
        public DataSet ObtenerCuentasActivasPorClienteId()
        {
            int clienteID =  Convert.ToInt32(cmbCliente.SelectedValue);
            DataSet dsClientes = ObtenerClientePorID(clienteID);
            unCliente.DataRowToObject(dsClientes.Tables[0].Rows[0]);

            Cuenta unaCuenta = new Cuenta(unCliente, unUsuario);
            DataSet dsCuentas = unaCuenta.TraerCuentasActivasPorClienteID();
                               
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
                return false;
            }
            else
            {
                return true;
            }
            
        }

        private void realizarAccionesRetiro() 
        {
            int clienteID = Convert.ToInt32(cmbCliente.SelectedValue);
            DataSet dsCliente = unCliente.TraerClientePorID(clienteID);
            unCliente.DataRowToObject(dsCliente.Tables[0].Rows[0]);

             
            double cuentaID = Convert.ToDouble(cmbCuenta.SelectedValue);
            DataSet dsCuenta = unaCuenta.TraerCuentaPorCuentaID(cuentaID);
            unaCuenta.DataRowToObject(dsCuenta.Tables[0].Rows[0]);
            
            int importe = Convert.ToInt32(txtImporte.Text);
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

        private void cmbCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            double cuentaID = Convert.ToDouble(cmbCuenta.SelectedValue);
            DataSet dsCuenta = unaCuenta.TraerCuentaPorCuentaID(cuentaID);
            string saldo = Convert.ToString(dsCuenta.Tables[0].Rows[0]["cuenta_saldo"]);
            txtSaldoActual.Text = saldo;
        }


        private void generarRetiroExitoso()
        {
            chequeActual.banco.Banco_id = Convert.ToDouble(cmbBanco.SelectedValue);
            chequeActual.Cliente = unCliente;
            chequeActual.Cuenta = unaCuenta;
            chequeActual.Fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);
            chequeActual.Importe = Convert.ToInt32(txtImporte.Text);
            chequeActual.GenerarChequeDevolverSuID();

            retiroActual.Cheque = chequeActual;
            retiroActual.Cuenta = unaCuenta;
            retiroActual.Fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);
            retiroActual.Importe = Convert.ToInt32(txtImporte.Text);
            retiroActual.GenerarRetiroDevolverSuID();

            MessageBox.Show("Retiro generado exitosamente", "retiro exitoso");

        }


    }
}