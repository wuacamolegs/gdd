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


namespace FrbaCommerce.Calificar_Vendedor
{
    public partial class calificarVendedor : Form
    {
        Calificacion unaCalificacion = new Calificacion();
        vendedoresSinCalificar frmPadre = new vendedoresSinCalificar();

        public calificarVendedor()
        {
            InitializeComponent();
        }

        private void calificarVendedor_Load(object sender, EventArgs e)
        {
            cmbCantidadEstrellas.SelectedIndex = 0;
        }

        public void AbrirParaCalificar(vendedoresSinCalificar frmEnviador, int id_Usuario_calificador, int cod_Publicacion)
        {
            //seteo los atributos de esta nueva calificacion con los datos que me fueron pasados como parametro
            unaCalificacion.cod_Publicacion = cod_Publicacion;
            unaCalificacion.id_Usuario_Calificador = id_Usuario_calificador;
            // guardo en mi atribto frmPadre el form que me invoco asi despues puedo pedirle que actualice la grilla
            frmPadre = frmEnviador;
            this.Show();

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                unaCalificacion.Cant_Estrellas = Int32.Parse(cmbCantidadEstrellas.Text);
                unaCalificacion.Descripcion = txtDetalleCalificacion.Text;

                unaCalificacion.GuardarCalificacion();
                DialogResult dr = MessageBox.Show("El Vendedor ha sido calificado con " + unaCalificacion.Cant_Estrellas + " estrellas.", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close(); 
                    frmPadre.BringToFront();
                }
                //actualizo la grilla
                frmPadre.cargarListadoVendedoresSinCalificar();

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
    }
}
