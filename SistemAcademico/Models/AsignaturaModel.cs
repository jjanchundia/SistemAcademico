using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemAcademico.Models
{
    public class AsignaturaModel
    {
        public int IdAsignatura { get; set; }
        public int IdProfesor { get; set; }
        public int IdCurso { get; set; }
        public string Nombre{ get; set; }
        public string Descripcion{ get; set; }
        public string NombreProfesor { get; set; }
        public string NombreCurso { get; set; }
    }
}
