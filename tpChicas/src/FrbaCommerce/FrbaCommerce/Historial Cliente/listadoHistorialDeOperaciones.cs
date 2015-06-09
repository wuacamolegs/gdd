using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Conexion;
using Utilities;
using Excepciones;

namespace FrbaCommerce.Historial_Cliente
{
    public partial class listadoHistorialDeOperaciones : Form
    {
        Usuario unUsuario = new Usuario();

        public listadoHistorialDeOperaciones()
        {
            InitializeComponent();
        }

        private void listadoHistorialDeOperaciones_Load(object sender, EventArgs e)
        {
            //se carga el combo box historial con un default para que siempre haya un campo seleccionado
            // al momento de cargar el listado y configurar la grilla
            cmbHistorial.SelectedIndex = 0;
        }

        private void configurarGrillaCompras(DataSet ds)
        {
            dtgHistorial.Columns.Clear();
            dtgHistorial.AutoGenerateColumns = false;
                       
            DataGridViewTextBoxColumn clmID = new DataGridViewTextBoxColumn();
            clmID.Width = 65;
            clmID.ReadOnly = true;
            clmID.DataPropertyName = "id_Compra";
            clmID.HeaderText = "ID Compra";
            dtgHistorial.Columns.Add(clmID);

            DataGridViewTextBoxColumn clmCodPublicacion = new DataGridViewTextBoxColumn();
            clmCodPublicacion.Width = 75;
            clmCodPublicacion.ReadOnly = true;
            clmCodPublicacion.DataPropertyName = "cod_Publicacion";
            clmCodPublicacion.HeaderText = "Código Publiación";
            dtgHistorial.Columns.Add(clmCodPublicacion);

            DataGridViewTextBoxColumn clmVendedor = new DataGridViewTextBoxColumn();
            clmVendedor.Width = 170;
            clmVendedor.ReadOnly = true;
            clmVendedor.DataPropertyName = "Vendedor";
            clmVendedor.HeaderText = "Vendedor";
            dtgHistorial.Columns.Add(clmVendedor);

            DataGridViewTextBoxColumn clmFecha = new DataGridViewTextBoxColumn();
            clmFecha.Width = 100;
            clmFecha.ReadOnly = true;
            clmFecha.DataPropertyName = "Fecha";
            clmFecha.HeaderText = "Fecha";
            dtgHistorial.Columns.Add(clmFecha);

            DataGridViewTextBoxColumn clmCantidad = new DataGridViewTextBoxColumn();
            clmCantidad.Width = 80;
            clmCantidad.ReadOnly = true;
            clmCantidad.DataPropertyName = "Cantidad";
            clmCantidad.HeaderText = "Cantidad";
            dtgHistorial.Columns.Add(clmCantidad);

            dtgHistorial.DataSource = ds.Tables[0];
        }

        private void configurarGrillaOfertas(DataSet ds)
        {
            dtgHistorial.Columns.Clear();
            dtgHistorial.AutoGenerateColumns = false;
            

            DataGridViewTextBoxColumn clmID = new DataGridViewTextBoxColumn();
            clmID.Width = 65;
            clmID.ReadOnly = true;
            clmID.DataPropertyName = "id_Oferta";
            clmID.HeaderText = "ID Oferta";
            dtgHistorial.Columns.Add(clmID);

            DataGridViewTextBoxColumn clmCodPublicacion = new DataGridViewTextBoxColumn();
            clmCodPublicacion.Width = 75;
            clmCodPublicacion.ReadOnly = true;
            clmCodPublicacion.DataPropertyName = "cod_Publicacion";
            clmCodPublicacion.HeaderText = "Código Publiación";
            dtgHistorial.Columns.Add(clmCodPublicacion);

            DataGridViewTextBoxColumn clmVendedor = new DataGridViewTextBoxColumn();
            clmVendedor.Width = 170;
            clmVendedor.ReadOnly = true;
            clmVendedor.DataPropertyName = "Vendedor";
            clmVendedor.HeaderText = "Vendedor";
            dtgHistorial.Columns.Add(clmVendedor);

            DataGridViewCheckBoxColumn clmGanoSubasta = new DataGridViewCheckBoxColumn();
            clmGanoSubasta.Width = 60;
            clmGanoSubasta.ReadOnly = true;
            clmGanoSubasta.DataPropertyName = "gano_Subasta";
            clmGanoSubasta.HeaderText = "Gano Subasta";
            dtgHistorial.Columns.Add(clmGanoSubasta);

            DataGridViewTextBoxColumn clmFecha = new DataGridViewTextBoxColumn();
            clmFecha.Width = 100;
            clmFecha.ReadOnly = true;
            clmFecha.DataPropertyName = "Fecha";
            clmFecha.HeaderText = "Fecha";
            dtgHistorial.Columns.Add(clmFecha);

            DataGridViewTextBoxColumn clmMonto = new DataGridViewTextBoxColumn();
            clmMonto.Width = 65;
            clmMonto.ReadOnly = true;
            clmMonto.DataPropertyName = "Monto";
            clmMonto.HeaderText = "Monto";
            dtgHistorial.Columns.Add(clmMonto);

            dtgHistorial.DataSource = ds.Tables[0];
        }

        private void configurarGrillaCalificacionesOtorgadas(DataSet ds)
        {
            dtgHistorial.Columns.Clear();
            dtgHistorial.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmCodCalificacion = new DataGridViewTextBoxColumn();
            clmCodCalificacion.Width = 90;
            clmCodCalificacion.ReadOnly = true;
            clmCodCalificacion.DataPropertyName = "cod_Calificacion";
            clmCodCalificacion.HeaderText = "Código Calificación";
            dtgHistorial.Columns.Add(clmCodCalificacion);

            DataGridViewTextBoxColumn clmCalificado = new DataGridViewTextBoxColumn();
            clmCalificado.Width = 120;
            clmCalificado.ReadOnly = true;
            clmCalificado.DataPropertyName = "Calificado";
            clmCalificado.HeaderText = "Calificado";
            dtgHistorial.Columns.Add(clmCalificado);

            DataGridViewTextBoxColumn clmCantEstrellas = new DataGridViewTextBoxColumn();
            clmCantEstrellas.Width = 90;
            clmCantEstrellas.ReadOnly = true;
            clmCantEstrellas.DataPropertyName = "cant_Estrellas";
            clmCantEstrellas.HeaderText = "Cantidad Estrellas";
            dtgHistorial.Columns.Add(clmCantEstrellas);

            DataGridViewTextBoxColumn clmDescripcion = new DataGridViewTextBoxColumn();
            clmDescripcion.Width = 250;
            clmDescripcion.ReadOnly = true;
            clmDescripcion.DataPropertyName = "Descripcion";
            clmDescripcion.HeaderText = "Descripcion";
            dtgHistorial.Columns.Add(clmDescripcion);

            dtgHistorial.DataSource = ds.Tables[0];
        }

        private void configurarGrillaCalificacionesRecibidas(DataSet ds)
        {
            dtgHistorial.Columns.Clear();
            dtgHistorial.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmCodCalificacion = new DataGridViewTextBoxColumn();
            clmCodCalificacion.Width = 90;
            clmCodCalificacion.ReadOnly = true;
            clmCodCalificacion.DataPropertyName = "cod_Calificacion";
            clmCodCalificacion.HeaderText = "Código Calificación";
            dtgHistorial.Columns.Add(clmCodCalificacion);

            DataGridViewTextBoxColumn clmCalificador = new DataGridViewTextBoxColumn();
            clmCalificador.Width = 120;
            clmCalificador.ReadOnly = true;
            clmCalificador.DataPropertyName = "Calificador";
            clmCalificador.HeaderText = "Calificador";
            dtgHistorial.Columns.Add(clmCalificador);

            DataGridViewTextBoxColumn clmCantEstrellas = new DataGridViewTextBoxColumn();
            clmCantEstrellas.Width = 90;
            clmCantEstrellas.ReadOnly = true;
            clmCantEstrellas.DataPropertyName = "cant_Estrellas";
            clmCantEstrellas.HeaderText = "Cantidad Estrellas";
            dtgHistorial.Columns.Add(clmCantEstrellas);

            DataGridViewTextBoxColumn clmDescripcion = new DataGridViewTextBoxColumn();
            clmDescripcion.Width = 250;
            clmDescripcion.ReadOnly = true;
            clmDescripcion.DataPropertyName = "Descripcion";
            clmDescripcion.HeaderText = "Descripcion";
            dtgHistorial.Columns.Add(clmDescripcion);

            dtgHistorial.DataSource = ds.Tables[0];
        }

        private void btnVer_Click(object sender, EventArgs e)
        {   
            //Según la operación que se seleccione se carga el listado
            //Se obtiene el DataSet correspondiente y se configura la grilla y las columnas para el mismo
            if (cmbHistorial.SelectedIndex == 0) cargarListadoDeCompras();
            if (cmbHistorial.SelectedIndex == 1) cargarListadoDeOfertas();
            if (cmbHistorial.SelectedIndex == 2) cargarListadoDeCalificacionesRecibidas();
            if (cmbHistorial.SelectedIndex == 3) cargarListadoDeCalificacionesOtorgadas();
        }

        private void cargarListadoDeCompras()
        {
            try
            {
                DataSet ds = unUsuario.obtenerTodasLasCompras();
                configurarGrillaCompras(ds);
            }          

            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarListadoDeOfertas()
        {
            try
            {
                DataSet ds = unUsuario.obtenerTodasLasOfertas();
                configurarGrillaOfertas(ds);
            }

            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarListadoDeCalificacionesRecibidas()
        {
            try
            {
                DataSet ds = unUsuario.obtenerTodasLasCalificacionesRecibidas();
                configurarGrillaCalificacionesRecibidas(ds);
            }

            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarListadoDeCalificacionesOtorgadas()
        {
            try
            {
                DataSet ds = unUsuario.obtenerTodasLasCalificacionesOtorgadas();
                configurarGrillaCalificacionesOtorgadas(ds);
            }

            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void abrirConUsuario(Usuario user)
        {
            //se guarda la información del usuario que abrió el formulario
            unUsuario = user;
            this.Show();
        }
    } 
}

