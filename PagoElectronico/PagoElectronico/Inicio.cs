using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

       
        private void Inicio_Load(object sender, EventArgs e)
        {
            try
            {
                Conexion.SQLHelper.Inicializar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Login.LogIn loginForm = new Login.LogIn();
            this.Hide();
            loginForm.Show();
        }



 










  
    
    }
}
