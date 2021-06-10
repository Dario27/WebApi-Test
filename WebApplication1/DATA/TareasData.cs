using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DATA
{
    public class TareasData
    {      
        public static string rutaConnexionSQL = ConfigurationManager.ConnectionStrings["WebApplication1.Properties.Settings.SqlServer"].ConnectionString;
        public static bool Registrar(Tareas objTareas)
        {
            using (SqlConnection oConexion = new SqlConnection(rutaConnexionSQL))
            {
                SqlCommand cmd = new SqlCommand("tsp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", objTareas.Descripcion);
                cmd.Parameters.AddWithValue("@EstTarea", objTareas.EstTarea);
                cmd.Parameters.AddWithValue("@Autor", objTareas.AutorTarea);
                cmd.Parameters.AddWithValue("@fechCreacion", objTareas.FechaCreacion);
                cmd.Parameters.AddWithValue("@FechaVence", objTareas.FechaVence);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool Modificar(Tareas objTareas)
        {
            using (SqlConnection oConexion = new SqlConnection(rutaConnexionSQL))
            {
                SqlCommand cmd = new SqlCommand("tsp_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idtarea", objTareas.IdTarea);
                cmd.Parameters.AddWithValue("@Descripcion", objTareas.Descripcion);
                cmd.Parameters.AddWithValue("@EstTarea", objTareas.EstTarea);
                cmd.Parameters.AddWithValue("@Autor", objTareas.AutorTarea);
                cmd.Parameters.AddWithValue("@FechaVence", objTareas.FechaVence);
                cmd.Parameters.AddWithValue("@fechCreacion", objTareas.FechaCreacion);                

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Tareas> Listar()
        {
            List<Tareas> oListaTareas = new List<Tareas>();
            using (SqlConnection oConexion = new SqlConnection(rutaConnexionSQL))
            {
                SqlCommand cmd = new SqlCommand("tsp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaTareas.Add(new Tareas()
                            {
                                IdTarea = Convert.ToInt32(dr["IdTarea"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                EstTarea = dr["EstTarea"].ToString(),
                                AutorTarea = dr["AutorTarea"].ToString(),
                                FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"].ToString()),
                                FechaVence = Convert.ToDateTime(dr["FechaVence"].ToString())
                            });
                        }

                    }



                    return oListaTareas;
                }
                catch (Exception)
                {
                    return oListaTareas;
                }
            }
        }

        public static Tareas ObtenerById(int idTarea)
        {
            Tareas oTareas = new Tareas();            
            using (SqlConnection oConexion = new SqlConnection(rutaConnexionSQL))
            {
                SqlCommand cmd = new SqlCommand("tsp_obtenerByID", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTarea", idTarea);
               
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oTareas = new Tareas()
                            {
                                IdTarea = Convert.ToInt32(dr["IdTarea"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                EstTarea = dr["EstTarea"].ToString(),
                                AutorTarea = dr["AutorTarea"].ToString(),
                                FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"].ToString()),
                                FechaVence = Convert.ToDateTime(dr["FechaVence"].ToString())
                            };
                        }

                    }



                    return oTareas;
                }
                catch (Exception)
                {
                    return oTareas;
                }
            }
        }

        public static List<Tareas> ObtenerByFilter()
        {
            List<Tareas> oListaFchVence = new List<Tareas>();
            using (SqlConnection oConexion = new SqlConnection(rutaConnexionSQL))
            {
                SqlCommand cmd = new SqlCommand("tsp_obtenerByFchVence", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaFchVence.Add(new Tareas()
                            {
                                IdTarea = Convert.ToInt32(dr["IdTarea"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                EstTarea = dr["EstTarea"].ToString(),
                                AutorTarea = dr["AutorTarea"].ToString(),
                                FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"].ToString()),
                                FechaVence = Convert.ToDateTime(dr["FechaVence"].ToString())
                            });
                        }

                    }

                    return oListaFchVence;
                }
                catch (Exception)
                {
                    return oListaFchVence;
                }
            }
        }

        public static bool Eliminar(Tareas oTareas)
        {
            using (SqlConnection oConexion = new SqlConnection(rutaConnexionSQL))
            {
                SqlCommand cmd = new SqlCommand("tsp_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTarea", oTareas.IdTarea);
                cmd.Parameters.AddWithValue("@autor", oTareas.AutorTarea);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}