using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Excepciones;
using Utilities;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class listadoVisibilidad : Form
    {
        public listadoVisibilidad()
        {
            InitializeComponent();
        }



        private decimal valorPorcentajeSeleccionado()
        {
            return Convert.ToDecimal(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["Porcentaje"]);
        }

        private decimal valorPrecioSeleccionado()
        {
            return Convert.ToDecimal(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["Precio"]);
        }

        private bool valorActivoSeleccionado()
        {
            return Convert.ToBoolean(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["Activo"]);
        }

        private string valorDescripcionSeleccionado()
        {
            return ((DataRowView)dtgListado.CurrentRow.DataBoundItem)["Descripcion"].ToString();
        }

        private int valorCodigoSeleccionado()
        {
            return Convert.ToInt32(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["cod_Visibilidad"]);
        }

        private int valorDuracionSeleccionado()
        {
            return Convert.ToInt32(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["Duracion"]);
        }


        public void CargarListadoDeVisibilidades()
        {
            try
            {
                //recibe un dataset de todas las visibilidades que hay en la BD. Luego, configura la grilla con esos datos
                DataSet ds = Visibilidad.obtenerTodasLasVisibilidades();
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
            //Se realiza la configuracion de la grilla con el dataset obtenido. Se crean las columnas con sus headers
            dtgListado.Columns.Clear();
            dtgListado.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmCod = new DataGridViewTextBoxColumn();
            clmCod.Width = 60;
            clmCod.ReadOnly = true;
            clmCod.DataPropertyName = "cod_Visibilidad";
            clmCod.HeaderText = "Código";
            dtgListado.Columns.Add(clmCod);

            DataGridViewTextBoxColumn clmDescripcion = new DataGridViewTextBoxColumn();
            clmDescripcion.ReadOnly = true;
            clmDescripcion.DataPropertyName = "Descripcion";
            clmDescripcion.HeaderText = "Descripción";
            dtgListado.Columns.Add(clmDescripcion);

            DataGridViewTextBoxColumn clmPrecio = new DataGridViewTextBoxColumn();
            clmPrecio.ReadOnly = true;
            clmPrecio.DataPropertyName = "Precio";
            clmPrecio.HeaderText = "Precio";
            dtgListado.Columns.Add(clmPrecio);

            DataGridViewTextBoxColumn clmPorcentaje = new DataGridViewTextBoxColumn();
            clmPorcentaje.ReadOnly = true;
            clmPorcentaje.DataPropertyName = "Porcentaje";
            clmPorcentaje.HeaderText = "Porcentaje";
            dtgListado.Columns.Add(clmPorcentaje);

            DataGridViewTextBoxColumn clmDuracion = new DataGridViewTextBoxColumn();
            clmDuracion.ReadOnly = true;
            clmDuracion.DataPropertyName = "Duracion";
            clmDuracion.HeaderText = "Duración";
            dtgListado.Columns.Add(clmDuracion);

            DataGridViewCheckBoxColumn clmActivo = new DataGridViewCheckBoxColumn();
            clmActivo.Width = 60;
            clmActivo.ReadOnly = true;
            clmActivo.DataPropertyName = "Activo";
            clmActivo.HeaderText = "Activo";
            dtgListado.Columns.Add(clmActivo);

            //le inserto a la grilla el dataset obtenido
            dtgListado.DataSource = ds.Tables[0];
            dtgListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void listadoVisibilidad_Load(object sender, EventArgs e)
        {
            CargarListadoDeVisibilidades();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //limpio los filtros y vuelvo a cargar la grilla sin filtros
            txtDescripcion.Text = "";
            txtPorcentaje.Text = "";
            txtPrecio.Text = "";
            txtDuracion.Text = "";
            chkActivo.Checked = false;
            CargarListadoDeVisibilidades();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //cuando toca el boton buscar, vuelvo a cargar la grilla pero ahora con filtros
            CargarListadoDeVisibilidadesConFiltros();
        }

        private void CargarListadoDeVisibilidadesConFiltros()
        {
            try
            {
                //obtengo el dataset con los filtros aplicados y configuro la grilla
                DataSet ds = Visibilidad.obtenerTodasLasVisibilidadesConFiltros(txtDescripcion.Text, txtPrecio.Text, txtPorcentaje.Text,txtDuracion.Text,chkActivo.Checked);
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
            //instancio una visibilidad con los datos de la fila seleccionada, y abro el formulario de visibilidad
            //en modo visualizar
            frmVisibilidad _frmVisibilidad = new frmVisibilidad();
            Visibilidad unaVisibilidad = new Visibilidad(valorCodigoSeleccionado(), valorDescripcionSeleccionado(), valorPrecioSeleccionado(), valorPorcentajeSeleccionado(), valorDuracionSeleccionado(), valorActivoSeleccionado());
            _frmVisibilidad.AbrirParaVer(unaVisibilidad, this);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //instancio una visibilidad con los datos de la fila seleccionada, y abro el formulario de visibilidad
            //en modo modificar
            frmVisibilidad _frmVisibilidad = new frmVisibilidad();
            Visibilidad unaVisibilidad = new Visibilidad(valorCodigoSeleccionado(), valorDescripcionSeleccionado(), valorPrecioSeleccionado(), valorPorcentajeSeleccionado(), valorDuracionSeleccionado(), valorActivoSeleccionado());
            _frmVisibilidad.AbrirParaModificar(unaVisibilidad, this);
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            //creo un dialog donde le pregunto si esta seguro de la accion a realizar. en caso de que 
            //conteste que si, se desactiva la visibilidad seleccionada
            DialogResult dr = MessageBox.Show("¿Está seguro que desea desactivar la visibilidad?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Visibilidad unaVisibilidad = new Visibilidad(valorCodigoSeleccionado(), valorDescripcionSeleccionado(), valorPrecioSeleccionado(), valorPorcentajeSeleccionado(), valorDuracionSeleccionado(), valorActivoSeleccionado());
                unaVisibilidad.Deshabilitar();
                MessageBox.Show("La visibilidad ha quedado desactivada", "Desactivada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListadoDeVisibilidades();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //abro el frm de visibilidad en modo agregar
            frmVisibilidad _frmVisib = new frmVisibilidad();
            _frmVisib.AbrirParaAgregar(this);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //creo un dialog donde le pregunto si esta seguro de la accion a realizar. si contesta que si, 
            //elimino (borrado logico) la visibilidad
            DialogResult dr = MessageBox.Show("¿Está seguro que desea eliminar la visibilidad?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    Visibilidad unaVisibilidad = new Visibilidad(valorCodigoSeleccionado(), valorDescripcionSeleccionado(), valorPrecioSeleccionado(), valorPorcentajeSeleccionado(),valorDuracionSeleccionado(), valorActivoSeleccionado());
                    unaVisibilidad.Eliminar();
                    MessageBox.Show("La visibilidad ha quedado eliminada", "Desactivada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListadoDeVisibilidades();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
