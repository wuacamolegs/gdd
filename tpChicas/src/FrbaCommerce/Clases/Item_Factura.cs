using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    public class Item_Factura : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Item_Factura;
        private decimal _Monto;
        private int _Cantidad;
        private int _nro_Factura;
        private Publicacion _Publicacion;

        #endregion

        #region properties
        public int id_Item_Factura
        {
            get { return _id_Item_Factura; }
            set { _id_Item_Factura = value; }
        }
        public decimal Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }
        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        public int nro_Factura
        {
            get { return _nro_Factura; }
            set { _nro_Factura = value; }
        }
        public Publicacion Publicacion
        {
            get { return _Publicacion; }
            set { _Publicacion = value; }
        }

        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Item_Factura";
        }

        public override string NombreEntidad()
        {
            return "Item_Factura";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Item_Factura = Convert.ToInt32(dr["id_Item_Factura"]);
            this.nro_Factura = Convert.ToInt32(dr["nro_Factura"]);
            this.Publicacion = new Publicacion(Convert.ToInt32(dr["cod_Publicacion"]));
            this.Monto = Convert.ToDecimal(dr["Monto"]);
            this.Cantidad = Convert.ToInt32(dr["Cantidad"]);
        }

        public void cargarNuevoItemFactura()
        {
            //se carga un nuevo item en la tabla item_factura
            setearListaDeParametros();
            this.Guardar(parameterList);
            parameterList.Clear();
        }

        #endregion

        #region metodos privados

        private void setearListaDeParametrosConCodPublicacion(int cod_Publicacion)
        {
            parameterList.Add(new SqlParameter("@cod_Publicacion", cod_Publicacion));
        }

        private void setearListaDeParametros()
        {
            parameterList.Add(new SqlParameter("@nro_Factura", this.nro_Factura));
            parameterList.Add(new SqlParameter("@cod_Publicacion", this.Publicacion.Codigo));
            parameterList.Add(new SqlParameter("@Monto", this.Monto));
            parameterList.Add(new SqlParameter("@Cantidad", this.Cantidad));
        }

        #endregion
    }
}
