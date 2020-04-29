using SistemAcademico.Entidades;
using System.Collections;
using System.Collections.Generic;

namespace SistemAcademico.DA
{
    public class Calificaciones
    {
        Conexion Helper = new Conexion();
        public List<CalificacionEntidad> ConsultarCalificacion(int? idPeriodo, int? idCursoSeccion, int? idAsignatura)
        {
            List<CalificacionEntidad> result = new List<CalificacionEntidad>();

            var parametros = new Hashtable()
            {
                { "idPeriodo", idPeriodo},
                { "idCursoSeccion", idCursoSeccion},
                { "idAsignatura", idAsignatura}
            };

            var datos = Helper.ConsultarSp("ConsCalificaciones", parametros);

            while (datos.Read())
            {
                CalificacionEntidad calificacion = new CalificacionEntidad();

                calificacion.IdCalificacion = (int)datos["IdSeccion"];
                calificacion.IdAlumno = (int)datos["IdCurso"];
                calificacion.IdAsignatura = (int)datos["IdAsignatura"];
                calificacion.IdCursoSeccion = (int)datos["IdCursoSeccion"];
                calificacion.IdSemestre = (int)datos["IdSemestre"];
                calificacion.Detalle = LlenarDetalle(idPeriodo, idCursoSeccion, idAsignatura);               

                result.Add(calificacion);
            }
            return result;
        }

        public List<CalificacionesDetalleEntidad> LlenarDetalle(int? idPeriodo, int? idCursoSeccion, int? idAsignatura)
        {
            List<CalificacionesDetalleEntidad> result = new List<CalificacionesDetalleEntidad>();

            var parametros = new Hashtable()
            {
                { "idPeriodo", idPeriodo},
                { "idCursoSeccion", idCursoSeccion},
                { "idAsignatura", idAsignatura}
            };

            var datos = Helper.ConsultarSp("ConsCalificacionesDetalle", parametros);

            while (datos.Read())
            {
                CalificacionesDetalleEntidad calificacion = new CalificacionesDetalleEntidad();

                calificacion.NombreAlumno = datos["NombreAlumno"].ToString();
                calificacion.Nota1 = (decimal)datos["Nota1"];
                calificacion.Nota2 = (decimal)datos["Nota2"];
                calificacion.Nota3 = (decimal)datos["Nota3"];
                calificacion.Prom1 = (decimal)datos["Prom1"];
                calificacion.PromOchentaPorCiento = (decimal)datos["PromOchentaPorCiento"];
                calificacion.Prom2 = (decimal)datos["Prom2"];
                calificacion.Examen = (decimal)datos["Examen"];
                calificacion.ExamenVeintePorCiento = (decimal)datos["ExamenVeintePorCiento"];
                calificacion.PromedioFinal = (decimal)datos["PromedioFinal"];

                result.Add(calificacion);
            }

            return result;
        }
    }
}