using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemAcademico.Models
{
    public class CursoModel
    {
        public int IdCurso { get; set; }
        public int IdProfesor { get; set; }
        public string NombreProfesor { get; set; }
        public string Nombre { get; set; }
        public string Descripcion{ get; set; }
        public int Estado { get; set; }
    }
}
