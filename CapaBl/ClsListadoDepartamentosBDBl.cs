using CapaDal;
using CapaEnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBl
{
    public class ClsListadoDepartamentosBDBl
    {
        static List<ClsDepartamento> departamentos;

        public static List<ClsDepartamento> ClsListadoDepartamentosBl()
        {
            departamentos = ClsListadosBDDal.ListadoDepartamentosDal();
            return departamentos;
        }
    }
}
