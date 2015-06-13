﻿using System;
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
using Clases;


namespace Clases
{
    public class Usuario : Base
    {
        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos
        //Defino los atributos que a mi entender son necesarios para la aplicacion. 
        private int _usuario_id;
        private string _username;
        private string _password;
        private bool _estado;
        private string _preguntaSecreta;
        private string _respuestaSecreta;
        private Rol _rol;  //el rol que se le asignada al usuario al momento de loguearse
        private bool _passAutogenerada;  //booleano para saber si tiene el pass autogenerado o no.

        #endregion

        #region constructor
        public Usuario()
        {

        }

        #endregion

        #region properties

        public int usuario_id
        {
            get { return _usuario_id; }
            set { _usuario_id = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public string Pregunta_Secreta
        {
            get { return _preguntaSecreta; }
            set { _preguntaSecreta = value; }
        }

        public string Respuesta_Secreta
        {
            get { return _respuestaSecreta; }
            set { _respuestaSecreta = value; }
        }

        public Rol Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }

        public bool ClaveAutoGenerada
        {
            get { return _passAutogenerada; }
            set { _passAutogenerada = value; }
        }

        #endregion

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Usuario";
        }

        public override string NombreEntidad()
        {
            return "Usuario";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.usuario_id = Convert.ToInt32(dr["usuario_id"]);
            this.Username = dr["usuario_username"].ToString();
            this.Password = dr["usuario_password"].ToString();
            this.Estado = Convert.ToBoolean(dr["usuario_estado"]);
         }

        private bool esClaveAutoGenerada(DataRow dr)
        {
            string @claveAutoGenerada = "ECE6128060FCDA0AFC43C2D59109C410E89DE2BEF602D70ED62C0640FD795970";
            bool @boolClave = false;
            if(claveAutoGenerada == dr["usuario_password"].ToString()){
                @boolClave = true;
            }
            return boolClave;
        }


        #endregion


        #region Busquedas en la base
        
        public bool obtenerUsuarioActivoPorUsername()
        {
            bool @encontroUsuario = false;

            setearListaDeParametrosConUsuario();
            
            DataSet ds = SQLHelper.ExecuteDataSet("traerUsuarioActivoPorUsername", CommandType.StoredProcedure, parameterList);
            
            parameterList.Clear();
   
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRowToObject(ds.Tables[0].Rows[0]);
                encontroUsuario = true;
            }
            return encontroUsuario;
                                  
        }

        #endregion


        #region metodos privados

        private void setearListaDeParametrosConUsuario()
        {
           parameterList.Add(new SqlParameter("@Username", this.Username)); //el nombre de la variable @Username de aca tiene que ser igual a la del store procedure que defini en .sql
                        
        }

        private void setearListaDeParametrosSoloConIdUsuario()
        {
            parameterList.Add(new SqlParameter("@usuario_id", this.usuario_id));
        }

        private void setearListaDeParametrosCompleta()
        {
            parameterList.Add(new SqlParameter("@id_Usuario", this.usuario_id));
            parameterList.Add(new SqlParameter("@Username", this.Username));
            parameterList.Add(new SqlParameter("@Clave", this.Password));
            parameterList.Add(new SqlParameter("@Estado", this.Estado));
        }



        #endregion

        #region metodos 

        public void AsignarRol(DataSet ds)
        {
            this.Rol = new Rol();
            this.Rol.DataRowToObject(ds.Tables[0].Rows[0]);
        }

        public void AsignarRol(Rol unRol) {
            this.Rol = unRol;
        }


        public void Deshabilitar()
        {
            setearListaDeParametrosConUsuario();
            DataSet ds = SQLHelper.ExecuteDataSet("traerUsuarioActivoPorUsername", CommandType.StoredProcedure, parameterList);
            parameterList.Clear();
            if (ds.Tables[0].Rows.Count == 0)
            {
                throw new NoEntidadException();
            }

            this.usuario_id = Convert.ToInt32(ds.Tables[0].Rows[0]["usuario_id"]);

            setearListaDeParametrosSoloConIdUsuario();
            base.Deshabilitar(parameterList);
            parameterList.Clear();
        }

        public bool CambiarClave(string claveNueva)
        {
            this.Password = claveNueva;
            this.ClaveAutoGenerada = false;
            setearListaDeParametrosCompleta();
            if (this.Modificar(parameterList))
            {
                parameterList.Clear();
                return true;
            }
            return false;
        }



        #endregion


    }
}