using SistemAcademico.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SistemAcademico.DA
{
    public class Admin
    {
        public Conexion Helper { get; set; }
        public List<ProfesorEntidad> ConsultarProfesores(int idProfesor)
        {
            List<ProfesorEntidad> result = new List<ProfesorEntidad>();

            var parametros = new Hashtable
            {
                {"id", idProfesor}
            };

            var datos = Helper.ConsultarSp("ConsProfesor", parametros);

            while (datos.Read())
            {
                ProfesorEntidad model = new ProfesorEntidad();

                model.IdProfesor = Convert.ToInt32(datos["IdAlumno"]);
                model.Nombres = datos["Nombres"].ToString();
                model.Apellidos = datos["Apellidos"].ToString();
                model.Cedula = datos["Cedula"].ToString();

                result.Add(model);
            }
            return result;
        }

        public void GrabarProfesor(ProfesorEntidad model)
        {
            var parametros = new Hashtable
            {
                {"Nombres", model.Nombres},
                {"Apellidos", model.Apellidos},
                {"Cedula", model.Cedula}
            };

            Helper.EjecutarSp("InsProfesor", parametros);
        }

        public void EditarProfesor(ProfesorEntidad model)
        {
            var parametros = new Hashtable
            {
                {"Nombres", model.Nombres},
                {"Apellidos", model.Apellidos},
                {"Cedula", model.Cedula}
            };

            Helper.EjecutarSp("UpdProfesor", parametros);
        }

        public void EiminarProfesor(int idProdesor)
        {
            var parametros = new Hashtable
            {
                {"IdProfesor", idProdesor}
            };

            Helper.EjecutarSp("DelProfesor", parametros);
        }
    }
}