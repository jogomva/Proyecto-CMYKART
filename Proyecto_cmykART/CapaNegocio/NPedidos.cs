using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NPedidos
    {

        public static int PedidoId;

        //Metodo que llama al metodo insertar de la clase dpedidos
        public static string Insertar(int idcliente, DateTime fecha, int idusuario,
            DataTable dtDetalles)
        {
            DPedidos Obj = new DPedidos();
            Obj.Idcliente = idcliente;
            Obj.Fecha = fecha;
            Obj.Idusuario = idusuario;
            
            List<DDetalle_Pedido> detalles = new List<DDetalle_Pedido>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Pedido detalle = new DDetalle_Pedido();
                detalle.Idpresentacion = Convert.ToInt32(row["Idpresentacion"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["Cantidad"].ToString());
                detalle.Precio = Convert.ToDecimal(row["Precio"].ToString());
                detalle.Articulo = (row["Diseño"].ToString());
                detalle.Estado = (row["Estado"].ToString());
                detalle.Presentacion = (row["Presentacion"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }


        //Metodo que llama al metodo editar de la clase dpedidos
        public static string Editar(int idpedido, int idcliente, DateTime fecha)
        {
            DPedidos Obj = new DPedidos();
            Obj.Idpedido = idpedido;
            Obj.Idcliente = idcliente;
            Obj.Fecha = fecha;
            return Obj.Editar(Obj);
        }


        public static string ActualizarTrazabilidad(int idpedido, bool arte_hecho, bool arte_aprobado, bool sublimado, bool entregado)
        {
            DPedidos Obj = new DPedidos();
            Obj.Idpedido = idpedido;
            Obj.Arte_hecho = arte_hecho;
            Obj.Arte_aprobado = arte_aprobado;
            Obj.Sublimado = sublimado;
            Obj.Entregado = entregado;
            return Obj.ActualizarTrazabilidad(Obj);
        }





        //Metodo que llama al metodo mostrar presentacion pedido nombre de la clase dpedidos
        public static DataTable Mostrar_Presentacion_Pedido_Nombre()
        {
            DPedidos Obj = new DPedidos();
            return Obj.Mostrar_Presentacion_Pedido_Nombre();
        }

        //Metodo que llama al metodo mostrar de la clase dpedidos
        public static DataTable Mostrar()
        {
            return new DPedidos().Mostrar();


        }

        //Metodo que llama al metodo buscar pedido de la clase dpedidos
        public static DataTable BuscarPedidoFecha(string textobuscar1, string textobuscar2)
        {
            DPedidos Obj = new DPedidos();
            return Obj.BuscarPedidoFecha(textobuscar1, textobuscar2);
        }

        //Metodo que llama al metodo reporte d eventas de la clase dpedidos
        public static DataTable ReporteVentas(string textobuscar1, string textobuscar2, string usuario)
        {
            DPedidos Obj = new DPedidos();
            return Obj.ReporteVentas(textobuscar1, textobuscar2, usuario);
        }

        //Metodo que llama al metodo mostrar detalle pedido de la clase dpedidos
        public static DataTable MostrarDetallePedido(string textobuscar)
        {
            DPedidos Obj = new DPedidos();
            return Obj.MostrarDetallePedido(textobuscar);
        }

        //Metodo que llama al metodo reporte de cantidad vendida
        public static DataTable ReporteCantidadVendida(string textobuscar,string usuario)
        {
            DPedidos Obj = new DPedidos();
            return Obj.ReporteCantidadVendida(textobuscar,usuario);
        }

        //Metodo que llama al metodo anular de la clase dpedidos
        public static string Anular(int iddetalle)
        {
            DPedidos Obj = new DPedidos();
            Obj.Idpedido = iddetalle;
            return Obj.Anular(iddetalle);
        }

        //Metodo que llama al metodo aumentar stock de la clase dpedidos
        public static string AumentarStock(int idpresentacion, int cantidad)
        {
            DPedidos Obj = new DPedidos();
            return Obj.AumentarStock(idpresentacion,cantidad);
        }


    }
}
