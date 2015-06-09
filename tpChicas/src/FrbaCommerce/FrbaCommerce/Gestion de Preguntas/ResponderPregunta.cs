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
using FrbaCommerce.Gestion_de_Preguntas;
using System.Configuration;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class ResponderPregunta : Form
    {
        //se instancia el form padre que sería el formulario del cual se llamo a este formulario
        listadoPreguntas frmPadre = new listadoPreguntas();
        private int id_Pregunta;
        int cod_Publicacion;
        
        public ResponderPregunta()
        {
            InitializeComponent();
        }

        public void AbrirParaResponder(int idPreg, listadoPreguntas frmEnviador, int codigoP)
        {
            //se guarda el formulario desde el cual se invocó para luego poder volver al mismo.
            //el codigo de la publicacion se guarda para después cuando se vuelva al formulario padre
            //se carguen las preguntas sin respuesta para ese código de publicación
            frmPadre = frmEnviador;
            id_Pregunta = idPreg;
            cod_Publicacion = codigoP;
            this.Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //se validan el campo respuesta
                ValidarCampos();
                //se guarda la respuesta que se ingresó
                string respuesta = txtRespuesta.Text;
                
                //se invoca el metodo guardar respuesta en Pregunta que va a invocar a un store procedure al que se le envía
                // el id de la pregunta a la cuál se responde, la respuesta que se ingresó, y la fecha de la respuesta
                Pregunta.GuardarRespuesta(id_Pregunta,respuesta, Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]));
                DialogResult dr = MessageBox.Show("La respuesta ha sido realizada", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                if (dr == DialogResult.OK)
                {
                    //si la respuesta fue realizada correctamente, entonces se carga el nuevo listado de preguntas
                    //no respondidas en el formulario padre
                    this.Close();
                    frmPadre.cargarListadoPreguntasNoRespondidas(cod_Publicacion);
                }


            }
            catch (EntidadExistenteException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (BadInsertException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ValidarCampos()
        {
            //se verifica que el campo respuesta no sea nulo
            string strErrores = "";
            strErrores += Validator.ValidarNulo(txtRespuesta.Text, "Pregunta");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            //si se apreta el botón volver, se carga el listado de preguntas no respondidas para un codigo de publicación
            //en el formulario padre y se cierra este formulario
            frmPadre.cargarListadoPreguntasNoRespondidas(cod_Publicacion);
            frmPadre.BringToFront();
            this.Close();
        }


    }
}
