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
    public class Moneda : Base
    {
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos

        private int _moneda_id;
        private string _moneda_nombre;
   
        
        #endregion

        #region constructor
      
        public Moneda()
        {

        }

        #endregion

        #region properties

        public int MonedaID
        {
            get { return _moneda_id; }
            set {_moneda_id = value;}
        }

        public string Nombre
        {
            get { return _moneda_nombre; }
            set { _moneda_nombre = value; }
        }

        #endregion

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Moneda";
        }

        public override string NombreEntidad()
        {
            return "Moneda";
        }
        #endregion

        #region dataRowToObject

        public override void DataRowToObject(DataRow dr)
        {
            this.MonedaID = Convert.ToInt32(dr["moneda_id"]);
            this.Nombre = Convert.ToString(dr["moneda_nombre"]);

        }

        #endregion


        public DataSet TraerTodasLasMonedas()
        {
            DataSet ds = this.TraerListado("Completo");
            return ds;
        }
    }
}
