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
        private int _importe;
        private DateTime _fecha;
        private ItemFactura _itemsFactura;
        
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
       
        public ItemFactura items
        {
            get { return _itemsFactura; }
            set { _itemsFactura = value; }
        }

        public int Importe
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


        public override void DataRowToObject(DataRow dr)
        {
            this.Cliente.cliente_id = Convert.ToInt32(dr["factura_cliente_id"]);
            this.Importe = Convert.ToInt32(dr["factura_importe"]);
            this.Fecha = Convert.ToDateTime(dr["cheque_fecha"]);
        }

    }
}
