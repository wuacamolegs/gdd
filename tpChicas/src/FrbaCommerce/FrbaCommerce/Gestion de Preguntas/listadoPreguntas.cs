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
using FrbaCommerce.Editar_Publicacion;
using FrbaCommerce.Gestion_de_Preguntas;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class listadoPreguntas : Form
    {
        Usuario unUsuario = new Usuario();
        //se guarda el form (frmPadre) desde el cual se lo llamó a este formulario
        frmMisPublicaciones frmPadre = new frmMisPublicaciones();
        private int id_Pregunta;
        private int cod_Publicacion;

        public listadoPreguntas()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            //se guarda la información del usuario con el que se abrió el formulario
            unUsuario = user;
            this.Show();
        }

        private int valorIdSeleccionado()
        {
            //convierto en int32 un el valor de la datarow seleccionado que está en la columna de Id Pregunta
            return Convert.ToInt32(((DataRowView)dtgPreguntas.CurrentRow.DataBoundItem)["id_Pregunta"]);
        }

        public void AbrirParaVer(int codigo, frmMisPublicaciones frmEnviador)
        {
            //se guarda tanto el form padre para luego poder volver a ese form
            //se recibe el codigo de la publicación de la cual se cargará el listado para ver de preguntas con respuestas
            frmPadre = frmEnviador;
            cod_Publicacion = codigo;
            btnResponder.Visible = false;
            cargarListadoRespuestas(cod_Publicacion);
        }

        public void cargarListadoRespuestas(int cod_P)
        {
            try
            {
                //se obtiene el DataSet de las preguntas con respuestas según la publicación seleccionada (por eso se 
                //envía el código de publicación y según el usuario)
                DataSet ds = Pregunta.obtenerPreguntasConRespuestas(cod_P, unUsuario);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    configurarGrillaPreguntasYRespuestas(ds);
                }

                MessageBox.Show("No ha realizado ninguna respuesta para esta publicación", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
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

        private void configurarGrillaPreguntasYRespuestas(DataSet ds)
        {
            //se configuran la grilla con sus respectivas columnas para el dataset de preguntas con respuestas
            dtgPreguntas.Columns.Clear();
            dtgPreguntas.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmIDPregunta = new DataGridViewTextBoxColumn();
            clmIDPregunta.Width = 65;
            clmIDPregunta.ReadOnly = true;
            clmIDPregunta.DataPropertyName = "id_Pregunta";
            clmIDPregunta.HeaderText = "ID Pregunta";
            dtgPreguntas.Columns.Add(clmIDPregunta);
            
            DataGridViewTextBoxColumn clmPregunta = new DataGridViewTextBoxColumn();
            clmPregunta.Width = 200;
            clmPregunta.ReadOnly = true;
            clmPregunta.DataPropertyName = "Pregunta";
            clmPregunta.HeaderText = "Pregunta";
            dtgPreguntas.Columns.Add(clmPregunta);

            DataGridViewTextBoxColumn clmRespuesta = new DataGridViewTextBoxColumn();
            clmRespuesta.Width = 200;
            clmRespuesta.ReadOnly = true;
            clmRespuesta.DataPropertyName = "Respuesta";
            clmRespuesta.HeaderText = "Respuesta";
            dtgPreguntas.Columns.Add(clmRespuesta);

            DataGridViewTextBoxColumn clmFechaRta = new DataGridViewTextBoxColumn();
            clmFechaRta.Width = 65;
            clmFechaRta.ReadOnly = true;
            clmFechaRta.DataPropertyName = "Fecha_respuesta";
            clmFechaRta.HeaderText = "Fecha Respuesta";
            dtgPreguntas.Columns.Add(clmFechaRta);

            DataGridViewTextBoxColumn clmCodigo = new DataGridViewTextBoxColumn();
            clmCodigo.Width = 70;
            clmCodigo.ReadOnly = true;
            clmCodigo.DataPropertyName = "Codigo";
            clmCodigo.HeaderText = "Código Publicación";
            dtgPreguntas.Columns.Add(clmCodigo);

            DataGridViewTextBoxColumn clmDescripcion = new DataGridViewTextBoxColumn();
            clmDescripcion.Width = 200;
            clmDescripcion.ReadOnly = true;
            clmDescripcion.DataPropertyName = "Descripcion";
            clmDescripcion.HeaderText = "Descripción Publicación";
            dtgPreguntas.Columns.Add(clmDescripcion);

            DataGridViewTextBoxColumn clmStock = new DataGridViewTextBoxColumn();
            clmStock.Width = 60;
            clmStock.ReadOnly = true;
            clmStock.DataPropertyName = "Stock";
            clmStock.HeaderText = "Stock";
            dtgPreguntas.Columns.Add(clmStock);

            DataGridViewTextBoxColumn clmFechaCreacion = new DataGridViewTextBoxColumn();
            clmFechaCreacion.Width = 80;
            clmFechaCreacion.ReadOnly = true;
            clmFechaCreacion.DataPropertyName = "Fecha_creacion";
            clmFechaCreacion.HeaderText = "Fecha Creación";
            dtgPreguntas.Columns.Add(clmFechaCreacion);

            DataGridViewTextBoxColumn clmFechaVencimiento = new DataGridViewTextBoxColumn();
            clmFechaVencimiento.Width = 80;
            clmFechaVencimiento.ReadOnly = true;
            clmFechaVencimiento.DataPropertyName = "Fecha_vencimiento";
            clmFechaVencimiento.HeaderText = "Fecha Vencimiento";
            dtgPreguntas.Columns.Add(clmFechaVencimiento);

            DataGridViewTextBoxColumn clmPrecio = new DataGridViewTextBoxColumn();
            clmPrecio.Width = 60;
            clmPrecio.ReadOnly = true;
            clmPrecio.DataPropertyName = "Precio";
            clmPrecio.HeaderText = "Precio";
            dtgPreguntas.Columns.Add(clmPrecio);

            dtgPreguntas.DataSource = ds.Tables[0];
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            //se carga el formulario padre que había sido guardado anteriormente y se cierra esta formulario
            frmPadre.CargarListadoDePublicaciones();
            frmPadre.BringToFront();
            this.Close();
        }

        public void AbrirParaResponder(int codigo, frmMisPublicaciones frmEnviador)
        {
            //nuevamente se guarda el formulario desde el cual se abrio este form
            //se carga el listado de las preguntas que todavía no han sido respondidas
            frmPadre = frmEnviador;
            cod_Publicacion = codigo;
            cargarListadoPreguntasNoRespondidas(cod_Publicacion);
        }

        public void cargarListadoPreguntasNoRespondidas(int codP)
        {
            try
            {
                //se obtiene el data set y se configura la grilla
                DataSet ds = Pregunta.obtenerPreguntasSinRespuestas(codP, unUsuario);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    configurarGrillaPreguntasYRespuestas(ds);
                }

                MessageBox.Show("No tiene ninguna pregunta pendiente a responder", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
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

        private void btnResponder_Click(object sender, EventArgs e)
        {
            //el usuario al tocar el botón responder, se instancia un nuevo formulario de tipo ResponderPregunta
            ResponderPregunta _frmResponderPregunta = new ResponderPregunta();
            //se guarda el id pregunta de la pregunta (fila de la grilla) seleccionada
            id_Pregunta = valorIdSeleccionado();
            //se abre el formulario con el mismo usuario y enviándole el formulario padre y el codigo publicacion para
            //que luego tenga la posibilidad de volver a este form y poder cargar el listado de preguntas para el mismo
            //cod de publicación (que es el que se le está enviando)
            _frmResponderPregunta.AbrirParaResponder(id_Pregunta, this, cod_Publicacion);
        }

    }
}
