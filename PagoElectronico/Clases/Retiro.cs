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
    public class Retiro : Base
    {
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos
       
        private Cheque _cheque;
        private Cuenta _cuenta;
        private Int64 _retiro_id;    //TODO: me parece que hay cosas de mas. si en el cheque ya dice el importe y la fecha por ahi no hace falta uqe este en retiro. VER.
        private DateTime _fecha;
        private Int64 _importe;
        
        #endregion

        #region constructor
      
        public Retiro()
        {

        }

        public Retiro(Cuenta unaCuenta, Cheque unCheque)
        {
            this.Cuenta = unaCuenta;
            this.Cheque = unCheque;
        }

        #endregion

        #region properties

        public Cheque Cheque
        {
            get { return _cheque; }
            set { _cheque = value; }
        }
       
        public Cuenta Cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }

        public Int64 Importe
        {
            get { return _importe; }
            set { _importe = value; }
        }

        public Int64 Retiro_id
        {
            get { return _retiro_id; }
            set { _retiro_id = value; }
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
            return "Retiro";
        }

        public override string NombreEntidad()
        {
            return "Retiro";
        }
        #endregion

        #region dataRowToObject
        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.Cuenta.cuenta_id = Convert.ToInt64(dr["retiro_cuenta_id"]);
            this.Cheque.Cheque_id = Convert.ToInt64(dr["retiro_cheque_id"]);
            this.Retiro_id= Convert.ToInt64(dr["retiro_id"]);
            this.Fecha = Convert.ToDateTime(dr["retiro_fecha"]);
            this.Importe = Convert.ToInt64(dr["retiro_importe"]);
        }

        #endregion

        #region setters

        #endregion

        #region llamados a la base
        public void GenerarRetiroDevolverSuID()
        {
            this.setearListaParametrosCompleta();
            DataSet ds = this.GuardarYObtenerID(parameterList);
            this.Retiro_id = Convert.ToInt64(ds.Tables[0].Rows[0]["retiro_id"]);
        }
        #endregion

        #region metodos privados

        public void setearListaParametrosCompleta()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@retiro_cheque_id", this.Cheque.Cheque_id));
            parameterList.Add(new SqlParameter("@retiro_cuenta_id", this.Cuenta.cuenta_id));
            parameterList.Add(new SqlParameter("@retiro_fecha", this.Fecha));
            parameterList.Add(new SqlParameter("@retiro_importe", this.Importe));
        }

        #endregion


       
        

    }
}
