using CapaEnt;
using Microsoft.Data.SqlClient;

namespace CapaDal
{
    public class ClsListadosBDDal
    {
        /// <summary>
        /// Devuelve listado de persoans de la base de datos de azure
        /// </summary>
        /// <returns>Listado de personas</returns>
        public static List<ClsPersona> ListadoPersonasDal()
        {
            //TODO mirar presentacionesSqlConnection miConexion= new SqlConnection();

            List<ClsPersona> listadoPersonas = new List<ClsPersona>();

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsPersona oPersona;

            try
            {
                miConexion = ClsConexion.Conectar();

                miConexion.Open();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)

                miComando.CommandText = "SELECT * FROM personas";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector

                if (miLector.HasRows)
                {

                    while (miLector.Read())

                    {

                        oPersona = new ClsPersona();

                        oPersona.Id = (int)miLector["id"];

                        oPersona.Nombre = (string)miLector["nombre"];

                        oPersona.Apellidos = (string)miLector["apellidos"];

                        //Si sospechamos que el campo puede ser Null en la BBDD

                        if (miLector["FechaNacimiento"] != System.DBNull.Value)

                        {
                            oPersona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                        }

                        oPersona.Direccion = (string)miLector["direccion"];

                        oPersona.Telefono = (string)miLector["telefono"];

                        listadoPersonas.Add(oPersona);

                    }

                }

                miLector.Close();

                miConexion.Close();

            }

            catch (SqlException exSql)
            {

                throw exSql;

            }
            finally
            {
                miConexion.Close();
            }

            return listadoPersonas;

        }
    }
}
