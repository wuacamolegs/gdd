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

namespace FrbaCommerce.Login
{
    public partial class LogIn : Form
    {
        int intentosFallidos = 0;
        string ultimoUserIngresado = "";
        int maxIntentosFallidos = Convert.ToInt32(ConfigurationManager.AppSettings["MaxIntentosFallidosLogIn"]);
        Usuario user = new Usuario();

        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

            grpRol.Visible = false;
            grpLogIn.Visible = true;
        }   

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string claveIngresada = Encryptor.GetSHA256(txtClave.Text);
            try
            {
                ValidarCampos();
                user.Username = txtUser.Text;

                //voy a la BD a buscar el usuario con los datos ingresados. si lo encuentra, realiza las acciones
                //correspondientes a un logueo exitoso, sino, suma un intento fallido, avisa, y verifica si ya alcanzo
                //la maxima cantidad de intentos fallidos

                if (user.obtenerUsuarioPorUsername())
                {
                    if (user.Clave.Trim() == claveIngresada.Trim())
                    {
                        RealizarAccionesLogInExitoso();
                    }
                    else
                    {
                        if (user.Username != ultimoUserIngresado)
                        {
                            intentosFallidos = 0;
                            ultimoUserIngresado = txtUser.Text;
                        }
                        intentosFallidos++;
                        MessageBox.Show("El usuario o clave ingresado es incorrecto. Por favor, ingrese los datos correctamente", "Log In fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        VerificarSiSeAlcanzoLaCantidadMaxima();
                    }
                }
                else
                {
                    intentosFallidos = 0;
                    MessageBox.Show("El usuario o clave ingresado es incorrecto. Por favor, ingrese los datos correctamente", "Log In fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public void RealizarAccionesLogInExitoso()
        {
            //limpio los intentos y voy a la seleccion de rol del usuario
            intentosFallidos = 0;
            SeleccionDeRol();
            
        }

        public void SeleccionDeRol()
        {
            try
            {
                //Obtengo los roles del usuario en cuestion. Si no los hay, muestro mensaje de error. 
                DataSet ds = Rol.ObtenerRolesPorUsuario(user.Id_Usuario);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("El usuario no tiene roles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Verifico la cantidad de roles del usuario. Si tiene mas de 1, se lo asigno directamente
                    //y lo dejo entrar al sistema.
                    
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        user.AsignarRol(ds);
                        AccederAlSistema();
                    }
                    else
                    {
                        //Si tiene mas de 1 rol, voy a pedirle que seleccione uno
                        MostrarListadoDeRolesASeleccionar(ds);
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


        private void MostrarListadoDeRolesASeleccionar(DataSet ds)
        {
            grpLogIn.Visible = false;
            grpRol.Visible = true;
            //Aprovechamos nuestro manager de dropdowns en el proyecto Utilities, y le pedimos que cargue nuestro combo
            //Con los nombres de los roles. Vamos a poder seleccionar uno de alli
            DropDownListManager.CargarCombo(cmbRoles, ds.Tables[0], "id_Rol", "Nombre", false,"");
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
                catch(NoEntidadException ex)
                {
                    //Significa que el username que esta ingresando no existe, no que se equivoca con la password. 
                    //No deshabilito nada
                    intentosFallidos = 0;
                }
            }
        }

        private void ValidarCampos()
        {
            string strErrores = "";
            strErrores = Validator.ValidarNulo(txtUser.Text, "Usuario");
            strErrores += Validator.ValidarNulo(txtClave.Text, "Clave");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }

        private void btnSelecRol_Click(object sender, EventArgs e)
        {
            Rol rolAAsignar = new Rol();
            rolAAsignar.Id_Rol = Convert.ToInt32(cmbRoles.SelectedValue);
            rolAAsignar.Nombre = cmbRoles.SelectedText.ToString();
            user.Rol = rolAAsignar;
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
                
                string claveNueva =  Encryptor.GetSHA256(dialogResult);
                puedeAcceder = user.CambiarClave(claveNueva);   

            }
            if (puedeAcceder)
            {
                Principal princ = new Principal();
                this.Hide();
                princ.abrirConUsuario(user);
            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnLogIn_Click(sender, e);
            }
        }

        

    }
}
