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
    public class Banco : Base
    {

        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos
       
        private Int64 _banco_id;
        private string _nombre;
        private string _direccion;
        
        #endregion

        #region constructor
      
        public Banco()
        {

        }


        #endregion

        #region properties


        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public Int64 Banco_id
        {
            get { return _banco_id; }
            set { _banco_id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        #endregion

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Banco";
        }

        public override string NombreEntidad()
        {
            return "Banco";
        }
        #endregion

        #region dataRowToObject

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.Banco_id = Convert.ToInt64(dr["banco_id"]);
            this.Nombre = Convert.ToString(dr["banco_nombre"]);
            this.Direccion = Convert.ToString(dr["banco_direccion"]);
        }

        #endregion

        #region setters

        #endregion

        #region llamados a la bd
        public DataSet ObtenerTodosLosBancos()
        {
            DataSet ds = this.TraerListado("completo");
            return ds;
        }
        #endregion

        #region metodos privados

        #endregion
    }

    
}
