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
    public class Cheque : Base
    {
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos

        private int _cheque_id;
        private Cliente _clienteDestino;
        private Cuenta _cuenta;
        private int _importe;
        private DateTime _fecha;    //el numero de egreso seria el numero de cheqeu
        private Banco _banco = new Banco();
        
        #endregion

        #region constructor
      
        public Cheque()
        {

        }

        public Cheque(Cuenta unaCuenta, Cliente unCliente, Banco unBanco)
        {
            this.Cliente = unCliente;
            this.Cuenta = unaCuenta;
            this.banco = unBanco;
        }

        #endregion

        #region properties

        public int Cheque_id
        {
            get { return _cheque_id; }
            set {_cheque_id = value;}
        }

        public Cliente Cliente
        {
            get { return _clienteDestino; }
            set { _clienteDestino = value; }
        }
       
        public Cuenta Cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }

        public Banco banco
        {
            get { return _banco; }
            set { _banco = value; }
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
            return "Cheque";
        }

        public override string NombreEntidad()
        {
            return "Cheque";
        }
        #endregion


        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.Cliente.cliente_id = Convert.ToInt32(dr["cheque_cliente_id"]);
            this.Cuenta.cuenta_id = Convert.ToInt32(dr["cheque_cuenta_id"]);
            this.banco.Banco_id = Convert.ToInt32(dr["cheque_banco_id"]);
            this.Fecha = Convert.ToDateTime(dr["cheque_fecha"]);
            this.Importe = Convert.ToInt32(dr["cheque_importe"]);
        }

        public void setearListaParametrosCompleta()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@cheque_id",this.Cheque_id));
            parameterList.Add(new SqlParameter("@cheque_cliente_id",this.Cliente.cliente_id));
            parameterList.Add(new SqlParameter("@cheque_cuenta_id",this.Cuenta.cuenta_id));
            parameterList.Add(new SqlParameter("@cheque_banco_id",this.banco.Banco_id));
            parameterList.Add(new SqlParameter("@cheque_fecha", this.Fecha));
            parameterList.Add(new SqlParameter("@cheque_importe", this.Importe));       
        }

        public void GenerarChequeDevolverSuID()
        {
            this.setearListaParametrosCompleta();
            DataSet ds = this.GuardarYObtenerID(parameterList);
            //this.Cheque_id = Convert.ToInt32(ds.Tables[0].Rows[0]);

       }


    }
}
