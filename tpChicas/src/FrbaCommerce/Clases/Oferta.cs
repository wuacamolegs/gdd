using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Excepciones;

namespace Clases
{
    public class Oferta : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Oferta;
        private bool _gano_Subasta;
        private DateTime _fecha;
        private decimal _monto;

        private Publicacion _publicacion = new Publicacion();
        private Usuario _usuario_Vendedor = new Usuario();
        private Usuario _usuario_Comprador = new Usuario();

        #endregion

        #region properties
        public int id_Oferta
        {
            get { return _id_Oferta; }
            set { _id_Oferta = value; }
        }
        public bool gano_Subasta
        {
            get { return _gano_Subasta; }
            set { _gano_Subasta = value; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public decimal Monto
        {
            get { return _monto; }
            set { _monto = value; }
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

        #region constructor
        public Oferta()
        {
            id_Oferta = -1;
            gano_Subasta = false;
            Monto = -1;
        }

        public Oferta(decimal montoOfertado, DateTime unaFecha, Publicacion unaPublic, Usuario unUsuarioComprador)
        {
            id_Oferta = -1;
            gano_Subasta = false;
            Publicacion = unaPublic;
            usuario_Vendedor = unaPublic.Usuario;
            usuario_Comprador = unUsuarioComprador;
            Monto = montoOfertado;
            Fecha = unaFecha;
        }
        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Ofertas";
        }

        public override string NombreEntidad()
        {
            return "Oferta";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Oferta = Convert.ToInt32(dr["id_Oferta"]);
            this.Publicacion = new Publicacion(Convert.ToInt32(dr["cod_Publicacion"]));
            this.usuario_Vendedor = new Usuario(Convert.ToInt32(dr["id_Usuario_Vendedor"]));
            this.usuario_Comprador = new Usuario(Convert.ToInt32(dr["id_Usuario_Comprador"]));
            this.gano_Subasta = Convert.ToBoolean(dr["gano_Subasta"]);
            this.Fecha = Convert.ToDateTime(dr["Fecha"]);
            this.Monto = Convert.ToDecimal(dr["Monto"]);
        }

        public void guardarNuevaOferta()
        {
            setearListaDeParametrosConMontoCodPublicacionVendedorCompradorFecha();
            DataSet dsNuevaOferta = this.GuardarYObtenerID(parameterList);
            parameterList.Clear();

            if (dsNuevaOferta.Tables[0].Rows.Count > 0)
            {
                id_Oferta = Convert.ToInt32(dsNuevaOferta.Tables[0].Rows[0]["id_Oferta"]);
            }
            else
            {
                throw new BadInsertException();
            }

        }

        public static DataSet obtenerOfertasPorCodPublicacion(int codigo)
        {
            Oferta unaOferta = new Oferta();
            unaOferta.setearListaDeParametrosConCodPublicacion(codigo);
            DataSet ds = unaOferta.TraerListado(unaOferta.parameterList, "GanadasPorCodigoPublicacion");
            unaOferta.parameterList.Clear();
            return ds;
        }



        #endregion

        #region metodos privados

        private void setearListaDeParametrosConMontoCodPublicacionVendedorCompradorFecha()
        {
            parameterList.Add(new SqlParameter("@cod_Publicacion", Publicacion.Codigo));
            parameterList.Add(new SqlParameter("@id_Usuario_Vendedor", usuario_Vendedor.Id_Usuario));
            parameterList.Add(new SqlParameter("@id_Usuario_Comprador", usuario_Comprador.Id_Usuario));
            parameterList.Add(new SqlParameter("@Fecha", Fecha));
            parameterList.Add(new SqlParameter("@Monto", Monto));

        }

        private void setearListaDeParametrosConCodPublicacion(int codigo)
        {
            parameterList.Add(new SqlParameter("@cod_Publicacion", codigo));
        }

        #endregion
    }
}
