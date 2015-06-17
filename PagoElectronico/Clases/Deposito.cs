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
   public class Deposito : Base
    {
         #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos
       
        private Cuenta _cuenta;
        private double _deposito_id;    
        private DateTime _fecha;
        private int _importe;
        private Cliente _cliente;
        private Tarjeta _tarjeta;
        

       // MONEDA SE PONE? ES POR DEFAULT U$D Y EN CUENTA NO SE PUSO.
        
        #endregion

        #region constructor
      
        public Deposito()
        {

        }

        public Deposito(Cuenta unaCuenta, Cliente unCliente, Tarjeta unaTarjeta)
        {
            this.Cuenta = unaCuenta;
            this.Cliente = unCliente;
            this.Tarjeta = unaTarjeta;
          
        }

        public 

        #endregion

        #region properties

        public Tarjeta Tarjeta
        {
            get { return _tarjeta; }
            set { _tarjeta = value; }
        }
       
        public Cuenta Cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }

        public int Importe
        {
            get { return _importe; }
            set { _importe = value; }
        }

        public double Deposito_id
        {
            get { return _deposito_id; }
            set { _deposito_id = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
       


        #endregion

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Deposito";
        }

        public override string NombreEntidad()
        {
            return "Deposito";
        }
        #endregion


        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.Cuenta.cuenta_id = Convert.ToInt32(dr["deposito_cuenta_id"]);
            this.Deposito_id= Convert.ToInt32(dr["deposito_id"]);
            this.Fecha = Convert.ToDateTime(dr["deposito_fecha"]);
            this.Importe = Convert.ToInt32(dr["deposito_importe"]);
            this.Tarjeta.tarjeta_id = Convert.ToInt32(dr["deposito_tarjeta_id"]);
            this.Cliente.cliente_id = Convert.ToInt32(dr["deposito_cliente_id"]);
        }

        public void GenerarDepositoDevolverSuID()
        {
            this.setearListaParametrosCompleta();
            DataSet ds = this.GuardarYObtenerID(parameterList);
            this.Deposito_id = Convert.ToDouble(ds.Tables[0].Rows[0]["deposito_id"]);
        }

        public void setearListaParametrosCompleta()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@deposito_cuenta_id", this.Cuenta.cuenta_id));
            parameterList.Add(new SqlParameter("@deposito_fecha", this.Fecha));
            parameterList.Add(new SqlParameter("@deposito_importe", this.Importe));
            parameterList.Add(new SqlParameter("deposito_tarjeta_id", this.Tarjeta.tarjeta_id));
            parameterList.Add(new SqlParameter("deposito_cliente_id", this.Cliente.cliente_id));
        }

        

    }
}
