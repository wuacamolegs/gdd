using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Conexion;
using Excepciones;
using Utilities;

namespace Clases
{
    public abstract class Base : IDisposable
    {
        // Textos para identificar los storeds en la base
        protected string _strInsertar = "insert";
        protected string _strModificar = "update";
        protected string _strEliminar = "delete";
        protected string _strDeshabilitar = "deshabilitar";
        protected string _strTraerListado = "traerListado";
        protected string _strRetornoID = "_RetornarID";

        public virtual void DataRowToObject(DataRow dr)
        {
            DataRowToObject(dr, true);
        }
        public virtual void DataRowToObject(DataRow dr, bool conEstructurasInternas)
        {
        }
        
        public abstract string NombreTabla();
        public abstract string NombreEntidad();

        public void Guardar(List<SqlParameter> parameterList)
        {
            SQLHelper.ExecuteDataSet(_strInsertar + NombreEntidad(), CommandType.StoredProcedure, NombreTabla(), parameterList);
        }

        public DataSet GuardarYObtenerID(List<SqlParameter> parameterList)
        {
            DataSet ds = SQLHelper.ExecuteDataSet(_strInsertar + NombreEntidad() + _strRetornoID, CommandType.StoredProcedure, NombreTabla(), parameterList);
            return ds;
        }

        public bool Modificar(List<SqlParameter> parameterList)
        {
            int result = SQLHelper.ExecuteNonQuery(_strModificar + NombreEntidad(), CommandType.StoredProcedure, parameterList);
            if (result > 0)
                return true;

            return false;
        }

        public void Eliminar(List<SqlParameter> parameterList)
        {
            SQLHelper.ExecuteNonQuery(_strEliminar + NombreEntidad(), CommandType.StoredProcedure, parameterList);
        }

        public void Deshabilitar(List<SqlParameter> parameterList)
        {
            SQLHelper.ExecuteNonQuery(_strDeshabilitar + NombreEntidad(), CommandType.StoredProcedure, parameterList);
        }

        public DataSet TraerListado(List<SqlParameter> parameterList, string Condiciones)
        {
            return SQLHelper.ExecuteDataSet(_strTraerListado + NombreTabla() + Condiciones, CommandType.StoredProcedure, NombreTabla(), parameterList);
        }

        /// <summary>
        /// Libero memoria
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
