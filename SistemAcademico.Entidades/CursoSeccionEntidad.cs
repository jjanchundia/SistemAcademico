using System;
using System.Collections.Generic;
using System.Text;

namespace SistemAcademico.Entidades
{
    public class CursoSeccionEntidad
    {
        public int IdCursoSeccion { get; set; }
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public int IdSeccion { get; set; }
        public string NombreSeccion { get; set; }
    }
}
