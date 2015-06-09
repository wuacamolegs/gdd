using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Excepciones;

namespace Clases
{
    public class Compra : Base 
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Compra;
        private DateTime _fecha;
        private int _cantidad;

        private Publicacion _publicacion;
        private Usuario _usuario_Vendedor;
        private Usuario _usuario_Comprador;

        #endregion

        #region constructor

        public Compra()
        {
            id_Compra = -1;
            Cantidad = -1;
        }

        public Compra(int cantidadIngresada, DateTime unaFecha, Publicacion unaPublic, Usuario unUsuarioComprador)
        {
            id_Compra = -1;
            Publicacion = unaPublic;
            usuario_Vendedor = unaPublic.Usuario;
            usuario_Comprador = unUsuarioComprador;
            Cantidad = cantidadIngresada;
            Fecha = unaFecha;
        }
        #endregion
        
        #region properties
        public int id_Compra
        {
            get { return _id_Compra; }
            set { _id_Compra = value; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
        public Publicacion Publicacion
        {
            get { return _publicacion; }
            set { _publicacion = value; }
        }
        public Usuario usuario_Vendedor
        {
            get { return _usuario_Vendedor; }
            set { _usuario_Vendedor = value; }
        }
        public Usuario usuario_Comprador
        {
            get { return _usuario_Comprador; }
            set { _usuario_Comprador = value; }
        }

        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Compras";
        }

        public override string NombreEntidad()
        {
            return "Compra";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Compra = Convert.ToInt32(dr["id_Compra"]);
            this.Publicacion = new Publicacion(Convert.ToInt32(dr["cod_Publicacion"]));
            this.usuario_Vendedor = new Usuario(Convert.ToInt32(dr["id_Usuario_Vendedor"]));
            this.usuario_Comprador = new Usuario(Convert.ToInt32(dr["id_Usuario_Comprador"]));
            this.Fecha = Convert.ToDateTime(dr["Fecha"]);
            this.Cantidad = Convert.ToInt32(dr["Cantidad"]);

        }

        public void guardarNuevaCompra()
        {
            setearListaDeParametrosConCantidadCodPublicacionVendedorCompradorFecha();
            DataSet dsNuevaCompra = this.GuardarYObtenerID(parameterList);
            parameterList.Clear();

            if (dsNuevaCompra.Tables[0].Rows.Count > 0)
            {
                id_Compra = Convert.ToInt32(dsNuevaCompra.Tables[0].Rows[0]["id_Compra"]);
            }
            else
            {
                throw new BadInsertException();
            }

        }

        public static DataSet obtenerComprasPorCodPublicacion(int codigo)
        {
            Compra unaCompra = new Compra();
            unaCompra.setearListaDeParametrosConCodPublicacion(codigo);
            DataSet ds = unaCompra.TraerListado(unaCompra.parameterList, "PorCodigoPublicacion");
            unaCompra.parameterList.Clear();
            return ds;
        }
        #endregion

        #region metodos privados

        private void setearListaDeParametrosConCantidadCodPublicacionVendedorCompradorFecha()
        {
            parameterList.Add(new SqlParameter("@cod_Publicacion", Publicacion.Codigo));
            parameterList.Add(new SqlParameter("@id_Usuario_Vendedor", usuario_Vendedor.Id_Usuario));
            parameterList.Add(new SqlParameter("@id_Usuario_Comprador", usuario_Comprador.Id_Usuario));
            parameterList.Add(new SqlParameter("@Fecha", Fecha));
            parameterList.Add(new SqlParameter("@Cantidad", Cantidad));

        }

        private void setearListaDeParametrosConCodPublicacion(int codigo)
        {
            parameterList.Add(new SqlParameter("@cod_Publicacion", codigo)); 
        }

        #endregion

    }
}
