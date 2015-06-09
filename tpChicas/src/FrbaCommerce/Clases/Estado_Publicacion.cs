using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    public class Estado_Publicacion : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Estado;
        private string _Nombre;
       
        #endregion

        #region constructor

            public Estado_Publicacion()
            {
                this.id_Estado = -1;
                this.Nombre = "";
            }

            public Estado_Publicacion(int unIdEstado)
            {
                this.id_Estado = unIdEstado;
                DataSet ds = Estado_Publicacion.ObtenerEstadoPorIdEstado(this.id_Estado);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRowToObject(ds.Tables[0].Rows[0]);
                }

            }
        #endregion


        #region properties
        public int id_Estado
        {
            get { return _id_Estado; }
            set { _id_Estado = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Estados_Publicacion";
        }

        public override string NombreEntidad()
        {
            return "Estado_Publicacion";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Estado = Convert.ToInt32(dr["id_Estado"]);
            this.Nombre = dr["Nombre"].ToString();
        }


        public static DataSet ObtenerEstadoPorIdEstado(int id_Estado)
        {
            Estado_Publicacion unEstado = new Estado_Publicacion();
            unEstado.setearListaDeParametrosConIdEstado(id_Estado);
            DataSet ds = unEstado.TraerListado(unEstado.parameterList, "PorId_Estado");
            unEstado.parameterList.Clear();

            return ds;
        }

        public static DataSet obtenerTodos()
        {
            Estado_Publicacion unEstado = new Estado_Publicacion();
            DataSet ds = unEstado.TraerListado(unEstado.parameterList, "");

            return ds;
        }

        public static DataSet obtenerTodosLosEditablesConPublicada()
        {
            Estado_Publicacion unEstado = new Estado_Publicacion();
            DataSet ds = unEstado.TraerListado(unEstado.parameterList, "EditablesConPublicada");

            return ds;
        }

        #endregion

        #region metodos privados
        private void setearListaDeParametrosConIdEstado(int id_Estado)
        {
            parameterList.Add(new SqlParameter("@id_Estado", id_Estado));
        }
        #endregion
    }
}
