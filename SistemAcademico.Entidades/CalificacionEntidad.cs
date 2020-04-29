using System;
using System.Collections.Generic;
using System.Text;

namespace SistemAcademico.Entidades
{
    public class CalificacionEntidad
    {
        public int IdCalificacion { get; set; }
        public int IdAlumno { get; set; }
        public int IdCursoSeccion { get; set; }
        public int IdAsignatura { get; set; }
        public int IdSemestre { get; set; }
        public List<CalificacionesDetalleEntidad> Detalle { get; set; }
    }
}
