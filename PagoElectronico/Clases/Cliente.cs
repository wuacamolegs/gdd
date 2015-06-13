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
        private int _documento;
        private Usuario _usuario;  

        #endregion

        #region constructor
      
        public Cliente()
        {

        }

        public Cliente(Usuario unUsuario)
        {
            this.Usuario = unUsuario;
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

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.cliente_id = Convert.ToInt32(dr["cliente_id"]);
            this.Nombre = dr["cliente_nombre"].ToString();
            this.Apellido = dr["cliente_apellido"].ToString();
            this.Documento = Convert.ToInt32(dr["cliente_numero_documento"]);
            this.FechaNacimiento = Convert.ToDateTime(dr["cliente_fecha_nacimiento"]);
        }


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


        #endregion


        public DataSet ObtenerClientesPorUsuarioID(int unUsuarioID){
            this.setearListaDeParametrosConUsuario(unUsuarioID);
            DataSet ds = this.TraerListado(this.parameterList, "PorUsuarioID");
            this.parameterList.Clear();
            return ds;
        }

        public DataSet ObtenerTodosLosClientes(int unUsuarioID){
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

    }
}
 