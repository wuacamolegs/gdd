using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Configuration;
using Excepciones;
using Utilities;


namespace Clases
{
    public class Usuario : Base
    {
        
        #region variables 
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos

        private int _id_Usuario;
        private string _username;
        private string _clave;
        private bool _claveAutoGenerada;
        private bool _activo;
        private Rol _rol;
        
        #endregion

        #region constructor
        public Usuario()
        {
            
        }
        public Usuario(int unIdUsuario){
            this.Id_Usuario = unIdUsuario;
            DataSet ds = Usuario.ObtenerUsuarioPorId(this.Id_Usuario);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRowToObject(ds.Tables[0].Rows[0]);
                
                
            }
        }
        #endregion

        #region properties

        public int Id_Usuario
        {
            get { return _id_Usuario; }
            set { _id_Usuario = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        
        public string Clave
        {
            get { return _clave; }
            set { _clave = value; }
        }
        

        public bool ClaveAutoGenerada
        {
            get { return _claveAutoGenerada; }
            set { _claveAutoGenerada = value; }
        }

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
        public Rol Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }
        #endregion 

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Usuarios";
        }

        public override string NombreEntidad()
        {
            return "Usuario";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.Id_Usuario = Convert.ToInt32(dr["id_Usuario"]);
            this.Username = dr["Username"].ToString();
            this.Clave =  dr["Clave"].ToString();
            this.ClaveAutoGenerada = Convert.ToBoolean(dr["ClaveAutoGenerada"]);
            this.Activo = Convert.ToBoolean(dr["Activo"]);
        }

        public static DataSet ObtenerUsuarioPorId(int unIdUsuario)
        {
            Usuario unUsuario = new Usuario();
            unUsuario.Id_Usuario = unIdUsuario;
            unUsuario.setearListaDeParametrosSoloConIdUsuario();
            DataSet ds = unUsuario.TraerListado(unUsuario.parameterList, "PorId_Usuario");
            unUsuario.parameterList.Clear();

            return ds;
        }

        public bool obtenerUsuarioPorUsername()
        {
            setearListaDeParametrosConUsuario();
            DataSet ds = SQLHelper.ExecuteDataSet("traerUsuarioPorUsername", CommandType.StoredProcedure, parameterList);
            parameterList.Clear();
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRowToObject(ds.Tables[0].Rows[0]);
                if(this.Activo)
                    return true;   
            }
            
            return false;
        }

        public void AsignarRol(DataSet ds)
        {
            this.Rol = new Rol();
            this.Rol.DataRowToObject(ds.Tables[0].Rows[0]);
        }


        public void Deshabilitar()
        {
            setearListaDeParametrosConUsuario();
            DataSet ds = SQLHelper.ExecuteDataSet("traerUsuarioPorUsername", CommandType.StoredProcedure, parameterList);
            parameterList.Clear();
            if (ds.Tables[0].Rows.Count == 0)
            {
                throw new NoEntidadException();
            }

            this.Id_Usuario = Convert.ToInt32(ds.Tables[0].Rows[0]["id_Usuario"]);

            setearListaDeParametrosSoloConIdUsuario();
            base.Deshabilitar(parameterList);
            parameterList.Clear();
        }

        public bool CambiarClave(string claveNueva)
        {
            this.Clave = claveNueva;
            this.ClaveAutoGenerada = false;
            setearListaDeParametrosCompleta();
            if (this.Modificar(parameterList))
            {
                parameterList.Clear();
                return true;
            }
            return false;
        }
        public void CrearDefault(string unNombreDeUsuario)
        {
            this.Username = unNombreDeUsuario;
            this.Clave = Encryptor.GetSHA256(unNombreDeUsuario);
            this.ClaveAutoGenerada = true;
            this.Activo = true;
        }
        public void guardarDatosDeUsuarioNuevo()
        {
            setearListaDeParametrosConUsuario();
            // se ejecuto un procedure que me trae los Usuarios where Username = UsernameIngresado
            // solo si el ds esta vacio se inserta el usuario en la BD
            DataSet ds = SQLHelper.ExecuteDataSet("validarUsernameEnUsuario", CommandType.StoredProcedure, parameterList);
            parameterList.Clear();
            if (ds.Tables[0].Rows.Count == 0)
            {                
                this.Id_Usuario = this.GuardarYObtenerID();
                // se inserta este usuario en la BD y seteo en el atributo id_usuario
                // el id que le puso la base al nuevo registro.
            }
            else
                throw new Exception("Ya existe un Usuario con este Username. Por favor, ingrese otro.");
            parameterList.Clear();
            
            
            parameterList.Clear();
        }

        public int GuardarYObtenerID()
        {
            setearListaDeParametros();
            DataSet dsNuevoUsuario = this.GuardarYObtenerID(parameterList);
            this.Id_Usuario = Convert.ToInt32(dsNuevoUsuario.Tables[0].Rows[0]["id_Usuario"]);
            return this.Id_Usuario;
        }  

        public DataSet obtenerTodasLasCompras()
        {
            //obtengo un listado de todas las compras por un usuario
            this.setearListaDeParametrosSoloConIdUsuario();
            DataSet ds = this.TraerListado(this.parameterList, "Compras");
            this.parameterList.Clear();

            return ds;
        }

        public DataSet obtenerTodasLasOfertas()
        {
            //obtengo el listado de todas las ofertas por un usuario
            this.setearListaDeParametrosSoloConIdUsuario();
            DataSet ds = this.TraerListado(this.parameterList, "Ofertas");
            this.parameterList.Clear();

            return ds;
        }

        public DataSet obtenerTodasLasCalificacionesRecibidas()
        {
            //obtengo un dataset con un listado de todas las calificaciones que recibió un usuario
            this.setearListaDeParametrosSoloConIdUsuario();
            DataSet ds = this.TraerListado(this.parameterList, "CalificacionesRecibidas");
            this.parameterList.Clear();

            return ds;
        }

        public DataSet obtenerTodasLasCalificacionesOtorgadas()
        {
            //obtengo un dataset con todas las calificaciones que otorgó un usuario
            this.setearListaDeParametrosSoloConIdUsuario();
            DataSet ds = this.TraerListado(this.parameterList, "CalificacionesOtorgadas");
            this.parameterList.Clear();

            return ds;
        }

        public DataSet obtenerVendedoresConMayorCantProdNoVendidos(DateTime Fecha_Hasta, DateTime Fecha_Desde, string Año)
        {
            //obtengo un dataset con un listado de los 5 vendedores con mayor cantidad de productos no vendidos
            this.setearListaDeParametrosConTrimestreAño(Fecha_Hasta, Fecha_Desde, Año);
            DataSet ds = this.TraerListado(this.parameterList, "ConMayorCantidadDeProductosSinVender");
            this.parameterList.Clear();

            return ds;
        }

        public DataSet obtenerVendedoresConMayorCantProdNoVendidosConFiltros(DateTime Fecha_Hasta, DateTime Fecha_Desde, string Año, string Mes, string GradoVisibilidad)
        {
            //me devuelve un dataset con los 5 vendedores con mayor cantidad de productos no vendidos de acuerdo
            //a los filtros que le envie de grado de vidibilidad y mes
            this.setearListaDeParametrosConTrimestreAñoMesVisibilidad(Fecha_Hasta, Fecha_Desde, Año,Mes,GradoVisibilidad);
            DataSet ds = this.TraerListado(this.parameterList, "ConMayorCantidadDeProductosSinVenderConFiltros");
            this.parameterList.Clear();

            return ds;
        }

        public DataSet obtenerVendedoresConMayorFacturacion(DateTime Fecha_Hasta, DateTime Fecha_Desde, string Año)
        {
            //me devuelve un dataset con los 5 vendedores con mayor facturación
            this.setearListaDeParametrosConTrimestreAño(Fecha_Hasta,Fecha_Desde,Año);
            DataSet ds = this.TraerListado(this.parameterList, "ConMayorFacturacion");
            this.parameterList.Clear();

            return ds;
        }

        public DataSet obtenerVendedoresMayorCalificacion(DateTime Fecha_Hasta, DateTime Fecha_Desde, string Año)
        {
            //obtengo los 5 vendedores de mayor calificación (promedio de cantidad de estrellas que tienen)
            this.setearListaDeParametrosConTrimestreAño(Fecha_Hasta, Fecha_Desde, Año);
            DataSet ds = this.TraerListado(this.parameterList, "ConMayorCalificacion");
            this.parameterList.Clear();

            return ds;
        }

        public DataSet obtenerClientesMayorCantPubliSinCalificar(DateTime Fecha_Hasta, DateTime Fecha_Desde, string Año)
        {
            //obtengo un dataset con los 5 vendedores con mayor cantidad de publicaciones sin calificar
            this.setearListaDeParametrosConTrimestreAño(Fecha_Hasta, Fecha_Desde, Año);
            DataSet ds = this.TraerListado(this.parameterList, "ConMayorCantDePublicacionesSinCalificar");
            this.parameterList.Clear();

            return ds;
        }
        public DataSet obtenerVendedoresSinCalificar()
        {
            this.setearListaDeParametrosSoloConIdUsuario();
            DataSet ds = this.TraerListado(this.parameterList, "VendedoresSinCalificar");
            this.parameterList.Clear();
            return ds;
        }

        public static DataSet obtenerTodos()
        {
            Usuario user = new Usuario();
            return user.TraerListado(user.parameterList, "");

        }
        public int cantPublicacionesPendientesDeCalificacion()
        {
            return obtenerVendedoresSinCalificar().Tables[0].Rows.Count;
        }

        #endregion

        #region metodos privados
        private void setearListaDeParametrosConTrimestreAño(DateTime Fecha_Hasta, DateTime Fecha_Desde, string Año)
        {
            parameterList.Add(new SqlParameter("@Fecha_Hasta", Fecha_Hasta));
            parameterList.Add(new SqlParameter("@Fecha_Desde", Fecha_Desde));
            parameterList.Add(new SqlParameter("@Anio", Año));
        }

        private void setearListaDeParametrosConTrimestreAñoMesVisibilidad(DateTime Fecha_Hasta, DateTime Fecha_Desde, string Año,string Mes, string GradoVisibilidad)
        {
            parameterList.Add(new SqlParameter("@Fecha_Hasta", Fecha_Hasta));
            parameterList.Add(new SqlParameter("@Fecha_Desde", Fecha_Desde));
            parameterList.Add(new SqlParameter("@Anio", Año));
            parameterList.Add(new SqlParameter("@Mes", Mes));
            parameterList.Add(new SqlParameter("@GradoVisibilidad", GradoVisibilidad));
        }

        private void setearListaDeParametrosSoloConIdUsuario()
        {
            parameterList.Add(new SqlParameter("@id_Usuario", this.Id_Usuario));
        }

        private void setearListaDeParametrosCompleta()
        {
            parameterList.Add(new SqlParameter("@id_Usuario", this.Id_Usuario));
            parameterList.Add(new SqlParameter("@Username", this.Username));
            parameterList.Add(new SqlParameter("@Clave", this.Clave));
            parameterList.Add(new SqlParameter("@ClaveAutoGenerada", this.ClaveAutoGenerada));
            parameterList.Add(new SqlParameter("@Activo", this.Activo));
        }
        private void setearListaDeParametros()
        {
            parameterList.Add(new SqlParameter("@Username", this.Username));
            parameterList.Add(new SqlParameter("@Clave", this.Clave));
            parameterList.Add(new SqlParameter("@ClaveAutoGenerada", this.ClaveAutoGenerada));
            parameterList.Add(new SqlParameter("@Activo", this.Activo));
        }
        private void setearListaDeParametrosConUsuarioYClave()
        {
            parameterList.Add(new SqlParameter("@Username", this.Username));
            parameterList.Add(new SqlParameter("@Clave", this.Clave));
        }

        private void setearListaDeParametrosConUsuario()
        {
            parameterList.Add(new SqlParameter("@Username", this.Username));
        }
        #endregion

    }
}
