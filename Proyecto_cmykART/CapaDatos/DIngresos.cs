using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DIngresos
    {
        #region Variables

        private int _Idingreso;
        private int _Idusuario;
        private int _Idpresentacion;
        private int _Stock_inicial;
        private int _Stock_actual;
        private string _Estado;
        private decimal _Precio;
        private DateTime _Fecha;


        #endregion

        #region Propiedades

        public int Idingreso
        {
            get { return _Idingreso; }
            set { _Idingreso = value; }
        }
        public int Idusuario
        {
            get { return _Idusuario; }
            set { _Idusuario = value; }
        }
        public int Idpresentacion
        {
            get { return _Idpresentacion; }
            set { _Idpresentacion = value; }
        }
        public int Stock_inicial
        {
            get { return _Stock_inicial; }
            set { _Stock_inicial = value; }
        }
        public int Stock_actual
        {
            get { return _Stock_actual; }
            set { _Stock_actual = value; }
        }
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        public decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        #endregion

        #region Contructores

        public DIngresos ()
        {

        }
        public DIngresos(int idingreso, int idusuario, int idpresentacion, int stockinicial, int stockactual, string estado,
            decimal precio, DateTime fecha)
        {
            this.Idingreso = idingreso;
            this.Idusuario = idusuario;
            this.Idpresentacion = idpresentacion;
            this.Stock_inicial = stockinicial;
            this.Stock_actual = stockactual;
            this.Estado = estado;
            this.Precio = precio;
            this.Fecha = fecha;
        }


        #endregion

        #region Metodos

        //Metodo que muestra los primeros 50 registros
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Pedidos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Mostrar_Ingresos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {

                DtResultado = null; ;
            }
            return DtResultado;
        }

        //Metodo que permite insertar nuevos registros
        public string Insertar(DIngresos Ingresos)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Insertar_Ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idingreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdIngreso);

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Ingresos.Idusuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Ingresos.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                SqlParameter ParStockInicial = new SqlParameter();
                ParStockInicial.ParameterName = "@stock_inicial";
                ParStockInicial.SqlDbType = SqlDbType.Int;
                ParStockInicial.Value = Ingresos.Stock_inicial;
                SqlCmd.Parameters.Add(ParStockInicial);

                SqlParameter ParStockActual = new SqlParameter();
                ParStockActual.ParameterName = "@stock_actual";
                ParStockActual.SqlDbType = SqlDbType.Int;
                ParStockActual.Value = Ingresos.Stock_actual;
                SqlCmd.Parameters.Add(ParStockActual);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Ingresos.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Decimal;
                ParPrecio.Value = Ingresos.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Ingresos.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                respuesta = SqlCmd.ExecuteNonQuery() == 2 ? "OK" : "No se insertó el registro¡";
            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return respuesta;
        }

        //Metodo que muestra el reporte del stock
        public DataTable Reporte_Stock(string TextoBuscar, string Usuario)
        {
            DataTable DtResultado = new DataTable("Ingresos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Reporte_Stock";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {

                DtResultado = null;
            }
            return DtResultado;
        }

        //Netodo para anular un registro de ingreso
        public string Anular(DIngresos Ingresos)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Anular_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Value = Ingresos.Idingreso;
                SqlCmd.Parameters.Add(ParIdingreso);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se anulo el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Metodo para buscar ingresos por fechas

        public DataTable BuscarIngresoFecha(String TextoBuscar1, String TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("Ingresos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Buscar_Ingresos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar1 = new SqlParameter();
                ParTextoBuscar1.ParameterName = "@textobuscar1";
                ParTextoBuscar1.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar1.Size = 50;
                ParTextoBuscar1.Value = TextoBuscar1;
                SqlCmd.Parameters.Add(ParTextoBuscar1);

                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@textobuscar2";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.Size = 50;
                ParTextoBuscar2.Value = TextoBuscar2;
                SqlCmd.Parameters.Add(ParTextoBuscar2);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        #endregion 


    }
}
