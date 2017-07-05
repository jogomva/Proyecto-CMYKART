using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DReglas
    {
        private int _Idregla;
        private string _Nombre;
        private string _Descripcion;

        public int Idregla
        {
            get { return _Idregla; }
            set { _Idregla = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public DReglas()
        {

        }

        public DReglas(int idregla, string nombre, string descripcion)
        {
            this.Idregla = idregla;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public string Insertar(DReglas Regla)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Insertar_Regla";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdregla = new SqlParameter();
                ParIdregla.ParameterName = "@idregla";
                ParIdregla.SqlDbType = SqlDbType.Int;
                ParIdregla.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdregla);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Regla.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Regla.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se insertó el registro¡";



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


    }
}
