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
using FrbaCommerce.Abm_Empresa;
using Excepciones;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class listadoEmpresa : Form
    {
        public listadoEmpresa()
        {
            InitializeComponent();
        }

        private void listadoEmpresa_Load(object sender, EventArgs e)
        {
            CargarListadoDeEmpresas();
        }
        private void configurarGrilla(DataSet ds)
        {

            dtgListado.Columns.Clear();
            dtgListado.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmIdEmpresa = new DataGridViewTextBoxColumn();
            clmIdEmpresa.Width = 30;
            clmIdEmpresa.ReadOnly = true;
            clmIdEmpresa.DataPropertyName = "id_Empresa";
            clmIdEmpresa.HeaderText = "ID";
            dtgListado.Columns.Add(clmIdEmpresa);

            DataGridViewTextBoxColumn clmRazonSocial = new DataGridViewTextBoxColumn();
            clmRazonSocial.Width = 30;
            clmRazonSocial.ReadOnly = true;
            clmRazonSocial.DataPropertyName = "Razon_social";
            clmRazonSocial.HeaderText = "Razón Social";
            dtgListado.Columns.Add(clmRazonSocial);

            DataGridViewTextBoxColumn clmCuit = new DataGridViewTextBoxColumn();
            clmCuit.ReadOnly = true;
            clmCuit.DataPropertyName = "Cuit";
            clmCuit.HeaderText = "Cuit";
            dtgListado.Columns.Add(clmCuit);

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

            DataGridViewTextBoxColumn clmNombreDeContacto = new DataGridViewTextBoxColumn();
            clmNombreDeContacto.ReadOnly = true;
            clmNombreDeContacto.DataPropertyName = "Nombre_contacto";
            clmNombreDeContacto.HeaderText = "Nombre de Contacto";
            dtgListado.Columns.Add(clmNombreDeContacto);

            DataGridViewTextBoxColumn clmFechaDeCreacion = new DataGridViewTextBoxColumn();
            clmFechaDeCreacion.ReadOnly = true;
            clmFechaDeCreacion.DataPropertyName = "Fecha_creacion";
            clmFechaDeCreacion.HeaderText = "Fecha de Creación";
            dtgListado.Columns.Add(clmFechaDeCreacion);

            DataGridViewCheckBoxColumn clmActivo = new DataGridViewCheckBoxColumn();
            clmActivo.Width = 60;
            clmActivo.ReadOnly = true;
            clmActivo.DataPropertyName = "Activo";
            clmActivo.HeaderText = "Activo";
            dtgListado.Columns.Add(clmActivo);

            dtgListado.DataSource = ds.Tables[0];
            dtgListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void CargarListadoDeEmpresas()
        {
            try
            {
                DataSet ds = Empresa.obtenerTodasLasEmpresas();
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
        public void CargarListadoDeEmpresasConFiltros()
        {
            try
            {
                DataSet ds = Empresa.obtenerTodasLasEmpresasConFiltros(txtRazonSocial.Text, txtCuit.Text, txtMail.Text);
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
            CargarListadoDeEmpresasConFiltros();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //libio los textBox y cargo la grilla Sin filtros
            txtRazonSocial.Text = "";
            txtCuit.Text = "";
            txtMail.Text = "";
            CargarListadoDeEmpresas();
        }

        private int valorIdSeleccionado()
        {
            //devuelve el Id de la Empresa seleccionada en la grilla
            return Convert.ToInt32(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["id_Empresa"]);
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            frmEmpresa _frmEmpresa = new frmEmpresa();
            // instancio una nueva Empresa con el id_empresa seleccionado en la grilla
            // con el cual puedo cargar todos los atributos de la Empresa
            Empresa unaEmpresa = new Empresa(valorIdSeleccionado());
            unaEmpresa.CargarObjetoEmpresaConId();
            _frmEmpresa.AbrirParaVer(unaEmpresa, this);
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmEmpresa _frmEmpresa = new frmEmpresa();
            // instancio una nueva Empresa con el id_empresa seleccionado en la grilla
            // con el cual puedo cargar todos los atributos de la Empresa
            Empresa unaEmpresa = new Empresa(valorIdSeleccionado());
            unaEmpresa.CargarObjetoEmpresaConId();
            _frmEmpresa.AbrirParaModificar(unaEmpresa, this);
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Está seguro que desea dar de baja la empresa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Empresa unaEmpresa = new Empresa(valorIdSeleccionado());
                unaEmpresa.Eliminar();
                MessageBox.Show("La empresa ha sido eliminada", "Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //actualizo la grilla
                CargarListadoDeEmpresas();
            }
        }
        private void btnAlta_Click(object sender, EventArgs e)
        {
            frmEmpresa _frmEmpresa = new frmEmpresa();
            _frmEmpresa.AbrirParaAgregar(this);
        }
    


    }
}
