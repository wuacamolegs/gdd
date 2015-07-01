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
    public class ItemFactura : Base
    {
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos

        private int _item_factura_id;
        private Factura _factura;
        private DataTable _dt = new DataTable();
        
        #endregion

        #region constructor
      
        public ItemFactura()
        {
            tablaItems.Columns.Add("tvp_detalle", typeof(String));
            tablaItems.Columns.Add("tvp_cantidad", typeof(Decimal));
            tablaItems.Columns.Add("tvp_costo", typeof(Decimal));
        }

        public ItemFactura(Factura factura)
        {
            this.Factura = factura;
            tablaItems.Columns.Add("tvp_detalle", typeof(String));
            tablaItems.Columns.Add("tvp_cantidad", typeof(Decimal));
            tablaItems.Columns.Add("tvp_costo", typeof(Decimal));
        }

        #endregion

        #region properties

        public DataTable tablaItems
        {
            get { return _dt; }
            set { _dt = value; }
        }

        public int ItemFacturaID
        {
            get { return _item_factura_id; }
            set {_item_factura_id = value;}
        }

        public Factura Factura
        {
            get { return _factura; }
            set { _factura = value; }
        }
       

        #endregion

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Item_factura";
        }

        public override string NombreEntidad()
        {
            return "Item_factura";
        }
        #endregion

        #region DataRowToObject
        public override void DataRowToObject(DataRow dr)
        {
            this.ItemFacturaID = Convert.ToInt32(dr["item_factura_id"]);
            //this.tablaItems.Rows.Add(Convert.ToString(dr["item_factura_desc"]), Convert.ToDecimal(dr["item_factura_cant"]), Convert.ToDecimal(dr["item_factura_costo"]));
            this.Factura.Numero = Convert.ToInt32(dr["item_factura_factura_numero"]);

        }
        #endregion

        #region setters

        private void setearListaParametrosCompleta()
        {
            parameterList.Clear();
            parameterList.Add(new SqlParameter("@item_factura_numero", this.Factura.Numero));
            parameterList.Add(new SqlParameter("@item_factura_tabla_items", this.tablaItems));


        }


        #endregion

        #region llamados a la base
        
        public void InsertItem()
        {
            this.setearListaParametrosCompleta();
            this.Guardar(parameterList);
        }

        #endregion

        #region metodos privados

        #endregion


        public void crearItem(decimal CantTrans, decimal totalTrans, decimal codigoTransaccion)
        {
            tablaItems.Rows.Add(codigoTransaccion, CantTrans, totalTrans);
        }
    }
}
