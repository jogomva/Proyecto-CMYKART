using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;


namespace CapaNegocio
{
    public class NPerfiles
    {
        // Metodo Insertar que llame al metodo Insertar de la clase DPERFILES
        public static string Insertar(string nombre, string descripcion, int idusuario)
        {
            DPerfiles Obj = new DPerfiles();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Idusuario = idusuario;
            return Obj.Insertar(Obj);
        }
        // Metodo editar que llame al metodo editar de la clase DPERFILES
        public static string Editar(int idperfil,string nombre, string descripcion, int idusuario)
        {
            DPerfiles Obj = new DPerfiles();
            Obj.Idperfil = idperfil;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Idusuario = idusuario;
            return Obj.Editar(Obj);
        }

        //Metodo que llama al metodo eliminar de la clase dperfil
        public static string Eliminar(int idperfil)
        {
            DPerfiles Obj = new DPerfiles();
            Obj.Idperfil = idperfil;
            return Obj.Eliminar(Obj);
        }

        //Metodo que llama al metodo mostrar de la clase dperfil
        public static DataTable Mostrar()
        {
            return new DPerfiles().MostrarPerfiles();

        
        }

        //Metodo que llama al metodo buscar nombre de la clase dperfil
        public static DataTable Buscar_Nombre(string textoabuscar)
        {
            DPerfiles Obj = new DPerfiles();
            Obj.Textoabuscar = textoabuscar;
            return Obj.Buscar_Nombre(Obj);
        }



    }
}
