using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using CapaBl;
using CapaEnt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CRUDMAUI.ViewModels
{
    class AgregarPersonaVM : INotifyPropertyChanged
    {
        #region Atributos
        private ClsPersona persona = new ClsPersona();
        private DelegateCommand cmdCrear;
        private List<ClsDepartamento> departamentos;
        private ClsDepartamento departamento;
        private String confirma = "";
        #endregion

        #region Propiedades

        public String Confirma { get { return confirma; } }

        public ClsPersona Persona
        {
            get { return persona; }
            set
            {
                persona = value;
                NotifyPropertyChanged("persona");
                cmdCrear.RaiseCanExecuteChanged();
            }
        }

        public ClsDepartamento Departamento
        {
            get { return departamento; }
            set
            {
                departamento = value;
                NotifyPropertyChanged("departamento");

            }
        }
        public DelegateCommand CmdCrear
        {
            get { return cmdCrear; }
        }

        public List<ClsDepartamento> Departamentos
        {
            get { return departamentos; }
        }
        #endregion

        #region Constructor

        public AgregarPersonaVM()
        {
            departamentos = ClsListadoDepartamentosBDBl.ClsListadoDepartamentosBl();

            cmdCrear = new DelegateCommand(cmdCrear_Execute, cmd_CanExecute);
        }

        
        #endregion

        #region Comandos
        private bool cmd_CanExecute()
        {
            bool posible = false;
            if (persona.Id != null && persona.Nombre != null && persona.Telefono != null && persona.Apellidos != null && persona.Direccion != null && persona.Foto != null && persona.FechaNacimiento != null)
            {
                posible = true;
            }
            return posible;
        }

        private void cmdCrear_Execute()
        {
            int filas = ClsServicesBDBl.AddPersonaBl(persona);
            confirma = "Ha añadido la persona";
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
