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
using FrbaCommerce.Gestion_de_Preguntas;
using FrbaCommerce.Generar_Publicacion;


namespace FrbaCommerce.Editar_Publicacion
{
    public partial class frmMisPublicaciones : Form
    {
        Usuario unUsuario = new Usuario();
        private int cod_Publicacion;
        Dictionary<int, Publicacion> publicaciones = new Dictionary<int, Publicacion>();
        List<Publicacion> listaDePubs = new List<Publicacion>();

        public frmMisPublicaciones()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        private void frmMisPublicaciones_Load(object sender, EventArgs e)
        {
            CargarListadoDePublicaciones();
        }

        private void llenarPublicaciones(DataSet ds)
        {
            listaDePubs.Clear();
            publicaciones.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Publicacion unaPub = new Publicacion();
                unaPub.DataRowToObject(dr);
                listaDePubs.Add(unaPub);
            }

            publicaciones = listaDePubs.ToDictionary(unaPub => unaPub.Codigo, unaPub => unaPub);
        }

        public void CargarListadoDePublicaciones()
        {
            try
            {
                DataSet ds = Publicacion.obtenerTodas(unUsuario);
                llenarPublicaciones(ds);
                configurarGrilla();
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

        private void configurarGrilla()
        {
            dtgListado.Columns.Clear();

            var listadoABindear = publicaciones.Values.Select(unaPub => new
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
                Estado = unaPub.Estado_Publicacion.Nombre,
                Rubros = unaPub.obtenerRubrosEnTexto()
            });

            dtgListado.DataSource = listadoABindear.ToList();
            dtgListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            agregarBotonVer();

        }

        private void agregarBotonVer()
        {
            var nuevaClm = new DataGridViewButtonColumn
            {
                Text = "Modificar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            dtgListado.Columns.Add(nuevaClm);
        }

        

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            CargarListadoDePublicaciones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarListadoDePublicacionesConFiltros();
        }

        public void CargarListadoDePublicacionesConFiltros()
        {
            try
            {
                DataSet ds = Publicacion.obtenerTodasConFiltros(unUsuario, txtDescripcion.Text);
                llenarPublicaciones(ds);
                configurarGrilla();
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

        private void btnRespuestas_Click(object sender, EventArgs e)
        {
            //se instancia un nuevo formulario de tipo listadoPreguntas y se lo abre con el mismo usuario, asique se lo
            //envía por parámetro. además se le envia this para que guarde quien es el formulario padre en el caso que después
            //pueda volver y el codigo publicación para poder cargar nuevamente el listado de preguntas para esa publicación
            listadoPreguntas _frmVerRespuestas = new listadoPreguntas();
            _frmVerRespuestas.abrirConUsuario(unUsuario);
            _frmVerRespuestas.AbrirParaVer(cod_Publicacion,this);
        }

        private void btnResponderPregs_Click(object sender, EventArgs e)
        {
            //primero se valida si tiene preguntas pendientes a responder
            if (ValidarSiTienePreguntasPendientes() == 1)
            {
                //en el caso que tenga, se instancia un nuevo formulario de tipo listadoPreguntas, y se lo llama
                // a abrir con el mismo usuario enviandole el codigo publicacion y el formulario que lo llama
                listadoPreguntas _frmVerRespuestas = new listadoPreguntas();
                _frmVerRespuestas.abrirConUsuario(unUsuario);
                _frmVerRespuestas.AbrirParaResponder(cod_Publicacion, this);
            }
        }

        private int ValidarSiTienePreguntasPendientes()
        {
            //se obtiene el dataSet de las preguntas sin respuestas para una publicación y usuario
            DataSet ds = Pregunta.obtenerPreguntasSinRespuestas(cod_Publicacion, unUsuario);

            if (ds.Tables[0].Rows.Count == 0)
            {
                //si el dataset es nulo, entonces se le notifica que no tiene ninguna pregunta para responder
                MessageBox.Show("No tiene ninguna pregunta pendiente a responder", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return 1;
        }

        private void dtgListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) //esto lo pongo por si me hace click en un header, para que no ejecute ninguna accion
            {
                //11 es la columna que contiene el boton de modificar
                if (e.ColumnIndex == 11)
                {
                    Publicacion unaPub = listaDePubs.Find(pub => pub.Codigo == (int)dtgListado.Rows[e.RowIndex].Cells[0].Value);
                    frmDetallePublic _frmDetalle = new frmDetallePublic();
                    switch (unaPub.Estado_Publicacion.Nombre)
                    {
                        case "Borrador":
                            _frmDetalle.AbrirParaModificarBorrador(unaPub, this);
                            break;
                        case "Publicada":
                            if (unaPub.Tipo_Publicacion.Nombre == "Subasta")
                                MessageBox.Show("No se puede editar una subasta publicada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                _frmDetalle.AbrirParaModificarPublicada(unaPub, this);

                            break;
                        case "Pausada":
                            MessageBox.Show("No se puede editar una publicación pausada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case "Finalizada":
                            MessageBox.Show("No se puede editar una publicación finalizada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                    }




                }
                else
                {
                    cod_Publicacion = (int)dtgListado.Rows[e.RowIndex].Cells[0].Value;
                }
            }
                

            

            
        }

        
    }
}
