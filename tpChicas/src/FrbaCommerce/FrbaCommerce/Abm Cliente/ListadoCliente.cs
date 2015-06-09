using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Conexion;
using Utilities;
using FrbaCommerce.Abm_Cliente;
using Excepciones;


namespace FrbaCommerce.Abm_Cliente
{
    public partial class listadoCliente : Form
    {
        public listadoCliente()
        {
            InitializeComponent();
        }
        private void listadoCliente_Load(object sender, EventArgs e)
        {
            CargarListadoDeClientes();
            cmbTipoDni.SelectedIndex = 0;
        }
        private void configurarGrilla(DataSet ds)
        {

            dtgListado.Columns.Clear();
            dtgListado.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmIdCliente = new DataGridViewTextBoxColumn();
            clmIdCliente.Width = 30;
            clmIdCliente.ReadOnly = true;
            clmIdCliente.DataPropertyName = "id_Cliente";
            clmIdCliente.HeaderText = "ID";
            dtgListado.Columns.Add(clmIdCliente);

            DataGridViewTextBoxColumn clmTipoDni = new DataGridViewTextBoxColumn();
            clmTipoDni.Width = 35;
            clmTipoDni.ReadOnly = true;
            clmTipoDni.DataPropertyName = "Tipo_Dni";
            clmTipoDni.HeaderText = "Tipo de Documento";
            dtgListado.Columns.Add(clmTipoDni);

            DataGridViewTextBoxColumn clmDni = new DataGridViewTextBoxColumn();
            clmDni.Width = 30;
            clmDni.ReadOnly = true;
            clmDni.DataPropertyName = "Dni";
            clmDni.HeaderText = "Dni";
            dtgListado.Columns.Add(clmDni);

            DataGridViewTextBoxColumn clmCuil = new DataGridViewTextBoxColumn();
            clmCuil.Width = 30;
            clmCuil.ReadOnly = true;
            clmCuil.DataPropertyName = "Cuil";
            clmCuil.HeaderText = "Cuil";
            dtgListado.Columns.Add(clmCuil);

            DataGridViewTextBoxColumn clmApellido = new DataGridViewTextBoxColumn();
            clmApellido.ReadOnly = true;
            clmApellido.DataPropertyName = "Apellido";
            clmApellido.HeaderText = "Apellido";
            dtgListado.Columns.Add(clmApellido);

            DataGridViewTextBoxColumn clmNombre = new DataGridViewTextBoxColumn();
            clmNombre.ReadOnly = true;
            clmNombre.DataPropertyName = "Nombre";
            clmNombre.HeaderText = "Nombre";
            dtgListado.Columns.Add(clmNombre);

            DataGridViewTextBoxColumn clmFechaNac = new DataGridViewTextBoxColumn();
            clmFechaNac.Width = 80;
            clmFechaNac.ReadOnly = true;
            clmFechaNac.DataPropertyName = "Fecha_nac";
            clmFechaNac.HeaderText = "Fecha de Nacimiento";
            dtgListado.Columns.Add(clmFechaNac);

            DataGridViewTextBoxColumn clmMail = new DataGridViewTextBoxColumn();
            clmMail.ReadOnly = true;
            clmMail.DataPropertyName = "Mail";
            clmMail.HeaderText = "Mail";
            dtgListado.Columns.Add(clmMail);

            DataGridViewTextBoxColumn clmTelefono = new DataGridViewTextBoxColumn();
            clmTelefono.ReadOnly = true;
            clmTelefono.DataPropertyName = "Telefono";
            clmTelefono.HeaderText = "Teléfono";
            dtgListado.Columns.Add(clmTelefono);

            DataGridViewTextBoxColumn clmDireccion = new DataGridViewTextBoxColumn();
            clmDireccion.Width = 80;
            clmDireccion.ReadOnly = true;
            clmDireccion.DataPropertyName = "Direccion";
            clmDireccion.HeaderText = "Dirección";
            dtgListado.Columns.Add(clmDireccion);

            DataGridViewTextBoxColumn clmCiudad = new DataGridViewTextBoxColumn();
            clmCiudad.ReadOnly = true;
            clmCiudad.DataPropertyName = "Dom_ciudad";
            clmCiudad.HeaderText = "Ciudad";
            dtgListado.Columns.Add(clmCiudad);

            DataGridViewTextBoxColumn clmCodigoPostal = new DataGridViewTextBoxColumn();
            clmCodigoPostal.ReadOnly = true;
            clmCodigoPostal.DataPropertyName = "Dom_cod_postal";
            clmCodigoPostal.HeaderText = "Código Postal";
            dtgListado.Columns.Add(clmCodigoPostal);

            DataGridViewCheckBoxColumn clmActivo = new DataGridViewCheckBoxColumn();
            clmActivo.Width = 60;
            clmActivo.ReadOnly = true;
            clmActivo.DataPropertyName = "Activo";
            clmActivo.HeaderText = "Activo";
            dtgListado.Columns.Add(clmActivo);

            dtgListado.DataSource = ds.Tables[0];
            dtgListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void CargarListadoDeClientes()
        {
            try
            {
                DataSet ds = Cliente.obtenerTodosLosClientes();
                configurarGrilla(ds);
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void CargarListadoDeClientesConFiltros()
        {

            try
            {
                DataSet ds = Cliente.obtenerTodosLosClientesConFiltros(txtNombre.Text, txtApellido.Text, cmbTipoDni.Text, Convert.ToInt32(txtDni.Text), txtMail.Text);
                configurarGrilla(ds);
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ValidarFiltros();
            CargarListadoDeClientesConFiltros();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtMail.Text = "";
            txtDni.Text = "";
            CargarListadoDeClientes();
        }
        
        private int valorIdSeleccionado()
        {
            // devuelve el id_cliente del Cliente seleccionaod en la grilla
            return Convert.ToInt32(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["id_Cliente"]);
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            frmCliente _frmCliente = new frmCliente();
            // instancio un nuevo cliente con el id_cleinte del Cliente seleccionado en la grilla
            // a traves del cual voy a cargar todos los atributos del Cliente
            Cliente unCliente = new Cliente(valorIdSeleccionado());
            unCliente.CargarObjetoClienteConId();
            _frmCliente.AbrirParaVer(unCliente, this);
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmCliente _frmCliente = new frmCliente();
            // instancio un nuevo cliente con el id_cleinte del Cliente seleccionado en la grilla
            // a traves del cual voy a cargar todos los atributos del Cliente
            Cliente unCliente = new Cliente(valorIdSeleccionado());
            unCliente.CargarObjetoClienteConId();
            _frmCliente.AbrirParaModificar(unCliente, this);
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Está seguro que desea dar de baja el Cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Cliente unCliente = new Cliente(valorIdSeleccionado());
                unCliente.Eliminar();
                MessageBox.Show("El Cliente ha sido eliminada", "Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListadoDeClientes();
            }
        }
        private void btnAlta_Click(object sender, EventArgs e)
        {
            frmCliente _frmCliente = new frmCliente();
            _frmCliente.AbrirParaAgregar(this);
        }
        private void ValidarFiltros()
        {
            if (txtDni.Text != "") { Validator.EsNumero(txtDni.Text); }
             
        }

    }
}
