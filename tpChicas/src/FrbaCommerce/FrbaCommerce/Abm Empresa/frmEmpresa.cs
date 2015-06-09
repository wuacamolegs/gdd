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
//using FrbaCommerce.ABM_Empresa;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class frmEmpresa : Form
    {
        listadoEmpresa frmPadre = new listadoEmpresa();
        Empresa empresaDelForm = new Empresa();
        private int _id_usuario_registrado;
        public frmEmpresa()
        {
            InitializeComponent();
        }
        // necesito esta variable id_usuario_registrado porque cuando abro este form despues
        // de haber registrado un nuevo usuario, necesito guardar el id de este para el insert de 
        // la nueva Empresa
        public int id_usuario_registrado
        {
            get { return _id_usuario_registrado; }
            set { _id_usuario_registrado = value; }
        }

        // Este form se puede abrir para ver los Datos de una Empresa, para modificarlos,
        // para crear uno nuevo(se crea tambien un usuario default) o para registrar una nueva Empresa
        // despues de haber reistrado un usuario. 
        public void AbrirParaVer(Empresa unaEmpresa, listadoEmpresa frmEnviador)
        {
            frmPadre = frmEnviador;
            empresaDelForm = unaEmpresa;
            this.Show();
            txtRazonSocial.Text = unaEmpresa.Razon_social;
            txtCuit.Text = unaEmpresa.Cuit;
            txtNombreContacto.Text = unaEmpresa.Nombre_contacto;
            txtMail.Text = unaEmpresa.Mail;
            txtTelefono.Text = unaEmpresa.Telefono;
            txtCalle.Text = unaEmpresa.Dom_calle;
            txtNumeroCalle.Text = Convert.ToString(unaEmpresa.Dom_nro_calle);
            txtNroPiso.Text = Convert.ToString(unaEmpresa.Dom_piso);
            txtDepto.Text = Convert.ToString(unaEmpresa.Dom_depto);
            txtCodPostal.Text = unaEmpresa.Dom_cod_postal;
            txtLocalidad.Text = unaEmpresa.Dom_ciudad;            
            txtFechaCreacion.Text = Convert.ToString(unaEmpresa.Fecha_creacion);
            chkActivo.Checked = unaEmpresa.Activo;
            
            txtRazonSocial.Enabled = false;
            txtCuit.Enabled = false;
            txtNombreContacto.Enabled = false;
            txtMail.Enabled = false;
            txtTelefono.Enabled = false;
            txtCalle.Enabled = false;
            txtNumeroCalle.Enabled = false;
            txtNroPiso.Enabled = false;
            txtDepto.Enabled = false;
            txtCodPostal.Enabled = false;
            txtLocalidad.Enabled = false;
            txtFechaCreacion.Enabled = false;
            chkActivo.Enabled = false;

            btnAceptarAEmpresa.Visible = false;
            btnAceptarMEmpresa.Visible = false;
            btnAceptarREmpresa.Visible = false;
        }
        public void AbrirParaModificar(Empresa unaEmpresa, listadoEmpresa frmEnviador)
        {
            frmPadre = frmEnviador;
            empresaDelForm = unaEmpresa;
            this.Show();

            txtRazonSocial.Text = unaEmpresa.Razon_social;
            txtCuit.Text = unaEmpresa.Cuit;
            txtNombreContacto.Text = unaEmpresa.Nombre_contacto;
            txtMail.Text = unaEmpresa.Mail;
            txtTelefono.Text = unaEmpresa.Telefono;
            txtCalle.Text = unaEmpresa.Dom_calle;
            txtNumeroCalle.Text = Convert.ToString(unaEmpresa.Dom_nro_calle);
            txtNroPiso.Text = Convert.ToString(unaEmpresa.Dom_piso);
            txtDepto.Text = Convert.ToString(unaEmpresa.Dom_depto);
            txtCodPostal.Text = unaEmpresa.Dom_cod_postal;
            txtLocalidad.Text = unaEmpresa.Dom_ciudad;
            txtFechaCreacion.Text = Convert.ToString(unaEmpresa.Fecha_creacion);
            chkActivo.Checked = unaEmpresa.Activo;

            txtRazonSocial.Enabled = true;
            txtCuit.Enabled = true;
            txtNombreContacto.Enabled = true;
            txtMail.Enabled = true;
            txtTelefono.Enabled = true;
            txtCalle.Enabled = true;
            txtNumeroCalle.Enabled = true;
            txtNroPiso.Enabled = true;
            txtDepto.Enabled = true;
            txtCodPostal.Enabled = true;
            txtLocalidad.Enabled = true;
            txtFechaCreacion.Enabled = true;
            chkActivo.Enabled = true;

            btnAceptarAEmpresa.Visible = false;
            btnAceptarREmpresa.Visible = false;
            
        }
        public void AbrirParaAgregar(listadoEmpresa frmEnviador)
        {
            frmPadre = frmEnviador;
            this.Show();
            txtRazonSocial.Text = "";
            txtCuit.Text = "";
            txtNombreContacto.Text = "";
            txtMail.Text = "";
            txtTelefono.Text = "";
            txtCalle.Text = "";
            txtNumeroCalle.Text = "";
            txtNroPiso.Text = "";
            txtDepto.Text = "";
            txtCodPostal.Text = "";
            txtLocalidad.Text = "";
            txtFechaCreacion.Text = Convert.ToString(DateTime.Today);
            chkActivo.Visible = false;

            btnAceptarMEmpresa.Visible = false;
            btnAceptarAEmpresa.Visible = true;
            btnAceptarREmpresa.Visible = false;
        }
        public void AbrirParaRegistrarNuevaEmpresa(int id_Usuario)
        {
            this.Show();
            txtRazonSocial.Text = "";
            txtCuit.Text = "";
            txtNombreContacto.Text = "";
            txtMail.Text = "";
            txtTelefono.Text = "";
            txtCalle.Text = "";
            txtNumeroCalle.Text = "";
            txtNroPiso.Text = "";
            txtDepto.Text = "";
            txtCodPostal.Text = "";
            txtLocalidad.Text = "";
            txtFechaCreacion.Text = Convert.ToString(DateTime.Today);
            chkActivo.Visible = false;

            // el id del usuario nuevo que se registro y recibi como parametro lo guardo en mi
            // atributo id_usuario_regustrado            
            this.id_usuario_registrado = id_Usuario;

            btnAceptarMEmpresa.Visible = false;
            btnAceptarAEmpresa.Visible = false;
            btnVolver.Visible = false;
            btnAceptarREmpresa.Visible = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPadre.CargarListadoDeEmpresas();
            frmPadre.BringToFront();
            this.Close();
        }
        private void btnAceptarMEmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
               
                empresaDelForm.Razon_social = txtRazonSocial.Text;
                empresaDelForm.Cuit = txtCuit.Text;
                empresaDelForm.Activo = true;
                empresaDelForm.Dom_calle = txtCalle.Text;
                empresaDelForm.Dom_ciudad = txtLocalidad.Text;
                empresaDelForm.Dom_cod_postal = txtCodPostal.Text;
                empresaDelForm.Dom_depto = txtDepto.Text;
                empresaDelForm.Dom_nro_calle = Int32.Parse(txtNumeroCalle.Text);
                if (!String.IsNullOrEmpty(txtNroPiso.Text)) empresaDelForm.Dom_piso = -1;
                empresaDelForm.Fecha_creacion = DateTime.Parse(txtFechaCreacion.Text);
                empresaDelForm.Mail = txtMail.Text;
                empresaDelForm.Nombre_contacto = txtNombreContacto.Text;
                empresaDelForm.Telefono = txtTelefono.Text;
                empresaDelForm.Activo = chkActivo.Checked;

                empresaDelForm.ModificarDatos();
                DialogResult dr = MessageBox.Show("La Empresa ha sido modificada", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                frmPadre.CargarListadoDeEmpresas();
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
        private void btnAceptarAEmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                Empresa unaEmpresaNueva = new Empresa();
                unaEmpresaNueva.Razon_social = txtRazonSocial.Text;
                unaEmpresaNueva.Cuit = txtCuit.Text;
                unaEmpresaNueva.Activo = true;
                unaEmpresaNueva.Dom_calle = txtCalle.Text;
                unaEmpresaNueva.Dom_ciudad = txtLocalidad.Text;
                unaEmpresaNueva.Dom_cod_postal = txtCodPostal.Text;
                unaEmpresaNueva.Dom_depto = txtDepto.Text;              
                unaEmpresaNueva.Dom_nro_calle = Int32.Parse(txtNumeroCalle.Text);
                if (!String.IsNullOrEmpty(txtNroPiso.Text)) unaEmpresaNueva.Dom_piso = -1;
                unaEmpresaNueva.Fecha_creacion = DateTime.Parse(txtFechaCreacion.Text);
                unaEmpresaNueva.Mail = txtMail.Text;
                unaEmpresaNueva.Nombre_contacto = txtNombreContacto.Text;
                unaEmpresaNueva.Telefono = txtTelefono.Text;
                unaEmpresaNueva.Usuario = new Usuario();
                unaEmpresaNueva.Usuario.CrearDefault(unaEmpresaNueva.Cuit);
                unaEmpresaNueva.Activo = true;

                unaEmpresaNueva.guardarDatosDeEmpresaNueva();
                DialogResult dr = MessageBox.Show("La empresa ha sido creada. Usuario y contraseña del nuevo Usuario =" + unaEmpresaNueva.Cuit, "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                frmPadre.CargarListadoDeEmpresas();

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
        private void btnAceptarREmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                Empresa unaEmpresaNueva = new Empresa();
                unaEmpresaNueva.Razon_social = txtRazonSocial.Text;
                unaEmpresaNueva.Cuit = txtCuit.Text;
                unaEmpresaNueva.Activo = true;
                unaEmpresaNueva.Dom_calle = txtCalle.Text;
                unaEmpresaNueva.Dom_ciudad = txtLocalidad.Text;
                unaEmpresaNueva.Dom_cod_postal = txtCodPostal.Text;
                unaEmpresaNueva.Dom_depto = txtDepto.Text;
                unaEmpresaNueva.Dom_nro_calle = Int32.Parse(txtNumeroCalle.Text);
                if (!String.IsNullOrEmpty(txtNroPiso.Text)) unaEmpresaNueva.Dom_piso = -1;
                unaEmpresaNueva.Fecha_creacion = DateTime.Parse(txtFechaCreacion.Text);
                unaEmpresaNueva.Mail = txtMail.Text;
                unaEmpresaNueva.Nombre_contacto = txtNombreContacto.Text;
                unaEmpresaNueva.Telefono = txtTelefono.Text;
                unaEmpresaNueva.Usuario = new Usuario();
                unaEmpresaNueva.Usuario.CrearDefault(unaEmpresaNueva.Cuit);
                unaEmpresaNueva.Activo = true;

                unaEmpresaNueva.guardarDatosDeEmpresaNuevaRegistrada(this.id_usuario_registrado);
                DialogResult dr = MessageBox.Show("El usuario ha sido registrado y la empresa creada.", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            strErrores = Validator.ValidarNulo(txtRazonSocial.Text, "Razon Social");
            strErrores += Validator.ValidarNulo(txtCuit.Text, "Cuit");
            strErrores += Validator.validarCuitCuil(txtCuit.Text, "Cuit");
            strErrores += Validator.ValidarNulo(txtCalle.Text, "Calle");
            strErrores += Validator.ValidarNulo(txtCodPostal.Text, "Codigo Postal");
            strErrores += Validator.ValidarNulo(txtFechaCreacion.Text, "Fecha de Creacion");
            strErrores += Validator.ValidarNulo(txtLocalidad.Text, "Localidad");
            strErrores += Validator.ValidarNulo(txtMail.Text, "Mail");
            strErrores += Validator.ValidarNulo(txtNombreContacto.Text, "Nombre del Contacto");
            strErrores += Validator.ValidarNulo(txtTelefono.Text, "Telefono");
            strErrores += Validator.SoloNumerosPeroOpcional(txtNroPiso.Text, "Numero de Piso");
            strErrores += Validator.SoloNumeros(txtNumeroCalle.Text, "Numero de Calle");             
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }
        
    }
}
