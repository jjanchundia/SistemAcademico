using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemAcademico.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Password{ get; set; }
        public int IdRol { get; set; }
        public int IdTipoUsuario { get; set; }
    }
}
