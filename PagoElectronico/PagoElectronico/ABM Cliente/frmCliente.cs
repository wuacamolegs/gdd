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

namespace PagoElectronico.ABM_Cliente
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        ListadoCliente frmPadre = new ListadoCliente(); /* CAMBIE ListadoCliente por frmCliente, en el tp de los chicos descia listado, total hace un inicialiteComponent y es lo mismo*/
        Cliente clienteDelForm = new Cliente();
        private int _id_usuario_registrado;

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
        public void AbrirParaVer(Cliente unCliente, ListadoCliente frmEnviador)
        {
            frmPadre = frmEnviador;
            clienteDelForm = unCliente;

            this.Show();

            txtNombre.Text = unCliente.Nombre;
            txtApellido.Text = unCliente.Apellido;
            cmbDNI.Text = unCliente.TipoDocumento;
            txtDNI.Text = Convert.ToString(unCliente.Documento);
            txtMail.Text = unCliente.Mail;
            txtCalle.Text = unCliente.Calle;
            txtDepto.Text = unCliente.DeptoDireccion;
            txtPiso.Text = unCliente.PisoDireccion.ToString();
            txtNumero.Text = unCliente.NumeroDireccion.ToString();
            txtPais.Text = unCliente.PaisResidente.ToString();
            txtFechaNac.Text = unCliente.FechaNacimiento.ToString();

            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            cmbDNI.Enabled = false;
            txtDNI.Enabled = false;
            txtMail.Enabled = false;
            txtCalle.Enabled = false;
            txtDepto.Enabled = false;
            txtPiso.Enabled = false;
            txtNumero.Enabled = false;
            txtPais.Enabled = false;
            txtFechaNac.Enabled = false;

            btnAceptarACliente.Visible = false;
            btnAceptarMCliente.Visible = false;
            btnAceptarRCliente.Visible = false;
        }
        public void AbrirParaModificar(Cliente unCliente, ListadoCliente frmEnviador)
        {
            frmPadre = frmEnviador;
            clienteDelForm = unCliente;
            this.Show();

            txtNombre.Text = unCliente.Nombre;
            txtApellido.Text = unCliente.Apellido;
            cmbDNI.Text = unCliente.TipoDocumento;
            txtMail.Text = unCliente.Mail;
            txtCalle.Text = Convert.ToString(unCliente.Calle);
            txtDepto.Text = unCliente.DeptoDireccion;
            txtPiso.Text = Convert.ToString(unCliente.PisoDireccion);
            txtNumero.Text = Convert.ToString(unCliente.NumeroDireccion);
            txtPais.Text = Convert.ToString(unCliente.PaisResidente);
            txtFechaNac.Text = unCliente.FechaNacimiento.ToString();


            btnAceptarACliente.Visible = false;
            btnAceptarRCliente.Visible = false;

        }
        public void AbrirParaAgregar(ListadoCliente frmEnviador)
        {
            frmPadre = frmEnviador;
            this.Show();

            cmbDNI.SelectedIndex = 0;
            txtDNI.Enabled = true;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtMail.Text = "";
            txtCalle.Text = "";
            txtDepto.Text = "";
            txtPiso.Text = "";
            txtNumero.Text = "";
            txtFechaNac.Text = Convert.ToString(DateTime.Today);
            txtPais.Text = "";
            chkActivo.Visible = false;

            btnAceptarMCliente.Visible = false;
            btnAceptarACliente.Visible = true;
            btnAceptarRCliente.Visible = false;
        }
        public void AbrirParaRegistrarNuevoCliente(int id_usuario)
        {
            this.Show();

            cmbDNI.SelectedIndex = 0;
            txtDNI.Enabled = true;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtMail.Text = "";
            txtCalle.Text = "";
            txtDepto.Text = "";
            txtPiso.Text = "";
            txtNumero.Text = "";
            txtFechaNac.Text = Convert.ToString(DateTime.Today);
            txtPais.Text = "";
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
                clienteDelForm.Documento = Int32.Parse(txtDNI.Text);
                clienteDelForm.TipoDocumento = cmbDNI.Text;
                clienteDelForm.Calle = txtCalle.Text;
                clienteDelForm.PaisResidente = Convert.ToInt32(txtPais.Text);
                clienteDelForm.DeptoDireccion = txtDepto.Text;
                clienteDelForm.NumeroDireccion = Convert.ToInt32(txtCalle.Text);
                if (!String.IsNullOrEmpty(txtPiso.Text)) clienteDelForm.PisoDireccion = -1;
                clienteDelForm.PisoDireccion = Int32.Parse(txtPiso.Text);
                clienteDelForm.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                clienteDelForm.Mail = txtMail.Text;
                clienteDelForm.Estado = chkActivo.Checked;

                // despues de setear los atributos al clienteDelForm segun los datos ingresados
                // le pido al cliente se encargue de modificar los datos.

                clienteDelForm.ModificarDatos(); /* TODO VER */
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
                unClienteNuevo.Documento = Int32.Parse(txtDNI.Text);
                unClienteNuevo.TipoDocumento = cmbDNI.Text;
                unClienteNuevo.Calle = txtCalle.Text;
                unClienteNuevo.PaisResidente = Convert.ToInt32(txtPais.Text);
                unClienteNuevo.NumeroDireccion = Convert.ToInt32(txtNumero.Text);
                unClienteNuevo.DeptoDireccion = txtDepto.Text;
                if (!String.IsNullOrEmpty(txtPiso.Text)) unClienteNuevo.PisoDireccion = -1;
                unClienteNuevo.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                unClienteNuevo.Mail = txtMail.Text;
                unClienteNuevo.Usuario = new Usuario();
                unClienteNuevo.Usuario.CrearDefault(Convert.ToString(unClienteNuevo.Documento));
                unClienteNuevo.Estado = true;

                // se instancio un nuevo Cliente y se le setearon todos los atributos segun los datos
                // ingresados. Ahora le pido al cliente que guarde e inserte sus datos en la BD.

                unClienteNuevo.guardarDatosDeClienteNuevo();
                DialogResult dr = MessageBox.Show("El Cliente ha sido creado. Usuario y contraseña del nuevo usuario = " + Convert.ToString(unClienteNuevo.Documento), "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                unClienteNuevo.TipoDocumento = cmbDNI.Text;
                unClienteNuevo.Documento = Int32.Parse(txtDNI.Text);
                unClienteNuevo.Mail = txtMail.Text;
                unClienteNuevo.Calle = txtCalle.Text;
                unClienteNuevo.DeptoDireccion = txtDepto.Text;
                if (!String.IsNullOrEmpty(txtPiso.Text)) unClienteNuevo.PisoDireccion = -1;
                unClienteNuevo.PaisResidente = Convert.ToInt32(txtPais.Text);
                unClienteNuevo.PisoDireccion = Int32.Parse(txtPiso.Text);
                unClienteNuevo.NumeroDireccion = Convert.ToInt32(txtNumero.Text);
                unClienteNuevo.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);

                unClienteNuevo.Usuario = new Usuario();
                unClienteNuevo.Usuario.CrearDefault(Convert.ToString(unClienteNuevo.Documento));
                unClienteNuevo.Estado = true;

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
            strErrores += Validator.SoloNumeros(txtDNI.Text, "Dni");
            strErrores += Validator.ValidarNulo(txtMail.Text, "Mail");
            strErrores += Validator.ValidarNulo(txtCalle.Text, "Calle");
            strErrores += Validator.ValidarNulo(txtNumero.Text, "Numero de calle");
            strErrores += Validator.SoloNumerosPeroOpcional(txtPiso.Text, "Numero de Piso");
            strErrores += Validator.ValidarNulo(txtPais.Text, "Pais");
            strErrores += Validator.ValidarNulo(txtFechaNac.Text, "Fecha de nacimiento");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }
       
    }
}
