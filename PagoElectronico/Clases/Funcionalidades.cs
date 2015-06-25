using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace Clases
{
    public class Funcionalidad : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Funcionalidad;
        private string _nombre;
        #endregion

        #region properties
        public int id_Funcionalidad
        {
            get { return _id_Funcionalidad; }
            set { _id_Funcionalidad = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Funcionalidades";
        }

        public override string NombreEntidad()
        {
            return "Funcionalidades";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Funcionalidad = Convert.ToInt32(dr["funcionalidades_id"]);
            this.Nombre = dr["funcionalidades_nombre"].ToString();
        }

        public static DataSet ObtenerFuncionalidadesPorRol(int id_Rol)
        {
            Funcionalidad miFunc = new Funcionalidad();
            miFunc.setearListaDeParametrosConIdRol(id_Rol);
            DataSet ds = miFunc.TraerListado(miFunc.parameterList, "PorId_Rol");
            miFunc.parameterList.Clear();
            return ds;
        }

        public static DataSet obtenerTodas()
        {
            Funcionalidad miFunc = new Funcionalidad();
            DataSet ds = miFunc.TraerListado(miFunc.parameterList, "");
            return ds;
        }

        public Funcionalidades? obtenerPorNombre()
        {
            if (Nombre == "ABM de Rol") return Funcionalidades.ABM_Rol;
            if (Nombre == "ABM de Usuario") return Funcionalidades.ABM_Usuario;
            if (Nombre == "ABM de Cliente") return Funcionalidades.ABM_Cliente;
            if (Nombre == "ABM de Cuenta") return Funcionalidades.ABM_Cuenta;
            if (Nombre == "Depositos") return Funcionalidades.Depositos;
            if (Nombre == "Retiro de Efectivo") return Funcionalidades.Retiro_Efectivo;
            if (Nombre == "Transferencias entre cuentas") return Funcionalidades.Transferencias_Entre_Cuentas;
            if (Nombre == "Facturacion de Costos") return Funcionalidades.Facturacion_De_Costos;
            if (Nombre == "Consulta de saldos") return Funcionalidades.Consulta_De_Saldos;
            if (Nombre == "Listado Estadistico") return Funcionalidades.Listado_Estadistico;
            return null;
        }

        #endregion

        #region setters

        private void setearListaDeParametrosConIdRol(int id_Rol)
        {
            parameterList.Add(new SqlParameter("@id_Rol", id_Rol));
        }
        #endregion

    }

    public enum Funcionalidades   //afuera de la clase
        {
        ABM_Rol,
        ABM_Usuario, 
        ABM_Cliente ,
        ABM_Cuenta ,
        Depositos,
        Retiro_Efectivo,
        Transferencias_Entre_Cuentas,
        Facturacion_De_Costos,
        Consulta_De_Saldos,
        Listado_Estadistico
        }

}


