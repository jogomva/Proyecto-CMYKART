using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DRoles
    {
        #region Variables

        private int _Idperfil;
        private int _Idregla;

        #endregion


        #region Propiedades
        public int Idperfil
        {
            get { return _Idperfil; }
            set { _Idperfil = value; }
        }

        public int Idregla
        {
            get { return _Idregla; }
            set { _Idregla = value; }
        }

        #endregion

        public DRoles()
        {

        }

        public DRoles(int idperfil,int idregla)
        {
            this.Idperfil = idperfil;
            this.Idregla = idregla;
        }


        #region Metodos

        //Metodo para mostrar el listado
        public DataTable Mostrar(Int32 idperfil)
        {
            DataTable DtResultado = new DataTable("Roles");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Mostrar_Reglas_Perfil";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPerfil = new SqlParameter();
                ParIdPerfil.ParameterName = "@idperfil";
                ParIdPerfil.SqlDbType = SqlDbType.Int;
                ParIdPerfil.Value = idperfil;
                SqlCmd.Parameters.Add(ParIdPerfil);


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {

                DtResultado = null;
            }
            return DtResultado;
        }

        //Metodo para insertar
        public string  Insertar(DRoles Rol)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Insertar_Regla_Perfil";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                

                SqlParameter ParIdPerfil = new SqlParameter();
                ParIdPerfil.ParameterName = "@perfilid";
                ParIdPerfil.SqlDbType = SqlDbType.Int;
                ParIdPerfil.Value = Rol.Idperfil;
                SqlCmd.Parameters.Add(ParIdPerfil);

                SqlParameter ParIdRegla = new SqlParameter();
                ParIdRegla.ParameterName = "@reglaid";
                ParIdRegla.SqlDbType = SqlDbType.Int;
                ParIdRegla.Value = Rol.Idregla;
                SqlCmd.Parameters.Add(ParIdRegla);

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se insertó el registro¡";
            }
            catch (Exception ex)
            {
                
                respuesta = ex.Message+ex.StackTrace;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return respuesta;

        }



        //Metodo para eliminar
        public string Eliminar(DRoles Rol)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Eliminar_PerfilRegla";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPerfil = new SqlParameter();
                ParIdPerfil.ParameterName = "@idperfil";
                ParIdPerfil.SqlDbType = SqlDbType.Int;
                ParIdPerfil.Value = Rol.Idperfil;
                SqlCmd.Parameters.Add(ParIdPerfil);

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Eliminó el Registro!";


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

        #endregion

    }
}
