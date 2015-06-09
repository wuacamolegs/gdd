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

namespace FrbaCommerce.Abm_Cliente
{
    public partial class frmCliente : Form
    {
        listadoCliente frmPadre = new listadoCliente();
        Cliente clienteDelForm = new Cliente();
        private int _id_usuario_registrado;

        public frmCliente()
        {
            InitializeComponent();
        }
        // necesito esta variable id_usuario_registrado porque cuando abro este form despues
        // de haber registrado un nuevo usuario, necesito guardar el id de este para el insert del 
        // nuevo Cliente
        public int id_usuario_registrado
        {
            get { return _id_usuario_registrado; }
            set { _id_usuario_registrado = value; }
        }

        // Este form se puede abrir para ver los Datos de un Cliente, para modificarlos,
        // para crear uno nuevo(se crea tambien un usuario default) o para registrar un nuevo Cliente
        // despues de haber reistrado un usuario. 
        public void AbrirParaVer(Cliente unCliente, listadoCliente frmEnviador)
        {
            frmPadre = frmEnviador;
            clienteDelForm = unCliente;

            this.Show();

            txtApellido.Text = unCliente.Apellido;
            txtCalle.Text = unCliente.Dom_calle;
            txtCodPostal.Text = unCliente.Dom_cod_postal;
            txtDepto.Text = unCliente.Dom_depto;
            txtCuil.Text = unCliente.Cuil;
            cmbTipoDni.Text = unCliente.Tipo_Doc;
            txtDni.Text = Convert.ToString(unCliente.Dni);
            txtFechaNac.Text = Convert.ToString(unCliente.Fecha_nac);
            txtLocalidad.Text = unCliente.Dom_ciudad;
            txtMail.Text = unCliente.Mail;
            txtNombre.Text = unCliente.Nombre;
            txtNroPiso.Text = unCliente.Dom_piso.ToString();
            txtNumeroCalle.Text = unCliente.Dom_nro_calle.ToString();
            txtTelefono.Text = unCliente.Telefono;
            chkActivo.Checked = unCliente.Activo;

            txtApellido.Enabled = false;
            txtCalle.Enabled = false;
            txtCodPostal.Enabled = false;
            txtDepto.Enabled = false;
            txtCuil.Enabled = false;
            txtDni.Enabled = false;
            txtFechaNac.Enabled = false;
            txtLocalidad.Enabled = false;
            txtMail.Enabled = false;
            txtNombre.Enabled = false;
            txtNroPiso.Enabled = false;
            txtNumeroCalle.Enabled = false;
            txtTelefono.Enabled = false;
            chkActivo.Enabled = false;
            cmbTipoDni.Enabled = false;

            btnAceptarACliente.Visible = false;
            btnAceptarMCliente.Visible = false;
            btnAceptarRCliente.Visible = false;
        }
        public void AbrirParaModificar(Cliente unCliente, listadoCliente frmEnviador)
        {
            frmPadre = frmEnviador;
            clienteDelForm = unCliente;
            this.Show();

            txtApellido.Text = unCliente.Apellido;
            txtCalle.Text = unCliente.Dom_calle;
            txtCodPostal.Text = unCliente.Dom_cod_postal;
            txtDepto.Text = unCliente.Dom_depto;
            txtCuil.Text = unCliente.Cuil;
            cmbTipoDni.Text = unCliente.Tipo_Doc;
            txtDni.Text = Convert.ToString(unCliente.Dni);
            txtFechaNac.Text = Convert.ToString(unCliente.Fecha_nac);
            txtLocalidad.Text = unCliente.Dom_ciudad;
            txtMail.Text = unCliente.Mail;
            txtNombre.Text = unCliente.Nombre;
            txtNroPiso.Text = Convert.ToString(unCliente.Dom_piso);
            txtNumeroCalle.Text = Convert.ToString(unCliente.Dom_nro_calle);
            txtTelefono.Text = unCliente.Telefono;
            chkActivo.Checked = unCliente.Activo;

            btnAceptarACliente.Visible = false;
            btnAceptarRCliente.Visible = false;

        }
        public void AbrirParaAgregar(listadoCliente frmEnviador)
        {
            frmPadre = frmEnviador;
            this.Show();

            cmbTipoDni.SelectedIndex = 0;
            txtDni.Enabled = true;

            txtApellido.Text = "";
            txtCalle.Text = "";
            txtCodPostal.Text = "";
            txtDepto.Text = "";
            txtCuil.Text = "";
            txtFechaNac.Text = Convert.ToString(DateTime.Today);
            txtLocalidad.Text = "";
            txtMail.Text = "";
            txtNombre.Text = "";
            txtNroPiso.Text = "";
            txtNumeroCalle.Text = "";
            txtTelefono.Text = "";
            chkActivo.Visible = false;

            btnAceptarMCliente.Visible = false;
            btnAceptarACliente.Visible = true;
            btnAceptarRCliente.Visible = false;
        }
        public void AbrirParaRegistrarNuevoCliente(int id_usuario)
        {
            this.Show();

            cmbTipoDni.SelectedIndex = 0;
            txtDni.Enabled = true;

            txtApellido.Text = "";
            txtCalle.Text = "";
            txtCodPostal.Text = "";
            txtDepto.Text = "";
            txtCuil.Text = "";
            txtFechaNac.Text = Convert.ToString(DateTime.Today);
            txtLocalidad.Text = "";
            txtMail.Text = "";
            txtNombre.Text = "";
            txtNroPiso.Text = "";
            txtNumeroCalle.Text = "";
            txtTelefono.Text = "";
            chkActivo.Visible = false;

            // el id del usuario nuevo que se registro y recibi como parametro lo guardo en mi
            // atributo id_usuario_regustrado
            this.id_usuario_registrado = id_usuario;

            btnAceptarMCliente.Visible = false;
            btnAceptarACliente.Visible = false;
            btnVolver.Visible = false;
            btnAceptarRCliente.Visible = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPadre.CargarListadoDeClientes();
            frmPadre.BringToFront();
            this.Close();
        }
        private void btnAceptarMCliente_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();

                clienteDelForm.Apellido = txtApellido.Text;
                clienteDelForm.Nombre = txtNombre.Text;
                clienteDelForm.Dni = Int32.Parse(txtDni.Text);
                clienteDelForm.Tipo_Doc = cmbTipoDni.Text;
                clienteDelForm.Cuil = txtCuil.Text;
                clienteDelForm.Dom_calle = txtCalle.Text;
                clienteDelForm.Dom_ciudad = txtLocalidad.Text;
                clienteDelForm.Dom_cod_postal = txtCodPostal.Text;
                clienteDelForm.Dom_depto = txtDepto.Text;
                if (!String.IsNullOrEmpty(txtNroPiso.Text)) clienteDelForm.Dom_piso = -1;
                clienteDelForm.Dom_piso = Int32.Parse(txtNroPiso.Text);
                clienteDelForm.Fecha_nac = DateTime.Parse(txtFechaNac.Text);
                clienteDelForm.Mail = txtMail.Text;
                clienteDelForm.Telefono = txtTelefono.Text;
                clienteDelForm.Activo = chkActivo.Checked;

                // despues de setear los atributos al clienteDelForm segun los datos ingresados
                // le pido al cliente se encargue de modificar los datos.

                clienteDelForm.ModificarDatos();
                DialogResult dr = MessageBox.Show("El Cliente ha sido modificado", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                //se vuelve a actualizar la grilla
                frmPadre.CargarListadoDeClientes();
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
        private void btnAceptarACliente_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                Cliente unClienteNuevo = new Cliente();

                unClienteNuevo.Apellido = txtApellido.Text;
                unClienteNuevo.Nombre = txtNombre.Text;
                unClienteNuevo.Dni = Int32.Parse(txtDni.Text);
                unClienteNuevo.Tipo_Doc = cmbTipoDni.Text;
                unClienteNuevo.Cuil = txtCuil.Text;
                unClienteNuevo.Dom_calle = txtCalle.Text;
                unClienteNuevo.Dom_ciudad = txtLocalidad.Text;
                unClienteNuevo.Dom_cod_postal = txtCodPostal.Text;
                unClienteNuevo.Dom_depto = txtDepto.Text;
                unClienteNuevo.Dom_nro_calle = Int32.Parse(txtNumeroCalle.Text);
                if (!String.IsNullOrEmpty(txtNroPiso.Text)) unClienteNuevo.Dom_piso = -1;
                unClienteNuevo.Fecha_nac = DateTime.Parse(txtFechaNac.Text);
                unClienteNuevo.Mail = txtMail.Text;
                unClienteNuevo.Telefono = txtTelefono.Text;
                unClienteNuevo.Usuario = new Usuario();
                unClienteNuevo.Usuario.CrearDefault(Convert.ToString(unClienteNuevo.Dni));
                unClienteNuevo.Activo = true;

                // se instancio un nuevo Cliente y se le setearon todos los atributos segun los datos
                // ingresados. Ahora le pido al cliente que guarde e inserte sus datos en la BD.

                unClienteNuevo.guardarDatosDeClienteNuevo();
                DialogResult dr = MessageBox.Show("El Cliente ha sido creado. Usuario y contraseña del nuevo usuario = " + Convert.ToString(unClienteNuevo.Dni), "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                //se actualiza la grilla
                frmPadre.CargarListadoDeClientes();

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
        private void btnAceptarRCliente_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                Cliente unClienteNuevo = new Cliente();

                unClienteNuevo.Apellido = txtApellido.Text;
                unClienteNuevo.Nombre = txtNombre.Text;
                unClienteNuevo.Dni = Int32.Parse(txtDni.Text);
                unClienteNuevo.Tipo_Doc = cmbTipoDni.Text;
                unClienteNuevo.Cuil = txtCuil.Text;
                unClienteNuevo.Dom_calle = txtCalle.Text;
                unClienteNuevo.Dom_ciudad = txtLocalidad.Text;
                unClienteNuevo.Dom_cod_postal = txtCodPostal.Text;
                unClienteNuevo.Dom_depto = txtDepto.Text;
                if (!String.IsNullOrEmpty(txtNroPiso.Text)) unClienteNuevo.Dom_piso = -1;
                unClienteNuevo.Dom_piso = Int32.Parse(txtNroPiso.Text);
                unClienteNuevo.Fecha_nac = DateTime.Parse(txtFechaNac.Text);
                unClienteNuevo.Mail = txtMail.Text;
                unClienteNuevo.Telefono = txtTelefono.Text;
                unClienteNuevo.Usuario = new Usuario();
                unClienteNuevo.Usuario.CrearDefault(Convert.ToString(unClienteNuevo.Dni));
                unClienteNuevo.Activo = true;

                // Se crea un nuevo Cliente y se le setean los atributos con los datos ingresados.
                // se le pide al cliente que guarden los datos en la BD. Para esto, se manda el id
                // del nuevo usuario ingresado.
                unClienteNuevo.guardarDatosDeClienteNuevoRegistrado(this.id_usuario_registrado);
                DialogResult dr = MessageBox.Show("El Usuario ha sido registrado y el Cliente creado.", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
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
            // lo primero que se hace Luego de ejecutarse el evento Click en los botones "Aceptar"
            // ya sea para alta o modificacion es la validacion de datos
            string strErrores = "";
            strErrores += Validator.ValidarNulo(txtNombre.Text, "Nombre");
            strErrores += Validator.ValidarNulo(txtApellido.Text, "Apellido");
            strErrores += Validator.SoloNumeros(txtDni.Text, "Dni");
            strErrores += Validator.ValidarNulo(txtMail.Text, "Mail");
            strErrores += Validator.ValidarNulo(txtTelefono.Text, "Telefono");
            strErrores += Validator.ValidarNulo(txtCuil.Text, "Cuil");
            strErrores += Validator.validarCuitCuil(txtCuil.Text, "Cuil");
            strErrores += Validator.ValidarNulo(txtCalle.Text, "Calle");
            strErrores += Validator.ValidarNulo(txtNumeroCalle.Text, "Numero de calle");
            strErrores += Validator.SoloNumerosPeroOpcional(txtNroPiso.Text, "Numero de Piso"); 
            strErrores += Validator.ValidarNulo(txtLocalidad.Text, "Localidad");
            strErrores += Validator.ValidarNulo(txtCodPostal.Text, "Código postal");
            strErrores += Validator.ValidarNulo(txtFechaNac.Text, "Fecha de nacimiento"); 
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }     
    }
}
