using CapaBl;
using CapaEnt;
using CRUDMAUI.Models;
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


        public List<ClsPersonaConDepartamentoM> PersonaConDepartamentoM { get { return Iniciar();}}

        public List<ClsPersonaConDepartamentoM>Iniciar()
        {        
            List<ClsPersonaConDepartamentoM> personaConDepartamento = new List<ClsPersonaConDepartamentoM> { };

            for(int i = 0;i<listaPersonas.Count;i++){
                personaConDepartamento.Add(new ClsPersonaConDepartamentoM(listaPersonas[i]));
            }
            return personaConDepartamento;
        }



    }
}
