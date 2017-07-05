using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NIngreso
    {
        //Metodo Insertar que llama al metodo Insertar de la clase DIngresos
        public static string Insertar(int idusuario, int idpresentacion, int stockinicial, int stockactual,
            string estado, decimal precio, DateTime fecha)
        {
            DIngresos Obj = new DIngresos();
            Obj.Idusuario = idusuario;
            Obj.Idpresentacion = idpresentacion;
            Obj.Stock_inicial = stockinicial;
            Obj.Stock_actual = stockactual;
            Obj.Estado = estado;
            Obj.Precio = precio;
            Obj.Fecha = fecha;
            return Obj.Insertar(Obj);
        }

        //Metodo que llama al metodo Mostrar de la clase DIngresos
        public static DataTable Mostrar()
        {
            return new DIngresos().Mostrar();


        }
        //Metodo que llama al metodo StockArticulos de la clase DIngresos
        public static DataTable Reporte_Stock(string textobuscar, string usuario)
        {
            return new DIngresos().Reporte_Stock(textobuscar, usuario);
        }

        //Metodo que llama al metodo anular de la clase DIngresos
        public static string Anular(int idingreso)
        {
            DIngresos Obj = new DIngresos();
            Obj.Idingreso = idingreso;
            return Obj.Anular(Obj);
        }

        //Metodo que llama al metodo buscar ingresos fecha de la clase dingresos
        public static DataTable BuscarIngresosFecha(string textobuscar1, string textobuscar2)
        {
            DIngresos Obj = new DIngresos();
            return Obj.BuscarIngresoFecha(textobuscar1, textobuscar2);
        }
    }
}
