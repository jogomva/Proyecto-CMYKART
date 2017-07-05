
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NBitacora_Ent_Sal
    {
        public static string Insertar(int idusuario,   DateTime fecha, string transaccion)
        {
            DBitacora_Ent_Sal Obj = new DBitacora_Ent_Sal();
            Obj.Idusuario = idusuario;
            Obj.Fecha = fecha;
            Obj.Transaccion = transaccion;
            return Obj.Insertar(Obj);
        }


        public static DataTable BuscarBitacora_Ent_Sal(int usuario)
        {
            DBitacora_Ent_Sal Obj = new DBitacora_Ent_Sal();
            return Obj.BuscarBitacora_Ent_Sal(usuario);
        }


        public static DataTable BuscarBitacora_Ent_Sal_Fecha(int usuario, string fechainicial, string fechafinal)
        {
            DBitacora_Ent_Sal Obj = new DBitacora_Ent_Sal();
            return Obj.BuscarBitacora_Ent_Sal_Fecha(usuario,fechainicial, fechafinal);
        }


    }
}
