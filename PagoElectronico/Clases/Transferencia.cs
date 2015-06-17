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
        private int importe;
        private int costo;
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

        public int Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public int Costo
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

        public override void DataRowToObject(DataRow dr)
        {
            //this.transferencia_id = Convert.ToInt32(dr[""]);
            this.CuentaOrigen.cuenta_id = Convert.ToDouble(dr["transferencia_origen_cuenta_id"]);
            this.CuentaDestino.cuenta_id = Convert.ToDouble(dr["transferencia_destino_cuenta_id"]);
            this.Importe = Convert.ToInt32(dr["transferencia_importe"]);
            this.Costo = Convert.ToInt32(dr["transferencia_costo"]);
            this.Fecha = Convert.ToDateTime(dr["transferencia_fecha"]);
        }
    }
}
