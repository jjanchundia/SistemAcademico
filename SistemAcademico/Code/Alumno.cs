using SistemAcademico.DA;
using SistemAcademico.Entidades;
using SistemAcademico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemAcademico.Code
{
    public class Alumno
    {
        static Alumnos alumno = new Alumnos();
        private static AlumnoEntidad PrepareAlumno(AlumnoModel model)
        {
            var alumno = new AlumnoEntidad();
            alumno.IdAlumno = model.IdAlumno;
            alumno.Nombres = model.Nombres;
            alumno.Apellidos = model.Apellidos;
            alumno.Cedula = model.Cedula;

            return alumno;
        }

        public static List<AlumnoModel> ConsultarAlumnos(string nombre)
        {
            return alumno.ConsultarAlumnos(nombre, null).Select(i => new AlumnoModel
            {
                IdAlumno = i.IdAlumno,
                Nombres = i.Nombres,
                Apellidos = i.Apellidos,
                Cedula = i.Cedula
            }).ToList();
        }

        public static AlumnoModel ConsultarAlumnosPorId(int idAlumno)
        {
            return alumno.ConsultarAlumnos(null, idAlumno).Select(i => new AlumnoModel
            {
                IdAlumno = i.IdAlumno,
                Nombres = i.Nombres,
                Apellidos = i.Apellidos,
                Cedula = i.Cedula
            }).FirstOrDefault();
        }

        public static void GrabarALumno(AlumnoModel model)
        {
            alumno.GrabarAlumno(PrepareAlumno(model));
        }

        public static void ActualizarAlumno(AlumnoModel model)
        {
            alumno.ActualizarAlumno(PrepareAlumno(model));
        }

        public static void EliminarAlumno(int idProfesor)
        {
            alumno.EiminarAlumno(idProfesor);
        }
    }
}