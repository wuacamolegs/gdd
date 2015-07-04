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
        public Cliente(string unNombre, string unApellido, string unTipoDni, Int64 unDni, string unMail, DateTime fechaNacimiento, Int64 paisResidente, string calle, Int64 numero, Int64 piso, string depto )
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
            }else{
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
            this.estado = Convert.ToBoolean(dr["cliente_estado"]);  //TODO agregar cliente estado a la bd
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
            parameterList.Add(new SqlParameter("@cliente_id", clienteID));
        }

        private void setearListaDeParametrosConClienteIDYCuentaID(Int64 cliente_id, Int64 cuenta_id)
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@cliente_id", cliente_id));
            parameterList.Add(new SqlParameter("@cuenta_id", cuenta_id));
        
        }

        private void setearListaDeParametrosConFiltros(string Nombre, string Apellido, string TipoDni, Int64 Dni, string Mail)
        {
            parameterList.Add(new SqlParameter("@Nombre", Nombre));
            parameterList.Add(new SqlParameter("@Apellido", Apellido));
            parameterList.Add(new SqlParameter("@Tipo_Dni", TipoDni));
            parameterList.Add(new SqlParameter("@Dni", Dni));
            parameterList.Add(new SqlParameter("@Mail", Mail));
        }

        private void setearListaDeParametrosCompleta()
        {
            parameterList.Add(new SqlParameter("@id_Cliente", this.cliente_id));
            parameterList.Add(new SqlParameter("@Tipo_Dni", this.TipoDocumento));
            parameterList.Add(new SqlParameter("@Dni", this.Documento));

            parameterList.Add(new SqlParameter("@Apellido", this.Apellido));
            parameterList.Add(new SqlParameter("@Nombre", this.Nombre));    //TODO: ARREGLAR NOMBRES VARIABLES, TIENEN QUE SER IGUAL A LOS NOMBRES
            parameterList.Add(new SqlParameter("@Fecha_nac", this.FechaNacimiento)); // DE LAS COLUMNAS DE LAS TABLAS
            parameterList.Add(new SqlParameter("@Mail", this.Mail));

            parameterList.Add(new SqlParameter("@Dom_calle", this.Calle));
            parameterList.Add(new SqlParameter("@Dom_nro_calle", this.NumeroDireccion));
            parameterList.Add(new SqlParameter("@Dom_piso", this.PisoDireccion));
            parameterList.Add(new SqlParameter("@Dom_depto", this.DeptoDireccion));
            parameterList.Add(new SqlParameter("@Pais_residente", this.PaisResidente));
            parameterList.Add(new SqlParameter("@Estado", this.estado));
        }


        #endregion

        #region llamados a la bd

        public void CargarObjetoClienteConId()
        {
            //Con el id del cliente me traigo de la BD todos los datos del Cliente
            setearListaDeParametrosConClienteID(this.cliente_id);
            DataSet ds = SQLHelper.ExecuteDataSet("traerClienteConId", CommandType.StoredProcedure, parameterList);
            parameterList.Clear();
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRowToObject(ds.Tables[0].Rows[0]);
            }
        }
        
        public  DataSet obtenerTodosLosClientes()
        {
            Cliente unCliente = new Cliente();
            return unCliente.TraerListado(unCliente.parameterList, "");
        }


        //Cuando le pasen este metodo a un cliente antes tienen que crearlo, ahi usar unCliente = new Cliente(unNombre, unApellido, unTipoDni, unDni, unMail); 
        // y despues basta con llamarlo como this.
        public  DataSet obtenerTodosLosClientesConFiltros(string unNombre, string unApellido, string unTipoDni, Int64 unDni, string unMail)
        {
            Cliente unCliente = new Cliente(unNombre, unApellido, unTipoDni, unDni, unMail);
            unCliente.setearListaDeParametrosConFiltros(unCliente.Nombre, unCliente.Apellido, unCliente.TipoDocumento, unCliente.Documento, unCliente.Mail);
            DataSet ds = unCliente.TraerListado(unCliente.parameterList, "ConFiltros");
            unCliente.parameterList.Clear();
            return ds;
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
             }else{
                 return Convert.ToInt64(ds.Tables[0].Rows[0]["cantidadSuscripciones"]);
             };
         }

        #endregion        
       
    
       

    }
}
 