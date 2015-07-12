﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Clases;
using Utilities;
using Excepciones;

namespace PagoElectronico.ABM_Cliente
{
    public partial class abm_tarjetas : Form
    {

        
        #region Variables

        public Usuario unUsuario = new Usuario();
        public Cliente unCliente = new Cliente();
        public Tarjeta unaTarjeta = new Tarjeta();
        
        #endregion


        #region Initialize

        public abm_tarjetas()
        {
            InitializeComponent();
        }
       
        
        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            unCliente.Usuario = unUsuario;
            unaTarjeta.Cliente = unCliente;
            this.Show();
        }

        private void abm_tarjetas_Load(object sender, EventArgs e)
        {
            //Cargargrilla
            DataSet dsTarjetas = unaTarjeta.traerTarjetas();
            cargarGrilla(dsTarjetas);
        }

        #endregion

    
        #region botones y vistas

        private void cargarGrilla(DataSet dsTarjetas)
        {

            //realizo la configuracion de la grilla, seteando las filas y columnas con sus nombres y valores
            dtgTarjetas.Columns.Clear();
            dtgTarjetas.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmID = new DataGridViewTextBoxColumn();
            clmID.Width = 150;
            clmID.ReadOnly = true;
            clmID.DataPropertyName = "tarjeta_id";
            clmID.HeaderText = "NUMERO DE TARJETA";
            dtgTarjetas.Columns.Add(clmID);

            DataGridViewTextBoxColumn clmEmisor = new DataGridViewTextBoxColumn();
            clmEmisor.Width = 80;
            clmEmisor.ReadOnly = true;
            clmEmisor.DataPropertyName = "tarjeta_emisor";
            clmEmisor.HeaderText = "EMISOR";
            dtgTarjetas.Columns.Add(clmEmisor);

            DataGridViewTextBoxColumn clmFechaEmision = new DataGridViewTextBoxColumn();
            clmFechaEmision.Width = 80;
            clmFechaEmision.ReadOnly = true;
            clmFechaEmision.DataPropertyName = "tarjeta_fecha_emision";
            clmFechaEmision.HeaderText = "FECHA DE EMISION";
            dtgTarjetas.Columns.Add(clmFechaEmision);

            DataGridViewTextBoxColumn clmVencimiento = new DataGridViewTextBoxColumn();
            clmVencimiento.Width = 80;
            clmVencimiento.ReadOnly = true;
            clmVencimiento.DataPropertyName = "tarjeta_vencimiento";
            clmVencimiento.HeaderText = "FECHA DE VENCIMIENTO";
            dtgTarjetas.Columns.Add(clmVencimiento);

            DataGridViewTextBoxColumn clmEstado = new DataGridViewTextBoxColumn();
            clmVencimiento.Width = 80;
            clmVencimiento.ReadOnly = true;
            clmVencimiento.DataPropertyName = "tarjeta_estado";
            clmVencimiento.HeaderText = "ESTADO";
            dtgTarjetas.Columns.Add(clmEstado);


            //le inserto a la grilla el dataset obtenido
            dtgTarjetas.DataSource = dsTarjetas.Tables[0];
        }

        private void dtgTarjetas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgTarjetas.SelectedRows.ToString();
            unaTarjeta.tarjeta_id = valorIdSeleccionado();
            unaTarjeta.tarjeta_emisor = valorEmisorSeleccionado();
            unaTarjeta.tarjeta_fecha_emision = valorEmisionSeleccionado();
            unaTarjeta.tarjeta_vencimiento = valorVencimientoSeleccionado();
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            formTarjeta formTarjeta = new formTarjeta();
            MessageBox.Show("TARJETA ID: " + valorIdSeleccionado() + "\n EMISOR: " + valorEmisorSeleccionado() + "\n ESTADO: " + valorEstadoSeleccionado(), "");
            unaTarjeta.tarjeta_id = valorIdSeleccionado();
            unaTarjeta.Emisor = valorEmisorSeleccionado();
            unaTarjeta.Estado = valorEstadoSeleccionado();
            unaTarjeta.FechaVencimiento = valorVencimientoSeleccionado();
            unaTarjeta.FechaEmision = valorEmisionSeleccionado();
            unaTarjeta.CodigoSeguridad = valorCodigoSeguridad();
            formRol.AbrirParaModificar(unRol, this);

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
       

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            
            DialogResult dr = MessageBox.Show("¿Está seguro que desea desactivar la tarjeta?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
               Tarjeta unaTarjeta = new Rol(valorIdSeleccionado(), valorEmisorSeleccionado(), valorEmisionSeleccionado(), valorVencimientoSeleccionado());
                unaTarjeta.Desactivar();
                MessageBox.Show("La tarjeta ha sido desactivada", "Desactivada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListadoDeTarjetas();
            }
        }

        public void CargarListadoDeTarjetas()
        {

            try
            {
                //obtengo en un dataset todos los roles de la bd
                DataSet dsTarjetas = unaTarjeta.traerTarjetasActivas();
                cargarGrilla(dsTarjetas);
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


        #endregion




        #region llamados a la base

        #endregion


        #region metodos privados

        private Int64 valorIdSeleccionado()
        {
            return Convert.ToInt64(((DataRowView)dtgTarjetas.CurrentRow.DataBoundItem)["tarjeta_id"]);
        }
        private Int64 valorEmisorSeleccionado()
        {
            return Convert.ToInt64(((DataRowView)dtgTarjetas.CurrentRow.DataBoundItem)["tarjeta_emisor"]);
        }
        private Boolean valorEstadoSeleccionado()
        {
            return Convert.ToBoolean(((DataRowView)dtgTarjetas.CurrentRow.DataBoundItem)["tarjeta_estado"]);
        }

        private Int64 valorCodigoSeguridad()
        {
            return Convert.ToInt64(((DataRowView)dtgTarjetas.CurrentRow.DataBoundItem)["tarjeta_codigo_seguridad"]);
        }

        private DateTime valorEmisionSeleccionado()
        {
            return Convert.ToDateTime(((DataRowView)dtgTarjetas.CurrentRow.DataBoundItem)["tarjeta_fecha_emision"]);
        }

        private DateTime valorVencimientoSeleccionado()
        {
            return Convert.ToDateTime(((DataRowView)dtgTarjetas.CurrentRow.DataBoundItem)["tarjeta_vencimiento"]);
        }

        #endregion


    }
}
