using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;

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

    }
}
