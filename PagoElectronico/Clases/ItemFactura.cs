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
        private decimal _costo;
        private string _descripcion;
        private int _cantidad;
        
        #endregion

        #region constructor
      
        public ItemFactura()
        {

        }

        public ItemFactura(Factura factura, int Cantidad, decimal Costo, string descr)
        {
            this.Factura = factura;
            this.Cantidad = Cantidad;
            this.Costo = Costo;
            this.Descripcion = descr;

        }

        #endregion

        #region properties

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
       
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public decimal Costo
        {
            get { return _costo; }
            set { _costo = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
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
            this.Costo = Convert.ToInt32(dr["item_factura_costo"]);
            this.Factura.Numero = Convert.ToInt32(dr["item_factura_factura_numero"]);
            this.Descripcion = Convert.ToString(dr["item_factura_desc"]);
            this.Cantidad = Convert.ToInt32(dr["item_factura_cant"]);
        }
        #endregion

        #region setters

        private void setearListaParametrosCompleta()
        {
            parameterList.Clear();
            parameterList.Add(new SqlParameter("@item_factura", this.Factura.Numero));
            parameterList.Add(new SqlParameter("@item_descr", this.Descripcion));
            parameterList.Add(new SqlParameter("@item_cantidad", this.Cantidad));
            parameterList.Add(new SqlParameter("@item_costo", this.Costo));

        }


        #endregion

        #region llamados a la base
        
        public void InsertItem()
        {
            this.setearListaParametrosCompleta();
            this.Guardar(parameterList);  //TODO falta procedure
        }

        #endregion

        #region metodos privados

        #endregion

    }
}
