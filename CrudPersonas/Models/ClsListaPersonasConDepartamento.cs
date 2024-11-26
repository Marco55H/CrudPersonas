using CapaBl;
using CapaEnt;

namespace CRUDASP.Models
{
    public class ClsListaPersonasConDepartamento
    {
        private List<ClsPersonaConDepartamentoM> lista;


        public List<ClsPersonaConDepartamentoM> Lista { get { return lista; } }


        public ClsListaPersonasConDepartamento() {

            List<ClsPersona> listaPersonas = ClsListadosBDBl.ObtenerLista();
            this.lista = new List<ClsPersonaConDepartamentoM> { };

            for (int i = 0; i<listaPersonas.Count; i++)
            {

                this.lista.Add(new ClsPersonaConDepartamentoM(listaPersonas[i]));

            }
        }
    }
}
