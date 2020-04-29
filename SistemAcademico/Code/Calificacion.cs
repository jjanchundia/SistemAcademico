using SistemAcademico.DA;
using SistemAcademico.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemAcademico.Code
{
    public class Calificacion
    {
        static Calificaciones calificacion = new Calificaciones();
        public static CalificacionesModel ConsultarCalificacion(int? idPeriodo, int? idCursoSeccion, int? idAsignatura)
        {
            return new CalificacionesModel()
            {
                IdAsignatura = (int)idAsignatura,
                IdCursoSeccion = (int)idCursoSeccion,
                Detalle = LlenarDetalleCalificacion(idPeriodo, idCursoSeccion, idAsignatura)
            };

            //return calificacion.ConsultarCalificacion(idPeriodo, idCursoSeccion, idAsignatura).Select(i => new CalificacionesModel
            //{
            //    IdCalificacion = i.IdCalificacion,
            //    IdAlumno = i.IdAlumno,
            //    IdAsignatura = i.IdAsignatura,
            //    IdCursoSeccion = i.IdCursoSeccion,
            //    IdSemestre = i.IdSemestre,
            //    Detalle = LlenarDetalleCalificacion(idPeriodo, idCursoSeccion, idAsignatura)
            //}).ToList();
        }

        private static List<CalificacionesDetalleModel> LlenarDetalleCalificacion(int? idPeriodo, int? idCursoSeccion, int? idAsignatura)
        {
            return calificacion.LlenarDetalle(idPeriodo, idCursoSeccion, idAsignatura).Select(i => new CalificacionesDetalleModel()
            {
                IdAlumno = i.IdAlumno,
                NombreAlumno = i.NombreAlumno,
                Nota1 = i.Nota1,
                Nota2 = i.Nota2,
                Nota3 = i.Nota3,
                Prom1 = i.Prom1,
                PromOchentaPorCiento = i.PromOchentaPorCiento,
                Prom2 = i.Prom2,
                Examen = i.Examen,
                ExamenVeintePorCiento = i.ExamenVeintePorCiento,
                PromedioFinal = i.PromedioFinal
            }).ToList();
        }
    }
}