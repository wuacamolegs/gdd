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


namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class frmVisibilidad : Form
    {
        listadoVisibilidad frmPadre = new listadoVisibilidad();
        Visibilidad visibilidadDelForm = new Visibilidad();
        public frmVisibilidad()
        {
            InitializeComponent();
        }

        public void AbrirParaVer(Visibilidad unaVisibilidad, listadoVisibilidad frmEnviador)
        {
            //si se ejecuta esta funcion, significa que llaman al frm para visualizar. va a instanciar una
            //variable global llamada visibilidadDelForm, la cual recibiremos por parametro y sera la visibilidad 
            //que se ha elegido visualizar. Tambien existe una variable global frmPadre, }
            //que es el form que llama a este, para poder volver al mismo
            //Configuro todos los campos de este formulario en enabled false, es decir, no editables
            frmPadre = frmEnviador;
            visibilidadDelForm = unaVisibilidad;
            
            this.Show();
            
            chkActivo.Visible = true;
            chkActivo.Checked = unaVisibilidad.Activo;
            chkActivo.Enabled = false;

            txtDescripcion.Text = unaVisibilidad.Descripcion;
            txtDescripcion.Enabled = false;
            
            txtPrecioPorPublicar.Text = unaVisibilidad.Precio.ToString();
            txtPrecioPorPublicar.Enabled = false;
            
            txtPorcentaje.Text = unaVisibilidad.Porcentaje.ToString();
            txtPorcentaje.Enabled = false;

            txtDuracion.Text = unaVisibilidad.Duracion.ToString();
            txtDuracion.Enabled = false;
            
            btnCrear.Visible = false;
            btnGuardar.Visible = false;
        }

        public void AbrirParaModificar(Visibilidad unaVisibilidad, listadoVisibilidad frmEnviador)
        {
            //si se ejecuta esta funcion, significa que llaman al frm para modificar. va a instanciar una
            //variable global llamada visibilidadDelForm, la cual recibiremos por parametro y sera la visibilidad 
            //que se ha elegido modificar. Tambien existe una variable global frmPadre, }
            //que es el form que llama a este, para poder volver al mismo
            //Configuro todos los campos de este formulario en enabled true, es decir,  editables
            frmPadre = frmEnviador;
            visibilidadDelForm = unaVisibilidad;
            
            this.Show();
            
            chkActivo.Visible = true;
            chkActivo.Checked = unaVisibilidad.Activo;
            chkActivo.Enabled = true;
            
            txtDescripcion.Text = unaVisibilidad.Descripcion;
            txtDescripcion.Enabled = true;

            txtPrecioPorPublicar.Text = unaVisibilidad.Precio.ToString();
            txtPrecioPorPublicar.Enabled = true;

            txtPorcentaje.Text = unaVisibilidad.Porcentaje.ToString();
            txtPorcentaje.Enabled = true;

            txtDuracion.Text = unaVisibilidad.Duracion.ToString();
            txtDuracion.Enabled = true;

            btnCrear.Visible = false;
            btnGuardar.Visible = true;
            
        }

        public void AbrirParaAgregar(listadoVisibilidad frmEnviador)
        {
            //si se ejecuta esta funcion, significa que llaman al frm para agregar.
            //existe una variable global frmPadre, 
            //que es el form que llama a este, para poder volver al mismo
            //Configuro todos los campos de este formulario en enabled true, es decir, editables
            this.Show();

            txtDescripcion.Text = "";
            txtDescripcion.Enabled = true;

            txtPrecioPorPublicar.Text = "";
            txtPrecioPorPublicar.Enabled = true;

            txtPorcentaje.Text = "";
            txtPorcentaje.Enabled = true;

            txtDuracion.Text = "";
            txtDuracion.Enabled = true;

            chkActivo.Checked = false;
            chkActivo.Visible = true;
            chkActivo.Enabled = true;

            btnCrear.Visible = true;
            btnVolver.Visible = true;
            btnGuardar.Visible = false;

            frmPadre = frmEnviador;


        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPadre.CargarListadoDeVisibilidades();
            frmPadre.BringToFront();
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //seteo los atributos de la visibilidad seleccionada con los datos ingresados por el usuario
            //y modifico la entidad
            try
            {
                ValidarCampos();
                string descripcion = txtDescripcion.Text;
                var precio = Convert.ToDecimal(txtPrecioPorPublicar.Text.Replace(".", ","));
                var porcentaje = Convert.ToDecimal(txtPorcentaje.Text.Replace(".", ","));
                int duracion = Convert.ToInt32(txtDuracion.Text);
                bool activo = chkActivo.Checked;

                visibilidadDelForm.Descripcion= descripcion;
                visibilidadDelForm.Precio = precio;
                visibilidadDelForm.Porcentaje = porcentaje;
                visibilidadDelForm.Duracion = duracion;
                visibilidadDelForm.Activo = activo;


                visibilidadDelForm.ModificarDatos();
                DialogResult dr = MessageBox.Show("La visibilidad ha sido modificada", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                frmPadre.CargarListadoDeVisibilidades();
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
            //valido que la descripcion no este vacia, que el precio y el porcentaje sean decimales y la duracion numeros
            //si lo son, lanzo una excepcion para arriba que quien me haya llamado debe controlar y avisar al usuario
            //los errores encontrados
            string strErrores = "";
            strErrores += Validator.ValidarNulo(txtDescripcion.Text, "Descripcion");
            strErrores += Validator.SoloNumerosODecimales(txtPrecioPorPublicar.Text, "Precio");
            strErrores += Validator.SoloNumerosODecimales(txtPorcentaje.Text, "Porcentaje");
            strErrores += Validator.SoloNumeros(txtDuracion.Text, "Duracion");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            //creo una nueva instancia con los datos ingresados por el usuario y creo la entidad
            try
            {
                ValidarCampos();

                var precio = Convert.ToDecimal(txtPrecioPorPublicar.Text.Replace(".", ","));
                var porcentaje = Convert.ToDecimal(txtPorcentaje.Text.Replace(".", ","));
                string descripcion = txtDescripcion.Text;
                int duracion = Convert.ToInt32(txtDuracion.Text);
                bool activo = chkActivo.Checked;

                Visibilidad unaVisibNueva = new Visibilidad(descripcion, precio, porcentaje, duracion, activo);
                unaVisibNueva.guardarDatosDeVisibilidadNueva();
                DialogResult dr = MessageBox.Show("La visibilidad ha sido creada", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                frmPadre.CargarListadoDeVisibilidades();

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
    }
}
