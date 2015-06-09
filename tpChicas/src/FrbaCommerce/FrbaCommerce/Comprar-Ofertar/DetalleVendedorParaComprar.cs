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
using System.Configuration;


namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class DetalleVendedorParaComprar : Form
    {
        frmDetallePublicGeneral frmPadre = new frmDetallePublicGeneral();
        frmVerPublicaciones frmPadrePrincipal = new frmVerPublicaciones();
        Usuario unUsuario = new Usuario();
        Publicacion publicDelForm = new Publicacion();

        public DetalleVendedorParaComprar()
        {
            InitializeComponent();
        }

        public void abrirConClienteComoVendedor(Usuario user, frmDetallePublicGeneral frmEnviador, Publicacion unaPublic, frmVerPublicaciones frmPrincipal)
        {
            //llena los campos del cliente y oculta los de la empresa
            unUsuario = user;
            publicDelForm = unaPublic;
            frmPadre = frmEnviador;
            frmPadrePrincipal = frmPrincipal;
            lblNombre.Visible = true;
            lblApellido.Visible = true;
            lblCuil.Visible = true;
            lblDni.Visible = true;
            lblTipoDoc.Visible = true;
            lblNombreACompletar.Visible = true;
            lblApellidoACompletar.Visible = true;
            lblCuilACompletar.Visible = true;
            lblDniACompletar.Visible = true;
            lblTipoDocumentoACompletar.Visible = true;
            lblFechaNac.Visible = true;
            lblFechaNacACompletar.Visible = true;

            Cliente unClienteVendedor = new Cliente(publicDelForm.Usuario);
            lblNombreACompletar.Text = unClienteVendedor.Nombre;
            lblApellidoACompletar.Text = unClienteVendedor.Apellido;
            lblTipoDocumentoACompletar.Text = unClienteVendedor.Tipo_Doc;
            lblDniACompletar.Text = unClienteVendedor.Dni.ToString();
            lblFechaNacACompletar.Text = unClienteVendedor.Fecha_nac.ToString().Substring(0,10);
            lblCuilACompletar.Text = unClienteVendedor.Cuil;
            
            //datos comunes
            lblCalleACompletar.Text = unClienteVendedor.Dom_calle;
            lblNumeroACompletar.Text = unClienteVendedor.Dom_nro_calle.ToString();
            lblNroPisoACompletar.Text = (!string.IsNullOrEmpty(unClienteVendedor.Dom_piso.ToString())) ? unClienteVendedor.Dom_piso.ToString() : "";//como este campo puede ser nulo, si lo es, no le asigno valor la txt
            lblDeptoACompletar.Text = (!string.IsNullOrEmpty(unClienteVendedor.Dom_depto)) ? unClienteVendedor.Dom_depto.ToString() : ""; //como este campo puede ser nulo, si lo es, no le asigno valor la txt
            lblCodPostalACompletar.Text = unClienteVendedor.Dom_cod_postal.ToString();
            lblMailACompletar.Text = unClienteVendedor.Mail;
            lblTelefonoACompletar.Text = unClienteVendedor.Telefono;
            lblReputacionACompletar.Text = unClienteVendedor.Reputacion.ToString();

            lblRazonSocial.Visible = false;
            lblCuit.Visible  = false;
            lblFechaCreacion.Visible = false;
            lblNombreContacto.Visible = false;
            lblNombreContactoACompletar.Visible = false;

            this.Show();

        }

        public void abrirConEmpresaComoVendedor(Usuario user, frmDetallePublicGeneral frmEnviador, Publicacion unaPublic, frmVerPublicaciones frmPrincipal)
        {
            //llena los campos de la empresa y oculta los del cliente
            unUsuario = user;
            publicDelForm = unaPublic;
            frmPadre = frmEnviador;
            frmPadrePrincipal = frmPrincipal;
            
            lblNombre.Visible = false;
            lblApellido.Visible = false;
            lblCuil.Visible = false;
            lblDni.Visible = false;
            lblTipoDoc.Visible = false;
            lblNombreACompletar.Visible = false;
            lblApellidoACompletar.Visible = false;
            lblCuilACompletar.Visible = false;
            lblDniACompletar.Visible = false;
            lblTipoDocumentoACompletar.Visible = false;
            lblFechaNac.Visible = false;
            lblFechaNacACompletar.Visible = false;

            Empresa unaEmpresaVendedora = new Empresa(publicDelForm.Usuario);
            lblRazonSocialACompletar.Text = unaEmpresaVendedora.Razon_social;
            lblCuitACompletar.Text = unaEmpresaVendedora.Cuit;
            lblNombreContactoACompletar.Text = unaEmpresaVendedora.Nombre_contacto;
            lblFechaCreacionACompletar.Text = unaEmpresaVendedora.Fecha_creacion.ToString().Substring(0, 10);
            
            //datos comunes
            lblCalleACompletar.Text = unaEmpresaVendedora.Dom_calle;
            lblNumeroACompletar.Text = unaEmpresaVendedora.Dom_nro_calle.ToString();
            lblNroPisoACompletar.Text = (!string.IsNullOrEmpty(unaEmpresaVendedora.Dom_piso.ToString())) ? unaEmpresaVendedora.Dom_piso.ToString() : "";//como este campo puede ser nulo, si lo es, no le asigno valor la txt
            lblDeptoACompletar.Text = (!string.IsNullOrEmpty(unaEmpresaVendedora.Dom_depto)) ? unaEmpresaVendedora.Dom_depto.ToString() : "";//como este campo puede ser nulo, si lo es, no le asigno valor la txt
            lblCodPostalACompletar.Text = unaEmpresaVendedora.Dom_cod_postal.ToString();
            lblMailACompletar.Text = unaEmpresaVendedora.Mail;
            lblTelefonoACompletar.Text = unaEmpresaVendedora.Telefono;
            lblReputacionACompletar.Text = unaEmpresaVendedora.Reputacion.ToString();

            lblRazonSocial.Visible = true;
            lblCuit.Visible  = true;
            lblFechaCreacion.Visible = true;
            lblNombreContacto.Visible = true;
            lblNombreContactoACompletar.Visible = true;
            this.Show();
        }

        private void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                //valido que no me este autocomprando
                ValidarAutoCompra();
                string cantidadIngresada = "";
                //realizo el mismo procedimiento que con el ofertar, voy a crear un dialog hasta que la cantidad
                //ingresada a comprar sea correcta, es decir, no sea nula y sea menor al stock. le ofrezo un boton
                //cancelar, por si se arrepiente
                while (cantidadIngresada == "")
                {
                    cantidadIngresada = DialogManager.ShowDialogCommonText("Por favor, ingrese cantidad a comprar", "Comprar");

                    if (string.IsNullOrEmpty(cantidadIngresada))
                    {
                        MessageBox.Show("Debe ingresar una cantidad válido", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (cantidadIngresada != "cancel")
                    {
                        string error = ValidarCantidadIngresada(cantidadIngresada);
                        if (error != "")
                        {
                            MessageBox.Show(error, "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cantidadIngresada = "";
                        }
                        else
                        {
                            //si ingreso una cantidad correcta, se crea la nueva compra
                            Compra nuevaCompra = new Compra(Convert.ToInt32(cantidadIngresada), Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]), publicDelForm, unUsuario);
                            nuevaCompra.guardarNuevaCompra();
                            publicDelForm.descontarStock(Convert.ToInt32(cantidadIngresada));
                            MessageBox.Show("La compra ha sido realizada", "Compra realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //cierro los forms y refreso el listado de publicaciones en el listado padre
                            frmPadrePrincipal.CargarListadoDePublicaciones();
                            frmPadre.Close();
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ValidarCantidadIngresada(string cantidadIngresada)
        {
            string strErrores = "";
            strErrores += (publicDelForm.Stock < Convert.ToInt32(cantidadIngresada)) ? "No se puede realizar esta acción dado que el stock es menor a la cantidad pedida" : "";
            if (strErrores.Length > 0)
            {
                return strErrores;
            }
            return "";

        }

        private void ValidarAutoCompra()
        {
            string strErrores = "";
            strErrores += (publicDelForm.Usuario.Id_Usuario == unUsuario.Id_Usuario) ? "No se puede realizar esta acción sobre su propia publicación" : "";
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }


    }
}
