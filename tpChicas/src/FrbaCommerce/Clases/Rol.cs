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
    public class Rol : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Rol;
        private string _nombre;
        private bool _habilitado;
        List<Funcionalidad> _funcionalidades = new List<Funcionalidad>();
        #endregion

        #region properties
        public int Id_Rol
        {
            get { return _id_Rol; }
            set { _id_Rol = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public bool Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }
        public List<Funcionalidad> Funcionalidades
        {
            get { return _funcionalidades; }
            set { _funcionalidades = value; }
        }
        #endregion

        #region constructor
        public Rol()
        {
            this.Id_Rol = 0;
            this.Nombre = "";
            this.Habilitado = false;

        }
        public Rol(int unIdRol, string unNombre, bool unValorDeHabilitado)
        {
            this.Id_Rol = unIdRol;
            this.Nombre = unNombre;
            this.Habilitado = unValorDeHabilitado;
            this.setearFuncionalidadesAlRol();

        }

        public Rol(string unNombre, bool unValorDeHabilitado)
        {
            this.Id_Rol = -1;
            this.Nombre = unNombre;
            this.Habilitado = unValorDeHabilitado;
        }

        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Roles";
        }

        public override string NombreEntidad()
        {
            return "Rol";
        }




   



        





        #endregion

        #region metodos privados
        
        #endregion

    }
}
