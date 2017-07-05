 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DUsuario
    {
        #region Variables

        private int _Idusuario;
        private string _Nombre;
        private string _Apellidos;
        private string _Usuario;
        private string _Password;
        private string _PasswordAnterior;
        private int _Idperfil;
        private int _Idusuario_creacion;
        private string _TextoBuscar;

        #endregion


        #region Propiedades
        public int Idusuario
        {
            get { return _Idusuario; }
            set { _Idusuario = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string PasswordAnterior
        {
            get { return _PasswordAnterior; }
            set { _PasswordAnterior = value; }
        }
        public int Idperfil
        {
            get { return _Idperfil; }
            set { _Idperfil = value; }
        }

        public int Idusuario_creacion
        {
            get { return _Idusuario_creacion; }
            set { _Idusuario_creacion = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        #endregion


        public DUsuario()
        {

        }

        public DUsuario(int idusuario, string nombre, string apellidos, string usuario, string password,string passwordAnterior,
            int idperfil,int idusuario_creacion, string textobuscar)
        {
            this.Idusuario = idusuario;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Usuario = usuario;
            this.Password = password;
            this.PasswordAnterior = passwordAnterior;
            this.Idperfil = idperfil;
            this.Idusuario_creacion = idusuario_creacion;
            this.TextoBuscar = textobuscar;

        }

        #region Metodos

        //Metodo para insertar usuario
        public string Insertar(DUsuario Usuarios)
        {
            string rpta = " ";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Insertar_Usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdUsuario);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Usuarios.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 150;
                ParApellidos.Value = Usuarios.Apellidos;
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = Usuarios.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);


                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 50;
                ParPassword.Value = Usuarios.Password;
                SqlCmd.Parameters.Add(ParPassword);

                SqlParameter ParIdPerfil = new SqlParameter();
                ParIdPerfil.ParameterName = "@idperfil";
                ParIdPerfil.SqlDbType = SqlDbType.Int;
                ParIdPerfil.Value = Usuarios.Idperfil;
                SqlCmd.Parameters.Add(ParIdPerfil);

                SqlParameter ParIdUsuarioCreacion = new SqlParameter();
                ParIdUsuarioCreacion.ParameterName = "@idusuario_creacion";
                ParIdUsuarioCreacion.SqlDbType = SqlDbType.Int;
                ParIdUsuarioCreacion.Value = Usuarios.Idusuario_creacion;
                SqlCmd.Parameters.Add(ParIdUsuarioCreacion);

                rpta = SqlCmd.ExecuteNonQuery() == 2 ? "OK" : "ERROR";

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

        //Metodo para validar el ingreso del usuario al sistema
        public DataTable Login(DUsuario Usuarios)
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Login";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = Usuarios.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 50;
                ParPassword.Value = Usuarios.Password;
                SqlCmd.Parameters.Add(ParPassword);


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {

                DtResultado = null;
            }
            return DtResultado;
        }

        //Metodo para editar un usuario
        public string Editar(DUsuario Usuarios)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Editar_Usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Usuarios.Idusuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

                SqlParameter ParIdPerfil = new SqlParameter();
                ParIdPerfil.ParameterName = "@idperfil";
                ParIdPerfil.SqlDbType = SqlDbType.Int;
                ParIdPerfil.Value = Usuarios.Idperfil;
                SqlCmd.Parameters.Add(ParIdPerfil);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Usuarios.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 150;
                ParApellidos.Value = Usuarios.Apellidos;
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = Usuarios.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 50;
                ParPassword.Value = Usuarios.Password;
                SqlCmd.Parameters.Add(ParPassword);

                SqlParameter ParIdUsuarioCreacion = new SqlParameter();
                ParIdUsuarioCreacion.ParameterName = "@idusuario_creacion";
                ParIdUsuarioCreacion.SqlDbType = SqlDbType.Int;
                ParIdUsuarioCreacion.Value = Usuarios.Idusuario_creacion;
                SqlCmd.Parameters.Add(ParIdUsuarioCreacion);

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


        //Metodo para restablecer una contraseña
        public string EditarContraseña(DUsuario Usuarios)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Editar_Contraseña";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Usuarios.Idusuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 50;
                ParPassword.Value = Usuarios.Password;
                SqlCmd.Parameters.Add(ParPassword);

                

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


        //Metodo para que el udsuario modifique su contraseña
        public string CambiarContraseña(DUsuario Usuario)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Cambiar_Password";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Usuario.Idusuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

                SqlParameter ParIdUsuarioModifica = new SqlParameter();
                ParIdUsuarioModifica.ParameterName = "@idusuario_modifica";
                ParIdUsuarioModifica.SqlDbType = SqlDbType.Int;
                ParIdUsuarioModifica.Value = Usuario.Idusuario_creacion;
                SqlCmd.Parameters.Add(ParIdUsuarioModifica);

                SqlParameter ParPasswordAnterior = new SqlParameter();
                ParPasswordAnterior.ParameterName = "@password_anterior";
                ParPasswordAnterior.SqlDbType = SqlDbType.VarChar;
                ParPasswordAnterior.Size = 50;
                ParPasswordAnterior.Value = Usuario.PasswordAnterior;
                SqlCmd.Parameters.Add(ParPasswordAnterior);

                SqlParameter ParPasswordNuevo = new SqlParameter();
                ParPasswordNuevo.ParameterName = "@password_nuevo";
                ParPasswordNuevo.SqlDbType = SqlDbType.VarChar;
                ParPasswordNuevo.Size = 50;
                ParPasswordNuevo.Value = Usuario.Password;
                SqlCmd.Parameters.Add(ParPasswordNuevo);



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

        //Metodo para eliminar un usuario
        public string Eliminar(DUsuario Usuarios)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Eliminar_Usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Usuarios.Idusuario;
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

        //Metodo para mostrar el listado 
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Mostrar_Usuarios";
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

        //Metodo para buscar usuario por nombre
        public DataTable Buscar_Nombre_Usuario(DUsuario Usuarios)
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Buscar_Nombre_Usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "textoabuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Usuarios.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

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
