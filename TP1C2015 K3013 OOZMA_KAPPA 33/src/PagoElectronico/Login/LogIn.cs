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
using PagoElectronico.ABM_Cliente;

namespace PagoElectronico.Login
{
    public partial class LogIn : Form
    {
        #region variables

        Int64 intentosFallidos = 0;
        string ultimoUserIngresado = "";
        Int64 maxintentosFallidos = Convert.ToInt64(ConfigurationManager.AppSettings["MaxintentosFallidosLogIn"]);
        Usuario unUsuario = new Usuario();
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
            btnCrearCliente.Visible = false;
        }

        #endregion

        #region acciones_Botones

        private void btnSelecRol_Click(object sender, EventArgs e)
        {
            Rol rolAAsignar = new Rol();
            rolAAsignar.rol_id = Convert.ToInt64(cmbRol.SelectedValue);
            rolAAsignar.Nombre = cmbRol.SelectedText.ToString();
            unUsuario.Rol = rolAAsignar;
            unUsuario.AsignarRol(rolAAsignar);
            AccederAlSistema();
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            //si es administrador muestro boton crear nuevo cliente
            if (Convert.ToInt64(cmbRol.SelectedValue) == 1)
            {
                btnCrearCliente.Visible = true;
            }
        }


        string claveIngresada = "";

        private void btnIngresar_Click(object sender, EventArgs e)
        {//Ahora voy a ver que se haya logueado bien
                     

            //valido que se hayan ingresado los campos en los textbox
            if(ValidarCampos()){
                return;
            }
            
            if(txtUsername.Text == "admin"){
                unUsuario.Username = "123";   //TODO: arreglar tema username
            }
            else{                  
            unUsuario.Username = txtUsername.Text;
            }
            unUsuario.Password = txtPassword.Text;
            

            //si se ingresaron los campos, paso a verificar que el usuario exista y que esta sea su contraseña.
            //verificar si el login es correcto o no
            claveIngresada = Encryptor.GetSHA256(txtPassword.Text); //encripto la clave para luego compararla en la BD

            if (unUsuario.obtenerUsuarioActivoPorUsername())
                {
                    
                    if (unUsuario.Password.Trim() == claveIngresada.Trim())
                    {
                        logAuditoria.EscribirLog(unUsuario.Username, "Exitoso", intentosFallidos);
                        RealizarAccionesLogInExitoso();
                    }
                    else
                    {
                        if (txtUsername.Text != ultimoUserIngresado)  //ultimo user ingresado desde que se inicio la aplicacion
                        {
                            intentosFallidos = 0;   //significa que fue su primer Int64ento fallido
                            ultimoUserIngresado = txtUsername.Text;
                        }
                        intentosFallidos++;
                        logAuditoria.EscribirLog(unUsuario.Username, "Fallido", intentosFallidos);

                        MessageBox.Show("El usuario o clave ingresado es incorrecto. Por favor, ingrese los datos correctamente", "Log In fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        VerificarSiSeAlcanzoLaCantidadMaxima();
                        
                    }
                }
             else
                {
                    intentosFallidos = 0;
                    MessageBox.Show("El usuario es incorrecto o se encuentra bloqueado. Por favor, ingrese los datos nuevamente", "Log In fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            //limpio los Int64entos y voy a la seleccion de rol del usuario
            intentosFallidos = 0;
            MessageBox.Show("Se Accedió al sistema", "Log In exitoso", MessageBoxButtons.OK);
            SeleccionDeRol();
            
        }

        public void SeleccionDeRol()
        {
           
            //Voy a la bd para obtener los roles asociados a este usuario.
            try
            {
                //Obtengo los roles del usuario en cuestion. Si no los hay, muestro mensaje de error. 
                DataSet dsroles = Rol.ObtenerRolesPorUsuario(unUsuario.usuario_id);

                if (dsroles.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("El usuario no tiene roles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Verifico la cantidad de roles del usuario. Si tiene 1, se lo asigno directamente
                    //y lo dejo entrar al sistema.                    
                    if (dsroles.Tables[0].Rows.Count == 1)
                    {
                        unUsuario.AsignarRol(dsroles);
                        AccederAlSistema();        
                    }
                    else
                    {
                        //Si tiene mas de 1 rol, voy a pedirle que seleccione uno
                        btnSelecRol.Visible = true;
                        lblRol.Visible = true;
                        cmbRol.Visible = true;
                        btnIngresar.Visible = false;
                        //Aprovechamos nuestro manager de dropdowns en el proyecto Utilities, y le pedimos que cargue nuestro combo
                        //Con los nombres de los roles. Vamos a poder seleccionar uno de alli

                        DropDownListManager.CargarCombo(cmbRol, dsroles.Tables[0], "rol_id", "rol_nombre", false, "");
                       
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
            if (intentosFallidos == maxintentosFallidos)
            {
                    //Si alcanzo la cantidad maxima de fallidos, deshabilito el usuario y le aviso de esto
                    unUsuario.Deshabilitar();
                    intentosFallidos = 0;
                    MessageBox.Show("El usuario ha quedado deshabilitado por los reiterados fallos en el inicio de sesion", "Deshabilitacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

            }
        }
        
        private void AccederAlSistema()
        {
                Principal princ = new Principal();
                this.Hide();
                princ.abrirConUsuario(unUsuario);
        }

        #endregion


        private void btnCrearCliente_Click(object sender, EventArgs e)
        {
            frmCliente ABMCliente = new frmCliente();
            this.Hide();
            ABMCliente.Show();
            ABMCliente.AbrirParaAgregar();
        }



    }
}
