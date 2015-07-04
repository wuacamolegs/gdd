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
    public class Transferencia : Base
    {
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos

        private Transferencia transferencia_id;
        private Cuenta cuentaOrigen;
        private Cuenta cuentaDestino;
        private Int64 importe;
        private Int64 costo;
        private DateTime fecha;

        #endregion

        #region constructor

        public Transferencia()
        { 
        
        }

        public Transferencia(Cuenta unaCuentaOrigen, Cuenta unaCuentaDestino)
        {
            this.cuentaOrigen = unaCuentaOrigen;
            this.cuentaDestino = unaCuentaDestino;
        }

        #endregion

        #region properties

        public Cuenta CuentaOrigen
        {
            get { return cuentaOrigen; }
            set { cuentaOrigen = value; }
        }

        public Cuenta CuentaDestino
        {
            get { return cuentaDestino; }
            set { cuentaDestino = value; }
        }

        public Transferencia transferencia
        {
            get { return transferencia_id; }
            set { transferencia_id = value; }
        }

        public Int64 Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public Int64 Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        #endregion

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Transferencia";
        }

        public override string NombreEntidad()
        {
            return "Transferencia";
        }

        #endregion

        #region DataRowToObject

        public override void DataRowToObject(DataRow dr)
        {
            //this.transferencia_id = Convert.ToInt64(dr[""]);
            this.CuentaOrigen.cuenta_id = Convert.ToInt64(dr["transferencia_origen_cuenta_id"]);
            this.CuentaDestino.cuenta_id = Convert.ToInt64(dr["transferencia_destino_cuenta_id"]);
            this.Importe = Convert.ToInt64(dr["transferencia_importe"]);
            this.Costo = Convert.ToInt64(dr["transferencia_costo"]);
            this.Fecha = Convert.ToDateTime(dr["transferencia_fecha"]);
        }

        #endregion

        #region setters

        public void setearListaDeParametrosCuentasImporte()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@cuenta_origen", this.CuentaOrigen.cuenta_id));
            parameterList.Add(new SqlParameter("@cuenta_destino", this.CuentaDestino.cuenta_id));
            parameterList.Add(new SqlParameter("@cuenta_importe", this.Importe));
            parameterList.Add(new SqlParameter("@cuenta_fecha", this.Fecha));
        }

        #endregion

        #region llamados a la bd

        #endregion

        #region metodos privados

        public void GenerarTransferencia()
        {
            this.setearListaDeParametrosCuentasImporte();
            this.Guardar(this.parameterList);
        }

        #endregion


    }
}
