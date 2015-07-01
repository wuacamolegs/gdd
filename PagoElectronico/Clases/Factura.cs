﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Configuration;
using Excepciones;
using Utilities;
using System.Windows.Forms;


namespace Clases
{
    public class Factura : Base
    {
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos

        private int _factura_numero;
        private Cliente _cliente;
        private Decimal _importe = 0;
        private DateTime _fecha;
        private DataTable _dt = new DataTable();
              
        #endregion

        #region constructor
      
        public Factura()
        {
            tablaSuscripciones.Columns.Add("tvp_cliente_id", typeof(Double));
            tablaSuscripciones.Columns.Add("tvp_cuenta_id", typeof(Double));
            tablaSuscripciones.Columns.Add("tvp_cantidad_Suscripciones", typeof(Int32));
        }

        #endregion

        #region properties

        public DataTable tablaSuscripciones
        {
            get { return _dt; }
            set { _dt = value; }
        }

        public int Numero
        {
            get { return _factura_numero; }
            set {_factura_numero = value;}
        }

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
       
        public Decimal Importe
        {
            get { return _importe; }
            set { _importe = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }


        #endregion

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Factura";
        }

        public override string NombreEntidad()
        {
            return "Factura";
        }
        #endregion

        #region dataRowToObject

        public override void DataRowToObject(DataRow dr)
        {
            this.Cliente.cliente_id = Convert.ToInt32(dr["factura_cliente_id"]);
            this.Importe = Convert.ToInt32(dr["factura_importe"]);
            this.Fecha = Convert.ToDateTime(dr["cheque_fecha"]);
        }

        #endregion

        #region setters
      
        private void setearListaParametrosSinNumeroFactura()
        {
          parameterList.Clear();
          parameterList.Add(new SqlParameter("@factura_importe", this.Importe));
          parameterList.Add(new SqlParameter("@factura_fecha", this.Fecha));
          parameterList.Add(new SqlParameter("@factura_cliente_id", this.Cliente.cliente_id));
          parameterList.Add(new SqlParameter("@tablaSuscripciones", this.tablaSuscripciones)); //para saber que suscripciones de que cuenta pag[o.
        }

        #endregion

        #region llamados a la base

        public Factura GenerarFactura()
        {
            setearListaParametrosSinNumeroFactura();
            DataSet ds = this.GuardarYObtenerID(parameterList);  //TODO falta obtener el id
            this.Numero = Convert.ToInt32(ds.Tables[0].Rows[0][0]); //TODO NO ANDA
            return this;
        }

        #endregion

        #region metodos privados

        #endregion

        public void AñadirItems(decimal CantTrans, decimal totalTrans, decimal CantMod, decimal totalMod, decimal cantSusc, decimal totalSusc)
        {
            ItemFactura unItem = new ItemFactura(this);
            unItem.crearItem(CantTrans,totalTrans,1);  //1 = "Comision por transferencia"
            unItem.crearItem(CantMod, totalMod,2);  // 2 = "Modificaciones Tipo Cuenta"
            unItem.crearItem(cantSusc, totalSusc,3); // 3 = "Suscripciones por Apertura Cuenta"
            unItem.InsertItem();
        }

    }
}
