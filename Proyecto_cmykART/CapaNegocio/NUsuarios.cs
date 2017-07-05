using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    
    public class NUsuario
    {
        
        //Metodo insertar que llama al metodo insertar de la clase DUSUARIOS
        public static string Insertar(string nombre, string apellidos, string usuario, string password, int idperfil, int idusuario_creacion)
        {
            DUsuario obj = new DUsuario();
            obj.Nombre = nombre;
            obj.Apellidos = apellidos;
            obj.Usuario = usuario;
            obj.Password = password;
            obj.Idperfil = idperfil;
            obj.Idusuario_creacion = idusuario_creacion;
            return obj.Insertar(obj);
        }

        //Metodo Login que llama al metodo Login de la clase DUSUARIOS
        public static DataTable Login (string usuario, string password)
        {
            DUsuario Obj = new DUsuario();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }

        //Metodo Editar que llama al metodo Editar de la clase DUSUARIOS
        public static string Editar(int idusuario, string nombre, string apellidos, string usuario, int idperfil,string password, int idusuario_creacion)
        {
            DUsuario obj = new DUsuario();
            obj.Idusuario = idusuario;
            obj.Nombre = nombre;
            obj.Apellidos = apellidos;
            obj.Usuario = usuario;
            obj.Idperfil = idperfil;
            obj.Password = password;
            obj.Idusuario_creacion = idusuario_creacion;
            return obj.Editar(obj);
        }

        //Metodo que llama al metodo EDITAR CONTRASEÑA  de la clase dusuario
        public static string EditarContraseña(int idusuario, string password)
        {
            DUsuario obj = new DUsuario();
            obj.Idusuario = idusuario;
            obj.Password = password;
            return obj.EditarContraseña(obj);
        }

        //Metodo que llama al metodo CAMBIAR CONTRASEÑA  de la clase dusuario
        public static string CambiarContraseña(int idusuario,int idusuario_modifica, string passwordAnterior, string passwordNuevo)
        {
            DUsuario obj = new DUsuario();
            obj.Idusuario = idusuario;
            obj.Idusuario_creacion = idusuario_modifica;
            obj.PasswordAnterior = passwordAnterior;
            obj.Password = passwordNuevo;
            return obj.CambiarContraseña(obj);
        }

        //Metodo Eliminar que llama al metodo Eliminar de la clase DUSUARIOS
        public static string Eliminar(int idusuario)
        {
            DUsuario Obj = new DUsuario();
            Obj.Idusuario = idusuario;
            return Obj.Eliminar(Obj);
        }

        //Metodo Mostrar que llama al metodo Mostrar de la clase DUSUARIOS
        public static DataTable Mostrar()
        {
            return new DUsuario().Mostrar();


        }

        //Metodo Buscar_Nombre que llama al metodo Buscar_Nombre de la clase DUSUARIOS
        public static DataTable Buscar_Nombre_Usuario(string textoabuscar)
        {
            DUsuario Obj = new DUsuario();
            Obj.TextoBuscar = textoabuscar;
            return Obj.Buscar_Nombre_Usuario(Obj);
        }
        
    
    }
}
