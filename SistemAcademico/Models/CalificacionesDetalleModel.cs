using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemAcademico.Models
{
    public class CalificacionesDetalleModel
    {
        public int IdAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }
        public decimal Nota3 { get; set; }
        public decimal Prom1 { get; set; }
        public decimal Prom2 { get; set; }
        public decimal PromOchentaPorCiento { get; set; }
        public decimal Examen { get; set; }
        public decimal ExamenVeintePorCiento { get; set; }
        public decimal Quimestre1 { get; set; }
        public decimal Quimestre2 { get; set; }
        public decimal PromedioFinal { get; set; }
    }
}
