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
using System.Data.SqlClient;
using Conexion;

namespace PagoElectronico.Listados
{
    public partial class Listado_Estadistico : Form
    {
        #region variables
        Usuario unUsuario = new Usuario();
        List<SqlParameter> parameterList = new List<SqlParameter>();
        //instancio variables donde se van a guardar todos los datos que van a ser enviados a los store procedures
        private DateTime Fecha_Hasta;
        private DateTime Fecha_Desde;
        private string Año;

        #endregion

        #region initialize

        public Listado_Estadistico()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        #endregion

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (cmbTrimestre.SelectedIndex == 0) cargarParametrosPrimerTrimestre();
                if (cmbTrimestre.SelectedIndex == 1) cargarParametrosSegundoTrimestre();
                if (cmbTrimestre.SelectedIndex == 2) cargarParametrosTercerTrimestre();
                if (cmbTrimestre.SelectedIndex == 3) cargarParametrosCuartoTrimestre();

                Año = txtAño.Text;

                setearListaDeParametrosConFechas();
                
                if (cmbListado.SelectedIndex == 0)
                {
                    cargarListadoClientesCuentasDeshabilitadasPorPendientesDeActivacion();
                }
                if (cmbListado.SelectedIndex == 1)
                {
                    cargarListadoClientesConMayorCantidadDeComisionesFacturadasEnTodasSusCuentas();
                }
                if (cmbListado.SelectedIndex == 2)
                {
                    cargarListadoClientesConMayorCantidadDeTransaccionesRealizadasEntreCuentasPropias();
                }
                if (cmbListado.SelectedIndex == 3)
                {
                    cargarListadoPaisesConMayorCantidadDeMovimientosTantoIngresosComoEgresos();
                }
                if (cmbListado.SelectedIndex == 4)
                {
                    cargarListadoTotalFacturadoParaLosDistintosTiposDeCuentas();
                }
            }
        }

        private void cargarListadoTotalFacturadoParaLosDistintosTiposDeCuentas()
        {
            //cuenta_tipo_cuenta_id TotalFacturado
            DataSet ds1 = SQLHelper.ExecuteDataSet("TraerListadoListadoTotalFacturadoParaLosDistintosTiposDeCuentas", CommandType.StoredProcedure, parameterList);
            cargarGrillaConTipoCuentaYCantidad(ds1);
        }

        private void cargarGrillaConTipoCuentaYCantidad(DataSet ds)
        {
            gridListados.Columns.Clear();
            gridListados.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmTipoCuenta = new DataGridViewTextBoxColumn();
            clmTipoCuenta.Width = 120;
            clmTipoCuenta.ReadOnly = true;
            clmTipoCuenta.DataPropertyName = "cuenta_tipo_cuenta_id";
            clmTipoCuenta.HeaderText = "TIPO CUENTA";
            gridListados.Columns.Add(clmTipoCuenta);

            DataGridViewTextBoxColumn clmFacturado = new DataGridViewTextBoxColumn();
            clmFacturado.Width = 200;
            clmFacturado.ReadOnly = true;
            clmFacturado.DataPropertyName = "TotalFacturado";
            clmFacturado.HeaderText = "TOTAL FACTURADO";
            gridListados.Columns.Add(clmFacturado);

            gridListados.DataSource = ds.Tables[0];
        }

        private void cargarListadoPaisesConMayorCantidadDeMovimientosTantoIngresosComoEgresos()
        {
            DataSet ds2 = SQLHelper.ExecuteDataSet("TraerListadoPaisesConMayorCantidadDeMovimientosTantoIngresosComoEgresos", CommandType.StoredProcedure, parameterList);
            cargarGrillaConPaisesYCantidad(ds2);
        }

        private void cargarGrillaConPaisesYCantidad(DataSet ds)
        {
            gridListados.Columns.Clear();
            gridListados.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmPais = new DataGridViewTextBoxColumn();
            clmPais.Width = 120;
            clmPais.ReadOnly = true;
            clmPais.DataPropertyName = "pais_descripcion";
            clmPais.HeaderText = "PAIS";
            gridListados.Columns.Add(clmPais);

            DataGridViewTextBoxColumn clmCantidad = new DataGridViewTextBoxColumn();
            clmCantidad.Width = 200;
            clmCantidad.ReadOnly = true;
            clmCantidad.DataPropertyName = "cantidad_movimientos";
            clmCantidad.HeaderText = "CANTIDAD MOVIMIENTOS";
            gridListados.Columns.Add(clmCantidad);

            gridListados.DataSource = ds.Tables[0];
        }


        private void cargarListadoClientesConMayorCantidadDeTransaccionesRealizadasEntreCuentasPropias()
        {
            DataSet ds3 = SQLHelper.ExecuteDataSet("TraerListadoClientesConMayorCantidadDeTransaccionesRealizadasEntreCuentasPropias", CommandType.StoredProcedure, parameterList);
            cargarGrillaConClienteYCantidad(ds3);
        }

        private void cargarGrillaConClienteYCantidad(DataSet ds)
        {
            gridListados.Columns.Clear();
            gridListados.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmCliente = new DataGridViewTextBoxColumn();
            clmCliente.Width = 120;
            clmCliente.ReadOnly = true;
            clmCliente.DataPropertyName = "cliente_nombre";
            clmCliente.HeaderText = "CLIENTE";
            gridListados.Columns.Add(clmCliente);

            DataGridViewTextBoxColumn clmCantidad = new DataGridViewTextBoxColumn();
            clmCantidad.Width = 200;
            clmCantidad.ReadOnly = true;
            clmCantidad.DataPropertyName = "Cantidad";
            clmCantidad.HeaderText = "CANTIDAD";
            gridListados.Columns.Add(clmCantidad);

            gridListados.DataSource = ds.Tables[0];
        }


        private void cargarListadoClientesConMayorCantidadDeComisionesFacturadasEnTodasSusCuentas()
        {
            DataSet ds4 = SQLHelper.ExecuteDataSet("TraerListadoClientesConMayorCantidadDeComisionesFacturadasEnTodasSusCuentas", CommandType.StoredProcedure, parameterList);
            cargarGrillaConClienteYCantidad(ds4);
        }

        private void cargarListadoClientesCuentasDeshabilitadasPorPendientesDeActivacion()
        {
            DataSet ds5 = SQLHelper.ExecuteDataSet("TraerListadoClientesCuentasDeshabilitadasPorPendientesDeActivacion", CommandType.StoredProcedure, parameterList);
            cargarGrillaConClienteNombreYCuentas(ds5);
        }

        private void cargarGrillaConClienteNombreYCuentas(DataSet ds)
        {
            gridListados.Columns.Clear();
            gridListados.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmCliente = new DataGridViewTextBoxColumn();
            clmCliente.Width = 120;
            clmCliente.ReadOnly = true;
            clmCliente.DataPropertyName = "cliente_nombre";
            clmCliente.HeaderText = "CLIENTE";
            gridListados.Columns.Add(clmCliente);

            DataGridViewTextBoxColumn clmCuenta = new DataGridViewTextBoxColumn();
            clmCuenta.Width = 200;
            clmCuenta.ReadOnly = true;
            clmCuenta.DataPropertyName = "cuenta_id";
            clmCuenta.HeaderText = "CUENTAS";
            gridListados.Columns.Add(clmCuenta);

            gridListados.DataSource = ds.Tables[0];
        }

        private bool ValidarCampos()
        {
            string strErrores = "";
            strErrores += Validator.ValidarNulo(txtAño.Text, "Año");
            strErrores += Validator.SoloNumeros(txtAño.Text, "Año");
            strErrores += Validator.EsAño(txtAño.Text, "Año");
            if (strErrores.Length > 0)
            {
                MessageBox.Show(strErrores, "Errores");
                return false;
            }
            else { return true; }
        }

        private void setearListaDeParametrosConFechas()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@FechaDES", Fecha_Desde));
            parameterList.Add(new SqlParameter("@FechaHAS", Fecha_Hasta));
        }

        private void cargarParametrosCuartoTrimestre()
        {
            Fecha_Desde = new DateTime(Convert.ToInt32(Año), 10, 1);
            Fecha_Hasta = new DateTime(Convert.ToInt32(Año), 12, 31);
        }

        private void cargarParametrosSegundoTrimestre()
        {
            Fecha_Desde = new DateTime(Convert.ToInt32(Año), 04, 1);
            Fecha_Hasta = new DateTime(Convert.ToInt32(Año), 06, 30);
        }

        private void cargarParametrosTercerTrimestre()
        {
            Fecha_Desde = new DateTime(Convert.ToInt32(Año), 07, 1);
            Fecha_Hasta = new DateTime(Convert.ToInt32(Año), 09, 30);
        }

        private void cargarParametrosPrimerTrimestre()
        {
            Fecha_Desde = new DateTime(Convert.ToInt32(Año), 01, 1);
            Fecha_Hasta = new DateTime(Convert.ToInt32(Año), 03, 31);
        }


    }
}
