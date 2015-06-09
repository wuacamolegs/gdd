using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Excepciones;
using Conexion;

namespace Clases
{
    public class Calificacion : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _cod_Calificacion;
        private int _id_usuario_Calificador;
        private int _cod_Publicacion;
        private int _Cant_Estrellas;
        private string _Descripcion;
        #endregion

        #region properties
        public int cod_Calificacion
        {
            get { return _cod_Calificacion; }
            set { _cod_Calificacion = value; }
        }
        public int id_Usuario_Calificador
        {
            get { return _id_usuario_Calificador; }
            set { _id_usuario_Calificador = value; }
        }
        public int cod_Publicacion
        {
            get { return _cod_Publicacion; }
            set { _cod_Publicacion = value; }
        }
        public int Cant_Estrellas
        {
            get { return _Cant_Estrellas; }
            set { _Cant_Estrellas = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        #endregion

        #region constructor
        public Calificacion()
        {
        }
        
        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Calificaciones";
        }

        public override string NombreEntidad()
        {
            return "Calificacion";
        }

        public override void DataRowToObject(DataRow dr)
        {
            //Esto es tal cual lo devuelve el stored de la DB
            this.cod_Calificacion = Convert.ToInt32(dr["cod_Calificacion"]);
            this.id_Usuario_Calificador = Convert.ToInt32(dr["id_usuario_Calificador"]);
            this.cod_Publicacion = Convert.ToInt32(dr["cod_Publicacion"]);
            this.Cant_Estrellas = Convert.ToInt32(dr["Cant_Estrellas"]);
            this.Descripcion = dr["Descripcion"].ToString();
            
        }
        public void GuardarCalificacion()
        {   
            setearListaDeParametros();
            this.Guardar(parameterList);
            parameterList.Clear();
        }

        #endregion

        #region metodos privados
        private void setearListaDeParametros()
        {
            parameterList.Add(new SqlParameter("@id_Usuario", this.id_Usuario_Calificador));
            parameterList.Add(new SqlParameter("@cod_Publicacion", this.cod_Publicacion));
            parameterList.Add(new SqlParameter("@CantEstrellas", this.Cant_Estrellas));
            parameterList.Add(new SqlParameter("@Descripcion", this.Descripcion)); 
        }
        #endregion

       
    }
}
