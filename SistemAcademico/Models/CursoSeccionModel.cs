using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemAcademico.Models
{
    public class CursoSeccionModel
    {
        public int IdCursoSeccion { get; set; }
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public int IdSeccion { get; set; }
        public string NombreSeccion{ get; set; }
    }
}
