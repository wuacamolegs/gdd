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
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos
        private Int64 _Rol_id;
        private string _nombre;
        private bool _estado;
        List<Funcionalidad> _funcionalidades = new List<Funcionalidad>();
        #endregion

        #region properties
        public Int64 rol_id
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
        public Rol(Int64 unIdRol, string unNombre, bool unValorDeEstado)
        {
            this.rol_id = unIdRol;
            this.Nombre = unNombre;
            this.Estado = unValorDeEstado;
            this.setearFuncionalidadesAlRol();

        }

        public Rol(string unNombre, bool unValorDeEstado)
        {
            this.rol_id = -1;
            this.Nombre = unNombre;
            this.Estado = unValorDeEstado;
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

        
        #endregion

        #region dataRowToObject

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.rol_id = Convert.ToInt64(dr["rol_id"]);
            this.Nombre = dr["rol_nombre"].ToString();
            this.Estado = Convert.ToBoolean(dr["rol_estado"]);
        }

        #endregion

        #region setters

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

        private void setearListaDeParametrosConIdUsuario(Int64 id_Usuario)
        {
            parameterList.Add(new SqlParameter("@usuario_id", id_Usuario));
        }

        private void setearListaDeParametrosConIdRol()
        {
            parameterList.Add(new SqlParameter("@rol_id", this.rol_id));
        }

        private void setearListaDeParametrosConIdFuncionalidadEIdRol(Int64 id_func)
        {
            parameterList.Add(new SqlParameter("@rol_id", this.rol_id));
            parameterList.Add(new SqlParameter("@funcionalidad_id", id_func));
        }

        private void setearListaDeParametrosConNombreYHabilitado(string unNombre, bool unValorDeEstado)
        {
            parameterList.Add(new SqlParameter("@rol_nombre", unNombre));
            parameterList.Add(new SqlParameter("@rol_estado", unValorDeEstado));
        }

        private void setearListaDeParametrosConIdRolNombreYHabilitado(string unNombre, bool unValorDeEstado)
        {
            parameterList.Add(new SqlParameter("@rol_id", this.rol_id));
            parameterList.Add(new SqlParameter("@rol_nombre", unNombre));
            parameterList.Add(new SqlParameter("@rol_estado", unValorDeEstado));
        }

        private void setearListaDeParametrosConNombre(string unNombre)
        {
            parameterList.Add(new SqlParameter("@rol_nombre", unNombre));
        }


        #endregion

        #region obtener datos bd

        public static DataSet ObtenerRolesPorUsuario(Int64 id_Usuario)
        {
            Rol unRol = new Rol();
            unRol.setearListaDeParametrosConIdUsuario(id_Usuario);
            DataSet ds = unRol.TraerListado(unRol.parameterList, "PorId_Usuario");
            unRol.parameterList.Clear();

            return ds;
        }


        public DataSet traerRoles()
        {
            DataSet ds = this.TraerListado("");
            return ds;
        }


        public  DataSet obtenerTodosLosRolesConFiltros(string unNombre, bool unValorDeEstado)
        {
            Rol unRol = new Rol(unNombre, unValorDeEstado);
            unRol.setearListaDeParametrosConNombreYHabilitado(unRol.Nombre, unRol.Estado);
            DataSet ds = unRol.TraerListado(unRol.parameterList, "ConFiltros");
            unRol.parameterList.Clear();
            return ds;
        }

        public static DataSet obtenerRolPorNombre(string unNombre)
        {
            Rol unRol = new Rol(unNombre, true);
            unRol.setearListaDeParametrosConNombre(unRol.Nombre);
            DataSet ds = unRol.TraerListado(unRol.parameterList, "PorNombre");
            unRol.parameterList.Clear();
            return ds;
        }

        public void ModificarDatos()
        {
            setearListaDeParametrosConIdRolNombreYHabilitado(this.Nombre, this.Estado);

            if (this.Modificar(parameterList))
            {
                parameterList.Clear();
                modificarFuncionalidades();
            }

        }

        public void guardarFuncionalidades()
        {
            foreach (Funcionalidad unaFunc in this.Funcionalidades)
            {
                setearListaDeParametrosConIdFuncionalidadEIdRol(unaFunc.id_Funcionalidad);
                SQLHelper.ExecuteDataSet(_strInsertar + "Rol_Funcionalidad", CommandType.StoredProcedure, "Rol_Funcionalidad", parameterList);
                parameterList.Clear();

            }
        }

        public void Deshabilitar()
        {
            setearListaDeParametrosConIdRol();
            Deshabilitar(parameterList);
            parameterList.Clear();
        }

        public void Eliminar()
        {
            setearListaDeParametrosConIdRol();
            DataSet ds = SQLHelper.ExecuteDataSet("validarRolEnUsuarios", CommandType.StoredProcedure, parameterList);
            if (ds.Tables[0].Rows.Count == 0)
                Eliminar(parameterList);
            else
                throw new Exception("No se puede eliminar porque hay usuarios que utilizan este rol");
            parameterList.Clear();
        }

        public void modificarFuncionalidades()
        {
            //lo que hago es eliminar todas las funcionalidades que tenia el rol y volver a crearlas
            //al volver a crearlas, si eran las mismas, vuelvo a obtener las mismas, si son distInt64as, las 
            //obtengo modificadas
            setearListaDeParametrosConIdRol();
            SQLHelper.ExecuteDataSet(_strEliminar + "Rol_Funcionalidad" + "_PorIdRol", CommandType.StoredProcedure, "Rol_Funcionalidad", parameterList);
            parameterList.Clear();
            guardarFuncionalidades();
        }

        public void guardarDatosDeRolNuevo()
        {
            //compruebo que no exista ya el rol creado
            DataSet dsParaComprobarExistencia = Rol.obtenerRolPorNombre(this.Nombre);
            if (dsParaComprobarExistencia.Tables[0].Rows.Count != 0)
                throw new EntidadExistenteException("un rol");

            //creo el rol nuevo y obtengo el id
            setearListaDeParametrosConNombreYHabilitado(this.Nombre, this.Estado);
            DataSet dsNuevoRol = this.GuardarYObtenerID(parameterList);
            parameterList.Clear();

            if (dsNuevoRol.Tables[0].Rows.Count > 0)
            {
                //seteo el id al rol y guardo las funcionalidades
                this.rol_id = Convert.ToInt64(dsNuevoRol.Tables[0].Rows[0]["rol_id"]);
                guardarFuncionalidades();
            }
            else
            {
                throw new BadInsertException();
            }
        }


        #endregion

        #region metodos privados

        
        #endregion


    } 
  }