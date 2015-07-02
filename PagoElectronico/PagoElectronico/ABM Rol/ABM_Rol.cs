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
using Excepciones;



namespace PagoElectronico.ABM_Rol
{
    public partial class ABM_de_Rol : Form
    {
        #region variables
        public Usuario unUsuario = new Usuario();
        public Rol unRol = new Rol();
        #endregion

        #region initialize
        public ABM_de_Rol()
        {
            InitializeComponent();
        }
     
        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }


        private void ABM_de_Rol_Load(object sender, EventArgs e)
        {
            //Cargargrilla
            cargarGrilla();

        }

        #endregion


        #region botones y vista

        private void cargarGrilla()
        {
            DataSet dsRol = unRol.traerRoles();
            //realizo la configuracion de la grilla, seteando las filas y columnas con sus nombres y valores
            dtgListado.Columns.Clear();
            dtgListado.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmID = new DataGridViewTextBoxColumn();
            clmID.Width = 40;
            clmID.ReadOnly = true;
            clmID.DataPropertyName = "rol_id";
            clmID.HeaderText = "ID ROL";
            dtgListado.Columns.Add(clmID);

            DataGridViewTextBoxColumn clmNombre = new DataGridViewTextBoxColumn();
            clmID.Width = 60;
            clmNombre.ReadOnly = true;
            clmNombre.DataPropertyName = "rol_nombre";
            clmNombre.HeaderText = "Nombre";
            dtgListado.Columns.Add(clmNombre);

            DataGridViewCheckBoxColumn clmHabilitado = new DataGridViewCheckBoxColumn();
            clmHabilitado.Width = 60;
            clmHabilitado.ReadOnly = true;
            clmHabilitado.DataPropertyName = "rol_estado";
            clmHabilitado.HeaderText = "Habilitado";
            dtgListado.Columns.Add(clmHabilitado);

            //le inserto a la grilla el dataset obtenido
            dtgListado.DataSource = dsRol.Tables[0];
        }

        private void dtgListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgListado.SelectedRows.ToString();
            unRol.rol_id = valorIdSeleccionado();
            unRol.Nombre = valorNombreSeleccionado();
            unRol.Estado = valorHabilitadoSeleccionado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //ModificarRol abmModificarRol = new ModificarRol();
            //abmModificarRol.abrirConRol(unRol);

            //si el boton tocado es modificar, instancio el rol con los datos de la fila seleccionada y abro el form
            //configurado con esos datos para editarlos
            frmRol _frmRol = new frmRol();
            Rol unRol = new Rol(valorIdSeleccionado(), valorNombreSeleccionado(), valorHabilitadoSeleccionado());
            _frmRol.AbrirParaModificar(unRol, this);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //si el boton tocado es agregar, abro el frmRol con el metodo abrirParaAgregar, que configurar el form
            //de forma tal que quede todo listo para realizar el alta
            frmRol _frmRol = new frmRol();
            _frmRol.AbrirParaAgregar(this);
        }

        private void btnDeshab_Click(object sender, EventArgs e)
        {
            //si el boton tocado es desactivar, le pregunto si esta seguro de deshabilitarlo.
            //si toca que si, instancio el rol y lo deshabilito. sino, no hago nada
            DialogResult dr = MessageBox.Show("¿Está seguro que desea deshabilitar el rol?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Rol unRol = new Rol(valorIdSeleccionado(), valorNombreSeleccionado(), valorHabilitadoSeleccionado());
                unRol.Deshabilitar();
                MessageBox.Show("El rol ha sido deshabilitado", "Deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListadoDeRoles();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //si toca boton eliminar, le pregunto si esta seguro de eliminarlo
            //si responde que si, ejecuto la accion (borrado logico), sino, no hago nada
            DialogResult dr = MessageBox.Show("¿Está seguro que desea eliminar el rol?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    Rol unRol = new Rol(valorIdSeleccionado(), valorNombreSeleccionado(), valorHabilitadoSeleccionado());
                    unRol.Eliminar();
                    MessageBox.Show("El rol sido eliminado", "Deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListadoDeRoles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region llamados a la base
        #endregion

        #region metodos privados

        private int valorIdSeleccionado()
        {
            return Convert.ToInt32(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["rol_id"]);
        }
        private string valorNombreSeleccionado()
        {
            return ((DataRowView)dtgListado.CurrentRow.DataBoundItem)["rol_nombre"].ToString();
        }
        private bool valorHabilitadoSeleccionado()
        {
            return Convert.ToBoolean(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["rol_estado"]);
        }

        #endregion


    }
}
