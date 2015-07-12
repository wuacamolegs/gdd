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
    public class Tarjeta : Base
    {

        #region variables
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos

        private Int64 _tarjeta_id;
        private Cuenta _cuenta;
        private Int64 _codigo_seguridad;
        private DateTime _fecha_emision;
        private DateTime _fecha_vencimiento;
        private Cliente _cliente;
        private Int64 _emisor;
        private bool _estado;

        #endregion

        #region constructor
      
        public Tarjeta()
        {

        }

        #endregion

        #region properties

        public Int64 tarjeta_id
        {
            get { return _tarjeta_id; }
            set {_tarjeta_id = value;}
        }

        public Int64 Emisor
        {
            get { return _emisor; }
            set { _emisor = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public Cuenta Cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
       
       
        public DateTime FechaVencimiento
        {
            get { return _fecha_vencimiento; }
            set { _fecha_vencimiento = value; }
        }

        public Int64 CodigoSeguridad
        {
            get { return _codigo_seguridad; }
            set { _codigo_seguridad = value; }
        }

        public DateTime FechaEmision
        {
            get { return _fecha_emision; }
            set { _fecha_emision = value; }
        }


        #endregion

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Tarjeta";
        }

        public override string NombreEntidad()
        {
            return "Tarjeta";
        }
        #endregion

        #region dataRowToObject
        public override void DataRowToObject(DataRow dr)
        {
            this.tarjeta_id = Convert.ToInt64(dr["tarjeta_id"]);
            this.CodigoSeguridad = Convert.ToInt64(dr["tarjeta_codigo_seguridad"]);
            this.FechaEmision = Convert.ToDateTime(dr["tarjeta_fecha_emision"]);
            this.FechaVencimiento = Convert.ToDateTime(dr["tarjeta_vencimiento"]);
            this.Cuenta.cuenta_id = Convert.ToInt64(dr["tarjeta_cuenta_numero"]);
        }
        #endregion

        #region setters

        private void setearListaParametrosConClienteIDYFecha()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@cliente_id", this.Cliente.cliente_id));
            parameterList.Add(new SqlParameter("@Fecha", Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"])));
        }

        private void setearListaParametrosParaModificar()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@tarjeta_id", this.tarjeta_id ));
            parameterList.Add(new SqlParameter("@tarjeta_emisor", this.Emisor));
            parameterList.Add(new SqlParameter("@tarjeta_fecha_vencimiento", this.FechaVencimiento));
            parameterList.Add(new SqlParameter("@tarjeta_estado", this.Estado));
        }

        private void setearListaParametrosConTarjetaID()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@tarjeta_id", this.tarjeta_id));
        }

        private void setearListaParametrosConClienteIDEmisorYFecha()
        {
            this.parameterList.Clear();
            parameterList.Add(new SqlParameter("@cliente_id", this.Cliente.cliente_id));
            parameterList.Add(new SqlParameter("@Fecha", Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"])));
            parameterList.Add(new SqlParameter("@tarjeta_emisor", this.Emisor));
        }

        #endregion

        #region lamados a la base
        #endregion

        #region metodos privados
        #endregion

        public DataSet ObtenerTarjetasPorClienteiD()
        {
            this.setearListaParametrosConClienteIDYFecha();
            DataSet ds = this.TraerListado(parameterList, "ActivasPorClienteID");
            return ds;
        }

        public DataSet traerTarjetas()
        {
            setearListaParametrosConClienteIDYFecha();
            return TraerListado(parameterList, "PorClienteID");
        }

        public void Desactivar()
        {
            setearListaParametrosConTarjetaID();
            this.Deshabilitar(parameterList);
        }

        public void UpdateTarjeta()
        {
            setearListaParametrosParaModificar();
            this.Modificar(parameterList);
        }

        public void CrearNueva()
        {
            setearListaParametrosConClienteIDYFecha();
            this.Guardar(parameterList);
        }

        public DataSet traerTarjetasActivas()
        {
            setearListaParametrosConClienteIDYFecha();
            return this.TraerListado(parameterList, "ActivasPorClienteID");
        }
    }
}
