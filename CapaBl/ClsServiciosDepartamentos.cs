using CapaDal;
using CapaEnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBl
{
    public class ClsServiciosDepartamentos
    {
        static ClsDepartamento departamento;

        public static ClsDepartamento BuscarDepartamentoBl(int id)
        {
            try
            {
                departamento = ClsServiciosDepartamentosDal.BuscarPersonaDal(id);
            }
            catch (Exception ex)
            {
                throw;
            }

            return departamento;
        }
    }
}
