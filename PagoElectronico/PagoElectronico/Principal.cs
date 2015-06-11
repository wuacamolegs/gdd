using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Conexion;
using Clases;
using Utilities;
using PagoElectronico.ABM_Rol;
using PagoElectronico.ABM_Cliente;
using PagoElectronico.Abm_Empresa;
using PagoElectronico.Abm_Visibilidad;
using PagoElectronico.Historial_Cliente;
using PagoElectronico.Generar_Publicacion;
using PagoElectronico.Listado_Estadistico;
using PagoElectronico.Editar_Publicacion;
using PagoElectronico.Comprar_Ofertar;
using PagoElectronico.Facturar_Publicaciones;
using PagoElectronico.Calificar_Vendedor;
using PagoElectronico.Registro_de_Usuario;


namespace PagoElectronico
{
    public partial class Principal : Form
    {
        public Usuario unUsuario = new Usuario();

        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            unUsuario.Rol.setearFuncionalidadesAlRol();
            bool permisosAdmin = false;
            bool permisosPublicacion = false;
            bool permisosUsuario = false;
            //Segun el rol, voy a tener funcionalidades. Voy a comparar cada funcionalidad del rol
            //contra el enum de la clase de funcionalidades que tiene definido todos los posibles tipos
            //de funcionalidades permitidas para el usuario. Segun las funcionalidades que mi rol tenga
            //vere mas o menos pestañas en el menu
            foreach (Funcionalidad unaFunc in unUsuario.Rol.Funcionalidades)
            {
                switch (unaFunc.obtenerPorNombre())
                {
                    case Funcionalidades.ABM_Cliente:
                        aBMClientesToolStripMenuItem.Visible = true;
                        permisosAdmin = true;
                        break;
                    case Funcionalidades.ABM_Empresas:
                        AbmEmpresasToolStripMenuItem.Visible = true;
                        permisosAdmin = true;
                        break;
                    case Funcionalidades.ABM_Rol:
                        ABMRolesToolStripMenuItem.Visible = true;
                        permisosAdmin = true;
                        break;
                    case Funcionalidades.Administrar_Usuarios:
                        administrarUsuariosToolStripMenuItem.Visible = true;
                        permisosAdmin = true;
                        break;
                    case Funcionalidades.Cambiar_Clave:
                        cambiarClaveToolStripMenuItem.Visible = true;
                        permisosAdmin = true;
                        break;
                    case Funcionalidades.ABM_Visibilidad:
                        AbmVisiblidadToolStripMenuItem.Visible = true;
                        permisosPublicacion = true;
                        break;
                    case Funcionalidades.Calificar:
                        calificarVendedoresToolStripMenuItem.Visible = true;
                        permisosUsuario = true;
                        break;
                    case Funcionalidades.Comprar_Ofertar:
                        comprarOfertarToolStripMenuItem.Visible = true;
                        permisosPublicacion = true;
                        break;
                    case Funcionalidades.Estadisticas:
                        listadoEstadísticoToolStripMenuItem.Visible = true;
                        permisosUsuario = true;
                        break;
                    case Funcionalidades.Facturar:
                        facturarPublicacionesToolStripMenuItem.Visible = true;
                        permisosPublicacion = true;
                        break;
                    case Funcionalidades.Generar_Publicaciones:
                        generarPublicacionToolStripMenuItem.Visible = true;
                        permisosPublicacion = true;
                        break;
                    case Funcionalidades.Historial_clientes:
                        historialToolStripMenuItem1.Visible = true;
                        permisosUsuario = true;
                        break;
                    case Funcionalidades.Mis_Publicaciones:
                        misPublicacionesToolStripMenuItem.Visible = true;
                        permisosPublicacion = true;
                        break;

                }
            }

            if (!permisosAdmin)
                menu.Items.Remove(pestanaInicio);
            if (!permisosPublicacion)
                menu.Items.Remove(pestanaPublicacion);
            if (!permisosUsuario)
                menu.Items.Remove(pestanaUsuario);

        }

        private void ABMRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoRoles frmListadoRoles = new listadoRoles();
            frmListadoRoles.Show(this);
        }


        private void AbmEmpresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoEmpresa frmListadoEmpresas = new listadoEmpresa();
            frmListadoEmpresas.Show(this);
        }

        private void AbmVisiblidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoVisibilidad frmListadoVisibilidad = new listadoVisibilidad();
            frmListadoVisibilidad.Show(this);
        }

        private void historialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listadoHistorialDeOperaciones frmListadoHistorial = new listadoHistorialDeOperaciones();
            frmListadoHistorial.abrirConUsuario(unUsuario);
        }


        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }


        private void listadoEstadísticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoEstadistico frmListadoEstadistico = new listadoEstadistico();
            frmListadoEstadistico.abrirConUsuario(unUsuario);
        }

        private void aBMClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoCliente frmListadoClientes = new listadoCliente();
            frmListadoClientes.Show(this);
        }

        private void misPublicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMisPublicaciones misPublic = new frmMisPublicaciones();
            misPublic.abrirConUsuario(unUsuario);
        }


        private void facturarPublicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFacturar frmFacturarPublicaciones = new frmFacturar();
            frmFacturarPublicaciones.abrirConUsuario(unUsuario);
        }

        private void calificarVendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vendedoresSinCalificar frmListadoVendedores = new vendedoresSinCalificar();
            frmListadoVendedores.abrirConUsuario(unUsuario);
        }

        private void generarPublicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetallePublic frmDetalle = new frmDetallePublic();
            frmDetalle.abrirConUsuario(unUsuario);
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inicial frmInicial = new Inicial();
            frmInicial.Show();
            this.Close();
        }

        private void comprarOfertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerPublicaciones lasPublic = new frmVerPublicaciones();
            lasPublic.abrirConUsuario(unUsuario);
        }

        private void administrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoUsuarios lstUsers = new listadoUsuarios();
            lstUsers.Show();

        }

        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //utilizo el dialogManager que me provee Utilities para crear un miniform que solo me ofrezca cambiar
            //la clave. La clave nueva ingresada sera la nueva clave (encriptada) del usuario
            string claveNuevaIngresada = DialogManager.ShowDialogWithPassword("Ingrese nueva clave", "Cambio de clave");

            if (string.IsNullOrEmpty(claveNuevaIngresada))
            {
                return;
            }

            string claveNueva = Encryptor.GetSHA256(claveNuevaIngresada);
            unUsuario.CambiarClave(claveNueva);
        }

        private void Principal_Load_1(object sender, EventArgs e)
        {

        }





    }
}
