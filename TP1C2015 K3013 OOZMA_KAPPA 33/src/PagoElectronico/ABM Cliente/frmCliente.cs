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
using Conexion;
using System.Configuration;

namespace PagoElectronico.ABM_Cliente
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        ListadoCliente frmPadre = new ListadoCliente(); 
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
            cmbDNI.SelectedValue = unCliente.TipoDocumento;
            txtDNI.Text = Convert.ToString(unCliente.Documento);
            txtMail.Text = unCliente.Mail;
            txtCalle.Text = unCliente.Calle;
            txtDepto.Text = unCliente.DeptoDireccion;
            txtPiso.Text = unCliente.PisoDireccion.ToString();
            txtNumero.Text = unCliente.NumeroDireccion.ToString();
            cmbPais.SelectedValue = unCliente.PaisResidente;
            cmbAnio.SelectedValue = unCliente.FechaNacimiento.Year.ToString();
            cmbMes.SelectedValue = unCliente.FechaNacimiento.Month.ToString();
            cmbDia.SelectedValue = unCliente.FechaNacimiento.Day.ToString();


            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            cmbDNI.Enabled = false;
            txtDNI.Enabled = false;
            txtMail.Enabled = false;
            txtCalle.Enabled = false;
            txtDepto.Enabled = false;
            txtPiso.Enabled = false;
            txtNumero.Enabled = false;
            cmbPais.Enabled = false;
            cmbAnio.Enabled = false;
            cmbDia.Enabled = false;
            cmbMes.Enabled = false;

            btnAceptarACliente.Visible = false;
            btnModificar.Visible = false;
        }
        public void AbrirParaModificar(Cliente unCliente, ListadoCliente frmEnviador)
        {
            txtPassword.Visible = false;
            txtRespuesta.Visible = false;
            txtRespuesta.Visible = false;
            gbUsuario.Visible = false;
            chkActivo.Visible = true;
            txtDNI.Enabled = false;
            cmbAnio.Enabled = false;
            cmbDia.Enabled = false;
            cmbMes.Enabled = false;
            cmbDNI.Enabled = false;
           

            //Cargar combo tipo dni y combo pais
            DataSet dsTipoDNI = SQLHelper.ExecuteDataSet("TraerListadoTipoDocumento");
            DataSet dsPais = SQLHelper.ExecuteDataSet("traerListadoPaisesCompleto");

            DropDownListManager.CargarCombo(cmbDNI, dsTipoDNI.Tables[0], "td_id", "td_descripcion", false, "");
            DropDownListManager.CargarCombo(cmbPais, dsPais.Tables[0], "pais_id", "pais_nombre", false, "");

            frmPadre = frmEnviador;
            clienteDelForm = unCliente;

            this.Show();
            
            txtNombre.Text = unCliente.Nombre;
            txtApellido.Text = unCliente.Apellido;
            cmbDNI.SelectedValue =  unCliente.TipoDocumento;
            txtDNI.Text = Convert.ToString(unCliente.Documento);
            txtMail.Text = unCliente.Mail;
            txtCalle.Text = Convert.ToString(unCliente.Calle);
            txtDepto.Text = unCliente.DeptoDireccion;
            txtPiso.Text = Convert.ToString(unCliente.PisoDireccion);
            txtNumero.Text = Convert.ToString(unCliente.NumeroDireccion);
            cmbPais.SelectedValue = unCliente.PaisResidente;

            cmbPais.SelectedValue = unCliente.PaisResidente;
            cmbAnio.SelectedValue = unCliente.FechaNacimiento.Year.ToString();
            cmbMes.SelectedValue = unCliente.FechaNacimiento.Month.ToString();
            cmbDia.SelectedValue = unCliente.FechaNacimiento.Day.ToString();


            cmbDNI.SelectedValue = unCliente.TipoDocumento;
            cmbPais.SelectedValue = Convert.ToInt32(unCliente.PaisResidente);


            btnAceptarACliente.Visible = false;
            btnModificar.Visible = true;

        }

        public void AbrirParaAgregar()
        {
            this.Show();


            chkActivo.Visible = false;
            linkTarjetas.Visible = false;


            cmbDNI.SelectedIndex = -1;
            txtDNI.Enabled = true;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtMail.Text = "";
            txtCalle.Text = "";
            txtDepto.Text = "";
            txtPiso.Text = "";
            txtNumero.Text = "";
            cmbAnio.SelectedIndex = -1;
            cmbDia.SelectedIndex = -1;
            cmbMes.SelectedIndex = -1;
            cmbPais.SelectedIndex = -1;
            lblestado.Visible = false;

            //Cargar combo tipo dni y combo pais
            DataSet dsTipoDNI = SQLHelper.ExecuteDataSet("TraerListadoTipoDocumento");
            DataSet dsPais = SQLHelper.ExecuteDataSet("traerListadoPaisesCompleto");
            DropDownListManager.CargarCombo(cmbDNI, dsTipoDNI.Tables[0], "td_id", "td_descripcion", false, "");
            cmbDNI.SelectedIndex = -1;
            DropDownListManager.CargarCombo(cmbPais, dsPais.Tables[0], "pais_id", "pais_nombre", false, "");
            cmbPais.SelectedIndex = -1;

           btnModificar.Visible = false;
           btnAceptarACliente.Visible = true;

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
            strErrores += Validator.ValidarNulo(cmbPais.Text, "Pais");
            strErrores += Validator.ValidarNulo(txtCalle.Text, "Calle");
            strErrores += Validator.ValidarNulo(txtNumero.Text, "Numero");
            strErrores += Validator.SoloNumerosPeroOpcional(txtPiso.Text, "Piso");
            strErrores += Validator.ValidarNulo(txtDepto.Text, "Depto");
            if (cmbMes.SelectedIndex == -1 || cmbAnio.SelectedIndex == -1 || cmbDia.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese una fecha valida", "Error Fechas");
            }
            else
            {
                if (strErrores.Length > 0)
                {
                    throw new Exception(strErrores);
                }
            }
        }

        private void linkTarjetas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            abm_tarjetas frmTarjeta = new abm_tarjetas();
            frmTarjeta.abrirConCliente(clienteDelForm);
            frmTarjeta.Show();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();


                Cliente unClienteNuevo = new Cliente();
                clienteDelForm.Apellido = txtApellido.Text;
                clienteDelForm.Nombre = txtNombre.Text;
                clienteDelForm.Documento = Int32.Parse(txtDNI.Text);
                clienteDelForm.TipoDocumento = Convert.ToInt64(cmbDNI.SelectedValue);
                clienteDelForm.Calle = txtCalle.Text;
                clienteDelForm.PaisResidente = Convert.ToInt32(cmbPais.SelectedValue);
                clienteDelForm.NumeroDireccion = Convert.ToInt32(txtNumero.Text);
                clienteDelForm.DeptoDireccion = txtDepto.Text;
                if (!String.IsNullOrEmpty(txtPiso.Text)) clienteDelForm.PisoDireccion = -1;
                clienteDelForm.PisoDireccion = Int32.Parse(txtPiso.Text);
                clienteDelForm.FechaString = cmbAnio.Text + "/" + cmbMes.Text + "/" +  cmbDia.Text;

                clienteDelForm.Mail = txtMail.Text;
                clienteDelForm.estado = chkActivo.Checked;

                // despues de setear los atributos al clienteDelForm segun los datos ingresados
                // le pido al cliente se encargue de modificar los datos.

                clienteDelForm.ModificarDatos();
                DialogResult dr = MessageBox.Show("El Cliente ha sido modificado", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();

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
                clienteDelForm.Apellido = txtApellido.Text;
                clienteDelForm.Nombre = txtNombre.Text;
                clienteDelForm.Documento = Int32.Parse(txtDNI.Text);
                clienteDelForm.TipoDocumento = Convert.ToInt64(cmbDNI.SelectedValue);
                clienteDelForm.Calle = txtCalle.Text;
                clienteDelForm.PaisResidente = Convert.ToInt32(cmbPais.SelectedValue);
                clienteDelForm.NumeroDireccion = Convert.ToInt32(txtNumero.Text);
                clienteDelForm.DeptoDireccion = txtDepto.Text;
                if (!String.IsNullOrEmpty(txtPiso.Text)) clienteDelForm.PisoDireccion = -1;
                clienteDelForm.PisoDireccion = Int32.Parse(txtPiso.Text);
                clienteDelForm.Mail = txtMail.Text;
                clienteDelForm.estado = chkActivo.Checked;
  

                clienteDelForm.FechaString = cmbAnio.Text + "/" + cmbMes.Text + "/" + cmbDia.Text;

                Usuario unUsuarioNuevo = new Usuario();
                unClienteNuevo.Usuario = unUsuarioNuevo;
                unUsuarioNuevo.Respuesta_Secreta =  Encryptor.GetSHA256(txtRespuesta.Text);
                unUsuarioNuevo.Pregunta_Secreta = txtPregunta.Text;
                unUsuarioNuevo.Username = txtDNI.Text;
                unUsuarioNuevo.NombreApellido = txtNombre.Text + " " + txtApellido.Text;
                unUsuarioNuevo.FechaCreacion = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);               
                unUsuarioNuevo.FechaModificacion = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);
                unUsuarioNuevo.Password = Encryptor.GetSHA256(txtPassword.Text);

                // se instancio un nuevo Cliente y se le setearon todos los atributos segun los datos
                // ingresados. Ahora le pido al cliente que guarde e inserte sus datos en la BD.
                // Creo su usuario asociado

                unClienteNuevo.guardarDatosDeClienteNuevo(unUsuarioNuevo);
                this.Close();

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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloLetras(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloLetras(e);
        }

        private void txtPregunta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.SoloLetras(e);
        }









    }
}

 