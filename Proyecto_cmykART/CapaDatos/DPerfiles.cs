using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPerfiles
    {
        #region

        private int _Idperfil;
        private string _Nombre;
        private string _Descripcion;
        private int _Idusuario;
        private string _Textoabuscar;

        #endregion


        #region Propiedades
        public int Idperfil
        {
            get { return _Idperfil; }
            set { _Idperfil = value; }
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
        public int Idusuario
        {
            get { return _Idusuario; }
            set { _Idusuario = value; }
        }
        public string Textoabuscar
        {
            get { return _Textoabuscar; }
            set { _Textoabuscar = value; }
        }

        #endregion



        public DPerfiles()
        {

        }

        public DPerfiles(int idperfil, string nombre, string descripcion,int idusuario, string textoabuscar)
        {
            this.Idperfil = idperfil;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Idusuario = idusuario;
            this.Textoabuscar = textoabuscar;

        }

        #region Metodos
        //Metodo para insertar
        public string Insertar (DPerfiles Perfiles)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Insertar_Perfil";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPerfil = new SqlParameter();
                ParIdPerfil.ParameterName = "@idperfil";
                ParIdPerfil.SqlDbType = SqlDbType.Int;
                ParIdPerfil.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdPerfil);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre_perfil";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Perfiles.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Perfiles.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Perfiles.Idusuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

                respuesta = SqlCmd.ExecuteNonQuery() == 2 ? "OK" : "ERROR";
            }
            catch (Exception ex)
            {
                
                respuesta= ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return respuesta;
        }

        //Metodo para editar
        public string Editar(DPerfiles Perfil)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Editar_Perfil";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPerfil = new SqlParameter();
                ParIdPerfil.ParameterName = "@idperfil";
                ParIdPerfil.SqlDbType = SqlDbType.Int;
                ParIdPerfil.Value = Perfil.Idperfil;
                SqlCmd.Parameters.Add(ParIdPerfil);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Perfil.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Perfil.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Perfil.Idusuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "ERROR";
                
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

        //Metodo para eliminar
        public string Eliminar(DPerfiles Perfil)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Eliminar_Perfil";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPerfil = new SqlParameter();
                ParIdPerfil.ParameterName = "@idperfil";
                ParIdPerfil.SqlDbType = SqlDbType.Int;
                ParIdPerfil.Value = Perfil.Idperfil;
                SqlCmd.Parameters.Add(ParIdPerfil);

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "ERROR";


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

        //Metodo para mostrar el listado de los perfiles
        public DataTable MostrarPerfiles()
        {
            DataTable DtResultado = new DataTable("Perfil");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Mostrar_Perfiles";
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

        //Metodo para buscar por nombre de perfil
        public DataTable Buscar_Nombre(DPerfiles Perfil)
        {
            DataTable DtResultado = new DataTable("Perfil");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Buscar_Perfil";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoaBuscar = new SqlParameter();
                ParTextoaBuscar.ParameterName = "textoabuscar";
                ParTextoaBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoaBuscar.Size = 50;
                ParTextoaBuscar.Value = Perfil.Textoabuscar;
                SqlCmd.Parameters.Add(ParTextoaBuscar);

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
