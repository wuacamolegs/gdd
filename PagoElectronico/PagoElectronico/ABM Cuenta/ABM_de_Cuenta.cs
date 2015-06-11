using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class ABM_de_Cuenta : Form
    {
        public Usuario unUsuario = new Usuario();

        public ABM_de_Cuenta()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }
    }
}
