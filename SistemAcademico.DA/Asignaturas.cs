using Microsoft.AspNetCore.Mvc.Rendering;
using SistemAcademico.Entidades;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace SistemAcademico.DA
{
    public class Asignaturas
    {
        Conexion Helper = new Conexion();
        public List<AsignaturaEntidad> ConsultarAsignatura(string nombres, int? idProfesor)
        {
            List<AsignaturaEntidad> result = new List<AsignaturaEntidad>();

            var parametros = new Hashtable();
            
            var datos = Helper.ConsultarSp("ConsAsignaturas", parametros);

            while (datos.Read())
            {
                AsignaturaEntidad article = new AsignaturaEntidad();

                article.IdAsignatura = (int)datos["IdAsignatura"];
                article.Nombre = datos["Nombre"].ToString();
                article.Descripcion = datos["Descripcion"].ToString();

                result.Add(article);
            }
            return result;
        }

        public void GrabarAsignatura(AsignaturaEntidad asignatura)
        {
            var parametros = new Hashtable
            {
                {"Nombre", asignatura.Nombre},
                {"Descripcion", asignatura.Descripcion},
            };

            Helper.EjecutarSp("InsAsignatura", parametros);
        }

        public void ActualizarAsignatura(AsignaturaEntidad asignatura)
        {
            var parametros = new Hashtable
            {
                {"idAsignatura", asignatura.IdAsignatura},
                {"nombre", asignatura.Nombre},
                {"descripcion", asignatura.Descripcion},
            };

            Helper.EjecutarSp("UpdAsignatura", parametros);
        }

        public void EiminarAsignatura(int idAsignatura)
        {
            var parametros = new Hashtable
            {
                {"idAsignatura", idAsignatura}
            };

            Helper.EjecutarSp("DelAsignatura", parametros);
        }

        public SelectList ConsultarCatalogoAsignatura()
        {
            var Catalogos = ConsultarAsignatura(null, null);
            return new SelectList(from ci in Catalogos
                                  select new { ID = ci.IdAsignatura, Name = $"{ci.Nombre}" }, "ID", "Name");
        }
    }
}