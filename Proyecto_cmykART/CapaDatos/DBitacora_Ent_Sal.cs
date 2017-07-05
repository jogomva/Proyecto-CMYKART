using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DBitacora_Ent_Sal
    {
        #region Variables

        private int _Idbitacora_ent_sal;
        private int _Idusuario;
        private DateTime _Fecha;
        private string _Transaccion;

        #endregion


        #region Propiedades
        public int Idbitacora_ent_sal
        {
            get { return _Idbitacora_ent_sal; }
            set { _Idbitacora_ent_sal = value; }
        }
        

        public int Idusuario
        {
            get { return _Idusuario; }
            set { _Idusuario = value; }
        }
        

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        

        public string Transaccion
        {
            get { return _Transaccion; }
            set { _Transaccion = value; }
        }

        #endregion

        public DBitacora_Ent_Sal()
        {

        }

        public DBitacora_Ent_Sal(int idbitacora, int idusuario, DateTime fecha , string transaccion)
        {
            this.Idbitacora_ent_sal = idbitacora;
            this.Idusuario = idusuario;
            this.Fecha = fecha;
            this.Transaccion = transaccion;
        }




        #region Metodos

        //Metodo para Inserar nuevos datos
        public string Insertar(DBitacora_Ent_Sal Bitacora)
        {
            string bitacora = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Insertar_Bitacora_Ent_Sal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdBitacora = new SqlParameter();
                ParIdBitacora.ParameterName = "@idbitacora_ent_sal";
                ParIdBitacora.SqlDbType = SqlDbType.Int;
                ParIdBitacora.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdBitacora);

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Bitacora.Idusuario;
                SqlCmd.Parameters.Add(ParIdUsuario);


                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Bitacora.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParTransaccion = new SqlParameter();
                ParTransaccion.ParameterName = "@transaccion";
                ParTransaccion.SqlDbType = SqlDbType.VarChar;
                ParTransaccion.Size = 30;
                ParTransaccion.Value = Bitacora.Transaccion;
                SqlCmd.Parameters.Add(ParTransaccion);

                //SqlParameter ParLlave = new SqlParameter();
                //ParLlave.ParameterName = "@llave";
                //ParLlave.SqlDbType = SqlDbType.Int;
                //ParLlave.Value = Bitacora.Llave;
                //SqlCmd.Parameters.Add(ParLlave);

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


        //Metodo para buscar datos
        public DataTable BuscarBitacora_Ent_Sal(int usuario)
        {
            DataTable DtResultado = new DataTable("Bitacora");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Mostrar_Bitacora_Ent_Sal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.Int;
                ParUsuario.Value = usuario;
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

        //Metodo para buscar por fechas
        public DataTable BuscarBitacora_Ent_Sal_Fecha(int usuario,String fechaInicial, String fechaFinal)
        {
            DataTable DtResultado = new DataTable("Bitacora");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Mostrar_Bitacora_Ent_Sal_Fecha";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.Int;
                ParUsuario.Value = usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParFechaInicial = new SqlParameter();
                ParFechaInicial.ParameterName = "@fecha_inicio";
                ParFechaInicial.SqlDbType = SqlDbType.VarChar;
                ParFechaInicial.Value = fechaInicial;
                SqlCmd.Parameters.Add(ParFechaInicial);

                SqlParameter ParFechaFinal = new SqlParameter();
                ParFechaFinal.ParameterName = "@fecha_final";
                ParFechaFinal.SqlDbType = SqlDbType.VarChar;
                ParFechaFinal.Value = fechaFinal;
                SqlCmd.Parameters.Add(ParFechaFinal);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        #endregion
    }
}
