using CapaEnt;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDal
{
    public class ClsServiciosDepartamentosDal
    {
        public static ClsDepartamento BuscarPersonaDal(int id)
        {
            SqlDataReader miLector;

            ClsDepartamento departamento = new ClsDepartamento();

            SqlCommand miComando = new SqlCommand();

            SqlConnection miConexion = new SqlConnection();

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                miConexion = ClsConexion.Conectar();

                miConexion.Open();

                miComando.CommandText = "SELECT * FROM Departamentos WHERE ID=@id";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        departamento.ID = (int)miLector["ID"];
                        departamento.Nombre = (String)miLector["Nombre"];
                        
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

            return departamento;
        }
    }
}
