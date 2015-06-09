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
using FrbaCommerce.Abm_Rol;
using Excepciones;

namespace FrbaCommerce.ABM_Rol
{
    public partial class listadoRoles : Form
    {
        public listadoRoles()
        {
            InitializeComponent();
        }

        private void listadoRoles_Load(object sender, EventArgs e)
        {
            CargarListadoDeRoles();
        }

        private void configurarGrilla(DataSet ds)
        {
            //realizo la configuracion de la grilla, seteando las filas y columnas con sus nombres y valores
            dtgListado.Columns.Clear();
            dtgListado.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmID = new DataGridViewTextBoxColumn();
            clmID.Width = 30;
            clmID.ReadOnly = true;
            clmID.DataPropertyName = "id_Rol";
            clmID.HeaderText = "ID";
            dtgListado.Columns.Add(clmID);

            DataGridViewTextBoxColumn clmNombre = new DataGridViewTextBoxColumn();
            clmNombre.ReadOnly = true;
            clmNombre.DataPropertyName = "Nombre";
            clmNombre.HeaderText = "Nombre";
            dtgListado.Columns.Add(clmNombre);

            DataGridViewCheckBoxColumn clmHabilitado = new DataGridViewCheckBoxColumn();
            clmHabilitado.Width = 60;
            clmHabilitado.ReadOnly = true;
            clmHabilitado.DataPropertyName = "Habilitado";
            clmHabilitado.HeaderText = "Habilitado";
            dtgListado.Columns.Add(clmHabilitado);

            //le inserto a la grilla el dataset obtenido
            dtgListado.DataSource = ds.Tables[0];
        }

        public void CargarListadoDeRoles()
        {

            try
            {
                //obtengo en un dataset todos los roles de la bd
                DataSet ds = Rol.obtenerTodosLosRoles();
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

        public void CargarListadoDeRolesConFiltros()
        {

            try
            {
                //obtengo un dataset de roles pero, en este caso, con los campos a filtrar
                //esto va a realizar una query donde recibira ambos filtros pero solo aplicara los que 
                //vengan llenos como para filtrar por ellos
                //luego, configuro la grilla
                DataSet ds = Rol.obtenerTodosLosRolesConFiltros(txtNombre.Text, chkHabilitado.Checked);
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

        private void btnVer_Click(object sender, EventArgs e)
        {
            //si el boton presionado es ver, instancio un rol con sus valores seleccionados, que son funciones,
            //ya que se obtienen de la grilla. Separamos la responsabilidad de la obtencion de ese valor en las
            //distintas funciones
            //luego de instanciado el rol, llamo al formulario frmRol mediante el mensaje AbrirParaVer, que recibe
            //el rol instanciado y este form. 
            frmRol _frmRol = new frmRol();
            Rol unRol = new Rol(valorIdSeleccionado(), valorNombreSeleccionado(), valorHabilitadoSeleccionado());
            _frmRol.AbrirParaVer(unRol, this);
            
        }

        private int valorIdSeleccionado()
        {
            return Convert.ToInt32(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["id_Rol"]);
        }
        private string valorNombreSeleccionado()
        {
            return ((DataRowView)dtgListado.CurrentRow.DataBoundItem)["Nombre"].ToString();
        }
        private bool valorHabilitadoSeleccionado()
        {
            return Convert.ToBoolean(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["Habilitado"]);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //si el boton tocado es agregar, abro el frmRol con el metodo abrirParaAgregar, que configurar el form
            //de forma tal que quede todo listo para realizar el alta
            frmRol _frmRol = new frmRol();            
            _frmRol.AbrirParaAgregar(this);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //si el boton tocado es modificar, instancio el rol con los datos de la fila seleccionada y abro el form
            //configurado con esos datos para editarlos
            frmRol _frmRol = new frmRol();
            Rol unRol = new Rol(valorIdSeleccionado(), valorNombreSeleccionado(), valorHabilitadoSeleccionado());
            _frmRol.AbrirParaModificar(unRol, this);
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            //si el boton tocado es desactivar, genero un dialog donde le pregunto si esta seguro de deshabilitarlo.
            //si toca que si, instancio el rol y lo deshabilito. sino, no hago nada
            DialogResult dr = MessageBox.Show("¿Está seguro que desea deshabilitar el rol?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Rol unRol = new Rol(valorIdSeleccionado(), valorNombreSeleccionado(), valorHabilitadoSeleccionado());
                unRol.Deshabilitar();
                MessageBox.Show("El rol ha quedado deshabilitado", "Deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListadoDeRoles();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Con filtros llenados o no, si toca boton buscar, me carga el listado de roles con los filtros disponibles
            CargarListadoDeRolesConFiltros();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //limpio los filtros y recargo el listado sin filtros
            txtNombre.Text = "";
            chkHabilitado.Checked = false;
            CargarListadoDeRoles();
        }

        private void dtgListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //si toca boton eliminar, genero un dialog donde le pregunto si esta seguro de eliminarlo
            //si responde que si, ejecuto la accion (borrado logico), sino, no hago nada
            DialogResult dr = MessageBox.Show("¿Está seguro que desea eliminar el rol?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    Rol unRol = new Rol(valorIdSeleccionado(), valorNombreSeleccionado(), valorHabilitadoSeleccionado());
                    unRol.Eliminar();
                    MessageBox.Show("El rol ha quedado eliminado", "Deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListadoDeRoles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
