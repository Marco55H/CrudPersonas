using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDal
{
    internal class ClsConexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection miConexion = new SqlConnection();
            try
            {

                miConexion.ConnectionString = "server=marco-holguin.database.windows.net;database=MarcoDB;uid=usuario;pwd=LaCampana123;trustServerCertificate = true;";

                miConexion.Open();

            }
            catch (Exception ex)
            {
                throw;
            }

            return miConexion;
        }
    }
}
