using Microsoft.AspNetCore.Mvc.Rendering;
using SistemAcademico.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemAcademico.DA
{
    public class Cursos
    {
        Conexion Helper = new Conexion();
        public List<CursoEntidad> ConsultarCurso(int? idCurso)
        {
            List<CursoEntidad> result = new List<CursoEntidad>();

            var parametros = new Hashtable
            {
                {"idCurso", idCurso},
            };

            var datos = Helper.ConsultarSp("ConsCurso", parametros);

            while (datos.Read())
            {
                CursoEntidad curso = new CursoEntidad();

                curso.IdCurso = (int)datos["IdCurso"];
                curso.Nombre = datos["Nombre"].ToString();
                curso.Descripcion = datos["Descripcion"].ToString();

                result.Add(curso);
            }
            return result;
        }

        public SelectList ConsultarCatalogoCurso()
        {
            var Catalogos = ConsultarCurso(null);
            return new SelectList(from ci in Catalogos
                                  select new { ID = ci.IdCurso, Name = $"{ ci.IdCurso} - {ci.Nombre}" }, "ID", "Name");
        }

        public void GrabarCurso(CursoEntidad curso)
        {
            var parametros = new Hashtable
            {
                {"IdProfesor", curso.IdProfesor},
                {"Nombre", curso.Nombre},
                {"descripcion", curso.Descripcion}
            };

            Helper.EjecutarSp("InsCurso", parametros);
        }

        public void ActualizarCurso(CursoEntidad curso)
        {
            var parametros = new Hashtable
            {
                {"idCurso", curso.IdCurso},
                {"nombre", curso.Nombre},
                {"descripcion", curso.Descripcion},
                {"idProfesor", curso.IdProfesor}
            };

            Helper.EjecutarSp("UpdCurso", parametros);
        }

        public void EiminarCurso(int idCurso)
        {
            var parametros = new Hashtable
            {
                {"idCurso", idCurso}
            };

            Helper.EjecutarSp("DelCurso", parametros);
        }

        public SelectList ConsultarCatalogoCursoSeccion()
        {
            var Catalogos = ConsultarCursoSeccion();
            return new SelectList(from ci in Catalogos
                                  select new { ID = ci.IdCursoSeccion, Name = $"{ci.NombreCurso + " " + ci.NombreSeccion}" }, "ID", "Name");
        }

        public List<CursoSeccionEntidad> ConsultarCursoSeccion()
        {
            List<CursoSeccionEntidad> result = new List<CursoSeccionEntidad>();

            var parametros = new Hashtable();

            var datos = Helper.ConsultarSp("ConsCursoSeccion", parametros);

            while (datos.Read())
            {
                CursoSeccionEntidad curso = new CursoSeccionEntidad();

                curso.IdCursoSeccion = (int)datos["IdCursoSeccion"];
                curso.IdCurso = (int)datos["IdCurso"];
                curso.IdSeccion = (int)datos["IdSeccion"];
                curso.NombreCurso = datos["NombreCurso"].ToString();
                curso.NombreSeccion = datos["NombreSeccion"].ToString();

                result.Add(curso);
            }
            return result;
        }
    }
}