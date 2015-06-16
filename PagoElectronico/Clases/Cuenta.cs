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
        private int _saldo;
        private DateTime _fecha_apertura;
        private DateTime _fecha_cierre;
        private double _cuenta_id;
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

        public int saldo
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

        public double cuenta_id
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


        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.estado = Convert.ToBoolean(dr["cuenta_estado"]);
            this.saldo = Convert.ToInt32(dr["cuenta_saldo"]);
            this.cuenta_id = Convert.ToDouble(dr["cuenta_id"]);
            this.FechaApertura = Convert.ToDateTime(dr["cuenta_fecha_apertura"]);
            this.FechaCierre = Convert.ToDateTime(dr["cuenta_fecha_cierre"]);
        }

        #region setters

        public void setearListaDeParametrosConClienteID(int clienteID)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@cliente_id", clienteID));
        }

        public void setearListaDeParametrosConCuentaID(double cuenta_id)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@cuenta_id", cuenta_id));
        }
        
        private void setearListaDeParametrosConImporte(int importe)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@importe", importe));
        }

        #endregion

        #region llamados a la base

        public DataSet TraerCuentasActivasPorClienteID()
        {
            this.setearListaDeParametrosConClienteID(this.cliente.cliente_id);
            DataSet ds = this.TraerListado(this.parameterList, "ActivasPorClienteID");
            return ds;
        }

        public DataSet TraerCuentaPorCuentaID(double cuentaID)
        {
            this.setearListaDeParametrosConCuentaID(cuentaID);
            DataSet ds = this.TraerListado(this.parameterList, "porCuentaID");
            return ds;
        }

        public void GenerarRetiro(int importe)
        {
            this.setearListaDeParametrosConImporte(importe);
            Modificar(parameterList); //TODO habria que verificar que se modifico correctamente, y en caso contrario borrar el cheque generado
            //TODO Falta el stored procedure! 
        }

        #endregion

    }
}
