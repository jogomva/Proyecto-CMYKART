using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DPedidos
    {
        #region Variables

        private int _Idpedido;
        private int _Idcliente;
        private DateTime _Fecha;
        private bool _Arte_hecho;
        private bool _Arte_aprobado;
        private bool _Sublimado;
        private bool _Entregado;
        private int _Idusuario;

        
        #endregion


        #region Propiedades

        public int Idpedido
        {
            get { return _Idpedido; }
            set { _Idpedido = value; }
        }


        public int Idcliente
        {
            get { return _Idcliente; }
            set { _Idcliente = value; }
        }


        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }


        public bool Arte_hecho
        {
            get { return _Arte_hecho; }
            set { _Arte_hecho = value; }
        }

        public bool Arte_aprobado
        {
            get { return _Arte_aprobado; }
            set { _Arte_aprobado = value; }
        }


        public bool Sublimado
        {
            get { return _Sublimado; }
            set { _Sublimado = value; }
        }

        public bool Entregado
        {
            get { return _Entregado; }
            set { _Entregado = value; }
        }

        public int Idusuario
        {
            get { return _Idusuario; }
            set { _Idusuario = value; }
        }




        #endregion




        public DPedidos()
        {


        }

        public DPedidos(int idpedido, int idcliente, DateTime fecha, bool arte_hecho,
            bool arte_aprobado, bool sublimado, bool entregado, int idusuario)
        {
            this.Idpedido = idpedido;
            this.Idcliente = idcliente;
            this.Fecha = fecha;
            this.Arte_hecho = arte_aprobado;
            this.Arte_aprobado = arte_aprobado;
            this.Sublimado = sublimado;
            this.Entregado= entregado;
            this.Idusuario = idusuario;
        }



        #region Metodos

       //Metodo para insertar datos
        public string Insertar(DPedidos Pedido, List<DDetalle_Pedido> Detalle)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer la trasacción
                SqlTransaction SqlTra = SqlCon.BeginTransaction();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "SP_Insertar_Pedido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPedido = new SqlParameter();
                ParIdPedido.ParameterName = "@idpedido";
                ParIdPedido.SqlDbType = SqlDbType.Int;
                ParIdPedido.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdPedido);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Pedido.Idcliente;
                SqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Pedido.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@idusuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Pedido.Idusuario;
                SqlCmd.Parameters.Add(ParIdUsuario);

                //Ejecutamos el comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingres el Registro";

                if (rpta.Equals("OK"))
                {
                    //Obtener el código del Pedido generado
                    this.Idpedido = Convert.ToInt32(SqlCmd.Parameters["@idpedido"].Value);
                    //
                    
                    foreach (DDetalle_Pedido det in Detalle)
                    {
                        det.Idpedido = this.Idpedido;

                        //Llamar al método insertar de la clase DDetalle_Pedido
                        rpta = det.Insertar(det, ref SqlCon, ref SqlTra);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                        else
                        {
                            //Actualizamos el stock
                            rpta = DisminuirStock(det.Idpresentacion, det.Cantidad);
                            if (!rpta.Equals("OK"))
                            {
                                break;
                            }
                        }
                    }

                }
                if (rpta.Equals("OK"))
                {
                    SqlTra.Commit(); 
                    
                }
                else
                {
                    SqlTra.Rollback();
                }


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

        //Metodo para editar pedidos
        public string Editar(DPedidos Pedido)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Editar_Pedidos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPedido = new SqlParameter();
                ParIdPedido.ParameterName = "@idpedido";
                ParIdPedido.SqlDbType = SqlDbType.Int;
                ParIdPedido.Value = Pedido.Idpedido;
                SqlCmd.Parameters.Add(ParIdPedido);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Pedido.Idcliente;
                SqlCmd.Parameters.Add(ParIdCliente);


                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Pedido.Fecha;
                SqlCmd.Parameters.Add(ParFecha);


                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se modificó el registro¡";
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




        //Metodo para actualizar trazabilidad
        public string ActualizarTrazabilidad(DPedidos Pedido)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Actualizar_Trazabilidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPedido = new SqlParameter();
                ParIdPedido.ParameterName = "@idpedido";
                ParIdPedido.SqlDbType = SqlDbType.Int;
                ParIdPedido.Value = Pedido.Idpedido;
                SqlCmd.Parameters.Add(ParIdPedido);

                SqlParameter ParArte_Hecho = new SqlParameter();
                ParArte_Hecho.ParameterName = "@arte_hecho";
                ParArte_Hecho.SqlDbType = SqlDbType.Bit;
                ParArte_Hecho.Value = Pedido.Arte_hecho;
                SqlCmd.Parameters.Add(ParArte_Hecho);

                SqlParameter ParArte_Aprobado = new SqlParameter();
                ParArte_Aprobado.ParameterName = "@arte_aprobado";
                ParArte_Aprobado.SqlDbType = SqlDbType.Bit;
                ParArte_Aprobado.Value = Pedido.Arte_aprobado;
                SqlCmd.Parameters.Add(ParArte_Aprobado);

                SqlParameter ParSublimado = new SqlParameter();
                ParSublimado.ParameterName = "@sublimado";
                ParSublimado.SqlDbType = SqlDbType.Bit;
                ParSublimado.Value = Pedido.Sublimado;
                SqlCmd.Parameters.Add(ParSublimado);

                SqlParameter ParEntregado = new SqlParameter();
                ParEntregado.ParameterName = "@entregado";
                ParEntregado.SqlDbType = SqlDbType.Bit;
                ParEntregado.Value = Pedido.Entregado;
                SqlCmd.Parameters.Add(ParEntregado);

                


                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se modificó el registro¡";
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







        //Metodo para devolver la cantidad en stock en caso de anular un pedido
        public string AumentarStock(int idpresentacion, int cantidad)
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
                SqlCmd.CommandText = "SP_Aumentar_Stock";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = idpresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = cantidad;
                SqlCmd.Parameters.Add(ParCantidad);


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


        //Metodo para disminuir el stock cuendo se realiza un pedido
        public string DisminuirStock(int idpresentacion, int cantidad)
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
                SqlCmd.CommandText = "SP_DisminuirStock";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = idpresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = cantidad;
                SqlCmd.Parameters.Add(ParCantidad);


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


        //Metodo para buscar la presentacion por nombre de presentacion
        public DataTable Mostrar_Presentacion_Pedido_Nombre()
        {
            DataTable DtResultado = new DataTable("Presentacion");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Mostrar_Inventario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //SqlParameter ParTextoBuscar = new SqlParameter();
                //ParTextoBuscar.ParameterName = "@textoabuscar";
                //ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                //ParTextoBuscar.Size = 50;
                //ParTextoBuscar.Value = TextoBuscar;
                //SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        //Metodo para mostrar los pedidos
        public DataTable  Mostrar()
        {
            DataTable DtResultado = new DataTable("Pedido");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Mostrar_Pedido";
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

        //Metodo para buscar los pedidos por fecha
        public DataTable BuscarPedidoFecha(String TextoBuscar1, String TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("Pedidos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Buscar_Pedido_Fecha";
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
            catch (Exception)
            {
                DtResultado = null ;
            }
            return DtResultado;

        }


        //Metodo para mostrar un reporte de las ventas a buscar por fecha
        public DataTable ReporteVentas(String TextoBuscar1, String TextoBuscar2, String Usuario)
        {
            DataTable DtResultado = new DataTable("Pedidos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Reporte_Ventas";
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

                SqlParameter ParUsuario= new SqlParameter();
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


        //Metodo para mostrar el detalle del pedido que se va a rebajar del stock
        public DataTable MostrarDetallePedido(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("detalle_venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Mostrar_Detalle_Pedido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
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

        //Metodo para anular un pedido
        public string Anular(int DetallePedido)
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
                SqlCmd.CommandText = "SP_Anular_Pedido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalle = new SqlParameter();
                ParIdDetalle.ParameterName = "@iddetalle";
                ParIdDetalle.SqlDbType = SqlDbType.Int;
                ParIdDetalle.Value = DetallePedido;
                SqlCmd.Parameters.Add(ParIdDetalle);


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

        public DataTable ReporteCantidadVendida (string buscar, string usuario)
        {
            DataTable dtResultado = new DataTable("Presentacion");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Reporte_Cantidad_Vendida";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@buscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = buscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtResultado);
            }
            catch (Exception)
            {

                dtResultado = null;
            }
            return dtResultado;
        }
           



        #endregion




    }
}
