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
            DataSet dsRol = unRol.traerRoles();
            cargarGrilla(dsRol);

        }

        #endregion


        #region botones y vista

        private void cargarGrilla(DataSet dsRol)
        {

            //realizo la configuracion de la grilla, seteando las filas y columnas con sus nombres y valores
            dtgListado.Columns.Clear();
            dtgListado.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmID = new DataGridViewTextBoxColumn();
            clmID.Width = 80;
            clmID.ReadOnly = true;
            clmID.DataPropertyName = "id_Rol";
            clmID.HeaderText = "ID ROL";
            dtgListado.Columns.Add(clmID);

            DataGridViewTextBoxColumn clmNombre = new DataGridViewTextBoxColumn();
            clmNombre.Width = 150;
            clmNombre.ReadOnly = true;
            clmNombre.DataPropertyName = "Nombre";
            clmNombre.HeaderText = "Nombre";
            dtgListado.Columns.Add(clmNombre);

            DataGridViewCheckBoxColumn clmHabilitado = new DataGridViewCheckBoxColumn();
            clmHabilitado.Width = 80;
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
            //si el boton tocado es modificar, instancio el rol con los datos de la fila seleccionada y abro el form
            //configurado con esos datos para editarlos
            frmRol formRol = new frmRol();
            MessageBox.Show("ROL ID: " + valorIdSeleccionado() + "\n NOMBRE: " + valorNombreSeleccionado() + "\n ESTADO: " +valorHabilitadoSeleccionado(), "");
            unRol.rol_id = valorIdSeleccionado();
            unRol.Nombre = valorNombreSeleccionado();
            unRol.Estado = valorHabilitadoSeleccionado();
            formRol.AbrirParaModificar(unRol, this);
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
            if(valorHabilitadoSeleccionado()){

                DialogResult dr = MessageBox.Show("¿Está seguro que desea deshabilitar el rol?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Rol unRol = new Rol(valorIdSeleccionado(), valorNombreSeleccionado(), valorHabilitadoSeleccionado());
                    unRol.Deshabilitar();
                    MessageBox.Show("El rol ha sido deshabilitado", "Deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListadoDeRoles();
                }
            }else{
                MessageBox.Show("El rol ya se encuentra deshabilitado. \n Vuelva a habilitarlo desde la seccion Modificación", "Deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Rol rolAEliminar = new Rol(valorIdSeleccionado(), valorNombreSeleccionado(), valorHabilitadoSeleccionado());
                    rolAEliminar.Eliminar();
                    MessageBox.Show("El rol sido eliminado", "Deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListadoDeRoles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            DataSet dsRol = unRol.traerRoles();
            cargarGrilla(dsRol);
        }

        public void CargarListadoDeRoles()
        {

            try
            {
                //obtengo en un dataset todos los roles de la bd
                DataSet dsRol = unRol.traerRoles();
                cargarGrilla(dsRol);
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataSet dsRoles = unRol.traerRoles();
            cargarGrilla(dsRoles);

        }

        #endregion

        #region llamados a la base

        #endregion

        #region metodos privados

        private Int64 valorIdSeleccionado()
        {
            return Convert.ToInt64(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["id_Rol"]);
        }
        private string valorNombreSeleccionado()
        {
            return ((DataRowView)dtgListado.CurrentRow.DataBoundItem)["Nombre"].ToString();
        }
        private bool valorHabilitadoSeleccionado()
        {
            return Convert.ToBoolean(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["rol_estado"]);
        }

        #endregion





    }
}
