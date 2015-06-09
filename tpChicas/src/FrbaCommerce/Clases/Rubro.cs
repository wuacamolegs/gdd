using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    public class Rubro : Base 
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Rubro;
        private string _Descripcion;
        private bool _Activo;

        #endregion

        #region constructor
        public Rubro()
        {
            this.id_Rubro = -1;
            this.Descripcion = "";
            this.Activo = false;
        }

        public Rubro(int unIdRubro)
        {
            this.id_Rubro = unIdRubro;
            DataSet ds = Rubro.ObtenerRubroPorId(this.id_Rubro);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRowToObject(ds.Tables[0].Rows[0]);
            }

        }
        #endregion

        #region properties
        public int id_Rubro
        {
            get { return _id_Rubro; }
            set { _id_Rubro = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public bool Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }

        #endregion

        #region metodos publicos

        public static DataSet ObtenerRubroPorId(int id_Rubro)
        {
            Rubro unRubro = new Rubro();
            unRubro.setearListaDeParametrosConIdRubro(id_Rubro);
            DataSet ds = unRubro.TraerListado(unRubro.parameterList, "PorId_Rubro");
            unRubro.parameterList.Clear();

            return ds;
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Rubro = Convert.ToInt32(dr["id_Rubro"]);
            this.Descripcion = dr["Descripcion"].ToString();
            this.Activo = Convert.ToBoolean(dr["Activo"]);
        }


        public override string NombreTabla()
        {
            return "Rubros";
        }

        public override string NombreEntidad()
        {
            return "Rubro";
        }

        public static DataSet obtenerTodas()
        {
            Rubro miRubro = new Rubro();
            DataSet ds = miRubro.TraerListado(miRubro.parameterList, "");
            return ds;
        }

        public static List<Rubro> obtenerPorCodPublicacion(int cod_Publicacion)
        {
            Rubro miRubro = new Rubro();
            miRubro.setearListaDeParametrosConCodPublicacion(cod_Publicacion);
            DataSet ds = miRubro.TraerListado(miRubro.parameterList, "PorCodPublicacion");
            miRubro.parameterList.Clear();
            List<Rubro> listaADevolver = new List<Rubro>();
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Rubro unRubro = new Rubro();
                unRubro.DataRowToObject(dr);
                listaADevolver.Add(unRubro);
            }
            return listaADevolver;
        }


        #endregion

        #region metodos privados
        private void setearListaDeParametrosConIdRubro(int id_Rubro)
        {
            parameterList.Add(new SqlParameter("@id_Rubro", id_Rubro));
        }

        private void setearListaDeParametrosConCodPublicacion(int cod_Publicacion)
        {
            parameterList.Add(new SqlParameter("@cod_Publicacion", cod_Publicacion));
        }
        #endregion

    }
}
