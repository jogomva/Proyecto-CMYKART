using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DPresentacion
    {
        #region Variables

        private int _Idpresentacion;
        private string _Nombre;
        private string _Descripcion;
        private int _Idusuario;
        private string _Textoabuscar;
        private bool _Inactivo;
        private int _Stock;

     
        #endregion

        #region Propiedades
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public int Idpresentacion
        {
            get { return _Idpresentacion; }
            set { _Idpresentacion = value; }
        }
        public string Textoabuscar
        {
            get { return _Textoabuscar; }
            set { _Textoabuscar = value; }
        }
        public int Idusuario
        {
            get { return _Idusuario; }
            set { _Idusuario = value; }
        }
        public bool Inactivo
        {
            get { return _Inactivo; }
            set { _Inactivo = value; }
        }
        public int Stock
        {
            get { return _Stock; }
            set { _Stock = value; }
        }

        

        #endregion
        public DPresentacion()
        {

        }

        public DPresentacion(int idpresentacion, string nombre, string descripcion, int idusuario,bool inactivo,int stock)
        {
            this.Idpresentacion = idpresentacion;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Idusuario = idusuario;
            this.Inactivo = inactivo;
            this.Stock = stock;
        }


        #region Metodos

        //Metodo para insertar
        public string Insertar(DPresentacion Presentacion)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Insertar_Presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "@idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdpresentacion);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Presentacion.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Presentacion.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Presentacion.Idusuario;
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

        //Metodo para editar presentaciones
        public string Editar(DPresentacion Presentacion)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Editar_Presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Presentacion.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Presentacion.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Presentacion.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Presentacion.Idusuario;
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
        public string Eliminar(DPresentacion Presentacion)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Eliminar_Presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Presentacion.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

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



        //Inactivar Presentacion
        public string Inactivar(DPresentacion Presentacion)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Inactivar_Presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Presentacion.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

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



        //Metodo para mostrar un listado
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Presentaciones");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Mostrar_Presentaciones";
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



        //Metodo para mostrar Inventario
        public DataTable MostrarInventario()
        {
            DataTable DtResultado = new DataTable("Presentaciones");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Mostrar_Inventario";
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



        //Metodo para buscar por nombre de presentacion
        public DataTable Buscar_Presentacion(DPresentacion Presentacion)
        {
            DataTable DtResultado = new DataTable("Presentacion");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Buscar_Presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoaBuscar = new SqlParameter();
                ParTextoaBuscar.ParameterName = "textoabuscar";
                ParTextoaBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoaBuscar.Size = 50;
                ParTextoaBuscar.Value = Presentacion.Textoabuscar;
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



        public string AgregarInventario(DPresentacion Presentacion)
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
                SqlCmd.CommandText = "SP_Aumentar_Inventario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Presentacion.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                SqlParameter ParStock= new SqlParameter();
                ParStock.ParameterName = "@cantidad";
                ParStock.SqlDbType = SqlDbType.Int;
                ParStock.Value = Presentacion.Stock;
                SqlCmd.Parameters.Add(ParStock);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizó el stock";


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



        #endregion

    }
}
