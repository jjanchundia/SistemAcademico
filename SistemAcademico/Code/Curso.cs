using Microsoft.AspNetCore.Mvc.Rendering;
using SistemAcademico.DA;
using SistemAcademico.Entidades;
using SistemAcademico.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemAcademico.Code
{
    public class Curso
    {
        static Cursos curso = new Cursos();
        private static CursoEntidad PrepareCurso(CursoModel model)
        {
            var curso = new CursoEntidad();
            curso.IdCurso = model.IdCurso;
            curso.Nombre = model.Nombre;
            curso.Descripcion = model.Descripcion;

            return curso;
        }       

        public static List<CursoModel> ConsultarCurso(int? idCurso)
        {
            return curso.ConsultarCurso(idCurso).Select(i => new CursoModel
            {
                Nombre = i.Nombre,
                Descripcion = i.Descripcion,
                IdCurso = i.IdCurso
            }).ToList();
        }

        public static CursoModel ConsultarCursoPorId(int idCurso)
        {
            return curso.ConsultarCurso(idCurso).Select(i => new CursoModel
            {
                IdCurso = i.IdCurso,
                Nombre = i.Nombre,
                Descripcion = i.Descripcion,
            }).FirstOrDefault();
        }

        public static SelectList ConsultarCatalogoCurso()
        {
            return curso.ConsultarCatalogoCurso();
        }

        public static void GrabarCurso(CursoModel model)
        {
            curso.GrabarCurso(PrepareCurso(model));
        }

        public static void ActualizarCurso(CursoModel model)
        {
            curso.ActualizarCurso(PrepareCurso(model));
        }

        public static void EliminarCurso(int idCurso)
        {
            curso.EiminarCurso(idCurso);
        }

        public static SelectList ConsultarCatalogoCursoSeccion()
        {
            return curso.ConsultarCatalogoCursoSeccion();
        }

        public static List<CursoSeccionModel> ConsultarCursoSeccion()
        {
            return curso.ConsultarCursoSeccion().Select(i => new CursoSeccionModel
            {
                IdCursoSeccion = i.IdCursoSeccion,
                IdCurso = i.IdCurso,
                NombreCurso = i.NombreCurso,
                IdSeccion = i.IdSeccion,
                NombreSeccion = i.NombreSeccion
            }).ToList();
        }
    }
}