using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NClientes
    {
        // Metodo Insertar que llame al metodo Insertar de la clase DCLIENTES
        public static string Insertar(string nombre, string direccion, string telefono, string email, int idusuario)
        {
            DClientes Obj = new DClientes();
            Obj.Nombre = nombre;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Idusuario = idusuario;
            return Obj.Insertar(Obj);
        }

        // Metodo Editar que llame al metodo Editar de la clase DCLIENTES
        public static string Editar(int idcliente, string nombre, string direccion, string telefono, string email,int idusuario)
        {
            DClientes Obj = new DClientes();
            Obj.Idcliente = idcliente;
            Obj.Nombre = nombre;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Idusuario = idusuario;
            return Obj.Editar(Obj);
        }

        // Metodo Eliminar que llame al metodo Eliminar de la clase DCLIENTES
        public static string Eliminar(int idcliente)
        {
            DClientes Obj = new DClientes();
            Obj.Idcliente = idcliente;
            return Obj.Eliminar(Obj);
        }
        
        //Metodo Mostrar Clientes que llama al metodo mostrar de clase dcliente
        public static DataTable Mostrar()
        {
            return new DClientes().Mostrar();

        }

        //Metodo Buscar Cliente por Nombre que llama al metodo de la clase dcliente
        public static DataTable Buscar_Nombre_Cliente (string textoabuscar)
        {
            DClientes Obj = new DClientes();
            Obj.Textoabuscar = textoabuscar;
            return Obj.Buscar_Nombre_Cliente(Obj);
        }

    }
}
