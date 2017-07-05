using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_Pedido
    {
        #region Variables

        private int _Iddetalle_pedido;
        private int _Idpedido;
        private int _Idpresentacion;
        private int _Cantidad;
        private decimal _Precio;
        private string _Articulo;
        private string _Presentacion;
        private string _Estado;


        #endregion


        #region Propiedades


        public int Iddetalle_pedido
        {
            get { return _Iddetalle_pedido; }
            set { _Iddetalle_pedido = value; }
        }
        public int Idpedido
        {
            get { return _Idpedido; }
            set { _Idpedido = value; }
        }

        public int Idpresentacion
        {
            get { return _Idpresentacion; }
            set { _Idpresentacion = value; }
        }
        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        public decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }
        public string Articulo
        {
            get { return _Articulo; }
            set { _Articulo = value; }
        }

        public string Presentacion
        {
            get { return _Presentacion; }
            set { _Presentacion = value; }
        }
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        #endregion


        public DDetalle_Pedido()
        {

        }

        public DDetalle_Pedido(int iddetalle_pedido, int idpedido, int idpresentacion, int cantidad, decimal precio, string articulo,string presentacion, string estado )
        {
            this.Iddetalle_pedido = iddetalle_pedido;
            this.Idpedido = idpedido;
            this.Idpresentacion = idpresentacion;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Articulo = articulo;
            this.Presentacion = presentacion;
            this.Estado = estado;
        }


        #region Metodos

        //mMetodo para insertar
        public string Insertar(DDetalle_Pedido Detalle_Pedido,
            ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "SP_Insertar_Detalle_Pedido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_Pedido = new SqlParameter();
                ParIddetalle_Pedido.ParameterName = "@iddetalle_pedido";
                ParIddetalle_Pedido.SqlDbType = SqlDbType.Int;
                ParIddetalle_Pedido.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_Pedido);

                SqlParameter ParIdPedido = new SqlParameter();
                ParIdPedido.ParameterName = "@idpedido";
                ParIdPedido.SqlDbType = SqlDbType.Int;
                ParIdPedido.Value = Detalle_Pedido.Idpedido;
                SqlCmd.Parameters.Add(ParIdPedido);

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Detalle_Pedido.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Detalle_Pedido.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Decimal;
                ParPrecio.Value = Detalle_Pedido.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParDiseño = new SqlParameter();
                ParDiseño.ParameterName = "@diseño";
                ParDiseño.SqlDbType = SqlDbType.VarChar;
                ParDiseño.Value = Detalle_Pedido.Articulo;
                SqlCmd.Parameters.Add(ParDiseño);

                SqlParameter ParPresentacion = new SqlParameter();
                ParPresentacion.ParameterName = "@presentacion";
                ParPresentacion.SqlDbType = SqlDbType.VarChar;
                ParPresentacion.Value = Detalle_Pedido.Presentacion;
                SqlCmd.Parameters.Add(ParPresentacion);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 50;
                ParEstado.Value = Detalle_Pedido.Estado;
                SqlCmd.Parameters.Add(ParEstado);


                //Ejecutamos el comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingresó el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;

        }



        #endregion 



    }
}
