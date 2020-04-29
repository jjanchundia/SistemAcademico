using SistemAcademico.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SistemAcademico.DA
{
    public class Alumnos
    {
        Conexion Helper = new Conexion();
        public List<AlumnoEntidad> ConsultarAlumnos(string nombre, int? idAlumno)
        {
            List<AlumnoEntidad> result = new List<AlumnoEntidad>();

            var parametros = new Hashtable 
            {
                {"nombre", nombre},
                {"idAlumno", idAlumno}
            };

            var datos = Helper.ConsultarSp("ConsAlumno", parametros);

            while (datos.Read())
            {
                AlumnoEntidad article = new AlumnoEntidad();

                article.IdAlumno = Convert.ToInt32(datos["IdAlumno"]);
                article.Nombres = datos["Nombres"].ToString();
                article.Apellidos = datos["Apellidos"].ToString();
                article.Cedula = datos["Cedula"].ToString();

                result.Add(article);
            }
            return result;
        }
        
        public void GrabarAlumno(AlumnoEntidad alumno)
        {
            var parametros = new Hashtable
            {
                {"Nombres", alumno.Nombres},
                {"Apellidos", alumno.Apellidos},
                {"Cedula", alumno.Cedula}
            };

            Helper.EjecutarSp("InsAlumno", parametros);
        }

        public void ActualizarAlumno(AlumnoEntidad alumno)
        {
            var parametros = new Hashtable
            {
                {"IdAlumno", alumno.IdAlumno},
                {"Nombres", alumno.Nombres},
                {"Apellidos", alumno.Apellidos},
                {"Cedula", alumno.Cedula}
            };

            Helper.EjecutarSp("UpdAlumno", parametros);
        }

        public void EiminarAlumno(int idAlumno)
        {
            var parametros = new Hashtable
            {
                {"IdAlumno", idAlumno}
            };

            Helper.EjecutarSp("DelAlumno", parametros);
        }        
    }
}