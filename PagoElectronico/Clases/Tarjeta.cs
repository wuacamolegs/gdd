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
    public class Tarjeta : Base
    {

        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos

        private int _tarjeta_id;
        private Cuenta _cuenta;
        private string _codigo_seguridad;
        private DateTime _fecha_emision;
        private DateTime _fecha_vencimiento;
        
        #endregion

        #region constructor
      
        public Tarjeta()
        {

        }

        #endregion

        #region properties

        public int tarjeta_id
        {
            get { return _tarjeta_id; }
            set {_tarjeta_id = value;}
        }

        public Cuenta Cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }
       
        public DateTime FechaVencimiento
        {
            get { return _fecha_vencimiento; }
            set { _fecha_vencimiento = value; }
        }

        public string CodigoSeguridad
        {
            get { return _codigo_seguridad; }
            set { _codigo_seguridad = value; }
        }

        public DateTime FechaEmision
        {
            get { return _fecha_emision; }
            set { _fecha_emision = value; }
        }


        #endregion

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Tarjeta";
        }

        public override string NombreEntidad()
        {
            return "Tarjeta";
        }
        #endregion

        #region dataRowToObject
        public override void DataRowToObject(DataRow dr)
        {
            this.tarjeta_id = Convert.ToInt32(dr["tarjeta_id"]);
            this.CodigoSeguridad = Convert.ToString(dr["tarjeta_codigo_seguridad"]);
            this.FechaEmision = Convert.ToDateTime(dr["tarjeta_fecha_emision"]);
            this.FechaVencimiento = Convert.ToDateTime(dr["tarjeta_vencimiento"]);
            this.Cuenta.cuenta_id = Convert.ToInt32(dr["tarjeta_cuenta_numero"]);
        }
        #endregion

        #region setters
        #endregion

        #region lamados a la base
        #endregion

        #region metodos privados
        #endregion
    }
}
