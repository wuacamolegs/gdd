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
    public class Cliente : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();
    
        #region atributos
        private int _id_Cliente;
        private string _Tipo_Doc;
        private int _Dni;
        private string _Cuil;
        private string _Apellido;
        private string _Nombre;
        private DateTime _Fecha_nac;
        private string _Mail;
        private string _Telefono;
        private string _Dom_calle;
        private int _Dom_nro_calle;
        private int _Dom_piso;
        private string _Dom_depto;
        private string _Dom_cod_postal;
        private string _Dom_ciudad;
        private bool _Activo;
        private decimal _Reputacion;

        private int _id_Rol = 2;
        private Usuario _usuario;
        #endregion

        #region properties
        public int id_Cliente
        {
            get { return _id_Cliente; }
            set { _id_Cliente = value; }
        }
        public string Tipo_Doc
        {
            get { return _Tipo_Doc; }
            set { _Tipo_Doc = value; }
        }
        public int Dni
        {
            get { return _Dni; }
            set { _Dni = value; }
        }
        public string Cuil
        {
            get { return _Cuil; }
            set { _Cuil = value; }
        }
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public DateTime Fecha_nac
        {
            get { return _Fecha_nac; }
            set { _Fecha_nac = value; }
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
        public Cliente()
        {
        }
        public Cliente(int unIdCliente){
            this.id_Cliente = unIdCliente;
        }
        public Cliente(string unNombre, string unApellido, string unTipoDni, int unDni, string unMail){
            this.Apellido = unApellido;
            this.Nombre = unNombre;
            this.Tipo_Doc = unTipoDni;
            this.Dni = unDni;
            this.Mail = unMail;
        }

        public Cliente(Usuario user)
        {
            this.Usuario = new Usuario(user.Id_Usuario);
            DataSet ds = Cliente.ObtenerClientePorIdUsuario(this.Usuario.Id_Usuario);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRowToObject(ds.Tables[0].Rows[0]);
            }
        }


        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Clientes";
        }

        public override string NombreEntidad()
        {
            return "Cliente";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Cliente = Convert.ToInt32(dr["id_Cliente"]);
            this.Tipo_Doc = dr["Tipo_Dni"].ToString();
            this.Dni = Convert.ToInt32(dr["Dni"]);
            this.Cuil = dr["Cuil"].ToString();
            this.Apellido = dr["Apellido"].ToString();
            this.Nombre = dr["Nombre"].ToString();
            this.Fecha_nac = Convert.ToDateTime(dr["Fecha_nac"]);
            this.Mail = dr["Mail"].ToString();
            this.Telefono = dr["Telefono"].ToString();
            this.Dom_calle = dr["Dom_calle"].ToString();
            this.Dom_nro_calle = Convert.ToInt32(dr["Dom_nro_calle"]);
            this.Dom_piso = Convert.ToInt32(dr["Dom_piso"]);
            this.Dom_depto = dr["Dom_depto"].ToString();
            this.Dom_cod_postal = dr["Dom_cod_postal"].ToString();
            this.Dom_ciudad = dr["Dom_ciudad"].ToString();
            this.Activo = Convert.ToBoolean(dr["Activo"]);
            this.Usuario = new Usuario(Convert.ToInt32(dr["id_Usuario"]));
            if (!String.IsNullOrEmpty(dr["Reputacion"].ToString())) this.Reputacion = Convert.ToDecimal(dr["Reputacion"]);
        }
        
        public void CargarObjetoClienteConId()
        {
            //Con el id del cliente me traigo de la BD todos los datos del Cliente
            setearListaDeParametrosConIdCliente();
            DataSet ds = SQLHelper.ExecuteDataSet("traerClienteConId", CommandType.StoredProcedure, parameterList);
            parameterList.Clear();
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRowToObject(ds.Tables[0].Rows[0]);
            }
        }

        public static DataSet ObtenerClientePorIdUsuario(int unIdUsuario)
        {
            Cliente unCliente = new Cliente();
            unCliente.setearListaDeParametrosConIdUsuario(unIdUsuario);
            DataSet ds = unCliente.TraerListado(unCliente.parameterList, "PorId_Usuario");
            unCliente.parameterList.Clear();

            return ds;
        }

        public static DataSet obtenerTodosLosClientes()
        {
            Cliente unCliente = new Cliente();
            return unCliente.TraerListado(unCliente.parameterList, "");
        }
        public static DataSet obtenerTodosLosClientesConFiltros(string unNombre, string unApellido, string unTipoDni, int unDni, string unMail)
        {
            Cliente unCliente = new Cliente(unNombre, unApellido, unTipoDni, unDni, unMail);
            unCliente.setearListaDeParametrosConFiltros(unCliente.Nombre, unCliente.Apellido, unCliente.Tipo_Doc, unCliente.Dni, unCliente.Mail);
            DataSet ds = unCliente.TraerListado(unCliente.parameterList, "ConFiltros");
            unCliente.parameterList.Clear();
            return ds;
        }
       
        public void guardarDatosDeClienteNuevo()
        {
            setearListaDeParametros();
            //Guardo tambien en la lista de parametros el id_rol (variable privada de la clase)
            //Para que tambien se inserte la relacio id_rol id_usuario en la BD
            setearListaDeParametrosConIdRol();
            DataSet ds1 = SQLHelper.ExecuteDataSet("validarTelefonoEnCliente", CommandType.StoredProcedure, parameterList);
            DataSet ds2 = SQLHelper.ExecuteDataSet("validarDniEnCliente", CommandType.StoredProcedure, parameterList);
            if ((ds1.Tables[0].Rows.Count == 0) && (ds2.Tables[0].Rows.Count == 0))
            {
                // se ejecuto un procedure que me traia los clientes where telefono = telfonoIngresado
                // y otro que me trae los clientes where dni = DniIngresado
                // solo si los dos ds estan vacios se inserta el usuarioDefault y el cliente en la BD
                this.Usuario.Id_Usuario = this.Usuario.GuardarYObtenerID();
                setearListaDeParametrosConIdUsuario(this.Usuario.Id_Usuario);
                this.Guardar(parameterList);
            }
            else
            {
                if (ds1.Tables[0].Rows.Count != 0) throw new Exception("Ya existe un Cliente con este telefono. Por favor, ingrese otro.");
                if (ds2.Tables[0].Rows.Count != 0) throw new Exception("Ya existe un Cliente con este Dni. Por favor, ingrese otro.");
            }
            parameterList.Clear();
        }
        public void guardarDatosDeClienteNuevoRegistrado(int id_usuario)
        {
            setearListaDeParametros();
            //Guardo tambien en la lista de parametros el id_rol (variable privada de la clase)
            //Para que tambien se inserte la relacio id_rol id_usuario en la BD
            setearListaDeParametrosConIdRol();
            setearListaDeParametrosConIdUsuario(id_usuario);
            DataSet ds1 = SQLHelper.ExecuteDataSet("validarTelefonoEnCliente", CommandType.StoredProcedure, parameterList);
            DataSet ds2 = SQLHelper.ExecuteDataSet("validarDniEnCliente", CommandType.StoredProcedure, parameterList);
            if ((ds1.Tables[0].Rows.Count == 0) && (ds2.Tables[0].Rows.Count == 0))
            {
                // se ejecuto un procedure que me traia los clientes where telefono = telfonoIngresado
                // y otro que me trae los clientes where dni = DniIngresado
                // solo si los dos ds estan vacios se inserta el cliente en la BD                
                this.Guardar(parameterList);
            }
            else
            {
                if (ds1.Tables[0].Rows.Count != 0) throw new Exception("Ya existe un Cliente con este telefono. Por favor, ingrese otro.");
                if (ds2.Tables[0].Rows.Count != 0) throw new Exception("Ya existe un Cliente con este Dni. Por favor, ingrese otro.");
            }
            parameterList.Clear();
        }
        
        public void ModificarDatos()
        {
            parameterList.Clear();
            setearListaDeParametros();
            setearListaDeParametrosConIdRol();
            setearListaDeParametrosConIdCliente();
            DataSet ds1 = SQLHelper.ExecuteDataSet("validarTelefonoEnCliente", CommandType.StoredProcedure, parameterList);
            DataSet ds2 = SQLHelper.ExecuteDataSet("validarDniEnCliente", CommandType.StoredProcedure, parameterList);
            if ((ds1.Tables[0].Rows.Count == 0) && (ds2.Tables[0].Rows.Count == 0))
            {
                // se ejecuto un procedure que me traia los clientes where telefono = telfonoIngresado
                // solo si el ds esta vacio se inserta el usuarioDefault y el cliente en la BD

                if (this.Modificar(parameterList))
                {
                    parameterList.Clear();
                }
            }
            else
            {
                if (ds1.Tables[0].Rows.Count != 0) throw new Exception("Ya existe un Cliente con este telefono. Por favor, ingrese otro.");
                if (ds2.Tables[0].Rows.Count != 0) throw new Exception("Ya existe un Cliente con este Dni. Por favor, ingrese otro.");
            }
            parameterList.Clear();           
           
        }

        public void Eliminar()
        {
            setearListaDeParametrosConIdCliente();
            this.Eliminar(parameterList);
            parameterList.Clear();
        }

        #endregion

        #region metodos privados
        private void setearListaDeParametrosConFiltros(string Nombre, string Apellido, string TipoDni, int Dni, string Mail)
        {
            parameterList.Add(new SqlParameter("@Nombre", Nombre));
            parameterList.Add(new SqlParameter("@Apellido", Apellido));
            parameterList.Add(new SqlParameter("@Tipo_Dni", TipoDni));
            parameterList.Add(new SqlParameter("@Dni", Dni)); 
            parameterList.Add(new SqlParameter("@Mail", Mail)); 
        }
        private void setearListaDeParametrosConIdUsuario(int id_Usuario)
        {
            parameterList.Add(new SqlParameter("@id_Usuario", id_Usuario));
        }
        private void setearListaDeParametrosConIdCliente()
        {
            parameterList.Add(new SqlParameter("@id_Cliente", this.id_Cliente));
        }       
        private void setearListaDeParametros()
        {
            //parameterList.Add(new SqlParameter("@id_Cliente", this.id_Cliente));
            parameterList.Add(new SqlParameter("@Tipo_Dni", "Dni"));
            parameterList.Add(new SqlParameter("@Dni", this.Dni));
            parameterList.Add(new SqlParameter("@Cuil", this.Cuil));
            parameterList.Add(new SqlParameter("@Apellido", this.Apellido));
            parameterList.Add(new SqlParameter("@Nombre", this.Nombre));
            parameterList.Add(new SqlParameter("@Fecha_nac", this.Fecha_nac));
            parameterList.Add(new SqlParameter("@Mail", this.Mail));            
            parameterList.Add(new SqlParameter("@Telefono", this.Telefono));
            parameterList.Add(new SqlParameter("@Dom_calle", this.Dom_calle));
            parameterList.Add(new SqlParameter("@Dom_nro_calle", this.Dom_nro_calle));
            parameterList.Add(new SqlParameter("@Dom_piso", this.Dom_piso));
            parameterList.Add(new SqlParameter("@Dom_depto", this.Dom_depto));
            parameterList.Add(new SqlParameter("@Dom_cod_postal", this.Dom_cod_postal));
            parameterList.Add(new SqlParameter("@Dom_ciudad", this.Dom_ciudad));
            parameterList.Add(new SqlParameter("@Activo", this.Activo));
        }        
        private void setearListaDeParametrosConIdRol()
        {        
            parameterList.Add(new SqlParameter("@id_Rol", this.id_Rol));
        }

        #endregion
                

    }
}
