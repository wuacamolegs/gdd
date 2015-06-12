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

        private void Retiro_Efectivo_Load(object sender, EventArgs e)
        {
            DataSet dsClientes = ObtenerClientes(unUsuario.usuario_id);
            DropDownListManager.CargarCombo(cmbRol, dsClientes.Tables[0], "cliente_id", "cliente_documento", false, "");

            Rol rolAAsignar = new Rol();
            rolAAsignar.rol_id = Convert.ToInt32(cmbRol.SelectedValue);
            rolAAsignar.Nombre = cmbRol.SelectedText.ToString();
            user.Rol = rolAAsignar;
            AccederAlSistema();
        }

        public DataSet ObtenerClientes()
        {
            Cliente unCliente = new Cliente();
            unRol.setearListaDeParametrosConIdUsuario(id_Usuario);
            DataSet ds = unRol.TraerListado(unRol.parameterList, "PorId_Usuario");
            unRol.parameterList.Clear();


        }
       
        
    }
}
