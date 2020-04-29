using System;
using System.Collections.Generic;
using System.Text;

namespace SistemAcademico.Entidades
{
    public class UsuarioEntidad
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
        public int IdTipoUsuario { get; set; }
    }
}
