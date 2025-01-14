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
    [QueryProperty(nameof(Persona), "persona")]
    class EditarPersonaVM : INotifyPropertyChanged
    {
        #region atributos
        private DelegateCommand cmdVolver;
        private ClsDepartamento departamento;
        private ClsPersonaConDepartamentoM persona;
        private DelegateCommand cmdEditado;
        private String confirma = "";
        private List<ClsDepartamento> departamentos;
        #endregion

        #region propiedades
        public List<ClsDepartamento> Departamentos { get { return departamentos; } }

        public ClsDepartamento Departamento {
            get { return departamento; }
            set
            {
                departamento = value;
                NotifyPropertyChanged("departamento");
            }
        }

        public String Confirma{get{return confirma; }}
        public DelegateCommand Editado { get { return cmdEditado; } }
        public DelegateCommand Volver { get { return cmdVolver; } }


        public ClsPersonaConDepartamentoM Persona { 
            get { return persona;} 
            set 
            {
                persona = value;
                //persona.IDDepartamento = departamento.ID;
                NotifyPropertyChanged("persona");
                cmdEditado.RaiseCanExecuteChanged();
            }
        }
        #endregion


        #region Constructor

        public EditarPersonaVM()
        {
            persona = new ClsPersonaConDepartamentoM();
            departamentos = ClsListadoDepartamentosBDBl.ClsListadoDepartamentosBl();
            cmdEditado = new DelegateCommand(cmdEditado_Execute, cmdEditado_CanExecute);
            cmdVolver = new DelegateCommand(cmdVolver_Execute, true);
        }


        #endregion


        #region Comandos

        private async void cmdVolver_Execute()
        {
            await Shell.Current.GoToAsync("///Personas");
        }


        private bool cmdEditado_CanExecute()
        {
            bool posible = false;
            if (persona.Id != null && persona.Nombre != null && persona.Telefono != null && persona.Apellidos!= null && persona.Direccion!= null && persona.Foto!=null && persona.FechaNacimiento!=null)
            {
                posible = true;
            }
            return posible;
        }

        private async void cmdEditado_Execute()
        {
            int lineas = ClsServicesBDBl.ActualizarPersonaBl(persona);
            confirma = "Ha modificado la persona";
            await Shell.Current.GoToAsync("///Personas");
        }
        #endregion


        #region PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
