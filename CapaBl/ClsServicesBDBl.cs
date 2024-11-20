using CapaDal;
using CapaEnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBl
{
    public class ClsServicesBDBl
    {
        static int filasAfectadas;
        static ClsPersona persona;
        public static int DeletePersonaBl(int id)
        {
            try
            {
                filasAfectadas=ClsServicesBDDal.DeletePersonaDAL(id);
                
            }
            catch (Exception ex)
            {
                throw;
            }
            return filasAfectadas;
        }

        public static ClsPersona BuscarPersonaDal(int id)
        {
            try
            {
                persona = ClsServicesBDDal.BuscarPersonaDal(id);
            }
            catch (Exception ex)
            {
                throw;
            }

            return persona;
        }

        public static int AddPersonaDal(ClsPersona personaAdd)
        {
            try
            {
                filasAfectadas = ClsServicesBDDal.AddPersonaDal(personaAdd);

            }
            catch (Exception ex)
            {
                throw;
            }

            return filasAfectadas;
        }

        public static int ActualizarPersonaDal(ClsPersona personaAdd)
        {
            try
            {
                filasAfectadas = ClsServicesBDDal.ActualizarPersonaDal(personaAdd);

            }
            catch (Exception ex)
            {
                throw;
            }

            return filasAfectadas;
        }

    }
}
