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
using FrbaCommerce.Abm_Cliente;
using FrbaCommerce.Abm_Empresa;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class registroUsuario : Form
    {
        public registroUsuario()
        {
            InitializeComponent();
        }
        private void registroUsuario_Load(object sender, EventArgs e)
        {
            cmdRol.SelectedIndex = 0;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                // se ingresaron en pantalla username y password del nuevo cliente
                ValidarCampos();
                
                // se instancia un nuevo usuario y se setean sus atributos
                Usuario unUsuarioNuevo = new Usuario();

                unUsuarioNuevo.Username = txtUsername.Text;
                unUsuarioNuevo.Clave = Encryptor.GetSHA256(txtPassword.Text);
                unUsuarioNuevo.ClaveAutoGenerada = false;
                unUsuarioNuevo.Activo = true;

                unUsuarioNuevo.guardarDatosDeUsuarioNuevo();

                // ya se inserto el nuevo usuario en la base de datos
                // segun si el rol seleccionado fue empresa o cliente muestro el formulario
                // correspondiente para el insert de los datos. Para esto necesito traerme el id
                // del nuevo usuario insertado.

                if (cmdRol.Text == "Empresa")
                {
                    frmEmpresa _frmEmpresa = new frmEmpresa();
                    _frmEmpresa.AbrirParaRegistrarNuevaEmpresa(unUsuarioNuevo.Id_Usuario);
                    this.Hide();
                }
                if (cmdRol.Text == "Cliente")
                {
                    frmCliente _frmCliente = new frmCliente();
                    _frmCliente.AbrirParaRegistrarNuevoCliente(unUsuarioNuevo.Id_Usuario);
                    this.Hide();
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
            string strErrores = "";
            strErrores += Validator.ValidarNulo(txtUsername.Text, "Username");
            strErrores += Validator.ValidarNulo(txtPassword.Text, "Password");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
            
            
        }

      
    }
}
