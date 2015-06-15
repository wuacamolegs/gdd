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


namespace PagoElectronico.ABM_Rol
{
    public partial class ABM_de_Rol : Form
    {
        public Usuario unUsuario = new Usuario();
        public Rol unRol = new Rol();

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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarRol abmModificarRol = new ModificarRol();
            abmModificarRol.abrirConRol(unRol);
        }





  

    }
}
