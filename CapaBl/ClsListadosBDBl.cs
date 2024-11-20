using CapaDal;
using CapaEnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBl
{
    public class ClsListadosBDBl
    {
        static List<ClsPersona> listaPersonasBL;

        public static List<ClsPersona> ObtenerLista()
        {
            listaPersonasBL = ClsListadosBDDal.ListadoPersonasDal();
            return listaPersonasBL;
        }
    }
}
