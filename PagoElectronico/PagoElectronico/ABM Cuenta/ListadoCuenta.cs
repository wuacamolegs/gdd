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
    public partial class ListadoCuenta : Form
    {
        #region variables
        public Usuario unUsuario = new Usuario();
        #endregion

        #region initialize
        public ListadoCuenta()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        #region botones
        #endregion

        #region llamados a la base 
        #endregion

        #region metodos privados
        #endregion
    }
}
