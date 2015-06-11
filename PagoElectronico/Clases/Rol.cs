using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excepciones;
using Conexion;


namespace Clases
{
    public class Rol : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _Rol_id;
        private string _nombre;
        private bool _estado;
        List<Funcionalidad> _funcionalidades = new List<Funcionalidad>();
        #endregion

        #region properties
        public int rol_id
        {
            get { return _Rol_id; }
            set { _Rol_id = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public List<Funcionalidad> Funcionalidades
        {
            get { return _funcionalidades; }
            set { _funcionalidades = value; }
        }

        #endregion

        #region constructor

        public Rol()
        {
            this.rol_id = 0;
            this.Nombre = "";
            this.Estado = false;

        }

        #endregion

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Roles";
        }

        public override string NombreEntidad()
        {
            return "Rol";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.rol_id = Convert.ToInt32(dr["rol_id"]);
            this.Nombre = dr["rol_nombre"].ToString();
            this.Estado = Convert.ToBoolean(dr["rol_estado"]);
        }
        
        #endregion


        #region obtener datos bd

        public static DataSet ObtenerRolesPorUsuario(int id_Usuario)
        {
            Rol unRol = new Rol();
            unRol.setearListaDeParametrosConIdUsuario(id_Usuario);
            DataSet ds = unRol.TraerListado(unRol.parameterList, "PorId_Usuario");
            unRol.parameterList.Clear();

            return ds;
        }

        #endregion


        #region metodos privados

        private void setearListaDeParametrosConIdUsuario(int id_Usuario)
        {
            parameterList.Add(new SqlParameter("@usuario_id", id_Usuario));
        }

        public List<Funcionalidad> setearFuncionalidadesAlRol()
        {

            DataSet dsFuncionalidades = Funcionalidad.ObtenerFuncionalidadesPorRol(this.rol_id);
            foreach (DataRow dr in dsFuncionalidades.Tables[0].Rows)
            {
                Funcionalidad unaFunc = new Funcionalidad();
                unaFunc.DataRowToObject(dr);
                this.Funcionalidades.Add(unaFunc);
            }
            return this.Funcionalidades;


        }
        #endregion

    } 
  }