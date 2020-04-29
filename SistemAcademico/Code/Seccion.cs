using Microsoft.AspNetCore.Mvc.Rendering;
using SistemAcademico.DA;
using SistemAcademico.Entidades;
using SistemAcademico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemAcademico.Code
{
    public class Seccion
    {
        static Secciones seccion = new Secciones();

        private static SeccionEntidad PrepareSeccion(SeccionModel model)
        {
            var seccion = new SeccionEntidad();
            seccion.IdSeccion = model.IdSeccion;
            seccion.IdCurso = model.IdCurso;
            seccion.IdProfesor = model.IdProfesor;
            seccion.Nombre = model.Nombre;
            seccion.Descripcion = model.Descripcion;

            return seccion;
        }

        public static List<SeccionModel> ConsultarSeccion(int? idProfesor)
        {
            return seccion.ConsultarSeccion(idProfesor).Select(i => new SeccionModel
            {
                IdProfesor = i.IdProfesor,
                Nombre = i.Nombre,
                Descripcion = i.Descripcion,
                IdCurso = i.IdCurso,
                IdSeccion = i.IdSeccion
            }).ToList();
        }       

        public static SeccionModel ConsultarSeccionPorId(int idAlumno)
        {
            return seccion.ConsultarSeccion(idAlumno).Select(i => new SeccionModel
            {
                IdProfesor = i.IdProfesor,
                Nombre = i.Nombre,
                Descripcion = i.Descripcion,
                IdCurso = i.IdCurso,
                IdSeccion = i.IdSeccion
            }).FirstOrDefault();
        }

        public static void GrabarSeccion(SeccionModel model)
        {
            seccion.GrabarSeccion(PrepareSeccion(model));
        }

        public static void ActualizarSeccion(SeccionModel model)
        {
            seccion.ActualizarSeccion(PrepareSeccion(model));
        }

        public static void EliminarSeccion(int idSeccion)
        {
            seccion.EiminarSeccion(idSeccion);
        }

        public static SelectList ConsultarCatalogoSeccion()
        {
            return seccion.ConsultarCatalogoSeccion();
        }

        public static void GrabarCursoSeccion(CursoSeccionModel model)
        {
            seccion.GrabarCursoSeccion(PrepareCursoSeccion(model));
        }

        private static CursoSeccionEntidad PrepareCursoSeccion(CursoSeccionModel model)
        {
            var seccion = new CursoSeccionEntidad();
            seccion.IdCursoSeccion = model.IdCursoSeccion;
            seccion.IdSeccion = model.IdSeccion;
            seccion.IdCurso = model.IdCurso;

            return seccion;
        }
    }
}