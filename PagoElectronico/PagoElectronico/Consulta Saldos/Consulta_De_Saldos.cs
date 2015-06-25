using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;

namespace PagoElectronico.Consulta_Saldos
{
    public partial class Consulta_De_Saldos : Form
    {
        #region variables
        public Usuario unUsuario = new Usuario();
        #endregion

        #region initialize
        public Consulta_De_Saldos()
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
