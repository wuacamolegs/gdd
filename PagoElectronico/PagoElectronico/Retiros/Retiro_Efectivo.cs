using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;

namespace PagoElectronico.Retiros
{
    public partial class Retiro_Efectivo : Form
    {
        public Usuario unUsuario = new Usuario();


        public Retiro_Efectivo()
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
