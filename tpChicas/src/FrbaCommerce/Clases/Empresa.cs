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
    public class Empresa : Base 
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Empresa;
        private string _Cuit;
        private string _Razon_social;
        private DateTime _Fecha_creacion;
        private string _Mail;
        private string _Telefono;
        private string _Dom_calle;
        private int _Dom_nro_calle;
        private int _Dom_piso;
        private string _Dom_depto;
        private string _Dom_cod_postal;
        private string _Dom_ciudad;
        private string _Nombre_contacto;
        private bool _Activo;
        private decimal _Reputacion;

        private int _id_Rol = 3;
        private Usuario _usuario;
        #endregion

        #region properties
        public int id_Empresa
        {
            get { return _id_Empresa; }
            set { _id_Empresa = value; }
        }
        public string Cuit
        {
            get { return _Cuit; }
            set { _Cuit = value; }
        }
        public string Razon_social
        {
            get { return _Razon_social; }
            set { _Razon_social = value; }
        }
        public DateTime Fecha_creacion
        {
            get { return _Fecha_creacion; }
            set { _Fecha_creacion = value; }
        }
        public string Mail
        {
            get { return _Mail; }
            set { _Mail = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public string Dom_calle
        {
            get { return _Dom_calle; }
            set { _Dom_calle = value; }
        }
        public int Dom_nro_calle
        {
            get { return _Dom_nro_calle; }
            set { _Dom_nro_calle = value; }
        }
        public int Dom_piso
        {
            get { return _Dom_piso; }
            set { _Dom_piso = value; }
        }
        public string Dom_depto
        {
            get { return _Dom_depto; }
            set { _Dom_depto = value; }
        }
        public string Dom_cod_postal
        {
            get { return _Dom_cod_postal; }
            set { _Dom_cod_postal = value; }
        }
        public string Dom_ciudad
        {
            get { return _Dom_ciudad; }
            set { _Dom_ciudad = value; }
        }
        public string Nombre_contacto
        {
            get { return _Nombre_contacto; }
            set { _Nombre_contacto = value; }
        }
        public bool Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }
        public decimal Reputacion
        {
            get { return _Reputacion; }
            set { _Reputacion = value; }
        }
        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public int id_Rol
        {
            get { return _id_Rol; }
        }
        #endregion

        #region constructor
        public Empresa()
        {
        }
        public Empresa(int unIdEmpresa){
            this.id_Empresa = unIdEmpresa;
            

        }
        public Empresa(string unaRazonSocial, string unCuit, string unEmail){
            this.Razon_social = unaRazonSocial;
            this.Cuit = unCuit;
            this.Mail = unEmail;

        }

        public Empresa(Usuario user)
        {
            this.Usuario = new Usuario(user.Id_Usuario);
            DataSet ds = Empresa.ObtenerEmpresaPorIdUsuario(this.Usuario.Id_Usuario);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRowToObject(ds.Tables[0].Rows[0]);
            }
        }

        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Empresas";
        }

        public override string NombreEntidad()
        {
            return "Empresa";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Empresa = Convert.ToInt32(dr["id_Empresa"]);
            this.Cuit = dr["Cuit"].ToString();
            this.Razon_social = dr["Razon_social"].ToString();
            this.Mail = dr["Mail"].ToString();
            this.Fecha_creacion = Convert.ToDateTime(dr["Fecha_creacion"]);
            this.Telefono = dr["Telefono"].ToString();
            this.Dom_calle = dr["Dom_calle"].ToString();
            this.Dom_nro_calle = Convert.ToInt32(dr["Dom_nro_calle"]);
            this.Dom_piso = Convert.ToInt32(dr["Dom_piso"]);
            this.Dom_depto = dr["Dom_depto"].ToString();
            this.Dom_cod_postal = dr["Dom_cod_postal"].ToString();
            this.Dom_ciudad = dr["Dom_ciudad"].ToString();
            this.Nombre_contacto = dr["Nombre_contacto"].ToString();
            this.Activo = Convert.ToBoolean(dr["Activo"]);
            this.Usuario = new Usuario(Convert.ToInt32(dr["id_Usuario"]));
            if (!String.IsNullOrEmpty(dr["Reputacion"].ToString())) this.Reputacion = Convert.ToDecimal(dr["Reputacion"]);
        }

        public void CargarObjetoEmpresaConId()
        {
            //Con el id de la empresa me traigo de la BD todos los datos de la Empresa
            setearListaDeParametrosConIdEmpresa();
            DataSet ds = SQLHelper.ExecuteDataSet("traerEmpresaConId", CommandType.StoredProcedure, parameterList);
            parameterList.Clear();
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRowToObject(ds.Tables[0].Rows[0]);
            }
        }

        public static DataSet ObtenerEmpresaPorIdUsuario(int unIdUsuario)
        {
            Empresa unaEmpresa = new Empresa();
            unaEmpresa.setearListaDeParametrosConIdUsuario(unIdUsuario);
            DataSet ds = unaEmpresa.TraerListado(unaEmpresa.parameterList, "PorId_Usuario");
            unaEmpresa.parameterList.Clear();

            return ds;
            
        }
        public static DataSet obtenerTodasLasEmpresas()
        {
            Empresa unaEmpresa = new Empresa();
            return unaEmpresa.TraerListado(unaEmpresa.parameterList, "");
        }
        public static DataSet obtenerTodasLasEmpresasConFiltros(string unaRazonSocial, string unCuit, string unEmail)
        {
            Empresa unaEmpresa = new Empresa(unaRazonSocial, unCuit, unEmail);
            unaEmpresa.setearListaDeParametrosConFiltros(unaEmpresa.Razon_social, unaEmpresa.Cuit, unaEmpresa.Mail);
            DataSet ds = unaEmpresa.TraerListado(unaEmpresa.parameterList, "ConFiltros");
            unaEmpresa.parameterList.Clear();
            return ds;
        }
       
        public void guardarDatosDeEmpresaNueva()
        {
            
            setearListaDeParametros();            
            //Guardo tambien en la lista de parametros el id_rol (variable privada de la clase)
            //Para que tambien se inserte la relacio id_rol id_usuario en la BD
            setearListaDeParametrosConIdRol();
            DataSet ds = SQLHelper.ExecuteDataSet("validarCuitEnEmpresa", CommandType.StoredProcedure, parameterList);
            if (ds.Tables[0].Rows.Count == 0)
            {
                // se ejecuto un procedure que me trae las empresas where Cuit = Cuit Ingresado
                // solo si esta vacio se inserta el usuarioDefault y la empresa en la BD
                this.Usuario.Id_Usuario = this.Usuario.GuardarYObtenerID();
                setearListaDeParametrosConIdUsuario(this.Usuario.Id_Usuario);
                this.Guardar(parameterList);  
            }
            else
            {
                throw new Exception("Ya existe una Empresa con este Cuit. Por favor, ingrese otro.");         
            }
            parameterList.Clear();
        }
        public void guardarDatosDeEmpresaNuevaRegistrada(int id_Usuario)
        {
            setearListaDeParametros();
            //Guardo tambien en la lista de parametros el id_rol (variable privada de la clase)
            //Para que tambien se inserte la relacio id_rol id_usuario en la BD
            setearListaDeParametrosConIdRol();
            // el id_Usuario que estoy pasando como parametro es el id del usuario recientemente
            // registrado.
            setearListaDeParametrosConIdUsuario(id_Usuario);
            DataSet ds = SQLHelper.ExecuteDataSet("validarCuitEnEmpresa", CommandType.StoredProcedure, parameterList);
            if (ds.Tables[0].Rows.Count == 0)
            {
                this.Guardar(parameterList);
            }
            else
            {
                throw new Exception("Ya existe una Empresa con este Cuit. Por favor, ingrese otro.");
            }
            parameterList.Clear();
        }
        public void ModificarDatos()
        {
            parameterList.Clear();
            setearListaDeParametrosConIdEmpresa();
            setearListaDeParametros();
            DataSet ds = SQLHelper.ExecuteDataSet("validarCuitEnEmpresa", CommandType.StoredProcedure, parameterList);
            if (ds.Tables[0].Rows.Count == 0)
            {
                if (this.Modificar(parameterList))
                {
                    parameterList.Clear();
                }
            }
            else
            {
                throw new Exception("Ya existe una Empresa con este Cuit. Por favor, ingrese otro.");
            }
            parameterList.Clear();           
        }
        public void Eliminar()
        {
            setearListaDeParametrosConIdEmpresa();
            this.Eliminar(parameterList);
            parameterList.Clear();
        }

        #endregion

        #region metodos privados
        private void setearListaDeParametrosConFiltros(string RazonSocial,string Cuit,string Email)
        {
            parameterList.Add(new SqlParameter("@Razon_social", RazonSocial));
            parameterList.Add(new SqlParameter("@Cuit", Cuit)); 
            parameterList.Add(new SqlParameter("@Mail", Email)); 
        }
        private void setearListaDeParametrosConIdUsuario(int id_Usuario)
        {
            parameterList.Add(new SqlParameter("@id_Usuario", id_Usuario));
        }
        private void setearListaDeParametrosConIdEmpresa()
        {
            parameterList.Add(new SqlParameter("@id_Empresa", this.id_Empresa));
        }
        private void setearListaDeParametrosConIdYFiltros(string RazonSocial, string Cuit, string Email)
        {
            parameterList.Add(new SqlParameter("@id_Empresa", this.id_Empresa));
            parameterList.Add(new SqlParameter("@Razon_social", RazonSocial));
            parameterList.Add(new SqlParameter("@Cuit", Cuit));
            parameterList.Add(new SqlParameter("@Mail", Email));
        }
        private void setearListaDeParametros()
        {
            parameterList.Add(new SqlParameter("@Razon_social", this.Razon_social));
            parameterList.Add(new SqlParameter("@Cuit", this.Cuit));
            parameterList.Add(new SqlParameter("@Mail", this.Mail));
            parameterList.Add(new SqlParameter("@Fecha_creacion", this.Fecha_creacion));
            parameterList.Add(new SqlParameter("@Telefono", this.Telefono));
            parameterList.Add(new SqlParameter("@Dom_calle", this.Dom_calle));
            parameterList.Add(new SqlParameter("@Dom_nro_calle", this.Dom_nro_calle));
            parameterList.Add(new SqlParameter("@Dom_piso", this.Dom_piso));
            parameterList.Add(new SqlParameter("@Dom_depto", this.Dom_depto));
            parameterList.Add(new SqlParameter("@Dom_cod_postal", this.Dom_cod_postal));
            parameterList.Add(new SqlParameter("@Dom_ciudad", this.Dom_ciudad));
            parameterList.Add(new SqlParameter("@Nombre_contacto", this.Nombre_contacto));
            parameterList.Add(new SqlParameter("@Activo", this.Activo));
        }
        private void setearListaDeParametrosConIdRol()
        {
            parameterList.Add(new SqlParameter("@Id_Rol", this.id_Rol));
        }
                        
        #endregion
      
        
    }
}
