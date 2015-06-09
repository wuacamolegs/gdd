using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Excepciones;
using Conexion;


namespace Clases
{
    public class Rol : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Rol;
        private string _nombre;
        private bool _habilitado;
        List<Funcionalidad> _funcionalidades = new List<Funcionalidad>();
        #endregion

        #region properties
        public int Id_Rol
        {
            get { return _id_Rol; }
            set { _id_Rol = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public bool Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
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
            this.Id_Rol = 0;
            this.Nombre = "";
            this.Habilitado = false;

        }
        public Rol(int unIdRol, string unNombre, bool unValorDeHabilitado){
            this.Id_Rol = unIdRol;
            this.Nombre = unNombre;
            this.Habilitado = unValorDeHabilitado;
            this.setearFuncionalidadesAlRol();

        }

        public Rol(string unNombre, bool unValorDeHabilitado)
        {
            this.Id_Rol = -1;
            this.Nombre = unNombre;
            this.Habilitado = unValorDeHabilitado;
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
            this.Id_Rol = Convert.ToInt32(dr["id_Rol"]);
            this.Nombre = dr["Nombre"].ToString();
            this.Habilitado = Convert.ToBoolean(dr["Habilitado"]);
        }

        public static DataSet ObtenerRolesPorUsuario(int id_Usuario)
        {
            Rol unRol = new Rol();
            unRol.setearListaDeParametrosConIdUsuario(id_Usuario);
            DataSet ds = unRol.TraerListado(unRol.parameterList, "PorId_Usuario");
            unRol.parameterList.Clear();

            return ds;
        }

        public void setearFuncionalidadesAlRol()
        {
            DataSet dsFuncionalidades = Funcionalidad.ObtenerFuncionalidadesPorRol(this.Id_Rol);
            foreach (DataRow dr in dsFuncionalidades.Tables[0].Rows)
            {
                Funcionalidad unaFunc = new Funcionalidad();
                unaFunc.DataRowToObject(dr);
                this.Funcionalidades.Add(unaFunc);
            }
            
            
        }

        public static DataSet obtenerTodosLosRoles()
        {
            Rol unRol = new Rol();
            return unRol.TraerListado(unRol.parameterList, "");
        }

        public static DataSet obtenerTodosLosRolesConFiltros(string unNombre, bool unValorDeHabilitado)
        {
            Rol unRol = new Rol(unNombre, unValorDeHabilitado);
            unRol.setearListaDeParametrosConNombreYHabilitado(unRol.Nombre, unRol.Habilitado);
            DataSet ds = unRol.TraerListado(unRol.parameterList, "ConFiltros");
            unRol.parameterList.Clear();
            return ds;
        }


        public void guardarDatosDeRolNuevo()
        {
            //compruebo que no exista ya el rol creado
            DataSet dsParaComprobarExistencia = Rol.obtenerRolPorNombre(this.Nombre);
            if (dsParaComprobarExistencia.Tables[0].Rows.Count != 0)
                throw new EntidadExistenteException("un rol");

            //creo el rol nuevo y obtengo el id
            setearListaDeParametrosConNombreYHabilitado(this.Nombre, this.Habilitado);
            DataSet dsNuevoRol = this.GuardarYObtenerID(parameterList);
            parameterList.Clear();
            
            if (dsNuevoRol.Tables[0].Rows.Count > 0)
            {
                //seteo el id al rol y guardo las funcionalidades
                this.Id_Rol = Convert.ToInt32(dsNuevoRol.Tables[0].Rows[0]["id_Rol"]);
                guardarFuncionalidades();
            }
            else
            {
                throw new BadInsertException();
            }
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
            setearListaDeParametrosConIdRolNombreYHabilitado(this.Nombre, this.Habilitado);

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

        public void modificarFuncionalidades()
        {
            //lo que hago es eliminar todas las funcionalidades que tenia el rol y volver a crearlas
            //al volver a crearlas, si eran las mismas, vuelvo a obtener las mismas, si son distintas, las 
            //obtengo modificadas
            setearListaDeParametrosConIdRol();
            SQLHelper.ExecuteDataSet(_strEliminar + "Rol_Funcionalidad" + "_PorIdRol", CommandType.StoredProcedure, "Rol_Funcionalidad", parameterList);
            parameterList.Clear();
            guardarFuncionalidades();
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

        #endregion

        #region metodos privados
        private void setearListaDeParametrosConIdUsuario(int id_Usuario)
        {
            parameterList.Add(new SqlParameter("@id_Usuario", id_Usuario));
        }

        private void setearListaDeParametrosConIdRol()
        {
            parameterList.Add(new SqlParameter("@id_Rol", this.Id_Rol));
        }

        private void setearListaDeParametrosConIdFuncionalidadEIdRol(int id_func)
        {
            parameterList.Add(new SqlParameter("@id_Rol", this.Id_Rol));
            parameterList.Add(new SqlParameter("@id_Funcionalidad", id_func));
        }

        private void setearListaDeParametrosConNombreYHabilitado(string unNombre, bool unValorDeHabilitado)
        {
            parameterList.Add(new SqlParameter("@Nombre", unNombre));
            parameterList.Add(new SqlParameter("@Habilitado", unValorDeHabilitado));
        }

        private void setearListaDeParametrosConIdRolNombreYHabilitado(string unNombre, bool unValorDeHabilitado)
        {
            parameterList.Add(new SqlParameter("@id_Rol", this.Id_Rol));
            parameterList.Add(new SqlParameter("@Nombre", unNombre));
            parameterList.Add(new SqlParameter("@Habilitado", unValorDeHabilitado));
        }

        private void setearListaDeParametrosConNombre(string unNombre)
        {
            parameterList.Add(new SqlParameter("@Nombre", unNombre));
        }

        #endregion

    }
}
