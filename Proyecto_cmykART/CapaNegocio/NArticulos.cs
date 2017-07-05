using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NArticulos
    {
        //Metodo Insertar que llama al metodo Insertar de la clase DArticulos
        public static string Insertar(string codigo, string descripcion, int idusuario)
        {
            DArticulos Obj = new DArticulos();
            Obj.Codigo = codigo;
            Obj.Descripcion = descripcion;
            Obj.Idusuario = idusuario;
            return Obj.Insertar(Obj);
        }
        //Metodo Editar que llama al metodo Editar de la clase DArticulos
        public static string Editar(int idarticulo, string codigo, string descripcion,int idusuario)
        {
            DArticulos Obj = new DArticulos();
            Obj.IdArticulo = idarticulo;
            Obj.Codigo = codigo;
            Obj.Descripcion = descripcion;
            Obj.Idusuario = idusuario;
            return Obj.Editar(Obj);
        }
        //Metodo Eliminar que llama al metodo Eliminar de la clase DArticulos
        public static string Eliminar(int idarticulo)
        {
            DArticulos Obj = new DArticulos();
            Obj.IdArticulo = idarticulo;
            return Obj.Eliminar(Obj);
        }

        //Metodo que llama al metodo Mostrar de la clase DArticulos
        public static DataTable Mostrar()
        {
            return new DArticulos().Mostrar();


        }

        //Metodo que llama al metodo buscar codigo de articulo de la clase DArticulos
        public static DataTable Buscar_Codigo_Articulo(string textoabuscar)
        {
            DArticulos Obj = new DArticulos();
            Obj.Textobuscar = textoabuscar;
            return Obj.Buscar_Codigo_Articulo(Obj);
        }
    }
}
