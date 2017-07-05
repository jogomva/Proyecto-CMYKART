using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DArticulos
    {

        #region Variables

        private int _IdArticulo;
        private string _Codigo;
        private string _Descripcion;
        private int _Idusuario;
        private string _Textobuscar;

        #endregion





        #region Propiedades

        public int IdArticulo
        {
            get { return _IdArticulo; }
            set { _IdArticulo = value; }
        }

        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public string Textobuscar
        {
            get { return _Textobuscar; }
            set { _Textobuscar = value; }
        }
        public int Idusuario
        {
            get { return _Idusuario; }
            set { _Idusuario = value; }
        }

        #endregion

        


        public DArticulos()
        {

        }

        public DArticulos(int idarticulo, string codigo, string descripcion,int idusuario, string textobuscar)
        {
            this.IdArticulo = idarticulo;
            this.Codigo = codigo;
            this.Descripcion = descripcion;
            this.Idusuario = idusuario;
            this.Textobuscar = textobuscar;
        }



        #region Metodos

        //Metodo que muestra los primeros 100 registros 
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Mostrar_Articulos";
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

        //Metodo para Insertar nuevos registros
        public string Insertar(DArticulos Articulos)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Insertar_Articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                ParIdArticulo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdArticulo);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Articulos.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Articulos.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Articulos.Idusuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

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

        //Metodo para Editar nuevos registros
        public string Editar(DArticulos Articulos)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Editar_Articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                ParIdArticulo.Value = Articulos.IdArticulo;
                SqlCmd.Parameters.Add(ParIdArticulo);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Articulos.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Articulos.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Articulos.Idusuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

                respuesta = SqlCmd.ExecuteNonQuery() == 2 ? "OK" : "ERROR";

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

        public string Eliminar(DArticulos Articulos)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Eliminar_Articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                ParIdArticulo.Value = Articulos.IdArticulo;
                SqlCmd.Parameters.Add(ParIdArticulo);

                respuesta = SqlCmd.ExecuteNonQuery() == 2 ? "OK" : "ERROR";


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

        public DataTable Buscar_Codigo_Articulo(DArticulos Articulo)
        {
            DataTable DtResultado = new DataTable("Articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Buscar_Articulos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoaBuscar = new SqlParameter();
                ParTextoaBuscar.ParameterName = "textoabuscar";
                ParTextoaBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoaBuscar.Size = 50;
                ParTextoaBuscar.Value = Articulo.Textobuscar;
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
