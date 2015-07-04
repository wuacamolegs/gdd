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
        private bit _estado; // es un bit ahora, cambiar algo si hace falta

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
        public Cliente(string unNombre, string unApellido, string unTipoDni, int unDni, string unMail, DateTime fechaNacimiento, int paisResidente, string calle, int numero, int piso, string depto )
        {
            this.Apellido = unApellido;
            this.Nombre = unNombre;
            this.TipoDocumento = unTipoDni;
            this.Documento = unDni;
            this.Mail = unMail;
            this.FechaNacimiento = fechaNacimiento;
            this.PaisResidente = paisResidente;
            this.Calle = calle;
            this.NumeroDireccion = numero;
            this.PisoDireccion = piso;
            this.DeptoDireccion = depto;
        }

        //TODOS LOS DATOS
        public Cliente(string unNombre, string unApellido, string unTipoDni, int unDni, string unMail)
        {
            this.Apellido = unApellido;
            this.Nombre = unNombre;
            this.TipoDocumento = unTipoDni;
            this.Documento = unDni;
            this.Mail = unMail;
        }
        
        //A PARTIR USUARIO
        public Cliente(Usuario usuario, int usuarioID)  //LO TUVE QUE HACER DE OTRA FORMA PORQUE YA HABIA UN CLIENTE(USUARIO USER)
        {   
            this.Usuario = usuario;
            DataSet ds = this.ObtenerClientesPorUsuarioID(usuarioID);
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

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
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
            this.PaisResidente = Convert.ToInt32(dr["cliente_pais_residente_id"]);
            this.Estado = Convert.ToBoolean(dr["cliente_estado"]);
            //this.Usuario = new Usuario(Convert.ToInt32(dr["usuario_id"])); /* agregar constructor usuario */
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
            unCliente.setearListaDeParametrosConUsuarioID(unIdUsuario);
            DataSet ds = unCliente.TraerListado(unCliente.parameterList, "PorId_Usuario");
            unCliente.parameterList.Clear();

            return ds;
        }

        public static DataSet obtenerTodosLosClientes()
        {
            Cliente unCliente = new Cliente();
            return unCliente.TraerListado(unCliente.parameterList, "");
        }

        //Cuando le pasen este metodo a un cliente antes tienen que crearlo, ahi usar unCliente = new Cliente(unNombre, unApellido, unTipoDni, unDni, unMail); 
        // y despues basta con llamarlo como this.

        public static DataSet obtenerTodosLosClientesConFiltros(string unNombre, string unApellido, string unTipoDni, int unDni, string unMail)
        {
            Cliente unCliente = new Cliente(unNombre, unApellido, unTipoDni, unDni, unMail);
            unCliente.setearListaDeParametrosConFiltros(unCliente.Nombre, unCliente.Apellido, unCliente.TipoDocumento, unCliente.Documento, unCliente.Mail);
            DataSet ds = unCliente.TraerListado(unCliente.parameterList, "ConFiltros");
            unCliente.parameterList.Clear();
            return ds;
        }

        public void guardarDatosDeClienteNuevo()
        {
            setearListaDeParametros();
            //Guardo tambien en la lista de parametros el id_rol (variable privada de la clase)
            //Para que tambien se inserte la relacio id_rol id_usuario en la BD
            
            DataSet ds2 = SQLHelper.ExecuteDataSet("validarDniEnCliente", CommandType.StoredProcedure, parameterList);
            if (ds2.Tables[0].Rows.Count == 0)
            {
                // solo si el ds estan vacio se inserta el usuarioDefault y el cliente en la BD
                int usuarioID = Convert.ToInt32(this.Usuario.usuario_id);
                setearListaDeParametrosConUsuarioID(usuarioID);

                //CAMI: aca tendrias que hacer un metodo en usuario que sea insertUsuarioDevolverID 
                //donde setees la lista de parametros y llames a este metodo GuardarYObtenerID()

                //this.Usuario.usuario_id = this.Usuario.GuardarYObtenerID();
                this.Guardar(parameterList);
            }
            else
            {
                 if (ds2.Tables[0].Rows.Count != 0) throw new Exception("Ya existe un Cliente con este Dni. Por favor, ingrese otro.");
            }
            parameterList.Clear();
        }
        public void guardarDatosDeClienteNuevoRegistrado(int id_usuario)
        {
            setearListaDeParametros();
            //Guardo tambien en la lista de parametros el id_rol (variable privada de la clase)
            //Para que tambien se inserte la relacio id_rol id_usuario en la BD
            setearListaDeParametrosConUsuarioID(id_usuario);
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

        #region setearListas

        private void setearListaDeParametros() //TODO CAMBIAR A PARAMETROS SIN CLIENTE ID
        {
            //parameterList.Add(new SqlParameter("@id_Cliente", this.id_Cliente));
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@cliente_tipo_documento_id", "Dni"));
            parameterList.Add(new SqlParameter("@cliente_dni", this.Documento));
            parameterList.Add(new SqlParameter("@cliente_apellido", this.Apellido));
            parameterList.Add(new SqlParameter("@cliente_nombre", this.Nombre));
            parameterList.Add(new SqlParameter("@cliente_fecha_nacimiento", this.FechaNacimiento));
            parameterList.Add(new SqlParameter("@cliente_mail", this.Mail));
            parameterList.Add(new SqlParameter("@cliente_calle", this.Calle));
            parameterList.Add(new SqlParameter("@cliente_numero", this.NumeroDireccion));
            parameterList.Add(new SqlParameter("@cliente_piso", this.PisoDireccion));
            parameterList.Add(new SqlParameter("@cliente_depto", this.DeptoDireccion));
            parameterList.Add(new SqlParameter("@cliente_estado", this.Estado));
            parameterList.Add(new SqlParameter("@cliente_pais_residente_id", this.PaisResidente));
        }

        private void setearListaDeParametrosConIdCliente()
        {
            this.parameterList.Clear();

            parameterList.Add(new SqlParameter("@cliente_id", this.cliente_id));
        }

        public void setearListaDeParametrosConUsuarioID(int unUsuario)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@usuario_id", unUsuario));
        }

        public void setearListaDeParametrosConClienteID(int clienteID)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@cliente_id", clienteID));
        }

        private void setearListaDeParametrosConFiltros(string Nombre, string Apellido, string TipoDni, int Dni, string Mail)
        {
            this.parameterList.Clear();
            
            parameterList.Add(new SqlParameter("@cliente_nombre", Nombre));
            parameterList.Add(new SqlParameter("@cliente_apellido", Apellido));
            parameterList.Add(new SqlParameter("@cliente_tipo_documento_id", TipoDni));
            parameterList.Add(new SqlParameter("@cliente_dni", Dni));
            parameterList.Add(new SqlParameter("@Mail", Mail));
        }

        private void setearListaDeParametrosCompleta()
        {
            this.parameterList.Clear();
            
            parameterList.Add(new SqlParameter("@cliente_id", this.cliente_id));
            parameterList.Add(new SqlParameter("@cliente_tipo_documento_id", this.TipoDocumento));
            parameterList.Add(new SqlParameter("@cliente_dni", this.Documento));

            parameterList.Add(new SqlParameter("@cliente_apellido", this.Apellido));
            parameterList.Add(new SqlParameter("@cliente_nombre", this.Nombre));    //TODO: ARREGLAR NOMBRES VARIABLES, TIENEN QUE SER IGUAL A LOS NOMBRES
            parameterList.Add(new SqlParameter("@cliente_fecha_nacimiento", this.FechaNacimiento)); // DE LAS COLUMNAS DE LAS TABLAS
            parameterList.Add(new SqlParameter("@cliente_mail", this.Mail));

            parameterList.Add(new SqlParameter("@cliente_calle", this.Calle));
            parameterList.Add(new SqlParameter("@cliente_numero", this.NumeroDireccion));
            parameterList.Add(new SqlParameter("@cliente_piso", this.PisoDireccion));
            parameterList.Add(new SqlParameter("@cliente_depto", this.DeptoDireccion));
            parameterList.Add(new SqlParameter("@cliente_pais_residente_id", this.PaisResidente));
            parameterList.Add(new SqlParameter("@cliente_estado", this.Estado));
        }

        #endregion

        #region llamados a la bd

        public DataSet ObtenerClientesPorUsuarioID(int unUsuarioID)
        {
            this.setearListaDeParametrosConUsuarioID(unUsuarioID);
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

        public DataSet TraerTransferenciasAFacturarPorClienteID()
        {
            setearListaDeParametrosConClienteID(this.cliente_id);
            return this.TraerListado(parameterList, "TransferenciasAFacturar");
        }

        public DataSet TraerCostosPorAperturaCuentaAFacturarPorClienteID()
        {
            setearListaDeParametrosConClienteID(this.cliente_id);
            return this.TraerListado(parameterList, "AperturasCuentaAFacturar");
        }

        public DataSet TraerModificacionesTipoCuentaAFacturarPorClienteID()
        {
            setearListaDeParametrosConClienteID(this.cliente_id);
            return this.TraerListado(parameterList, "ModificacionesTCAFacturar");
        }
               

        #endregion        
       
    }
}
 