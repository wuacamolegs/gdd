using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;

namespace PagoElectronico.Transferencias
{
    public partial class Transferencias_Entre_Cuentas : Form
    {
        public Usuario unUsuario = new Usuario();


        public Transferencias_Entre_Cuentas()
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
