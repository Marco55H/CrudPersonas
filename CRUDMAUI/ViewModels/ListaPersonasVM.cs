using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using CapaBl;
using CapaEnt;
using CRUDMAUI.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
        private object cmsEditar_CanExecute;
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
                cmdEditar.RaiseCanExecuteChanged();
            }

        }

        public DelegateCommand CmdBorrar { get { return cmdBorrar; } }
        public DelegateCommand CmdEditar { get { return cmdEditar; } }
        public DelegateCommand CmdCrear { get { return cmdCrear; } }

        #endregion

        #region Constructor
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
                cmdBorrar = new DelegateCommand(cmdBorrar_Execute, cmdBorrar_CanExecute);

                cmdEditar = new DelegateCommand(cmdEditar_Execute, cmdBorrar_CanExecute);

                cmdCrear = new DelegateCommand(cmdCrear_Executer, cmdCrear_CanExecute);
            }
            catch (Exception ex)
            {
                //TODO Mostrar mensaje de error
            }


        }

 

        #endregion

        #region Comandos

        private async void cmdCrear_Executer()
        {
            await Shell.Current.GoToAsync("///Create");
        }   

        private bool cmdCrear_CanExecute()
        {
            return true;
        }


        private void cmdBorrar_Execute()
        {
            int filasModificadas = ClsServicesBDBl.DeletePersonaBl(personaSeleccionada.Id);
        }


        private bool cmdBorrar_CanExecute()
        {
            bool devolver = false;
            if (personaSeleccionada != null)
            {
                devolver = true;
            }
            return devolver;
        }


        private async void cmdEditar_Execute()
        {

            ClsPersona persona = ClsServicesBDBl.BuscarPersonaBl(personaSeleccionada.Id);


            var queryParams = new Dictionary<string, object>
            {
                {"persona", persona }
            };

            await Shell.Current.GoToAsync("///Edit", queryParams);
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
