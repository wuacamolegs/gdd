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
using Excepciones;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class listadoUsuarios : Form
    {
        public listadoUsuarios()
        {
            InitializeComponent();
        }

        private void listadoUsuarios_Load(object sender, EventArgs e)
        {
            cargarListadoUsuarios();
        }

        private void cargarListadoUsuarios()
        {
            try
            {
                DataSet ds = Usuario.obtenerTodos();
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

        private void configurarGrilla(DataSet ds)
        {
            dtgListado.Columns.Clear();
            dtgListado.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmID = new DataGridViewTextBoxColumn();
            clmID.Width = 30;
            clmID.ReadOnly = true;
            clmID.DataPropertyName = "id_Usuario";
            clmID.HeaderText = "ID";
            dtgListado.Columns.Add(clmID);

            DataGridViewTextBoxColumn clmNombre = new DataGridViewTextBoxColumn();
            clmNombre.ReadOnly = true;
            clmNombre.DataPropertyName = "Username";
            clmNombre.HeaderText = "Username";
            dtgListado.Columns.Add(clmNombre);


            DataGridViewCheckBoxColumn clmHabilitado = new DataGridViewCheckBoxColumn();
            clmHabilitado.Width = 60;
            clmHabilitado.ReadOnly = true;
            clmHabilitado.DataPropertyName = "Activo";
            clmHabilitado.HeaderText = "Activo";
            dtgListado.Columns.Add(clmHabilitado);

            dtgListado.DataSource = ds.Tables[0];
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Está seguro que desea deshabilitar el usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Usuario user = new Usuario(valorIdSeleccionado());
                user.Deshabilitar();
                MessageBox.Show("El usuario ha quedado deshabilitado", "Deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarListadoUsuarios();
            }
        }

        private int valorIdSeleccionado()
        {
            return Convert.ToInt32(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["id_Usuario"]);
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            string claveNuevaIngresada = DialogManager.ShowDialogWithPassword("Ingrese nueva clave", "Cambio de clave");

            if (string.IsNullOrEmpty(claveNuevaIngresada))
            {
                return;
            }

            string claveNueva = Encryptor.GetSHA256(claveNuevaIngresada);
            Usuario user = new Usuario(valorIdSeleccionado());
            user.CambiarClave(claveNueva);
        }


    }
}
