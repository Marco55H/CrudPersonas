using CapaEnt;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDal
{
    internal class ClsServicesBDDal
    {

        private static SqlConnection miConexion = new SqlConnection();
        

        /// <summary>
        /// Funcion que usamos para borrar una persona de la vbase de datos azure
        /// </summary>
        /// <param name="id">El parametro de entrada usado para encontrar la persona en la based de datos</param>
        /// <returns>Devuelve el número de filas que han sido afectadas</returns>
        public static int DeletePersonaDAL(int id)
        {

            int numeroFilasAfectadas = 0;

            SqlCommand miComando = new SqlCommand();

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                miConexion = ClsConexion.Conectar();

                miConexion.Open();

                miComando.CommandText = "DELETE FROM personas WHERE ID=@id";

                miComando.Connection = miConexion;

                numeroFilasAfectadas = miComando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                miConexion.Close();
            }

            return numeroFilasAfectadas;

        }


        public static ClsPersona BuscarPersona(int id)
        {
            SqlDataReader miLector;

            ClsPersona persona;

            SqlCommand miComando = new SqlCommand();

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                miConexion = ClsConexion.Conectar();

                miConexion.Open();

                miComando.CommandText = "SELECT FROM personas WHERE ID=@id";

                miComando.Connection = miConexion;

                miLector= miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                miConexion.Close();
            }

            return persona;
        }


        public static int addPersona(ClsPersona persona)
        {
            int filaAfectada=0;



            return filaAfectada;
        }

        public static int ActualizarPersona(ClsPersona persona)
        {
            int filasAfectadas = 0;



            return filasAfectadas;
        }
    }
}
