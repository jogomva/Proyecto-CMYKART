using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NRoles
    {
        //Metodo que llama al metodo MOSTRAR de la clase droles
        public static DataTable Mostrar(int idperfil)
        {
            DRoles Obj = new DRoles();
            
            return Obj.Mostrar(idperfil);
        }

        //Metodo que llama al metodo INSERTAR de la clase droles
        public static string Insertar(int idperfil,int idregla)
        {
            DRoles Obj = new DRoles();
            Obj.Idperfil = idperfil;
            Obj.Idregla = idregla;
            return Obj.Insertar(Obj);
            
        }

        //Metodo que llama al metodo ELIMINAR de la clase droles
        public static string Eliminar(int idperfil)
        {
            DRoles Obj = new DRoles();
            Obj.Idperfil = idperfil;
            return Obj.Eliminar(Obj);


        }
    } 
}
