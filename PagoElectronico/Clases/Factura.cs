using System;
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
        
        #endregion

        #region constructor
      
        public Factura()
        {

        }

        #endregion

        #region properties

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
          parameterList.Add(new SqlParameter("@factura_importe", this.Importe));
          parameterList.Add(new SqlParameter("@factura_fecha", this.Fecha));
          parameterList.Add(new SqlParameter("@factura_cliente_id", this.Cliente.cliente_id));

        }

        #endregion

        #region llamados a la base

        public Factura GenerarFactura()
        {
            setearListaParametrosSinNumeroFactura();
            DataSet ds = this.GuardarYObtenerID(parameterList);  //TODO falta obtener el id
            this.Numero = Convert.ToInt32(ds.Tables[0].Rows[0]["factura_numero"]);
            return this;
        }

        #endregion

        #region metodos privados

        #endregion




        public void AñadirItems(int CantTrans, decimal totalTrans, int CantMod, decimal totalMod, int cantSusc, decimal totalSusc)
        {
            crearItem(CantTrans,totalTrans,"Comisión por transferencia.");
            crearItem(CantMod,totalMod,"Modificaciones Tipo Cuenta");
            crearItem(cantSusc,totalSusc,"Suscripciones por Apertura Cuenta");
        }

        //TODO que pasa si facturo dos veces un cliente una cuenta? nueva factura no? no me tengo que fijar si ya facturo uno de estos items y alterar el total no?

        private void crearItem(int cant, decimal costo, string descr)
        {
            ItemFactura item = new ItemFactura(this, cant, costo, descr);
            item.InsertItem();
        }
    }
}
