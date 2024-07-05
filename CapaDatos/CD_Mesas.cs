using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Mesas
    {
        private static CD_Mesas instancia = null;

        public CD_Mesas()
        {

        }

        public static CD_Mesas Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new CD_Mesas();
                }

                return instancia;
            }
        }

        public bool Registrar(Mesas oMesas)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarMesas", oConexion);
                    cmd.Parameters.AddWithValue("NumeroMesa", oMesas.NumeroMesa);
                    cmd.Parameters.AddWithValue("Capacidad", oMesas.Capacidad);
                    cmd.Parameters.AddWithValue("IdEstadoMesas", oMesas.oEstadoMesas.IdEstadoMesas);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public bool Modificar(Mesas oMesas)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarMesa", oConexion);
                    cmd.Parameters.AddWithValue("IdMesas", oMesas.IdMesas);
                    cmd.Parameters.AddWithValue("NumeroMesa", oMesas.NumeroMesa);
                    cmd.Parameters.AddWithValue("IdEstadoMesas", oMesas.oEstadoMesas.IdEstadoMesas);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }


        public List<Mesas> Listar()
        {
            List<Mesas> Lista = new List<Mesas>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select m.IdMesas,m.NumeroMesas,m.Capacidad");
                    query.AppendLine("em.IdEstadoMesas,em.Descripcion[DescripcionMesas]");
                    query.AppendLine("from mesas m");
                    query.AppendLine("inner join EstadoMesas em on em.IdEstadoMesas = m.IdEstadoMesas");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new Mesas()
                            {
                                IdMesas = Convert.ToInt32(dr["IdMesas"]),
                                NumeroMesa = Convert.ToInt32(dr["NumeroMesas"]),
                                Capacidad = Convert.ToInt32(dr["Capacidad"]),
                                oEstadoMesas = new EstadoMesas() { IdEstadoMesas = Convert.ToInt32(dr["IdEstadoMesas"]), Descripcion = dr["DescripcionEstadoMesas"].ToString() },
                                
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Lista = new List<Mesas>();
                }
            }
            return Lista;
        }

        public bool Eliminar(int id)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("delete from mesas where IdMesas = @id", oConexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = true;

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }

        public bool ActualizarEstado(int IdMesas, int IdEstadoMesas)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update mesas set IdEstadoMesas = @IdEstadoHabitacion where IdMesas = @IdMesas ", oConexion);
                    cmd.Parameters.AddWithValue("@IdMesas", IdMesas);
                    cmd.Parameters.AddWithValue("@IdEstadoMesas", IdEstadoMesas);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = true;

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }

    }
}
