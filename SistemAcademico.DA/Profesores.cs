using SistemAcademico.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemAcademico.DA
{
    public class Profesores
    {
        Conexion Helper = new Conexion();
        public List<ProfesorEntidad> ConsultarProfesores(string nombres, int? idProfesor)
        {
            List<ProfesorEntidad> result = new List<ProfesorEntidad>();

            var parametros = new Hashtable
            {
                {"nombres", nombres},
                {"idProfesor", idProfesor},
            };

            var datos = Helper.ConsultarSp("ConsProfesor", parametros);

            while (datos.Read())
            {
                ProfesorEntidad article = new ProfesorEntidad();

                article.IdProfesor = (int)datos["IdProfesor"];
                article.Nombres = datos["Nombres"].ToString();
                article.Apellidos = datos["Apellidos"].ToString();
                article.Cedula = datos["Cedula"].ToString();

                result.Add(article);
            }
            return result;
        }

        public ProfesorEntidad ConsultarProfesorPorId(int idProfesor)
        {
            var parametros = new Hashtable
            {
                {"idProfesor", idProfesor}
            };

            var datos = Helper.ConsultarSp("ConsProfesorPorId", parametros);

            while (datos.Read())
            {
                ProfesorEntidad profesor = new ProfesorEntidad();

                profesor.IdProfesor = (int)datos["IdProfesor"];
                profesor.Nombres = datos["Nombres"].ToString();
                profesor.Apellidos = datos["Apellidos"].ToString();
                profesor.Cedula = datos["Cedula"].ToString();

                return profesor;
            }

            return new ProfesorEntidad();
        }

        public SelectList ConsultarCatalogoProfesor()
        {
            var Catalogos = ConsultarProfesores(null, null);
            return new SelectList(from ci in Catalogos
                                  select new { ID = ci.IdProfesor, Name = $"{ ci.IdProfesor.ToString()} - {ci.Nombres + " " + ci.Apellidos}" }, "ID", "Name");
        }

        public void GrabarProfesor(ProfesorEntidad profesor)
        {
            var parametros = new Hashtable
            {
                {"nombres", profesor.Nombres},
                {"apellidos", profesor.Apellidos},
                {"cedula", profesor.Cedula}
            };

            Helper.EjecutarSp("InsProfesor", parametros);
        }

        public void ActualizarProfesor(ProfesorEntidad profesor)
        {
            var parametros = new Hashtable
            {
                {"IdProfesor", profesor.IdProfesor},
                {"Nombres", profesor.Nombres},
                {"Apellidos", profesor.Apellidos},
                {"Cedula", profesor.Cedula}
            };

            Helper.EjecutarSp("UpdProfesor", parametros);
        }

        public void EiminarProfesor(int idProfesor)
        {
            var parametros = new Hashtable
            {
                {"idProfesor", idProfesor}
            };

            Helper.EjecutarSp("DelProfesor", parametros);
        }

        public void GrabarCalificacion(AlumnoEntidad alumno, int nota1, int nota2, int nota3, int nota4)
        {

        }
    }
}