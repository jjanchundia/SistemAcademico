using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemAcademico.Models
{
    public class AlumnoModel
    {
        public int IdAlumno { get; set; }
        public int IdCursoSeccion { get; set; }
        public string NombreCursoSeccion{ get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
}
