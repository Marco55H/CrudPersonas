using CapaEnt;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDal
{
    public class ClsServicesBDDal
    {        

        /// <summary>
        /// Pre: El id Maoyr que 0
        /// Pos: Si no encuentra usuario devuelve persona vacia
        /// Funcion que usamos para borrar una persona de la vbase de datos azure
        /// </summary>
        /// <param name="id">El parametro de entrada usado para encontrar la persona en la based de datos</param>
        /// <returns>Devuelve el número de filas que han sido afectadas</returns>
        public static int DeletePersonaDAL(int id)
        {

            int numeroFilasAfectadas = 0;

            SqlCommand miComando = new SqlCommand();

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            SqlConnection miConexion = new SqlConnection();

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


        public static ClsPersona BuscarPersonaDal(int id)
        {
            SqlDataReader miLector;

            ClsPersona persona = new ClsPersona();

            SqlCommand miComando = new SqlCommand();

            SqlConnection miConexion = new SqlConnection();

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                miConexion = ClsConexion.Conectar();

                miConexion.Open();

                miComando.CommandText = "SELECT * FROM Personas WHERE ID=@id";

                miComando.Connection = miConexion;

                miLector= miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        persona.Id = (int)miLector["ID"];
                        persona.Nombre = (String)miLector["Nombre"];
                        persona.Apellidos = (String)miLector["Apellidos"];

                        if (miLector["Telefono"] != System.DBNull.Value)
                        {
                            persona.Telefono = (String)miLector["Telefono"];
                        }
                        if (miLector["Direccion"] != System.DBNull.Value)
                        {
                            persona.Direccion = (String)miLector["Direccion"];
                        }
                        if (miLector["Foto"] != System.DBNull.Value)
                        {
                            persona.Foto = (String)miLector["Foto"];
                        }
                        if (miLector["FechaNacimiento"] != System.DBNull.Value)
                        {
                            persona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                        }
                        if (miLector["IDDepartamento"] != System.DBNull.Value)
                        {
                            persona.IDDepartamento = (int)miLector["IDDepartamento"];
                        }

                    }
                }
                miLector.Close();
                miConexion.Close();
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


        public static int AddPersonaDal(ClsPersona persona)
        {
            int filaAfectada=0;
            SqlCommand miComando = new SqlCommand();
            SqlConnection miConexion = new SqlConnection();

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.Id;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
            miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = persona.Foto;
            miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.DateTime).Value = persona.FechaNacimiento;
            miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.DateTime).Value = persona.IDDepartamento;

            try
            {
                miConexion = ClsConexion.Conectar();
                miConexion.Open();

                miComando.CommandText = "Insert into Personas (ID, Nombre, Apellidos, Telefono, Direccion, Foto, FechaNAcimiento, IDDepartamento) Values " +
                                                             "(@id, @nombre, @apellido, @telefono, @direccion, @fechanac, @idDepartamento)";
            
                miComando.Connection = miConexion;

                filaAfectada = miComando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                miConexion.Close();
            }

            return filaAfectada;
        }

        public static int ActualizarPersonaDal(ClsPersona persona)
        {
            int filaAfectada = 0;
            SqlCommand miComando = new SqlCommand();
            SqlConnection miConexion = new SqlConnection();

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.Id;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
            miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = persona.Foto;
            miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.DateTime).Value = persona.FechaNacimiento;
            miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.DateTime).Value = persona.IDDepartamento;

            try
            {
                miConexion = ClsConexion.Conectar();
                miConexion.Open();

                miComando.CommandText = "Update Personas Set Nombre=@nombre, Apellidos=@apellidos, Telefono=@telefono, Direccion=@direccion, Foto = @foto, FechaNacimiento=@fechaNacimiento,IDDepartamento=@idDepartamento, Where ID=@id";

                miComando.Connection = miConexion;

                filaAfectada = miComando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                miConexion.Close();
            }

            return filaAfectada;
        }
    }
}
