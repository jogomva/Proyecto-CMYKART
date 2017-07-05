using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DBitacora_Movimientos
    {
        #region Variables

        private int _Idbitacora_mov;
        private int _Idusuario;
        private string _Transaccion;
        private string _Tabla;
        private int _Llave;
        private string _Texto;

        #endregion


        #region Propiedades

        public int Idbitacora_mov
        {
            get { return _Idbitacora_mov; }
            set { _Idbitacora_mov = value; }
        }
        public int Idusuario
        {
            get { return _Idusuario; }
            set { _Idusuario = value; }
        }

        public string Transaccion
        {
            get { return _Transaccion; }
            set { _Transaccion = value; }
        }
        public string Tabla
        {
            get { return _Tabla; }
            set { _Tabla = value; }
        }
        public int Llave
        {
            get { return _Llave; }
            set { _Llave = value; }
        }
        public string Texto
        {
            get { return _Texto; }
            set { _Texto = value; }
        }

        #endregion
        public DBitacora_Movimientos()
        {

        }

        public DBitacora_Movimientos(int idbitacora_mov, int idusuario, string transaccion, string tabla, int llave, string texto)
        {
            this.Idbitacora_mov = idbitacora_mov;
            this.Idusuario = idusuario;
            this.Transaccion = transaccion;
            this.Tabla = tabla;
            this.Llave = llave;
            this.Texto = texto;
        }


        #region Metodos
        //Metodo para insertar datos
        public string Insertar(DBitacora_Movimientos Bitacora)
        {
            string bitacora = "";
            SqlConnection SqlCon = new SqlConnection();
            

            try
            {
                //Establecer el Comando
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Insertar_Bitacora_Movimietos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdBitacora = new SqlParameter();
                ParIdBitacora.ParameterName = "@idbitacora_mov";
                ParIdBitacora.SqlDbType = SqlDbType.Int;
                ParIdBitacora.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdBitacora);

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Bitacora.Idusuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

                SqlParameter ParTransaccion = new SqlParameter();
                ParTransaccion.ParameterName = "@transaccion";
                ParTransaccion.SqlDbType = SqlDbType.VarChar;
                ParTransaccion.Size = 30;
                ParTransaccion.Value = Bitacora.Transaccion;
                SqlCmd.Parameters.Add(ParTransaccion);

                SqlParameter ParTabla = new SqlParameter();
                ParTabla.ParameterName = "@tabla";
                ParTabla.SqlDbType = SqlDbType.VarChar;
                ParTabla.Size = 30;
                ParTabla.Value = Bitacora.Tabla;
                SqlCmd.Parameters.Add(ParTabla);

                SqlParameter ParLlave = new SqlParameter();
                ParLlave.ParameterName = "@llave";
                ParLlave.SqlDbType = SqlDbType.Int;
                ParLlave.Value = Bitacora.Llave;
                SqlCmd.Parameters.Add(ParLlave);

                SqlParameter ParTexto = new SqlParameter();
                ParTexto.ParameterName = "@texto";
                ParTexto.SqlDbType = SqlDbType.VarChar;
                ParTexto.Size = 100;
                ParTexto.Value = Bitacora.Texto;
                SqlCmd.Parameters.Add(ParTexto);

                bitacora = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se insertó el registro¡";
            }
            catch (Exception ex)
            {

                bitacora = ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return bitacora;
        }


        //Metodo para buscar por fechas
        public DataTable BuscarBitacoraMovimientosFecha( int Usuario,String TextoBuscar1, String TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("Movimientos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Buscar_Bitacora_Movimientos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.Int;
                ParUsuario.Value = Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParTextoBuscar1 = new SqlParameter();
                ParTextoBuscar1.ParameterName = "@fecha_inicial";
                ParTextoBuscar1.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar1.Size = 50;
                ParTextoBuscar1.Value = TextoBuscar1;
                SqlCmd.Parameters.Add(ParTextoBuscar1);

                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@fecha_final";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.Size = 50;
                ParTextoBuscar2.Value = TextoBuscar2;
                SqlCmd.Parameters.Add(ParTextoBuscar2);

                

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception )
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        #endregion

    }
}
