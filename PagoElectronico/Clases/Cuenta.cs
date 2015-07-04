﻿using System;
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

        #endregion

        #region constructor
      
        public Cuenta()
        {

        }

        public Cuenta(Cliente unCliente, Usuario unUsuario)
        {
            this.cliente = unCliente;
            this.Usuario = unUsuario;
        }

        #endregion

        #region properties

        public Cliente cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
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
            parameterList.Add(new SqlParameter("@Nombre", this.cliente.Nombre));
            parameterList.Add(new SqlParameter("@Apellido", this.cliente.Apellido));
            parameterList.Add(new SqlParameter("@Tipo_Dni", this.cliente.TipoDocumento));
            parameterList.Add(new SqlParameter("@Dni", this.cliente.Documento));
        }

        #endregion

        #region llamados a la base

        public DataSet TraerCuentasActivasPorClienteID()
        {
            this.setearListaDeParametrosConClienteIDYFechaActual(this.cliente.cliente_id);
            DataSet ds = this.TraerListado(this.parameterList, "ActivasPorClienteID");
            return ds;
        }

        public DataSet TraerCuentasAbiertasPorClienteID()
        {
            this.setearListaDeParametrosConClienteIDYFechaActual(this.cliente.cliente_id);
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
            this.setearListaDeParametrosConClienteID(this.cliente.cliente_id);
            DataSet ds = this.TraerListado(this.parameterList, "PorClienteID");
            return ds;            
        }

        public DataSet TraerCuentasACobrarPorClienteID()
        {
            this.setearListaDeParametrosConClienteID(this.cliente.cliente_id);
            DataSet ds = this.TraerListado(this.parameterList, "APagarPorClienteID");
            return ds;
        }

        #endregion

        #region metodos privados

        #endregion



        public DataSet ObtenerCuentasPorUsuarioID(long usuarioID)
        {
            setearListaDeParametrosConUsuarioID(usuarioID);
            DataSet ds = this.TraerListado(parameterList,"PorUsuarioID");
            return ds;
        }



        public DataSet TraerCuentaPorFiltrosCliente()
        {//TODO: CUANDO GINO SUBA SUS CAMBIOS AGREGAR EN EL SP TRAERCUENTAFILTROS EL CLIENTE_ESTADO
            setearListaDeParametrosConFiltros();
            DataSet ds = this.TraerListado(parameterList, "ConFiltros");
            return ds;
        }


    }
}
