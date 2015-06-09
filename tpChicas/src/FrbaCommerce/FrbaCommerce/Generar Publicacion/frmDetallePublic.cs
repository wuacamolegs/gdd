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
using FrbaCommerce.Editar_Publicacion;
using System.Configuration;
namespace FrbaCommerce.Generar_Publicacion
{
    public partial class frmDetallePublic : Form
    {
        frmMisPublicaciones frmPadre = new frmMisPublicaciones();
        Usuario unUsuario = new Usuario();
        Publicacion publicDelForm = new Publicacion();
        public frmDetallePublic()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPadre.BringToFront();
            this.Close();
        }

        public void AbrirParaModificarBorrador(Publicacion unaPublic, frmMisPublicaciones frmEnviador)
        {
            //Si se ejecuta esta funcion, significa que se va a abrir el form en modo modificar 
            //y que la publicacion a modificar es de tipo borrador, eso significa que puede editar TODOS los
            //campos. Por ende, seteo la publicacion del form en una variable global con la publicacion que
            //recibo como parametro, mismo para el formulario padre que me llama, luego populo todos los campos
            //con los datos recibidos y los habilito para la edicion
            btnGuardar.Visible = true;
            btnGenerar.Visible = false;

            frmPadre = frmEnviador;
            publicDelForm = unaPublic;

            this.Show();
            cargarListados();

            txtDescripcion.Text = unaPublic.Descripcion;
            txtDescripcion.Enabled = true;

            cmbEstado.SelectedValue = unaPublic.Estado_Publicacion.id_Estado;

            dtFechaCreacion.Text = unaPublic.Fecha_creacion.ToString();

            txtStock.Text = unaPublic.Stock.ToString();
            btnAumentarStock.Enabled = true;
            btnRestarStock.Enabled = true;


            cmbVisibilidad.SelectedValue = unaPublic.Visibilidad.cod_Visibilidad;
            cmbVisibilidad.Enabled = true;

            cmbTipo.SelectedValue = unaPublic.Tipo_Publicacion.id_Tipo;
            cmbTipo.Enabled = true;

            txtPrecio.Text = unaPublic.Precio.ToString();
            txtPrecio.Enabled = true;

            chkPregs.Checked = unaPublic.Permiso_Preguntas;
            chkPregs.Enabled = true;

            //De todos los rubros cargados, chequeo los que pertenece mi publicacion
            for (int index = 0; index < lstRubros.Items.Count; index++)
            {
                Rubro item = (Rubro)lstRubros.Items[index];
                if (publicDelForm.Rubros.Any(unRubro => unRubro.Descripcion == item.Descripcion))
                    lstRubros.SetItemChecked(index, true);
                else
                    lstRubros.SetItemChecked(index, false);
            }
            lstRubros.Enabled = true;
        }

        public void AbrirParaModificarPublicada(Publicacion unaPublic, frmMisPublicaciones frmEnviador)
        {
            //Si se ejecuta esta funcion, significa que se abre el formulario en modo modificar, y la publicacion
            //a modificar es de estado publicada, es decir, solo puede updatear stock y estado. Por eso, habilito
            //solo esos campos
            btnGuardar.Visible = true;
            btnGenerar.Visible = false;

            frmPadre = frmEnviador;
            publicDelForm = unaPublic;

            this.Show();
            cargarListados();

            txtDescripcion.Text = unaPublic.Descripcion;
            txtDescripcion.Enabled = false;

            cargarEstadosParaEdicionPublicada();
            cmbEstado.SelectedValue = unaPublic.Estado_Publicacion.id_Estado;

            dtFechaCreacion.Text = unaPublic.Fecha_creacion.ToString();
            
            txtStock.Text = unaPublic.Stock.ToString();
            if (unaPublic.Tipo_Publicacion.Nombre == "Subasta")
            {
                btnAumentarStock.Enabled = false;
                btnRestarStock.Enabled = false;
            }


            cmbVisibilidad.SelectedValue = unaPublic.Visibilidad.cod_Visibilidad;
            cmbVisibilidad.Enabled = false;

            cmbTipo.SelectedValue = unaPublic.Tipo_Publicacion.id_Tipo;
            cmbTipo.Enabled = false;
            
            txtPrecio.Text = unaPublic.Precio.ToString();
            txtPrecio.Enabled = false;
            
            chkPregs.Checked = unaPublic.Permiso_Preguntas;
            chkPregs.Enabled = false;

            for (int index=0; index < lstRubros.Items.Count; index++ )
            {
                Rubro item = (Rubro)lstRubros.Items[index];
                if (publicDelForm.Rubros.Any(unRubro => unRubro.Descripcion == item.Descripcion))
                    lstRubros.SetItemChecked(index, true);
                else
                    lstRubros.SetItemChecked(index, false);
            }
            lstRubros.Enabled = false;
        }

        public void AbrirParaGenerar()
        {
            //Si se ejecuta esta funcion significa que se abre el formulario para generar una nueva publicacion
            //Todos los campos seran editables y vacios
            btnGuardar.Visible = false;
            btnGenerar.Visible = true;

            cargarListados();

            txtDescripcion.Text = "";
            txtDescripcion.Enabled = true;

            txtStock.Text = "0";

            dtFechaCreacion.Text = ConfigurationManager.AppSettings["Fecha"];

            btnAumentarStock.Enabled = true;
            btnRestarStock.Enabled = true;

            cmbVisibilidad.Enabled = true;

            cmbTipo.Enabled = true;

            txtPrecio.Text = "";
            txtPrecio.Enabled = true;

            chkPregs.Enabled = true;

            lstRubros.Enabled = true;
        }



        private void cargarEstadosParaEdicionPublicada()
        {
            //si la publicacion es publicada, solo me deja algunas transiciones entre estados. Por eso, 
            //obtengo este dataset y seteo el combo
            DataSet ds = Estado_Publicacion.obtenerTodosLosEditablesConPublicada();
            DropDownListManager.CargarCombo(cmbEstado, ds.Tables[0], "id_Estado", "Nombre", false, "");
            
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
            AbrirParaGenerar();
        }

        public void cargarListados()
        {
            //cargo todos los listados de la publicacion, tipos, estados, visibilidades, y rubros
            cargarTipos();
            cargarEstados();
            cargarVisibilidades();
            cargarRubros();
        }
        private void cargarVisibilidades()
        {
            DataSet ds = Visibilidad.obtenerTodasLasVisibilidades();
            DropDownListManager.CargarCombo(cmbVisibilidad, ds.Tables[0], "cod_Visibilidad", "Descripcion", false, "");
        }

        private void cargarEstados()
        {
            DataSet ds = Estado_Publicacion.obtenerTodos();
            DropDownListManager.CargarCombo(cmbEstado, ds.Tables[0], "id_Estado", "Nombre", false, "");
        }

        private void cargarTipos()
        {
            DataSet ds = Tipo_Publicacion.obtenerTodos();
            DropDownListManager.CargarCombo(cmbTipo, ds.Tables[0], "id_Tipo", "Nombre", false, "");
        }
        
        public void cargarRubros()
        {
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Guardo la publicacion
                ValidarCampos();
                publicDelForm.Descripcion = txtDescripcion.Text;
                publicDelForm.Stock = Convert.ToInt32(txtStock.Text);
                publicDelForm.Precio = Convert.ToDecimal(txtPrecio.Text);
                publicDelForm.Visibilidad = new Visibilidad(Convert.ToInt32(cmbVisibilidad.SelectedValue));
                publicDelForm.Fecha_vencimiento = (publicDelForm.Estado_Publicacion.Nombre != "Publicada") ? Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]).AddDays(publicDelForm.Visibilidad.Duracion) : publicDelForm.Fecha_vencimiento;
                //La consigna pide que la fecha de vencimiento se genere automaticamente con la duracion de
                //la visibilidad. Por eso es que obtengo el dia de la fecha con el app config y le sumo
                //los dias de duracion de la visibilidad
                publicDelForm.Tipo_Publicacion = new Tipo_Publicacion(Convert.ToInt32(cmbTipo.SelectedValue));
                publicDelForm.Estado_Publicacion = new Estado_Publicacion(Convert.ToInt32(cmbEstado.SelectedValue));
                publicDelForm.Rubros.Clear();
                foreach (Rubro unRubro in lstRubros.CheckedItems)
                {
                    publicDelForm.Rubros.Add(unRubro);
                }

                publicDelForm.ModificarDatosYRubros();
                DialogResult dr = MessageBox.Show("La publicacion ha sido modificada", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                frmPadre.CargarListadoDePublicaciones();
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

        private void ValidarCantidadGratuitas()
        {
            //Solo se permiten 3 publicaciones gratuitas por usuario
            DataSet dsCantGratuitas = Publicacion.obtenerCantidadDePubsGratuitas(unUsuario);
            if (!(dsCantGratuitas.Tables[0].Rows.Count < Convert.ToInt32(ConfigurationManager.AppSettings["maxPubGratuitas"])))
                throw new Exception("No se puede realizar esta acción. Ya se ha generado el máximo de publicaciones gratuitas.");
        }

        private void ValidarCampos()
        {
            //valido que la descripcion no sea nula, el precio sea decimal, el stock mayor a cero y que haya algo
            //seleccionado en el listado de rubros. de lo contrario, lanzo una excepcion para arriba para que
            //quien haya llamado a esta funcion la capture y muestre información al usuario de qué ha fallado
            string strErrores = "";
            strErrores += Validator.ValidarNulo(txtDescripcion.Text, "Descripcion");
            strErrores += Validator.SoloNumerosODecimales(txtPrecio.Text, "Precio");
            strErrores += Validator.MayorACero(txtStock.Text, "Stock");
            strErrores += Validator.validarNuloEnListaDeCheckbox(lstRubros, "Listado de rubros");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }

        private void btnAumentarStock_Click(object sender, EventArgs e)
        {
            txtStock.Text = (Convert.ToInt32(txtStock.Text) + 1).ToString();
        }

        private void btnRestarStock_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txtStock.Text) != 0)
                txtStock.Text = (Convert.ToInt32(txtStock.Text) - 1).ToString();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                if (cmbVisibilidad.Text == "Gratis")
                    ValidarCantidadGratuitas();
                publicDelForm.Usuario = unUsuario;
                publicDelForm.Descripcion = txtDescripcion.Text;
                publicDelForm.Stock = Convert.ToInt32(txtStock.Text);
                publicDelForm.Precio = Convert.ToDecimal(txtPrecio.Text);
                publicDelForm.Visibilidad = new Visibilidad(Convert.ToInt32(cmbVisibilidad.SelectedValue));
                publicDelForm.Fecha_vencimiento = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]).AddDays(publicDelForm.Visibilidad.Duracion);
                publicDelForm.Tipo_Publicacion = new Tipo_Publicacion(Convert.ToInt32(cmbTipo.SelectedValue));
                publicDelForm.Estado_Publicacion = new Estado_Publicacion(Convert.ToInt32(cmbEstado.SelectedValue));
                publicDelForm.Permiso_Preguntas = chkPregs.Checked;
                publicDelForm.Rubros.Clear();
                foreach (Rubro unRubro in lstRubros.CheckedItems)
                {
                    publicDelForm.Rubros.Add(unRubro);
                }

                publicDelForm.GenerarDatosYRubros();
                DialogResult dr = MessageBox.Show("La publicacion ha sido generada", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.AbrirParaGenerar();
                }

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
