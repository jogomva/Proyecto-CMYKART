using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DClientes
    {
        #region Variables

        private int _Idcliente;
        private string _Nombre;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private int _Idusuario;
        private string _Textoabuscar;

        #endregion

        #region Propiedades
        public int Idcliente
        {
            get { return _Idcliente; }
            set { _Idcliente = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
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

        #region Constructores

        public DClientes()
        {

        }

        public DClientes(int idcliente, string nombre, string direccion, string telefono, string email,int idusuario , string textoabuscar)
        {
            this.Idcliente = idcliente;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Idusuario = idusuario;
            this.Textoabuscar = textoabuscar;
        }

        #endregion


        #region Metodos


        //Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Mostrar_Clientes";
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
        
        //Metodo para buscar por nombre del cliente
        public DataTable Buscar_Nombre_Cliente(DClientes Cliente)
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Buscar_Cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoaBuscar = new SqlParameter();
                ParTextoaBuscar.ParameterName = "textoabuscar";
                ParTextoaBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoaBuscar.Size = 150;
                ParTextoaBuscar.Value = Cliente.Textoabuscar;
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

        //Metodo Insertar Cliente
        public string Insertar(DClientes Cliente)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer la trasacción
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Insertar_Cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 150;
                ParNombre.Value = Cliente.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 150;
                ParDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 50;
                ParTelefono.Value = Cliente.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 150;
                ParEmail.Value = Cliente.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Cliente.Idusuario;
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

        //Metodo Editar Cliente
        public string Editar(DClientes Cliente)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Editar_Cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Cliente.Idcliente;
                SqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 150;
                ParNombre.Value = Cliente.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 150;
                ParDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 50;
                ParTelefono.Value = Cliente.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 150;
                ParEmail.Value = Cliente.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Cliente.Idusuario;
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

        //Metodo Eliminar Cliente
        public string Eliminar(DClientes Cliente)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Eliminar_Cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Cliente.Idcliente;
                SqlCmd.Parameters.Add(ParIdCliente);

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


        #endregion
    }
}
