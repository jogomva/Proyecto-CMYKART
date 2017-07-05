using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NBitacora_Movimientos
    {
        public static string Insertar( string transaccion, string tabla, int usuario, int llave, string texto)
        {
            DBitacora_Movimientos Obj = new DBitacora_Movimientos();
            Obj.Transaccion = transaccion;
            Obj.Tabla = tabla;
            Obj.Idusuario = usuario;
            Obj.Llave = llave;
            Obj.Texto = texto;
            return Obj.Insertar(Obj);
        }


        public static DataTable BuscarBitacoraMovimientosFecha(int usuario,string textobuscar1, string textobuscar2)
        {
            DBitacora_Movimientos Obj = new DBitacora_Movimientos();
            return Obj.BuscarBitacoraMovimientosFecha(usuario,textobuscar1, textobuscar2);
        }
    }
}
