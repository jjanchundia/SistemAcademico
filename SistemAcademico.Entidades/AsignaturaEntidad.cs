using System;
using System.Collections.Generic;
using System.Text;

namespace SistemAcademico.Entidades
{
    public class AsignaturaEntidad
    {
        public int IdAsignatura { get; set; }
        public int IdProfesor { get; set; }
        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string NombreProfesor { get; set; }
        public string NombreCurso { get; set; }
    }
}
