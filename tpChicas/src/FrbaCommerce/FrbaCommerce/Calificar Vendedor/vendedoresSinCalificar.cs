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

namespace FrbaCommerce.Calificar_Vendedor
{
    public partial class vendedoresSinCalificar : Form
    {
        Usuario unUsuario = new Usuario();
        public vendedoresSinCalificar()
        {
            InitializeComponent();
        }
        public void abrirConUsuario(Usuario user)
        {
            //es necesario abrir este form e instanciar al usuario que esta usando la aplicacion
            unUsuario = user;
            this.Show();
        }

        private void calificar_Load(object sender, EventArgs e)
        {
            cargarListadoVendedoresSinCalificar();
        }
        private void configurarGrilla(DataSet ds)
        {

            dtgVendedoresSinCalificar.Columns.Clear();
            dtgVendedoresSinCalificar.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmCodPublicacion = new DataGridViewTextBoxColumn();
            clmCodPublicacion.Visible = false;
            clmCodPublicacion.ReadOnly = true;
            clmCodPublicacion.DataPropertyName = "cod_Publicacion";
            clmCodPublicacion.HeaderText = "Cod_Publ";
            dtgVendedoresSinCalificar.Columns.Add(clmCodPublicacion);

            DataGridViewTextBoxColumn clmVendedor = new DataGridViewTextBoxColumn();
            clmVendedor.Width = 30;
            clmVendedor.ReadOnly = true;
            clmVendedor.DataPropertyName = "Vendedor";
            clmVendedor.HeaderText = "Vendedor";
            dtgVendedoresSinCalificar.Columns.Add(clmVendedor);
            
            DataGridViewTextBoxColumn clmTipoPublicacion = new DataGridViewTextBoxColumn();
            clmTipoPublicacion.ReadOnly = true;
            clmTipoPublicacion.DataPropertyName = "Nombre";
            clmTipoPublicacion.HeaderText = "Tipo de Publicacion";
            dtgVendedoresSinCalificar.Columns.Add(clmTipoPublicacion);

            DataGridViewTextBoxColumn clmPublicacion = new DataGridViewTextBoxColumn();
            clmPublicacion.Width = 30;
            clmPublicacion.ReadOnly = true;
            clmPublicacion.DataPropertyName = "Descripcion";
            clmPublicacion.HeaderText = "Publicacion";
            dtgVendedoresSinCalificar.Columns.Add(clmPublicacion);

            DataGridViewTextBoxColumn clmFecha = new DataGridViewTextBoxColumn();
            clmFecha.ReadOnly = true;
            clmFecha.DataPropertyName = "Fecha";
            clmFecha.HeaderText = "Fecha";
            dtgVendedoresSinCalificar.Columns.Add(clmFecha);

            dtgVendedoresSinCalificar.DataSource = ds.Tables[0];
            dtgVendedoresSinCalificar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            agregarBotonCalificar();
        }
        private void agregarBotonCalificar()
        {
            var nuevaClm = new DataGridViewButtonColumn
            {
                Text = "Calificar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            dtgVendedoresSinCalificar.Columns.Add(nuevaClm);
        }
        private void dtgVendedoresSinCalificar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // la columna cinco es la que tiene los botones calificar. Por eso, si la celda que regiustra en el evento del Click
            // no esta en la columna cinco, no hago nada.
            if (e.ColumnIndex != 5)
                return;
            
            calificarVendedor _frmCalificarVendedor = new calificarVendedor();
            _frmCalificarVendedor.AbrirParaCalificar(this, unUsuario.Id_Usuario, valorCodSeleccionado());
            // le paso como parametros al form: 1.esteForm(para que despues vuelva a cargarse la grilla actualizada
            //                                  2. el id el usuario que esta usando la aplicacion
            //                                  3. el codigo de la publicacion seleccionada en la grilla que va a ser calificada
        }
        public void cargarListadoVendedoresSinCalificar()
        {
            try
            {
                // le pido al usuario que me traiga todos aquellos vendedores a los que el usuario compro
                // o gano subasta y no los ha calificado.
                DataSet ds = unUsuario.obtenerVendedoresSinCalificar();
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No hay ningún vendedor sin calificar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                configurarGrilla(ds);
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

        private int valorCodSeleccionado()
        {
            // me devuelve el codigo de la publicacion sin calificar que esta seleccionada en la grilla
            return Convert.ToInt32(((DataRowView)dtgVendedoresSinCalificar.CurrentRow.DataBoundItem)["cod_Publicacion"]);
        }

        
    }
}
