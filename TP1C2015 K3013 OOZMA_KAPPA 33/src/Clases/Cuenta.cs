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
    public class Cuenta : Base
    {
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos
       
        private Cliente _cliente;
        private bool _estado;
        private Int64 _saldo;
        private DateTime _fecha_apertura;
        private DateTime _fecha_cierre;
        private Int64 _cuenta_id;
        private Usuario _usuario;
        private Int64 _tipo_cuenta;
        private Int64 _pais;
        private Int64 _moneda;

        #endregion

        #region constructor
      
        public Cuenta()
        {

        }

        public Cuenta(Cliente unCliente, Usuario unUsuario)
        {
            this.Cliente = unCliente;
            this.Usuario = unUsuario;
        }

        #endregion

        #region properties

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        public Int64 tipoCuenta
        {
            get { return _tipo_cuenta; }
            set { _tipo_cuenta = value; }
        }

        public Int64 Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }

        public Int64 Pais
        {
            get { return _pais; }
            set { _pais = value; }
        }

        public bool estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public Int64 saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        public DateTime FechaApertura
        {
            get { return _fecha_apertura; }
            set { _fecha_apertura = value; }
        }

        public DateTime FechaCierre
        {
            get { return _fecha_cierre; }
            set { _fecha_cierre = value; }
        }

        public Int64 cuenta_id
        {
            get { return _cuenta_id; }
            set { _cuenta_id = value; }
        }

        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        #endregion

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Cuenta";
        }

        public override string NombreEntidad()
        {
            return "Cuenta";
        }
        #endregion

        #region dataRowToObject

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.estado = Convert.ToBoolean(dr["cuenta_estado"]);
            this.saldo = Convert.ToInt64(dr["cuenta_saldo"]);
            this.cuenta_id = Convert.ToInt64(dr["cuenta_id"]);
            this.FechaApertura = Convert.ToDateTime(dr["cuenta_fecha_apertura"]);
            this.FechaCierre = Convert.ToDateTime(dr["cuenta_fecha_cierre"]);
        }

        public void DataRowToObjectCompleto(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.Cliente.cliente_id = Convert.ToInt64(dr["cuenta_cliente_id"]);
            this.estado = Convert.ToBoolean(dr["cuenta_estado"]);
            this.saldo = Convert.ToInt64(dr["cuenta_saldo"]);
            this.cuenta_id = Convert.ToInt64(dr["cuenta_id"]);
            this.Moneda = Convert.ToInt64(dr["cuenta_moneda_id"]);
            this.FechaApertura = Convert.ToDateTime(dr["cuenta_fecha_apertura"]);
            this.FechaCierre = Convert.ToDateTime(dr["cuenta_fecha_cierre"]);
            this.tipoCuenta = Convert.ToInt64(dr["cuenta_tipo_cuenta_id"]);
        }

        #endregion

        #region setters

        private void setearListaDeParametrosConUsuarioID(Int64 usuarioID)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@usuario_id", usuarioID));
        }

        public void setearListaDeParametrosConClienteID(Int64 clienteID)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@cliente_id", clienteID));
        }

        public void setearListaDeParametrosConCuentaID(Int64 cuenta_id)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@cuenta_id", cuenta_id));
        }
        
        private void setearListaDeParametrosConImporte(Int64 importe)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@importe", importe));
        }

        private void setearListaDeParametrosConClienteIDYFechaActual(Int64 clienteID)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@cliente_id", clienteID));
            parameterList.Add(new SqlParameter("@Fecha", Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]).ToString("yyyy-MM-dd HH:mm:ss")));
        }

        private void setearListaDeParametrosConFiltros()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Nombre", this.Cliente.Nombre));
            parameterList.Add(new SqlParameter("@Apellido", this.Cliente.Apellido));
            parameterList.Add(new SqlParameter("@Tipo_Dni", this.Cliente.TipoDocumento));
            parameterList.Add(new SqlParameter("@Dni", this.Cliente.Documento));
        }

        private void setearListaDeParametrosSinFecha()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Cuenta_id",this.cuenta_id));
            parameterList.Add(new SqlParameter("@Cliente_id", this.Cliente.cliente_id));
            parameterList.Add(new SqlParameter("@Pais", this.Pais));
            parameterList.Add(new SqlParameter("@Moneda", this.Moneda));
            parameterList.Add(new SqlParameter("@Tipo_Cuenta", this.tipoCuenta));
        }

        private void setearListaDeParametrosSinCuentaID()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Cliente_id", this.Cliente.cliente_id));
            parameterList.Add(new SqlParameter("@Pais", this.Pais));
            parameterList.Add(new SqlParameter("@Moneda", this.Moneda));
            parameterList.Add(new SqlParameter("@Tipo_Cuenta", this.tipoCuenta));
            parameterList.Add(new SqlParameter("@Fecha", Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"])));
        }

        private void setearListaDeParametrosCompleta()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@Cuenta_id", this.cuenta_id));
            parameterList.Add(new SqlParameter("@Cliente_id", this.Cliente.cliente_id));
            parameterList.Add(new SqlParameter("@Pais", this.Pais));
            parameterList.Add(new SqlParameter("@Moneda", this.Moneda));
            parameterList.Add(new SqlParameter("@Tipo_Cuenta", this.tipoCuenta));
            parameterList.Add(new SqlParameter("@Fecha", Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"])));
        }



        #endregion

        #region llamados a la base

        public DataSet TraerCuentasActivasPorClienteID()
        {
            this.setearListaDeParametrosConClienteIDYFechaActual(this.Cliente.cliente_id);
            DataSet ds = this.TraerListado(this.parameterList, "ActivasPorClienteID");
            return ds;
        }

        public DataSet TraerCuentasAbiertasPorClienteID()
        {
            this.setearListaDeParametrosConClienteIDYFechaActual(this.Cliente.cliente_id);
            DataSet ds = this.TraerListado(this.parameterList, "PorCliente_NoCerradas");
            return ds;
        }

        public DataSet TraerCuentaPorCuentaID(Int64 cuentaID)
        {
            this.setearListaDeParametrosConCuentaID(cuentaID);
            DataSet ds = this.TraerListado(this.parameterList, "porCuentaID");
            return ds;
        }

        public DataSet TraerCuentasPorClienteID()
        {
            this.setearListaDeParametrosConClienteID(this.Cliente.cliente_id);
            DataSet ds = this.TraerListado(this.parameterList, "PorClienteID");
            return ds;            
        }

        public DataSet TraerCuentasACobrarPorClienteID()
        {
            this.setearListaDeParametrosConClienteID(this.Cliente.cliente_id);
            DataSet ds = this.TraerListado(this.parameterList, "APagarPorClienteID");
            return ds;
        }

        public void UpdateCuenta()
        {
            this.setearListaDeParametrosCompleta();
            this.Modificar(parameterList);
        }

        public void InsertCuenta()
        {
            this.setearListaDeParametrosSinCuentaID();
            this.Guardar(parameterList);
        }

 
        public DataSet ObtenerCuentasPorUsuarioID(long usuarioID)
        {
            setearListaDeParametrosConUsuarioID(usuarioID);
            DataSet ds = this.TraerListado(parameterList, "PorUsuarioID");
            return ds;
        }



        public DataSet TraerCuentaPorFiltrosCliente()
        {
            setearListaDeParametrosConFiltros();
            DataSet ds = this.TraerListado(parameterList, "ConFiltros");
            return ds;
        }

        public Int64 TraerCantidadTransaccionesAPagar()
        {
            setearListaDeParametrosConCuentaID(this.cuenta_id);
            DataSet ds = this.TraerListado(parameterList, "CantidadTransaccionesAPagar");
            if (Convert.ToInt64(ds.Tables[0].Rows.Count) == 0){
              return 0;
            }else{
              return Convert.ToInt64(ds.Tables[0].Rows[0]["cantidad"]);
            }


        }

        public void EliminarCuenta()
        {
            setearListaDeParametrosConCuentaID(this.cuenta_id);
            this.Eliminar(parameterList);
        }

        #endregion

        #region metodos privados
        
        #endregion





    }
}
