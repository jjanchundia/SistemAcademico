using SistemAcademico.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SistemAcademico.DA
{
    public class Usuarios
    {
        Conexion Helper = new Conexion();
        public List<UsuarioEntidad> ConsultarUsuario(string usuario, string password)
        {
            List<UsuarioEntidad> result = new List<UsuarioEntidad>();

            var parametros = new Hashtable
            {
                {"usuario", usuario},
                {"password", password},
            };

            var datos = Helper.ConsultarSp("ConsUsuario", parametros);

            while (datos.Read())
            {
                UsuarioEntidad usuarios = new UsuarioEntidad();
                usuarios.IdUsuario = (int)datos["IdUsuario"];
                usuarios.Usuario = datos["Usuario"].ToString();
                usuarios.Password = datos["Password"].ToString();
                usuarios.IdRol = (int)datos["IdRol"];

                result.Add(usuarios);
            }
            return result;
        }

        public List<MenuEntidad> ConsultarMenu(int idRol)
        {
            List<MenuEntidad> result = new List<MenuEntidad>();

            var parametros = new Hashtable
            {
                { "idRol", idRol}
            };

            var datos = Helper.ConsultarSp("ConsMenu", parametros);

            while (datos.Read())
            {
                MenuEntidad menu = new MenuEntidad();

                menu.NombreAccion = datos["Accion"].ToString();
                menu.NombreController = datos["Controlador"].ToString();
                menu.Mensaje = datos["Mensaje"].ToString();

                result.Add(menu);
            }
            return result;
        }
        
        //public void GrabarUsuario(CursoEntidad curso)
        //{
        //    var parametros = new Hashtable
        //    {
        //        {"IdProfesor", curso.IdProfesor},
        //        {"Nombre", curso.Nombre},
        //        {"descripcion", curso.Descripcion}
        //    };

        //    Helper.EjecutarSp("InsCurso", parametros);
        //}

        //public void ActualizarUsuario(CursoEntidad curso)
        //{
        //    var parametros = new Hashtable
        //    {
        //        {"idCurso", curso.IdCurso},
        //        {"nombre", curso.Nombre},
        //        {"descripcion", curso.Descripcion},
        //        {"idProfesor", curso.IdProfesor}
        //    };

        //    Helper.EjecutarSp("UpdCurso", parametros);
        //}

        //public void EiminarUsuario(int idCurso)
        //{
        //    var parametros = new Hashtable
        //    {
        //        {"idCurso", idCurso}
        //    };

        //    Helper.EjecutarSp("DelCurso", parametros);
        //}
    }
}