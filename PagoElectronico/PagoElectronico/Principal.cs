using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System;
using Conexion;
using Clases;
using Utilities;
using PagoElectronico.ABM_Rol;
using PagoElectronico.ABM_Cliente;
using PagoElectronico.ABM_Cuenta;
using PagoElectronico.ABM_de_Usuario;
using PagoElectronico.Consulta_Saldos;
using PagoElectronico.Depositos;
using PagoElectronico.Facturacion;
using PagoElectronico.Listados;
using PagoElectronico.Login;
using PagoElectronico.Properties;
using PagoElectronico.Retiros;
using PagoElectronico.Transferencias;


namespace PagoElectronico
{
    public partial class Principal : Form
    {

        public Usuario unUsuario = new Usuario();
    
         public Principal()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            unUsuario.Rol.Funcionalidades = unUsuario.Rol.setearFuncionalidadesAlRol();
                          
            cerrarSesionToolStripMenuItem.Visible = true;
            iNICIOToolStripMenuItem1.Visible = true;
            rOLToolStripMenuItem1.Visible = false;
            uSUARIOToolStripMenuItem.Visible = true;
            cLIENTEToolStripMenuItem.Visible = false;
            cUENTAToolStripMenuItem.Visible = false;
            fACTURACIONToolStripMenuItem.Visible = false;
            lISTADOESTADISTICOToolStripMenuItem.Visible = false;
            aBMUSUARIOToolStripMenuItem.Visible = false;
            cAMBIARCONTRASEÑAToolStripMenuItem.Visible = true;
            aBMCUENTAToolStripMenuItem.Visible = false;
            dEPOSITOSToolStripMenuItem.Visible = false;
            rETIROSToolStripMenuItem.Visible = false;
            tRANSFERENCIASToolStripMenuItem.Visible = false;
            cONSULTASALDOToolStripMenuItem.Visible = false;

            //Segun el rol, voy a tener funcionalidades. Voy a comparar cada funcionalidad del rol
            //contra el enum de la clase de funcionalidades que tiene definido todos los posibles tipos
            //de funcionalidades permitidas para el usuario. Segun las funcionalidades que mi rol tenga
            //vere mas o menos pestañas en el menu
            foreach (Funcionalidad unaFunc in unUsuario.Rol.Funcionalidades)
            {
               switch (unaFunc.obtenerPorNombre())
                {
                    case Funcionalidades.ABM_Cliente:
                        cLIENTEToolStripMenuItem.Visible = true;
                        break;
                    case Funcionalidades.ABM_Usuario:
                        aBMUSUARIOToolStripMenuItem.Visible = true;
                        break;
                    case Funcionalidades.ABM_Rol:
                        rOLToolStripMenuItem1.Visible = true;
                        break;
                    case Funcionalidades.ABM_Cuenta:
                        cUENTAToolStripMenuItem.Visible = true;
                        aBMCUENTAToolStripMenuItem.Visible = true;
                        break;
                    case Funcionalidades.Depositos:
                        cUENTAToolStripMenuItem.Visible = true;
                        dEPOSITOSToolStripMenuItem.Visible = true;
                        break;
                    case Funcionalidades.Retiro_Efectivo:
                        cUENTAToolStripMenuItem.Visible = true;
                        rETIROSToolStripMenuItem.Visible = true;
                        break;
                    case Funcionalidades.Transferencias_Entre_Cuentas:
                        cUENTAToolStripMenuItem.Visible = true;
                        tRANSFERENCIASToolStripMenuItem.Visible = true;
                        break;
                    case Funcionalidades.Facturacion_De_Costos:
                        fACTURACIONToolStripMenuItem.Visible = true;
                        break;
                    case Funcionalidades.Consulta_De_Saldos:
                        cUENTAToolStripMenuItem.Visible = true;
                        cONSULTASALDOToolStripMenuItem.Visible = true;
                        break;
                    case Funcionalidades.Listado_Estadistico:
                        lISTADOESTADISTICOToolStripMenuItem.Visible = true;
                        break;
                }
                
            }

      }


        private void aBMUSUARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_Usuario abmUsuario = new ABM_Usuario();

            abmUsuario.abrirConUsuario(unUsuario);
        }

        private void cLIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_de_Cliente abmCliente = new ABM_de_Cliente();

            abmCliente.abrirConUsuario(unUsuario);
        }

        private void aBMCUENTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoCuenta abmCuenta = new ListadoCuenta();

            abmCuenta.abrirConUsuario(unUsuario);
        }

        private void dEPOSITOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmDepositos depositos = new frmDepositos();

            depositos.abrirConUsuario(unUsuario);
        }

        private void rETIROSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Retiro_Efectivo retiro = new Retiro_Efectivo();
            retiro.abrirConUsuario(unUsuario);
        }

        private void tRANSFERENCIASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transferencias_Entre_Cuentas transf = new Transferencias_Entre_Cuentas();

            transf.abrirConUsuario(unUsuario);
        }

        private void cONSULTASALDOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_De_Saldos consultaSaldos = new Consulta_De_Saldos();

            consultaSaldos.abrirConUsuario(unUsuario);
        }

        private void fACTURACIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facturacion_De_Costos fact = new Facturacion_De_Costos();

            fact.abrirConUsuario(unUsuario);
        }

        private void lISTADOESTADISTICOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listado_Estadistico list = new Listado_Estadistico();

            list.abrirConUsuario(unUsuario);
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLHelper.Cerrar();
            Application.Exit();
        }

        private void cAMBIARCONTRASEÑAToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void aBMROLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_de_Rol abmRol = new ABM_de_Rol();
            abmRol.abrirConUsuario(unUsuario);
        }










    }
}
