using Microsoft.AspNetCore.Mvc.Rendering;
using SistemAcademico.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SistemAcademico.DA
{
    public class Secciones
    {
        Conexion Helper = new Conexion();
        public List<SeccionEntidad> ConsultarSeccion(int? idSeccion)
        {
            List<SeccionEntidad> result = new List<SeccionEntidad>();

            var parametros = new Hashtable
            {
                {"idSeccion", idSeccion},
            };

            var datos = Helper.ConsultarSp("ConsSeccion", parametros);

            while (datos.Read())
            {
                SeccionEntidad seccion = new SeccionEntidad();

                seccion.IdSeccion = (int)datos["IdSeccion"];
                seccion.Nombre = datos["Nombre"].ToString();
                seccion.Descripcion = datos["Descripcion"].ToString();

                result.Add(seccion);
            }
            return result;
        }

        public void GrabarSeccion(SeccionEntidad Seccion)
        {
            var parametros = new Hashtable
            {
                {"nombre", Seccion.Nombre},
                {"descripcion", Seccion.Descripcion},
            };

            Helper.EjecutarSp("InsSeccion", parametros);
        }

        public void ActualizarSeccion(SeccionEntidad seccion)
        {
            var parametros = new Hashtable
            {
                {"idSeccion", seccion.IdSeccion},
                {"nombre", seccion.Nombre},
                {"descripcion", seccion.Descripcion},
            };

            Helper.EjecutarSp("UpdSeccion", parametros);
        }

        public void EiminarSeccion(int idSeccion)
        {
            var parametros = new Hashtable
            {
                {"idSeccion", idSeccion}
            };

            Helper.EjecutarSp("DelSeccion", parametros);
        }

        public SelectList ConsultarCatalogoSeccion()
        {
            var Catalogos = ConsultarSeccion(null);
            return new SelectList(from ci in Catalogos
                                  select new { ID = ci.IdSeccion, Name = $"{ci.Nombre}" }, "ID", "Name");
        }

        public void GrabarCursoSeccion(CursoSeccionEntidad model)
        {
            var parametros = new Hashtable
            {
                {"idCurso", model.IdCurso},
                {"idSeccion", model.IdSeccion},
            };

            Helper.EjecutarSp("InsCursoSeccion", parametros);
        }
    }
}