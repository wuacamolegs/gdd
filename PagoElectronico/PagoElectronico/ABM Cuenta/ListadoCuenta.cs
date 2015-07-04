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
    public partial class ListadoCuenta : Form
    {
        #region variables
        public Usuario unUsuario = new Usuario();
        public Cliente unCliente = new Cliente();
        public Cuenta unaCuenta = new Cuenta();
      
        #endregion

        #region initialize

        public ListadoCuenta()
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

        private void ListadoCuenta_Load(object sender, EventArgs e)
        {

            //CARGAMOS GRILLA CON TODAS LAS CUENTAS QUE HAY.
            DataSet dsCuenta = ObtenerCuentas();
            cargarGrilla(dsCuenta);


            //CARGO CMB TIPO DNI
            DataSet ds = unCliente.TraerListado("TodosLosTiposDNI");
            DropDownListManager.CargarCombo(cmbTipoDNI, ds.Tables[0], "td_id", "td_descripcion", false, "");
            cmbTipoDNI.SelectedIndex = -1;
        }

        #endregion

       
        #region botones
        
        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                unaCuenta.Cliente.Nombre = Convert.ToString(txtNombre.Text);
                unaCuenta.Cliente.Apellido = Convert.ToString(txtApellido.Text);
                unaCuenta.Cliente.TipoDocumento = Convert.ToString(cmbTipoDNI.SelectedIndex);
                if (txtDNI.Text == "") {unaCuenta.Cliente.Documento = 0; } else { unaCuenta.Cliente.Documento = Convert.ToInt64(txtDNI.Text); }
                DataSet ds = unaCuenta.TraerCuentaPorFiltrosCliente();
                cargarGrilla(ds); //TODO: CUANDO GINO SUBA SUS CAMBIOS AGREGAR EN EL SP TRAERCUENTAFILTROS EL CLIENTE_ESTADO
            }

        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            cmbTipoDNI.SelectedIndex = 0;
            DataSet dsCuenta = ObtenerCuentas();
            cargarGrilla(dsCuenta);
        }


        #endregion

        #region llamados a la base 

        #endregion

        #region metodos privados

        private void cargarGrilla(DataSet dsCuenta)
        {
            //realizo la configuracion de la grilla, seteando las filas y columnas con sus nombres y valores

            gridCuentas.Columns.Clear();
            gridCuentas.AutoGenerateColumns = false;
            
            DataGridViewTextBoxColumn clm_cuentaID = new DataGridViewTextBoxColumn();
            clm_cuentaID.Width = 130;
            clm_cuentaID.ReadOnly = true;
            clm_cuentaID.DataPropertyName = "cuenta_id";
            clm_cuentaID.HeaderText = "Cuenta ID";
            gridCuentas.Columns.Add(clm_cuentaID);
            
            DataGridViewTextBoxColumn clm_clienteID = new DataGridViewTextBoxColumn();
            clm_clienteID.Width = 40;
            clm_clienteID.ReadOnly = true;
            clm_clienteID.DataPropertyName = "cliente_id";
            clm_clienteID.HeaderText = "Cliente ID";
            gridCuentas.Columns.Add(clm_clienteID);

            DataGridViewTextBoxColumn clm_cliente_nombre = new DataGridViewTextBoxColumn();
            clm_cliente_nombre.Width = 80;
            clm_cliente_nombre.ReadOnly = true;
            clm_cliente_nombre.DataPropertyName = "cliente_nombre";
            clm_cliente_nombre.HeaderText = "Titular";
            gridCuentas.Columns.Add(clm_cliente_nombre);

            DataGridViewTextBoxColumn clm_saldo = new DataGridViewTextBoxColumn();
            clm_saldo.Width = 80;
            clm_saldo.ReadOnly = true;
            clm_saldo.DataPropertyName = "cuenta_saldo";
            clm_saldo.HeaderText = "Saldo";
            gridCuentas.Columns.Add(clm_saldo);

            DataGridViewTextBoxColumn clm_tipoCuenta = new DataGridViewTextBoxColumn();
            clm_tipoCuenta.Width = 40;
            clm_tipoCuenta.ReadOnly = true;
            clm_tipoCuenta.DataPropertyName = "cuenta_tipo_cuenta_id";
            clm_tipoCuenta.HeaderText = "TipoCuenta";
            gridCuentas.Columns.Add(clm_tipoCuenta);

            DataGridViewTextBoxColumn clm_pais = new DataGridViewTextBoxColumn();
            clm_pais.Width = 40;
            clm_pais.ReadOnly = true;
            clm_pais.DataPropertyName = "cuenta_pais_id";
            clm_pais.HeaderText = "Pais";
            gridCuentas.Columns.Add(clm_pais);

            DataGridViewTextBoxColumn clm_moneda = new DataGridViewTextBoxColumn();
            clm_moneda.Width = 40;
            clm_moneda.ReadOnly = true;
            clm_moneda.DataPropertyName = "cuenta_moneda_id";
            clm_moneda.HeaderText = "Moneda";
            gridCuentas.Columns.Add(clm_moneda);

            DataGridViewTextBoxColumn clm_fecha_apertura = new DataGridViewTextBoxColumn();
            clm_fecha_apertura.Width = 80;
            clm_fecha_apertura.ReadOnly = true;
            clm_fecha_apertura.DataPropertyName = "cuenta_fecha_apertura";
            clm_fecha_apertura.HeaderText = "Apertura";
            gridCuentas.Columns.Add(clm_fecha_apertura);

            DataGridViewTextBoxColumn clm_fecha_cierre = new DataGridViewTextBoxColumn();
            clm_fecha_cierre.Width = 80;
            clm_fecha_cierre.ReadOnly = true;
            clm_fecha_cierre.DataPropertyName = "cuenta_fecha_cierre";
            clm_fecha_cierre.HeaderText = "Cierre";
            gridCuentas.Columns.Add(clm_fecha_cierre);

            DataGridViewCheckBoxColumn clm_Estado = new DataGridViewCheckBoxColumn();
            clm_Estado.Width = 80;
            clm_Estado.ReadOnly = true;
            clm_Estado.DataPropertyName = "cuenta_estado";
            clm_Estado.HeaderText = "Estado";
            gridCuentas.Columns.Add(clm_Estado);
            
            //le inserto a la grilla el dataset obtenido
            gridCuentas.DataSource = dsCuenta.Tables[0];

        }

        private DataSet ObtenerCuentas()
        {
            DataSet ds = new DataSet();
            if (unUsuario.Rol.rol_id == 1)
            {
                DataSet dsCuentas = unaCuenta.TraerListado("Completo");
                ds = dsCuentas;
            }
            else
            {
                DataSet dsCuentaUsuario = unaCuenta.ObtenerCuentasPorUsuarioID(unUsuario.usuario_id);
                ds = dsCuentaUsuario;
            }

            return ds;

        }

        private bool ValidarCampos()
        {
            if (txtDNI.Text != "") 
            { 
                Validator.EsNumero(txtDNI.Text); 
            }
            if (txtNombre.Text != "")
            {

            }
            if (txtApellido.Text != "")
            {

            }
            return true;
        }



        #endregion

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ABM_de_Cuenta abmCuenta = new ABM_de_Cuenta(unUsuario);
            //TODO CARGAR DATOS CUENTA
            unaCuenta.cuenta_id = Convert.ToInt64(((DataRowView)gridCuentas.CurrentRow.DataBoundItem)["cuenta_id"]);
            unaCuenta.Cliente.cliente_id = Convert.ToInt64(((DataRowView)gridCuentas.CurrentRow.DataBoundItem)["cliente_id"]);
            unaCuenta.tipoCuenta = Convert.ToInt64(((DataRowView)gridCuentas.CurrentRow.DataBoundItem)["cuenta_tipo_cuenta_id"]);
            unaCuenta.Pais = Convert.ToInt64(((DataRowView)gridCuentas.CurrentRow.DataBoundItem)["cuenta_pais_id"]);

            abmCuenta.AbrirParaModificar(unaCuenta);
            this.Hide();
            abmCuenta.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ABM_de_Cuenta abmCuenta = new ABM_de_Cuenta(unUsuario);
            abmCuenta.AbrirParaCrear();
            this.Hide();
            abmCuenta.Show();
        }

    }
}
