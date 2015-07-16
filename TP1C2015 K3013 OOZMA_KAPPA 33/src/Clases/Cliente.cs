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

        private Int64 _cliente_id;
        private string _nombre;
        private string _apellido;
        private DateTime _fecha_nacimiento;
        private string _tipo_documento_id;
        private Int64 _documento;
        private Int64 _pais_residente_id;
        private Usuario _usuario;
        private string _calle;
        private Int64 _numero;
        private Int64 _piso;
        private string _depto;
        private string _mail;
        private bool _estado;


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
        public Cliente(Int64 unIdCliente)
        {
            this.cliente_id = unIdCliente;
        }

        //SOLO CON LOS FILTROS
        public Cliente(string unNombre, string unApellido, string unTipoDni, Int64 unDni, string unMail, DateTime fechaNacimiento, Int64 paisResidente, string calle, Int64 numero, Int64 piso, string depto)
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
        public Cliente(string unNombre, string unApellido, string unTipoDni, Int64 unDni, string unMail)
        {
            this.Apellido = unApellido;
            this.Nombre = unNombre;
            this.TipoDocumento = unTipoDni;
            this.Documento = unDni;
            this.Mail = unMail;
        }

        //A PARTIR USUARIO
        public Cliente(Usuario usuario, Int64 usuarioID)  //LO TUVE QUE HACER DE OTRA FORMA PORQUE YA HABIA UN CLIENTE(USUARIO USER)
        {
            this.Usuario = usuario;
            DataSet ds = this.ObtenerClientesPorUsuarioID(usuarioID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRowToObject(ds.Tables[0].Rows[0]);
            }
            else
            {
                MessageBox.Show("No se encontro el Cliente Asociado", "Error");
            }
        }
        #endregion

        #region properties

        public Int64 cliente_id
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

        public Int64 Documento
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

        public Int64 PaisResidente
        {
            get { return _pais_residente_id; }
            set { _pais_residente_id = value; }
        }

        public string Calle
        {
            get { return _calle; }
            set { _calle = value; }
        }

        public Int64 NumeroDireccion
        {
            get { return _numero; }
            set { _numero = value; }
        }

        public Int64 PisoDireccion
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

        public bool estado
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
        #endregion

        #region dataRowToObject

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.cliente_id = Convert.ToInt64(dr["cliente_id"]);
            this.Nombre = dr["cliente_nombre"].ToString();
            this.Apellido = dr["cliente_apellido"].ToString();
            this.Documento = Convert.ToInt64(dr["cliente_numero_documento"]);
            this.FechaNacimiento = Convert.ToDateTime(dr["cliente_fecha_nacimiento"]);
        }

        public void DataRowToObjectCompleto(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.cliente_id = Convert.ToInt64(dr["cliente_id"]);
            this.TipoDocumento = dr["cliente_tipo_documento_id"].ToString();
            this.Documento = Convert.ToInt64(dr["cliente_numero_documento"]);
            this.Apellido = dr["cliente_apellido"].ToString();
            this.Nombre = dr["cliente_nombre"].ToString();
            this.FechaNacimiento = Convert.ToDateTime(dr["cliente_fecha_nacimiento"]);
            this.Mail = dr["cliente_mail"].ToString();
            this.Calle = dr["cliente_calle"].ToString();
            this.NumeroDireccion = Convert.ToInt64(dr["cliente_numero"]);
            this.PisoDireccion = Convert.ToInt64(dr["cliente_piso"]);
            this.DeptoDireccion = dr["cliente_depto"].ToString();
            this.estado = Convert.ToBoolean(dr["cliente_estado"]);
        }


        #endregion

        #region setearListas

        public void setearListaDeParametrosConUsuarioID(Int64 unUsuario)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@usuario_id", unUsuario));
        }

        public void setearListaDeParametrosConClienteID(Int64 clienteID)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@cliente_id", this.cliente_id));
        }
       
        
        private void setearListaDeParametrosConClienteIDYCuentaID(Int64 cliente_id, Int64 cuenta_id)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@cliente_id", cliente_id));
            parameterList.Add(new SqlParameter("@cuenta_id", cuenta_id));

        }

        private void setearListaDeParametrosConFiltros(string Nombre, string Apellido, int TipoDni, string Dni, string Mail)
        {
            parameterList.Add(new SqlParameter("@cliente_nombre", Nombre));
            parameterList.Add(new SqlParameter("@cliente_apellido", Apellido));
            parameterList.Add(new SqlParameter("@cliente_tipo_documento_id", TipoDni));
            parameterList.Add(new SqlParameter("@cliente_numero_documento", Dni));
            parameterList.Add(new SqlParameter("@cliente_mail", Mail));
        }

        private void setearListaDeParametros()
        {
            parameterList.Add(new SqlParameter("@cliente_id", this.cliente_id));
            parameterList.Add(new SqlParameter("@cliente_tipo_documento_id", this.TipoDocumento));
            parameterList.Add(new SqlParameter("@cliente_numero_documento", this.Documento));
            parameterList.Add(new SqlParameter("@cliente_apellido", this.Apellido));
            parameterList.Add(new SqlParameter("@cliente_nombre", this.Nombre));
            parameterList.Add(new SqlParameter("@cliente_fecha_nacimiento", this.FechaNacimiento));
            parameterList.Add(new SqlParameter("@cliente_mail", this.Mail));
            parameterList.Add(new SqlParameter("@cliente_pais_id", this.PaisResidente));
            parameterList.Add(new SqlParameter("@cliente_numero", this.NumeroDireccion));
            parameterList.Add(new SqlParameter("@cliente_calle", this.Calle));
            parameterList.Add(new SqlParameter("@cliente_direccion", this.PisoDireccion));
            parameterList.Add(new SqlParameter("@cliente_depto", this.DeptoDireccion));
            parameterList.Add(new SqlParameter("@cliente_estado", this.estado));
        }

        #endregion

        #region llamados a la bd


        public DataSet obtenerTodosLosClientes()
        {
            Cliente unCliente = new Cliente();
            return unCliente.TraerListado(unCliente.parameterList, "");
        }


        //Cuando le pasen este metodo a un cliente antes tienen que crearlo, ahi usar unCliente = new Cliente(unNombre, unApellido, unTipoDni, unDni, unMail); 
        // y despues basta con llamarlo como this.
        public DataSet obtenerTodosLosClientesConFiltros(string unNombre, string unApellido, int unTipoDni, string unDni, string unMail)
        {
            this.setearListaDeParametrosConFiltros(unNombre, unApellido, unTipoDni, unDni, unMail);
            DataSet ds = this.TraerListado(parameterList, "ConFiltros");
            this.parameterList.Clear();
            return ds;
        }


        public void guardarDatosDeClienteNuevo()
        {
            setearListaDeParametros();
            //Guardo tambien en la lista de parametros el id_rol (variable privada de la clase)
            //Para que tambien se inserte la relacio id_rol id_usuario en la BD

            DataSet ds2 = SQLHelper.ExecuteDataSet("validarDniEnClienteAlta", CommandType.StoredProcedure, parameterList);
            if ((ds2.Tables[0].Rows.Count == 0))
            {
                // se ejecuto un procedure que me traia los clientes where telefono = telfonoIngresado
                // y otro que me trae los clientes where dni = DniIngresado
                // solo si los dos ds estan vacios se inserta el usuarioDefault y el cliente en la BD
                this.Usuario.usuario_id = this.Usuario.GuardarYObtenerID();
                setearListaDeParametrosConUsuarioID(this.Usuario.usuario_id);
                this.Guardar(parameterList);
            }
            else
            {

                if (ds2.Tables[0].Rows.Count != 0) throw new Exception("Ya existe un Cliente con este Dni. Por favor, ingrese otro.");
            }
            parameterList.Clear();
        }

        public void ModificarDatos()
        {
            /*parameterList.Clear(); VER GINO LO COMENTE PORQUE SE REPETIA CODIGO CREO
            setearListaDeParametros();*/
            setearListaDeParametrosConClienteID(this.cliente_id);
            DataSet ds2 = SQLHelper.ExecuteDataSet("validarDniEnClienteModificar", CommandType.StoredProcedure, parameterList);
            if ((ds2.Tables[0].Rows.Count == 0))
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
                if (ds2.Tables[0].Rows.Count != 0) throw new Exception("Ya existe un Cliente con este Dni. Por favor, ingrese otro.");
            }
            parameterList.Clear();

        }

        public void Eliminar()
        {
            setearListaDeParametrosConClienteID(this.cliente_id);
            this.Eliminar(parameterList);
            parameterList.Clear();
        }


        public DataSet ObtenerClientesPorUsuarioID(Int64 unUsuarioID)
        {
            this.setearListaDeParametrosConUsuarioID(unUsuarioID);
            DataSet ds = this.TraerListado(this.parameterList, "PorUsuarioID");
            this.parameterList.Clear();
            return ds;
        }


        public DataSet ObtenerTodosLosClientes(Int64 unUsuarioID)
        {
            DataSet ds = this.TraerListado("Completo");
            return ds;
        }


        public DataSet TraerClientePorID(Int64 clienteID)
        {
            this.setearListaDeParametrosConClienteID(clienteID);
            DataSet ds = this.TraerListado(this.parameterList, "porClienteID");
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.DataRowToObject(ds.Tables[0].Rows[0]);
            }
            this.parameterList.Clear();
            return ds;
        }

        public DataSet TraerTransferenciasAFacturarPorClienteID()
        {
            setearListaDeParametrosConClienteID(this.cliente_id);
            return this.TraerListado(parameterList, "TransferenciasAFacturar");
        }

        public DataSet TraerSuscripcionesPendientesAFacturarPorClienteIDYCuentaID(Int64 cuenta_id)
        {
            setearListaDeParametrosConClienteIDYCuentaID(this.cliente_id, cuenta_id);
            return this.TraerListado(parameterList, "SuscripcionesPendientesAFacturarPorClienteIDYCuentaID");
        }

        public DataSet TraerModificacionesTipoCuentaAFacturarPorClienteID()
        {
            setearListaDeParametrosConClienteID(this.cliente_id);
            return this.TraerListado(parameterList, "ModificacionesTCAFacturar");
        }

        public Int64 TraerCantidadSuscripcionesPendientesAFacturarPorClienteIDYCuentaID(Int64 cuenta_id)
        {
            setearListaDeParametrosConClienteIDYCuentaID(this.cliente_id, cuenta_id);
            DataSet ds = this.TraerListado(parameterList, "CantidadSuscripcionesPendientesAFacturarPorClienteIDYCuentaID");
            if (ds.Tables[0].Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(ds.Tables[0].Rows[0]["cantidadSuscripciones"]);
            };
        }

        public void guardarDatosDeClienteNuevoRegistrado(int id_usuario)
        {
            setearListaDeParametros();
            //Guardo tambien en la lista de parametros el id_rol (variable privada de la clase)
            //Para que tambien se inserte la relacio id_rol id_usuario en la BD
            setearListaDeParametrosConUsuarioID(id_usuario);
            DataSet ds2 = SQLHelper.ExecuteDataSet("validarDniEnCliente", CommandType.StoredProcedure, parameterList);
            if ((ds2.Tables[0].Rows.Count == 0))
            {
                // se ejecuto un procedure que me traia los clientes where telefono = telfonoIngresado
                // y otro que me trae los clientes where dni = DniIngresado
                // solo si los dos ds estan vacios se inserta el cliente en la BD                
                this.Guardar(parameterList); //el sp, esta en Base.cs//
            }
            else
            {
                if (ds2.Tables[0].Rows.Count != 0) throw new Exception("Ya existe un Cliente con este Dni. Por favor, ingrese otro.");
            }
            parameterList.Clear();
        }

        #endregion        
       
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

        private void setearListaDeParametrosConIdCliente()
        {
            parameterList.Add(new SqlParameter("@id_Cliente", this._cliente_id));
        } 
      
        public DataSet TraerClientePorIDConTodosLosDatos(int clienteID)
        {
            setearListaDeParametrosConClienteID(Convert.ToInt64(cliente_id));
            return TraerListado(parameterList, "ConTodoPorClienteID");

        }

        public DataSet ObtenerTodosLosClientesConCosasAFacturar()
        {
            return TraerListado("ConCosasAFacturar");
        }

        public DataSet ObtenerClientesPorUsuarioIDSiFacturaAlgo(int userID)
        {
            setearListaDeParametrosConUsuarioID(userID);
            return TraerListado(parameterList,"ConCosasAFacturarPorUsuarioID");
        }
    }
}
 