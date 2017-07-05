using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NPresentacion
    {
        //Metodo insertar que llama al metodo insertar de la clase DPRESENTACION
        public static string Insertar(string nombre, string descripcion, int idusuario)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Idusuario = idusuario;
            return Obj.Insertar(Obj);
        }

        //Metodo EDITAR que llama al metodo EDITAR de la clase DPRESENTACION
        public static string Editar(int idpresentacion, string nombre, string descripcion, int idusuario)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Idpresentacion = idpresentacion;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Idusuario = idusuario;
            return Obj.Editar(Obj);
        }

        //Metodo ELIMINAR que llama al metodo ELIMINAR de la clase DPRESENTACION
        public static string Eliminar(int idpresentacion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Idpresentacion = idpresentacion;
            return Obj.Eliminar(Obj);
        }


        //Metodo Inactivar que llama al metodo Inactivar de la clase DPRESENTACION
        public static string Inactivar(int idpresentacion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Idpresentacion = idpresentacion;
            return Obj.Inactivar(Obj);
        }


        //Metodo MOSTRAR que llama al metodo MOSTRAR de la clase DPRESENTACION
        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();


        }


        //Metodo MostrarInventario que llama al metodo MostrarInventario de la clase DPRESENTACION
        public static DataTable MostrarInventario()
        {
            return new DPresentacion().MostrarInventario();


        }

        //Metodo BUSCAR PRESENTACION que llama al metodo BUSCAR PRESENTACION de la clase DPRESENTACION
        public static DataTable Buscar_Presentacion(string textoabuscar)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Textoabuscar = textoabuscar;
            return Obj.Buscar_Presentacion(Obj);
        }


        //Metodo Aumentar Inventario que llama al metodo Aumentar Inventariode la clase DPRESENTACION
        public static string AgregarInventario(int idpresentacion, int stock)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Idpresentacion = idpresentacion;
            Obj.Stock = stock;
            return Obj.AgregarInventario(Obj);
        }
    
    }
}
