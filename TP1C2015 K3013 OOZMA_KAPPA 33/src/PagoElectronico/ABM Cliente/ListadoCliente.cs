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
using Conexion;
using Excepciones;


namespace PagoElectronico.ABM_Cliente
{
    public partial class ListadoCliente : Form
    {
        #region variables

        public Cliente unCliente = new Cliente();

        public Usuario unUsuario = new Usuario();


        #endregion

        #region initialize

        public ListadoCliente()
        {
            InitializeComponent();
        }


        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }
        #endregion

        #region botones y vista

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                unCliente.Nombre = Convert.ToString(txtNombre.Text);
                unCliente.Apellido = Convert.ToString(txtApellido.Text);
                unCliente.TipoDocumento = Convert.ToString(cmbTipoDoc.SelectedIndex);
                unCliente.Mail = Convert.ToString(txtMail.Text);
                if (txtDNI.Text == "") { unCliente.Documento = 0; } else { unCliente.Documento = Convert.ToInt64(txtDNI.Text); }
                CargarListadoDeClientesConFiltros();
            }


        }


        private bool ValidarCampos()
        {
            string strerrores = "";
            if (txtDNI.Text != "")
            {
                strerrores = Validator.SoloNumeros(txtDNI.Text, "DNI");
                if (strerrores.Length > 0)
                {
                    MessageBox.Show(strerrores, "Campos Erroneos");
                    txtDNI.Text = "";
                    return false;
                }
                else { return true; }
            }
            else { return true; }
        }


        public void CargarListadoDeClientesConFiltros()
        {
            try
            {
                DataSet ds = unCliente.obtenerTodosLosClientesConFiltros(txtNombre.Text, txtApellido.Text, Convert.ToInt32(cmbTipoDoc.SelectedValue), txtDNI.Text, txtMail.Text);
                cargarGrilla(ds);
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

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            cmbTipoDoc.SelectedIndex = -1;
            DataSet dsCliente = unCliente.TraerListado("ConTodo");
            cargarGrilla(dsCliente);
        }

        private void cargarGrilla(DataSet dsCliente)
        {
            
            //realizo la configuracion de la grilla, seteando las filas y columnas con sus nombres y valores
            dtgClientes.Columns.Clear();
            dtgClientes.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clm_clienteID = new DataGridViewTextBoxColumn();
            clm_clienteID.Width = 80;
            clm_clienteID.ReadOnly = true;
            clm_clienteID.DataPropertyName = "cliente_id";
            clm_clienteID.HeaderText = "ID";
            dtgClientes.Columns.Add(clm_clienteID);

            DataGridViewTextBoxColumn clm_cliente_nombre = new DataGridViewTextBoxColumn();
            clm_cliente_nombre.Width = 80;
            clm_cliente_nombre.ReadOnly = true;
            clm_cliente_nombre.DataPropertyName = "cliente_nombre";
            clm_cliente_nombre.HeaderText = "Nombre";
            dtgClientes.Columns.Add(clm_cliente_nombre);

            DataGridViewTextBoxColumn clm_cliente_apellido = new DataGridViewTextBoxColumn();
            clm_cliente_apellido.Width = 80;
            clm_cliente_apellido.ReadOnly = true;
            clm_cliente_apellido.DataPropertyName = "cliente_apellido";
            clm_cliente_apellido.HeaderText = "Apellido";
            dtgClientes.Columns.Add(clm_cliente_apellido);

            DataGridViewTextBoxColumn clm_cliente_fecha_nacimiento = new DataGridViewTextBoxColumn();
            clm_cliente_fecha_nacimiento.Width = 80;
            clm_cliente_fecha_nacimiento.ReadOnly = true;
            clm_cliente_fecha_nacimiento.DataPropertyName = "cliente_fecha_nacimiento";
            clm_cliente_fecha_nacimiento.HeaderText = "Fecha de nacimiento";
            dtgClientes.Columns.Add(clm_cliente_fecha_nacimiento);

            DataGridViewTextBoxColumn clm_cliente_documento = new DataGridViewTextBoxColumn();
            clm_cliente_documento.Width = 80;
            clm_cliente_documento.ReadOnly = true;
            clm_cliente_documento.DataPropertyName = "cliente_numero_documento";
            clm_cliente_documento.HeaderText = "Documento";
            dtgClientes.Columns.Add(clm_cliente_documento);

            DataGridViewTextBoxColumn clm_cliente_calle = new DataGridViewTextBoxColumn();
            clm_cliente_calle.Width = 80;
            clm_cliente_calle.ReadOnly = true;
            clm_cliente_calle.DataPropertyName = "cliente_calle";
            clm_cliente_calle.HeaderText = "Calle";
            dtgClientes.Columns.Add(clm_cliente_calle);

            DataGridViewTextBoxColumn clm_cliente_numero = new DataGridViewTextBoxColumn();
            clm_cliente_numero.Width = 80;
            clm_cliente_numero.ReadOnly = true;
            clm_cliente_numero.DataPropertyName = "cliente_numero";
            clm_cliente_numero.HeaderText = "Numero";
            dtgClientes.Columns.Add(clm_cliente_numero);

            DataGridViewTextBoxColumn clm_cliente_piso = new DataGridViewTextBoxColumn();
            clm_cliente_piso.Width = 80;
            clm_cliente_piso.ReadOnly = true;
            clm_cliente_piso.DataPropertyName = "cliente_piso";
            clm_cliente_piso.HeaderText = "Piso";
            dtgClientes.Columns.Add(clm_cliente_piso);

            DataGridViewTextBoxColumn clm_cliente_depto = new DataGridViewTextBoxColumn();
            clm_cliente_depto.Width = 80;
            clm_cliente_depto.ReadOnly = true;
            clm_cliente_depto.DataPropertyName = "cliente_depto";
            clm_cliente_depto.HeaderText = "Depto";
            dtgClientes.Columns.Add(clm_cliente_depto);

            DataGridViewTextBoxColumn clm_cliente_mail = new DataGridViewTextBoxColumn();
            clm_cliente_mail.Width = 80;
            clm_cliente_mail.ReadOnly = true;
            clm_cliente_mail.DataPropertyName = "cliente_mail";
            clm_cliente_mail.HeaderText = "Mail";
            dtgClientes.Columns.Add(clm_cliente_mail);

            //le inserto a la grilla el dataset obtenido
            dtgClientes.DataSource = dsCliente.Tables[0];

        }

        public void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            txtMail.Clear();

        }
        #endregion

        public DataSet ObtenerClientes()
        {
            DataSet ds = unCliente.TraerListado("ConTodo");
            return ds;

        }

  
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCliente _frmCliente = new frmCliente();
            _frmCliente.AbrirParaAgregar();
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

        public void CargarListadoDeClientes()
        {
            try
            {
                DataSet ds = unCliente.obtenerTodosLosClientes();
                cargarGrilla(ds);
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

        private int valorIdSeleccionado()
        {
            // devuelve el id_cliente del Cliente seleccionaod en la grilla
            return Convert.ToInt32(((DataRowView)dtgClientes.CurrentRow.DataBoundItem)["cliente_id"]);

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmCliente formCliente = new frmCliente();
            // instancio un nuevo cliente con el id_cleinte del Cliente seleccionado en la grilla
            // a traves del cual voy a cargar todos los atributos del Cliente
            MessageBox.Show("cliente id: "+ valorIdSeleccionado() + "\nnombre: ", "Cliente");

            DataSet ds = unCliente.TraerClientePorIDConTodosLosDatos(valorIdSeleccionado());
            unCliente.DataRowToObjectCompleto(ds.Tables[0].Rows[0]);
            formCliente.AbrirParaModificar(unCliente, this);
        }


        private void ListadoCliente_Load(object sender, EventArgs e)
        {
            DataSet ds = ObtenerClientes();
            cargarGrilla(ds);

            //Cargar combo tipo dni
            DataSet dsTipoDNI = SQLHelper.ExecuteDataSet("TraerListadoTipoDocumento");
            DropDownListManager.CargarCombo(cmbTipoDoc, dsTipoDNI.Tables[0], "td_id", "td_descripcion", false, "");
            cmbTipoDoc.SelectedIndex = -1;

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloLetras(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloLetras(e);
        }




    }
}        
        
        
        
