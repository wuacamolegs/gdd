using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;


namespace PagoElectronico.ABM_Cliente
{
    public partial class frmCliente : Form
    {
        public Cliente unCliente = new Cliente();

        public Usuario unUsuario = new Usuario();

        public frmCliente()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        #region botones

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ObtenerClientes();
            unCliente.Nombre = Convert.ToString(labelNombre);
            unCliente.Apellido = Convert.ToString(labelApellido);
            unCliente.TipoDocumento = Convert.ToString(cmbTipoDoc);
            unCliente.Documento = Convert.ToInt32(labelDNI);
            unCliente.Mail = Convert.ToString(labelMail);
            cargarGrilla();

        }

        public DataSet ObtenerClientes()
        {
            DataSet ds = unCliente.TraerListado("ConTodo");
            return ds;

        }

        private void cargarGrilla()
        {
            DataSet dsCliente = unCliente.TraerListado("ConTodo");
            //realizo la configuracion de la grilla, seteando las filas y columnas con sus nombres y valores

            //MessageBox.Show("cliente_id"+Convert.ToInt32(dsCliente.Tables[0].Rows[0]["cliente_id"]),"cliente_usuario_id"+Convert.ToInt32(dsCliente.Tables[0].Rows[0]["cliente_usuario_id"]));

            dtgClientes.Columns.Clear();
            dtgClientes.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clm_clienteID = new DataGridViewTextBoxColumn();
            clm_clienteID.Width = 40;
            clm_clienteID.ReadOnly = true;
            clm_clienteID.DataPropertyName = "cliente_id";
            clm_clienteID.HeaderText = "ID CLIENTE";
            dtgClientes.Columns.Add(clm_clienteID);

            DataGridViewTextBoxColumn clm_cliente_usuario_id = new DataGridViewTextBoxColumn();
            clm_cliente_usuario_id.Width = 40;
            clm_cliente_usuario_id.ReadOnly = true;
            clm_cliente_usuario_id.DataPropertyName = "cliente_usuario_id";
            clm_cliente_usuario_id.HeaderText = "USUARIO ID";
            dtgClientes.Columns.Add(clm_cliente_usuario_id);

            DataGridViewCheckBoxColumn clm_cliente_apellido = new DataGridViewCheckBoxColumn();
            clm_cliente_apellido.Width = 40;
            clm_cliente_apellido.ReadOnly = true;
            clm_cliente_apellido.DataPropertyName = "cliente_apellido";
            clm_cliente_apellido.HeaderText = "APELLIDO";
            dtgClientes.Columns.Add(clm_cliente_apellido);

            DataGridViewCheckBoxColumn clm_cliente_nombre = new DataGridViewCheckBoxColumn();
            clm_cliente_nombre.Width = 40;
            clm_cliente_nombre.ReadOnly = true;
            clm_cliente_nombre.DataPropertyName = "cliente_nombre";
            clm_cliente_nombre.HeaderText = "NOMBRE";
            dtgClientes.Columns.Add(clm_cliente_nombre);

            DataGridViewCheckBoxColumn clm_cliente_fecha_nacimiento = new DataGridViewCheckBoxColumn();
            clm_cliente_fecha_nacimiento.Width = 40;
            clm_cliente_fecha_nacimiento.ReadOnly = true;
            clm_cliente_fecha_nacimiento.DataPropertyName = "cliente_fecha_nacimiento";
            clm_cliente_fecha_nacimiento.HeaderText = "FECHA NACIMIENTO";
            dtgClientes.Columns.Add(clm_cliente_fecha_nacimiento);

            DataGridViewCheckBoxColumn clm_cliente_tipo_documento_id = new DataGridViewCheckBoxColumn();
            clm_cliente_tipo_documento_id.Width = 40;
            clm_cliente_tipo_documento_id.ReadOnly = true;
            clm_cliente_tipo_documento_id.DataPropertyName = "cliente_apellido";
            clm_cliente_tipo_documento_id.HeaderText = "APELLIDO";
            dtgClientes.Columns.Add(clm_cliente_tipo_documento_id);

            DataGridViewCheckBoxColumn clm_cliente_numero_documento = new DataGridViewCheckBoxColumn();
            clm_cliente_numero_documento.Width = 40;
            clm_cliente_numero_documento.ReadOnly = true;
            clm_cliente_numero_documento.DataPropertyName = "cliente_apellido";
            clm_cliente_numero_documento.HeaderText = "APELLIDO";
            dtgClientes.Columns.Add(clm_cliente_numero_documento);

            DataGridViewCheckBoxColumn clm_cliente_pais_residente_id = new DataGridViewCheckBoxColumn();
            clm_cliente_pais_residente_id.Width = 40;
            clm_cliente_pais_residente_id.ReadOnly = true;
            clm_cliente_pais_residente_id.DataPropertyName = "cliente_pais_residente_id";
            clm_cliente_pais_residente_id.HeaderText = "PAIS RESIDENTE ID";
            dtgClientes.Columns.Add(clm_cliente_pais_residente_id);

            DataGridViewCheckBoxColumn clm_cliente_calle = new DataGridViewCheckBoxColumn();
            clm_cliente_calle.Width = 40;
            clm_cliente_calle.ReadOnly = true;
            clm_cliente_calle.DataPropertyName = "cliente_calle";
            clm_cliente_calle.HeaderText = "CALLE";
            dtgClientes.Columns.Add(clm_cliente_calle);

            DataGridViewCheckBoxColumn clm_cliente_numero = new DataGridViewCheckBoxColumn();
            clm_cliente_numero.Width = 40;
            clm_cliente_numero.ReadOnly = true;
            clm_cliente_numero.DataPropertyName = "cliente_numero";
            clm_cliente_numero.HeaderText = "NUMERO";
            dtgClientes.Columns.Add(clm_cliente_numero);

            DataGridViewCheckBoxColumn clm_cliente_piso = new DataGridViewCheckBoxColumn();
            clm_cliente_piso.Width = 40;
            clm_cliente_piso.ReadOnly = true;
            clm_cliente_piso.DataPropertyName = "cliente_piso";
            clm_cliente_piso.HeaderText = "PISO";
            dtgClientes.Columns.Add(clm_cliente_piso);

            DataGridViewCheckBoxColumn clm_cliente_depto = new DataGridViewCheckBoxColumn();
            clm_cliente_depto.Width = 40;
            clm_cliente_depto.ReadOnly = true;
            clm_cliente_depto.DataPropertyName = "cliente_depto";
            clm_cliente_depto.HeaderText = "DEPTO";
            dtgClientes.Columns.Add(clm_cliente_depto);

            DataGridViewCheckBoxColumn clm_cliente_mail = new DataGridViewCheckBoxColumn();
            clm_cliente_mail.Width = 40;
            clm_cliente_mail.ReadOnly = true;
            clm_cliente_mail.DataPropertyName = "cliente_mail";
            clm_cliente_mail.HeaderText = "MAIL";
            dtgClientes.Columns.Add(clm_cliente_mail);

            //le inserto a la grilla el dataset obtenido
            dtgClientes.DataSource = dsCliente.Tables[0];

        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        public void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            txtMail.Clear();

        }

        #endregion

    }
}        
        
        
        
