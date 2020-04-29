using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;
using System.IO;

namespace SistemAcademico.DA
{
    public class Conexion
    {
        public string GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build().GetSection("ConnectionStrings").GetSection("ConnDatabase").Value;
        }
        
        public MySqlDataReader ConsultarSp(string spName, Hashtable parametros)
        {
            var conexion = GetConfiguration();
            MySqlConnection connection = new MySqlConnection(conexion);
            connection.Open();
            MySqlCommand command = new MySqlCommand(spName, connection);
            command.CommandType = CommandType.StoredProcedure;

            if (parametros.Count > 0)
            {
                foreach (object o in parametros.Keys)
                {
                    command.Parameters.AddWithValue(o.ToString(), parametros[o]);
                }
            }            

            MySqlDataReader dataReader = command.ExecuteReader();

            return dataReader;
        }

        public int EjecutarSp(string spName, Hashtable parametros)
        {
            MySqlConnection connection = new MySqlConnection(GetConfiguration());
            connection.Open();

            using (MySqlCommand command = new MySqlCommand(spName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 1200;

                foreach (object o in parametros.Keys)
                {
                    command.Parameters.AddWithValue(o.ToString(), parametros[o]);
                }

                return command.ExecuteNonQuery();
            }
        }
    }
}