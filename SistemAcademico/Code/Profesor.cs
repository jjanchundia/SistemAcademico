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
    public class Profesor
    {
        static Profesores profesor = new Profesores();
        
        private static ProfesorEntidad PrepareProfesor(ProfesorModel model)
        {
            var profesor = new ProfesorEntidad();
            profesor.IdProfesor = model.IdProfesor;
            profesor.Nombres = model.Nombres;
            profesor.Apellidos = model.Apellidos;
            profesor.Cedula = model.Cedula;

            return profesor;
        }
        public static List<ProfesorModel> ConsultarProfesores(string nombres, int? idProfesor)
        {
            return profesor.ConsultarProfesores(nombres, idProfesor).Select(i => new ProfesorModel
            {
                IdProfesor = i.IdProfesor,
                Nombres = i.Nombres,
                Apellidos = i.Apellidos,
                Cedula = i.Cedula
            }).ToList();
        }              

        public static ProfesorModel ConsultarProfesorPorId(int idAlumno)
        {
            return profesor.ConsultarProfesores(null, idAlumno).Select(i => new ProfesorModel
            {
                IdProfesor = i.IdProfesor,
                Nombres = i.Nombres,
                Apellidos = i.Apellidos,
                Cedula = i.Cedula
            }).FirstOrDefault();
        }

        public static SelectList ConsultarCatalogoProfesor()
        {
            return profesor.ConsultarCatalogoProfesor();
        }
        public static void GrabarProfesor(ProfesorModel model)
        {
            profesor.GrabarProfesor(PrepareProfesor(model));
        }

        public static void ActualizarProfesor(ProfesorModel model)
        {
            profesor.ActualizarProfesor(PrepareProfesor(model));
        }

        public static void EliminarProfesor(int idProfesor)
        {
            profesor.EiminarProfesor(idProfesor);
        }
    }
}