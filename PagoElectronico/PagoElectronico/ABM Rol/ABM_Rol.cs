using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Clases;
using Utilities;


namespace PagoElectronico.ABM_Rol
{
    public partial class ABM_de_Rol : Form
    {
        public Usuario unUsuario = new Usuario();
        public Rol unRol = new Rol();

        public ABM_de_Rol()
        {
            InitializeComponent();
        }
     
        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        private void ABM_de_Rol_Load(object sender, EventArgs e)
        {
           //Cargar cmbRol
            DataSet dsRol = unRol.traerRoles();
            DropDownListManager.CargarCombo(cmbRol, dsRol.Tables[0], "rol_id", "rol_nombre", false, "");
        }


  

    }
}
