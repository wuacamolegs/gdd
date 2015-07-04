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
        public Cliente unCliente = new Cliente();
        public Cuenta unaCuenta = new Cuenta();
      
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

       
        #region botones

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ObtenerCuentas();
            unCliente.Nombre = Convert.ToString(lblNombre);
            unCliente.Apellido = Convert.ToString(lblApellido);
            unCliente.TipoDocumento = Convert.ToString(cmbDNI);
            unCliente.Documento = Convert.ToInt32(lblDNI);
            cargarGrilla();

        }


        private void cargarGrilla() //TODO
        {
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }


        public void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
                        

        }
        #endregion

        #region llamados a la base 
        #endregion

        #region metodos privados
        #endregion
    }
}
