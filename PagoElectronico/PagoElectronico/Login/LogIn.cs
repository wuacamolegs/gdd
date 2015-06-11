using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.VisualBasic;
using Clases;
using Excepciones;
using Utilities;
using Conexion;
using Log;

namespace PagoElectronico.Login
{
    public partial class LogIn : Form
    {
        #region variables

        int intentosFallidos = 0;
        string ultimoUserIngresado = "";
        int maxIntentosFallidos = Convert.ToInt32(ConfigurationManager.AppSettings["MaxIntentosFallidosLogIn"]);
        Usuario user = new Usuario();
        FSLogger logAuditoria; 

        #endregion


        #region inicializar

        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            logAuditoria = new FSLogger("LogInAuditoria");  //Creo archivo log con nombre LogInAuditoria, en la ruta actual
            btnSelecRol.Visible = false;
            lblRol.Visible = false;     //oculto botones de eleccion Rol. una vez que se loguea correctamente elije el rol.
            cmbRol.Visible = false;
        }

        #endregion

        #region acciones_Botones

        private void btnSelecRol_Click(object sender, EventArgs e)
        {

        }
        string claveIngresada = "";

        private void btnIngresar_Click(object sender, EventArgs e)
        {//Ahora voy a ver que se haya logueado bien
                     

            //valido que se hayan ingresado los campos en los textbox
            if(ValidarCampos()){
                return;
            }
            
            if(txtUsername.Text == "admin"){
                user.Username = "123";
            }
            else{
            user.Username = txtUsername.Text;}
            user.Password = txtPassword.Text;
            

            //si se ingresaron los campos, paso a verificar que el usuario exista y que esta sea su contraseña.
            //verificar si el login es correcto o no
            claveIngresada = Encryptor.GetSHA256(txtPassword.Text); //encripto la clave para luego compararla en la BD

            if (user.obtenerUsuarioActivoPorUsername())
                {
                    
                    if (user.Password.Trim() == claveIngresada.Trim())
                    {
                        logAuditoria.EscribirLog(user.Username, "Exitoso", intentosFallidos);
                        RealizarAccionesLogInExitoso();
                    }
                    else
                    {
                        if (txtUsername.Text != ultimoUserIngresado)  //ultimo user ingresado desde que se inicio la aplicacion
                        {
                            intentosFallidos = 0;   //significa que fue su primer intento fallido
                            ultimoUserIngresado = txtUsername.Text;
                        }
                        intentosFallidos++;
                        logAuditoria.EscribirLog(user.Username, "Fallido", intentosFallidos);

                        MessageBox.Show("El usuario o clave ingresado es incorrecto. Por favor, ingrese los datos correctamente", "Log In fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        VerificarSiSeAlcanzoLaCantidadMaxima();
                        
                    }
                }
             else
                {
                    intentosFallidos = 0;
                    MessageBox.Show("El usuario es incorrecto. Por favor, ingrese los datos correctamente", "Log In fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
        }


        #endregion

        
        #region metodosPrivados

        //Se fija que se hayan ingresado bien los campos de username y password
        private bool ValidarCampos()
        {
            string strErrores = "";
            string strErrores2 = "";
            strErrores = Validator.ValidarNulo(txtUsername.Text, "Username");
            strErrores2 = Validator.ValidarNulo(txtPassword.Text, "Password");
            if (strErrores.Length + strErrores2.Length > 0)
            {
                MessageBox.Show(strErrores + strErrores2);
                txtUsername.Clear();
                txtPassword.Clear();
                return true;
            }
            return false;
        }


        public void RealizarAccionesLogInExitoso()
        {
            //limpio los intentos y voy a la seleccion de rol del usuario
            intentosFallidos = 0;
            MessageBox.Show("Se Accedió al sistema, Por favor selecione un rol", "Log In exitoso", MessageBoxButtons.OK);
            SeleccionDeRol();
            
        }

        public void SeleccionDeRol()
        {
           
            //Voy a la bd para obtener los roles asociados a este usuario.
            try
            {
                //Obtengo los roles del usuario en cuestion. Si no los hay, muestro mensaje de error. 
                DataSet ds = Rol.ObtenerRolesPorUsuario(user.usuario_id);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("El usuario no tiene roles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Verifico la cantidad de roles del usuario. Si tiene 1, se lo asigno directamente
                    //y lo dejo entrar al sistema.
                    
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        user.AsignarRol(ds);
                        AccederAlSistema();
                    }
                    else
                    {
                        //Si tiene mas de 1 rol, voy a pedirle que seleccione uno
          
                        btnSelecRol.Visible = true;
                        lblRol.Visible = true;
                        cmbRol.Visible = true;
                        btnIngresar.Visible = false;
                        
                    }
                }
                
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void VerificarSiSeAlcanzoLaCantidadMaxima()
        {
            if (intentosFallidos == maxIntentosFallidos)
            {
                try
                {
                    //Si alcanzo la cantidad maxima de fallidos, deshabilito el usuario y le aviso de esto
                    user.Deshabilitar();
                    intentosFallidos = 0;
                    MessageBox.Show("El usuario ha quedado deshabilitado por los reiterados fallos en el inicio de sesion", "Deshabilitacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (NoEntidadException ex)
                {
                    //Significa que el username que esta ingresando no existe, no que se equivoca con la password. 
                    //No deshabilito nada
                    intentosFallidos = 0;
                }
            }
        }



        private void AccederAlSistema()
        {
            //Verifico que la clave no sea la autogenerada. De ser asi, le pido que la cambie. Sino, via libre para 
            //acceder al sistema
            bool puedeAcceder = true;
            if (user.ClaveAutoGenerada)
            {

                //En el proyecto utilities, creamos un dialog manager que nos permite crear un formulario
                //del tipo dialog. Lo que quisimos modelar fue una especie de pop up que le mandemos un texto,
                //nos ofrezca un textbox y nos devuelta el resultado ingresado por el usuario. En este caso,
                //le vamos a decir que su pass fue autogenerada y que la cambie. Si no ingreso nada, lo deshabilitamos.
                //Sino, la encriptamos y updateamos la password
                string dialogResult = DialogManager.ShowDialogWithPassword("Este es su primer ingreso en el sistema, por favor, actualice su clave", "Cambio de clave");

                if (string.IsNullOrEmpty(dialogResult))
                {
                    user.Deshabilitar();
                    MessageBox.Show("El usuario ha quedado deshabilitado", "Deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string claveNueva = Encryptor.GetSHA256(dialogResult);
                puedeAcceder = user.CambiarClave(claveNueva);

            }
            if (puedeAcceder)
            {
                Principal princ = new Principal();
                this.Hide();
                princ.abrirConUsuario(user);
            }
        }




        #endregion



    }
}
