using Microsoft.AspNetCore.Mvc.Rendering;
using SistemAcademico.DA;
using SistemAcademico.Entidades;
using SistemAcademico.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemAcademico.Code
{
    public class Asignatura
    {
        static Asignaturas asignatura = new Asignaturas();
        private static AsignaturaEntidad PrepareAsignatura(AsignaturaModel model)
        {
            var asignatura = new AsignaturaEntidad();
            asignatura.Nombre = model.Nombre;
            asignatura.Descripcion = model.Descripcion;

            return asignatura;
        }

        public static List<AsignaturaModel> ConsultarAsignatura(string nombre)
        {
            return asignatura.ConsultarAsignatura(nombre, null).Select(i => new AsignaturaModel
            {
                IdAsignatura = i.IdAsignatura,
                Nombre = i.Nombre,
                Descripcion = i.Descripcion,
            }).ToList();
        }

        public static AsignaturaModel ConsultarAsignaturaPorId(int idAsignatura)
        {
            return asignatura.ConsultarAsignatura(null, idAsignatura).Select(i => new AsignaturaModel
            {
                IdAsignatura = i.IdAsignatura,
                Nombre = i.Nombre,
                Descripcion = i.Descripcion,
            }).FirstOrDefault();
        }

        public static void GrabarAsignatura(AsignaturaModel model)
        {
            asignatura.GrabarAsignatura(PrepareAsignatura(model));
        }

        public static void ActualizarAsignatura(AsignaturaModel model)
        {
            asignatura.ActualizarAsignatura(PrepareAsignatura(model));
        }

        public static void EliminarAsignatura(int idAsignatura)
        {
            asignatura.EiminarAsignatura(idAsignatura);
        }

        public static SelectList ConsultarCatalogoAsignatura()
        {
            return asignatura.ConsultarCatalogoAsignatura();
        }
    }
}