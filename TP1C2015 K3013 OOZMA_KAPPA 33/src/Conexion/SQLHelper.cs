using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Data;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using Excepciones;

namespace Conexion
{
    public class SQLHelper
    {
        #region atributos

        private static SqlConnection _cnnConexion;
        private static SqlTransaction _trans;

        #endregion

        #region properties

        public static SqlConnection CnnConexion
        {
            get { return SQLHelper._cnnConexion; }
            set { SQLHelper._cnnConexion = value; }
        }

        public static SqlTransaction Trans
        {
            get { return SQLHelper._trans; }
            set { SQLHelper._trans = value; }
        }

        #endregion

        public static void Inicializar()
        {
            try
            {
                CnnConexion = new SqlConnection(SQLHelper.getConnectionString);
                CnnConexion.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Cerrar()
        {
            try
            {
                CnnConexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string getConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            }
        }

        #region Execute Reader

        public static SqlDataReader ExecuteReader(string nombreProcedure)
        {
            return ExecuteReader(nombreProcedure, CommandType.StoredProcedure);
        }
        public static SqlDataReader ExecuteReader(string nombreProcedure, CommandType Tipo)
        {
            return ExecuteReader(nombreProcedure, Tipo, null);
        }
        public static SqlDataReader ExecuteReader(string nombreProcedure, List<SqlParameter> ParameterList)
        {
            return ExecuteReader(nombreProcedure, CommandType.StoredProcedure, ParameterList);

        }
        public static SqlDataReader ExecuteReader(string nombreProcedure, CommandType Tipo, List<SqlParameter> ParameterList)
        {
            SqlConnection cnnConexion;
            SqlCommand cmdComando;
            SqlDataReader rdrReader;


            cnnConexion = new SqlConnection(SQLHelper.getConnectionString);
            cnnConexion.Open();

            cmdComando = new SqlCommand(nombreProcedure, cnnConexion);
            cmdComando.CommandType = Tipo;

            if (ParameterList != null)
            {
                for (int i = 0; i < ParameterList.Count; i++)
                {

                    cmdComando.Parameters.AddWithValue(ParameterList[i].ParameterName, ParameterList[i].Value);
                }
            }

            rdrReader = cmdComando.ExecuteReader();

            return rdrReader;

        }
        #endregion

        #region ExecuteNonQuery

        public static int ExecuteNonQuery(string nombreProcedure)
        {
            return ExecuteNonQuery(nombreProcedure, CommandType.Text);
        }
        public static int ExecuteNonQuery(string nombreProcedure, CommandType Tipo)
        {
            return ExecuteNonQuery(nombreProcedure, Tipo, null);
        }
        public static int ExecuteNonQuery(string nombreProcedure, List<SqlParameter> ParameterList)
        {
            return ExecuteNonQuery(nombreProcedure, CommandType.StoredProcedure, ParameterList);
        }

        public static int ExecuteNonQuery(string nombreProcedure, CommandType Tipo, List<SqlParameter> ParameterList)
        {
            SqlCommand cmdComand;
            int _cantDatos;


            if (Tipo == CommandType.StoredProcedure)
            {
                nombreProcedure = "OOZMA_KAPPA." + nombreProcedure;
            }

            cmdComand = new SqlCommand(nombreProcedure, _cnnConexion);
            try
            {

                cmdComand.CommandType = Tipo;
                if (Trans != null && Trans.Connection != null)
                {
                    cmdComand.Transaction = Trans;
                }

                cargarParametros(ParameterList, cmdComand);

                _cantDatos = cmdComand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ErrorConsultaException(nombreProcedure + ": " + ex.Message);
            }
            finally
            {
                cmdComand.Dispose();
            }
            return _cantDatos;
        }

        #endregion

        #region DataSet

        public static DataSet ExecuteDataSet(string nombreProcedure)
        {
            return ExecuteDataSet(nombreProcedure, CommandType.StoredProcedure);
        }
        public static DataSet ExecuteDataSet(string nombreProcedure, CommandType Tipo)
        {
            return ExecuteDataSet(nombreProcedure, Tipo, "");
        }
        public static DataSet ExecuteDataSet(string nombreProcedure, CommandType Tipo, string strTabla)
        {
            return ExecuteDataSet(nombreProcedure, Tipo, strTabla, null);
        }
        public static DataSet ExecuteDataSet(string nombreProcedure, CommandType commandType, List<SqlParameter> ParameterList)
        {
            return ExecuteDataSet(nombreProcedure, commandType, "", ParameterList);
        }

        public static DataSet ExecuteDataSet(string nombreProcedure, CommandType Tipo, string strTabla, List<SqlParameter> ParameterList)
        {
            DataSet ds = new DataSet();

            SqlCommand cmdComando;

            if (Tipo == CommandType.StoredProcedure)
            {
                nombreProcedure = "OOZMA_KAPPA." + nombreProcedure;
            }

            cmdComando = new SqlCommand(nombreProcedure, _cnnConexion);
            cmdComando.CommandTimeout = 150;
            cmdComando.CommandType = Tipo;
            try
            {
                if (Trans != null && Trans.Connection != null)
                {
                    cmdComando.Transaction = Trans;
                }
                SqlDataAdapter dtAdapter = new SqlDataAdapter(cmdComando);

                cargarParametros(ParameterList, cmdComando);

                if (String.IsNullOrEmpty(strTabla))
                    dtAdapter.Fill(ds);
                else
                    dtAdapter.Fill(ds, strTabla);

            }
            catch (Exception ex)
            {
                throw new ErrorConsultaException(nombreProcedure + ": " + ex.Message);
            }
            finally
            {
                cmdComando.Dispose();
            }

            return ds;
        }

        #endregion

        private static void cargarParametros(List<SqlParameter> ParameterList, SqlCommand cmdComand)
        {
            if (ParameterList != null)
            {
                for (int i = 0; i < ParameterList.Count; i++)
                {
                    if (ParameterList[i].Value == null)
                    {
                        ParameterList[i].Value = string.Empty;
                    }
                    cmdComand.Parameters.AddWithValue(ParameterList[i].ParameterName, ParameterList[i].Value);
                }

            }
        }
    }
}