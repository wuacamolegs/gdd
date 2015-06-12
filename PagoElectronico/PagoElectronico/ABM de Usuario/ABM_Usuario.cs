using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Utilities;
using Conexion;

namespace PagoElectronico.ABM_de_Usuario
{
    public partial class ABM_Usuario : Form
    {
        public Usuario unUsuario = new Usuario();

        public ABM_Usuario()
        {
            InitializeComponent();
        }
     
        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        private void ABM_Usuario_Load(object sender, EventArgs e)
        {
            DataSet ds = SQLHelper.ExecuteDataSet("traerListadoRoles");
            DropDownListManager.CargarCombo(cmbRol, ds.Tables[0], "id_Rol", "Nombre", false, "");

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           if( validarCampos()){
               corroborarEsUsuarioExistente();


           }
               
               
        }

        private bool validarCampos()
        {
            string strErrores = "";
            strErrores = Validator.ValidarNulo(txtUsername.Text, "-Username-");
            strErrores = strErrores + Validator.ValidarNulo(txtPassword.Text, "-Password-");
            strErrores = strErrores + Validator.ValidarNulo(txtPreguntaSecreta.Text, "-Pregunta Secreta-");
            strErrores = strErrores + Validator.ValidarNulo(txtRespuestaSecreta.Text, "-Respuesta Secreta-");
            if (strErrores.Length > 0)
            {
                MessageBox.Show("Por favor ingrese los siguientes campos: strErrores","Faltan datos", MessageBoxButtons.OK);
                txtUsername.Clear();
                txtPassword.Clear();
                txtPreguntaSecreta.Clear();
                txtRespuestaSecreta.Clear();
                return false;
            }
            return true;
        }

        private bool corroborarEsUsuarioExistente()
        {

            unUsuario.Username = txtUsername.Text;
            unUsuario.Password = txtPassword.Text;
            unUsuario.Pregunta_Secreta = txtPreguntaSecreta.Text;
            unUsuario.Respuesta_Secreta = txtRespuestaSecreta.Text;
            
            Rol rolAAsignar = new Rol();
            rolAAsignar.rol_id = Convert.ToInt32(cmbRol.SelectedValue);
            rolAAsignar.Nombre = cmbRol.SelectedText.ToString();
            unUsuario.Rol = rolAAsignar;

            unUsuario.Modificar()
                        
            return true;
        }
       

    }
}
