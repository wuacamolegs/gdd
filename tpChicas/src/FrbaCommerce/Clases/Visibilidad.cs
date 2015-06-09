using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Utilities;
using System.Globalization;
using Excepciones;
using Conexion;

namespace Clases
{
    public class Visibilidad : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _cod_Visibilidad;
        private string _descripcion;
        private decimal _precio;
        private decimal _porcentaje;
        private int _duracion;
        private bool _activo;

        #endregion

        #region properties
        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        public int cod_Visibilidad
        {
            get { return _cod_Visibilidad; }
            set { _cod_Visibilidad = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        public decimal Porcentaje
        {
            get { return _porcentaje; }
            set { _porcentaje = value; }
        }

        public int Duracion
        {
            get { return _duracion; }
            set { _duracion = value; }
        }
        #endregion

        #region constructor
        public Visibilidad()
        {
            this.cod_Visibilidad= 0;
            this.Descripcion = "";
            this.Precio = 0;
            this.Porcentaje = 0;
            this.Duracion = 0;
            this.Activo = false;

        }
        public Visibilidad(int unCodigo, string unaDescripcion, decimal unPrecio, decimal unPorcentaje, int unaDuracion, bool unValorDeActivo){
            this.cod_Visibilidad = unCodigo;
            this.Descripcion = unaDescripcion;
            this.Precio = unPrecio;
            this.Porcentaje = unPorcentaje;
            this.Duracion = unaDuracion;
            this.Activo = unValorDeActivo;

        }

        public Visibilidad(string unaDescripcion, decimal unPrecio, decimal unPorcentaje, int unaDuracion, bool unValorDeActivo)
        {
            this.cod_Visibilidad = -1;
            this.Descripcion = unaDescripcion;
            this.Precio = unPrecio;
            this.Porcentaje = unPorcentaje;
            this.Duracion = unaDuracion;
            this.Activo= unValorDeActivo;
        }

        public Visibilidad(int codigoVisibilidad)
        {
            this.cod_Visibilidad= codigoVisibilidad;
            DataSet ds = Visibilidad.obtenerTodasLasVisibilidadesPorCodigo(this.cod_Visibilidad);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRowToObject(ds.Tables[0].Rows[0]);
            }

        }
        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Visibilidades";
        }

        public override string NombreEntidad()
        {
            return "Visibilidad";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.cod_Visibilidad = Convert.ToInt32(dr["cod_Visibilidad"]);
            this.Descripcion = dr["Descripcion"].ToString();
            this.Precio = Convert.ToDecimal(dr["Precio"]);
            this.Porcentaje = Convert.ToDecimal(dr["Porcentaje"]);
            this.Duracion = Convert.ToInt32(dr["Duracion"]);
            this.Activo = Convert.ToBoolean(dr["Activo"]);
        }

        public static DataSet obtenerTodasLasVisibilidadesPorCodigo(int unCodigo)
        {
            Visibilidad unaVisibilidad = new Visibilidad();
            unaVisibilidad.cod_Visibilidad = unCodigo;
            unaVisibilidad.setearListaDeParametrosConCodVisibilidad();
            DataSet ds = unaVisibilidad.TraerListado(unaVisibilidad.parameterList, "PorCod_Visibilidad");
            unaVisibilidad.parameterList.Clear();

            return ds;
        }

        public void Deshabilitar()
        {
            setearListaDeParametrosConCodVisibilidad();
            this.Deshabilitar(parameterList);
            parameterList.Clear();
        }

        public void Eliminar()
        {
            setearListaDeParametrosConCodVisibilidad();
            DataSet ds = SQLHelper.ExecuteDataSet("validarVisibilidadEnPublicacion", CommandType.StoredProcedure, parameterList);
            if (ds.Tables[0].Rows.Count == 0)
                Eliminar(parameterList);
            else
                throw new Exception("No se puede eliminar poque hay publicaciones que utilizan esta visibilidad");
            parameterList.Clear();
        }

        public static DataSet obtenerTodasLasVisibilidades()
        {
            Visibilidad unaVisibilidad = new Visibilidad();
            return unaVisibilidad.TraerListado(unaVisibilidad.parameterList, "");
        }

        public static DataSet obtenerTodasLasVisibilidadesConFiltros(string unaDescripcion, string unPrecio, string unPorcentaje, string unaDuracion, bool unValorDeActivo)
        {
            Visibilidad unaVisibilidad = new Visibilidad();
            unaVisibilidad.setearListaDeParametrosConDescripcionPrecioDuracionPorcentajeYActivo(unaDescripcion, unPrecio, unPorcentaje, unaDuracion, unValorDeActivo);            
            DataSet ds = unaVisibilidad.TraerListado(unaVisibilidad.parameterList, "ConFiltros");
            unaVisibilidad.parameterList.Clear();
            return ds;
        }

        public void ModificarDatos()
        {
            setearListaDeParametrosEntidadEntera();

            if (this.Modificar(parameterList))
            {
                parameterList.Clear();
            }

        }


        public void guardarDatosDeVisibilidadNueva()
        {
            DataSet dsParaComprobarExistencia = Visibilidad.obtenerPorDescripcion(this.Descripcion);
            if (dsParaComprobarExistencia.Tables[0].Rows.Count != 0)
                throw new EntidadExistenteException("una visibilidad");
            setearListaDeParametrosEntidadEnteraSinCodigo();
            DataSet dsNuevaVisib = this.GuardarYObtenerID(parameterList);
            parameterList.Clear();

            if (dsNuevaVisib.Tables[0].Rows.Count > 0)
            {
                this.cod_Visibilidad = Convert.ToInt32(dsNuevaVisib.Tables[0].Rows[0]["cod_Visibilidad"]);
            }
            else
            {
                throw new BadInsertException();
            }
        }

        public static DataSet obtenerPorDescripcion(string unaDescripcion)
        {
            Visibilidad unaVisibilidad = new Visibilidad();
            unaVisibilidad.setearListaDeParametrosConDescripcion(unaDescripcion);
            DataSet ds = unaVisibilidad.TraerListado(unaVisibilidad.parameterList, "PorDescripcion");
            unaVisibilidad.parameterList.Clear();
            return ds;   
        }


        #endregion

        #region metodos privados
        private void setearListaDeParametrosConCodVisibilidad()
        {
            parameterList.Add(new SqlParameter("@cod_Visibilidad", this.cod_Visibilidad));
        }

        private void setearListaDeParametrosConDescripcion(string unaDescripcion)
        {
            parameterList.Add(new SqlParameter("@Descripcion", unaDescripcion));
        }

        private void setearListaDeParametrosConDescripcionPrecioDuracionPorcentajeYActivo(string unaDescripcion, string unPrecio, string unPorcentaje, string unaDuracion, bool unValorDeActivo)
        {
            if(!(String.IsNullOrEmpty(unaDescripcion)))
                parameterList.Add(new SqlParameter("@Descripcion", unaDescripcion));
            if (!(String.IsNullOrEmpty(unPrecio)))
                parameterList.Add(new SqlParameter("@Precio", unPrecio));
            if (!(String.IsNullOrEmpty(unPorcentaje)))
                parameterList.Add(new SqlParameter("@Porcentaje", unPorcentaje));
            if (!(String.IsNullOrEmpty(unaDuracion)))
                parameterList.Add(new SqlParameter("@Duracion", unaDuracion));
            
            parameterList.Add(new SqlParameter("@Activo", unValorDeActivo));
        }


        private void setearListaDeParametrosEntidadEntera()
        {
            parameterList.Add(new SqlParameter("@cod_Visibilidad", this.cod_Visibilidad));
            parameterList.Add(new SqlParameter("@Descripcion", this.Descripcion));
            parameterList.Add(new SqlParameter("@Precio", this.Precio));
            parameterList.Add(new SqlParameter("@Porcentaje", this.Porcentaje));
            parameterList.Add(new SqlParameter("@Duracion", this.Duracion));
            parameterList.Add(new SqlParameter("@Activo", this.Activo));
            
        }

        private void setearListaDeParametrosEntidadEnteraSinCodigo()
        {
            parameterList.Add(new SqlParameter("@Descripcion", this.Descripcion));
            parameterList.Add(new SqlParameter("@Precio", this.Precio));
            parameterList.Add(new SqlParameter("@Porcentaje", this.Porcentaje));
            parameterList.Add(new SqlParameter("@Duracion", this.Duracion));
            parameterList.Add(new SqlParameter("@Activo", this.Activo));

        }
        #endregion

    }
}
