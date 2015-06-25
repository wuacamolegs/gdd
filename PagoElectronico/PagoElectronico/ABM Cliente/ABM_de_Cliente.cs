using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;


namespace PagoElectronico.ABM_Cliente
{
    public partial class ABM_de_Cliente : Form
    {
        #region variables

        public Usuario unUsuario = new Usuario();

        #endregion

        #region initialize
        public ABM_de_Cliente()
        {
            InitializeComponent();
        }
     
        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }
        #endregion

        #region botones
        #endregion

        #region llamados a la base
        #endregion

        #region metodos privados
        #endregion

    }
}
