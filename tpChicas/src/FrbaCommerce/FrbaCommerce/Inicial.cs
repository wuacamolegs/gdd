using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Conexion;
using FrbaCommerce.Registro_de_Usuario;

namespace FrbaCommerce
{
    public partial class Inicial : Form
    {
        public Inicial()
        {
            InitializeComponent();
        }

        private void lblIniciarSesion_Click(object sender, EventArgs e)
        {
            Login.LogIn loginForm = new Login.LogIn();
            this.Hide();
            loginForm.Show(); 
        }

        private void Inicial_Load(object sender, EventArgs e)
        {
            try
            {
                SQLHelper.Inicializar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblRegistrarUsuario_Click(object sender, EventArgs e)
        {
            registroUsuario frmRegistroUsuario = new registroUsuario();            
            frmRegistroUsuario.Show();
        }

  
    }
}
