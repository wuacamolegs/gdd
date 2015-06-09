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
    public partial class frmDetallePublicGeneral : Form
    {
        frmVerPublicaciones frmPadre = new frmVerPublicaciones();
        Publicacion publicDelForm = new Publicacion();
        Usuario unUsuario = new Usuario();
        public frmDetallePublicGeneral()
        {
            InitializeComponent();
        }

        public void AbrirParaVer(Publicacion unaPublic, frmVerPublicaciones frmEnviador, Usuario user)
        {
            //Se abre formulario para visualizar
            frmPadre = frmEnviador;
            publicDelForm = unaPublic;

            this.abrirConUsuario(user);

            lblDescripcionACompletar.Text = unaPublic.Descripcion;
            lblFechaCreacionACompletar.Text = unaPublic.Fecha_creacion.ToString();
            lblFechaVencimientoACompletar.Text = unaPublic.Fecha_vencimiento.ToString();
            lblStockACompletar.Text = unaPublic.Stock.ToString();
            lblUsuarioACompletar.Text = unaPublic.Usuario.Username;
            lblTipoACompletar.Text = unaPublic.Tipo_Publicacion.Nombre;
            lblPrecioACompletar.Text = unaPublic.obtenerPrecioSegunTipo().ToString();
            //valido que pueda comprar u ofertar
            if (puedeComprarUOfertar())
            {
                grpPreguntas.Visible = puedePreguntar();
                //segun el tipo de publicacion, veo que botones mostrarle
                if (publicDelForm.Tipo_Publicacion.Nombre == "Subasta")
                {
                    btnComprar.Visible = false;
                    btnOfertar.Visible = true;
                }
                else
                {
                    btnComprar.Visible = true;
                    btnOfertar.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("No se pueden realizar acciones de compra/oferta. O bien usted no tiene los permisos para ello o bien cuenta con publicaciones pendientes de calificación", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnComprar.Visible = false;
                btnOfertar.Visible = false;
                grpPreguntas.Visible = false;
            }

        }

        private bool puedePreguntar()
        {
            if (publicDelForm.Usuario.Username == unUsuario.Username)
                return false;

            return true;
        }

        private bool puedeComprarUOfertar()
        {
            //puede comprar u ofertar solo si es un cliente y tiene menos de 5 publicaciones pendientes de calificacion
            bool puede = false;
            if (unUsuario.Rol.Nombre == "Cliente" && unUsuario.cantPublicacionesPendientesDeCalificacion() < 5)
                puede = true;
            return puede;
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        private void frmDetallePublicGeneral_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            
            frmPadre.Show();
            this.Close();
        }

        private void btnOfertar_Click(object sender, EventArgs e)
        {
            try
            {
                //primero, valido que no me este autoofertando
                ValidarAutoCompra();
                string montoOfertado = "";
                //hasta que no ingrese un monto ofertado correcto, sigo mostrando el dialog
                while (montoOfertado == "")
                {
                    //creo un dialog pidiendo en un textbox el monto ofertado
                    montoOfertado = DialogManager.ShowDialogCommonText("Por favor, ingrese un monto a ofertar", "Ofertar");

                    if (string.IsNullOrEmpty(montoOfertado))
                    {
                        //aca entra solo si toca aceptar y no ingresa monto
                        MessageBox.Show("Debe ingresar un monto válido", "Monto inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (montoOfertado != "cancel")
                    {
                        string error = ValidarMontoOfertado(montoOfertado);
                        if (error != "")
                        {
                            //si el momnto ingresado es menor al precio de la subasta, le aviso del error
                            //y vuelvo a setear el monto a "", para que la app le vuelva a pedir monto
                            MessageBox.Show(error, "Monto inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            montoOfertado = "";
                        }else{
                            //si el monto es correcto, genero la nueva oferta
                            Oferta nuevaOferta = new Oferta(Convert.ToDecimal(montoOfertado), Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]) ,publicDelForm, unUsuario);
                            nuevaOferta.guardarNuevaOferta();
                            MessageBox.Show("La oferta ha sido realizada", "Oferta realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmPadre.CargarListadoDePublicaciones();
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

        private string ValidarMontoOfertado(string montoOfertado)
        {
            string strErrores = "";
            strErrores += (publicDelForm.obtenerMayorOferta() >= Convert.ToDecimal(montoOfertado)) ? "No se puede realizar esta acción dado que el precio de la subasta es mayor al ingresado" : "";
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

        private void btnComprar_Click(object sender, EventArgs e)
        {
            //Si toca boton comprar, abro formulario con detalle del vendedor, dependiendo de si es empresa
            //o cliente lo abro de uno u otro modo
            DetalleVendedorParaComprar frmDetalleVendedor = new DetalleVendedorParaComprar();
            Cliente unCli = new Cliente(publicDelForm.Usuario);
            if (unCli.id_Cliente ==0)
                frmDetalleVendedor.abrirConEmpresaComoVendedor(unUsuario, this, publicDelForm, frmPadre);
            else
                frmDetalleVendedor.abrirConClienteComoVendedor(unUsuario, this, publicDelForm, frmPadre);

        }

        private void btnRegistrarPregunta_Click(object sender, EventArgs e)
        {
            //Este boton registra preguntas, validando previamente el campo
            try
            {
                ValidarCampos();
                string pregunta = txtPreguntas.Text;

                Pregunta unaPregunta = new Pregunta(pregunta, publicDelForm);

                unaPregunta.GuardarPregunta(unUsuario);
                DialogResult dr = MessageBox.Show("La pregunta ha sido realizada", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    txtPreguntas.Text = "";   
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
            //solo valida que el campo pregunta no sea nulo
            string strErrores = "";
            strErrores += Validator.ValidarNulo(txtPreguntas.Text, "Pregunta");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }
    }
}
