using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    public class Tipo_Publicacion : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Tipo;
        private string _Nombre;

        #endregion

        #region constructor

        public Tipo_Publicacion()
        {
            this.id_Tipo = -1;
            this.Nombre = "";
        }

        public Tipo_Publicacion(int unIdTipo)
        {
            this.id_Tipo = unIdTipo;
            DataSet ds = Tipo_Publicacion.ObtenerTiposPublicacionPorId(this.id_Tipo);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRowToObject(ds.Tables[0].Rows[0]);
            }

        }

        #endregion


        #region properties
        public int id_Tipo
        {
            get { return _id_Tipo; }
            set { _id_Tipo = value; }
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
            return "Tipos_Publicacion";
        }

        public override string NombreEntidad()
        {
            return "Tipo_Publicacion";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Tipo = Convert.ToInt32(dr["id_Tipo"]);
            this.Nombre = dr["Nombre"].ToString();
        }


        public static DataSet ObtenerTiposPublicacionPorId(int id_Tipo)
        {
            Tipo_Publicacion unTipo = new Tipo_Publicacion();
            unTipo.setearListaDeParametrosConIdTipo(id_Tipo);
            DataSet ds = unTipo.TraerListado(unTipo.parameterList, "PorId_Tipo");
            unTipo.parameterList.Clear();

            return ds;
        }

        public static DataSet obtenerTodos()
        {
            Tipo_Publicacion unTipo = new Tipo_Publicacion();
            DataSet ds = unTipo.TraerListado(unTipo.parameterList, "");

            return ds;
        }

        #endregion

        #region metodos privados
        private void setearListaDeParametrosConIdTipo(int id_Tipo)
        {
            parameterList.Add(new SqlParameter("@id_Tipo", id_Tipo));
        }
        #endregion
    }
}
