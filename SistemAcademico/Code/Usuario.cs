using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SistemAcademico.DA;
using SistemAcademico.Entidades;
using SistemAcademico.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemAcademico.Code
{
    public class Usuario
    {
        static Usuarios usuarios = new Usuarios();
        private static UsuarioEntidad PrepareUsuario(UsuarioModel model)
        {
            var usuario = new UsuarioEntidad();
            usuario.IdUsuario = model.IdUsuario;
            usuario.Usuario = model.Usuario;
            usuario.Password = model.Password;
            usuario.IdRol = model.IdRol;

            return usuario;
        }

        public static List<UsuarioModel> ConsultarUsuario(string usuario, string password)
        {
            return usuarios.ConsultarUsuario(usuario, password).Select(i => new UsuarioModel
            {
                IdUsuario = i.IdUsuario,
                Usuario = i.Usuario,
                Password = i.Password,
                IdRol = i.IdRol
            }).ToList();
        }

        public static List<MenuModel> ConsultarMenu(int idRol)
        {
            return usuarios.ConsultarMenu(idRol).Select(i => new MenuModel
            {
                NombreAccion = i.NombreAccion,
                NombreController = i.NombreController,
                Mensaje = i.Mensaje
            }).ToList();
        }

        //public static UsuarioModel ConsultarCursoPorId(int idUsuario)
        //{
        //    return usuario.ConsultarUsuario(usuario, password).Select(i => new UsuarioModel
        //    {
        //        Usuario = i.Usuario,
        //        Password = i.Password
        //    }).ToList();
        //}

        //public static void GrabarCurso(CursoModel model)
        //{
        //    curso.GrabarCurso(PrepareCurso(model));
        //}

        //public static void ActualizarCurso(CursoModel model)
        //{
        //    curso.ActualizarCurso(PrepareCurso(model));
        //}

        //public static void EliminarCurso(int idCurso)
        //{
        //    curso.EiminarCurso(idCurso);
        //}        
    }
}