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
using System.Windows.Forms;


namespace Clases
{
    public class Cliente : Base
    {
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos
       
        private int _cliente_id;
        private string _nombre;
        private string _apellido;
        private DateTime _fecha_nacimiento;
        private string _tipo_documento_id;
        private int _documento;
        private int _pais_residente_id;
        private Usuario _usuario;  
        private string _calle;
        private int _numero;
        private int _piso;
        private string _depto;
        private string _mail;


        #endregion

        #region constructor
      
        //CLIENTE VACIO
        public Cliente()
        {

        }

        //A PARTIR ID USUARIO
        public Cliente(Usuario unUsuario)
        {
            this.Usuario = unUsuario;
        }
        
        //A PARTIR ID CLIENTE
        public Cliente(int unIdCliente)
        {
            this.cliente_id = unIdCliente;
        }

        //SOLO CON LOS FILTROS
        public Cliente(string unNombre, string unApellido, string unTipoDni, int unDni, string unMail, int paisNacimiento, int paisResidente, string calle, int numero, int piso, int depto )
        {
            this.Apellido = unApellido;
            this.Nombre = unNombre;
            this.TipoDocumento = unTipoDni;
            this.Documento = unDni;
            this.Mail = unMail;
        }

        //TODOS LOS DATOS
        public Cliente(string unNombre, string unApellido, string unTipoDni, int unDni, string unMail, int paisNacimiento, int paisResidente, string calle, int numero, int piso, int depto)
        {
            this.Apellido = unApellido;
            this.Nombre = unNombre;
            this.TipoDocumento = unTipoDni;
            this.Documento = unDni;
            this.Mail = unMail;
        }
        
        //A PARTIR USUARIO
        public Cliente(Usuario user)
        {   
            this.Usuario = user;
            DataSet ds = this.ObtenerClientesPorUsuarioID(this.Usuario.usuario_id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRowToObject(ds.Tables[0].Rows[0]);
            }else{
            MessageBox.Show("No se encontro el Cliente Asociado", "Error");
            }
        }
        #endregion

        #region properties

        public int cliente_id
        {
            get { return _cliente_id; }
            set { _cliente_id = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _fecha_nacimiento; }
            set { _fecha_nacimiento = value; }
        }

        public int Documento
        {
            get { return _documento; }
            set { _documento = value; }
        }

        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string TipoDocumento
        {
            get { return _tipo_documento_id; }
            set { _tipo_documento_id = value; }
        }

        public int PaisResidente
        {
            get { return _pais_residente_id; }
            set { _pais_residente_id = value; }
        }

        public string Calle
        {
            get { return _calle; }
            set { _calle = value; }
        }

        public int NumeroDireccion
        {
            get { return _numero; }
            set { _numero = value; }
        }

        public int PisoDireccion
        {
            get { return _piso; }
            set { _piso = value; }
        }
        public string DeptoDireccion
        {
            get { return _depto; }
            set { _depto = value; }
        }
        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        #endregion

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Cliente";
        }

        public override string NombreEntidad()
        {
            return "Cliente";
        }
        #endregion


        #region llamados a la bd

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
            unCliente.setearListaDeParametrosConFiltros(unCliente._cliente_nombre, unCliente._cliente_apellido, unCliente._cliente_tipo_documento_id, unCliente._cliente_numero_documento, unCliente._cliente_mail);
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
           // DataSet ds1 = SQLHelper.ExecuteDataSet("validarTelefonoEnCliente", CommandType.StoredProcedure, parameterList); no tiene telefono
            DataSet ds2 = SQLHelper.ExecuteDataSet("validarDniEnCliente", CommandType.StoredProcedure, parameterList);
            //if ((ds1.Tables[0].Rows.Count == 0) && (ds2.Tables[0].Rows.Count == 0))
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
                //if (ds1.Tables[0].Rows.Count != 0) throw new Exception("Ya existe un Cliente con este telefono. Por favor, ingrese otro.");
                if (ds2.Tables[0].Rows.Count != 0) throw new Exception("Ya existe un Cliente con este Dni. Por favor, ingrese otro.");
            }
            parameterList.Clear();
        }
        
        
        public void guardarDatosDeClienteNuevoRegistrado(int id_usuario)
        {
            setearListaDeParametrosCompleta();
            //Guardo tambien en la lista de parametros el id_rol (variable privada de la clase)
            //Para que tambien se inserte la relacio id_rol id_usuario en la BD
            setearListaDeParametrosConIdRol();
            setearListaDeParametrosConIdUsuario(id_usuario);
          //  DataSet ds1 = SQLHelper.ExecuteDataSet("validarTelefonoEnCliente", CommandType.StoredProcedure, parameterList);
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
            setearListaDeParametrosCompleta();
            setearListaDeParametrosConIdRol();
            setearListaDeParametrosConIdCliente();
         //   DataSet ds1 = SQLHelper.ExecuteDataSet("validarTelefonoEnCliente", CommandType.StoredProcedure, parameterList);
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
              //  if (ds1.Tables[0].Rows.Count != 0) throw new Exception("Ya existe un Cliente con este telefono. Por favor, ingrese otro.");
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


        public DataSet ObtenerClientesPorUsuarioID(int unUsuarioID)
        {
            this.setearListaDeParametrosConUsuario(unUsuarioID);
            DataSet ds = this.TraerListado(this.parameterList, "PorUsuarioID");
            this.parameterList.Clear();
            return ds;
        }


        public DataSet ObtenerTodosLosClientes(int unUsuarioID)
        {
            DataSet ds = this.TraerListado("Completo");
            return ds;
        }


        public DataSet TraerClientePorID(int clienteID)
        {
            this.setearListaDeParametrosConClienteID(clienteID);
            DataSet ds = this.TraerListado(this.parameterList, "porClienteID");
            this.parameterList.Clear();
            return ds;
        }
               

        #endregion




        #region dataRowToObject

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.cliente_id = Convert.ToInt32(dr["cliente_id"]);
            this.Nombre = dr["cliente_nombre"].ToString();
            this.Apellido = dr["cliente_apellido"].ToString();
            this.Documento = Convert.ToInt32(dr["cliente_numero_documento"]);
            this.FechaNacimiento = Convert.ToDateTime(dr["cliente_fecha_nacimiento"]);
        }



        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.cliente_id = Convert.ToInt32(dr["cliente_id"]);
            this.TipoDocumento = dr["cliente_tipo_documento_id"].ToString();
            this.Documento = Convert.ToInt32(dr["cliente_numero_documento"]);
            this.Apellido = dr["cliente_apellido"].ToString();
            this.Nombre = dr["cliente_nombre"].ToString();
            this.FechaNacimiento = Convert.ToDateTime(dr["cliente_fecha_nacimiento"]);
            this.Mail = dr["cliente_mail"].ToString();
            this.Calle = dr["cliente_calle"].ToString();
            this.NumeroDireccion = Convert.ToInt32(dr["cliente_numero"]);
            this.PisoDireccion = Convert.ToInt32(dr["cliente_piso"]);
            this.DeptoDireccion = dr["cliente_depto"].ToString();
            //this.Activo = Convert.ToBoolean(dr["Activo"]);
        }


        #endregion
        


        #region setearListas

        public void setearListaDeParametrosConUsuario(int unUsuario)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@usuario_id",unUsuario)); 
        }



        public void setearListaDeParametrosConClienteID(int clienteID)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@cliente_id", clienteID));
        }



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


        private void setearListaDeParametrosCompleta()
        {
            //parameterList.Add(new SqlParameter("@id_Cliente", this.id_Cliente));
            parameterList.Add(new SqlParameter("@Tipo_Dni", this.TipoDocumento));
            parameterList.Add(new SqlParameter("@Dni", this._cliente_numero_documento));
            //parameterList.Add(new SqlParameter("@Cuil", this.Cuil));
            parameterList.Add(new SqlParameter("@Apellido", this._cliente_apellido);
            parameterList.Add(new SqlParameter("@Nombre", this._cliente_nombre));
            parameterList.Add(new SqlParameter("@Fecha_nac", this._cliente_fecha_nacimiento));
            parameterList.Add(new SqlParameter("@Mail", this._cliente_mail));
            //parameterList.Add(new SqlParameter("@Telefono", this.Telefono));
            parameterList.Add(new SqlParameter("@Dom_calle", this._cliente_calle));
            parameterList.Add(new SqlParameter("@Dom_nro_calle", this._cliente_numero));
            parameterList.Add(new SqlParameter("@Dom_piso", this._cliente_piso));
            parameterList.Add(new SqlParameter("@Dom_depto", this._cliente_depto));
            parameterList.Add(new SqlParameter("@Pais_residente", this._cliente_pais_residente_id));
            //parameterList.Add(new SqlParameter("@Dom_cod_postal", this.Dom_cod_postal));
            //parameterList.Add(new SqlParameter("@Dom_ciudad", this.Dom_ciudad));
            //parameterList.Add(new SqlParameter("@Activo", this.Activo));
        }


        private void setearListaDeParametrosConIdRol()
        {
            parameterList.Add(new SqlParameter("@id_Rol", this.id_Rol));
        }



        #endregion


        

    }
}
 