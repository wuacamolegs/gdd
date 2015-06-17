using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.ABM_Rol
{
              
   public partial class frmRol : Form
    {
        listadoRoles frmPadre = new listadoRoles();
        Rol rolDelForm = new Rol();
        public frmRol()
        {
            InitializeComponent();
        }


        public void AbrirParaModificar(Rol unRol, listadoRoles frmEnviador)
        {
            //si se ejecuta esta funcion, significa que llaman al frm para modificar. va a instanciar una
            //variable global llamada rolDelForm, el cual recibiremos por parametro y sera el rol que se ha elegido
            //modificar. Tambien existe una variable global frmPadre, que es el form que llama a este, para poder
            //volver al mismo
            //Configuro todos los campos de este formulario en enabled true, es decir, editables
            frmPadre = frmEnviador;
            rolDelForm = unRol;

            this.Show();

            chkHabilitado.Visible = true;
            chkHabilitado.Checked = unRol.Habilitado;
            chkHabilitado.Enabled = true;

            txtNombre.Text = unRol.Nombre;
            txtNombre.Enabled = true;

            lstFuncDelSist.Visible = true;

            btnAgregar.Visible = true;
            btnEliminar.Visible = true;
            btnCrear.Visible = false;
            btnGuardar.Visible = true;

            cargarListadoDeFuncionalidadesDelRol();
            cargarListadoDeFuncionalidadesDelSistema();
        }

        public void AbrirParaAgregar(listadoRoles frmEnviador)
        {
            //si se ejecuta esta funcion, significa que llaman al frm para crear un nuevo rol. va a instanciar una
            //variable global llamada rolDelForm, el cual quedara instanciado sin datos y se completara cuando el
            //usuario los ingrese. 
            //Tambien existe una variable global frmPadre, que es el form que llama a este, para poder
            //volver al mismo
            //Configuro todos los campos de este formulario en enabled true, es decir, editables
            this.Show();

            txtNombre.Text = "";
            txtNombre.Enabled = true;

            chkHabilitado.Checked = false;
            chkHabilitado.Visible = true;
            chkHabilitado.Enabled = true;

            lstFuncDelSist.Visible = true;
            lstFuncDelRol.Visible = true;

            btnEliminar.Visible = true;
            btnAgregar.Visible = true;
            btnCrear.Visible = true;
            btnCancelar.Visible = true;
            btnGuardar.Visible = false;

            frmPadre = frmEnviador;

            lstFuncDelRol.Items.Clear();
            cargarListadoDeFuncionalidadesDelSistema();

        }


        private void cargarListadoDeFuncionalidadesDelRol()
        {
            //cargo el listado de funcionalidades pertenecientes al rol y le exijo al listado que se muestre solo
            //el nombre de las funciones
            lstFuncDelRol.Items.Clear();
            foreach (Funcionalidad unaFunc in rolDelForm.Funcionalidades)
            {
                lstFuncDelRol.Items.Add(unaFunc);
            }
            lstFuncDelRol.DisplayMember = "Nombre";
            
        }
       
        private void cargarListadoDeFuncionalidadesDelSistema()
        {
            //cargo el listado de funcionalidades no pertenecientes al rol cargadas en el sistema
            //y le exijo al listado que se muestre solo el nombre de las funciones
            lstFuncDelSist.Items.Clear();
            DataSet ds = Funcionalidad.obtenerTodas();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Funcionalidad unaFunc = new Funcionalidad();
                unaFunc.DataRowToObject(dr);
                if(!(contieneLaListaDeFuncionalidadDeRoles(unaFunc)))
                    lstFuncDelSist.Items.Add(unaFunc);
            }
            lstFuncDelSist.DisplayMember = "Nombre";
        }


     
        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }


       
       
       private void btnCrear_Click(object sender, EventArgs e)
        {
            //instancio el rol con los datos ingresados por el usuario y lo creo. luego, vuelvo al formulario que llamo a este
            try
            {
                ValidarCampos();
                string nombre = txtNombre.Text;
                bool habilitado = chkHabilitado.Checked;

                Rol unRolNuevo = new Rol(nombre, habilitado);

                foreach (Funcionalidad unaFunc in lstFuncDelRol.Items)
                {
                    unRolNuevo.Funcionalidades.Add(unaFunc);
                }

                unRolNuevo.guardarDatosDeRolNuevo();
                DialogResult dr = MessageBox.Show("El rol ha sido creado", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                frmPadre.CargarListadoDeRoles();

            }
            catch (EntidadExistenteException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(BadInsertException ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void ValidarCampos()
        {
            //valido que los campos a ingresar no sean nulos. Si lo son, lanzo una excepcion para arriba para que quien llame a esta func controle y devuelva el error obtenido, es decir, que no se ha completado el campo
            string strErrores = "";
            strErrores = Validator.ValidarNulo(txtNombre.Text, "Nombre");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //valido los campos, seteo a los atributos del rol los nuevos campos ingresados por el usuario 
            //(hayan o no cambiado), y realizo la modificacion
            try
            {
                ValidarCampos();
                string nombre = txtNombre.Text;
                bool habilitado = chkHabilitado.Checked;

                rolDelForm.Nombre = nombre;
                rolDelForm.Habilitado = habilitado;

                rolDelForm.Funcionalidades.Clear();
                foreach (Funcionalidad unaFunc in lstFuncDelRol.Items)
                {
                    rolDelForm.Funcionalidades.Add(unaFunc);
                }

                rolDelForm.ModificarDatos();
                DialogResult dr = MessageBox.Show("El rol ha sido modificado", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                frmPadre.CargarListadoDeRoles();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmPadre.CargarListadoDeRoles();
            frmPadre.BringToFront();
            this.Close();
        }


        }
    }
}
