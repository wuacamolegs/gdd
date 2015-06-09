using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Utilities;
using Excepciones;
using System.Configuration;



namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class frmVerPublicaciones : Form
    {
        Usuario unUsuario = new Usuario();
        Dictionary<int, Publicacion> publicaciones = new Dictionary<int, Publicacion>();
        List<Publicacion> listaDePubs = new List<Publicacion>();
        public int paginado =0;
        public frmVerPublicaciones()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        public void CargarListadoDePublicaciones()
        {
            try
            {
                DataSet ds = Publicacion.obtenerTodas(Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]));
                paginado = 0;
                llenarPublicaciones(ds);
                configurarGrilla();
                btnAnterior.Visible = false;
                btnPrimero.Visible = false;
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

        private void llenarPublicaciones(DataSet ds)
        {
            //paso todo el dataset a una lista de publicaciones
            listaDePubs.Clear();
            publicaciones.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Publicacion unaPub = new Publicacion();
                unaPub.DataRowToObject(dr);
                listaDePubs.Add(unaPub);
            }
            //armo, con la lista de publicaciones, un diccionario
            publicaciones = listaDePubs.ToDictionary(unaPub => unaPub.Codigo, unaPub => unaPub);
        }

        private void configurarGrilla()
        {
            dtgListado.Columns.Clear();
            btnAnterior.Visible = true;
            btnSiguiente.Visible = true;
            btnUltimo.Visible = true;
            btnPrimero.Visible = true;

            //creo un bind de mi diccionario de publicaciones donde voy a poder setear todos los campos que quiero
            //mostrar en la grilla y que valores va a tener

            var bindeo = publicaciones.Values.Select(unaPub => new
            {
                Codigo = unaPub.Codigo,
                Descripcion = unaPub.Descripcion,
                Creacion = unaPub.Fecha_creacion,
                Vencimiento = unaPub.Fecha_vencimiento,
                Stock = unaPub.Stock,
                Precio = unaPub.obtenerPrecioSegunTipo(),
                Preguntas = unaPub.Permiso_Preguntas,
                Tipo = unaPub.Tipo_Publicacion.Nombre,
                Visibilidad = unaPub.Visibilidad.Descripcion,
                Rubros = unaPub.obtenerRubrosEnTexto()
            });

            //le seteo el bind a la grilla
            var listadoABindear = bindeo.ToList();

            //pagino, segun una config del app.config, la grilla
            if (listadoABindear.Count - paginado > 10)
                dtgListado.DataSource = listadoABindear.GetRange(paginado, Convert.ToInt32(ConfigurationManager.AppSettings["Paginado"])); 
            else
                dtgListado.DataSource = listadoABindear.GetRange(paginado, listadoABindear.Count - paginado);
            
            dtgListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            agregarBotonVer();

            if (listadoABindear.Count == 0)
            {
                btnAnterior.Visible = false;
                btnSiguiente.Visible = false;
                btnUltimo.Visible = false;
                btnPrimero.Visible = false;
            }

        }

        private void agregarBotonVer()
        {
            //agrego boton de Ver
            var nuevaClm = new DataGridViewButtonColumn
            {
                Text = "Ver",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            dtgListado.Columns.Add(nuevaClm);
        }



        public void CargarListadoDePublicacionesConFiltros()
        {
            try
            {
                string filtroDeRubros = "";
                for (int index = 0; index < lstRubros.CheckedItems.Count; index++)
                {
                    Rubro item = (Rubro)lstRubros.CheckedItems[index];
                    filtroDeRubros += item.Descripcion;
                }
                
                DataSet ds = Publicacion.obtenerTodasConFiltros(Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]),txtDescripcion.Text, filtroDeRubros);
                paginado = 0;
                llenarPublicaciones(ds);
                configurarGrilla();
                btnAnterior.Visible = false;
                btnPrimero.Visible = false;
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

        private void frmVerPublicaciones_Load(object sender, EventArgs e)
        {
            CargarListadoDePublicaciones();
            CargarListadoDeRubros();

        }

        public void CargarListadoDeRubros()
        {
            //cargo todos los rubros que hay en el sistema
            lstRubros.Items.Clear();
            DataSet ds = Rubro.obtenerTodas();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Rubro unRubro = new Rubro();
                unRubro.DataRowToObject(dr);
                lstRubros.Items.Add(unRubro);
            }
            lstRubros.DisplayMember = "Descripcion";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarListadoDePublicacionesConFiltros();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //limpio todos los filtros a su origen y vuelvo a cargar el listado de publicaciones sin filtros
            txtDescripcion.Text = "";
            while (lstRubros.CheckedIndices.Count > 0)
            {
                lstRubros.SetItemChecked(lstRubros.CheckedIndices[0], false);
            }
            CargarListadoDePublicaciones();
        }

        private void dtgListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //10 es la columna que contiene el boton de ver, las demas no deberian tener accion alguna
            if (e.ColumnIndex != 10)
                return;

            //si toco boton de ver, seteo la publicacion obtenida de la grilla y abro el formulario de detalle
            //de la publicacion
            Publicacion unaPub = listaDePubs.Find(pub => pub.Codigo == (int)dtgListado.Rows[e.RowIndex].Cells[0].Value);
            frmDetallePublicGeneral _frmDetalle = new frmDetallePublicGeneral();
            _frmDetalle.AbrirParaVer(unaPub, this, unUsuario);
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            paginado = 0;
            configurarGrilla();
            btnAnterior.Visible = false;
            btnSiguiente.Visible = true;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            paginado -= 10;
            configurarGrilla();
            btnSiguiente.Visible = true;
            if (paginado == 0)
                btnAnterior.Visible = false;
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            paginado = listaDePubs.Count - (listaDePubs.Count % 10);
            configurarGrilla();
            btnAnterior.Visible = true;
            btnPrimero.Visible = true;
            btnSiguiente.Visible = false;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            paginado += 10;
            configurarGrilla();
            btnAnterior.Visible = true;
            btnPrimero.Visible = true;
            if (listaDePubs.Count - paginado < 10)
                btnSiguiente.Visible = false;
        }
    }
}
