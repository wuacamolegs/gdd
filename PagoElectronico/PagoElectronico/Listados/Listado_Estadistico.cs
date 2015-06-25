using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;

namespace PagoElectronico.Listados
{
    public partial class Listado_Estadistico : Form
    {
        #region variables
        public Usuario unUsuario = new Usuario();
        #endregion

        #region initialize
        public Listado_Estadistico()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        #endregion

        #region botones y vistas
        #endregion

        #region llamados a la base
        #endregion

        #region metodos privados
        #endregion


    }
}
