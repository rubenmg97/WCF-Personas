using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Entity;

namespace DaobussinesPersonas
{
    public class DBPersona
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Sql"].ConnectionString);

        public List<EntPersona> Obtener()
        {
            SqlCommand comando = new SqlCommand("spObtenerPersonas", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            List<EntPersona> ls = new List<EntPersona>();

            foreach (DataRow fila in tabla.Rows)
            {
                EntPersona p = new EntPersona();
                p.Id = Convert.ToInt32(fila["Id"]);
                p.Nombre = fila["Nombre"].ToString();
                p.Paterno = fila["Paterno"].ToString();
                p.Materno = fila["Materno"].ToString();
                p.Sexo = Convert.ToBoolean(fila["Sexo"]);
                p.Nacimiento = Convert.ToDateTime(fila["FechaNacimiento"]);
                p.Alta = Convert.ToDateTime(fila["FechaAlta"]);
                p.Edad = Convert.ToInt32(fila["Edad"]);

                ls.Add(p);
            }

            return ls;
        }

        public EntPersona Obtener(int Id)
        {
            SqlCommand comando = new SqlCommand("spObtenerPersonasId", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            DataRow fila = tabla.Rows[0];

            EntPersona p = new EntPersona();
            p.Id = Convert.ToInt32(fila["Id"]);
            p.Nombre = fila["Nombre"].ToString();
            p.Paterno = fila["Paterno"].ToString();
            p.Materno = fila["Materno"].ToString();
            p.Sexo = Convert.ToBoolean(fila["Sexo"]);
            p.Nacimiento = Convert.ToDateTime(fila["FechaNacimiento"]);
            p.Alta = Convert.ToDateTime(fila["FechaAlta"]);
            p.Edad = Convert.ToInt32(fila["Edad"]);
            return p;
        }


        public List<EntPersona> Obtener(String nombre)
        {
            SqlCommand comando = new SqlCommand("spObtenerPersonasNombre", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            List<EntPersona> ls = new List<EntPersona>();

            foreach (DataRow fila in tabla.Rows)
            {
                EntPersona p = new EntPersona();
                p.Id = Convert.ToInt32(fila["Id"]);
                p.Nombre = fila["Nombre"].ToString();
                p.Paterno = fila["Paterno"].ToString();
                p.Materno = fila["Materno"].ToString();
                p.Sexo = Convert.ToBoolean(fila["Sexo"]);
                p.Nacimiento = Convert.ToDateTime(fila["FechaNacimiento"]);
                p.Alta = Convert.ToDateTime(fila["FechaAlta"]);
                p.Edad = Convert.ToInt32(fila["Edad"]);

                ls.Add(p);
            }

            return ls;
        }

        public Boolean Obtener(String nombre, String paterno, String materno)
        {
            SqlCommand comando = new SqlCommand("spObtenerPersonasNombreCompleto", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Paterno", paterno);
            comando.Parameters.AddWithValue("@Materno", materno);
            SqlDataAdapter data = new SqlDataAdapter();
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            if (tabla.Rows[0] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void Create(EntPersona p)
        {
            int filasAfectadas = 0;
            SqlCommand comando = new SqlCommand("spCrearPersona", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", p.Nombre);
            comando.Parameters.AddWithValue("@Paterno", p.Paterno);
            comando.Parameters.AddWithValue("@Materno", p.Materno);
            comando.Parameters.AddWithValue("@Sexo", p.Sexo);
            comando.Parameters.AddWithValue("@FechaNacimiento", p.Nacimiento);

            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
                if (filasAfectadas != 1)
                {
                    throw new ApplicationException("Error al Crear Persona");
                }
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }


        }

        public void Edit(EntPersona p)
        {
            int filasAfectadas = 0;
            SqlCommand comando = new SqlCommand("spEditarPersona", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", p.Id);
            comando.Parameters.AddWithValue("@Nombre", p.Nombre);
            comando.Parameters.AddWithValue("@Paterno", p.Paterno);
            comando.Parameters.AddWithValue("@Materno", p.Materno);
            comando.Parameters.AddWithValue("@FechaNacimiento", p.Nacimiento);
            comando.Parameters.AddWithValue("@Sexo", p.Sexo);
            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
                if (filasAfectadas != 1)
                {
                    throw new ApplicationException("Error Al Editar");
                }
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }

        }

        public void Delete(EntPersona p)
        {
            int filasAfectadas = 0;
            SqlCommand comando = new SqlCommand("spBorrarPersona", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", p.Id);

            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
                if (filasAfectadas != 1)
                {
                    throw new ApplicationException("Error Al Borrar");
                }
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

    }
}
