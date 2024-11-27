using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using CapaBl;
using CapaEnt;
using CRUDMAUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CRUDMAUI.ViewModels
{
    internal class ListaPersonasVM : INotifyPropertyChanged
    {
        #region atributos
        private List<ClsPersona> listaPersonas;

        private DelegateCommand cmdCrear;

        private DelegateCommand cmdEditar;

        private DelegateCommand cmdBorrar;

        private ClsPersonaConDepartamentoM personaSeleccionada;

        public List<ClsPersonaConDepartamentoM> personasConDepartamentoM;
        #endregion

        #region Propiedades
        public List<ClsPersonaConDepartamentoM> PersonaConDepartamentoM { get { return personasConDepartamentoM; } }

        public ClsPersonaConDepartamentoM PersonaSeleccionada
        {

            get { return personaSeleccionada; }
            set
            {
                personaSeleccionada = value;
                NotifyPropertyChanged(nameof(PersonaSeleccionada));
                cmdBorrar.RaiseCanExecuteChanged();
            }

        }

        public DelegateCommand CmdBorrar { get { return cmdBorrar; } }
        public DelegateCommand CmdEditar { get { return cmdEditar; } }
        public DelegateCommand CmdCrear { get { return cmdCrear; } }

        #endregion

        public ListaPersonasVM()
        {
            try
            {
                personasConDepartamentoM = new List<ClsPersonaConDepartamentoM> { };
                listaPersonas = ClsListadosBDBl.ObtenerLista();

                for (int i = 0; i < listaPersonas.Count; i++)
                {
                    personasConDepartamentoM.Add(new ClsPersonaConDepartamentoM(listaPersonas[i]));
                }

                // Inicializar comando de navegación con Execute y CanExecute
                cmdBorrar = new DelegateCommand(cmdBorrar_Execute, cmsBorrar_CanExecute);

                cmdCrear = new DelegateCommand(cmdCrea_Executer);
            }
            catch (Exception ex)
            {
                //TODO Mostrar mensaje de error
            }


        }

        #region Comandos

        private async void cmdCrea_Executer()
        {
            await Shell.Current.GoToAsync("///Create");
        }

        
        private bool cmsBorrar_CanExecute()
        {
            bool devolver=false;
            if (personaSeleccionada != null)
            {
                devolver= true;
            }
            return devolver;
        }

        private void cmdBorrar_Execute()
        {
           
        }

        private async void cmdEditar_Execute()
        {
            Dictionary<string, Object> diccionarioMandar = new Dictionary<string, object>();

            diccionarioMandar.Add("persona", personaSeleccionada);

            await Shell.Current.GoToAsync("///Edit", diccionarioMandar);
        }

        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
