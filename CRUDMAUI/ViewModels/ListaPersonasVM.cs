using CapaBl;
using CapaEnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDMAUI.ViewModels
{
    internal class ListaPersonasVM
    {

        private List<ClsPersona> listaPersonas = ClsListadosBDBl.ObtenerLista();

    }
}
