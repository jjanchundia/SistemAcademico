using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemAcademico.Models
{
    public class CalificacionesModel
    {
        public int IdCalificacion { get; set; }
        public int IdAlumno { get; set; }        
        public int IdCursoSeccion { get; set; }
        public int IdAsignatura { get; set; }
        public int IdSemestre { get; set; }
        public List<CalificacionesDetalleModel> Detalle { get; set; }
    }
}
