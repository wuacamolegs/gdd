using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using Excepciones;

namespace Clases
{
    public class Publicacion : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _codigo;
        private string _descripcion;
        private int _stock;
        private DateTime _fecha_creacion;
        private DateTime _fecha_vencimiento;
        private decimal _precio;
        private bool _permiso_Preguntas;
        private Usuario _usuario;
        private Tipo_Publicacion _tipo_publicacion;
        private Visibilidad _visibilidad;
        private Estado_Publicacion _estado_Publicacion;
        private List<Rubro> _rubros = new List<Rubro>();
        
        #endregion

        #region constructor
        public Publicacion(){
            this.Codigo = -1;
            this.Descripcion = "";
            this.Stock = -1;
            this.Fecha_vencimiento = DateTime.Now;
            this.Fecha_creacion = DateTime.Now;
            this.Precio = -1;
            this.Permiso_Preguntas = false;
        }

        public Publicacion(int unCodigo)
        {
            this.Codigo = unCodigo;
            DataSet ds = Publicacion.ObtenerPublicacionPorId(this.Codigo);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRowToObject(ds.Tables[0].Rows[0]);
            }

        }
        
        #endregion

        #region properties
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
        public DateTime Fecha_creacion
        {
            get { return _fecha_creacion; }
            set { _fecha_creacion = value; }
        }
        public DateTime Fecha_vencimiento
        {
            get { return _fecha_vencimiento; }
            set { _fecha_vencimiento = value; }
        }
        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        public bool Permiso_Preguntas
        {
            get { return _permiso_Preguntas; }
            set { _permiso_Preguntas = value; }
        }
        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public Tipo_Publicacion Tipo_Publicacion
        {
            get { return _tipo_publicacion; }
            set { _tipo_publicacion = value; }
        }
        public Visibilidad Visibilidad
        {
            get { return _visibilidad; }
            set { _visibilidad = value; }
        }
        public Estado_Publicacion Estado_Publicacion
        {
            get { return _estado_Publicacion; }
            set { _estado_Publicacion = value; }
        }

        public List<Rubro> Rubros
        {
            get { return _rubros; }
            set { _rubros = value; }
        }
        
        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Publicaciones";
        }

        public override string NombreEntidad()
        {
            return "Publicacion";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.Codigo = Convert.ToInt32(dr["Codigo"]);
            this.Usuario = new Usuario(Convert.ToInt32(dr["id_Usuario"]));
            this.Descripcion = dr["Descripcion"].ToString();
            this.Stock = Convert.ToInt32(dr["Stock"]);
            this.Fecha_creacion = Convert.ToDateTime(dr["Fecha_creacion"]);
            this.Fecha_vencimiento = Convert.ToDateTime(dr["Fecha_vencimiento"]);
            this.Precio = Convert.ToDecimal(dr["Precio"]);
            this.Tipo_Publicacion = new Tipo_Publicacion(Convert.ToInt32(dr["id_Tipo"]));
            this.Visibilidad = new Visibilidad(Convert.ToInt32(dr["cod_Visibilidad"]));
            this.Estado_Publicacion = new Estado_Publicacion(Convert.ToInt32(dr["id_Estado"]));
            this.Permiso_Preguntas = Convert.ToBoolean(dr["permiso_Preguntas"]);
            this.Rubros = Rubro.obtenerPorCodPublicacion(this.Codigo);
        }

        public static DataSet obtenerTodas(Usuario unUsuario)
        {
            Publicacion unaPublic = new Publicacion();
            unaPublic.setearListaDeParametrosConIdUsuario(unUsuario.Id_Usuario);
            DataSet ds = unaPublic.TraerListado(unaPublic.parameterList, "PorId_Usuario");
            unaPublic.parameterList.Clear();

            return ds;
        }


        public static DataSet ObtenerPublicacionPorId(int unCodigo)
        {
            Publicacion unaPublic = new Publicacion();
            unaPublic.setearListaDeParametrosConCodigoPublic(unCodigo);
            DataSet ds = unaPublic.TraerListado(unaPublic.parameterList, "PorCod_Publicacion");
            unaPublic.parameterList.Clear();

            return ds;
        }

        public static DataSet obtenerTodasConFiltros(Usuario unUsuario, string unaDesc)
        {
            Publicacion unaPublic = new Publicacion();
            unaPublic.setearListaDeParametrosConIdUsuarioYFiltros(unUsuario.Id_Usuario, unaDesc);
            DataSet ds = unaPublic.TraerListado(unaPublic.parameterList, "PorId_UsuarioYFiltros");
            unaPublic.parameterList.Clear();

            return ds;
        }

        public static DataSet obtenerTodas(DateTime unaFecha)
        {
            Publicacion unaPublic = new Publicacion();
            unaPublic.setearListaDeParametrosConFecha(unaFecha);
            DataSet ds = unaPublic.TraerListado(unaPublic.parameterList, "NoVendidasOrdenadoPorVisibilidad");
            unaPublic.parameterList.Clear();
            return ds;
        }

        public static DataSet obtenerTodasConFiltros(DateTime unaFecha, string unaDesc, string filtroDeRubros)
        {
            Publicacion unaPublic = new Publicacion();
            unaPublic.setearListaDeParametrosConFechaYFiltros(unaFecha, unaDesc, filtroDeRubros);
            DataSet ds = unaPublic.TraerListado(unaPublic.parameterList, "NoVendidasOrdenadoPorVisibilidadConFiltros");
            unaPublic.parameterList.Clear();
            return ds;
        }

        public void descontarStock(int cantidadIngresada)
        {
            Stock = Stock - cantidadIngresada;
            ModificarDatos();
            
        }

        public void ModificarDatos()
        {
            setearListaDeParametrosEntidadEntera();

            if (this.Modificar(parameterList))
            {
                parameterList.Clear();
            }

        }

        public void GenerarDatosYRubros()
        {
            //guardo la publicacion y obtengo el id
            setearListaDeParametrosEntidadEnteraSinCodigo();
            DataSet dsNuevaPub = this.GuardarYObtenerID(parameterList);
            parameterList.Clear();

            if (dsNuevaPub.Tables[0].Rows.Count > 0)
            {
                //seteo el id a la entidad
                this.Codigo = Convert.ToInt32(dsNuevaPub.Tables[0].Rows[0]["Codigo"]);
            }
            else
            {
                throw new BadInsertException();
            }
            //modifico los rubros
            modificarRubros();
        }

        public void ModificarDatosYRubros()
        {
            setearListaDeParametrosEntidadEntera();

            if (this.Modificar(parameterList))
            {
                parameterList.Clear();
            }

            guardarRubros();

        }

        public void modificarRubros()
        {
            //lo que va a hacer es eliminar todos los rubros y luego volver a crearlos
            //si son los mismos, vuelvo a tener los mismos. si cambiaron, los obtengo modificados
            setearListaDeParametrosConCodigoPublic(Codigo);
            SQLHelper.ExecuteDataSet(_strEliminar + "Rubros_Publicacion" + "PorCod_Publicacion", CommandType.StoredProcedure, "Rubros_Publicacion", parameterList);
            parameterList.Clear();
            guardarRubros();
        }

        public void guardarRubros()
        {
            foreach (Rubro unRubro in Rubros)
            {
                setearListaDeParametrosConCodPublicacionEIdRubro(unRubro.id_Rubro);
                SQLHelper.ExecuteDataSet(_strInsertar + "Rubros_Publicacion", CommandType.StoredProcedure, "Rubros_Publicacion", parameterList);
                parameterList.Clear();

            }
        }

        public object obtenerRubrosEnTexto()
        {
            string textoRubros = "";
            foreach (Rubro unRubro in Rubros)
            {
                textoRubros += unRubro.Descripcion + ", ";
            }
            return textoRubros.Remove(textoRubros.Length - 2);
        }

        public static DataSet obtenerPublicacionesARendir(Usuario unUsuario, DateTime fecha)
        {
            Publicacion unaPubli = new Publicacion();
            unaPubli.setearListaDeParametrosConIdUsuarioYFecha(unUsuario.Id_Usuario, fecha);
            DataSet ds = unaPubli.TraerListado(unaPubli.parameterList, "MasAntiguasARendirPorUsuario");
            unaPubli.parameterList.Clear();
            return ds;
        }

        public static DataSet obtenerCantidadDePubsGratuitas(Usuario unUsuario)
        {
            Publicacion unaPublic = new Publicacion();
            unaPublic.setearListaDeParametrosConIdUsuario(unUsuario.Id_Usuario);
            DataSet ds = unaPublic.TraerListado(unaPublic.parameterList, "GratuitasPorId_Usuario");
            unaPublic.parameterList.Clear();
            return ds;
        }

        public decimal obtenerPrecioSegunTipo()
        {
            if (Tipo_Publicacion.Nombre == "Subasta")
            {
                return obtenerMayorOferta();
            }

            return Precio;

        }

        public decimal obtenerMayorOferta()
        {
            setearListaDeParametrosConCodigoPublic(Codigo);
            DataSet ds = SQLHelper.ExecuteDataSet("traerMayorOfertaPorCodPublicacion", CommandType.StoredProcedure, parameterList);
            parameterList.Clear();
            if (ds.Tables[0].Rows.Count == 1)
            {
                if (String.IsNullOrEmpty(ds.Tables[0].Rows[0]["maxOferta"].ToString()))
                    return Precio;
                else
                    return Convert.ToDecimal(ds.Tables[0].Rows[0]["maxOferta"]);
            }

            return Precio;
        }


        #endregion

        #region metodos privados
        private void setearListaDeParametrosConIdUsuarioYFecha(int unIdUsuario, DateTime unaFecha)
        {
            parameterList.Add(new SqlParameter("@id_Usuario", unIdUsuario));
            parameterList.Add(new SqlParameter("@Fecha", unaFecha));
        }

        private void setearListaDeParametrosConIdUsuario(int unIdUsuario)
        {
            parameterList.Add(new SqlParameter("@id_Usuario", unIdUsuario));
        }

        private void setearListaDeParametrosConFecha(DateTime unaFecha)
        {
            parameterList.Add(new SqlParameter("@Fecha_Vencimiento", unaFecha));
        }

        private void setearListaDeParametrosConFechaYFiltros(DateTime unaFecha, string unaDesc, string filtroDeRubros)
        {
            parameterList.Add(new SqlParameter("@Fecha_Vencimiento", unaFecha));
            parameterList.Add(new SqlParameter("@Descripcion", unaDesc));
            parameterList.Add(new SqlParameter("@filtroRubros", filtroDeRubros));
        }

        private void setearListaDeParametrosConCodigoPublic(int unCodigo)
        {
            parameterList.Add(new SqlParameter("@cod_Publicacion", unCodigo));
        }
        
        private void setearListaDeParametrosConCodPublicacionEIdRubro(int unIdRubro)
        {
            parameterList.Add(new SqlParameter("@cod_Publicacion", Codigo));
            parameterList.Add(new SqlParameter("@id_Rubro", unIdRubro));
        }

        private void setearListaDeParametrosConIdUsuarioYFiltros(int unIdUsuario, string unaDesc)
        {
            parameterList.Add(new SqlParameter("@id_Usuario", unIdUsuario));
            parameterList.Add(new SqlParameter("@Descripcion", unaDesc));
        }

        private void setearListaDeParametrosEntidadEntera()
        {
            parameterList.Add(new SqlParameter("@Codigo", Codigo));
            parameterList.Add(new SqlParameter("@id_Usuario", Usuario.Id_Usuario));
            parameterList.Add(new SqlParameter("@Descripcion", Descripcion));
            parameterList.Add(new SqlParameter("@Stock", Stock));
            parameterList.Add(new SqlParameter("@Fecha_creacion", Fecha_creacion));
            parameterList.Add(new SqlParameter("@Fecha_vencimiento", Fecha_vencimiento));
            parameterList.Add(new SqlParameter("@Precio", Precio));
            parameterList.Add(new SqlParameter("@id_Tipo", Tipo_Publicacion.id_Tipo));
            parameterList.Add(new SqlParameter("@cod_Visibilidad", Visibilidad.cod_Visibilidad));
            parameterList.Add(new SqlParameter("@id_Estado", Estado_Publicacion.id_Estado));
            parameterList.Add(new SqlParameter("@permiso_Preguntas", Permiso_Preguntas));
        }

        private void setearListaDeParametrosEntidadEnteraSinCodigo()
        {
            parameterList.Add(new SqlParameter("@id_Usuario", Usuario.Id_Usuario));
            parameterList.Add(new SqlParameter("@Descripcion", Descripcion));
            parameterList.Add(new SqlParameter("@Stock", Stock));
            parameterList.Add(new SqlParameter("@Fecha_creacion", Fecha_creacion));
            parameterList.Add(new SqlParameter("@Fecha_vencimiento", Fecha_vencimiento));
            parameterList.Add(new SqlParameter("@Precio", Precio));
            parameterList.Add(new SqlParameter("@id_Tipo", Tipo_Publicacion.id_Tipo));
            parameterList.Add(new SqlParameter("@cod_Visibilidad", Visibilidad.cod_Visibilidad));
            parameterList.Add(new SqlParameter("@id_Estado", Estado_Publicacion.id_Estado));
            parameterList.Add(new SqlParameter("@permiso_Preguntas", Permiso_Preguntas));
        }

        #endregion

    }
}
